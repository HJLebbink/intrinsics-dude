// The MIT License (MIT)
//
// Copyright (c) 2021 Henk-Jan Lebbink
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace IntrinsicsDude.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    using HtmlAgilityPack;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    public class IntrinsicStore
    {
        private readonly IDictionary<Intrinsic, IList<IntrinsicDataElement>> _data;
        private static readonly IList<IntrinsicDataElement> empty = new List<IntrinsicDataElement>(0);

        public IntrinsicStore()
        {
            this._data = new Dictionary<Intrinsic, IList<IntrinsicDataElement>>();
        }

        public IntrinsicStore(string xmlfilename)
        {
            this._data = new Dictionary<Intrinsic, IList<IntrinsicDataElement>>();
            this.LoadXml(xmlfilename);
        }

        public ReadOnlyDictionary<Intrinsic, IList<IntrinsicDataElement>> Data
        {
            get
            {
                return new ReadOnlyDictionary<Intrinsic, IList<IntrinsicDataElement>>(this._data);
            }
        }

        public IList<IntrinsicDataElement> Get(Intrinsic intrinsic)
        {
            if (this._data.TryGetValue(intrinsic, out IList<IntrinsicDataElement> dataElements))
            {
                return dataElements;
            }

            IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicStore:get; intrinsic=" + intrinsic + " does not have data elements.");
            return empty;
        }

        public CpuID GetCpuID(Intrinsic intrinsic)
        {
            CpuID cpuID = CpuID.NONE;
            if (this._data.TryGetValue(intrinsic, out IList<IntrinsicDataElement> dataElements))
            {
                foreach (IntrinsicDataElement dataElement in dataElements)
                {
                    cpuID |= dataElement._cpuID;
                }
            }

            return cpuID;
        }

        #region Loading/Saving

        public void LoadHtml(string filename)
        {
            try
            {
                DateTime time1 = DateTime.Now;

                if (File.Exists(filename))
                {
                    IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: going to load file " + filename);
                }
                else
                {
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicStore: loadHtml: file " + filename + " does not exist.");
                    return;
                }

                HtmlDocument doc = new HtmlDocument();
                doc.Load(filename);

                //SortedSet<string> allIntrinsicNames = new SortedSet<string>();
                this._data.Clear();

                bool is_capitals = false;
                bool warn = true;

                foreach (HtmlNode item in doc.GetElementbyId("intrinsics_list").ChildNodes)
                {
                    IntrinsicDataElement dataElement = new IntrinsicDataElement()
                    {
                        _id = item.GetAttributeValue("id", -1),
                        _intrinsic = Intrinsic.NONE,
                    };
                    if (item.GetAttributeValue("class", string.Empty).Equals("intrinsic SVML", StringComparison.OrdinalIgnoreCase))
                    {
                        dataElement._cpuID |= CpuID.SVML;
                    }

                    IList<string> paramName = new List<string>(2);
                    IList<string> paramType = new List<string>(2);

                    #region payload
                    foreach (HtmlNode element in item.ChildNodes)
                    {
                        string elementClass = element.GetAttributeValue("class", "NONE").ToUpper();
                        //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: element.class=" + elementClass);
                        switch (elementClass)
                        {
                            case "INSTRUCTION":
                                {
                                    string instruction = element.InnerText.ToUpper();
                                    dataElement._instruction = (instruction.Equals("...")) ? "UNKNOWN" : instruction;
                                    break;
                                }

                            case "SIGNATURE":
                                break;
                            case "DETAILS":
                                {
                                    foreach (HtmlNode element2 in element.Descendants())
                                    {
                                        string element2Class = element2.GetAttributeValue("class", "NONE").ToUpper();
                                        //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: B: element2Class=" + element2Class + "; element2 " + element2.InnerText);
                                        switch (element2Class)
                                        {
                                            case "NAME":
                                                string intrinsicStr = element2.InnerText;
                                                //allIntrinsicNames.Add(intrinsicStr);
                                                dataElement._intrinsic = ParseIntrinsic(intrinsicStr, is_capitals, warn); break;
                                            case "RETTYPE": dataElement._returnType = ParseReturnType(element2.InnerText, is_capitals, warn); break;
                                            case "PARAM_TYPE": paramType.Add(element2.InnerText); break;
                                            case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                            case "DESC_VAR": break;

                                            case "DESCRIPTION": dataElement._description = AddAcronyms(ReplaceHtml(element2.InnerText)); break;
                                            case "OPERATION": dataElement._operation = AddAcronyms(ReplaceHtml(element2.InnerHtml)); break;
                                            case "CPUID": dataElement._cpuID |= ParseCpuID(element2.InnerText.Trim(), is_capitals, warn); break;
                                            case "PERFORMANCE":
                                                dataElement._performance = element2.InnerHtml;
                                                TestPerformance(dataElement._performance);
                                                break;
                                            case "INSTRUCTION_NOTE":
                                                dataElement._instructionNote = element2.InnerText; break;
                                            case "SYNOPSIS":
                                                dataElement._asm = RetrieveAsmStr(element2.InnerHtml);

                                                break;
                                            case "SIG":
                                            case "DESC_NOTE":
                                            case "NONE":
                                                break;

                                            default:
                                                if (element2Class.StartsWith("DESC_VAR"))
                                                {
                                                    // ok
                                                }
                                                else
                                                {
                                                    IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: B: found unexpected element2Class=" + element2Class + "; " + element2.InnerHtml);
                                                }

                                                break;
                                        }
                                    }

                                    break;
                                }

                            case "ALSOKNC":
                                {
                                    dataElement._cpuID |= CpuID.KNCNI;
                                    break;
                                }

                            default:
                                IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: found unexpected elementClass=" + elementClass);
                                break;
                        }

                        for (int i = 0; i < paramName.Count; ++i)
                        {
                            dataElement._parameters.Add(new Tuple<ParamType, string>(ParseParamType(paramType[i], is_capitals, warn), paramName[i]));
                        }
                    }

                    if (dataElement._cpuID == CpuID.NONE)
                    {
                        //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: Intrinsic " + dataElement.intrinsic + " does not have an cpuID, assuming IA32");
                        dataElement._cpuID = CpuID.IA32;
                    }

                    #endregion
                    #region store the dataElement
                    if (this._data.TryGetValue(dataElement._intrinsic, out IList<IntrinsicDataElement> dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0)
                        {
                            dataElement,
                        };
                        this._data.Add(dataElement._intrinsic, dataElements);
                    }
                    #endregion
                }
                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "Load HTML");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:loadHtml; e={1}", this.ToString(), e.ToString()));
            }
        }

        public void SaveXml(string filename)
        {
            IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: saveXml: filename " + filename);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version = \"1.0\" encoding = \"utf-8\" ?>");
            sb.AppendLine("<intrinsicsdudedata>");

            foreach (Intrinsic intrinsic in new SortedSet<Intrinsic>(this._data.Keys))
            {
                foreach (IntrinsicDataElement dataElement in this._data[intrinsic])
                {
                    sb.AppendLine("<intrinsic>");
                    sb.AppendLine("<id>" + dataElement._id + "</id>");
                    sb.AppendLine("<name>" + dataElement._intrinsic + "</name>");
                    sb.AppendLine("<cpuid>" + IntrinsicTools.ToString(dataElement._cpuID) + "</cpuid>");
                    sb.AppendLine("<ret>" + IntrinsicTools.ToString(dataElement._returnType) + "</ret>");

                    sb.Append("<sign>");
                    foreach (Tuple<ParamType, string> parameter in dataElement._parameters)
                    {
                        sb.Append(parameter.Item1);
                        sb.Append(' ');
                        sb.Append(parameter.Item2);
                        sb.Append(',');
                    }

                    if (dataElement._parameters.Count > 0)
                    {
                        sb.Length--; // remove the trailing comma
                    }

                    sb.AppendLine("</sign>");

                    sb.AppendLine("<instr>" + dataElement._instruction + "</instr>");
                    sb.AppendLine("<asm>" + dataElement._asm + "</asm>");
                    sb.AppendLine("<desc>" + AddHtml(dataElement._description) + "</desc>");
                    sb.AppendLine("<oper>" + AddHtml(dataElement._operation) + "</oper>");
                    sb.AppendLine("<performance>" + AddHtml(dataElement._performance) + "</performance>");
                    sb.AppendLine("</intrinsic>");
                }
            }

            sb.AppendLine("</intrinsicsdudedata>");
            File.WriteAllText(filename, sb.ToString());
        }

        public void LoadXml(string filename)
        {
            //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadXml: filename " + filename);
            try
            {
                DateTime time1 = DateTime.Now;
                XElement booksFromFile = XElement.Load(filename);

                bool is_capitals = false;
                bool warn = true;

                this._data.Clear();

                foreach (XElement intrinsicNode in booksFromFile.Nodes())
                {
                    IntrinsicDataElement dataElement = new IntrinsicDataElement();
                    foreach (XElement element in intrinsicNode.Nodes())
                    {
                        string value = element.Value;
                        switch (element.Name.ToString())
                        {
                            case "name":
                                dataElement._intrinsic = ParseIntrinsic(value, is_capitals, warn);
                                break;
                            case "id":
                                if (!int.TryParse(value, out dataElement._id))
                                {
                                    dataElement._id = -1;
                                }

                                break;
                            case "cpuid":
                                dataElement._cpuID = ParseCpuID_multiple(value, is_capitals, warn);
                                break;
                            case "ret":
                                dataElement._returnType = ParseReturnType(value, is_capitals, warn);
                                break;
                            case "sign":
                                if (value.Length > 0)
                                {
                                    foreach (string s1 in value.Split(','))
                                    {
                                        string[] a2 = s1.Split(' ');
                                        if (a2.Length == 2)
                                        {
                                            dataElement._parameters.Add(new Tuple<ParamType, string>(ParseParamType_InternalName(a2[0], warn), a2[1]));
                                        }
                                        else
                                        {
                                            IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicStore: loadXml: weird signature " + value);
                                        }
                                    }
                                }

                                break;
                            case "instr":
                                dataElement._instruction = value;
                                break;
                            case "asm":
                                dataElement._asm = value;
                                break;
                            case "desc":
                                dataElement._description = value;
                                break;
                            case "oper":
                                dataElement._operation = ReplaceHtml(value);
                                break;
                            case "performance":
                                dataElement._performance = value;
                                break;
                            default:
                                IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicStore: loadXml: unsupported name " + element.Name.ToString());
                                break;
                        }
                    }

                    #region store the dataElement
                    if (this._data.TryGetValue(dataElement._intrinsic, out IList<IntrinsicDataElement> dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0)
                        {
                            dataElement,
                        };
                        this._data.Add(dataElement._intrinsic, dataElements);
                    }
                    #endregion
                }

                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "XML-Data-Loader");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:loadXml; e={1}", this.ToString(), e.ToString()));
            }
        }

        #endregion

        #region Private Methods

        private static string RetrieveAsmStr(string str)
        {
            string startKeyword = "Instruction: ";
            string endKeyword = "<br>";

            int startPos = str.IndexOf(startKeyword);
            if (startPos == -1)
            {
                return string.Empty;
            }

            startPos += startKeyword.Length;
            int endPos = str.IndexOf(endKeyword, startPos);
            if (endPos == -1)
            {
                return string.Empty;
            }

            string result = str.Substring(startPos, endPos - startPos);
            // the result string may contain a hazard remark, remove it.
            result = Remove1SpanTag(result).ToUpper();

            result = result.Replace(", ", ",");
            result = result.Replace(" {ER}", string.Empty);
            result = result.Replace(" {K}", string.Empty);
            return result;
        }

        /// <summary>
        /// Remove one xml tag, nothing more.
        /// </summary>
        private static string Remove1SpanTag(string str)
        {
            char beginChar = '>';
            string endKeyword = "</span>";

            int endPos = str.IndexOf(endKeyword);
            if (endPos == -1)
            {
                return str;
            }

            endPos--;

            string result = string.Empty;
            for (int i = endPos; i > 0; --i)
            {
                if (str[i].Equals(beginChar))
                {
                    result = str.Substring(i + 1, endPos - i);
                    break;
                }
            }

            return result + str.Substring(endPos + 1 + endKeyword.Length);
        }

        /// <summary>
        /// Checks whether the performance string is ok
        /// </summary>
        private static void TestPerformance(string str)
        {
            string str2 = str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("<tbody>", string.Empty).Replace("</tbody>", string.Empty).Replace("<tr>", string.Empty).Replace("<td>", string.Empty);
            string[] lines = str2.Split(new string[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != 3)
                {
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicStore: testPerformance");
                }
            }
        }

        /// <summary>
        /// Replace some html special chars with asci chars
        /// </summary>
        private static string ReplaceHtml(string str)
        {
            if (str == null)
            {
                return null;
            }

            return str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
        }

        private static string AddHtml(string str)
        {
            if (str == null)
            {
                return null;
            }

            return str.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
        }

        private static string AddAcronyms(string str)
        {
            return str.
                Replace("floating-point", "FP").
                Replace("double-precision", "DP").
                Replace("single-precision", "SP");
        }

        #endregion
    }
}
