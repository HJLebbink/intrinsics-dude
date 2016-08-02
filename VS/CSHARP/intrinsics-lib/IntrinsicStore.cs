using AsmTools;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Intrinsics.IntrinsicTools;

namespace Intrinsics
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


        private void load(string filename)
        {
            Debug.WriteLine("INFO: IntrinsicStore: load: filename " + filename);
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
                                foreach (HtmlNode element2 in element.Descendants())
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
                                        case "DESCRIPTION": dataElement.description = element2.InnerHtml; break;
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

                    this._data.Add(dataElement.intrinsic, dataElement);
                    //Console.WriteLine("id " + dataElement.id + ":" + dataElement.returnType + " " + intrinsic_name + "(" + string.Join(",", paramName.ToArray()) + "); cpuid=" + string.Join(",", cpuidList.ToArray()) + "; instruction=" + instruction);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("ERROR: IntrinsicStore: load: exception " + e.ToString() + e.StackTrace);
            }
        }
    }
}
