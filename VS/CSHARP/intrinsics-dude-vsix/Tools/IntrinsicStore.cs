// The MIT License (MIT)
//
// Copyright (c) 2017 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Linq;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
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

        public ReadOnlyDictionary<Intrinsic, IList<IntrinsicDataElement>> Data {
            get {
                return new ReadOnlyDictionary<Intrinsic, IList<IntrinsicDataElement>>(this._data);
            }
        }

        public IList<IntrinsicDataElement> Get(Intrinsic intrinsic)
        {
            if (this._data.TryGetValue(intrinsic, out var dataElements))
            {
                return dataElements;
            }
            IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore:get; intrinsic=" + intrinsic +" does not have data elements.");
            return empty;
        }

        public CpuID GetCpuID(Intrinsic intrinsic)
        {
            CpuID cpuID = CpuID.NONE;
            if (this._data.TryGetValue(intrinsic, out var dataElements))
            {
                foreach(IntrinsicDataElement dataElement in dataElements)
                {
                    cpuID |= dataElement.cpuID;
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
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: going to load file " + filename);
                }
                else
                {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore: loadHtml: file " + filename + " does not exist.");
                    return;
                }

                HtmlDocument doc = new HtmlDocument();
                doc.Load(filename);

                //SortedSet<string> allIntrinsicNames = new SortedSet<string>();
                this._data.Clear();

                foreach (HtmlNode item in doc.GetElementbyId("intrinsics_list").ChildNodes)
                {
                    IntrinsicDataElement dataElement = new IntrinsicDataElement()
                    {
                        id = item.GetAttributeValue("id", -1),
                        intrinsic = Intrinsic.NONE
                    };
                    if (item.GetAttributeValue("class", "").Equals("intrinsic SVML", StringComparison.OrdinalIgnoreCase))
                    {
                        dataElement.cpuID |= CpuID.SVML;
                    }

                    IList<string> paramName = new List<string>(2);
                    IList<string> paramType = new List<string>(2);

                    #region payload
                    foreach (HtmlNode element in item.ChildNodes)
                    {
                        string elementClass = element.GetAttributeValue("class", "NONE").ToUpper();
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: element.class=" + elementClass);
                        switch (elementClass)
                        {
                            case "INSTRUCTION":
                                {
                                    string instruction = element.InnerText.ToUpper();
                                    dataElement.instruction = (instruction.Equals("...")) ? "UNKNOWN" : instruction;
                                    break;
                                }
                            case "SIGNATURE":
                                break;
                            case "DETAILS":
                                {
                                    foreach (HtmlNode element2 in element.Descendants())
                                    {
                                        string element2Class = element2.GetAttributeValue("class", "NONE").ToUpper();
                                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: B: element2Class=" + element2Class + "; element2 " + element2.InnerText);
                                        switch (element2Class)
                                        {
                                            case "NAME":
                                                string intrinsicStr = element2.InnerText;
                                                //allIntrinsicNames.Add(intrinsicStr);
                                                dataElement.intrinsic = IntrinsicTools.ParseIntrinsic(intrinsicStr); break;
                                            case "RETTYPE": dataElement.returnType = IntrinsicTools.ParseReturnType(element2.InnerText); break;
                                            case "PARAM_TYPE": paramType.Add(element2.InnerText); break;
                                            case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                            case "DESC_VAR": break;

                                            case "DESCRIPTION": dataElement.description = AddAcronyms(ReplaceHtml(element2.InnerText)); break;
                                            case "OPERATION": dataElement.operation = AddAcronyms(ReplaceHtml(element2.InnerHtml)); break;
                                            case "CPUID": dataElement.cpuID |= IntrinsicTools.ParseCpuID(element2.InnerText.Trim()); break;
                                            case "PERFORMANCE":
                                                dataElement.performance = element2.InnerHtml;
                                                TestPerformance(dataElement.performance);
                                                break;
                                            case "INSTRUCTION_NOTE":
                                                dataElement.instructionNote = element2.InnerText; break;
                                            case "SYNOPSIS":
                                                dataElement.asm = RetrieveAsmStr(element2.InnerHtml);
                                                if (dataElement.asm.Equals("psraw"))
                                                {
                                                    IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: found asmStr=" + dataElement.asm);
                                                }


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
                                                    IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: B: found unexpected element2Class=" + element2Class + "; " + element2.InnerHtml);
                                                }
                                                break;
                                        }
                                    }
                                    break;
                                }
                            case "ALSOKNC":
                                {
                                    dataElement.cpuID |= CpuID.KNCNI;
                                    break;
                                }
                            default:
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: found unexpected elementClass=" + elementClass);
                                break;
                        }

                        for (int i = 0; i < paramName.Count; ++i)
                        {
                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.ParseParamType(paramType[i]), paramName[i]));
                        }
                    }
                    if (dataElement.cpuID == CpuID.NONE)
                    {
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: Intrinsic " + dataElement.intrinsic + " does not have an cpuID, assuming IA32");
                        dataElement.cpuID = CpuID.IA32;
                    }

                    #endregion
                    #region store the dataElement
                    if (this._data.TryGetValue(dataElement.intrinsic, out var dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0)
                        {
                            dataElement
                        };
                        this._data.Add(dataElement.intrinsic, dataElements);
                    }
                    #endregion
                }
                /*
                foreach (string str in allIntrinsicNames)
                {
                    //IntrinsicsDudeToolsStatic.Output("    "+str.ToUpper() + ",");
                    IntrinsicsDudeToolsStatic.Output("case \""+str.ToUpper()+"\": return Intrinsic."+str.ToUpper() +";");
                }
                */
                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "Load HTML");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicStore: loadHtml: exception " + e.ToString());
            }
        }

        public void SaveXml(string filename)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: saveXml: filename " + filename);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version = \"1.0\" encoding = \"utf-8\" ?>");
            sb.AppendLine("<intrinsicsdudedata>");

            foreach (Intrinsic intrinsic in new SortedSet<Intrinsic>(this._data.Keys))
            {
                foreach (IntrinsicDataElement dataElement in this._data[intrinsic])
                {
                    sb.AppendLine("<intrinsic>");
                    sb.AppendLine("<id>" + dataElement.id + "</id>");
                    sb.AppendLine("<name>" + dataElement.intrinsic + "</name>");
                    sb.AppendLine("<cpuid>" + IntrinsicTools.ToString(dataElement.cpuID) + "</cpuid>");
                    sb.AppendLine("<ret>" + IntrinsicTools.ToString(dataElement.returnType) + "</ret>");

                    sb.Append("<sign>");
                    foreach (Tuple<ParamType, string> parameter in dataElement.parameters)
                    {
                        sb.Append(parameter.Item1);
                        sb.Append(' ');
                        sb.Append(parameter.Item2);
                        sb.Append(',');
                    }
                    if (dataElement.parameters.Count > 0) sb.Length--; // remove the trailing comma
                    sb.AppendLine("</sign>");

                    sb.AppendLine("<instr>" + dataElement.instruction + "</instr>");
                    sb.AppendLine("<asm>" + dataElement.asm + "</asm>");
                    sb.AppendLine("<desc>" + AddHtml(dataElement.description) + "</desc>");
                    sb.AppendLine("<oper>" + AddHtml(dataElement.operation) + "</oper>");
                    sb.AppendLine("<performance>" + AddHtml(dataElement.performance) + "</performance>");
                    sb.AppendLine("</intrinsic>");
                }
            }
            sb.AppendLine("</intrinsicsdudedata>");
            System.IO.File.WriteAllText(filename, sb.ToString());
        }

        public void LoadXml(string filename)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadXml: filename " + filename);
            try
            {
                DateTime time1 = DateTime.Now;
                XElement booksFromFile = XElement.Load(filename);

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
                                dataElement.intrinsic = IntrinsicTools.ParseIntrinsic(value);
                                break;
                            case "id":
                                if (!Int32.TryParse(value, out dataElement.id)) dataElement.id = -1;
                                break;
                            case "cpuid":
                                dataElement.cpuID = IntrinsicTools.ParseCpuID_multiple(value);
                                break;
                            case "ret":
                                dataElement.returnType = IntrinsicTools.ParseReturnType(value);
                                break;
                            case "sign":
                                if (value.Length > 0)
                                {
                                    foreach (string s1 in value.Split(','))
                                    {
                                        string[] a2 = s1.Split(' ');
                                        if (a2.Length == 2)
                                        {
                                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.ParseParamType_InternalName(a2[0]), a2[1]));
                                        }
                                        else
                                        {
                                            IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore: loadXml: weird signature " + value);
                                        }
                                    }
                                }
                                break;
                            case "instr":
                                dataElement.instruction = value;
                                break;
                            case "asm":
                                dataElement.asm = value;
                                break;
                            case "desc":
                                dataElement.description = value;
                                break;
                            case "oper":
                                dataElement.operation = ReplaceHtml(value);
                                break;
                            case "performance":
                                dataElement.performance = value;
                                break;
                            default:
                                IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore: loadXml: unsupported name " + element.Name.ToString());
                                break;
                        }
                    }

                    #region store the dataElement
                    if (this._data.TryGetValue(dataElement.intrinsic, out var dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0)
                        {
                            dataElement
                        };
                        this._data.Add(dataElement.intrinsic, dataElements);
                    }
                    #endregion
                }
                IntrinsicsDudeToolsStatic.PrintSpeedWarning(time1, "XML-Data-Loader");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicStore: loadXml: exception " + e.ToString());
            }
        }

        #endregion
       
        #region Private Methods

        private static string RetrieveAsmStr(string str)
        {
            string startKeyword = "Instruction: ";
            string endKeyword = "<br>";

            int startPos = str.IndexOf(startKeyword);
            if (startPos == -1) return "";
            startPos += startKeyword.Length;
            int endPos = str.IndexOf(endKeyword, startPos);
            if (endPos == -1) return "";
            string result = str.Substring(startPos, endPos - startPos);
            // the result string may contain a hazard remark, remove it.
            result = Remove1SpanTag(result).ToUpper();

            result = result.Replace(", ", ",");
            result = result.Replace(" {ER}", "");
            result = result.Replace(" {K}", "");
            return result;
        }

        /// <summary>
        /// Remove one xml tag, nothing more.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string Remove1SpanTag(string str)
        {
            char beginChar = '>';
            string endKeyword = "</span>";

            int endPos = str.IndexOf(endKeyword);
            if (endPos == -1) return str;
            endPos--;


            string result = "";
            for (int i = endPos; i>0; --i)
            {
                if (str[i].Equals(beginChar))
                {
                    result = str.Substring(i+1, endPos - i);
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
            string str2 = str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("<tbody>", "").Replace("</tbody>", "").Replace("<tr>", "").Replace("<td>", "");
            string[] lines = str2.Split(new string[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length != 3)
                {
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore: testPerformance");
                }
            }
        }

        /// <summary>
        /// Replace some html special chars with asci chars
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ReplaceHtml(string str)
        {
            if (str == null) return null;
            return str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
        }

        private static string AddHtml(string str)
        {
            if (str == null) return null;
            return str.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
        }

        private static string AddAcronyms(string str) {
            return str.
                Replace("floating-point", "FP").
                Replace("double-precision", "DP").
                Replace("single-precision", "SP");
        }

        #endregion
    }
}
