using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    class DataGenerator
    {
        static void Main(string[] args)
        {
            Assembly thisAssem = typeof(DataGenerator).Assembly;
            AssemblyName thisAssemName = thisAssem.GetName();
            System.Version ver = thisAssemName.Version;
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "Loaded DataGenerator version {0}.", ver));
            payload();
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, "Press any key to continue."));
            Console.ReadKey();
        }

        static void payload() {

            string filenameIn = @"H:\Dropbox\sc\GitHub\intrinsics-dude\VS\CSHARP\intrinsics-lib\Resources\Intel-Intrinsics-Guide.html";
            string filenameOut = @"H:\Dropbox\sc\GitHub\intrinsics-dude\VS\CSHARP\intrinsics-lib\Resources\output.txt";
            HtmlDocument doc = new HtmlDocument();
            doc.Load(filenameIn);


            StringBuilder sb = new StringBuilder();

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
                                    case "RETTYPE": returnType = element2.InnerText.ToUpper(); break;
                                    case "NAME": intrinsic_name = element2.InnerText.ToUpper(); break;
                                    case "PARAM_NAME": paramName.Add(element2.InnerText); break;
                                    case "PARAM_TYPE": paramType.Add(element2.InnerText.ToUpper()); break;
                                    default: break;
                                }
                            }
                            break;
                        case "DETAILS":
                            foreach (HtmlNode element2 in element.Descendants())
                            {
                                switch (element2.GetAttributeValue("class", "NONE").ToUpper())
                                {
                                    case "DESCRIPTION": description = element2.InnerText.Replace("\n", " ").Trim(); break;
                                    case "OPERATION": operation = element2.InnerHtml; break;
                                    case "CPUID": cpuidList.Add(element2.InnerText.ToUpper()); break;
                                    case "PERFORMANCE": performance = element2.InnerHtml; break;
                                    default: break;
                                }
                            }
                            break;
                        default: break;
                    }
                }
                //Console.WriteLine("    case \"" + intrinsic_name + "\": return Intrinsic." + intrinsic_name +";");


                sb.AppendLine("///<summary>"+ description+" (" + string.Join(", ", cpuidList.ToArray())+")</summary>");
                sb.AppendLine(intrinsic_name + ",");

                //Console.WriteLine("id "+id+ ":"+ returnType+" "+intrinsic_name + "("+ string.Join(",", paramName.ToArray()) +"); cpuid=" + string.Join(",", cpuidList.ToArray()) + "; instruction="+ instruction);
            }

            System.IO.File.WriteAllText(filenameOut, sb.ToString());
        }
    }
}
