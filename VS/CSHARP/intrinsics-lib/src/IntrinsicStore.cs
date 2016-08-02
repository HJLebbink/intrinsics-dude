using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicsDude.Tools
{
    public class IntrinsicStore
    {
        /// <summary>Constructor</summary>
        public IntrinsicStore()
        {
            const string filename = @"H:\Dropbox\sc\GitHub\intrinsics-dude\VS\CSHARP\data-generator\Resources\Intel-Intrinsics-Guide.html";
            this.load(filename);
        }

        public void load(string filename)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(filename);

            foreach (HtmlNode item in doc.GetElementbyId("intrinsics_list").ChildNodes)
            {
                int id = item.GetAttributeValue("id", -1);

                string returnType = null;
                string intrinsic_name = null;
                string instruction = null;
                string description = null;
                string operation = null;
                string performance = null;
                IList<string> paramName = new List<string>(2);
                IList<string> paramType = new List<string>(2);
                IList<string> cpuidList = new List<string>(1);

                foreach (HtmlNode element in item.ChildNodes)
                {
                    switch (element.GetAttributeValue("class", "NONE").ToUpper())
                    {
                        case "INSTRUCTION": instruction = element.InnerHtml; break;
                        case "SIGNATURE":
                            foreach (HtmlNode element2 in element.Descendants())
                            {
                                switch (element2.GetAttributeValue("class", "NONE").ToUpper())
                                {
                                    case "RETTYPE": returnType = element2.InnerText; break;
                                    case "NAME": intrinsic_name = element2.InnerText; break;
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
                                    case "DESCRIPTION": description = element2.InnerHtml; break;
                                    case "OPERATION": operation = element2.InnerHtml; break;
                                    case "CPUID": cpuidList.Add(element2.InnerText); break;
                                    case "PERFORMANCE": performance = element2.InnerHtml; break;
                                    default: break;
                                }
                            }
                            break;
                        default: break;
                    }
                }

                Console.WriteLine("id " + id + ":" + returnType + " " + intrinsic_name + "(" + string.Join(",", paramName.ToArray()) + "); cpuid=" + string.Join(",", cpuidList.ToArray()) + "; instruction=" + instruction);

            }

        }
    }
}
