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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public class IntrinsicDataElement
    {
        public Intrinsic intrinsic;
        public ReturnType returnType;
        public readonly IList<Tuple<ParamType, string>> parameters;
        public CpuID cpuID;
        public int id;
        public String instruction;
        public string instructionNote;

        public string description;
        public string operation;
        public string performance; // unused


        /// <summary>Constructor</summary>
        public IntrinsicDataElement()
        {
            this.parameters = new List<Tuple<ParamType, string>>();
            this.cpuID = CpuID.NONE;
        }

        public TextBlock DocumentationTextBlock {
            get {
                StringBuilder sb = new StringBuilder();
                sb.Append(IntrinsicTools.ToString(this.returnType));
                sb.Append(". .");
                sb.Append(this.intrinsic.ToString().ToLower());
                sb.Append(".(.");
                foreach (Tuple<ParamType, string> param in this.parameters)
                {
                    sb.Append(IntrinsicTools.ToString(param.Item1));
                    sb.Append(". .");
                    sb.Append(param.Item2);
                    sb.Append("., .");
                }
                if (this.parameters.Count > 0)
                {
                    sb.Length -= 4; // remove the last comma
                }
                sb.Append(".)");
                
                TextBlock description = this.AddSyntaxHighlighting(sb.ToString());

                description.Inlines.Add(MakeRunBold("  ["+IntrinsicTools.ToString(this.cpuID)+ "]\n"));
                description.Inlines.Add(new Run(IntrinsicTools.Linewrap(this.description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips)));

                if ((this.operation != null) && (this.operation.Length > 0))
                {
                    description.Inlines.Add(MakeRunBold("\n\nOperation:\n"));
                    Run run = new Run(this.operation)
                    {
                        FontFamily = new FontFamily("Consolas")
                    };
                    description.Inlines.Add(run);
                }

                if ((this.performance != null) && (this.performance.Length > 0))
                {
                    description.Inlines.Add(MakeRunBold("\n\nPerformance:\n"));
                    foreach (Run run in MakePerformance(this.performance))
                    {
                        description.Inlines.Add(run);
                    }
                }

                description.FontSize = IntrinsicsDudeToolsStatic.GetFontSize() + 2;
                //description.FontFamily = IntrinsicsDudeToolsStatic.getFontType();
                //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentQuickInfoSession; setting description fontSize={1}; fontFamily={2}", this.ToString(), description.FontSize, description.FontFamily));

                return description;
            }
        }

        public string DocumenationString {
            get {
                #region Add intrinsic signature

                StringBuilder sb = new StringBuilder();

                sb.Append(IntrinsicTools.ToString(this.returnType));
                sb.Append(" ");
                sb.Append(this.intrinsic.ToString().ToLower());
                sb.Append("(");
                foreach (Tuple<ParamType, string> param in this.parameters)
                {
                    sb.Append(IntrinsicTools.ToString(param.Item1));
                    sb.Append(" ");
                    sb.Append(param.Item2);
                    sb.Append(", ");
                }
                if (this.parameters.Count > 0)
                {
                    sb.Length -= 2; // remove the last comma
                }
                sb.Append(")  [");
                sb.Append(IntrinsicTools.ToString(this.cpuID));
                sb.AppendLine("]");
                #endregion

                sb.Append(IntrinsicTools.Linewrap(this.description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips));
                if ((this.operation != null) && (this.operation.Length > 0))
                {
                    sb.Append("\n\nOperation:\n");
                    sb.Append(this.operation);
                }
                return sb.ToString();
            }
        }

        #region Private Methods

        private TextBlock AddSyntaxHighlighting(string str)
        {
            TextBlock textBlock = new TextBlock();

            string[] a2 = str.Split('.');
            for (int i2 = 0; i2<a2.Length; ++i2)
            {
                string str2 = a2[i2];
                if (IntrinsicTools.ParseSimdRegisterType(str2, false) != SimdRegisterType.NONE)
                {
                    textBlock.Inlines.Add(MakeRun2(str2, Settings.Default.SyntaxHighlighting_Register));
                }
                else if (IntrinsicTools.GarseIntrinsic(str2, false) != Intrinsic.NONE)
                {
                    textBlock.Inlines.Add(MakeRun2(str2, Settings.Default.SyntaxHighlighting_Intrinsic));
                }
                else
                {
                    string[] a3 = str2.Split(' ');
                    for (int i3 = 0; i3 < a3.Length; ++i3)
                    {
                        string str3 = a3[i3];
                        switch (str3)
                        {
                            case "":
                                break;
                            case "__INT8":
                            case "__INT16":
                            case "__INT32":
                            case "__INT64":
                            case "const":
                            case "void":
                            case "unsigned":
                            case "char":
                            case "byte":
                            case "short":
                            case "int":
                            case "double":
                            case "float":
                                textBlock.Inlines.Add(MakeRun2(str3, System.Drawing.Color.Blue));
                                break;
                            default:
                                textBlock.Inlines.Add(MakeRunBold(str3));
                                break;
                        }
                        if (i3 < a3.Length - 1)
                        {
                            textBlock.Inlines.Add(new Run(" "));
                        }
                    }
                }
            }
            return textBlock;
        }

        private static Run MakeRunBold(string str)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold
            };
            return r1;
        }

        private static Run MakeRun2(string str, System.Drawing.Color color)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(color))
            };
            return r1;
        }

        private static IList<Run> MakePerformance(string str)
        {
            FontFamily family = new FontFamily("Consolas");
            IList<Run> list = new List<Run>();
            Run run = new Run(string.Format("{0,-20}{1,-10}{2,-10}\n", "Architecture", "Latency", "Throughput"))
            {
                FontFamily = family,
                FontStyle = FontStyles.Italic
            };
            list.Add(run);

            string str2 = str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("<tbody>", "").Replace("</tbody>", "").Replace("<tr>", "").Replace("<td>", "");
            string[] lines = str2.Split(new string[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length == 3)
                {
                    Run run1 = new Run(string.Format("{0,-20}{1,-10}{2,-10}\n", elements[0], elements[1], elements[2]))
                    {
                        FontFamily = family
                    };
                    list.Add(run1);
                }
            }
            return list;
        }

        #endregion
    }
}
