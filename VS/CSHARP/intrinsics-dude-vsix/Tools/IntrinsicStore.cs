// The MIT License (MIT)
//
// Copyright (c) 2016 Henk-Jan Lebbink
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

        /// <summary>Constructor</summary>
        public IntrinsicStore(string filename)
        {
            this._data = new Dictionary<Intrinsic, IList<IntrinsicDataElement>>();
            //this.generateData();
            this.loadXml(filename);
        }

        public IList<IntrinsicDataElement> get(Intrinsic intrinsic)
        {
            IList<IntrinsicDataElement> dataElements;
            if (this._data.TryGetValue(intrinsic, out dataElements))
            {
                return dataElements;
            }
            IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore:get; intrinsic=" + intrinsic +" does not have data elements.");
            return empty;
        }

        public CpuID getCpuID(Intrinsic intrinsic)
        {
            CpuID cpuID = CpuID.NONE;
            IList<IntrinsicDataElement> dataElements;
            if (this._data.TryGetValue(intrinsic, out dataElements))
            {
                foreach(IntrinsicDataElement dataElement in dataElements)
                {
                    cpuID |= dataElement.cpuID;
                }
            }
            return cpuID;
        }

        #region Private Methods

        /// <summary>
        /// used once to generate the data from the Intel intrinsics guide
        /// </summary>
        private void generateData()
        {
            string path = IntrinsicsDudeToolsStatic.getInstallPath() + "Resources" + Path.DirectorySeparatorChar;
            string filename = path + "Intel-Intrinsics-Guide.html";
            this.loadHtml(filename);
            this.saveXml(filename + ".xml");
            this.loadXml(filename + ".xml");
            this.saveXml(filename + ".2.xml"); // to check that that loading and saving results in the same file
        }

        private void loadHtml(string filename)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: filename " + filename);
            try
            {
                DateTime time1 = DateTime.Now;
                HtmlDocument doc = new HtmlDocument();
                doc.Load(filename);

                //SortedSet<string> allIntrinsicNames = new SortedSet<string>();
                this._data.Clear();

                foreach (HtmlNode item in doc.GetElementbyId("intrinsics_list").ChildNodes)
                {
                    IntrinsicDataElement dataElement = new IntrinsicDataElement();

                    dataElement.id = item.GetAttributeValue("id", -1);
                    dataElement.intrinsic = Intrinsic.NONE;

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
                                #region
                                string instruction = element.InnerText.ToUpper();
                                if (instruction.Equals("..."))
                                {
                                    dataElement.instruction = "NONE";
                                    dataElement.cpuID |= CpuID.SVML;
                                } else
                                {
                                    dataElement.instruction = instruction;
                                }
                                break;
                            #endregion
                            case "SIGNATURE":
                                break;
                            case "DETAILS":
                                #region
                                foreach (HtmlNode element2 in element.Descendants())
                                {
                                    string element2Class = element2.GetAttributeValue("class", "NONE").ToUpper();
                                    //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: B: element2Class=" + element2Class + "; element2 " + element2.InnerText);
                                    switch (element2Class)
                                    {
                                        case "NAME":
                                            string intrinsicStr = element2.InnerText;
                                            //allIntrinsicNames.Add(intrinsicStr);
                                            dataElement.intrinsic = IntrinsicTools.parseIntrinsic(intrinsicStr); break;
                                        case "RETTYPE": dataElement.returnType = IntrinsicTools.parseReturnType(element2.InnerText); break;
                                        case "PARAM_TYPE": paramType.Add(element2.InnerText); break;
                                        case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                        case "DESC_VAR": break;

                                        case "DESCRIPTION": dataElement.description = removeHtml(element2.InnerText); break;
                                        case "OPERATION": dataElement.operation = removeHtml(element2.InnerHtml); break;
                                        case "CPUID": dataElement.cpuID |= IntrinsicTools.parseCpuID(element2.InnerText); break;
                                        case "PERFORMANCE": dataElement.performance = element2.InnerHtml; break;
                                        case "INSTRUCTION_NOTE": dataElement.instructionNote = element2.InnerText; break;

                                        case "SIG":
                                        case "SYNOPSIS":
                                        case "DESC_NOTE":
                                        case "NONE":
                                            break;

                                        default:
                                            if (element2Class.StartsWith("DESC_VAR")) {
                                                // ok
                                            } else
                                            {
                                                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: B: found unexpected element2Class=" + element2Class + "; " + element2.InnerHtml);
                                            }
                                            break;
                                    }
                                }
                                break;
                            #endregion
                            case "ALSOKNC":
                                dataElement.cpuID |= CpuID.KNCNI;
                                break;
                            default:
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: found unexpected elementClass=" + elementClass);
                                break;
                        }

                        if (dataElement.cpuID == CpuID.NONE)
                        {
                            dataElement.cpuID = CpuID.DEFAULT;
                        }
                        for (int i = 0; i < paramName.Count; ++i)
                        {
                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.parseParamType(paramType[i]), paramName[i]));
                        }
                    }
                    #endregion

                    #region store the dataElement

                    IList<IntrinsicDataElement> dataElements = null;
                    if (this._data.TryGetValue(dataElement.intrinsic, out dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0);
                        dataElements.Add(dataElement);
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
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Load HTML");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicStore: loadHtml: exception " + e.ToString());
            }
        }

        private void saveXml(string filename)
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
                    sb.AppendLine("<desc>" + addHtml(dataElement.description) + "</desc>");
                    sb.AppendLine("<oper>" + addHtml(dataElement.operation) + "</oper>");
                    //sb.AppendLine("<performance>" + addHtml(dataElement.performance) + "</performance>");
                    sb.AppendLine("</intrinsic>");
                }
            }
            sb.AppendLine("</intrinsicsdudedata>");
            System.IO.File.WriteAllText(filename, sb.ToString());
        }

        private void loadXml(string filename)
        {
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadXml: filename " + filename);
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
                                dataElement.intrinsic = IntrinsicTools.parseIntrinsic(value);
                                break;
                            case "id":
                                if (!Int32.TryParse(value, out dataElement.id)) dataElement.id = -1;
                                break;
                            case "cpuid":
                                dataElement.cpuID = IntrinsicTools.parseCpuID_multiple(value);
                                break;
                            case "ret":
                                dataElement.returnType = IntrinsicTools.parseReturnType(value);
                                break;
                            case "sign":
                                if (value.Length > 0)
                                {
                                    foreach (string s1 in value.Split(','))
                                    {
                                        string[] a2 = s1.Split(' ');
                                        if (a2.Length == 2)
                                        {
                                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.parseParamType_InternalName(a2[0]), a2[1]));
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
                            case "desc":
                                dataElement.description = value;
                                break;
                            case "oper":
                                dataElement.operation = removeHtml(value);
                                break;
                            default:
                                IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore: loadXml: unsupported name " + element.Name.ToString());
                                break;
                        }
                    }

                    #region store the dataElement
                    IList<IntrinsicDataElement> dataElements = null;
                    if (this._data.TryGetValue(dataElement.intrinsic, out dataElements))
                    {
                        dataElements.Add(dataElement);
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: loadHtml: multiple data elements for intrinsic " + dataElement.intrinsic);
                    }
                    else
                    {
                        dataElements = new List<IntrinsicDataElement>(0);
                        dataElements.Add(dataElement);
                        this._data.Add(dataElement.intrinsic, dataElements);
                    }
                    #endregion
                }
                IntrinsicsDudeToolsStatic.printSpeedWarning(time1, "Load XML");
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicStore: loadXml: exception " + e.ToString());
            }
        }

        private static string removeHtml(string str)
        {
            if (str == null) return null;
            return str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
        }

        private static string addHtml(string str)
        {
            if (str == null) return null;
            return str.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;");
        }

        #endregion
    }
}
