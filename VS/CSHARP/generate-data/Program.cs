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

using IntrinsicsDude.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntrinsicsDude.GenerateData
{
    class Program
    {
        static void Main(string[] args)
        {
            IntrinsicStore store = new IntrinsicStore();

            /// used once to generate the data from the Intel intrinsics guide. 
            /// To create the hmtl, use https://software.intel.com/sites/landingpage/IntrinsicsGuide/#=undefined

            string path = IntrinsicsDudeToolsStatic.GetInstallPath() + "Resources" + Path.DirectorySeparatorChar;
            //string filename = path + "Intel-Intrinsics-Guide-(11-aug-16).html";
            string fileIn = path + "Intel-Intrinsics-Guide-(01-feb-17).html";
            string performance_Filename = path + "Performance.txt";



            Console.WriteLine("Converting file " + fileIn + ".");
            store.LoadHtml(fileIn);

            string fileOut = path + "Intrinsics-Data.xml";
            if (false)
            {
                Console.WriteLine("Saving file " + fileOut + ".");
                store.SaveXml(fileOut);
            }

            if (false)
            {
                IntrinsicStore store2 = new IntrinsicStore();
                store2.LoadXml(fileOut);
                store2.SaveXml(fileOut + ".2.xml"); // to check that that loading and saving results in the same file
            }

            if (true)
            {
                IDictionary<string, string> performanceData = new SortedDictionary<string, string>();

                foreach (var x in store.Data)
                {
                    if (x.Value.Count > 1)
                        Console.WriteLine("intrinsic " + x.Key + " : " + x.Value.Count);

                    foreach (IntrinsicDataElement y in x.Value)
                    {
                        string perf = y.performance;
                        string asm = y.asm;

                        if ((perf == null) || (perf.Length == 0))
                        {
                            //Console.WriteLine("intrinsic " + x.Key + " : performance is null");
                        }
                        else
                        {
                            if (performanceData.ContainsKey(asm))
                            {
                                if (!performanceData[asm].Equals(perf))
                                {
                                    Console.WriteLine("Asm" + asm + " already exists!");
                                    Console.WriteLine("  : " + perf);
                                    Console.WriteLine("  : " + performanceData[asm]);
                                }
                            } else
                            {
                                performanceData.Add(new KeyValuePair<string, string>(asm, perf));
                            }
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> entry in performanceData)
                {
                    sb.AppendLine(entry.Key.ToUpper() + "\t" + entry.Value);
                }
                System.IO.File.WriteAllText(performance_Filename, sb.ToString());
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
