﻿// The MIT License (MIT)
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
        public string performance;
        public string operation;


        /// <summary>Constructor</summary>
        public IntrinsicDataElement()
        {
            parameters = new List<Tuple<ParamType, string>>();
            cpuID = CpuID.NONE;
        }

        public TextBlock descriptionTextBlock {
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
                
                TextBlock description = this.addSyntaxHighlighting(sb.ToString());

                description.Inlines.Add(makeRunBold("  ["+IntrinsicTools.ToString(this.cpuID, true)+ "]\n"));
                description.Inlines.Add(new Run(IntrinsicTools.linewrap(this.description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips)));
                if ((this.operation != null) && (this.operation.Length > 0))
                {
                    description.Inlines.Add(makeRunBold("\n\nOperation:\n"));
                    description.Inlines.Add(new Run(this.operation));
                }

                description.FontSize = IntrinsicsDudeToolsStatic.getFontSize() + 2;
                //description.FontFamily = IntrinsicsDudeToolsStatic.getFontType();
                //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:AugmentQuickInfoSession; setting description fontSize={1}; fontFamily={2}", this.ToString(), description.FontSize, description.FontFamily));

                return description;
            }
        }

        public string descriptionString {
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
                sb.Append(IntrinsicTools.ToString(this.cpuID, true));
                sb.AppendLine("]");
                #endregion

                sb.Append(IntrinsicTools.linewrap(this.description, IntrinsicsDudePackage.maxNumberOfCharsInToolTips));
                if ((this.operation != null) && (this.operation.Length > 0))
                {
                    sb.Append("\n\nOperation:\n");
                    sb.Append(this.operation);
                }
                return sb.ToString();
            }
        }

        #region Private Methods

        private TextBlock addSyntaxHighlighting(string str)
        {
            TextBlock textBlock = new TextBlock();

            string[] a2 = str.Split('.');
            for (int i2 = 0; i2<a2.Length; ++i2)
            {
                string str2 = a2[i2];
                if (IntrinsicTools.parseSimdRegisterType(str2, false) != SimdRegisterType.NONE)
                {
                    textBlock.Inlines.Add(makeRun2(str2, Settings.Default.SyntaxHighlighting_Register));
                }
                else if (IntrinsicTools.parseIntrinsic(str2, false) != Intrinsic.NONE)
                {
                    textBlock.Inlines.Add(makeRun2(str2, Settings.Default.SyntaxHighlighting_Intrinsic));
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
                                textBlock.Inlines.Add(makeRun2(str3, System.Drawing.Color.Blue));
                                break;
                            default:
                                textBlock.Inlines.Add(makeRunBold(str3));
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

        private static Run makeRunBold(string str)
        {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            return r1;
        }

        private static Run makeRun2(string str, System.Drawing.Color color)
        {
            Run r1 = new Run(str);
            r1.FontWeight = FontWeights.Bold;
            r1.Foreground = new SolidColorBrush(IntrinsicsDudeToolsStatic.convertColor(color));
            return r1;
        }
        #endregion
    }
}
