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
            return _data[intrinsic];
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

                    IList<string> paramName = new List<string>(2);
                    IList<string> paramType = new List<string>(2);
                    IList<string> cpuidList = new List<string>(1);

                    #region payload
                    foreach (HtmlNode element in item.ChildNodes)
                    {
                        switch (element.GetAttributeValue("class", "NONE").ToUpper())
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
                                foreach (HtmlNode element2 in element.Descendants(1))
                                {
                                    switch (element2.GetAttributeValue("class", "NONE").ToUpper())
                                    {
                                        case "RETTYPE": dataElement.returnType = IntrinsicTools.parseReturnType(element2.InnerText); break;
                                        case "NAME": dataElement.intrinsic = IntrinsicTools.parseIntrinsic(element2.InnerText); break;
                                        case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                        case "PARAM_TYPE": paramType.Add(element2.InnerText); break;
                                        default: break;
                                    }
                                }
                                break;
                            case "DETAILS":
                                foreach (HtmlNode element2 in element.Descendants())
                                {
                                    switch (element2.GetAttributeValue("class", "NONE").ToUpper())
                                    {
                                        case "DESCRIPTION": dataElement.description = removeHtml(element2.InnerText); break;
                                        case "OPERATION": dataElement.operation = element2.InnerHtml; break;
                                        case "CPUID": cpuidList.Add(element2.InnerText); break;
                                        case "PERFORMANCE": dataElement.performance = element2.InnerHtml; break;
                                        default: break;
                                    }
                                }
                                break;
                            default: break;
                        }

                        for (int i = 0; i < paramName.Count; ++i)
                        {
                            dataElement.parameters.Add(new Tuple<ParamType, string>(IntrinsicTools.parseParamType(paramType[i]), paramName[i]));
                        }

                        dataElement.cpuID = CpuID.NONE;
                        for (int i = 0; i < cpuidList.Count; ++i)
                        {
                            dataElement.cpuID |= IntrinsicTools.parseCpuID(cpuidList[i]);
                        }
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
