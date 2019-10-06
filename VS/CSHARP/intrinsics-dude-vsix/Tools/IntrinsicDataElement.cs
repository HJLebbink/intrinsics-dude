// The MIT License (MIT)
//
// Copyright (c) 2019 Henk-Jan Lebbink
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
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using Microsoft.VisualStudio.Shell;
    using static IntrinsicsDude.Tools.IntrinsicTools;

    public class IntrinsicDataElement
    {
        public Intrinsic _intrinsic;
        public ReturnType _returnType;
        public readonly IList<Tuple<ParamType, string>> _parameters;
        public CpuID _cpuID;
        public int _id;
        public string _instruction;
        public string _instructionNote;
        public string _asm;
        public string _description;
        public string _operation;
        public string _performance; // unused

        /// <summary>Constructor</summary>
        public IntrinsicDataElement()
        {
            this._parameters = new List<Tuple<ParamType, string>>();
            this._cpuID = CpuID.ARCH_NONE;
        }

        public TextBlock DocumentationTextBlock(Brush foreground)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(IntrinsicTools.ToString(this._returnType));
            sb.Append(". .");
            sb.Append(this._intrinsic.ToString().ToLower());
            sb.Append(".(.");
            foreach (Tuple<ParamType, string> param in this._parameters)
            {
                sb.Append(IntrinsicTools.ToString(param.Item1));
                sb.Append(". .");
                sb.Append(param.Item2);
                sb.Append("., .");
            }

            if (this._parameters.Count > 0)
            {
                sb.Length -= 4; // remove the last comma
            }

            sb.Append(".)");

            TextBlock description = this.AddSyntaxHighlighting(sb.ToString(), foreground);

            description.Inlines.Add(MakeRunBold("  [" + IntrinsicTools.ToString(this._cpuID) + "]\n", foreground));
            description.Inlines.Add(new Run(IntrinsicTools.Linewrap(this._description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips))
            {
                Foreground = IntrinsicsDudeToolsStatic.Get_Font_Color_Async().Result,
            });

            if ((this._operation != null) && (this._operation.Length > 0))
            {
                description.Inlines.Add(MakeRunBold("\n\nOperation:\n", foreground));
                description.Inlines.Add(new Run(this._operation)
                {
                    FontFamily = new FontFamily("Consolas"),
                    Foreground = foreground,
                });
            }

            if ((this._performance != null) && (this._performance.Length > 0))
            {
                description.Inlines.Add(MakeRunBold("\n\nPerformance:\n", foreground));
                foreach (Run run in MakePerformance(this._performance, foreground))
                {
                    description.Inlines.Add(run);
                }
            }

            description.FontSize = IntrinsicsDudeToolsStatic.Get_Font_Size_Async().Result + 2;
            //description.FontFamily = IntrinsicsDudeToolsStatic.getFontType();
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentQuickInfoSession; setting description fontSize={1}; fontFamily={2}", this.ToString(), description.FontSize, description.FontFamily));

            return description;
        }

        public string DocumenationString
        {
            get
            {
                #region Add intrinsic signature

                StringBuilder sb = new StringBuilder();

                sb.Append(IntrinsicTools.ToString(this._returnType));
                sb.Append(" ");
                sb.Append(this._intrinsic.ToString().ToLower());
                sb.Append("(");
                foreach (Tuple<ParamType, string> param in this._parameters)
                {
                    sb.Append(IntrinsicTools.ToString(param.Item1));
                    sb.Append(" ");
                    sb.Append(param.Item2);
                    sb.Append(", ");
                }

                if (this._parameters.Count > 0)
                {
                    sb.Length -= 2; // remove the last comma
                }

                sb.Append(")  [");
                sb.Append(IntrinsicTools.ToString(this._cpuID));
                sb.AppendLine("]");
                #endregion

                sb.Append(IntrinsicTools.Linewrap(this._description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips));
                if ((this._operation != null) && (this._operation.Length > 0))
                {
                    sb.Append("\n\nOperation:\n");
                    sb.Append(this._operation);
                }

                return sb.ToString();
            }
        }

        #region Private Methods

        private TextBlock AddSyntaxHighlighting(string str, Brush foreground)
        {
            TextBlock textBlock = new TextBlock();

            //str = str.ToUpper();
            bool is_capitals = false;
            bool warn = false;

            string[] a2 = str.Split('.');
            for (int i2 = 0; i2 < a2.Length; ++i2)
            {
                string str2 = a2[i2];
                if (ParseSimdRegisterType(str2, is_capitals, warn) != SimdRegisterType.NONE)
                {
                    textBlock.Inlines.Add(MakeRun2(str2, new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.SyntaxHighlighting_Register))));
                }
                else if (ParseIntrinsic(str2, is_capitals, warn) != Intrinsic.NONE)
                {
                    textBlock.Inlines.Add(MakeRun2(str2, new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.SyntaxHighlighting_Intrinsic))));
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
                                //textBlock.Inlines.Add(MakeRun2(str3, new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(System.Drawing.Color.Blue))));
                                textBlock.Inlines.Add(MakeRunBold(str3, foreground));
                                break;
                            case "const":
                            case "void":
                            case "unsigned":
                            case "char":
                            case "byte":
                            case "short":
                            case "int":
                            case "double":
                            case "float":
                                //textBlock.Inlines.Add(MakeRun2(str3, new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(System.Drawing.Color.Blue))));
                                textBlock.Inlines.Add(MakeRunBold(str3.ToLower(), foreground));
                                break;
                            default:
                                textBlock.Inlines.Add(MakeRunBold(str3, foreground));
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

        private static Run MakeRunBold(string str, Brush foreground)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold,
                Foreground = foreground, //new SolidColorBrush(IntrinsicsDudeToolsStatic.ConvertColor(Settings.Default.TextEditorColorForeGround))
            };
            return r1;
        }

        private static Run MakeRun2(string str, Brush foreground)
        {
            Run r1 = new Run(str)
            {
                FontWeight = FontWeights.Bold,
                Foreground = foreground,
            };
            return r1;
        }

        private static IList<Run> MakePerformance(string str, Brush foreground)
        {
            FontFamily family = new FontFamily("Consolas");
            IList<Run> list = new List<Run>();

            Run run = new Run(string.Format("{0,-20}{1,-10}{2,-10}\n", "Architecture", "Latency", "Throughput"))
            {
                FontFamily = family,
                FontStyle = FontStyles.Italic,
                Foreground = foreground,
            };
            run.SetResourceReference(Border.BackgroundProperty, VsBrushes.ToolWindowTextKey);

            list.Add(run);

            string str2 = str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("<tbody>", string.Empty).Replace("</tbody>", string.Empty).Replace("<tr>", string.Empty).Replace("<td>", string.Empty);
            string[] lines = str2.Split(new string[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] elements = lines[i].Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Length == 3)
                {
                    Run run1 = new Run(string.Format("{0,-20}{1,-10}{2,-10}\n", elements[0], elements[1], elements[2]))
                    {
                        FontFamily = family,
                        Foreground = foreground,
                    };
                    list.Add(run1);
                }
            }

            return list;
        }

        #endregion
    }
}
