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

using AsmTools;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public class IntrinsicStore
    {
        private readonly IDictionary<Intrinsic, IntrinsicDataElement> _data;

        /// <summary>Constructor</summary>
        public IntrinsicStore(string filename)
        {
            this._data = new Dictionary<Intrinsic, IntrinsicDataElement>();
            this.load(filename);
        }

        public IntrinsicDataElement get(Intrinsic intrinsic)
        {
            IntrinsicDataElement value;
            if (this._data.TryGetValue(intrinsic, out value))
            {
                return value;
            }
            IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicStore:get; intrinsic=" + intrinsic +" does not have a data element.");
            return null;
        }

        public CpuID getCpuID(Intrinsic intrinsic)
        {
            IntrinsicDataElement dataElement;
            if (this._data.TryGetValue(intrinsic, out dataElement))
            {
                return dataElement.cpuID;
            }
            return CpuID.NONE;
        }

        #region Private Methods

        private void load(string filename)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: load: filename " + filename);
            try
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(filename);

                foreach (HtmlNode item in doc.GetElementbyId("intrinsics_list").ChildNodes)
                {
                    IntrinsicDataElement dataElement = new IntrinsicDataElement();

                    dataElement.id = item.GetAttributeValue("id", -1);
                    dataElement.intrinsic = Intrinsic.NONE;

                    bool printit = false;// dataElement.id == 8;


                    IList<string> paramName = new List<string>(2);
                    IList<string> paramType = new List<string>(2);
                    IList<string> cpuidList = new List<string>(1);
                    bool CpuID_KNCNI = false;

                    #region payload
                    foreach (HtmlNode element in item.ChildNodes)
                    {
                        string elementClass = element.GetAttributeValue("class", "NONE").ToUpper();
                        if (printit) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: load: element.class=" + elementClass);
                        switch (elementClass)
                        {
                            case "INSTRUCTION":
                                string instruction = element.InnerText.ToUpper();
                                if (instruction.Equals("..."))
                                {
                                    dataElement.isSVML = true;
                                }
                                dataElement.instruction = AsmSourceTools.parseMnemonic(instruction);
                                break;
                            case "SIGNATURE":
                                break;
                            case "DETAILS":
                                foreach (HtmlNode element2 in element.Descendants())
                                {
                                    string element2Class = element2.GetAttributeValue("class", "NONE").ToUpper();
                                    if (printit) IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: load: B: element2Class=" + element2Class + "; element2 " + element2.InnerText);
                                    switch (element2Class)
                                    {
                                        case "NAME": dataElement.intrinsic = IntrinsicTools.parseIntrinsic(element2.InnerText); break;
                                        case "RETTYPE": dataElement.returnType = IntrinsicTools.parseReturnType(element2.InnerText); break;
                                        case "PARAM_TYPE": paramType.Add(element2.InnerText); break;
                                        case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                        case "DESC_VAR": break;

                                        case "DESCRIPTION": dataElement.description = removeHtml(element2.InnerText); break;
                                        case "OPERATION": dataElement.operation = element2.InnerHtml; break;
                                        case "CPUID": cpuidList.Add(element2.InnerText); break;
                                        case "PERFORMANCE": dataElement.performance = element2.InnerText; break;
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
                                                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: load: B: found unexpected element2Class=" + element2Class + "; " + element2.InnerHtml);
                                            }
                                            break;
                                    }
                                }
                                break;
                            case "ALSOKNC":
                                CpuID_KNCNI = true;
                                break;
                            default:
                                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicStore: load: found unexpected elementClass=" + elementClass);
                                break;
                        }

                        for (int i = 0; i < paramName.Count; ++i)
                        {
                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.parseParamType(paramType[i]), paramName[i]));
                        }

                        #region Set CpuID
                        dataElement.cpuID = CpuID.NONE;
                        for (int i = 0; i < cpuidList.Count; ++i)
                        {
                            dataElement.cpuID |= IntrinsicTools.parseCpuID(cpuidList[i]);
                        }
                        if (CpuID_KNCNI)
                        {
                            dataElement.cpuID |= CpuID.KNCNI;
                        }
                        #endregion
                    }
                    #endregion
                    if (!this._data.ContainsKey(dataElement.intrinsic))
                    {
                        this._data.Add(dataElement.intrinsic, dataElement);
                    }
                    //Console.WriteLine("id " + dataElement.id + ":" + dataElement.returnType + " " + intrinsic_name + "(" + string.Join(",", paramName.ToArray()) + "); cpuid=" + string.Join(",", cpuidList.ToArray()) + "; instruction=" + instruction);
                }
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicStore: load: exception " + e.ToString());
            }
        }

        private static string removeHtml(string str)
        {
            return str;
        }

        #endregion
    }
}
