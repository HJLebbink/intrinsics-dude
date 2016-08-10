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

using Microsoft.VisualStudio.Text;
using System;
using System.Text;

namespace IntrinsicsDude.Tools
{
    public static partial class IntrinsicTools {
        public const int SCAN_BUFFER_SIZE = 500;

        public enum IntrinsicRegisterType
        {
            NONE,
            __M128,
            __M128D,
            __M128I,
            __M256,
            __M256D,
            __M256I,
            __M512,
            __M512D,
            __M512I,
            __M64,
            __MMASK16,
            __MMASK32,
            __MMASK64,
            __MMASK8,
        }

        [Flags]
        public enum CpuID
        {
            NONE        = 0,
            ADX         = 1 << 0,
            AES         = 1 << 1,
            AVX         = 1 << 2,
            AVX2        = 1 << 3,
            AVX512BW    = 1 << 4,
            AVX512CD    = 1 << 5,
            AVX512DQ    = 1 << 6,
            AVX512ER    = 1 << 7,
            AVX512F     = 1 << 8,
            AVX512VL    = 1 << 9,
            BMI1        = 1 << 10,
            BMI2        = 1 << 11,
            CLFLUSHOPT  = 1 << 12,
            FMA         = 1 << 13,
            FP16C       = 1 << 14,
            FXSR        = 1 << 15,
            KNCNI       = 1 << 16,
            MMX         = 1 << 17,
            MPX         = 1 << 18,
            PCLMULQDQ   = 1 << 19,
            SSE         = 1 << 20,
            SSE2        = 1 << 21,
            SSE3        = 1 << 22,
            SSE4_1      = 1 << 23,
            SSE4_2      = 1 << 24,
            SSSE3       = 1 << 25
        }

        public enum ReturnType
        {
            NONE,
            __INT16,
            __INT32,
            __INT64,
            __INT8,
            __M128,
            __M128D,
            __M128I,
            __M256,
            __M256D,
            __M256I,
            __M512,
            __M512D,
            __M512I,
            __M64,
            __MMASK16,
            __MMASK32,
            __MMASK64,
            __MMASK8,
            CONST_VOID_PTR,
            DOUBLE,
            FLOAT,
            INT,
            UNSIGNED__INT32,
            UNSIGNED__INT64,
            UNSIGNED_CHAR,
            UNSIGNED_INT,
            UNSIGNED_SHORT,
            VOID,
            VOID_PTR
        }

        public enum ParamType
        {
            NONE,
            __INT32,
            __INT32_PTR,
            __INT64,
            __INT64_CONST_PTR,
            __INT64_PTR,
            __M128,
            __M128_CONST_PTR,
            __M128D,
            __M128D_CONST_PTR,
            __M128I,
            __M256,
            __M256D,
            __M256I,
            __M512,
            __M512D,
            __M512I,
            __M64,
            __MMASK16,
            __MMASK16_PTR,
            __MMASK32,
            __MMASK64,
            __MMASK8,
            _MM_BROADCAST32_ENUM,
            _MM_BROADCAST64_ENUM,
            _MM_DOWNCONV_EPI32_ENUM,
            _MM_DOWNCONV_EPI64_ENUM,
            _MM_DOWNCONV_PD_ENUM,
            _MM_DOWNCONV_PS_ENUM,
            _MM_EXP_ADJ_ENUM,
            _MM_MANTISSA_NORM_ENUM,
            _MM_MANTISSA_SIGN_ENUM,
            _MM_UPCONV_EPI32_ENUM,
            _MM_UPCONV_EPI64_ENUM,
            _MM_UPCONV_PD_ENUM,
            _MM_UPCONV_PS_ENUM,
            CONST_MM_CMPINT_ENUM,
            CONST_INT,
            CONST_VOID_PTR,
            CONST_VOID_PTR_PTR,
            DOUBLE,
            DOUBLE_CONST_PTR,
            FLOAT,
            FLOAT_CONST_PTR,
            INT,
            INT_CONST_PTR,
            SIZE_T,
            UNSIGNED__INT32,
            UNSIGNED__INT32_PTR,
            UNSIGNED__INT64,
            UNSIGNED__INT64_PTR,
            UNSIGNED_CHAR,
            UNSIGNED_INT,
            UNSIGNED_INT_PTR,
            UNSIGNED_SHORT,
            VOID,
            VOID_PTR,
            VOID_CONST_PTR
        }

        public static IntrinsicRegisterType parseIntrinsicRegisterType(string str)
        {
            switch (str.ToUpper())
            {
                case "__M128": return IntrinsicRegisterType.__M128;
                case "__M128D": return IntrinsicRegisterType.__M128D;
                case "__M128I": return IntrinsicRegisterType.__M128I;
                case "__M256": return IntrinsicRegisterType.__M256;
                case "__M256D": return IntrinsicRegisterType.__M256D;
                case "__M256I": return IntrinsicRegisterType.__M256I;
                case "__M512": return IntrinsicRegisterType.__M512;
                case "__M512D": return IntrinsicRegisterType.__M512D;
                case "__M512I": return IntrinsicRegisterType.__M512I;
                case "__M64": return IntrinsicRegisterType.__M64;
                case "__MMASK16": return IntrinsicRegisterType.__MMASK16;
                case "__MMASK32": return IntrinsicRegisterType.__MMASK32;
                case "__MMASK64": return IntrinsicRegisterType.__MMASK64;
                case "__MMASK8": return IntrinsicRegisterType.__MMASK8;
                default:
                    Console.WriteLine("parseIntrinsicRegisterType: unknown return type \"" + str + "\".");
                    return IntrinsicRegisterType.NONE;
            }
        }

        public static ReturnType parseReturnType(string str)
        {
            switch (str.ToUpper())
            {
                case "__INT16": return ReturnType.__INT16;
                case "__INT32": return ReturnType.__INT32;
                case "__INT64": return ReturnType.__INT64;
                case "__INT8": return ReturnType.__INT8;
                case "__M128": return ReturnType.__M128;
                case "__M128D": return ReturnType.__M128D;
                case "__M128I": return ReturnType.__M128I;
                case "__M256": return ReturnType.__M256;
                case "__M256D": return ReturnType.__M256D;
                case "__M256I": return ReturnType.__M256I;
                case "__M512": return ReturnType.__M512;
                case "__M512D": return ReturnType.__M512D;
                case "__M512I": return ReturnType.__M512I;
                case "__M64": return ReturnType.__M64;
                case "__MMASK16": return ReturnType.__MMASK16;
                case "__MMASK32": return ReturnType.__MMASK32;
                case "__MMASK64": return ReturnType.__MMASK64;
                case "__MMASK8": return ReturnType.__MMASK8;
                case "CONST VOID *": return ReturnType.CONST_VOID_PTR;
                case "DOUBLE": return ReturnType.DOUBLE;
                case "FLOAT": return ReturnType.FLOAT;
                case "INT": return ReturnType.INT;
                case "UNSIGNED __INT32": return ReturnType.UNSIGNED__INT32;
                case "UNSIGNED __INT64": return ReturnType.UNSIGNED__INT64;
                case "UNSIGNED CHAR": return ReturnType.UNSIGNED_CHAR;
                case "UNSIGNED INT": return ReturnType.UNSIGNED_INT;
                case "UNSIGNED SHORT": return ReturnType.UNSIGNED_SHORT;
                case "VOID": return ReturnType.VOID;
                case "VOID *": return ReturnType.VOID_PTR;
                default:
                    Console.WriteLine("parseReturnType: unknown return type \"" + str+"\".");
                    return ReturnType.NONE;
            }
        }
        
        public static ParamType parseParamType(string str)
        {
            switch (str.ToUpper())
            {
                case "__INT32": return ParamType.__INT32;
                case "__INT32*": return ParamType.__INT32_PTR;
                case "__INT64": return ParamType.__INT64;
                case "__INT64 CONST*": return ParamType.__INT64_CONST_PTR;
                case "__INT64*": return ParamType.__INT64_PTR;
                case "__M128": return ParamType.__M128;
                case "__M128 CONST *": return ParamType.__M128_CONST_PTR;
                case "__M128D": return ParamType.__M128D;
                case "__M128D CONST *": return ParamType.__M128D_CONST_PTR;
                case "__M128I": return ParamType.__M128I;
                case "__M256": return ParamType.__M256;
                case "__M256D": return ParamType.__M256D;
                case "__M256I": return ParamType.__M256I;
                case "__M512": return ParamType.__M512;
                case "__M512D": return ParamType.__M512D;
                case "__M512I": return ParamType.__M512I;
                case "__M64": return ParamType.__M64;
                case "__MMASK16": return ParamType.__MMASK16;
                case "__MMASK16 *": return ParamType.__MMASK16_PTR;
                case "__MMASK32": return ParamType.__MMASK32;
                case "__MMASK64": return ParamType.__MMASK64;
                case "__MMASK8": return ParamType.__MMASK8;
                case "_MM_BROADCAST32_ENUM": return ParamType._MM_BROADCAST32_ENUM;
                case "_MM_BROADCAST64_ENUM": return ParamType._MM_BROADCAST64_ENUM;
                case "_MM_DOWNCONV_EPI32_ENUM": return ParamType._MM_DOWNCONV_EPI32_ENUM;
                case "_MM_DOWNCONV_EPI64_ENUM": return ParamType._MM_DOWNCONV_EPI64_ENUM;
                case "_MM_DOWNCONV_PD_ENUM": return ParamType._MM_DOWNCONV_PD_ENUM;
                case "_MM_DOWNCONV_PS_ENUM": return ParamType._MM_DOWNCONV_PS_ENUM;
                case "_MM_EXP_ADJ_ENUM": return ParamType._MM_EXP_ADJ_ENUM;
                case "_MM_MANTISSA_NORM_ENUM": return ParamType._MM_MANTISSA_NORM_ENUM;
                case "_MM_MANTISSA_SIGN_ENUM": return ParamType._MM_MANTISSA_SIGN_ENUM;
                case "_MM_UPCONV_EPI32_ENUM": return ParamType._MM_UPCONV_EPI32_ENUM;
                case "_MM_UPCONV_EPI64_ENUM": return ParamType._MM_UPCONV_EPI64_ENUM;
                case "_MM_UPCONV_PD_ENUM": return ParamType._MM_UPCONV_PD_ENUM;
                case "_MM_UPCONV_PS_ENUM": return ParamType._MM_UPCONV_PS_ENUM;
                case "CONST _MM_CMPINT_ENUM": return ParamType.CONST_MM_CMPINT_ENUM;
                case "CONST INT": return ParamType.CONST_INT;
                case "CONST VOID *": return ParamType.CONST_VOID_PTR;
                case "CONST VOID **": return ParamType.CONST_VOID_PTR_PTR;
                case "DOUBLE": return ParamType.DOUBLE;
                case "DOUBLE CONST *": return ParamType.DOUBLE_CONST_PTR;
                case "DOUBLE CONST*": return ParamType.DOUBLE_CONST_PTR;
                case "FLOAT": return ParamType.FLOAT;
                case "FLOAT CONST *": return ParamType.FLOAT_CONST_PTR;
                case "FLOAT CONST*": return ParamType.FLOAT_CONST_PTR;
                case "INT": return ParamType.INT;
                case "INT CONST*": return ParamType.INT_CONST_PTR;
                case "SIZE_T": return ParamType.SIZE_T;
                case "UNSIGNED __INT32": return ParamType.UNSIGNED__INT32;
                case "UNSIGNED __INT32*": return ParamType.UNSIGNED__INT32_PTR;
                case "UNSIGNED __INT64": return ParamType.UNSIGNED__INT64;
                case "UNSIGNED __INT64 *": return ParamType.UNSIGNED__INT64_PTR;
                case "UNSIGNED CHAR": return ParamType.UNSIGNED_CHAR;
                case "UNSIGNED INT": return ParamType.UNSIGNED_INT;
                case "UNSIGNED INT *": return ParamType.UNSIGNED_INT_PTR;
                case "UNSIGNED SHORT": return ParamType.UNSIGNED_SHORT;
                case "VOID": return ParamType.VOID;
                case "VOID *": return ParamType.VOID_PTR;
                case "VOID CONST *": return ParamType.VOID_CONST_PTR;
                case "VOID CONST*": return ParamType.VOID_CONST_PTR;
                case "VOID*": return ParamType.VOID_PTR;
                default:
                    Console.WriteLine("parseParamType: unknown param type \"" + str + "\".");
                    return ParamType.NONE;
            }
        }

        public static CpuID parseCpuID(string str)
        {
            switch (str.ToUpper())
            {
                case "ADX": return CpuID.ADX;
                case "AES": return CpuID.AES;
                case "AVX": return CpuID.AVX;
                case "AVX2": return CpuID.AVX2;
                case "AVX512BW": return CpuID.AVX512BW;
                case "AVX512CD": return CpuID.AVX512CD;
                case "AVX512DQ": return CpuID.AVX512DQ;
                case "AVX512ER": return CpuID.AVX512ER;
                case "AVX512F": return CpuID.AVX512F;
                case "AVX512VL": return CpuID.AVX512VL;
                case "BMI1": return CpuID.BMI1;
                case "BMI2": return CpuID.BMI2;
                case "CLFLUSHOPT": return CpuID.CLFLUSHOPT;
                case "FMA": return CpuID.FMA;
                case "FP16C": return CpuID.FP16C;
                case "FXSR": return CpuID.FXSR;
                case "KNCNI": return CpuID.KNCNI;
                case "MMX": return CpuID.MMX;
                case "MPX": return CpuID.MPX;
                case "PCLMULQDQ": return CpuID.PCLMULQDQ;
                case "SSE": return CpuID.SSE;
                case "SSE2": return CpuID.SSE2;
                case "SSE3": return CpuID.SSE3;
                case "SSE4.1": return CpuID.SSE4_1;
                case "SSE4.2": return CpuID.SSE4_2;
                case "SSSE3": return CpuID.SSSE3;
                default: return CpuID.NONE;
            }
        }

        public static string ToString(CpuID cpuIDs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CpuID value in Enum.GetValues(typeof(CpuID)))
            {
                if ((value != CpuID.NONE) && cpuIDs.HasFlag(value))
                {
                    sb.Append(value.ToString());
                    sb.Append(", ");
                }
            }
            if (sb.Length > 0) sb.Length -= 2;
            return sb.ToString();
        }

        public static string ToString(ParamType type)
        {
            switch (type)
            {
                case ParamType.__INT32: return "__int32";
                case ParamType.__INT32_PTR: return "__int32 *";
                case ParamType.__INT64: return "__int64";
                case ParamType.__INT64_CONST_PTR: return "__int64 const *";
                case ParamType.__INT64_PTR: return "__int64 *";
                case ParamType.__M128: return "__m128";
                case ParamType.__M128_CONST_PTR: return "__m128 const *";
                case ParamType.__M128D: return "__m128d";
                case ParamType.__M128D_CONST_PTR: return "__m128d";
                case ParamType.__M128I: return "__m128i";
                case ParamType.__M256: return "__m256";
                case ParamType.__M256D: return "__m256d";
                case ParamType.__M256I: return "__m256i";
                case ParamType.__M512: return "__m512";
                case ParamType.__M512D: return "__m512d";
                case ParamType.__M512I: return "__m512i";
                case ParamType.__M64: return "__m64";
                case ParamType.__MMASK16: return "__mmask16";
                case ParamType.__MMASK16_PTR: return "__mmask16 *";
                case ParamType.__MMASK32: return "__mmask32";
                case ParamType.__MMASK64: return "__mmask64";
                case ParamType.__MMASK8: return "__mmask8";
                case ParamType._MM_BROADCAST32_ENUM: return "_MM_BROADCAST32_ENUM";
                case ParamType._MM_BROADCAST64_ENUM: return "_MM_BROADCAST64_ENUM";
                case ParamType._MM_DOWNCONV_EPI32_ENUM: return "_MM_DOWNCONV_EPI32_ENUM";
                case ParamType._MM_DOWNCONV_EPI64_ENUM: return "_MM_DOWNCONV_EPI64_ENUM";
                case ParamType._MM_DOWNCONV_PD_ENUM: return "_MM_DOWNCONV_PD_ENUM";
                case ParamType._MM_DOWNCONV_PS_ENUM: return "_MM_DOWNCONV_PS_ENUM";
                case ParamType._MM_EXP_ADJ_ENUM: return "_MM_EXP_ADJ_ENUM";
                case ParamType._MM_MANTISSA_NORM_ENUM: return "_MM_MANTISSA_NORM_ENUM";
                case ParamType._MM_MANTISSA_SIGN_ENUM: return "_MM_MANTISSA_SIGN_ENUM";
                case ParamType._MM_UPCONV_EPI32_ENUM: return "_MM_UPCONV_EPI32_ENUM";
                case ParamType._MM_UPCONV_EPI64_ENUM: return "_MM_UPCONV_EPI64_ENUM";
                case ParamType._MM_UPCONV_PD_ENUM: return "_MM_UPCONV_PD_ENUM";
                case ParamType._MM_UPCONV_PS_ENUM: return "_MM_UPCONV_PS_ENUM";
                case ParamType.CONST_MM_CMPINT_ENUM: return "CONST_MM_CMPINT_ENUM";
                case ParamType.CONST_INT: return "const int";
                case ParamType.CONST_VOID_PTR: return "const void *";
                case ParamType.CONST_VOID_PTR_PTR: return "const void **";
                case ParamType.DOUBLE: return "double";
                case ParamType.DOUBLE_CONST_PTR: return "double const *";
                case ParamType.FLOAT: return "float";
                case ParamType.FLOAT_CONST_PTR: return "float";
                case ParamType.INT: return "int";
                case ParamType.INT_CONST_PTR: return "int const *";
                case ParamType.SIZE_T: return "size_t";
                case ParamType.UNSIGNED__INT32: return "unsigned __int32";
                case ParamType.UNSIGNED__INT32_PTR: return "unsigned __int32 *";
                case ParamType.UNSIGNED__INT64: return "unsigned __int64";
                case ParamType.UNSIGNED__INT64_PTR: return "unsigned __int64 *";
                case ParamType.UNSIGNED_CHAR: return "unsigned char";
                case ParamType.UNSIGNED_INT: return "unsigned int";
                case ParamType.UNSIGNED_INT_PTR: return "unsigned int *";
                case ParamType.UNSIGNED_SHORT: return "unsigned short";
                case ParamType.VOID: return "void";
                case ParamType.VOID_PTR: return "void *";
                case ParamType.VOID_CONST_PTR: return "void const *";
                default:
                    return "UNKNOWN";
                    break;
            }
        }

        public static string ToString(ReturnType type)
        {
            switch (type)
            {
                case ReturnType.__INT16: return "__int16";
                case ReturnType.__INT32: return "__int32";
                case ReturnType.__INT64: return "__int64";
                case ReturnType.__INT8: return "__int8";
                case ReturnType.__M128: return "__m128";
                case ReturnType.__M128D: return "__m128d";
                case ReturnType.__M128I: return "__m128d";
                case ReturnType.__M256: return "__m256";
                case ReturnType.__M256D: return "__m256d";
                case ReturnType.__M256I: return "__m256i";
                case ReturnType.__M512: return "__m512";
                case ReturnType.__M512D: return "__m512d";
                case ReturnType.__M512I: return "__m512i";
                case ReturnType.__M64: return "__m64";
                case ReturnType.__MMASK16: return "__mmask16";
                case ReturnType.__MMASK32: return "__mmask32";
                case ReturnType.__MMASK64: return "__mmask64";
                case ReturnType.__MMASK8: return "__mmask8";
                case ReturnType.CONST_VOID_PTR: return "const void *";
                case ReturnType.DOUBLE: return "double";
                case ReturnType.FLOAT: return "float";
                case ReturnType.INT: return "int";
                case ReturnType.UNSIGNED__INT32: return "unsigned __int32";
                case ReturnType.UNSIGNED__INT64: return "unsigned __int64";
                case ReturnType.UNSIGNED_CHAR: return "unsigned char";
                case ReturnType.UNSIGNED_INT: return "unsigned int";
                case ReturnType.UNSIGNED_SHORT: return "unsigned short";
                case ReturnType.VOID: return "void";
                case ReturnType.VOID_PTR: return "void *";
                default:
                    return "UNKNOWN";
                    break;
            }
        }

        public static string getCpuID_Documentation(CpuID cpuID)
        {
            switch (cpuID)
            {
                case CpuID.NONE: return "";
                case CpuID.ADX: return "Multi-Precision Add-Carry Instruction Extension";
                case CpuID.AES: return "Advanced Encryption Standard Extension";
                case CpuID.AVX: return "";
                case CpuID.AVX2: return "";
                case CpuID.AVX512F: return "Instruction set AVX512 Foundation (Knights Landing, Intel Xeon)";
                case CpuID.AVX512CD: return "Instruction set AVX512 Conflict Detection (Knights Landing, Intel Xeon)";
                case CpuID.AVX512ER: return "Instruction set AVX512 Exponential and Reciprocal (Knights Landing)";
                //case CpuID.AVX512PF: return "Instruction set AVX512 Prefetch (Knights Landing)";
                case CpuID.AVX512BW: return "Instruction set AVX512 Byte and Word (Intel Xeon)";
                case CpuID.AVX512DQ: return "Instruction set AVX512 Doubleword and QuadWord (Intel Xeon)";
                case CpuID.AVX512VL: return "Instruction set AVX512 Vector Length Extensions (Intel Xeon)";
                case CpuID.BMI1: return "Bit Manipulation Instruction Set 1";
                case CpuID.BMI2: return "Bit Manipulation Instruction Set 2";
                case CpuID.CLFLUSHOPT: return "";
                case CpuID.FMA: return "Fused Multiply-Add Instructions";
                case CpuID.FP16C: return "Half Precision Floating Point Conversion Instructions";
                case CpuID.FXSR: return "";
                case CpuID.KNCNI: return "";
                case CpuID.MMX: return "";
                case CpuID.MPX: return "Memory Protection Extensions";
                case CpuID.PCLMULQDQ: return "Carry-Less Multiplication Instructions";
                case CpuID.SSE: return "";
                case CpuID.SSE2: return "";
                case CpuID.SSE3: return "";
                case CpuID.SSE4_1: return "";
                case CpuID.SSE4_2: return "";
                case CpuID.SSSE3: return "";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Return the first mnemonic before the provided position in the provided line
        /// </summary>
        public static Tuple<Intrinsic, int> getPreviousKeywordPos(int pos, string line)
        {
            //Debug.WriteLine(string.Format("INFO: getKeyword; pos={0}; line=\"{1}\"", pos, new string(line)));
            if ((pos < 0) || (pos >= line.Length))
            {
                return new Tuple<Intrinsic, int>(Intrinsic.NONE, pos);
            }
            string line2 = line.ToUpper();

            // find the beginning of the keyword
            for (int i1 = pos - 1; i1 >= 2; --i1)
            {
                char c0 = line2[i1 - 0];
                if (c0.Equals('_'))
                {
                    char c1 = line2[i1 - 1];
                    char c2 = line2[i1 - 2];

                    if (c1.Equals('M') && c2.Equals('M'))
                    {
                        for (int i2 = i1 + 2; i2 < line.Length; ++i2)
                        {
                            char c3 = line2[i2];
                            if (Char.IsWhiteSpace(c3) || c3.Equals('('))
                            {
                                int endPos = i2 - 1;
                                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(line2.Substring(i1, endPos));
                                if (intrinsic != Intrinsic.NONE)
                                {
                                    return new Tuple<Intrinsic, int>(intrinsic, i1);
                                }
                            }
                        }
                    }
                }
            }
            return new Tuple<Intrinsic, int>(Intrinsic.NONE, pos);
        }

        public static string sourceCodeLine(string str)
        {
            int startPos = -1;
            for (int i = str.Length - 1; i >= 0; --i)
            {
                if (str[i].Equals(';'))
                {
                    startPos = i + 1;
                    break;
                }
            }
            if ((startPos > 0) && (startPos < str.Length))
            {
                return str.Substring(startPos);
            }
            else
            {
                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: sourceCodeLine: no semicolon found: startPos=" + startPos + "; str.Length=" + str.Length + "; str=\"" + str + "\".");
                return str;
            }
        }

        /// <summary>
        /// return Intrinsic, paramIndex, startPos of Intrinsic:
        /// </summary>
        public static Tuple<Intrinsic, int, ITrackingSpan> getCurrentIntrinsicAndParamIndex(ITextSnapshot snapshot, int triggerPoint)
        {
            string codeStr = IntrinsicTools.getContent(snapshot, triggerPoint);

            Tuple<Intrinsic, int, int, int> tup = IntrinsicTools.getCurrentIntrinsicAndParamIndex_str(codeStr);
            Intrinsic intrinsic = tup.Item1;
            int paramIndex = tup.Item2;
            int startPos = (triggerPoint - codeStr.Length + tup.Item3)+1;

            ITrackingSpan applicableToSpan = snapshot.CreateTrackingSpan(new Span(startPos, tup.Item4+2), SpanTrackingMode.EdgeInclusive, TrackingFidelityMode.Forward);
            IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex: B: codeStr=\"" + codeStr.TrimStart() + "\"; span=\""+ applicableToSpan.GetText(snapshot)+ "\"; returning intrinsic=" + intrinsic + "; paramIndex=" + paramIndex);
            return new Tuple<Intrinsic, int, ITrackingSpan>(intrinsic, paramIndex, applicableToSpan);
        }

        /// <summary>
        /// return Intrinsic, paramIndex, startPos, length
        /// </summary>
        public static Tuple<Intrinsic, int, int, int> getCurrentIntrinsicAndParamIndex_str(string str)
        {
            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex_private: A str=" + str);

            int paramIndex = 0;
            int endPositionIntrinsic = -1;
            bool sillyExeception = false;

            #region Find the end position of the intrinsic

            if (str.EndsWith("()"))
            {
                sillyExeception = true;
                endPositionIntrinsic = str.Length - 2;
            }
            else
            {
                int nClosingParenthesis = 0;
                for (int i = str.Length - 1; i >= 0; --i)
                {
                    char c = str[i];
                    switch (c)
                    {
                        case ')':
                            nClosingParenthesis++;
                            break;
                        case '(':
                            if (nClosingParenthesis == 0)
                            {
                                endPositionIntrinsic = i;
                                //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex_private: A endPositionIntrinsic=" + endPositionIntrinsic);
                            }
                            else
                            {
                                nClosingParenthesis--;
                            }
                            break;
                        case ',':
                            if (nClosingParenthesis == 0)
                            {
                                paramIndex++;
                            }
                            break;
                        case ';':
                            return new Tuple<Intrinsic, int, int, int>(Intrinsic.NONE, -1, -1, -1);
                        default:
                            break;
                    }
                    if (endPositionIntrinsic != -1)
                    {
                        break; // break out of the loop;
                    }
                }
            }
            #endregion

            int beginPositionIntrinsic = -1;
            #region Find the begin position of the intrinsic
            {
                if (endPositionIntrinsic == -1)
                {
                    return new Tuple<Intrinsic, int, int, int>(Intrinsic.NONE, -1, -1, -1);
                }
                else
                {
                    for (int i = endPositionIntrinsic - 1; i >= 0; --i)
                    {
                        char c = str[i];
                        //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex_private: buffer[" + i + "]=" + c);
                        if (Char.IsLetterOrDigit(c) || c.Equals('_'))
                        {
                            // this is a character of the intrinsic
                            if (i == 0)
                            {
                                beginPositionIntrinsic = 0;
                            }
                        }
                        else
                        { // found the beginning of the intrinsic
                            beginPositionIntrinsic = i + 1;
                            //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex_private: A found begin position " + beginPositionIntrinsic);
                            break;
                        }
                    }
                }
            }
            #endregion

            #region Parse the intrinsic string
            if (beginPositionIntrinsic == -1)
            {
                return new Tuple<Intrinsic, int, int, int>(Intrinsic.NONE, -1, -1, -1);
            }
            else
            {
                int length2 = endPositionIntrinsic - beginPositionIntrinsic;
                char[] subBuffer = new char[length2];
                for (int i = 0; i < length2; ++i)
                {
                    subBuffer[i] = str[i + beginPositionIntrinsic];
                }
                string intrinsicStr = new string(subBuffer);
                Intrinsic intrinsic = IntrinsicTools.parseIntrinsic(intrinsicStr);
                //IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicTools: getCurrentIntrinsicAndParamIndex_private: A found str \"" + intrinsicStr + "\"; returning intrinsic=" + intrinsic+ "; paramIndex="+ paramIndex);

                return new Tuple<Intrinsic, int, int, int>(intrinsic, paramIndex, beginPositionIntrinsic, (sillyExeception) ? length2 - 1 : length2);
            }
            #endregion
        }

        public static string getContent(ITextSnapshot snapshot, int triggerPoint)
        {
            //TODO do not use fixed scan buffer size but search for char ';'
            int bufferStartIndex = Math.Max(0, triggerPoint - IntrinsicTools.SCAN_BUFFER_SIZE);
            int length = (triggerPoint - bufferStartIndex) + 1;
            return sourceCodeLine(snapshot.GetText(bufferStartIndex, length));
        }

        public static Intrinsic parseIntrinsic(string str)
        {
            switch (str.ToUpper())
            {
                case "_MM_ABS_EPI16": return Intrinsic._MM_ABS_EPI16;
                case "_MM_MASK_ABS_EPI16": return Intrinsic._MM_MASK_ABS_EPI16;
                case "_MM_MASKZ_ABS_EPI16": return Intrinsic._MM_MASKZ_ABS_EPI16;
                case "_MM256_ABS_EPI16": return Intrinsic._MM256_ABS_EPI16;
                case "_MM256_MASK_ABS_EPI16": return Intrinsic._MM256_MASK_ABS_EPI16;
                case "_MM256_MASKZ_ABS_EPI16": return Intrinsic._MM256_MASKZ_ABS_EPI16;
                case "_MM512_ABS_EPI16": return Intrinsic._MM512_ABS_EPI16;
                case "_MM512_MASK_ABS_EPI16": return Intrinsic._MM512_MASK_ABS_EPI16;
                case "_MM512_MASKZ_ABS_EPI16": return Intrinsic._MM512_MASKZ_ABS_EPI16;
                case "_MM_ABS_EPI32": return Intrinsic._MM_ABS_EPI32;
                case "_MM_MASK_ABS_EPI32": return Intrinsic._MM_MASK_ABS_EPI32;
                case "_MM_MASKZ_ABS_EPI32": return Intrinsic._MM_MASKZ_ABS_EPI32;
                case "_MM256_ABS_EPI32": return Intrinsic._MM256_ABS_EPI32;
                case "_MM256_MASK_ABS_EPI32": return Intrinsic._MM256_MASK_ABS_EPI32;
                case "_MM256_MASKZ_ABS_EPI32": return Intrinsic._MM256_MASKZ_ABS_EPI32;
                case "_MM512_ABS_EPI32": return Intrinsic._MM512_ABS_EPI32;
                case "_MM512_MASK_ABS_EPI32": return Intrinsic._MM512_MASK_ABS_EPI32;
                case "_MM512_MASKZ_ABS_EPI32": return Intrinsic._MM512_MASKZ_ABS_EPI32;
                case "_MM_ABS_EPI64": return Intrinsic._MM_ABS_EPI64;
                case "_MM_MASK_ABS_EPI64": return Intrinsic._MM_MASK_ABS_EPI64;
                case "_MM_MASKZ_ABS_EPI64": return Intrinsic._MM_MASKZ_ABS_EPI64;
                case "_MM256_ABS_EPI64": return Intrinsic._MM256_ABS_EPI64;
                case "_MM256_MASK_ABS_EPI64": return Intrinsic._MM256_MASK_ABS_EPI64;
                case "_MM256_MASKZ_ABS_EPI64": return Intrinsic._MM256_MASKZ_ABS_EPI64;
                case "_MM512_ABS_EPI64": return Intrinsic._MM512_ABS_EPI64;
                case "_MM512_MASK_ABS_EPI64": return Intrinsic._MM512_MASK_ABS_EPI64;
                case "_MM512_MASKZ_ABS_EPI64": return Intrinsic._MM512_MASKZ_ABS_EPI64;
                case "_MM_ABS_EPI8": return Intrinsic._MM_ABS_EPI8;
                case "_MM_MASK_ABS_EPI8": return Intrinsic._MM_MASK_ABS_EPI8;
                case "_MM_MASKZ_ABS_EPI8": return Intrinsic._MM_MASKZ_ABS_EPI8;
                case "_MM256_ABS_EPI8": return Intrinsic._MM256_ABS_EPI8;
                case "_MM256_MASK_ABS_EPI8": return Intrinsic._MM256_MASK_ABS_EPI8;
                case "_MM256_MASKZ_ABS_EPI8": return Intrinsic._MM256_MASKZ_ABS_EPI8;
                case "_MM512_ABS_EPI8": return Intrinsic._MM512_ABS_EPI8;
                case "_MM512_MASK_ABS_EPI8": return Intrinsic._MM512_MASK_ABS_EPI8;
                case "_MM512_MASKZ_ABS_EPI8": return Intrinsic._MM512_MASKZ_ABS_EPI8;
                case "_MM512_ABS_PD": return Intrinsic._MM512_ABS_PD;
                case "_MM512_MASK_ABS_PD": return Intrinsic._MM512_MASK_ABS_PD;
                case "_MM_ABS_PI16": return Intrinsic._MM_ABS_PI16;
                case "_MM_ABS_PI32": return Intrinsic._MM_ABS_PI32;
                case "_MM_ABS_PI8": return Intrinsic._MM_ABS_PI8;
                case "_MM512_ABS_PS": return Intrinsic._MM512_ABS_PS;
                case "_MM512_MASK_ABS_PS": return Intrinsic._MM512_MASK_ABS_PS;
                case "_MM_ACOS_PD": return Intrinsic._MM_ACOS_PD;
                case "_MM256_ACOS_PD": return Intrinsic._MM256_ACOS_PD;
                case "_MM512_ACOS_PD": return Intrinsic._MM512_ACOS_PD;
                case "_MM512_MASK_ACOS_PD": return Intrinsic._MM512_MASK_ACOS_PD;
                case "_MM_ACOS_PS": return Intrinsic._MM_ACOS_PS;
                case "_MM256_ACOS_PS": return Intrinsic._MM256_ACOS_PS;
                case "_MM512_ACOS_PS": return Intrinsic._MM512_ACOS_PS;
                case "_MM512_MASK_ACOS_PS": return Intrinsic._MM512_MASK_ACOS_PS;
                case "_MM_ACOSH_PD": return Intrinsic._MM_ACOSH_PD;
                case "_MM256_ACOSH_PD": return Intrinsic._MM256_ACOSH_PD;
                case "_MM512_ACOSH_PD": return Intrinsic._MM512_ACOSH_PD;
                case "_MM512_MASK_ACOSH_PD": return Intrinsic._MM512_MASK_ACOSH_PD;
                case "_MM_ACOSH_PS": return Intrinsic._MM_ACOSH_PS;
                case "_MM256_ACOSH_PS": return Intrinsic._MM256_ACOSH_PS;
                case "_MM512_ACOSH_PS": return Intrinsic._MM512_ACOSH_PS;
                case "_MM512_MASK_ACOSH_PS": return Intrinsic._MM512_MASK_ACOSH_PS;
                case "_MM512_ADC_EPI32": return Intrinsic._MM512_ADC_EPI32;
                case "_MM512_MASK_ADC_EPI32": return Intrinsic._MM512_MASK_ADC_EPI32;
                case "_MM_ADD_EPI16": return Intrinsic._MM_ADD_EPI16;
                case "_MM_MASK_ADD_EPI16": return Intrinsic._MM_MASK_ADD_EPI16;
                case "_MM_MASKZ_ADD_EPI16": return Intrinsic._MM_MASKZ_ADD_EPI16;
                case "_MM256_ADD_EPI16": return Intrinsic._MM256_ADD_EPI16;
                case "_MM256_MASK_ADD_EPI16": return Intrinsic._MM256_MASK_ADD_EPI16;
                case "_MM256_MASKZ_ADD_EPI16": return Intrinsic._MM256_MASKZ_ADD_EPI16;
                case "_MM512_ADD_EPI16": return Intrinsic._MM512_ADD_EPI16;
                case "_MM512_MASK_ADD_EPI16": return Intrinsic._MM512_MASK_ADD_EPI16;
                case "_MM512_MASKZ_ADD_EPI16": return Intrinsic._MM512_MASKZ_ADD_EPI16;
                case "_MM_ADD_EPI32": return Intrinsic._MM_ADD_EPI32;
                case "_MM_MASK_ADD_EPI32": return Intrinsic._MM_MASK_ADD_EPI32;
                case "_MM_MASKZ_ADD_EPI32": return Intrinsic._MM_MASKZ_ADD_EPI32;
                case "_MM256_ADD_EPI32": return Intrinsic._MM256_ADD_EPI32;
                case "_MM256_MASK_ADD_EPI32": return Intrinsic._MM256_MASK_ADD_EPI32;
                case "_MM256_MASKZ_ADD_EPI32": return Intrinsic._MM256_MASKZ_ADD_EPI32;
                case "_MM512_ADD_EPI32": return Intrinsic._MM512_ADD_EPI32;
                case "_MM512_MASK_ADD_EPI32": return Intrinsic._MM512_MASK_ADD_EPI32;
                case "_MM512_MASKZ_ADD_EPI32": return Intrinsic._MM512_MASKZ_ADD_EPI32;
                case "_MM_ADD_EPI64": return Intrinsic._MM_ADD_EPI64;
                case "_MM_MASK_ADD_EPI64": return Intrinsic._MM_MASK_ADD_EPI64;
                case "_MM_MASKZ_ADD_EPI64": return Intrinsic._MM_MASKZ_ADD_EPI64;
                case "_MM256_ADD_EPI64": return Intrinsic._MM256_ADD_EPI64;
                case "_MM256_MASK_ADD_EPI64": return Intrinsic._MM256_MASK_ADD_EPI64;
                case "_MM256_MASKZ_ADD_EPI64": return Intrinsic._MM256_MASKZ_ADD_EPI64;
                case "_MM512_ADD_EPI64": return Intrinsic._MM512_ADD_EPI64;
                case "_MM512_MASK_ADD_EPI64": return Intrinsic._MM512_MASK_ADD_EPI64;
                case "_MM512_MASKZ_ADD_EPI64": return Intrinsic._MM512_MASKZ_ADD_EPI64;
                case "_MM_ADD_EPI8": return Intrinsic._MM_ADD_EPI8;
                case "_MM_MASK_ADD_EPI8": return Intrinsic._MM_MASK_ADD_EPI8;
                case "_MM_MASKZ_ADD_EPI8": return Intrinsic._MM_MASKZ_ADD_EPI8;
                case "_MM256_ADD_EPI8": return Intrinsic._MM256_ADD_EPI8;
                case "_MM256_MASK_ADD_EPI8": return Intrinsic._MM256_MASK_ADD_EPI8;
                case "_MM256_MASKZ_ADD_EPI8": return Intrinsic._MM256_MASKZ_ADD_EPI8;
                case "_MM512_ADD_EPI8": return Intrinsic._MM512_ADD_EPI8;
                case "_MM512_MASK_ADD_EPI8": return Intrinsic._MM512_MASK_ADD_EPI8;
                case "_MM512_MASKZ_ADD_EPI8": return Intrinsic._MM512_MASKZ_ADD_EPI8;
                case "_MM_ADD_PD": return Intrinsic._MM_ADD_PD;
                case "_MM_MASK_ADD_PD": return Intrinsic._MM_MASK_ADD_PD;
                case "_MM_MASKZ_ADD_PD": return Intrinsic._MM_MASKZ_ADD_PD;
                case "_MM256_ADD_PD": return Intrinsic._MM256_ADD_PD;
                case "_MM256_MASK_ADD_PD": return Intrinsic._MM256_MASK_ADD_PD;
                case "_MM256_MASKZ_ADD_PD": return Intrinsic._MM256_MASKZ_ADD_PD;
                case "_MM512_ADD_PD": return Intrinsic._MM512_ADD_PD;
                case "_MM512_MASK_ADD_PD": return Intrinsic._MM512_MASK_ADD_PD;
                case "_MM512_MASKZ_ADD_PD": return Intrinsic._MM512_MASKZ_ADD_PD;
                case "_MM_ADD_PI16": return Intrinsic._MM_ADD_PI16;
                case "_MM_ADD_PI32": return Intrinsic._MM_ADD_PI32;
                case "_MM_ADD_PI8": return Intrinsic._MM_ADD_PI8;
                case "_MM_ADD_PS": return Intrinsic._MM_ADD_PS;
                case "_MM_MASK_ADD_PS": return Intrinsic._MM_MASK_ADD_PS;
                case "_MM_MASKZ_ADD_PS": return Intrinsic._MM_MASKZ_ADD_PS;
                case "_MM256_ADD_PS": return Intrinsic._MM256_ADD_PS;
                case "_MM256_MASK_ADD_PS": return Intrinsic._MM256_MASK_ADD_PS;
                case "_MM256_MASKZ_ADD_PS": return Intrinsic._MM256_MASKZ_ADD_PS;
                case "_MM512_ADD_PS": return Intrinsic._MM512_ADD_PS;
                case "_MM512_MASK_ADD_PS": return Intrinsic._MM512_MASK_ADD_PS;
                case "_MM512_MASKZ_ADD_PS": return Intrinsic._MM512_MASKZ_ADD_PS;
                case "_MM512_ADD_ROUND_PD": return Intrinsic._MM512_ADD_ROUND_PD;
                case "_MM512_MASK_ADD_ROUND_PD": return Intrinsic._MM512_MASK_ADD_ROUND_PD;
                case "_MM512_MASKZ_ADD_ROUND_PD": return Intrinsic._MM512_MASKZ_ADD_ROUND_PD;
                case "_MM512_ADD_ROUND_PS": return Intrinsic._MM512_ADD_ROUND_PS;
                case "_MM512_MASK_ADD_ROUND_PS": return Intrinsic._MM512_MASK_ADD_ROUND_PS;
                case "_MM512_MASKZ_ADD_ROUND_PS": return Intrinsic._MM512_MASKZ_ADD_ROUND_PS;
                case "_MM_ADD_ROUND_SD": return Intrinsic._MM_ADD_ROUND_SD;
                case "_MM_MASK_ADD_ROUND_SD": return Intrinsic._MM_MASK_ADD_ROUND_SD;
                case "_MM_MASKZ_ADD_ROUND_SD": return Intrinsic._MM_MASKZ_ADD_ROUND_SD;
                case "_MM_ADD_ROUND_SS": return Intrinsic._MM_ADD_ROUND_SS;
                case "_MM_MASK_ADD_ROUND_SS": return Intrinsic._MM_MASK_ADD_ROUND_SS;
                case "_MM_MASKZ_ADD_ROUND_SS": return Intrinsic._MM_MASKZ_ADD_ROUND_SS;
                case "_MM_ADD_SD": return Intrinsic._MM_ADD_SD;
                case "_MM_MASK_ADD_SD": return Intrinsic._MM_MASK_ADD_SD;
                case "_MM_MASKZ_ADD_SD": return Intrinsic._MM_MASKZ_ADD_SD;
                case "_MM_ADD_SI64": return Intrinsic._MM_ADD_SI64;
                case "_MM_ADD_SS": return Intrinsic._MM_ADD_SS;
                case "_MM_MASK_ADD_SS": return Intrinsic._MM_MASK_ADD_SS;
                case "_MM_MASKZ_ADD_SS": return Intrinsic._MM_MASKZ_ADD_SS;
                case "_ADDCARRY_U32": return Intrinsic._ADDCARRY_U32;
                case "_ADDCARRY_U64": return Intrinsic._ADDCARRY_U64;
                case "_ADDCARRYX_U32": return Intrinsic._ADDCARRYX_U32;
                case "_ADDCARRYX_U64": return Intrinsic._ADDCARRYX_U64;
                case "_MM512_ADDN_PD": return Intrinsic._MM512_ADDN_PD;
                case "_MM512_MASK_ADDN_PD": return Intrinsic._MM512_MASK_ADDN_PD;
                case "_MM512_ADDN_PS": return Intrinsic._MM512_ADDN_PS;
                case "_MM512_MASK_ADDN_PS": return Intrinsic._MM512_MASK_ADDN_PS;
                case "_MM512_ADDN_ROUND_PD": return Intrinsic._MM512_ADDN_ROUND_PD;
                case "_MM512_MASK_ADDN_ROUND_PD": return Intrinsic._MM512_MASK_ADDN_ROUND_PD;
                case "_MM512_ADDN_ROUND_PS": return Intrinsic._MM512_ADDN_ROUND_PS;
                case "_MM512_MASK_ADDN_ROUND_PS": return Intrinsic._MM512_MASK_ADDN_ROUND_PS;
                case "_MM_ADDS_EPI16": return Intrinsic._MM_ADDS_EPI16;
                case "_MM_MASK_ADDS_EPI16": return Intrinsic._MM_MASK_ADDS_EPI16;
                case "_MM_MASKZ_ADDS_EPI16": return Intrinsic._MM_MASKZ_ADDS_EPI16;
                case "_MM256_ADDS_EPI16": return Intrinsic._MM256_ADDS_EPI16;
                case "_MM256_MASK_ADDS_EPI16": return Intrinsic._MM256_MASK_ADDS_EPI16;
                case "_MM256_MASKZ_ADDS_EPI16": return Intrinsic._MM256_MASKZ_ADDS_EPI16;
                case "_MM512_ADDS_EPI16": return Intrinsic._MM512_ADDS_EPI16;
                case "_MM512_MASK_ADDS_EPI16": return Intrinsic._MM512_MASK_ADDS_EPI16;
                case "_MM512_MASKZ_ADDS_EPI16": return Intrinsic._MM512_MASKZ_ADDS_EPI16;
                case "_MM_ADDS_EPI8": return Intrinsic._MM_ADDS_EPI8;
                case "_MM_MASK_ADDS_EPI8": return Intrinsic._MM_MASK_ADDS_EPI8;
                case "_MM_MASKZ_ADDS_EPI8": return Intrinsic._MM_MASKZ_ADDS_EPI8;
                case "_MM256_ADDS_EPI8": return Intrinsic._MM256_ADDS_EPI8;
                case "_MM256_MASK_ADDS_EPI8": return Intrinsic._MM256_MASK_ADDS_EPI8;
                case "_MM256_MASKZ_ADDS_EPI8": return Intrinsic._MM256_MASKZ_ADDS_EPI8;
                case "_MM512_ADDS_EPI8": return Intrinsic._MM512_ADDS_EPI8;
                case "_MM512_MASK_ADDS_EPI8": return Intrinsic._MM512_MASK_ADDS_EPI8;
                case "_MM512_MASKZ_ADDS_EPI8": return Intrinsic._MM512_MASKZ_ADDS_EPI8;
                case "_MM_ADDS_EPU16": return Intrinsic._MM_ADDS_EPU16;
                case "_MM_MASK_ADDS_EPU16": return Intrinsic._MM_MASK_ADDS_EPU16;
                case "_MM_MASKZ_ADDS_EPU16": return Intrinsic._MM_MASKZ_ADDS_EPU16;
                case "_MM256_ADDS_EPU16": return Intrinsic._MM256_ADDS_EPU16;
                case "_MM256_MASK_ADDS_EPU16": return Intrinsic._MM256_MASK_ADDS_EPU16;
                case "_MM256_MASKZ_ADDS_EPU16": return Intrinsic._MM256_MASKZ_ADDS_EPU16;
                case "_MM512_ADDS_EPU16": return Intrinsic._MM512_ADDS_EPU16;
                case "_MM512_MASK_ADDS_EPU16": return Intrinsic._MM512_MASK_ADDS_EPU16;
                case "_MM512_MASKZ_ADDS_EPU16": return Intrinsic._MM512_MASKZ_ADDS_EPU16;
                case "_MM_ADDS_EPU8": return Intrinsic._MM_ADDS_EPU8;
                case "_MM_MASK_ADDS_EPU8": return Intrinsic._MM_MASK_ADDS_EPU8;
                case "_MM_MASKZ_ADDS_EPU8": return Intrinsic._MM_MASKZ_ADDS_EPU8;
                case "_MM256_ADDS_EPU8": return Intrinsic._MM256_ADDS_EPU8;
                case "_MM256_MASK_ADDS_EPU8": return Intrinsic._MM256_MASK_ADDS_EPU8;
                case "_MM256_MASKZ_ADDS_EPU8": return Intrinsic._MM256_MASKZ_ADDS_EPU8;
                case "_MM512_ADDS_EPU8": return Intrinsic._MM512_ADDS_EPU8;
                case "_MM512_MASK_ADDS_EPU8": return Intrinsic._MM512_MASK_ADDS_EPU8;
                case "_MM512_MASKZ_ADDS_EPU8": return Intrinsic._MM512_MASKZ_ADDS_EPU8;
                case "_MM_ADDS_PI16": return Intrinsic._MM_ADDS_PI16;
                case "_MM_ADDS_PI8": return Intrinsic._MM_ADDS_PI8;
                case "_MM_ADDS_PU16": return Intrinsic._MM_ADDS_PU16;
                case "_MM_ADDS_PU8": return Intrinsic._MM_ADDS_PU8;
                case "_MM512_ADDSETC_EPI32": return Intrinsic._MM512_ADDSETC_EPI32;
                case "_MM512_MASK_ADDSETC_EPI32": return Intrinsic._MM512_MASK_ADDSETC_EPI32;
                case "_MM512_ADDSETS_EPI32": return Intrinsic._MM512_ADDSETS_EPI32;
                case "_MM512_MASK_ADDSETS_EPI32": return Intrinsic._MM512_MASK_ADDSETS_EPI32;
                case "_MM512_ADDSETS_PS": return Intrinsic._MM512_ADDSETS_PS;
                case "_MM512_MASK_ADDSETS_PS": return Intrinsic._MM512_MASK_ADDSETS_PS;
                case "_MM512_ADDSETS_ROUND_PS": return Intrinsic._MM512_ADDSETS_ROUND_PS;
                case "_MM512_MASK_ADDSETS_ROUND_PS": return Intrinsic._MM512_MASK_ADDSETS_ROUND_PS;
                case "_MM_ADDSUB_PD": return Intrinsic._MM_ADDSUB_PD;
                case "_MM256_ADDSUB_PD": return Intrinsic._MM256_ADDSUB_PD;
                case "_MM_ADDSUB_PS": return Intrinsic._MM_ADDSUB_PS;
                case "_MM256_ADDSUB_PS": return Intrinsic._MM256_ADDSUB_PS;
                case "_MM_AESDEC_SI128": return Intrinsic._MM_AESDEC_SI128;
                case "_MM_AESDECLAST_SI128": return Intrinsic._MM_AESDECLAST_SI128;
                case "_MM_AESENC_SI128": return Intrinsic._MM_AESENC_SI128;
                case "_MM_AESENCLAST_SI128": return Intrinsic._MM_AESENCLAST_SI128;
                case "_MM_AESIMC_SI128": return Intrinsic._MM_AESIMC_SI128;
                case "_MM_AESKEYGENASSIST_SI128": return Intrinsic._MM_AESKEYGENASSIST_SI128;
                case "_MM_ALIGNR_EPI32": return Intrinsic._MM_ALIGNR_EPI32;
                case "_MM_MASK_ALIGNR_EPI32": return Intrinsic._MM_MASK_ALIGNR_EPI32;
                case "_MM_MASKZ_ALIGNR_EPI32": return Intrinsic._MM_MASKZ_ALIGNR_EPI32;
                case "_MM256_ALIGNR_EPI32": return Intrinsic._MM256_ALIGNR_EPI32;
                case "_MM256_MASK_ALIGNR_EPI32": return Intrinsic._MM256_MASK_ALIGNR_EPI32;
                case "_MM256_MASKZ_ALIGNR_EPI32": return Intrinsic._MM256_MASKZ_ALIGNR_EPI32;
                case "_MM512_ALIGNR_EPI32": return Intrinsic._MM512_ALIGNR_EPI32;
                case "_MM512_MASK_ALIGNR_EPI32": return Intrinsic._MM512_MASK_ALIGNR_EPI32;
                case "_MM512_MASKZ_ALIGNR_EPI32": return Intrinsic._MM512_MASKZ_ALIGNR_EPI32;
                case "_MM_ALIGNR_EPI64": return Intrinsic._MM_ALIGNR_EPI64;
                case "_MM_MASK_ALIGNR_EPI64": return Intrinsic._MM_MASK_ALIGNR_EPI64;
                case "_MM_MASKZ_ALIGNR_EPI64": return Intrinsic._MM_MASKZ_ALIGNR_EPI64;
                case "_MM256_ALIGNR_EPI64": return Intrinsic._MM256_ALIGNR_EPI64;
                case "_MM256_MASK_ALIGNR_EPI64": return Intrinsic._MM256_MASK_ALIGNR_EPI64;
                case "_MM256_MASKZ_ALIGNR_EPI64": return Intrinsic._MM256_MASKZ_ALIGNR_EPI64;
                case "_MM512_ALIGNR_EPI64": return Intrinsic._MM512_ALIGNR_EPI64;
                case "_MM512_MASK_ALIGNR_EPI64": return Intrinsic._MM512_MASK_ALIGNR_EPI64;
                case "_MM512_MASKZ_ALIGNR_EPI64": return Intrinsic._MM512_MASKZ_ALIGNR_EPI64;
                case "_MM_ALIGNR_EPI8": return Intrinsic._MM_ALIGNR_EPI8;
                case "_MM_MASK_ALIGNR_EPI8": return Intrinsic._MM_MASK_ALIGNR_EPI8;
                case "_MM_MASKZ_ALIGNR_EPI8": return Intrinsic._MM_MASKZ_ALIGNR_EPI8;
                case "_MM256_ALIGNR_EPI8": return Intrinsic._MM256_ALIGNR_EPI8;
                case "_MM256_MASK_ALIGNR_EPI8": return Intrinsic._MM256_MASK_ALIGNR_EPI8;
                case "_MM256_MASKZ_ALIGNR_EPI8": return Intrinsic._MM256_MASKZ_ALIGNR_EPI8;
                case "_MM512_ALIGNR_EPI8": return Intrinsic._MM512_ALIGNR_EPI8;
                case "_MM512_MASK_ALIGNR_EPI8": return Intrinsic._MM512_MASK_ALIGNR_EPI8;
                case "_MM512_MASKZ_ALIGNR_EPI8": return Intrinsic._MM512_MASKZ_ALIGNR_EPI8;
                case "_MM_ALIGNR_PI8": return Intrinsic._MM_ALIGNR_PI8;
                case "_ALLOW_CPU_FEATURES": return Intrinsic._ALLOW_CPU_FEATURES;
                case "_MM_MASK_AND_EPI32": return Intrinsic._MM_MASK_AND_EPI32;
                case "_MM_MASKZ_AND_EPI32": return Intrinsic._MM_MASKZ_AND_EPI32;
                case "_MM256_MASK_AND_EPI32": return Intrinsic._MM256_MASK_AND_EPI32;
                case "_MM256_MASKZ_AND_EPI32": return Intrinsic._MM256_MASKZ_AND_EPI32;
                case "_MM512_AND_EPI32": return Intrinsic._MM512_AND_EPI32;
                case "_MM512_MASK_AND_EPI32": return Intrinsic._MM512_MASK_AND_EPI32;
                case "_MM512_MASKZ_AND_EPI32": return Intrinsic._MM512_MASKZ_AND_EPI32;
                case "_MM_MASK_AND_EPI64": return Intrinsic._MM_MASK_AND_EPI64;
                case "_MM_MASKZ_AND_EPI64": return Intrinsic._MM_MASKZ_AND_EPI64;
                case "_MM256_MASK_AND_EPI64": return Intrinsic._MM256_MASK_AND_EPI64;
                case "_MM256_MASKZ_AND_EPI64": return Intrinsic._MM256_MASKZ_AND_EPI64;
                case "_MM512_AND_EPI64": return Intrinsic._MM512_AND_EPI64;
                case "_MM512_MASK_AND_EPI64": return Intrinsic._MM512_MASK_AND_EPI64;
                case "_MM512_MASKZ_AND_EPI64": return Intrinsic._MM512_MASKZ_AND_EPI64;
                case "_MM_AND_PD": return Intrinsic._MM_AND_PD;
                case "_MM_MASK_AND_PD": return Intrinsic._MM_MASK_AND_PD;
                case "_MM_MASKZ_AND_PD": return Intrinsic._MM_MASKZ_AND_PD;
                case "_MM256_AND_PD": return Intrinsic._MM256_AND_PD;
                case "_MM256_MASK_AND_PD": return Intrinsic._MM256_MASK_AND_PD;
                case "_MM256_MASKZ_AND_PD": return Intrinsic._MM256_MASKZ_AND_PD;
                case "_MM512_AND_PD": return Intrinsic._MM512_AND_PD;
                case "_MM512_MASK_AND_PD": return Intrinsic._MM512_MASK_AND_PD;
                case "_MM512_MASKZ_AND_PD": return Intrinsic._MM512_MASKZ_AND_PD;
                case "_MM_AND_PS": return Intrinsic._MM_AND_PS;
                case "_MM_MASK_AND_PS": return Intrinsic._MM_MASK_AND_PS;
                case "_MM_MASKZ_AND_PS": return Intrinsic._MM_MASKZ_AND_PS;
                case "_MM256_AND_PS": return Intrinsic._MM256_AND_PS;
                case "_MM256_MASK_AND_PS": return Intrinsic._MM256_MASK_AND_PS;
                case "_MM256_MASKZ_AND_PS": return Intrinsic._MM256_MASKZ_AND_PS;
                case "_MM512_AND_PS": return Intrinsic._MM512_AND_PS;
                case "_MM512_MASK_AND_PS": return Intrinsic._MM512_MASK_AND_PS;
                case "_MM512_MASKZ_AND_PS": return Intrinsic._MM512_MASKZ_AND_PS;
                case "_MM_AND_SI128": return Intrinsic._MM_AND_SI128;
                case "_MM256_AND_SI256": return Intrinsic._MM256_AND_SI256;
                case "_MM512_AND_SI512": return Intrinsic._MM512_AND_SI512;
                case "_MM_AND_SI64": return Intrinsic._MM_AND_SI64;
                case "_MM_MASK_ANDNOT_EPI32": return Intrinsic._MM_MASK_ANDNOT_EPI32;
                case "_MM_MASKZ_ANDNOT_EPI32": return Intrinsic._MM_MASKZ_ANDNOT_EPI32;
                case "_MM256_MASK_ANDNOT_EPI32": return Intrinsic._MM256_MASK_ANDNOT_EPI32;
                case "_MM256_MASKZ_ANDNOT_EPI32": return Intrinsic._MM256_MASKZ_ANDNOT_EPI32;
                case "_MM512_ANDNOT_EPI32": return Intrinsic._MM512_ANDNOT_EPI32;
                case "_MM512_MASK_ANDNOT_EPI32": return Intrinsic._MM512_MASK_ANDNOT_EPI32;
                case "_MM512_MASKZ_ANDNOT_EPI32": return Intrinsic._MM512_MASKZ_ANDNOT_EPI32;
                case "_MM_MASK_ANDNOT_EPI64": return Intrinsic._MM_MASK_ANDNOT_EPI64;
                case "_MM_MASKZ_ANDNOT_EPI64": return Intrinsic._MM_MASKZ_ANDNOT_EPI64;
                case "_MM256_MASK_ANDNOT_EPI64": return Intrinsic._MM256_MASK_ANDNOT_EPI64;
                case "_MM256_MASKZ_ANDNOT_EPI64": return Intrinsic._MM256_MASKZ_ANDNOT_EPI64;
                case "_MM512_ANDNOT_EPI64": return Intrinsic._MM512_ANDNOT_EPI64;
                case "_MM512_MASK_ANDNOT_EPI64": return Intrinsic._MM512_MASK_ANDNOT_EPI64;
                case "_MM512_MASKZ_ANDNOT_EPI64": return Intrinsic._MM512_MASKZ_ANDNOT_EPI64;
                case "_MM_ANDNOT_PD": return Intrinsic._MM_ANDNOT_PD;
                case "_MM_MASK_ANDNOT_PD": return Intrinsic._MM_MASK_ANDNOT_PD;
                case "_MM_MASKZ_ANDNOT_PD": return Intrinsic._MM_MASKZ_ANDNOT_PD;
                case "_MM256_ANDNOT_PD": return Intrinsic._MM256_ANDNOT_PD;
                case "_MM256_MASK_ANDNOT_PD": return Intrinsic._MM256_MASK_ANDNOT_PD;
                case "_MM256_MASKZ_ANDNOT_PD": return Intrinsic._MM256_MASKZ_ANDNOT_PD;
                case "_MM512_ANDNOT_PD": return Intrinsic._MM512_ANDNOT_PD;
                case "_MM512_MASK_ANDNOT_PD": return Intrinsic._MM512_MASK_ANDNOT_PD;
                case "_MM512_MASKZ_ANDNOT_PD": return Intrinsic._MM512_MASKZ_ANDNOT_PD;
                case "_MM_ANDNOT_PS": return Intrinsic._MM_ANDNOT_PS;
                case "_MM_MASK_ANDNOT_PS": return Intrinsic._MM_MASK_ANDNOT_PS;
                case "_MM_MASKZ_ANDNOT_PS": return Intrinsic._MM_MASKZ_ANDNOT_PS;
                case "_MM256_ANDNOT_PS": return Intrinsic._MM256_ANDNOT_PS;
                case "_MM256_MASK_ANDNOT_PS": return Intrinsic._MM256_MASK_ANDNOT_PS;
                case "_MM256_MASKZ_ANDNOT_PS": return Intrinsic._MM256_MASKZ_ANDNOT_PS;
                case "_MM512_ANDNOT_PS": return Intrinsic._MM512_ANDNOT_PS;
                case "_MM512_MASK_ANDNOT_PS": return Intrinsic._MM512_MASK_ANDNOT_PS;
                case "_MM512_MASKZ_ANDNOT_PS": return Intrinsic._MM512_MASKZ_ANDNOT_PS;
                case "_MM_ANDNOT_SI128": return Intrinsic._MM_ANDNOT_SI128;
                case "_MM256_ANDNOT_SI256": return Intrinsic._MM256_ANDNOT_SI256;
                case "_MM512_ANDNOT_SI512": return Intrinsic._MM512_ANDNOT_SI512;
                case "_MM_ANDNOT_SI64": return Intrinsic._MM_ANDNOT_SI64;
                case "_MM_ASIN_PD": return Intrinsic._MM_ASIN_PD;
                case "_MM256_ASIN_PD": return Intrinsic._MM256_ASIN_PD;
                case "_MM512_ASIN_PD": return Intrinsic._MM512_ASIN_PD;
                case "_MM512_MASK_ASIN_PD": return Intrinsic._MM512_MASK_ASIN_PD;
                case "_MM_ASIN_PS": return Intrinsic._MM_ASIN_PS;
                case "_MM256_ASIN_PS": return Intrinsic._MM256_ASIN_PS;
                case "_MM512_ASIN_PS": return Intrinsic._MM512_ASIN_PS;
                case "_MM512_MASK_ASIN_PS": return Intrinsic._MM512_MASK_ASIN_PS;
                case "_MM_ASINH_PD": return Intrinsic._MM_ASINH_PD;
                case "_MM256_ASINH_PD": return Intrinsic._MM256_ASINH_PD;
                case "_MM512_ASINH_PD": return Intrinsic._MM512_ASINH_PD;
                case "_MM512_MASK_ASINH_PD": return Intrinsic._MM512_MASK_ASINH_PD;
                case "_MM_ASINH_PS": return Intrinsic._MM_ASINH_PS;
                case "_MM256_ASINH_PS": return Intrinsic._MM256_ASINH_PS;
                case "_MM512_ASINH_PS": return Intrinsic._MM512_ASINH_PS;
                case "_MM512_MASK_ASINH_PS": return Intrinsic._MM512_MASK_ASINH_PS;
                case "_MM_ATAN_PD": return Intrinsic._MM_ATAN_PD;
                case "_MM256_ATAN_PD": return Intrinsic._MM256_ATAN_PD;
                case "_MM512_ATAN_PD": return Intrinsic._MM512_ATAN_PD;
                case "_MM512_MASK_ATAN_PD": return Intrinsic._MM512_MASK_ATAN_PD;
                case "_MM_ATAN_PS": return Intrinsic._MM_ATAN_PS;
                case "_MM256_ATAN_PS": return Intrinsic._MM256_ATAN_PS;
                case "_MM512_ATAN_PS": return Intrinsic._MM512_ATAN_PS;
                case "_MM512_MASK_ATAN_PS": return Intrinsic._MM512_MASK_ATAN_PS;
                case "_MM_ATAN2_PD": return Intrinsic._MM_ATAN2_PD;
                case "_MM256_ATAN2_PD": return Intrinsic._MM256_ATAN2_PD;
                case "_MM512_ATAN2_PD": return Intrinsic._MM512_ATAN2_PD;
                case "_MM512_MASK_ATAN2_PD": return Intrinsic._MM512_MASK_ATAN2_PD;
                case "_MM_ATAN2_PS": return Intrinsic._MM_ATAN2_PS;
                case "_MM256_ATAN2_PS": return Intrinsic._MM256_ATAN2_PS;
                case "_MM512_ATAN2_PS": return Intrinsic._MM512_ATAN2_PS;
                case "_MM512_MASK_ATAN2_PS": return Intrinsic._MM512_MASK_ATAN2_PS;
                case "_MM_ATANH_PD": return Intrinsic._MM_ATANH_PD;
                case "_MM256_ATANH_PD": return Intrinsic._MM256_ATANH_PD;
                case "_MM512_ATANH_PD": return Intrinsic._MM512_ATANH_PD;
                case "_MM512_MASK_ATANH_PD": return Intrinsic._MM512_MASK_ATANH_PD;
                case "_MM_ATANH_PS": return Intrinsic._MM_ATANH_PS;
                case "_MM256_ATANH_PS": return Intrinsic._MM256_ATANH_PS;
                case "_MM512_ATANH_PS": return Intrinsic._MM512_ATANH_PS;
                case "_MM512_MASK_ATANH_PS": return Intrinsic._MM512_MASK_ATANH_PS;
                case "_MM_AVG_EPU16": return Intrinsic._MM_AVG_EPU16;
                case "_MM_MASK_AVG_EPU16": return Intrinsic._MM_MASK_AVG_EPU16;
                case "_MM_MASKZ_AVG_EPU16": return Intrinsic._MM_MASKZ_AVG_EPU16;
                case "_MM256_AVG_EPU16": return Intrinsic._MM256_AVG_EPU16;
                case "_MM256_MASK_AVG_EPU16": return Intrinsic._MM256_MASK_AVG_EPU16;
                case "_MM256_MASKZ_AVG_EPU16": return Intrinsic._MM256_MASKZ_AVG_EPU16;
                case "_MM512_AVG_EPU16": return Intrinsic._MM512_AVG_EPU16;
                case "_MM512_MASK_AVG_EPU16": return Intrinsic._MM512_MASK_AVG_EPU16;
                case "_MM512_MASKZ_AVG_EPU16": return Intrinsic._MM512_MASKZ_AVG_EPU16;
                case "_MM_AVG_EPU8": return Intrinsic._MM_AVG_EPU8;
                case "_MM_MASK_AVG_EPU8": return Intrinsic._MM_MASK_AVG_EPU8;
                case "_MM_MASKZ_AVG_EPU8": return Intrinsic._MM_MASKZ_AVG_EPU8;
                case "_MM256_AVG_EPU8": return Intrinsic._MM256_AVG_EPU8;
                case "_MM256_MASK_AVG_EPU8": return Intrinsic._MM256_MASK_AVG_EPU8;
                case "_MM256_MASKZ_AVG_EPU8": return Intrinsic._MM256_MASKZ_AVG_EPU8;
                case "_MM512_AVG_EPU8": return Intrinsic._MM512_AVG_EPU8;
                case "_MM512_MASK_AVG_EPU8": return Intrinsic._MM512_MASK_AVG_EPU8;
                case "_MM512_MASKZ_AVG_EPU8": return Intrinsic._MM512_MASKZ_AVG_EPU8;
                case "_MM_AVG_PU16": return Intrinsic._MM_AVG_PU16;
                case "_MM_AVG_PU8": return Intrinsic._MM_AVG_PU8;
                case "_BEXTR_U32": return Intrinsic._BEXTR_U32;
                case "_BEXTR_U64": return Intrinsic._BEXTR_U64;
                case "_BIT_SCAN_FORWARD": return Intrinsic._BIT_SCAN_FORWARD;
                case "_BIT_SCAN_REVERSE": return Intrinsic._BIT_SCAN_REVERSE;
                case "_BITSCANFORWARD": return Intrinsic._BITSCANFORWARD;
                case "_BITSCANFORWARD64": return Intrinsic._BITSCANFORWARD64;
                case "_BITSCANREVERSE": return Intrinsic._BITSCANREVERSE;
                case "_BITSCANREVERSE64": return Intrinsic._BITSCANREVERSE64;
                case "_BITTEST": return Intrinsic._BITTEST;
                case "_BITTEST64": return Intrinsic._BITTEST64;
                case "_BITTESTANDCOMPLEMENT": return Intrinsic._BITTESTANDCOMPLEMENT;
                case "_BITTESTANDCOMPLEMENT64": return Intrinsic._BITTESTANDCOMPLEMENT64;
                case "_BITTESTANDRESET": return Intrinsic._BITTESTANDRESET;
                case "_BITTESTANDRESET64": return Intrinsic._BITTESTANDRESET64;
                case "_BITTESTANDSET": return Intrinsic._BITTESTANDSET;
                case "_BITTESTANDSET64": return Intrinsic._BITTESTANDSET64;
                case "_MM_BLEND_EPI16": return Intrinsic._MM_BLEND_EPI16;
                case "_MM_MASK_BLEND_EPI16": return Intrinsic._MM_MASK_BLEND_EPI16;
                case "_MM256_BLEND_EPI16": return Intrinsic._MM256_BLEND_EPI16;
                case "_MM256_MASK_BLEND_EPI16": return Intrinsic._MM256_MASK_BLEND_EPI16;
                case "_MM512_MASK_BLEND_EPI16": return Intrinsic._MM512_MASK_BLEND_EPI16;
                case "_MM_BLEND_EPI32": return Intrinsic._MM_BLEND_EPI32;
                case "_MM_MASK_BLEND_EPI32": return Intrinsic._MM_MASK_BLEND_EPI32;
                case "_MM256_BLEND_EPI32": return Intrinsic._MM256_BLEND_EPI32;
                case "_MM256_MASK_BLEND_EPI32": return Intrinsic._MM256_MASK_BLEND_EPI32;
                case "_MM512_MASK_BLEND_EPI32": return Intrinsic._MM512_MASK_BLEND_EPI32;
                case "_MM_MASK_BLEND_EPI64": return Intrinsic._MM_MASK_BLEND_EPI64;
                case "_MM256_MASK_BLEND_EPI64": return Intrinsic._MM256_MASK_BLEND_EPI64;
                case "_MM512_MASK_BLEND_EPI64": return Intrinsic._MM512_MASK_BLEND_EPI64;
                case "_MM_MASK_BLEND_EPI8": return Intrinsic._MM_MASK_BLEND_EPI8;
                case "_MM256_MASK_BLEND_EPI8": return Intrinsic._MM256_MASK_BLEND_EPI8;
                case "_MM512_MASK_BLEND_EPI8": return Intrinsic._MM512_MASK_BLEND_EPI8;
                case "_MM_BLEND_PD": return Intrinsic._MM_BLEND_PD;
                case "_MM_MASK_BLEND_PD": return Intrinsic._MM_MASK_BLEND_PD;
                case "_MM256_BLEND_PD": return Intrinsic._MM256_BLEND_PD;
                case "_MM256_MASK_BLEND_PD": return Intrinsic._MM256_MASK_BLEND_PD;
                case "_MM512_MASK_BLEND_PD": return Intrinsic._MM512_MASK_BLEND_PD;
                case "_MM_BLEND_PS": return Intrinsic._MM_BLEND_PS;
                case "_MM_MASK_BLEND_PS": return Intrinsic._MM_MASK_BLEND_PS;
                case "_MM256_BLEND_PS": return Intrinsic._MM256_BLEND_PS;
                case "_MM256_MASK_BLEND_PS": return Intrinsic._MM256_MASK_BLEND_PS;
                case "_MM512_MASK_BLEND_PS": return Intrinsic._MM512_MASK_BLEND_PS;
                case "_MM_BLENDV_EPI8": return Intrinsic._MM_BLENDV_EPI8;
                case "_MM256_BLENDV_EPI8": return Intrinsic._MM256_BLENDV_EPI8;
                case "_MM_BLENDV_PD": return Intrinsic._MM_BLENDV_PD;
                case "_MM256_BLENDV_PD": return Intrinsic._MM256_BLENDV_PD;
                case "_MM_BLENDV_PS": return Intrinsic._MM_BLENDV_PS;
                case "_MM256_BLENDV_PS": return Intrinsic._MM256_BLENDV_PS;
                case "_BLSI_U32": return Intrinsic._BLSI_U32;
                case "_BLSI_U64": return Intrinsic._BLSI_U64;
                case "_BLSMSK_U32": return Intrinsic._BLSMSK_U32;
                case "_BLSMSK_U64": return Intrinsic._BLSMSK_U64;
                case "_BLSR_U32": return Intrinsic._BLSR_U32;
                case "_BLSR_U64": return Intrinsic._BLSR_U64;
                case "_BND_CHK_PTR_BOUNDS": return Intrinsic._BND_CHK_PTR_BOUNDS;
                case "_BND_CHK_PTR_LBOUNDS": return Intrinsic._BND_CHK_PTR_LBOUNDS;
                case "_BND_CHK_PTR_UBOUNDS": return Intrinsic._BND_CHK_PTR_UBOUNDS;
                case "_BND_COPY_PTR_BOUNDS": return Intrinsic._BND_COPY_PTR_BOUNDS;
                case "_BND_GET_PTR_LBOUND": return Intrinsic._BND_GET_PTR_LBOUND;
                case "_BND_GET_PTR_UBOUND": return Intrinsic._BND_GET_PTR_UBOUND;
                case "_BND_INIT_PTR_BOUNDS": return Intrinsic._BND_INIT_PTR_BOUNDS;
                case "_BND_NARROW_PTR_BOUNDS": return Intrinsic._BND_NARROW_PTR_BOUNDS;
                case "_BND_SET_PTR_BOUNDS": return Intrinsic._BND_SET_PTR_BOUNDS;
                case "_BND_STORE_PTR_BOUNDS": return Intrinsic._BND_STORE_PTR_BOUNDS;
                case "_MM256_BROADCAST_F32X2": return Intrinsic._MM256_BROADCAST_F32X2;
                case "_MM256_MASK_BROADCAST_F32X2": return Intrinsic._MM256_MASK_BROADCAST_F32X2;
                case "_MM256_MASKZ_BROADCAST_F32X2": return Intrinsic._MM256_MASKZ_BROADCAST_F32X2;
                case "_MM512_BROADCAST_F32X2": return Intrinsic._MM512_BROADCAST_F32X2;
                case "_MM512_MASK_BROADCAST_F32X2": return Intrinsic._MM512_MASK_BROADCAST_F32X2;
                case "_MM512_MASKZ_BROADCAST_F32X2": return Intrinsic._MM512_MASKZ_BROADCAST_F32X2;
                case "_MM256_BROADCAST_F32X4": return Intrinsic._MM256_BROADCAST_F32X4;
                case "_MM256_MASK_BROADCAST_F32X4": return Intrinsic._MM256_MASK_BROADCAST_F32X4;
                case "_MM256_MASKZ_BROADCAST_F32X4": return Intrinsic._MM256_MASKZ_BROADCAST_F32X4;
                case "_MM512_BROADCAST_F32X4": return Intrinsic._MM512_BROADCAST_F32X4;
                case "_MM512_MASK_BROADCAST_F32X4": return Intrinsic._MM512_MASK_BROADCAST_F32X4;
                case "_MM512_MASKZ_BROADCAST_F32X4": return Intrinsic._MM512_MASKZ_BROADCAST_F32X4;
                case "_MM512_BROADCAST_F32X8": return Intrinsic._MM512_BROADCAST_F32X8;
                case "_MM512_MASK_BROADCAST_F32X8": return Intrinsic._MM512_MASK_BROADCAST_F32X8;
                case "_MM512_MASKZ_BROADCAST_F32X8": return Intrinsic._MM512_MASKZ_BROADCAST_F32X8;
                case "_MM256_BROADCAST_F64X2": return Intrinsic._MM256_BROADCAST_F64X2;
                case "_MM256_MASK_BROADCAST_F64X2": return Intrinsic._MM256_MASK_BROADCAST_F64X2;
                case "_MM256_MASKZ_BROADCAST_F64X2": return Intrinsic._MM256_MASKZ_BROADCAST_F64X2;
                case "_MM512_BROADCAST_F64X2": return Intrinsic._MM512_BROADCAST_F64X2;
                case "_MM512_MASK_BROADCAST_F64X2": return Intrinsic._MM512_MASK_BROADCAST_F64X2;
                case "_MM512_MASKZ_BROADCAST_F64X2": return Intrinsic._MM512_MASKZ_BROADCAST_F64X2;
                case "_MM512_BROADCAST_F64X4": return Intrinsic._MM512_BROADCAST_F64X4;
                case "_MM512_MASK_BROADCAST_F64X4": return Intrinsic._MM512_MASK_BROADCAST_F64X4;
                case "_MM512_MASKZ_BROADCAST_F64X4": return Intrinsic._MM512_MASKZ_BROADCAST_F64X4;
                case "_MM_BROADCAST_I32X2": return Intrinsic._MM_BROADCAST_I32X2;
                case "_MM_MASK_BROADCAST_I32X2": return Intrinsic._MM_MASK_BROADCAST_I32X2;
                case "_MM_MASKZ_BROADCAST_I32X2": return Intrinsic._MM_MASKZ_BROADCAST_I32X2;
                case "_MM256_BROADCAST_I32X2": return Intrinsic._MM256_BROADCAST_I32X2;
                case "_MM256_MASK_BROADCAST_I32X2": return Intrinsic._MM256_MASK_BROADCAST_I32X2;
                case "_MM256_MASKZ_BROADCAST_I32X2": return Intrinsic._MM256_MASKZ_BROADCAST_I32X2;
                case "_MM512_BROADCAST_I32X2": return Intrinsic._MM512_BROADCAST_I32X2;
                case "_MM512_MASK_BROADCAST_I32X2": return Intrinsic._MM512_MASK_BROADCAST_I32X2;
                case "_MM512_MASKZ_BROADCAST_I32X2": return Intrinsic._MM512_MASKZ_BROADCAST_I32X2;
                case "_MM256_BROADCAST_I32X4": return Intrinsic._MM256_BROADCAST_I32X4;
                case "_MM256_MASK_BROADCAST_I32X4": return Intrinsic._MM256_MASK_BROADCAST_I32X4;
                case "_MM256_MASKZ_BROADCAST_I32X4": return Intrinsic._MM256_MASKZ_BROADCAST_I32X4;
                case "_MM512_BROADCAST_I32X4": return Intrinsic._MM512_BROADCAST_I32X4;
                case "_MM512_MASK_BROADCAST_I32X4": return Intrinsic._MM512_MASK_BROADCAST_I32X4;
                case "_MM512_MASKZ_BROADCAST_I32X4": return Intrinsic._MM512_MASKZ_BROADCAST_I32X4;
                case "_MM512_BROADCAST_I32X8": return Intrinsic._MM512_BROADCAST_I32X8;
                case "_MM512_MASK_BROADCAST_I32X8": return Intrinsic._MM512_MASK_BROADCAST_I32X8;
                case "_MM512_MASKZ_BROADCAST_I32X8": return Intrinsic._MM512_MASKZ_BROADCAST_I32X8;
                case "_MM256_BROADCAST_I64X2": return Intrinsic._MM256_BROADCAST_I64X2;
                case "_MM256_MASK_BROADCAST_I64X2": return Intrinsic._MM256_MASK_BROADCAST_I64X2;
                case "_MM256_MASKZ_BROADCAST_I64X2": return Intrinsic._MM256_MASKZ_BROADCAST_I64X2;
                case "_MM512_BROADCAST_I64X2": return Intrinsic._MM512_BROADCAST_I64X2;
                case "_MM512_MASK_BROADCAST_I64X2": return Intrinsic._MM512_MASK_BROADCAST_I64X2;
                case "_MM512_MASKZ_BROADCAST_I64X2": return Intrinsic._MM512_MASKZ_BROADCAST_I64X2;
                case "_MM512_BROADCAST_I64X4": return Intrinsic._MM512_BROADCAST_I64X4;
                case "_MM512_MASK_BROADCAST_I64X4": return Intrinsic._MM512_MASK_BROADCAST_I64X4;
                case "_MM512_MASKZ_BROADCAST_I64X4": return Intrinsic._MM512_MASKZ_BROADCAST_I64X4;
                case "_MM256_BROADCAST_PD": return Intrinsic._MM256_BROADCAST_PD;
                case "_MM256_BROADCAST_PS": return Intrinsic._MM256_BROADCAST_PS;
                case "_MM256_BROADCAST_SD": return Intrinsic._MM256_BROADCAST_SD;
                case "_MM_BROADCAST_SS": return Intrinsic._MM_BROADCAST_SS;
                case "_MM256_BROADCAST_SS": return Intrinsic._MM256_BROADCAST_SS;
                case "_MM_BROADCASTB_EPI8": return Intrinsic._MM_BROADCASTB_EPI8;
                case "_MM_MASK_BROADCASTB_EPI8": return Intrinsic._MM_MASK_BROADCASTB_EPI8;
                case "_MM_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM_MASKZ_BROADCASTB_EPI8;
                case "_MM256_BROADCASTB_EPI8": return Intrinsic._MM256_BROADCASTB_EPI8;
                case "_MM256_MASK_BROADCASTB_EPI8": return Intrinsic._MM256_MASK_BROADCASTB_EPI8;
                case "_MM256_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM256_MASKZ_BROADCASTB_EPI8;
                case "_MM512_BROADCASTB_EPI8": return Intrinsic._MM512_BROADCASTB_EPI8;
                case "_MM512_MASK_BROADCASTB_EPI8": return Intrinsic._MM512_MASK_BROADCASTB_EPI8;
                case "_MM512_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM512_MASKZ_BROADCASTB_EPI8;
                case "_MM_BROADCASTD_EPI32": return Intrinsic._MM_BROADCASTD_EPI32;
                case "_MM_MASK_BROADCASTD_EPI32": return Intrinsic._MM_MASK_BROADCASTD_EPI32;
                case "_MM_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM_MASKZ_BROADCASTD_EPI32;
                case "_MM256_BROADCASTD_EPI32": return Intrinsic._MM256_BROADCASTD_EPI32;
                case "_MM256_MASK_BROADCASTD_EPI32": return Intrinsic._MM256_MASK_BROADCASTD_EPI32;
                case "_MM256_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM256_MASKZ_BROADCASTD_EPI32;
                case "_MM512_BROADCASTD_EPI32": return Intrinsic._MM512_BROADCASTD_EPI32;
                case "_MM512_MASK_BROADCASTD_EPI32": return Intrinsic._MM512_MASK_BROADCASTD_EPI32;
                case "_MM512_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM512_MASKZ_BROADCASTD_EPI32;
                case "_MM_BROADCASTMB_EPI64": return Intrinsic._MM_BROADCASTMB_EPI64;
                case "_MM256_BROADCASTMB_EPI64": return Intrinsic._MM256_BROADCASTMB_EPI64;
                case "_MM512_BROADCASTMB_EPI64": return Intrinsic._MM512_BROADCASTMB_EPI64;
                case "_MM_BROADCASTMW_EPI32": return Intrinsic._MM_BROADCASTMW_EPI32;
                case "_MM256_BROADCASTMW_EPI32": return Intrinsic._MM256_BROADCASTMW_EPI32;
                case "_MM512_BROADCASTMW_EPI32": return Intrinsic._MM512_BROADCASTMW_EPI32;
                case "_MM_BROADCASTQ_EPI64": return Intrinsic._MM_BROADCASTQ_EPI64;
                case "_MM_MASK_BROADCASTQ_EPI64": return Intrinsic._MM_MASK_BROADCASTQ_EPI64;
                case "_MM_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM_MASKZ_BROADCASTQ_EPI64;
                case "_MM256_BROADCASTQ_EPI64": return Intrinsic._MM256_BROADCASTQ_EPI64;
                case "_MM256_MASK_BROADCASTQ_EPI64": return Intrinsic._MM256_MASK_BROADCASTQ_EPI64;
                case "_MM256_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM256_MASKZ_BROADCASTQ_EPI64;
                case "_MM512_BROADCASTQ_EPI64": return Intrinsic._MM512_BROADCASTQ_EPI64;
                case "_MM512_MASK_BROADCASTQ_EPI64": return Intrinsic._MM512_MASK_BROADCASTQ_EPI64;
                case "_MM512_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM512_MASKZ_BROADCASTQ_EPI64;
                case "_MM_BROADCASTSD_PD": return Intrinsic._MM_BROADCASTSD_PD;
                case "_MM256_BROADCASTSD_PD": return Intrinsic._MM256_BROADCASTSD_PD;
                case "_MM256_MASK_BROADCASTSD_PD": return Intrinsic._MM256_MASK_BROADCASTSD_PD;
                case "_MM256_MASKZ_BROADCASTSD_PD": return Intrinsic._MM256_MASKZ_BROADCASTSD_PD;
                case "_MM512_BROADCASTSD_PD": return Intrinsic._MM512_BROADCASTSD_PD;
                case "_MM512_MASK_BROADCASTSD_PD": return Intrinsic._MM512_MASK_BROADCASTSD_PD;
                case "_MM512_MASKZ_BROADCASTSD_PD": return Intrinsic._MM512_MASKZ_BROADCASTSD_PD;
                case "_MM256_BROADCASTSI128_SI256": return Intrinsic._MM256_BROADCASTSI128_SI256;
                case "_MM_BROADCASTSS_PS": return Intrinsic._MM_BROADCASTSS_PS;
                case "_MM_MASK_BROADCASTSS_PS": return Intrinsic._MM_MASK_BROADCASTSS_PS;
                case "_MM_MASKZ_BROADCASTSS_PS": return Intrinsic._MM_MASKZ_BROADCASTSS_PS;
                case "_MM256_BROADCASTSS_PS": return Intrinsic._MM256_BROADCASTSS_PS;
                case "_MM256_MASK_BROADCASTSS_PS": return Intrinsic._MM256_MASK_BROADCASTSS_PS;
                case "_MM256_MASKZ_BROADCASTSS_PS": return Intrinsic._MM256_MASKZ_BROADCASTSS_PS;
                case "_MM512_BROADCASTSS_PS": return Intrinsic._MM512_BROADCASTSS_PS;
                case "_MM512_MASK_BROADCASTSS_PS": return Intrinsic._MM512_MASK_BROADCASTSS_PS;
                case "_MM512_MASKZ_BROADCASTSS_PS": return Intrinsic._MM512_MASKZ_BROADCASTSS_PS;
                case "_MM_BROADCASTW_EPI16": return Intrinsic._MM_BROADCASTW_EPI16;
                case "_MM_MASK_BROADCASTW_EPI16": return Intrinsic._MM_MASK_BROADCASTW_EPI16;
                case "_MM_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM_MASKZ_BROADCASTW_EPI16;
                case "_MM256_BROADCASTW_EPI16": return Intrinsic._MM256_BROADCASTW_EPI16;
                case "_MM256_MASK_BROADCASTW_EPI16": return Intrinsic._MM256_MASK_BROADCASTW_EPI16;
                case "_MM256_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM256_MASKZ_BROADCASTW_EPI16;
                case "_MM512_BROADCASTW_EPI16": return Intrinsic._MM512_BROADCASTW_EPI16;
                case "_MM512_MASK_BROADCASTW_EPI16": return Intrinsic._MM512_MASK_BROADCASTW_EPI16;
                case "_MM512_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM512_MASKZ_BROADCASTW_EPI16;
                case "_MM256_BSLLI_EPI128": return Intrinsic._MM256_BSLLI_EPI128;
                case "_MM512_BSLLI_EPI128": return Intrinsic._MM512_BSLLI_EPI128;
                case "_MM_BSLLI_SI128": return Intrinsic._MM_BSLLI_SI128;
                case "_MM256_BSRLI_EPI128": return Intrinsic._MM256_BSRLI_EPI128;
                case "_MM512_BSRLI_EPI128": return Intrinsic._MM512_BSRLI_EPI128;
                case "_MM_BSRLI_SI128": return Intrinsic._MM_BSRLI_SI128;
                case "_BSWAP": return Intrinsic._BSWAP;
                case "_BSWAP64": return Intrinsic._BSWAP64;
                case "_BZHI_U32": return Intrinsic._BZHI_U32;
                case "_BZHI_U64": return Intrinsic._BZHI_U64;
                case "_CASTF32_U32": return Intrinsic._CASTF32_U32;
                case "_CASTF64_U64": return Intrinsic._CASTF64_U64;
                case "_MM_CASTPD_PS": return Intrinsic._MM_CASTPD_PS;
                case "_MM256_CASTPD_PS": return Intrinsic._MM256_CASTPD_PS;
                case "_MM512_CASTPD_PS": return Intrinsic._MM512_CASTPD_PS;
                case "_MM_CASTPD_SI128": return Intrinsic._MM_CASTPD_SI128;
                case "_MM256_CASTPD_SI256": return Intrinsic._MM256_CASTPD_SI256;
                case "_MM512_CASTPD_SI512": return Intrinsic._MM512_CASTPD_SI512;
                case "_MM256_CASTPD128_PD256": return Intrinsic._MM256_CASTPD128_PD256;
                case "_MM512_CASTPD128_PD512": return Intrinsic._MM512_CASTPD128_PD512;
                case "_MM256_CASTPD256_PD128": return Intrinsic._MM256_CASTPD256_PD128;
                case "_MM512_CASTPD256_PD512": return Intrinsic._MM512_CASTPD256_PD512;
                case "_MM512_CASTPD512_PD128": return Intrinsic._MM512_CASTPD512_PD128;
                case "_MM512_CASTPD512_PD256": return Intrinsic._MM512_CASTPD512_PD256;
                case "_MM_CASTPS_PD": return Intrinsic._MM_CASTPS_PD;
                case "_MM256_CASTPS_PD": return Intrinsic._MM256_CASTPS_PD;
                case "_MM512_CASTPS_PD": return Intrinsic._MM512_CASTPS_PD;
                case "_MM_CASTPS_SI128": return Intrinsic._MM_CASTPS_SI128;
                case "_MM256_CASTPS_SI256": return Intrinsic._MM256_CASTPS_SI256;
                case "_MM512_CASTPS_SI512": return Intrinsic._MM512_CASTPS_SI512;
                case "_MM256_CASTPS128_PS256": return Intrinsic._MM256_CASTPS128_PS256;
                case "_MM512_CASTPS128_PS512": return Intrinsic._MM512_CASTPS128_PS512;
                case "_MM256_CASTPS256_PS128": return Intrinsic._MM256_CASTPS256_PS128;
                case "_MM512_CASTPS256_PS512": return Intrinsic._MM512_CASTPS256_PS512;
                case "_MM512_CASTPS512_PS128": return Intrinsic._MM512_CASTPS512_PS128;
                case "_MM512_CASTPS512_PS256": return Intrinsic._MM512_CASTPS512_PS256;
                case "_MM_CASTSI128_PD": return Intrinsic._MM_CASTSI128_PD;
                case "_MM_CASTSI128_PS": return Intrinsic._MM_CASTSI128_PS;
                case "_MM256_CASTSI128_SI256": return Intrinsic._MM256_CASTSI128_SI256;
                case "_MM512_CASTSI128_SI512": return Intrinsic._MM512_CASTSI128_SI512;
                case "_MM256_CASTSI256_PD": return Intrinsic._MM256_CASTSI256_PD;
                case "_MM256_CASTSI256_PS": return Intrinsic._MM256_CASTSI256_PS;
                case "_MM256_CASTSI256_SI128": return Intrinsic._MM256_CASTSI256_SI128;
                case "_MM512_CASTSI256_SI512": return Intrinsic._MM512_CASTSI256_SI512;
                case "_MM512_CASTSI512_PD": return Intrinsic._MM512_CASTSI512_PD;
                case "_MM512_CASTSI512_PS": return Intrinsic._MM512_CASTSI512_PS;
                case "_MM512_CASTSI512_SI128": return Intrinsic._MM512_CASTSI512_SI128;
                case "_MM512_CASTSI512_SI256": return Intrinsic._MM512_CASTSI512_SI256;
                case "_CASTU32_F32": return Intrinsic._CASTU32_F32;
                case "_CASTU64_F64": return Intrinsic._CASTU64_F64;
                case "_MM_CBRT_PD": return Intrinsic._MM_CBRT_PD;
                case "_MM256_CBRT_PD": return Intrinsic._MM256_CBRT_PD;
                case "_MM512_CBRT_PD": return Intrinsic._MM512_CBRT_PD;
                case "_MM512_MASK_CBRT_PD": return Intrinsic._MM512_MASK_CBRT_PD;
                case "_MM_CBRT_PS": return Intrinsic._MM_CBRT_PS;
                case "_MM256_CBRT_PS": return Intrinsic._MM256_CBRT_PS;
                case "_MM512_CBRT_PS": return Intrinsic._MM512_CBRT_PS;
                case "_MM512_MASK_CBRT_PS": return Intrinsic._MM512_MASK_CBRT_PS;
                case "_MM_CDFNORM_PD": return Intrinsic._MM_CDFNORM_PD;
                case "_MM256_CDFNORM_PD": return Intrinsic._MM256_CDFNORM_PD;
                case "_MM512_CDFNORM_PD": return Intrinsic._MM512_CDFNORM_PD;
                case "_MM512_MASK_CDFNORM_PD": return Intrinsic._MM512_MASK_CDFNORM_PD;
                case "_MM_CDFNORM_PS": return Intrinsic._MM_CDFNORM_PS;
                case "_MM256_CDFNORM_PS": return Intrinsic._MM256_CDFNORM_PS;
                case "_MM512_CDFNORM_PS": return Intrinsic._MM512_CDFNORM_PS;
                case "_MM512_MASK_CDFNORM_PS": return Intrinsic._MM512_MASK_CDFNORM_PS;
                case "_MM_CDFNORMINV_PD": return Intrinsic._MM_CDFNORMINV_PD;
                case "_MM256_CDFNORMINV_PD": return Intrinsic._MM256_CDFNORMINV_PD;
                case "_MM512_CDFNORMINV_PD": return Intrinsic._MM512_CDFNORMINV_PD;
                case "_MM512_MASK_CDFNORMINV_PD": return Intrinsic._MM512_MASK_CDFNORMINV_PD;
                case "_MM_CDFNORMINV_PS": return Intrinsic._MM_CDFNORMINV_PS;
                case "_MM256_CDFNORMINV_PS": return Intrinsic._MM256_CDFNORMINV_PS;
                case "_MM512_CDFNORMINV_PS": return Intrinsic._MM512_CDFNORMINV_PS;
                case "_MM512_MASK_CDFNORMINV_PS": return Intrinsic._MM512_MASK_CDFNORMINV_PS;
                case "_MM_CEIL_PD": return Intrinsic._MM_CEIL_PD;
                case "_MM256_CEIL_PD": return Intrinsic._MM256_CEIL_PD;
                case "_MM512_CEIL_PD": return Intrinsic._MM512_CEIL_PD;
                case "_MM512_MASK_CEIL_PD": return Intrinsic._MM512_MASK_CEIL_PD;
                case "_MM_CEIL_PS": return Intrinsic._MM_CEIL_PS;
                case "_MM256_CEIL_PS": return Intrinsic._MM256_CEIL_PS;
                case "_MM512_CEIL_PS": return Intrinsic._MM512_CEIL_PS;
                case "_MM512_MASK_CEIL_PS": return Intrinsic._MM512_MASK_CEIL_PS;
                case "_MM_CEIL_SD": return Intrinsic._MM_CEIL_SD;
                case "_MM_CEIL_SS": return Intrinsic._MM_CEIL_SS;
                case "_MM_CEXP_PS": return Intrinsic._MM_CEXP_PS;
                case "_MM256_CEXP_PS": return Intrinsic._MM256_CEXP_PS;
                case "_MM_CLEVICT": return Intrinsic._MM_CLEVICT;
                case "_MM_CLFLUSH": return Intrinsic._MM_CLFLUSH;
                case "_MM_CLFLUSHOPT": return Intrinsic._MM_CLFLUSHOPT;
                case "_MM_CLMULEPI64_SI128": return Intrinsic._MM_CLMULEPI64_SI128;
                case "_MM_CLOG_PS": return Intrinsic._MM_CLOG_PS;
                case "_MM256_CLOG_PS": return Intrinsic._MM256_CLOG_PS;
                case "_MM_CMP_EPI16_MASK": return Intrinsic._MM_CMP_EPI16_MASK;
                case "_MM_MASK_CMP_EPI16_MASK": return Intrinsic._MM_MASK_CMP_EPI16_MASK;
                case "_MM256_CMP_EPI16_MASK": return Intrinsic._MM256_CMP_EPI16_MASK;
                case "_MM256_MASK_CMP_EPI16_MASK": return Intrinsic._MM256_MASK_CMP_EPI16_MASK;
                case "_MM512_CMP_EPI16_MASK": return Intrinsic._MM512_CMP_EPI16_MASK;
                case "_MM512_MASK_CMP_EPI16_MASK": return Intrinsic._MM512_MASK_CMP_EPI16_MASK;
                case "_MM_CMP_EPI32_MASK": return Intrinsic._MM_CMP_EPI32_MASK;
                case "_MM_MASK_CMP_EPI32_MASK": return Intrinsic._MM_MASK_CMP_EPI32_MASK;
                case "_MM256_CMP_EPI32_MASK": return Intrinsic._MM256_CMP_EPI32_MASK;
                case "_MM256_MASK_CMP_EPI32_MASK": return Intrinsic._MM256_MASK_CMP_EPI32_MASK;
                case "_MM512_CMP_EPI32_MASK": return Intrinsic._MM512_CMP_EPI32_MASK;
                case "_MM512_MASK_CMP_EPI32_MASK": return Intrinsic._MM512_MASK_CMP_EPI32_MASK;
                case "_MM_CMP_EPI64_MASK": return Intrinsic._MM_CMP_EPI64_MASK;
                case "_MM_MASK_CMP_EPI64_MASK": return Intrinsic._MM_MASK_CMP_EPI64_MASK;
                case "_MM256_CMP_EPI64_MASK": return Intrinsic._MM256_CMP_EPI64_MASK;
                case "_MM256_MASK_CMP_EPI64_MASK": return Intrinsic._MM256_MASK_CMP_EPI64_MASK;
                case "_MM512_CMP_EPI64_MASK": return Intrinsic._MM512_CMP_EPI64_MASK;
                case "_MM512_MASK_CMP_EPI64_MASK": return Intrinsic._MM512_MASK_CMP_EPI64_MASK;
                case "_MM_CMP_EPI8_MASK": return Intrinsic._MM_CMP_EPI8_MASK;
                case "_MM_MASK_CMP_EPI8_MASK": return Intrinsic._MM_MASK_CMP_EPI8_MASK;
                case "_MM256_CMP_EPI8_MASK": return Intrinsic._MM256_CMP_EPI8_MASK;
                case "_MM256_MASK_CMP_EPI8_MASK": return Intrinsic._MM256_MASK_CMP_EPI8_MASK;
                case "_MM512_CMP_EPI8_MASK": return Intrinsic._MM512_CMP_EPI8_MASK;
                case "_MM512_MASK_CMP_EPI8_MASK": return Intrinsic._MM512_MASK_CMP_EPI8_MASK;
                case "_MM_CMP_EPU16_MASK": return Intrinsic._MM_CMP_EPU16_MASK;
                case "_MM_MASK_CMP_EPU16_MASK": return Intrinsic._MM_MASK_CMP_EPU16_MASK;
                case "_MM256_CMP_EPU16_MASK": return Intrinsic._MM256_CMP_EPU16_MASK;
                case "_MM256_MASK_CMP_EPU16_MASK": return Intrinsic._MM256_MASK_CMP_EPU16_MASK;
                case "_MM512_CMP_EPU16_MASK": return Intrinsic._MM512_CMP_EPU16_MASK;
                case "_MM512_MASK_CMP_EPU16_MASK": return Intrinsic._MM512_MASK_CMP_EPU16_MASK;
                case "_MM_CMP_EPU32_MASK": return Intrinsic._MM_CMP_EPU32_MASK;
                case "_MM_MASK_CMP_EPU32_MASK": return Intrinsic._MM_MASK_CMP_EPU32_MASK;
                case "_MM256_CMP_EPU32_MASK": return Intrinsic._MM256_CMP_EPU32_MASK;
                case "_MM256_MASK_CMP_EPU32_MASK": return Intrinsic._MM256_MASK_CMP_EPU32_MASK;
                case "_MM512_CMP_EPU32_MASK": return Intrinsic._MM512_CMP_EPU32_MASK;
                case "_MM512_MASK_CMP_EPU32_MASK": return Intrinsic._MM512_MASK_CMP_EPU32_MASK;
                case "_MM_CMP_EPU64_MASK": return Intrinsic._MM_CMP_EPU64_MASK;
                case "_MM_MASK_CMP_EPU64_MASK": return Intrinsic._MM_MASK_CMP_EPU64_MASK;
                case "_MM256_CMP_EPU64_MASK": return Intrinsic._MM256_CMP_EPU64_MASK;
                case "_MM256_MASK_CMP_EPU64_MASK": return Intrinsic._MM256_MASK_CMP_EPU64_MASK;
                case "_MM512_CMP_EPU64_MASK": return Intrinsic._MM512_CMP_EPU64_MASK;
                case "_MM512_MASK_CMP_EPU64_MASK": return Intrinsic._MM512_MASK_CMP_EPU64_MASK;
                case "_MM_CMP_EPU8_MASK": return Intrinsic._MM_CMP_EPU8_MASK;
                case "_MM_MASK_CMP_EPU8_MASK": return Intrinsic._MM_MASK_CMP_EPU8_MASK;
                case "_MM256_CMP_EPU8_MASK": return Intrinsic._MM256_CMP_EPU8_MASK;
                case "_MM256_MASK_CMP_EPU8_MASK": return Intrinsic._MM256_MASK_CMP_EPU8_MASK;
                case "_MM512_CMP_EPU8_MASK": return Intrinsic._MM512_CMP_EPU8_MASK;
                case "_MM512_MASK_CMP_EPU8_MASK": return Intrinsic._MM512_MASK_CMP_EPU8_MASK;
                case "_MM_CMP_PD": return Intrinsic._MM_CMP_PD;
                case "_MM256_CMP_PD": return Intrinsic._MM256_CMP_PD;
                case "_MM_CMP_PD_MASK": return Intrinsic._MM_CMP_PD_MASK;
                case "_MM_MASK_CMP_PD_MASK": return Intrinsic._MM_MASK_CMP_PD_MASK;
                case "_MM256_CMP_PD_MASK": return Intrinsic._MM256_CMP_PD_MASK;
                case "_MM256_MASK_CMP_PD_MASK": return Intrinsic._MM256_MASK_CMP_PD_MASK;
                case "_MM512_CMP_PD_MASK": return Intrinsic._MM512_CMP_PD_MASK;
                case "_MM512_MASK_CMP_PD_MASK": return Intrinsic._MM512_MASK_CMP_PD_MASK;
                case "_MM_CMP_PS": return Intrinsic._MM_CMP_PS;
                case "_MM256_CMP_PS": return Intrinsic._MM256_CMP_PS;
                case "_MM_CMP_PS_MASK": return Intrinsic._MM_CMP_PS_MASK;
                case "_MM_MASK_CMP_PS_MASK": return Intrinsic._MM_MASK_CMP_PS_MASK;
                case "_MM256_CMP_PS_MASK": return Intrinsic._MM256_CMP_PS_MASK;
                case "_MM256_MASK_CMP_PS_MASK": return Intrinsic._MM256_MASK_CMP_PS_MASK;
                case "_MM512_CMP_PS_MASK": return Intrinsic._MM512_CMP_PS_MASK;
                case "_MM512_MASK_CMP_PS_MASK": return Intrinsic._MM512_MASK_CMP_PS_MASK;
                case "_MM512_CMP_ROUND_PD_MASK": return Intrinsic._MM512_CMP_ROUND_PD_MASK;
                case "_MM512_MASK_CMP_ROUND_PD_MASK": return Intrinsic._MM512_MASK_CMP_ROUND_PD_MASK;
                case "_MM512_CMP_ROUND_PS_MASK": return Intrinsic._MM512_CMP_ROUND_PS_MASK;
                case "_MM512_MASK_CMP_ROUND_PS_MASK": return Intrinsic._MM512_MASK_CMP_ROUND_PS_MASK;
                case "_MM_CMP_ROUND_SD_MASK": return Intrinsic._MM_CMP_ROUND_SD_MASK;
                case "_MM_MASK_CMP_ROUND_SD_MASK": return Intrinsic._MM_MASK_CMP_ROUND_SD_MASK;
                case "_MM_CMP_ROUND_SS_MASK": return Intrinsic._MM_CMP_ROUND_SS_MASK;
                case "_MM_MASK_CMP_ROUND_SS_MASK": return Intrinsic._MM_MASK_CMP_ROUND_SS_MASK;
                case "_MM_CMP_SD": return Intrinsic._MM_CMP_SD;
                case "_MM_CMP_SD_MASK": return Intrinsic._MM_CMP_SD_MASK;
                case "_MM_MASK_CMP_SD_MASK": return Intrinsic._MM_MASK_CMP_SD_MASK;
                case "_MM_CMP_SS": return Intrinsic._MM_CMP_SS;
                case "_MM_CMP_SS_MASK": return Intrinsic._MM_CMP_SS_MASK;
                case "_MM_MASK_CMP_SS_MASK": return Intrinsic._MM_MASK_CMP_SS_MASK;
                case "_MM_CMPEQ_EPI16": return Intrinsic._MM_CMPEQ_EPI16;
                case "_MM256_CMPEQ_EPI16": return Intrinsic._MM256_CMPEQ_EPI16;
                case "_MM_CMPEQ_EPI16_MASK": return Intrinsic._MM_CMPEQ_EPI16_MASK;
                case "_MM_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI16_MASK;
                case "_MM256_CMPEQ_EPI16_MASK": return Intrinsic._MM256_CMPEQ_EPI16_MASK;
                case "_MM256_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI16_MASK;
                case "_MM512_CMPEQ_EPI16_MASK": return Intrinsic._MM512_CMPEQ_EPI16_MASK;
                case "_MM512_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI16_MASK;
                case "_MM_CMPEQ_EPI32": return Intrinsic._MM_CMPEQ_EPI32;
                case "_MM256_CMPEQ_EPI32": return Intrinsic._MM256_CMPEQ_EPI32;
                case "_MM_CMPEQ_EPI32_MASK": return Intrinsic._MM_CMPEQ_EPI32_MASK;
                case "_MM_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI32_MASK;
                case "_MM256_CMPEQ_EPI32_MASK": return Intrinsic._MM256_CMPEQ_EPI32_MASK;
                case "_MM256_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI32_MASK;
                case "_MM512_CMPEQ_EPI32_MASK": return Intrinsic._MM512_CMPEQ_EPI32_MASK;
                case "_MM512_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI32_MASK;
                case "_MM_CMPEQ_EPI64": return Intrinsic._MM_CMPEQ_EPI64;
                case "_MM256_CMPEQ_EPI64": return Intrinsic._MM256_CMPEQ_EPI64;
                case "_MM_CMPEQ_EPI64_MASK": return Intrinsic._MM_CMPEQ_EPI64_MASK;
                case "_MM_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI64_MASK;
                case "_MM256_CMPEQ_EPI64_MASK": return Intrinsic._MM256_CMPEQ_EPI64_MASK;
                case "_MM256_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI64_MASK;
                case "_MM512_CMPEQ_EPI64_MASK": return Intrinsic._MM512_CMPEQ_EPI64_MASK;
                case "_MM512_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI64_MASK;
                case "_MM_CMPEQ_EPI8": return Intrinsic._MM_CMPEQ_EPI8;
                case "_MM256_CMPEQ_EPI8": return Intrinsic._MM256_CMPEQ_EPI8;
                case "_MM_CMPEQ_EPI8_MASK": return Intrinsic._MM_CMPEQ_EPI8_MASK;
                case "_MM_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI8_MASK;
                case "_MM256_CMPEQ_EPI8_MASK": return Intrinsic._MM256_CMPEQ_EPI8_MASK;
                case "_MM256_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI8_MASK;
                case "_MM512_CMPEQ_EPI8_MASK": return Intrinsic._MM512_CMPEQ_EPI8_MASK;
                case "_MM512_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI8_MASK;
                case "_MM_CMPEQ_EPU16_MASK": return Intrinsic._MM_CMPEQ_EPU16_MASK;
                case "_MM_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU16_MASK;
                case "_MM256_CMPEQ_EPU16_MASK": return Intrinsic._MM256_CMPEQ_EPU16_MASK;
                case "_MM256_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU16_MASK;
                case "_MM512_CMPEQ_EPU16_MASK": return Intrinsic._MM512_CMPEQ_EPU16_MASK;
                case "_MM512_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU16_MASK;
                case "_MM_CMPEQ_EPU32_MASK": return Intrinsic._MM_CMPEQ_EPU32_MASK;
                case "_MM_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU32_MASK;
                case "_MM256_CMPEQ_EPU32_MASK": return Intrinsic._MM256_CMPEQ_EPU32_MASK;
                case "_MM256_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU32_MASK;
                case "_MM512_CMPEQ_EPU32_MASK": return Intrinsic._MM512_CMPEQ_EPU32_MASK;
                case "_MM512_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU32_MASK;
                case "_MM_CMPEQ_EPU64_MASK": return Intrinsic._MM_CMPEQ_EPU64_MASK;
                case "_MM_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU64_MASK;
                case "_MM256_CMPEQ_EPU64_MASK": return Intrinsic._MM256_CMPEQ_EPU64_MASK;
                case "_MM256_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU64_MASK;
                case "_MM512_CMPEQ_EPU64_MASK": return Intrinsic._MM512_CMPEQ_EPU64_MASK;
                case "_MM512_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU64_MASK;
                case "_MM_CMPEQ_EPU8_MASK": return Intrinsic._MM_CMPEQ_EPU8_MASK;
                case "_MM_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU8_MASK;
                case "_MM256_CMPEQ_EPU8_MASK": return Intrinsic._MM256_CMPEQ_EPU8_MASK;
                case "_MM256_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU8_MASK;
                case "_MM512_CMPEQ_EPU8_MASK": return Intrinsic._MM512_CMPEQ_EPU8_MASK;
                case "_MM512_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU8_MASK;
                case "_MM_CMPEQ_PD": return Intrinsic._MM_CMPEQ_PD;
                case "_MM512_CMPEQ_PD_MASK": return Intrinsic._MM512_CMPEQ_PD_MASK;
                case "_MM512_MASK_CMPEQ_PD_MASK": return Intrinsic._MM512_MASK_CMPEQ_PD_MASK;
                case "_MM_CMPEQ_PI16": return Intrinsic._MM_CMPEQ_PI16;
                case "_MM_CMPEQ_PI32": return Intrinsic._MM_CMPEQ_PI32;
                case "_MM_CMPEQ_PI8": return Intrinsic._MM_CMPEQ_PI8;
                case "_MM_CMPEQ_PS": return Intrinsic._MM_CMPEQ_PS;
                case "_MM512_CMPEQ_PS_MASK": return Intrinsic._MM512_CMPEQ_PS_MASK;
                case "_MM512_MASK_CMPEQ_PS_MASK": return Intrinsic._MM512_MASK_CMPEQ_PS_MASK;
                case "_MM_CMPEQ_SD": return Intrinsic._MM_CMPEQ_SD;
                case "_MM_CMPEQ_SS": return Intrinsic._MM_CMPEQ_SS;
                case "_MM_CMPESTRA": return Intrinsic._MM_CMPESTRA;
                case "_MM_CMPESTRC": return Intrinsic._MM_CMPESTRC;
                case "_MM_CMPESTRI": return Intrinsic._MM_CMPESTRI;
                case "_MM_CMPESTRM": return Intrinsic._MM_CMPESTRM;
                case "_MM_CMPESTRO": return Intrinsic._MM_CMPESTRO;
                case "_MM_CMPESTRS": return Intrinsic._MM_CMPESTRS;
                case "_MM_CMPESTRZ": return Intrinsic._MM_CMPESTRZ;
                case "_MM_CMPGE_EPI16_MASK": return Intrinsic._MM_CMPGE_EPI16_MASK;
                case "_MM_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM_MASK_CMPGE_EPI16_MASK;
                case "_MM256_CMPGE_EPI16_MASK": return Intrinsic._MM256_CMPGE_EPI16_MASK;
                case "_MM256_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI16_MASK;
                case "_MM512_CMPGE_EPI16_MASK": return Intrinsic._MM512_CMPGE_EPI16_MASK;
                case "_MM512_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI16_MASK;
                case "_MM_CMPGE_EPI32_MASK": return Intrinsic._MM_CMPGE_EPI32_MASK;
                case "_MM_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM_MASK_CMPGE_EPI32_MASK;
                case "_MM256_CMPGE_EPI32_MASK": return Intrinsic._MM256_CMPGE_EPI32_MASK;
                case "_MM256_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI32_MASK;
                case "_MM512_CMPGE_EPI32_MASK": return Intrinsic._MM512_CMPGE_EPI32_MASK;
                case "_MM512_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI32_MASK;
                case "_MM_CMPGE_EPI64_MASK": return Intrinsic._MM_CMPGE_EPI64_MASK;
                case "_MM_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM_MASK_CMPGE_EPI64_MASK;
                case "_MM256_CMPGE_EPI64_MASK": return Intrinsic._MM256_CMPGE_EPI64_MASK;
                case "_MM256_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI64_MASK;
                case "_MM512_CMPGE_EPI64_MASK": return Intrinsic._MM512_CMPGE_EPI64_MASK;
                case "_MM512_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI64_MASK;
                case "_MM_CMPGE_EPI8_MASK": return Intrinsic._MM_CMPGE_EPI8_MASK;
                case "_MM_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM_MASK_CMPGE_EPI8_MASK;
                case "_MM256_CMPGE_EPI8_MASK": return Intrinsic._MM256_CMPGE_EPI8_MASK;
                case "_MM256_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI8_MASK;
                case "_MM512_CMPGE_EPI8_MASK": return Intrinsic._MM512_CMPGE_EPI8_MASK;
                case "_MM512_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI8_MASK;
                case "_MM_CMPGE_EPU16_MASK": return Intrinsic._MM_CMPGE_EPU16_MASK;
                case "_MM_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM_MASK_CMPGE_EPU16_MASK;
                case "_MM256_CMPGE_EPU16_MASK": return Intrinsic._MM256_CMPGE_EPU16_MASK;
                case "_MM256_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU16_MASK;
                case "_MM512_CMPGE_EPU16_MASK": return Intrinsic._MM512_CMPGE_EPU16_MASK;
                case "_MM512_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU16_MASK;
                case "_MM_CMPGE_EPU32_MASK": return Intrinsic._MM_CMPGE_EPU32_MASK;
                case "_MM_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM_MASK_CMPGE_EPU32_MASK;
                case "_MM256_CMPGE_EPU32_MASK": return Intrinsic._MM256_CMPGE_EPU32_MASK;
                case "_MM256_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU32_MASK;
                case "_MM512_CMPGE_EPU32_MASK": return Intrinsic._MM512_CMPGE_EPU32_MASK;
                case "_MM512_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU32_MASK;
                case "_MM_CMPGE_EPU64_MASK": return Intrinsic._MM_CMPGE_EPU64_MASK;
                case "_MM_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM_MASK_CMPGE_EPU64_MASK;
                case "_MM256_CMPGE_EPU64_MASK": return Intrinsic._MM256_CMPGE_EPU64_MASK;
                case "_MM256_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU64_MASK;
                case "_MM512_CMPGE_EPU64_MASK": return Intrinsic._MM512_CMPGE_EPU64_MASK;
                case "_MM512_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU64_MASK;
                case "_MM_CMPGE_EPU8_MASK": return Intrinsic._MM_CMPGE_EPU8_MASK;
                case "_MM_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM_MASK_CMPGE_EPU8_MASK;
                case "_MM256_CMPGE_EPU8_MASK": return Intrinsic._MM256_CMPGE_EPU8_MASK;
                case "_MM256_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU8_MASK;
                case "_MM512_CMPGE_EPU8_MASK": return Intrinsic._MM512_CMPGE_EPU8_MASK;
                case "_MM512_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU8_MASK;
                case "_MM_CMPGE_PD": return Intrinsic._MM_CMPGE_PD;
                case "_MM_CMPGE_PS": return Intrinsic._MM_CMPGE_PS;
                case "_MM_CMPGE_SD": return Intrinsic._MM_CMPGE_SD;
                case "_MM_CMPGE_SS": return Intrinsic._MM_CMPGE_SS;
                case "_MM_CMPGT_EPI16": return Intrinsic._MM_CMPGT_EPI16;
                case "_MM256_CMPGT_EPI16": return Intrinsic._MM256_CMPGT_EPI16;
                case "_MM_CMPGT_EPI16_MASK": return Intrinsic._MM_CMPGT_EPI16_MASK;
                case "_MM_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM_MASK_CMPGT_EPI16_MASK;
                case "_MM256_CMPGT_EPI16_MASK": return Intrinsic._MM256_CMPGT_EPI16_MASK;
                case "_MM256_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI16_MASK;
                case "_MM512_CMPGT_EPI16_MASK": return Intrinsic._MM512_CMPGT_EPI16_MASK;
                case "_MM512_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI16_MASK;
                case "_MM_CMPGT_EPI32": return Intrinsic._MM_CMPGT_EPI32;
                case "_MM256_CMPGT_EPI32": return Intrinsic._MM256_CMPGT_EPI32;
                case "_MM_CMPGT_EPI32_MASK": return Intrinsic._MM_CMPGT_EPI32_MASK;
                case "_MM_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM_MASK_CMPGT_EPI32_MASK;
                case "_MM256_CMPGT_EPI32_MASK": return Intrinsic._MM256_CMPGT_EPI32_MASK;
                case "_MM256_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI32_MASK;
                case "_MM512_CMPGT_EPI32_MASK": return Intrinsic._MM512_CMPGT_EPI32_MASK;
                case "_MM512_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI32_MASK;
                case "_MM_CMPGT_EPI64": return Intrinsic._MM_CMPGT_EPI64;
                case "_MM256_CMPGT_EPI64": return Intrinsic._MM256_CMPGT_EPI64;
                case "_MM_CMPGT_EPI64_MASK": return Intrinsic._MM_CMPGT_EPI64_MASK;
                case "_MM_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM_MASK_CMPGT_EPI64_MASK;
                case "_MM256_CMPGT_EPI64_MASK": return Intrinsic._MM256_CMPGT_EPI64_MASK;
                case "_MM256_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI64_MASK;
                case "_MM512_CMPGT_EPI64_MASK": return Intrinsic._MM512_CMPGT_EPI64_MASK;
                case "_MM512_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI64_MASK;
                case "_MM_CMPGT_EPI8": return Intrinsic._MM_CMPGT_EPI8;
                case "_MM256_CMPGT_EPI8": return Intrinsic._MM256_CMPGT_EPI8;
                case "_MM_CMPGT_EPI8_MASK": return Intrinsic._MM_CMPGT_EPI8_MASK;
                case "_MM_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM_MASK_CMPGT_EPI8_MASK;
                case "_MM256_CMPGT_EPI8_MASK": return Intrinsic._MM256_CMPGT_EPI8_MASK;
                case "_MM256_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI8_MASK;
                case "_MM512_CMPGT_EPI8_MASK": return Intrinsic._MM512_CMPGT_EPI8_MASK;
                case "_MM512_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI8_MASK;
                case "_MM_CMPGT_EPU16_MASK": return Intrinsic._MM_CMPGT_EPU16_MASK;
                case "_MM_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM_MASK_CMPGT_EPU16_MASK;
                case "_MM256_CMPGT_EPU16_MASK": return Intrinsic._MM256_CMPGT_EPU16_MASK;
                case "_MM256_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU16_MASK;
                case "_MM512_CMPGT_EPU16_MASK": return Intrinsic._MM512_CMPGT_EPU16_MASK;
                case "_MM512_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU16_MASK;
                case "_MM_CMPGT_EPU32_MASK": return Intrinsic._MM_CMPGT_EPU32_MASK;
                case "_MM_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM_MASK_CMPGT_EPU32_MASK;
                case "_MM256_CMPGT_EPU32_MASK": return Intrinsic._MM256_CMPGT_EPU32_MASK;
                case "_MM256_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU32_MASK;
                case "_MM512_CMPGT_EPU32_MASK": return Intrinsic._MM512_CMPGT_EPU32_MASK;
                case "_MM512_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU32_MASK;
                case "_MM_CMPGT_EPU64_MASK": return Intrinsic._MM_CMPGT_EPU64_MASK;
                case "_MM_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM_MASK_CMPGT_EPU64_MASK;
                case "_MM256_CMPGT_EPU64_MASK": return Intrinsic._MM256_CMPGT_EPU64_MASK;
                case "_MM256_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU64_MASK;
                case "_MM512_CMPGT_EPU64_MASK": return Intrinsic._MM512_CMPGT_EPU64_MASK;
                case "_MM512_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU64_MASK;
                case "_MM_CMPGT_EPU8_MASK": return Intrinsic._MM_CMPGT_EPU8_MASK;
                case "_MM_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM_MASK_CMPGT_EPU8_MASK;
                case "_MM256_CMPGT_EPU8_MASK": return Intrinsic._MM256_CMPGT_EPU8_MASK;
                case "_MM256_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU8_MASK;
                case "_MM512_CMPGT_EPU8_MASK": return Intrinsic._MM512_CMPGT_EPU8_MASK;
                case "_MM512_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU8_MASK;
                case "_MM_CMPGT_PD": return Intrinsic._MM_CMPGT_PD;
                case "_MM_CMPGT_PI16": return Intrinsic._MM_CMPGT_PI16;
                case "_MM_CMPGT_PI32": return Intrinsic._MM_CMPGT_PI32;
                case "_MM_CMPGT_PI8": return Intrinsic._MM_CMPGT_PI8;
                case "_MM_CMPGT_PS": return Intrinsic._MM_CMPGT_PS;
                case "_MM_CMPGT_SD": return Intrinsic._MM_CMPGT_SD;
                case "_MM_CMPGT_SS": return Intrinsic._MM_CMPGT_SS;
                case "_MM_CMPISTRA": return Intrinsic._MM_CMPISTRA;
                case "_MM_CMPISTRC": return Intrinsic._MM_CMPISTRC;
                case "_MM_CMPISTRI": return Intrinsic._MM_CMPISTRI;
                case "_MM_CMPISTRM": return Intrinsic._MM_CMPISTRM;
                case "_MM_CMPISTRO": return Intrinsic._MM_CMPISTRO;
                case "_MM_CMPISTRS": return Intrinsic._MM_CMPISTRS;
                case "_MM_CMPISTRZ": return Intrinsic._MM_CMPISTRZ;
                case "_MM_CMPLE_EPI16_MASK": return Intrinsic._MM_CMPLE_EPI16_MASK;
                case "_MM_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM_MASK_CMPLE_EPI16_MASK;
                case "_MM256_CMPLE_EPI16_MASK": return Intrinsic._MM256_CMPLE_EPI16_MASK;
                case "_MM256_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI16_MASK;
                case "_MM512_CMPLE_EPI16_MASK": return Intrinsic._MM512_CMPLE_EPI16_MASK;
                case "_MM512_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI16_MASK;
                case "_MM_CMPLE_EPI32_MASK": return Intrinsic._MM_CMPLE_EPI32_MASK;
                case "_MM_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM_MASK_CMPLE_EPI32_MASK;
                case "_MM256_CMPLE_EPI32_MASK": return Intrinsic._MM256_CMPLE_EPI32_MASK;
                case "_MM256_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI32_MASK;
                case "_MM512_CMPLE_EPI32_MASK": return Intrinsic._MM512_CMPLE_EPI32_MASK;
                case "_MM512_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI32_MASK;
                case "_MM_CMPLE_EPI64_MASK": return Intrinsic._MM_CMPLE_EPI64_MASK;
                case "_MM_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM_MASK_CMPLE_EPI64_MASK;
                case "_MM256_CMPLE_EPI64_MASK": return Intrinsic._MM256_CMPLE_EPI64_MASK;
                case "_MM256_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI64_MASK;
                case "_MM512_CMPLE_EPI64_MASK": return Intrinsic._MM512_CMPLE_EPI64_MASK;
                case "_MM512_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI64_MASK;
                case "_MM_CMPLE_EPI8_MASK": return Intrinsic._MM_CMPLE_EPI8_MASK;
                case "_MM_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM_MASK_CMPLE_EPI8_MASK;
                case "_MM256_CMPLE_EPI8_MASK": return Intrinsic._MM256_CMPLE_EPI8_MASK;
                case "_MM256_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI8_MASK;
                case "_MM512_CMPLE_EPI8_MASK": return Intrinsic._MM512_CMPLE_EPI8_MASK;
                case "_MM512_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI8_MASK;
                case "_MM_CMPLE_EPU16_MASK": return Intrinsic._MM_CMPLE_EPU16_MASK;
                case "_MM_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM_MASK_CMPLE_EPU16_MASK;
                case "_MM256_CMPLE_EPU16_MASK": return Intrinsic._MM256_CMPLE_EPU16_MASK;
                case "_MM256_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU16_MASK;
                case "_MM512_CMPLE_EPU16_MASK": return Intrinsic._MM512_CMPLE_EPU16_MASK;
                case "_MM512_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU16_MASK;
                case "_MM_CMPLE_EPU32_MASK": return Intrinsic._MM_CMPLE_EPU32_MASK;
                case "_MM_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM_MASK_CMPLE_EPU32_MASK;
                case "_MM256_CMPLE_EPU32_MASK": return Intrinsic._MM256_CMPLE_EPU32_MASK;
                case "_MM256_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU32_MASK;
                case "_MM512_CMPLE_EPU32_MASK": return Intrinsic._MM512_CMPLE_EPU32_MASK;
                case "_MM512_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU32_MASK;
                case "_MM_CMPLE_EPU64_MASK": return Intrinsic._MM_CMPLE_EPU64_MASK;
                case "_MM_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM_MASK_CMPLE_EPU64_MASK;
                case "_MM256_CMPLE_EPU64_MASK": return Intrinsic._MM256_CMPLE_EPU64_MASK;
                case "_MM256_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU64_MASK;
                case "_MM512_CMPLE_EPU64_MASK": return Intrinsic._MM512_CMPLE_EPU64_MASK;
                case "_MM512_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU64_MASK;
                case "_MM_CMPLE_EPU8_MASK": return Intrinsic._MM_CMPLE_EPU8_MASK;
                case "_MM_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM_MASK_CMPLE_EPU8_MASK;
                case "_MM256_CMPLE_EPU8_MASK": return Intrinsic._MM256_CMPLE_EPU8_MASK;
                case "_MM256_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU8_MASK;
                case "_MM512_CMPLE_EPU8_MASK": return Intrinsic._MM512_CMPLE_EPU8_MASK;
                case "_MM512_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU8_MASK;
                case "_MM_CMPLE_PD": return Intrinsic._MM_CMPLE_PD;
                case "_MM512_CMPLE_PD_MASK": return Intrinsic._MM512_CMPLE_PD_MASK;
                case "_MM512_MASK_CMPLE_PD_MASK": return Intrinsic._MM512_MASK_CMPLE_PD_MASK;
                case "_MM_CMPLE_PS": return Intrinsic._MM_CMPLE_PS;
                case "_MM512_CMPLE_PS_MASK": return Intrinsic._MM512_CMPLE_PS_MASK;
                case "_MM512_MASK_CMPLE_PS_MASK": return Intrinsic._MM512_MASK_CMPLE_PS_MASK;
                case "_MM_CMPLE_SD": return Intrinsic._MM_CMPLE_SD;
                case "_MM_CMPLE_SS": return Intrinsic._MM_CMPLE_SS;
                case "_MM_CMPLT_EPI16": return Intrinsic._MM_CMPLT_EPI16;
                case "_MM_CMPLT_EPI16_MASK": return Intrinsic._MM_CMPLT_EPI16_MASK;
                case "_MM_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM_MASK_CMPLT_EPI16_MASK;
                case "_MM256_CMPLT_EPI16_MASK": return Intrinsic._MM256_CMPLT_EPI16_MASK;
                case "_MM256_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI16_MASK;
                case "_MM512_CMPLT_EPI16_MASK": return Intrinsic._MM512_CMPLT_EPI16_MASK;
                case "_MM512_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI16_MASK;
                case "_MM_CMPLT_EPI32": return Intrinsic._MM_CMPLT_EPI32;
                case "_MM_CMPLT_EPI32_MASK": return Intrinsic._MM_CMPLT_EPI32_MASK;
                case "_MM_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM_MASK_CMPLT_EPI32_MASK;
                case "_MM256_CMPLT_EPI32_MASK": return Intrinsic._MM256_CMPLT_EPI32_MASK;
                case "_MM256_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI32_MASK;
                case "_MM512_CMPLT_EPI32_MASK": return Intrinsic._MM512_CMPLT_EPI32_MASK;
                //case "_MM512_CMPLT_EPI32_MASK": return Intrinsic._MM512_CMPLT_EPI32_MASK;
                case "_MM512_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI32_MASK;
                //case "_MM512_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI32_MASK;
                case "_MM_CMPLT_EPI64_MASK": return Intrinsic._MM_CMPLT_EPI64_MASK;
                case "_MM_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM_MASK_CMPLT_EPI64_MASK;
                case "_MM256_CMPLT_EPI64_MASK": return Intrinsic._MM256_CMPLT_EPI64_MASK;
                case "_MM256_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI64_MASK;
                case "_MM512_CMPLT_EPI64_MASK": return Intrinsic._MM512_CMPLT_EPI64_MASK;
                case "_MM512_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI64_MASK;
                case "_MM_CMPLT_EPI8": return Intrinsic._MM_CMPLT_EPI8;
                case "_MM_CMPLT_EPI8_MASK": return Intrinsic._MM_CMPLT_EPI8_MASK;
                case "_MM_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM_MASK_CMPLT_EPI8_MASK;
                case "_MM256_CMPLT_EPI8_MASK": return Intrinsic._MM256_CMPLT_EPI8_MASK;
                case "_MM256_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI8_MASK;
                case "_MM512_CMPLT_EPI8_MASK": return Intrinsic._MM512_CMPLT_EPI8_MASK;
                case "_MM512_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI8_MASK;
                case "_MM_CMPLT_EPU16_MASK": return Intrinsic._MM_CMPLT_EPU16_MASK;
                case "_MM_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM_MASK_CMPLT_EPU16_MASK;
                case "_MM256_CMPLT_EPU16_MASK": return Intrinsic._MM256_CMPLT_EPU16_MASK;
                case "_MM256_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU16_MASK;
                case "_MM512_CMPLT_EPU16_MASK": return Intrinsic._MM512_CMPLT_EPU16_MASK;
                case "_MM512_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU16_MASK;
                case "_MM_CMPLT_EPU32_MASK": return Intrinsic._MM_CMPLT_EPU32_MASK;
                case "_MM_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM_MASK_CMPLT_EPU32_MASK;
                case "_MM256_CMPLT_EPU32_MASK": return Intrinsic._MM256_CMPLT_EPU32_MASK;
                case "_MM256_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU32_MASK;
                case "_MM512_CMPLT_EPU32_MASK": return Intrinsic._MM512_CMPLT_EPU32_MASK;
                case "_MM512_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU32_MASK;
                case "_MM_CMPLT_EPU64_MASK": return Intrinsic._MM_CMPLT_EPU64_MASK;
                case "_MM_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM_MASK_CMPLT_EPU64_MASK;
                case "_MM256_CMPLT_EPU64_MASK": return Intrinsic._MM256_CMPLT_EPU64_MASK;
                case "_MM256_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU64_MASK;
                case "_MM512_CMPLT_EPU64_MASK": return Intrinsic._MM512_CMPLT_EPU64_MASK;
                case "_MM512_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU64_MASK;
                case "_MM_CMPLT_EPU8_MASK": return Intrinsic._MM_CMPLT_EPU8_MASK;
                case "_MM_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM_MASK_CMPLT_EPU8_MASK;
                case "_MM256_CMPLT_EPU8_MASK": return Intrinsic._MM256_CMPLT_EPU8_MASK;
                case "_MM256_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU8_MASK;
                case "_MM512_CMPLT_EPU8_MASK": return Intrinsic._MM512_CMPLT_EPU8_MASK;
                case "_MM512_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU8_MASK;
                case "_MM_CMPLT_PD": return Intrinsic._MM_CMPLT_PD;
                case "_MM512_CMPLT_PD_MASK": return Intrinsic._MM512_CMPLT_PD_MASK;
                case "_MM512_MASK_CMPLT_PD_MASK": return Intrinsic._MM512_MASK_CMPLT_PD_MASK;
                case "_MM_CMPLT_PS": return Intrinsic._MM_CMPLT_PS;
                case "_MM512_CMPLT_PS_MASK": return Intrinsic._MM512_CMPLT_PS_MASK;
                case "_MM512_MASK_CMPLT_PS_MASK": return Intrinsic._MM512_MASK_CMPLT_PS_MASK;
                case "_MM_CMPLT_SD": return Intrinsic._MM_CMPLT_SD;
                case "_MM_CMPLT_SS": return Intrinsic._MM_CMPLT_SS;
                case "_MM_CMPNEQ_EPI16_MASK": return Intrinsic._MM_CMPNEQ_EPI16_MASK;
                case "_MM_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI16_MASK;
                case "_MM256_CMPNEQ_EPI16_MASK": return Intrinsic._MM256_CMPNEQ_EPI16_MASK;
                case "_MM256_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI16_MASK;
                case "_MM512_CMPNEQ_EPI16_MASK": return Intrinsic._MM512_CMPNEQ_EPI16_MASK;
                case "_MM512_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI16_MASK;
                case "_MM_CMPNEQ_EPI32_MASK": return Intrinsic._MM_CMPNEQ_EPI32_MASK;
                case "_MM_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI32_MASK;
                case "_MM256_CMPNEQ_EPI32_MASK": return Intrinsic._MM256_CMPNEQ_EPI32_MASK;
                case "_MM256_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI32_MASK;
                case "_MM512_CMPNEQ_EPI32_MASK": return Intrinsic._MM512_CMPNEQ_EPI32_MASK;
                case "_MM512_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI32_MASK;
                case "_MM_CMPNEQ_EPI64_MASK": return Intrinsic._MM_CMPNEQ_EPI64_MASK;
                case "_MM_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI64_MASK;
                case "_MM256_CMPNEQ_EPI64_MASK": return Intrinsic._MM256_CMPNEQ_EPI64_MASK;
                case "_MM256_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI64_MASK;
                case "_MM512_CMPNEQ_EPI64_MASK": return Intrinsic._MM512_CMPNEQ_EPI64_MASK;
                case "_MM512_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI64_MASK;
                case "_MM_CMPNEQ_EPI8_MASK": return Intrinsic._MM_CMPNEQ_EPI8_MASK;
                case "_MM_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI8_MASK;
                case "_MM256_CMPNEQ_EPI8_MASK": return Intrinsic._MM256_CMPNEQ_EPI8_MASK;
                case "_MM256_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI8_MASK;
                case "_MM512_CMPNEQ_EPI8_MASK": return Intrinsic._MM512_CMPNEQ_EPI8_MASK;
                case "_MM512_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI8_MASK;
                case "_MM_CMPNEQ_EPU16_MASK": return Intrinsic._MM_CMPNEQ_EPU16_MASK;
                case "_MM_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU16_MASK;
                case "_MM256_CMPNEQ_EPU16_MASK": return Intrinsic._MM256_CMPNEQ_EPU16_MASK;
                case "_MM256_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU16_MASK;
                case "_MM512_CMPNEQ_EPU16_MASK": return Intrinsic._MM512_CMPNEQ_EPU16_MASK;
                case "_MM512_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU16_MASK;
                case "_MM_CMPNEQ_EPU32_MASK": return Intrinsic._MM_CMPNEQ_EPU32_MASK;
                case "_MM_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU32_MASK;
                case "_MM256_CMPNEQ_EPU32_MASK": return Intrinsic._MM256_CMPNEQ_EPU32_MASK;
                case "_MM256_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU32_MASK;
                case "_MM512_CMPNEQ_EPU32_MASK": return Intrinsic._MM512_CMPNEQ_EPU32_MASK;
                case "_MM512_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU32_MASK;
                case "_MM_CMPNEQ_EPU64_MASK": return Intrinsic._MM_CMPNEQ_EPU64_MASK;
                case "_MM_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU64_MASK;
                case "_MM256_CMPNEQ_EPU64_MASK": return Intrinsic._MM256_CMPNEQ_EPU64_MASK;
                case "_MM256_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU64_MASK;
                case "_MM512_CMPNEQ_EPU64_MASK": return Intrinsic._MM512_CMPNEQ_EPU64_MASK;
                case "_MM512_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU64_MASK;
                case "_MM_CMPNEQ_EPU8_MASK": return Intrinsic._MM_CMPNEQ_EPU8_MASK;
                case "_MM_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU8_MASK;
                case "_MM256_CMPNEQ_EPU8_MASK": return Intrinsic._MM256_CMPNEQ_EPU8_MASK;
                case "_MM256_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU8_MASK;
                case "_MM512_CMPNEQ_EPU8_MASK": return Intrinsic._MM512_CMPNEQ_EPU8_MASK;
                case "_MM512_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU8_MASK;
                case "_MM_CMPNEQ_PD": return Intrinsic._MM_CMPNEQ_PD;
                case "_MM512_CMPNEQ_PD_MASK": return Intrinsic._MM512_CMPNEQ_PD_MASK;
                case "_MM512_MASK_CMPNEQ_PD_MASK": return Intrinsic._MM512_MASK_CMPNEQ_PD_MASK;
                case "_MM_CMPNEQ_PS": return Intrinsic._MM_CMPNEQ_PS;
                case "_MM512_CMPNEQ_PS_MASK": return Intrinsic._MM512_CMPNEQ_PS_MASK;
                case "_MM512_MASK_CMPNEQ_PS_MASK": return Intrinsic._MM512_MASK_CMPNEQ_PS_MASK;
                case "_MM_CMPNEQ_SD": return Intrinsic._MM_CMPNEQ_SD;
                case "_MM_CMPNEQ_SS": return Intrinsic._MM_CMPNEQ_SS;
                case "_MM_CMPNGE_PD": return Intrinsic._MM_CMPNGE_PD;
                case "_MM_CMPNGE_PS": return Intrinsic._MM_CMPNGE_PS;
                case "_MM_CMPNGE_SD": return Intrinsic._MM_CMPNGE_SD;
                case "_MM_CMPNGE_SS": return Intrinsic._MM_CMPNGE_SS;
                case "_MM_CMPNGT_PD": return Intrinsic._MM_CMPNGT_PD;
                case "_MM_CMPNGT_PS": return Intrinsic._MM_CMPNGT_PS;
                case "_MM_CMPNGT_SD": return Intrinsic._MM_CMPNGT_SD;
                case "_MM_CMPNGT_SS": return Intrinsic._MM_CMPNGT_SS;
                case "_MM_CMPNLE_PD": return Intrinsic._MM_CMPNLE_PD;
                case "_MM512_CMPNLE_PD_MASK": return Intrinsic._MM512_CMPNLE_PD_MASK;
                case "_MM512_MASK_CMPNLE_PD_MASK": return Intrinsic._MM512_MASK_CMPNLE_PD_MASK;
                case "_MM_CMPNLE_PS": return Intrinsic._MM_CMPNLE_PS;
                case "_MM512_CMPNLE_PS_MASK": return Intrinsic._MM512_CMPNLE_PS_MASK;
                case "_MM512_MASK_CMPNLE_PS_MASK": return Intrinsic._MM512_MASK_CMPNLE_PS_MASK;
                case "_MM_CMPNLE_SD": return Intrinsic._MM_CMPNLE_SD;
                case "_MM_CMPNLE_SS": return Intrinsic._MM_CMPNLE_SS;
                case "_MM_CMPNLT_PD": return Intrinsic._MM_CMPNLT_PD;
                case "_MM512_CMPNLT_PD_MASK": return Intrinsic._MM512_CMPNLT_PD_MASK;
                case "_MM512_MASK_CMPNLT_PD_MASK": return Intrinsic._MM512_MASK_CMPNLT_PD_MASK;
                case "_MM_CMPNLT_PS": return Intrinsic._MM_CMPNLT_PS;
                case "_MM512_CMPNLT_PS_MASK": return Intrinsic._MM512_CMPNLT_PS_MASK;
                case "_MM512_MASK_CMPNLT_PS_MASK": return Intrinsic._MM512_MASK_CMPNLT_PS_MASK;
                case "_MM_CMPNLT_SD": return Intrinsic._MM_CMPNLT_SD;
                case "_MM_CMPNLT_SS": return Intrinsic._MM_CMPNLT_SS;
                case "_MM_CMPORD_PD": return Intrinsic._MM_CMPORD_PD;
                case "_MM512_CMPORD_PD_MASK": return Intrinsic._MM512_CMPORD_PD_MASK;
                case "_MM512_MASK_CMPORD_PD_MASK": return Intrinsic._MM512_MASK_CMPORD_PD_MASK;
                case "_MM_CMPORD_PS": return Intrinsic._MM_CMPORD_PS;
                case "_MM512_CMPORD_PS_MASK": return Intrinsic._MM512_CMPORD_PS_MASK;
                case "_MM512_MASK_CMPORD_PS_MASK": return Intrinsic._MM512_MASK_CMPORD_PS_MASK;
                case "_MM_CMPORD_SD": return Intrinsic._MM_CMPORD_SD;
                case "_MM_CMPORD_SS": return Intrinsic._MM_CMPORD_SS;
                case "_MM_CMPUNORD_PD": return Intrinsic._MM_CMPUNORD_PD;
                case "_MM512_CMPUNORD_PD_MASK": return Intrinsic._MM512_CMPUNORD_PD_MASK;
                case "_MM512_MASK_CMPUNORD_PD_MASK": return Intrinsic._MM512_MASK_CMPUNORD_PD_MASK;
                case "_MM_CMPUNORD_PS": return Intrinsic._MM_CMPUNORD_PS;
                case "_MM512_CMPUNORD_PS_MASK": return Intrinsic._MM512_CMPUNORD_PS_MASK;
                case "_MM512_MASK_CMPUNORD_PS_MASK": return Intrinsic._MM512_MASK_CMPUNORD_PS_MASK;
                case "_MM_CMPUNORD_SD": return Intrinsic._MM_CMPUNORD_SD;
                case "_MM_CMPUNORD_SS": return Intrinsic._MM_CMPUNORD_SS;
                case "_MM_COMI_ROUND_SD": return Intrinsic._MM_COMI_ROUND_SD;
                case "_MM_COMI_ROUND_SS": return Intrinsic._MM_COMI_ROUND_SS;
                case "_MM_COMIEQ_SD": return Intrinsic._MM_COMIEQ_SD;
                case "_MM_COMIEQ_SS": return Intrinsic._MM_COMIEQ_SS;
                case "_MM_COMIGE_SD": return Intrinsic._MM_COMIGE_SD;
                case "_MM_COMIGE_SS": return Intrinsic._MM_COMIGE_SS;
                case "_MM_COMIGT_SD": return Intrinsic._MM_COMIGT_SD;
                case "_MM_COMIGT_SS": return Intrinsic._MM_COMIGT_SS;
                case "_MM_COMILE_SD": return Intrinsic._MM_COMILE_SD;
                case "_MM_COMILE_SS": return Intrinsic._MM_COMILE_SS;
                case "_MM_COMILT_SD": return Intrinsic._MM_COMILT_SD;
                case "_MM_COMILT_SS": return Intrinsic._MM_COMILT_SS;
                case "_MM_COMINEQ_SD": return Intrinsic._MM_COMINEQ_SD;
                case "_MM_COMINEQ_SS": return Intrinsic._MM_COMINEQ_SS;
                case "_MM_MASK_COMPRESS_EPI32": return Intrinsic._MM_MASK_COMPRESS_EPI32;
                case "_MM_MASKZ_COMPRESS_EPI32": return Intrinsic._MM_MASKZ_COMPRESS_EPI32;
                case "_MM256_MASK_COMPRESS_EPI32": return Intrinsic._MM256_MASK_COMPRESS_EPI32;
                case "_MM256_MASKZ_COMPRESS_EPI32": return Intrinsic._MM256_MASKZ_COMPRESS_EPI32;
                case "_MM512_MASK_COMPRESS_EPI32": return Intrinsic._MM512_MASK_COMPRESS_EPI32;
                case "_MM512_MASKZ_COMPRESS_EPI32": return Intrinsic._MM512_MASKZ_COMPRESS_EPI32;
                case "_MM_MASK_COMPRESS_EPI64": return Intrinsic._MM_MASK_COMPRESS_EPI64;
                case "_MM_MASKZ_COMPRESS_EPI64": return Intrinsic._MM_MASKZ_COMPRESS_EPI64;
                case "_MM256_MASK_COMPRESS_EPI64": return Intrinsic._MM256_MASK_COMPRESS_EPI64;
                case "_MM256_MASKZ_COMPRESS_EPI64": return Intrinsic._MM256_MASKZ_COMPRESS_EPI64;
                case "_MM512_MASK_COMPRESS_EPI64": return Intrinsic._MM512_MASK_COMPRESS_EPI64;
                case "_MM512_MASKZ_COMPRESS_EPI64": return Intrinsic._MM512_MASKZ_COMPRESS_EPI64;
                case "_MM_MASK_COMPRESS_PD": return Intrinsic._MM_MASK_COMPRESS_PD;
                case "_MM_MASKZ_COMPRESS_PD": return Intrinsic._MM_MASKZ_COMPRESS_PD;
                case "_MM256_MASK_COMPRESS_PD": return Intrinsic._MM256_MASK_COMPRESS_PD;
                case "_MM256_MASKZ_COMPRESS_PD": return Intrinsic._MM256_MASKZ_COMPRESS_PD;
                case "_MM512_MASK_COMPRESS_PD": return Intrinsic._MM512_MASK_COMPRESS_PD;
                case "_MM512_MASKZ_COMPRESS_PD": return Intrinsic._MM512_MASKZ_COMPRESS_PD;
                case "_MM_MASK_COMPRESS_PS": return Intrinsic._MM_MASK_COMPRESS_PS;
                case "_MM_MASKZ_COMPRESS_PS": return Intrinsic._MM_MASKZ_COMPRESS_PS;
                case "_MM256_MASK_COMPRESS_PS": return Intrinsic._MM256_MASK_COMPRESS_PS;
                case "_MM256_MASKZ_COMPRESS_PS": return Intrinsic._MM256_MASKZ_COMPRESS_PS;
                case "_MM512_MASK_COMPRESS_PS": return Intrinsic._MM512_MASK_COMPRESS_PS;
                case "_MM512_MASKZ_COMPRESS_PS": return Intrinsic._MM512_MASKZ_COMPRESS_PS;
                case "_MM_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM_MASK_COMPRESSSTOREU_EPI32;
                case "_MM256_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM256_MASK_COMPRESSSTOREU_EPI32;
                case "_MM512_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM512_MASK_COMPRESSSTOREU_EPI32;
                case "_MM_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM_MASK_COMPRESSSTOREU_EPI64;
                case "_MM256_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM256_MASK_COMPRESSSTOREU_EPI64;
                case "_MM512_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM512_MASK_COMPRESSSTOREU_EPI64;
                case "_MM_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM_MASK_COMPRESSSTOREU_PD;
                case "_MM256_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM256_MASK_COMPRESSSTOREU_PD;
                case "_MM512_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM512_MASK_COMPRESSSTOREU_PD;
                case "_MM_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM_MASK_COMPRESSSTOREU_PS;
                case "_MM256_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM256_MASK_COMPRESSSTOREU_PS;
                case "_MM512_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM512_MASK_COMPRESSSTOREU_PS;
                case "_MM_CONFLICT_EPI32": return Intrinsic._MM_CONFLICT_EPI32;
                case "_MM_MASK_CONFLICT_EPI32": return Intrinsic._MM_MASK_CONFLICT_EPI32;
                case "_MM_MASKZ_CONFLICT_EPI32": return Intrinsic._MM_MASKZ_CONFLICT_EPI32;
                case "_MM256_CONFLICT_EPI32": return Intrinsic._MM256_CONFLICT_EPI32;
                case "_MM256_MASK_CONFLICT_EPI32": return Intrinsic._MM256_MASK_CONFLICT_EPI32;
                case "_MM256_MASKZ_CONFLICT_EPI32": return Intrinsic._MM256_MASKZ_CONFLICT_EPI32;
                case "_MM512_CONFLICT_EPI32": return Intrinsic._MM512_CONFLICT_EPI32;
                case "_MM512_MASK_CONFLICT_EPI32": return Intrinsic._MM512_MASK_CONFLICT_EPI32;
                case "_MM512_MASKZ_CONFLICT_EPI32": return Intrinsic._MM512_MASKZ_CONFLICT_EPI32;
                case "_MM_CONFLICT_EPI64": return Intrinsic._MM_CONFLICT_EPI64;
                case "_MM_MASK_CONFLICT_EPI64": return Intrinsic._MM_MASK_CONFLICT_EPI64;
                case "_MM_MASKZ_CONFLICT_EPI64": return Intrinsic._MM_MASKZ_CONFLICT_EPI64;
                case "_MM256_CONFLICT_EPI64": return Intrinsic._MM256_CONFLICT_EPI64;
                case "_MM256_MASK_CONFLICT_EPI64": return Intrinsic._MM256_MASK_CONFLICT_EPI64;
                case "_MM256_MASKZ_CONFLICT_EPI64": return Intrinsic._MM256_MASKZ_CONFLICT_EPI64;
                case "_MM512_CONFLICT_EPI64": return Intrinsic._MM512_CONFLICT_EPI64;
                case "_MM512_MASK_CONFLICT_EPI64": return Intrinsic._MM512_MASK_CONFLICT_EPI64;
                case "_MM512_MASKZ_CONFLICT_EPI64": return Intrinsic._MM512_MASKZ_CONFLICT_EPI64;
                case "_MM_COS_PD": return Intrinsic._MM_COS_PD;
                case "_MM256_COS_PD": return Intrinsic._MM256_COS_PD;
                case "_MM512_COS_PD": return Intrinsic._MM512_COS_PD;
                case "_MM512_MASK_COS_PD": return Intrinsic._MM512_MASK_COS_PD;
                case "_MM_COS_PS": return Intrinsic._MM_COS_PS;
                case "_MM256_COS_PS": return Intrinsic._MM256_COS_PS;
                case "_MM512_COS_PS": return Intrinsic._MM512_COS_PS;
                case "_MM512_MASK_COS_PS": return Intrinsic._MM512_MASK_COS_PS;
                case "_MM_COSD_PD": return Intrinsic._MM_COSD_PD;
                case "_MM256_COSD_PD": return Intrinsic._MM256_COSD_PD;
                case "_MM512_COSD_PD": return Intrinsic._MM512_COSD_PD;
                case "_MM512_MASK_COSD_PD": return Intrinsic._MM512_MASK_COSD_PD;
                case "_MM_COSD_PS": return Intrinsic._MM_COSD_PS;
                case "_MM256_COSD_PS": return Intrinsic._MM256_COSD_PS;
                case "_MM512_COSD_PS": return Intrinsic._MM512_COSD_PS;
                case "_MM512_MASK_COSD_PS": return Intrinsic._MM512_MASK_COSD_PS;
                case "_MM_COSH_PD": return Intrinsic._MM_COSH_PD;
                case "_MM256_COSH_PD": return Intrinsic._MM256_COSH_PD;
                case "_MM512_COSH_PD": return Intrinsic._MM512_COSH_PD;
                case "_MM512_MASK_COSH_PD": return Intrinsic._MM512_MASK_COSH_PD;
                case "_MM_COSH_PS": return Intrinsic._MM_COSH_PS;
                case "_MM256_COSH_PS": return Intrinsic._MM256_COSH_PS;
                case "_MM512_COSH_PS": return Intrinsic._MM512_COSH_PS;
                case "_MM512_MASK_COSH_PS": return Intrinsic._MM512_MASK_COSH_PS;
                case "_MM_COUNTBITS_32": return Intrinsic._MM_COUNTBITS_32;
                case "_MM_COUNTBITS_64": return Intrinsic._MM_COUNTBITS_64;
                case "_MM_CRC32_U16": return Intrinsic._MM_CRC32_U16;
                case "_MM_CRC32_U32": return Intrinsic._MM_CRC32_U32;
                case "_MM_CRC32_U64": return Intrinsic._MM_CRC32_U64;
                case "_MM_CRC32_U8": return Intrinsic._MM_CRC32_U8;
                case "_MM_CSQRT_PS": return Intrinsic._MM_CSQRT_PS;
                case "_MM256_CSQRT_PS": return Intrinsic._MM256_CSQRT_PS;
                case "_MM_CVT_PI2PS": return Intrinsic._MM_CVT_PI2PS;
                case "_MM_CVT_PS2PI": return Intrinsic._MM_CVT_PS2PI;
                case "_MM512_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_CVT_ROUNDEPI32_PS;
                case "_MM512_MASK_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPI32_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI32_PS;
                case "_MM512_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_CVT_ROUNDEPI64_PD;
                case "_MM512_MASK_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_MASK_CVT_ROUNDEPI64_PD;
                case "_MM512_MASKZ_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI64_PD;
                case "_MM512_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_CVT_ROUNDEPI64_PS;
                case "_MM512_MASK_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPI64_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI64_PS;
                case "_MM512_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_CVT_ROUNDEPU32_PS;
                case "_MM512_MASK_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPU32_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU32_PS;
                case "_MM512_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_CVT_ROUNDEPU64_PD;
                case "_MM512_MASK_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_MASK_CVT_ROUNDEPU64_PD;
                case "_MM512_MASKZ_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU64_PD;
                case "_MM512_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_CVT_ROUNDEPU64_PS;
                case "_MM512_MASK_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPU64_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU64_PS;
                case "_MM_CVT_ROUNDI32_SS": return Intrinsic._MM_CVT_ROUNDI32_SS;
                case "_MM_CVT_ROUNDI64_SD": return Intrinsic._MM_CVT_ROUNDI64_SD;
                case "_MM_CVT_ROUNDI64_SS": return Intrinsic._MM_CVT_ROUNDI64_SS;
                case "_MM512_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_CVT_ROUNDPD_EPI32;
                case "_MM512_MASK_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPI32;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPI32;
                case "_MM512_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_CVT_ROUNDPD_EPI64;
                case "_MM512_MASK_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPI64;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPI64;
                case "_MM512_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_CVT_ROUNDPD_EPU32;
                case "_MM512_MASK_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPU32;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPU32;
                case "_MM512_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_CVT_ROUNDPD_EPU64;
                case "_MM512_MASK_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPU64;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPU64;
                case "_MM512_CVT_ROUNDPD_PS": return Intrinsic._MM512_CVT_ROUNDPD_PS;
                case "_MM512_MASK_CVT_ROUNDPD_PS": return Intrinsic._MM512_MASK_CVT_ROUNDPD_PS;
                case "_MM512_MASKZ_CVT_ROUNDPD_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_PS;
                case "_MM512_CVT_ROUNDPD_PSLO": return Intrinsic._MM512_CVT_ROUNDPD_PSLO;
                case "_MM512_MASK_CVT_ROUNDPD_PSLO": return Intrinsic._MM512_MASK_CVT_ROUNDPD_PSLO;
                case "_MM512_CVT_ROUNDPH_PS": return Intrinsic._MM512_CVT_ROUNDPH_PS;
                case "_MM512_MASK_CVT_ROUNDPH_PS": return Intrinsic._MM512_MASK_CVT_ROUNDPH_PS;
                case "_MM512_MASKZ_CVT_ROUNDPH_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDPH_PS;
                case "_MM512_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_CVT_ROUNDPS_EPI32;
                case "_MM512_MASK_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPI32;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPI32;
                case "_MM512_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_CVT_ROUNDPS_EPI64;
                case "_MM512_MASK_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPI64;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPI64;
                case "_MM512_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_CVT_ROUNDPS_EPU32;
                case "_MM512_MASK_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPU32;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPU32;
                case "_MM512_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_CVT_ROUNDPS_EPU64;
                case "_MM512_MASK_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPU64;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPU64;
                case "_MM512_CVT_ROUNDPS_PD": return Intrinsic._MM512_CVT_ROUNDPS_PD;
                case "_MM512_MASK_CVT_ROUNDPS_PD": return Intrinsic._MM512_MASK_CVT_ROUNDPS_PD;
                case "_MM512_MASKZ_CVT_ROUNDPS_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_PD;
                case "_MM_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM_MASK_CVT_ROUNDPS_PH;
                case "_MM_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM_MASKZ_CVT_ROUNDPS_PH;
                case "_MM256_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM256_MASK_CVT_ROUNDPS_PH;
                case "_MM256_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM256_MASKZ_CVT_ROUNDPS_PH;
                case "_MM512_CVT_ROUNDPS_PH": return Intrinsic._MM512_CVT_ROUNDPS_PH;
                case "_MM512_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM512_MASK_CVT_ROUNDPS_PH;
                case "_MM512_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_PH;
                case "_MM_CVT_ROUNDSD_I32": return Intrinsic._MM_CVT_ROUNDSD_I32;
                case "_MM_CVT_ROUNDSD_I64": return Intrinsic._MM_CVT_ROUNDSD_I64;
                case "_MM_CVT_ROUNDSD_SI32": return Intrinsic._MM_CVT_ROUNDSD_SI32;
                case "_MM_CVT_ROUNDSD_SI64": return Intrinsic._MM_CVT_ROUNDSD_SI64;
                case "_MM_CVT_ROUNDSD_SS": return Intrinsic._MM_CVT_ROUNDSD_SS;
                case "_MM_MASK_CVT_ROUNDSD_SS": return Intrinsic._MM_MASK_CVT_ROUNDSD_SS;
                case "_MM_MASKZ_CVT_ROUNDSD_SS": return Intrinsic._MM_MASKZ_CVT_ROUNDSD_SS;
                case "_MM_CVT_ROUNDSD_U32": return Intrinsic._MM_CVT_ROUNDSD_U32;
                case "_MM_CVT_ROUNDSD_U64": return Intrinsic._MM_CVT_ROUNDSD_U64;
                case "_MM_CVT_ROUNDSI32_SS": return Intrinsic._MM_CVT_ROUNDSI32_SS;
                case "_MM_CVT_ROUNDSI64_SD": return Intrinsic._MM_CVT_ROUNDSI64_SD;
                case "_MM_CVT_ROUNDSI64_SS": return Intrinsic._MM_CVT_ROUNDSI64_SS;
                case "_MM_CVT_ROUNDSS_I32": return Intrinsic._MM_CVT_ROUNDSS_I32;
                case "_MM_CVT_ROUNDSS_I64": return Intrinsic._MM_CVT_ROUNDSS_I64;
                case "_MM_CVT_ROUNDSS_SD": return Intrinsic._MM_CVT_ROUNDSS_SD;
                case "_MM_MASK_CVT_ROUNDSS_SD": return Intrinsic._MM_MASK_CVT_ROUNDSS_SD;
                case "_MM_MASKZ_CVT_ROUNDSS_SD": return Intrinsic._MM_MASKZ_CVT_ROUNDSS_SD;
                case "_MM_CVT_ROUNDSS_SI32": return Intrinsic._MM_CVT_ROUNDSS_SI32;
                case "_MM_CVT_ROUNDSS_SI64": return Intrinsic._MM_CVT_ROUNDSS_SI64;
                case "_MM_CVT_ROUNDSS_U32": return Intrinsic._MM_CVT_ROUNDSS_U32;
                case "_MM_CVT_ROUNDSS_U64": return Intrinsic._MM_CVT_ROUNDSS_U64;
                case "_MM_CVT_ROUNDU32_SS": return Intrinsic._MM_CVT_ROUNDU32_SS;
                case "_MM_CVT_ROUNDU64_SD": return Intrinsic._MM_CVT_ROUNDU64_SD;
                case "_MM_CVT_ROUNDU64_SS": return Intrinsic._MM_CVT_ROUNDU64_SS;
                case "_MM_CVT_SI2SS": return Intrinsic._MM_CVT_SI2SS;
                case "_MM_CVT_SS2SI": return Intrinsic._MM_CVT_SS2SI;
                case "_MM_CVTEPI16_EPI32": return Intrinsic._MM_CVTEPI16_EPI32;
                case "_MM_MASK_CVTEPI16_EPI32": return Intrinsic._MM_MASK_CVTEPI16_EPI32;
                case "_MM_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM_MASKZ_CVTEPI16_EPI32;
                case "_MM256_CVTEPI16_EPI32": return Intrinsic._MM256_CVTEPI16_EPI32;
                case "_MM256_MASK_CVTEPI16_EPI32": return Intrinsic._MM256_MASK_CVTEPI16_EPI32;
                case "_MM256_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI32;
                case "_MM512_CVTEPI16_EPI32": return Intrinsic._MM512_CVTEPI16_EPI32;
                case "_MM512_MASK_CVTEPI16_EPI32": return Intrinsic._MM512_MASK_CVTEPI16_EPI32;
                case "_MM512_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI32;
                case "_MM_CVTEPI16_EPI64": return Intrinsic._MM_CVTEPI16_EPI64;
                case "_MM_MASK_CVTEPI16_EPI64": return Intrinsic._MM_MASK_CVTEPI16_EPI64;
                case "_MM_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM_MASKZ_CVTEPI16_EPI64;
                case "_MM256_CVTEPI16_EPI64": return Intrinsic._MM256_CVTEPI16_EPI64;
                case "_MM256_MASK_CVTEPI16_EPI64": return Intrinsic._MM256_MASK_CVTEPI16_EPI64;
                case "_MM256_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI64;
                case "_MM512_CVTEPI16_EPI64": return Intrinsic._MM512_CVTEPI16_EPI64;
                case "_MM512_MASK_CVTEPI16_EPI64": return Intrinsic._MM512_MASK_CVTEPI16_EPI64;
                case "_MM512_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI64;
                case "_MM_CVTEPI16_EPI8": return Intrinsic._MM_CVTEPI16_EPI8;
                case "_MM_MASK_CVTEPI16_EPI8": return Intrinsic._MM_MASK_CVTEPI16_EPI8;
                case "_MM_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTEPI16_EPI8;
                case "_MM256_CVTEPI16_EPI8": return Intrinsic._MM256_CVTEPI16_EPI8;
                case "_MM256_MASK_CVTEPI16_EPI8": return Intrinsic._MM256_MASK_CVTEPI16_EPI8;
                case "_MM256_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI8;
                case "_MM512_CVTEPI16_EPI8": return Intrinsic._MM512_CVTEPI16_EPI8;
                case "_MM512_MASK_CVTEPI16_EPI8": return Intrinsic._MM512_MASK_CVTEPI16_EPI8;
                case "_MM512_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI8;
                case "_MM_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM_CVTEPI32_EPI16": return Intrinsic._MM_CVTEPI32_EPI16;
                case "_MM_MASK_CVTEPI32_EPI16": return Intrinsic._MM_MASK_CVTEPI32_EPI16;
                case "_MM_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTEPI32_EPI16;
                case "_MM256_CVTEPI32_EPI16": return Intrinsic._MM256_CVTEPI32_EPI16;
                case "_MM256_MASK_CVTEPI32_EPI16": return Intrinsic._MM256_MASK_CVTEPI32_EPI16;
                case "_MM256_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI16;
                case "_MM512_CVTEPI32_EPI16": return Intrinsic._MM512_CVTEPI32_EPI16;
                case "_MM512_MASK_CVTEPI32_EPI16": return Intrinsic._MM512_MASK_CVTEPI32_EPI16;
                case "_MM512_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI16;
                case "_MM_CVTEPI32_EPI64": return Intrinsic._MM_CVTEPI32_EPI64;
                case "_MM_MASK_CVTEPI32_EPI64": return Intrinsic._MM_MASK_CVTEPI32_EPI64;
                case "_MM_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM_MASKZ_CVTEPI32_EPI64;
                case "_MM256_CVTEPI32_EPI64": return Intrinsic._MM256_CVTEPI32_EPI64;
                case "_MM256_MASK_CVTEPI32_EPI64": return Intrinsic._MM256_MASK_CVTEPI32_EPI64;
                case "_MM256_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI64;
                case "_MM512_CVTEPI32_EPI64": return Intrinsic._MM512_CVTEPI32_EPI64;
                case "_MM512_MASK_CVTEPI32_EPI64": return Intrinsic._MM512_MASK_CVTEPI32_EPI64;
                case "_MM512_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI64;
                case "_MM_CVTEPI32_EPI8": return Intrinsic._MM_CVTEPI32_EPI8;
                case "_MM_MASK_CVTEPI32_EPI8": return Intrinsic._MM_MASK_CVTEPI32_EPI8;
                case "_MM_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTEPI32_EPI8;
                case "_MM256_CVTEPI32_EPI8": return Intrinsic._MM256_CVTEPI32_EPI8;
                case "_MM256_MASK_CVTEPI32_EPI8": return Intrinsic._MM256_MASK_CVTEPI32_EPI8;
                case "_MM256_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI8;
                case "_MM512_CVTEPI32_EPI8": return Intrinsic._MM512_CVTEPI32_EPI8;
                case "_MM512_MASK_CVTEPI32_EPI8": return Intrinsic._MM512_MASK_CVTEPI32_EPI8;
                case "_MM512_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI8;
                case "_MM_CVTEPI32_PD": return Intrinsic._MM_CVTEPI32_PD;
                case "_MM_MASK_CVTEPI32_PD": return Intrinsic._MM_MASK_CVTEPI32_PD;
                case "_MM_MASKZ_CVTEPI32_PD": return Intrinsic._MM_MASKZ_CVTEPI32_PD;
                case "_MM256_CVTEPI32_PD": return Intrinsic._MM256_CVTEPI32_PD;
                case "_MM256_MASK_CVTEPI32_PD": return Intrinsic._MM256_MASK_CVTEPI32_PD;
                case "_MM256_MASKZ_CVTEPI32_PD": return Intrinsic._MM256_MASKZ_CVTEPI32_PD;
                case "_MM512_CVTEPI32_PD": return Intrinsic._MM512_CVTEPI32_PD;
                case "_MM512_MASK_CVTEPI32_PD": return Intrinsic._MM512_MASK_CVTEPI32_PD;
                case "_MM512_MASKZ_CVTEPI32_PD": return Intrinsic._MM512_MASKZ_CVTEPI32_PD;
                case "_MM_CVTEPI32_PS": return Intrinsic._MM_CVTEPI32_PS;
                case "_MM_MASK_CVTEPI32_PS": return Intrinsic._MM_MASK_CVTEPI32_PS;
                case "_MM_MASKZ_CVTEPI32_PS": return Intrinsic._MM_MASKZ_CVTEPI32_PS;
                case "_MM256_CVTEPI32_PS": return Intrinsic._MM256_CVTEPI32_PS;
                case "_MM256_MASK_CVTEPI32_PS": return Intrinsic._MM256_MASK_CVTEPI32_PS;
                case "_MM256_MASKZ_CVTEPI32_PS": return Intrinsic._MM256_MASKZ_CVTEPI32_PS;
                case "_MM512_CVTEPI32_PS": return Intrinsic._MM512_CVTEPI32_PS;
                case "_MM512_MASK_CVTEPI32_PS": return Intrinsic._MM512_MASK_CVTEPI32_PS;
                case "_MM512_MASKZ_CVTEPI32_PS": return Intrinsic._MM512_MASKZ_CVTEPI32_PS;
                case "_MM_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM512_CVTEPI32LO_PD": return Intrinsic._MM512_CVTEPI32LO_PD;
                case "_MM512_MASK_CVTEPI32LO_PD": return Intrinsic._MM512_MASK_CVTEPI32LO_PD;
                case "_MM_CVTEPI64_EPI16": return Intrinsic._MM_CVTEPI64_EPI16;
                case "_MM_MASK_CVTEPI64_EPI16": return Intrinsic._MM_MASK_CVTEPI64_EPI16;
                case "_MM_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTEPI64_EPI16;
                case "_MM256_CVTEPI64_EPI16": return Intrinsic._MM256_CVTEPI64_EPI16;
                case "_MM256_MASK_CVTEPI64_EPI16": return Intrinsic._MM256_MASK_CVTEPI64_EPI16;
                case "_MM256_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI16;
                case "_MM512_CVTEPI64_EPI16": return Intrinsic._MM512_CVTEPI64_EPI16;
                case "_MM512_MASK_CVTEPI64_EPI16": return Intrinsic._MM512_MASK_CVTEPI64_EPI16;
                case "_MM512_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI16;
                case "_MM_CVTEPI64_EPI32": return Intrinsic._MM_CVTEPI64_EPI32;
                case "_MM_MASK_CVTEPI64_EPI32": return Intrinsic._MM_MASK_CVTEPI64_EPI32;
                case "_MM_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTEPI64_EPI32;
                case "_MM256_CVTEPI64_EPI32": return Intrinsic._MM256_CVTEPI64_EPI32;
                case "_MM256_MASK_CVTEPI64_EPI32": return Intrinsic._MM256_MASK_CVTEPI64_EPI32;
                case "_MM256_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI32;
                case "_MM512_CVTEPI64_EPI32": return Intrinsic._MM512_CVTEPI64_EPI32;
                case "_MM512_MASK_CVTEPI64_EPI32": return Intrinsic._MM512_MASK_CVTEPI64_EPI32;
                case "_MM512_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI32;
                case "_MM_CVTEPI64_EPI8": return Intrinsic._MM_CVTEPI64_EPI8;
                case "_MM_MASK_CVTEPI64_EPI8": return Intrinsic._MM_MASK_CVTEPI64_EPI8;
                case "_MM_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTEPI64_EPI8;
                case "_MM256_CVTEPI64_EPI8": return Intrinsic._MM256_CVTEPI64_EPI8;
                case "_MM256_MASK_CVTEPI64_EPI8": return Intrinsic._MM256_MASK_CVTEPI64_EPI8;
                case "_MM256_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI8;
                case "_MM512_CVTEPI64_EPI8": return Intrinsic._MM512_CVTEPI64_EPI8;
                case "_MM512_MASK_CVTEPI64_EPI8": return Intrinsic._MM512_MASK_CVTEPI64_EPI8;
                case "_MM512_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI8;
                case "_MM_CVTEPI64_PD": return Intrinsic._MM_CVTEPI64_PD;
                case "_MM_MASK_CVTEPI64_PD": return Intrinsic._MM_MASK_CVTEPI64_PD;
                case "_MM_MASKZ_CVTEPI64_PD": return Intrinsic._MM_MASKZ_CVTEPI64_PD;
                case "_MM256_CVTEPI64_PD": return Intrinsic._MM256_CVTEPI64_PD;
                case "_MM256_MASK_CVTEPI64_PD": return Intrinsic._MM256_MASK_CVTEPI64_PD;
                case "_MM256_MASKZ_CVTEPI64_PD": return Intrinsic._MM256_MASKZ_CVTEPI64_PD;
                case "_MM512_CVTEPI64_PD": return Intrinsic._MM512_CVTEPI64_PD;
                case "_MM512_MASK_CVTEPI64_PD": return Intrinsic._MM512_MASK_CVTEPI64_PD;
                case "_MM512_MASKZ_CVTEPI64_PD": return Intrinsic._MM512_MASKZ_CVTEPI64_PD;
                case "_MM_CVTEPI64_PS": return Intrinsic._MM_CVTEPI64_PS;
                case "_MM_MASK_CVTEPI64_PS": return Intrinsic._MM_MASK_CVTEPI64_PS;
                case "_MM_MASKZ_CVTEPI64_PS": return Intrinsic._MM_MASKZ_CVTEPI64_PS;
                case "_MM256_CVTEPI64_PS": return Intrinsic._MM256_CVTEPI64_PS;
                case "_MM256_MASK_CVTEPI64_PS": return Intrinsic._MM256_MASK_CVTEPI64_PS;
                case "_MM256_MASKZ_CVTEPI64_PS": return Intrinsic._MM256_MASKZ_CVTEPI64_PS;
                case "_MM512_CVTEPI64_PS": return Intrinsic._MM512_CVTEPI64_PS;
                case "_MM512_MASK_CVTEPI64_PS": return Intrinsic._MM512_MASK_CVTEPI64_PS;
                case "_MM512_MASKZ_CVTEPI64_PS": return Intrinsic._MM512_MASKZ_CVTEPI64_PS;
                case "_MM_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM_CVTEPI8_EPI16": return Intrinsic._MM_CVTEPI8_EPI16;
                case "_MM_MASK_CVTEPI8_EPI16": return Intrinsic._MM_MASK_CVTEPI8_EPI16;
                case "_MM_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM_MASKZ_CVTEPI8_EPI16;
                case "_MM256_CVTEPI8_EPI16": return Intrinsic._MM256_CVTEPI8_EPI16;
                case "_MM256_MASK_CVTEPI8_EPI16": return Intrinsic._MM256_MASK_CVTEPI8_EPI16;
                case "_MM256_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI16;
                case "_MM512_CVTEPI8_EPI16": return Intrinsic._MM512_CVTEPI8_EPI16;
                case "_MM512_MASK_CVTEPI8_EPI16": return Intrinsic._MM512_MASK_CVTEPI8_EPI16;
                case "_MM512_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI16;
                case "_MM_CVTEPI8_EPI32": return Intrinsic._MM_CVTEPI8_EPI32;
                case "_MM_MASK_CVTEPI8_EPI32": return Intrinsic._MM_MASK_CVTEPI8_EPI32;
                case "_MM_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM_MASKZ_CVTEPI8_EPI32;
                case "_MM256_CVTEPI8_EPI32": return Intrinsic._MM256_CVTEPI8_EPI32;
                case "_MM256_MASK_CVTEPI8_EPI32": return Intrinsic._MM256_MASK_CVTEPI8_EPI32;
                case "_MM256_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI32;
                case "_MM512_CVTEPI8_EPI32": return Intrinsic._MM512_CVTEPI8_EPI32;
                case "_MM512_MASK_CVTEPI8_EPI32": return Intrinsic._MM512_MASK_CVTEPI8_EPI32;
                case "_MM512_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI32;
                case "_MM_CVTEPI8_EPI64": return Intrinsic._MM_CVTEPI8_EPI64;
                case "_MM_MASK_CVTEPI8_EPI64": return Intrinsic._MM_MASK_CVTEPI8_EPI64;
                case "_MM_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM_MASKZ_CVTEPI8_EPI64;
                case "_MM256_CVTEPI8_EPI64": return Intrinsic._MM256_CVTEPI8_EPI64;
                case "_MM256_MASK_CVTEPI8_EPI64": return Intrinsic._MM256_MASK_CVTEPI8_EPI64;
                case "_MM256_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI64;
                case "_MM512_CVTEPI8_EPI64": return Intrinsic._MM512_CVTEPI8_EPI64;
                case "_MM512_MASK_CVTEPI8_EPI64": return Intrinsic._MM512_MASK_CVTEPI8_EPI64;
                case "_MM512_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI64;
                case "_MM_CVTEPU16_EPI32": return Intrinsic._MM_CVTEPU16_EPI32;
                case "_MM_MASK_CVTEPU16_EPI32": return Intrinsic._MM_MASK_CVTEPU16_EPI32;
                case "_MM_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM_MASKZ_CVTEPU16_EPI32;
                case "_MM256_CVTEPU16_EPI32": return Intrinsic._MM256_CVTEPU16_EPI32;
                case "_MM256_MASK_CVTEPU16_EPI32": return Intrinsic._MM256_MASK_CVTEPU16_EPI32;
                case "_MM256_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM256_MASKZ_CVTEPU16_EPI32;
                case "_MM512_CVTEPU16_EPI32": return Intrinsic._MM512_CVTEPU16_EPI32;
                case "_MM512_MASK_CVTEPU16_EPI32": return Intrinsic._MM512_MASK_CVTEPU16_EPI32;
                case "_MM512_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM512_MASKZ_CVTEPU16_EPI32;
                case "_MM_CVTEPU16_EPI64": return Intrinsic._MM_CVTEPU16_EPI64;
                case "_MM_MASK_CVTEPU16_EPI64": return Intrinsic._MM_MASK_CVTEPU16_EPI64;
                case "_MM_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM_MASKZ_CVTEPU16_EPI64;
                case "_MM256_CVTEPU16_EPI64": return Intrinsic._MM256_CVTEPU16_EPI64;
                case "_MM256_MASK_CVTEPU16_EPI64": return Intrinsic._MM256_MASK_CVTEPU16_EPI64;
                case "_MM256_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU16_EPI64;
                case "_MM512_CVTEPU16_EPI64": return Intrinsic._MM512_CVTEPU16_EPI64;
                case "_MM512_MASK_CVTEPU16_EPI64": return Intrinsic._MM512_MASK_CVTEPU16_EPI64;
                case "_MM512_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU16_EPI64;
                case "_MM_CVTEPU32_EPI64": return Intrinsic._MM_CVTEPU32_EPI64;
                case "_MM_MASK_CVTEPU32_EPI64": return Intrinsic._MM_MASK_CVTEPU32_EPI64;
                case "_MM_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM_MASKZ_CVTEPU32_EPI64;
                case "_MM256_CVTEPU32_EPI64": return Intrinsic._MM256_CVTEPU32_EPI64;
                case "_MM256_MASK_CVTEPU32_EPI64": return Intrinsic._MM256_MASK_CVTEPU32_EPI64;
                case "_MM256_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU32_EPI64;
                case "_MM512_CVTEPU32_EPI64": return Intrinsic._MM512_CVTEPU32_EPI64;
                case "_MM512_MASK_CVTEPU32_EPI64": return Intrinsic._MM512_MASK_CVTEPU32_EPI64;
                case "_MM512_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU32_EPI64;
                case "_MM_CVTEPU32_PD": return Intrinsic._MM_CVTEPU32_PD;
                case "_MM_MASK_CVTEPU32_PD": return Intrinsic._MM_MASK_CVTEPU32_PD;
                case "_MM_MASKZ_CVTEPU32_PD": return Intrinsic._MM_MASKZ_CVTEPU32_PD;
                case "_MM256_CVTEPU32_PD": return Intrinsic._MM256_CVTEPU32_PD;
                case "_MM256_MASK_CVTEPU32_PD": return Intrinsic._MM256_MASK_CVTEPU32_PD;
                case "_MM256_MASKZ_CVTEPU32_PD": return Intrinsic._MM256_MASKZ_CVTEPU32_PD;
                case "_MM512_CVTEPU32_PD": return Intrinsic._MM512_CVTEPU32_PD;
                case "_MM512_MASK_CVTEPU32_PD": return Intrinsic._MM512_MASK_CVTEPU32_PD;
                case "_MM512_MASKZ_CVTEPU32_PD": return Intrinsic._MM512_MASKZ_CVTEPU32_PD;
                case "_MM512_CVTEPU32_PS": return Intrinsic._MM512_CVTEPU32_PS;
                case "_MM512_MASK_CVTEPU32_PS": return Intrinsic._MM512_MASK_CVTEPU32_PS;
                case "_MM512_MASKZ_CVTEPU32_PS": return Intrinsic._MM512_MASKZ_CVTEPU32_PS;
                case "_MM512_CVTEPU32LO_PD": return Intrinsic._MM512_CVTEPU32LO_PD;
                case "_MM512_MASK_CVTEPU32LO_PD": return Intrinsic._MM512_MASK_CVTEPU32LO_PD;
                case "_MM_CVTEPU64_PD": return Intrinsic._MM_CVTEPU64_PD;
                case "_MM_MASK_CVTEPU64_PD": return Intrinsic._MM_MASK_CVTEPU64_PD;
                case "_MM_MASKZ_CVTEPU64_PD": return Intrinsic._MM_MASKZ_CVTEPU64_PD;
                case "_MM256_CVTEPU64_PD": return Intrinsic._MM256_CVTEPU64_PD;
                case "_MM256_MASK_CVTEPU64_PD": return Intrinsic._MM256_MASK_CVTEPU64_PD;
                case "_MM256_MASKZ_CVTEPU64_PD": return Intrinsic._MM256_MASKZ_CVTEPU64_PD;
                case "_MM512_CVTEPU64_PD": return Intrinsic._MM512_CVTEPU64_PD;
                case "_MM512_MASK_CVTEPU64_PD": return Intrinsic._MM512_MASK_CVTEPU64_PD;
                case "_MM512_MASKZ_CVTEPU64_PD": return Intrinsic._MM512_MASKZ_CVTEPU64_PD;
                case "_MM_CVTEPU64_PS": return Intrinsic._MM_CVTEPU64_PS;
                case "_MM_MASK_CVTEPU64_PS": return Intrinsic._MM_MASK_CVTEPU64_PS;
                case "_MM_MASKZ_CVTEPU64_PS": return Intrinsic._MM_MASKZ_CVTEPU64_PS;
                case "_MM256_CVTEPU64_PS": return Intrinsic._MM256_CVTEPU64_PS;
                case "_MM256_MASK_CVTEPU64_PS": return Intrinsic._MM256_MASK_CVTEPU64_PS;
                case "_MM256_MASKZ_CVTEPU64_PS": return Intrinsic._MM256_MASKZ_CVTEPU64_PS;
                case "_MM512_CVTEPU64_PS": return Intrinsic._MM512_CVTEPU64_PS;
                case "_MM512_MASK_CVTEPU64_PS": return Intrinsic._MM512_MASK_CVTEPU64_PS;
                case "_MM512_MASKZ_CVTEPU64_PS": return Intrinsic._MM512_MASKZ_CVTEPU64_PS;
                case "_MM_CVTEPU8_EPI16": return Intrinsic._MM_CVTEPU8_EPI16;
                case "_MM_MASK_CVTEPU8_EPI16": return Intrinsic._MM_MASK_CVTEPU8_EPI16;
                case "_MM_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM_MASKZ_CVTEPU8_EPI16;
                case "_MM256_CVTEPU8_EPI16": return Intrinsic._MM256_CVTEPU8_EPI16;
                case "_MM256_MASK_CVTEPU8_EPI16": return Intrinsic._MM256_MASK_CVTEPU8_EPI16;
                case "_MM256_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI16;
                case "_MM512_CVTEPU8_EPI16": return Intrinsic._MM512_CVTEPU8_EPI16;
                case "_MM512_MASK_CVTEPU8_EPI16": return Intrinsic._MM512_MASK_CVTEPU8_EPI16;
                case "_MM512_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI16;
                case "_MM_CVTEPU8_EPI32": return Intrinsic._MM_CVTEPU8_EPI32;
                case "_MM_MASK_CVTEPU8_EPI32": return Intrinsic._MM_MASK_CVTEPU8_EPI32;
                case "_MM_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM_MASKZ_CVTEPU8_EPI32;
                case "_MM256_CVTEPU8_EPI32": return Intrinsic._MM256_CVTEPU8_EPI32;
                case "_MM256_MASK_CVTEPU8_EPI32": return Intrinsic._MM256_MASK_CVTEPU8_EPI32;
                case "_MM256_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI32;
                case "_MM512_CVTEPU8_EPI32": return Intrinsic._MM512_CVTEPU8_EPI32;
                case "_MM512_MASK_CVTEPU8_EPI32": return Intrinsic._MM512_MASK_CVTEPU8_EPI32;
                case "_MM512_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI32;
                case "_MM_CVTEPU8_EPI64": return Intrinsic._MM_CVTEPU8_EPI64;
                case "_MM_MASK_CVTEPU8_EPI64": return Intrinsic._MM_MASK_CVTEPU8_EPI64;
                case "_MM_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM_MASKZ_CVTEPU8_EPI64;
                case "_MM256_CVTEPU8_EPI64": return Intrinsic._MM256_CVTEPU8_EPI64;
                case "_MM256_MASK_CVTEPU8_EPI64": return Intrinsic._MM256_MASK_CVTEPU8_EPI64;
                case "_MM256_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI64;
                case "_MM512_CVTEPU8_EPI64": return Intrinsic._MM512_CVTEPU8_EPI64;
                case "_MM512_MASK_CVTEPU8_EPI64": return Intrinsic._MM512_MASK_CVTEPU8_EPI64;
                case "_MM512_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI64;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTEPI32_PS": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTEPI32_PS;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTEPU32_PS": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTEPU32_PS;
                case "_MM512_MASK_CVTFXPNT_ROUND_ADJUSTEPU32_PS": return Intrinsic._MM512_MASK_CVTFXPNT_ROUND_ADJUSTEPU32_PS;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTPS_EPI32": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTPS_EPI32;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTPS_EPU32": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTPS_EPU32;
                case "_MM512_CVTFXPNT_ROUNDPD_EPI32LO": return Intrinsic._MM512_CVTFXPNT_ROUNDPD_EPI32LO;
                case "_MM512_MASK_CVTFXPNT_ROUNDPD_EPI32LO": return Intrinsic._MM512_MASK_CVTFXPNT_ROUNDPD_EPI32LO;
                case "_MM512_CVTFXPNT_ROUNDPD_EPU32LO": return Intrinsic._MM512_CVTFXPNT_ROUNDPD_EPU32LO;
                case "_MM512_MASK_CVTFXPNT_ROUNDPD_EPU32LO": return Intrinsic._MM512_MASK_CVTFXPNT_ROUNDPD_EPU32LO;
                case "_MM_CVTI32_SD": return Intrinsic._MM_CVTI32_SD;
                case "_MM_CVTI32_SS": return Intrinsic._MM_CVTI32_SS;
                case "_MM_CVTI64_SD": return Intrinsic._MM_CVTI64_SD;
                case "_MM_CVTI64_SS": return Intrinsic._MM_CVTI64_SS;
                case "_MM_CVTM64_SI64": return Intrinsic._MM_CVTM64_SI64;
                case "_MM_CVTPD_EPI32": return Intrinsic._MM_CVTPD_EPI32;
                case "_MM_MASK_CVTPD_EPI32": return Intrinsic._MM_MASK_CVTPD_EPI32;
                case "_MM_MASKZ_CVTPD_EPI32": return Intrinsic._MM_MASKZ_CVTPD_EPI32;
                case "_MM256_CVTPD_EPI32": return Intrinsic._MM256_CVTPD_EPI32;
                case "_MM256_MASK_CVTPD_EPI32": return Intrinsic._MM256_MASK_CVTPD_EPI32;
                case "_MM256_MASKZ_CVTPD_EPI32": return Intrinsic._MM256_MASKZ_CVTPD_EPI32;
                case "_MM512_CVTPD_EPI32": return Intrinsic._MM512_CVTPD_EPI32;
                case "_MM512_MASK_CVTPD_EPI32": return Intrinsic._MM512_MASK_CVTPD_EPI32;
                case "_MM512_MASKZ_CVTPD_EPI32": return Intrinsic._MM512_MASKZ_CVTPD_EPI32;
                case "_MM_CVTPD_EPI64": return Intrinsic._MM_CVTPD_EPI64;
                case "_MM_MASK_CVTPD_EPI64": return Intrinsic._MM_MASK_CVTPD_EPI64;
                case "_MM_MASKZ_CVTPD_EPI64": return Intrinsic._MM_MASKZ_CVTPD_EPI64;
                case "_MM256_CVTPD_EPI64": return Intrinsic._MM256_CVTPD_EPI64;
                case "_MM256_MASK_CVTPD_EPI64": return Intrinsic._MM256_MASK_CVTPD_EPI64;
                case "_MM256_MASKZ_CVTPD_EPI64": return Intrinsic._MM256_MASKZ_CVTPD_EPI64;
                case "_MM512_CVTPD_EPI64": return Intrinsic._MM512_CVTPD_EPI64;
                case "_MM512_MASK_CVTPD_EPI64": return Intrinsic._MM512_MASK_CVTPD_EPI64;
                case "_MM512_MASKZ_CVTPD_EPI64": return Intrinsic._MM512_MASKZ_CVTPD_EPI64;
                case "_MM_CVTPD_EPU32": return Intrinsic._MM_CVTPD_EPU32;
                case "_MM_MASK_CVTPD_EPU32": return Intrinsic._MM_MASK_CVTPD_EPU32;
                case "_MM_MASKZ_CVTPD_EPU32": return Intrinsic._MM_MASKZ_CVTPD_EPU32;
                case "_MM256_CVTPD_EPU32": return Intrinsic._MM256_CVTPD_EPU32;
                case "_MM256_MASK_CVTPD_EPU32": return Intrinsic._MM256_MASK_CVTPD_EPU32;
                case "_MM256_MASKZ_CVTPD_EPU32": return Intrinsic._MM256_MASKZ_CVTPD_EPU32;
                case "_MM512_CVTPD_EPU32": return Intrinsic._MM512_CVTPD_EPU32;
                case "_MM512_MASK_CVTPD_EPU32": return Intrinsic._MM512_MASK_CVTPD_EPU32;
                case "_MM512_MASKZ_CVTPD_EPU32": return Intrinsic._MM512_MASKZ_CVTPD_EPU32;
                case "_MM_CVTPD_EPU64": return Intrinsic._MM_CVTPD_EPU64;
                case "_MM_MASK_CVTPD_EPU64": return Intrinsic._MM_MASK_CVTPD_EPU64;
                case "_MM_MASKZ_CVTPD_EPU64": return Intrinsic._MM_MASKZ_CVTPD_EPU64;
                case "_MM256_CVTPD_EPU64": return Intrinsic._MM256_CVTPD_EPU64;
                case "_MM256_MASK_CVTPD_EPU64": return Intrinsic._MM256_MASK_CVTPD_EPU64;
                case "_MM256_MASKZ_CVTPD_EPU64": return Intrinsic._MM256_MASKZ_CVTPD_EPU64;
                case "_MM512_CVTPD_EPU64": return Intrinsic._MM512_CVTPD_EPU64;
                case "_MM512_MASK_CVTPD_EPU64": return Intrinsic._MM512_MASK_CVTPD_EPU64;
                case "_MM512_MASKZ_CVTPD_EPU64": return Intrinsic._MM512_MASKZ_CVTPD_EPU64;
                case "_MM_CVTPD_PI32": return Intrinsic._MM_CVTPD_PI32;
                case "_MM_CVTPD_PS": return Intrinsic._MM_CVTPD_PS;
                case "_MM_MASK_CVTPD_PS": return Intrinsic._MM_MASK_CVTPD_PS;
                case "_MM_MASKZ_CVTPD_PS": return Intrinsic._MM_MASKZ_CVTPD_PS;
                case "_MM256_CVTPD_PS": return Intrinsic._MM256_CVTPD_PS;
                case "_MM256_MASK_CVTPD_PS": return Intrinsic._MM256_MASK_CVTPD_PS;
                case "_MM256_MASKZ_CVTPD_PS": return Intrinsic._MM256_MASKZ_CVTPD_PS;
                case "_MM512_CVTPD_PS": return Intrinsic._MM512_CVTPD_PS;
                case "_MM512_MASK_CVTPD_PS": return Intrinsic._MM512_MASK_CVTPD_PS;
                case "_MM512_MASKZ_CVTPD_PS": return Intrinsic._MM512_MASKZ_CVTPD_PS;
                case "_MM512_CVTPD_PSLO": return Intrinsic._MM512_CVTPD_PSLO;
                case "_MM512_MASK_CVTPD_PSLO": return Intrinsic._MM512_MASK_CVTPD_PSLO;
                case "_MM_CVTPH_PS": return Intrinsic._MM_CVTPH_PS;
                case "_MM_MASK_CVTPH_PS": return Intrinsic._MM_MASK_CVTPH_PS;
                case "_MM_MASKZ_CVTPH_PS": return Intrinsic._MM_MASKZ_CVTPH_PS;
                case "_MM256_CVTPH_PS": return Intrinsic._MM256_CVTPH_PS;
                case "_MM256_MASK_CVTPH_PS": return Intrinsic._MM256_MASK_CVTPH_PS;
                case "_MM256_MASKZ_CVTPH_PS": return Intrinsic._MM256_MASKZ_CVTPH_PS;
                case "_MM512_CVTPH_PS": return Intrinsic._MM512_CVTPH_PS;
                case "_MM512_MASK_CVTPH_PS": return Intrinsic._MM512_MASK_CVTPH_PS;
                case "_MM512_MASKZ_CVTPH_PS": return Intrinsic._MM512_MASKZ_CVTPH_PS;
                case "_MM_CVTPI16_PS": return Intrinsic._MM_CVTPI16_PS;
                case "_MM_CVTPI32_PD": return Intrinsic._MM_CVTPI32_PD;
                case "_MM_CVTPI32_PS": return Intrinsic._MM_CVTPI32_PS;
                case "_MM_CVTPI32X2_PS": return Intrinsic._MM_CVTPI32X2_PS;
                case "_MM_CVTPI8_PS": return Intrinsic._MM_CVTPI8_PS;
                case "_MM_CVTPS_EPI32": return Intrinsic._MM_CVTPS_EPI32;
                case "_MM_MASK_CVTPS_EPI32": return Intrinsic._MM_MASK_CVTPS_EPI32;
                case "_MM_MASKZ_CVTPS_EPI32": return Intrinsic._MM_MASKZ_CVTPS_EPI32;
                case "_MM256_CVTPS_EPI32": return Intrinsic._MM256_CVTPS_EPI32;
                case "_MM256_MASK_CVTPS_EPI32": return Intrinsic._MM256_MASK_CVTPS_EPI32;
                case "_MM256_MASKZ_CVTPS_EPI32": return Intrinsic._MM256_MASKZ_CVTPS_EPI32;
                case "_MM512_CVTPS_EPI32": return Intrinsic._MM512_CVTPS_EPI32;
                case "_MM512_MASK_CVTPS_EPI32": return Intrinsic._MM512_MASK_CVTPS_EPI32;
                case "_MM512_MASKZ_CVTPS_EPI32": return Intrinsic._MM512_MASKZ_CVTPS_EPI32;
                case "_MM_CVTPS_EPI64": return Intrinsic._MM_CVTPS_EPI64;
                case "_MM_MASK_CVTPS_EPI64": return Intrinsic._MM_MASK_CVTPS_EPI64;
                case "_MM_MASKZ_CVTPS_EPI64": return Intrinsic._MM_MASKZ_CVTPS_EPI64;
                case "_MM256_CVTPS_EPI64": return Intrinsic._MM256_CVTPS_EPI64;
                case "_MM256_MASK_CVTPS_EPI64": return Intrinsic._MM256_MASK_CVTPS_EPI64;
                case "_MM256_MASKZ_CVTPS_EPI64": return Intrinsic._MM256_MASKZ_CVTPS_EPI64;
                case "_MM512_CVTPS_EPI64": return Intrinsic._MM512_CVTPS_EPI64;
                case "_MM512_MASK_CVTPS_EPI64": return Intrinsic._MM512_MASK_CVTPS_EPI64;
                case "_MM512_MASKZ_CVTPS_EPI64": return Intrinsic._MM512_MASKZ_CVTPS_EPI64;
                case "_MM_CVTPS_EPU32": return Intrinsic._MM_CVTPS_EPU32;
                case "_MM_MASK_CVTPS_EPU32": return Intrinsic._MM_MASK_CVTPS_EPU32;
                case "_MM_MASKZ_CVTPS_EPU32": return Intrinsic._MM_MASKZ_CVTPS_EPU32;
                case "_MM256_CVTPS_EPU32": return Intrinsic._MM256_CVTPS_EPU32;
                case "_MM256_MASK_CVTPS_EPU32": return Intrinsic._MM256_MASK_CVTPS_EPU32;
                case "_MM256_MASKZ_CVTPS_EPU32": return Intrinsic._MM256_MASKZ_CVTPS_EPU32;
                case "_MM512_CVTPS_EPU32": return Intrinsic._MM512_CVTPS_EPU32;
                case "_MM512_MASK_CVTPS_EPU32": return Intrinsic._MM512_MASK_CVTPS_EPU32;
                case "_MM512_MASKZ_CVTPS_EPU32": return Intrinsic._MM512_MASKZ_CVTPS_EPU32;
                case "_MM_CVTPS_EPU64": return Intrinsic._MM_CVTPS_EPU64;
                case "_MM_MASK_CVTPS_EPU64": return Intrinsic._MM_MASK_CVTPS_EPU64;
                case "_MM_MASKZ_CVTPS_EPU64": return Intrinsic._MM_MASKZ_CVTPS_EPU64;
                case "_MM256_CVTPS_EPU64": return Intrinsic._MM256_CVTPS_EPU64;
                case "_MM256_MASK_CVTPS_EPU64": return Intrinsic._MM256_MASK_CVTPS_EPU64;
                case "_MM256_MASKZ_CVTPS_EPU64": return Intrinsic._MM256_MASKZ_CVTPS_EPU64;
                case "_MM512_CVTPS_EPU64": return Intrinsic._MM512_CVTPS_EPU64;
                case "_MM512_MASK_CVTPS_EPU64": return Intrinsic._MM512_MASK_CVTPS_EPU64;
                case "_MM512_MASKZ_CVTPS_EPU64": return Intrinsic._MM512_MASKZ_CVTPS_EPU64;
                case "_MM_CVTPS_PD": return Intrinsic._MM_CVTPS_PD;
                case "_MM256_CVTPS_PD": return Intrinsic._MM256_CVTPS_PD;
                case "_MM512_CVTPS_PD": return Intrinsic._MM512_CVTPS_PD;
                case "_MM512_MASK_CVTPS_PD": return Intrinsic._MM512_MASK_CVTPS_PD;
                case "_MM512_MASKZ_CVTPS_PD": return Intrinsic._MM512_MASKZ_CVTPS_PD;
                case "_MM_CVTPS_PH": return Intrinsic._MM_CVTPS_PH;
                case "_MM_MASK_CVTPS_PH": return Intrinsic._MM_MASK_CVTPS_PH;
                case "_MM_MASKZ_CVTPS_PH": return Intrinsic._MM_MASKZ_CVTPS_PH;
                case "_MM256_CVTPS_PH": return Intrinsic._MM256_CVTPS_PH;
                case "_MM256_MASK_CVTPS_PH": return Intrinsic._MM256_MASK_CVTPS_PH;
                case "_MM256_MASKZ_CVTPS_PH": return Intrinsic._MM256_MASKZ_CVTPS_PH;
                case "_MM512_CVTPS_PH": return Intrinsic._MM512_CVTPS_PH;
                case "_MM512_MASK_CVTPS_PH": return Intrinsic._MM512_MASK_CVTPS_PH;
                case "_MM512_MASKZ_CVTPS_PH": return Intrinsic._MM512_MASKZ_CVTPS_PH;
                case "_MM_CVTPS_PI16": return Intrinsic._MM_CVTPS_PI16;
                case "_MM_CVTPS_PI32": return Intrinsic._MM_CVTPS_PI32;
                case "_MM_CVTPS_PI8": return Intrinsic._MM_CVTPS_PI8;
                case "_MM512_CVTPSLO_PD": return Intrinsic._MM512_CVTPSLO_PD;
                case "_MM512_MASK_CVTPSLO_PD": return Intrinsic._MM512_MASK_CVTPSLO_PD;
                case "_MM_CVTPU16_PS": return Intrinsic._MM_CVTPU16_PS;
                case "_MM_CVTPU8_PS": return Intrinsic._MM_CVTPU8_PS;
                case "_MM_CVTSD_F64": return Intrinsic._MM_CVTSD_F64;
                case "_MM_CVTSD_I32": return Intrinsic._MM_CVTSD_I32;
                case "_MM_CVTSD_I64": return Intrinsic._MM_CVTSD_I64;
                case "_MM_CVTSD_SI32": return Intrinsic._MM_CVTSD_SI32;
                case "_MM_CVTSD_SI64": return Intrinsic._MM_CVTSD_SI64;
                case "_MM_CVTSD_SI64X": return Intrinsic._MM_CVTSD_SI64X;
                case "_MM_CVTSD_SS": return Intrinsic._MM_CVTSD_SS;
                case "_MM_MASK_CVTSD_SS": return Intrinsic._MM_MASK_CVTSD_SS;
                case "_MM_MASKZ_CVTSD_SS": return Intrinsic._MM_MASKZ_CVTSD_SS;
                case "_MM_CVTSD_U32": return Intrinsic._MM_CVTSD_U32;
                case "_MM_CVTSD_U64": return Intrinsic._MM_CVTSD_U64;
                case "_MM_CVTSEPI16_EPI8": return Intrinsic._MM_CVTSEPI16_EPI8;
                case "_MM_MASK_CVTSEPI16_EPI8": return Intrinsic._MM_MASK_CVTSEPI16_EPI8;
                case "_MM_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI16_EPI8;
                case "_MM256_CVTSEPI16_EPI8": return Intrinsic._MM256_CVTSEPI16_EPI8;
                case "_MM256_MASK_CVTSEPI16_EPI8": return Intrinsic._MM256_MASK_CVTSEPI16_EPI8;
                case "_MM256_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI16_EPI8;
                case "_MM512_CVTSEPI16_EPI8": return Intrinsic._MM512_CVTSEPI16_EPI8;
                case "_MM512_MASK_CVTSEPI16_EPI8": return Intrinsic._MM512_MASK_CVTSEPI16_EPI8;
                case "_MM512_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI16_EPI8;
                case "_MM_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM_CVTSEPI32_EPI16": return Intrinsic._MM_CVTSEPI32_EPI16;
                case "_MM_MASK_CVTSEPI32_EPI16": return Intrinsic._MM_MASK_CVTSEPI32_EPI16;
                case "_MM_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTSEPI32_EPI16;
                case "_MM256_CVTSEPI32_EPI16": return Intrinsic._MM256_CVTSEPI32_EPI16;
                case "_MM256_MASK_CVTSEPI32_EPI16": return Intrinsic._MM256_MASK_CVTSEPI32_EPI16;
                case "_MM256_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTSEPI32_EPI16;
                case "_MM512_CVTSEPI32_EPI16": return Intrinsic._MM512_CVTSEPI32_EPI16;
                case "_MM512_MASK_CVTSEPI32_EPI16": return Intrinsic._MM512_MASK_CVTSEPI32_EPI16;
                case "_MM512_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTSEPI32_EPI16;
                case "_MM_CVTSEPI32_EPI8": return Intrinsic._MM_CVTSEPI32_EPI8;
                case "_MM_MASK_CVTSEPI32_EPI8": return Intrinsic._MM_MASK_CVTSEPI32_EPI8;
                case "_MM_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI32_EPI8;
                case "_MM256_CVTSEPI32_EPI8": return Intrinsic._MM256_CVTSEPI32_EPI8;
                case "_MM256_MASK_CVTSEPI32_EPI8": return Intrinsic._MM256_MASK_CVTSEPI32_EPI8;
                case "_MM256_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI32_EPI8;
                case "_MM512_CVTSEPI32_EPI8": return Intrinsic._MM512_CVTSEPI32_EPI8;
                case "_MM512_MASK_CVTSEPI32_EPI8": return Intrinsic._MM512_MASK_CVTSEPI32_EPI8;
                case "_MM512_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI32_EPI8;
                case "_MM_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM_CVTSEPI64_EPI16": return Intrinsic._MM_CVTSEPI64_EPI16;
                case "_MM_MASK_CVTSEPI64_EPI16": return Intrinsic._MM_MASK_CVTSEPI64_EPI16;
                case "_MM_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI16;
                case "_MM256_CVTSEPI64_EPI16": return Intrinsic._MM256_CVTSEPI64_EPI16;
                case "_MM256_MASK_CVTSEPI64_EPI16": return Intrinsic._MM256_MASK_CVTSEPI64_EPI16;
                case "_MM256_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI16;
                case "_MM512_CVTSEPI64_EPI16": return Intrinsic._MM512_CVTSEPI64_EPI16;
                case "_MM512_MASK_CVTSEPI64_EPI16": return Intrinsic._MM512_MASK_CVTSEPI64_EPI16;
                case "_MM512_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI16;
                case "_MM_CVTSEPI64_EPI32": return Intrinsic._MM_CVTSEPI64_EPI32;
                case "_MM_MASK_CVTSEPI64_EPI32": return Intrinsic._MM_MASK_CVTSEPI64_EPI32;
                case "_MM_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI32;
                case "_MM256_CVTSEPI64_EPI32": return Intrinsic._MM256_CVTSEPI64_EPI32;
                case "_MM256_MASK_CVTSEPI64_EPI32": return Intrinsic._MM256_MASK_CVTSEPI64_EPI32;
                case "_MM256_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI32;
                case "_MM512_CVTSEPI64_EPI32": return Intrinsic._MM512_CVTSEPI64_EPI32;
                case "_MM512_MASK_CVTSEPI64_EPI32": return Intrinsic._MM512_MASK_CVTSEPI64_EPI32;
                case "_MM512_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI32;
                case "_MM_CVTSEPI64_EPI8": return Intrinsic._MM_CVTSEPI64_EPI8;
                case "_MM_MASK_CVTSEPI64_EPI8": return Intrinsic._MM_MASK_CVTSEPI64_EPI8;
                case "_MM_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI8;
                case "_MM256_CVTSEPI64_EPI8": return Intrinsic._MM256_CVTSEPI64_EPI8;
                case "_MM256_MASK_CVTSEPI64_EPI8": return Intrinsic._MM256_MASK_CVTSEPI64_EPI8;
                case "_MM256_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI8;
                case "_MM512_CVTSEPI64_EPI8": return Intrinsic._MM512_CVTSEPI64_EPI8;
                case "_MM512_MASK_CVTSEPI64_EPI8": return Intrinsic._MM512_MASK_CVTSEPI64_EPI8;
                case "_MM512_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI8;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI8;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI8;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI8;
                case "_CVTSH_SS": return Intrinsic._CVTSH_SS;
                case "_MM_CVTSI128_SI32": return Intrinsic._MM_CVTSI128_SI32;
                case "_MM_CVTSI128_SI64": return Intrinsic._MM_CVTSI128_SI64;
                case "_MM_CVTSI128_SI64X": return Intrinsic._MM_CVTSI128_SI64X;
                case "_MM_CVTSI32_SD": return Intrinsic._MM_CVTSI32_SD;
                case "_MM_CVTSI32_SI128": return Intrinsic._MM_CVTSI32_SI128;
                case "_MM_CVTSI32_SI64": return Intrinsic._MM_CVTSI32_SI64;
                case "_MM_CVTSI32_SS": return Intrinsic._MM_CVTSI32_SS;
                case "_MM_CVTSI64_M64": return Intrinsic._MM_CVTSI64_M64;
                case "_MM_CVTSI64_SD": return Intrinsic._MM_CVTSI64_SD;
                case "_MM_CVTSI64_SI128": return Intrinsic._MM_CVTSI64_SI128;
                case "_MM_CVTSI64_SI32": return Intrinsic._MM_CVTSI64_SI32;
                case "_MM_CVTSI64_SS": return Intrinsic._MM_CVTSI64_SS;
                case "_MM_CVTSI64X_SD": return Intrinsic._MM_CVTSI64X_SD;
                case "_MM_CVTSI64X_SI128": return Intrinsic._MM_CVTSI64X_SI128;
                case "_MM_CVTSS_F32": return Intrinsic._MM_CVTSS_F32;
                case "_MM_CVTSS_I32": return Intrinsic._MM_CVTSS_I32;
                case "_MM_CVTSS_I64": return Intrinsic._MM_CVTSS_I64;
                case "_MM_CVTSS_SD": return Intrinsic._MM_CVTSS_SD;
                case "_MM_MASK_CVTSS_SD": return Intrinsic._MM_MASK_CVTSS_SD;
                case "_MM_MASKZ_CVTSS_SD": return Intrinsic._MM_MASKZ_CVTSS_SD;
                case "_CVTSS_SH": return Intrinsic._CVTSS_SH;
                case "_MM_CVTSS_SI32": return Intrinsic._MM_CVTSS_SI32;
                case "_MM_CVTSS_SI64": return Intrinsic._MM_CVTSS_SI64;
                case "_MM_CVTSS_U32": return Intrinsic._MM_CVTSS_U32;
                case "_MM_CVTSS_U64": return Intrinsic._MM_CVTSS_U64;
                case "_MM_CVTT_PS2PI": return Intrinsic._MM_CVTT_PS2PI;
                case "_MM512_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_CVTT_ROUNDPD_EPI32;
                case "_MM512_MASK_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPI32;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPI32;
                case "_MM512_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_CVTT_ROUNDPD_EPI64;
                case "_MM512_MASK_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPI64;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPI64;
                case "_MM512_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_CVTT_ROUNDPD_EPU32;
                case "_MM512_MASK_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPU32;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPU32;
                case "_MM512_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_CVTT_ROUNDPD_EPU64;
                case "_MM512_MASK_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPU64;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPU64;
                case "_MM512_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_CVTT_ROUNDPS_EPI32;
                case "_MM512_MASK_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPI32;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPI32;
                case "_MM512_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_CVTT_ROUNDPS_EPI64;
                case "_MM512_MASK_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPI64;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPI64;
                case "_MM512_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_CVTT_ROUNDPS_EPU32;
                case "_MM512_MASK_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPU32;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPU32;
                case "_MM512_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_CVTT_ROUNDPS_EPU64;
                case "_MM512_MASK_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPU64;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPU64;
                case "_MM_CVTT_ROUNDSD_I32": return Intrinsic._MM_CVTT_ROUNDSD_I32;
                case "_MM_CVTT_ROUNDSD_I64": return Intrinsic._MM_CVTT_ROUNDSD_I64;
                case "_MM_CVTT_ROUNDSD_SI32": return Intrinsic._MM_CVTT_ROUNDSD_SI32;
                case "_MM_CVTT_ROUNDSD_SI64": return Intrinsic._MM_CVTT_ROUNDSD_SI64;
                case "_MM_CVTT_ROUNDSD_U32": return Intrinsic._MM_CVTT_ROUNDSD_U32;
                case "_MM_CVTT_ROUNDSD_U64": return Intrinsic._MM_CVTT_ROUNDSD_U64;
                case "_MM_CVTT_ROUNDSS_I32": return Intrinsic._MM_CVTT_ROUNDSS_I32;
                case "_MM_CVTT_ROUNDSS_I64": return Intrinsic._MM_CVTT_ROUNDSS_I64;
                case "_MM_CVTT_ROUNDSS_SI32": return Intrinsic._MM_CVTT_ROUNDSS_SI32;
                case "_MM_CVTT_ROUNDSS_SI64": return Intrinsic._MM_CVTT_ROUNDSS_SI64;
                case "_MM_CVTT_ROUNDSS_U32": return Intrinsic._MM_CVTT_ROUNDSS_U32;
                case "_MM_CVTT_ROUNDSS_U64": return Intrinsic._MM_CVTT_ROUNDSS_U64;
                case "_MM_CVTT_SS2SI": return Intrinsic._MM_CVTT_SS2SI;
                case "_MM_CVTTPD_EPI32": return Intrinsic._MM_CVTTPD_EPI32;
                case "_MM_MASK_CVTTPD_EPI32": return Intrinsic._MM_MASK_CVTTPD_EPI32;
                case "_MM_MASKZ_CVTTPD_EPI32": return Intrinsic._MM_MASKZ_CVTTPD_EPI32;
                case "_MM256_CVTTPD_EPI32": return Intrinsic._MM256_CVTTPD_EPI32;
                case "_MM256_MASK_CVTTPD_EPI32": return Intrinsic._MM256_MASK_CVTTPD_EPI32;
                case "_MM256_MASKZ_CVTTPD_EPI32": return Intrinsic._MM256_MASKZ_CVTTPD_EPI32;
                case "_MM512_CVTTPD_EPI32": return Intrinsic._MM512_CVTTPD_EPI32;
                case "_MM512_MASK_CVTTPD_EPI32": return Intrinsic._MM512_MASK_CVTTPD_EPI32;
                case "_MM512_MASKZ_CVTTPD_EPI32": return Intrinsic._MM512_MASKZ_CVTTPD_EPI32;
                case "_MM_CVTTPD_EPI64": return Intrinsic._MM_CVTTPD_EPI64;
                case "_MM_MASK_CVTTPD_EPI64": return Intrinsic._MM_MASK_CVTTPD_EPI64;
                case "_MM_MASKZ_CVTTPD_EPI64": return Intrinsic._MM_MASKZ_CVTTPD_EPI64;
                case "_MM256_CVTTPD_EPI64": return Intrinsic._MM256_CVTTPD_EPI64;
                case "_MM256_MASK_CVTTPD_EPI64": return Intrinsic._MM256_MASK_CVTTPD_EPI64;
                case "_MM256_MASKZ_CVTTPD_EPI64": return Intrinsic._MM256_MASKZ_CVTTPD_EPI64;
                case "_MM512_CVTTPD_EPI64": return Intrinsic._MM512_CVTTPD_EPI64;
                case "_MM512_MASK_CVTTPD_EPI64": return Intrinsic._MM512_MASK_CVTTPD_EPI64;
                case "_MM512_MASKZ_CVTTPD_EPI64": return Intrinsic._MM512_MASKZ_CVTTPD_EPI64;
                case "_MM_CVTTPD_EPU32": return Intrinsic._MM_CVTTPD_EPU32;
                case "_MM_MASK_CVTTPD_EPU32": return Intrinsic._MM_MASK_CVTTPD_EPU32;
                case "_MM_MASKZ_CVTTPD_EPU32": return Intrinsic._MM_MASKZ_CVTTPD_EPU32;
                case "_MM256_CVTTPD_EPU32": return Intrinsic._MM256_CVTTPD_EPU32;
                case "_MM256_MASK_CVTTPD_EPU32": return Intrinsic._MM256_MASK_CVTTPD_EPU32;
                case "_MM256_MASKZ_CVTTPD_EPU32": return Intrinsic._MM256_MASKZ_CVTTPD_EPU32;
                case "_MM512_CVTTPD_EPU32": return Intrinsic._MM512_CVTTPD_EPU32;
                case "_MM512_MASK_CVTTPD_EPU32": return Intrinsic._MM512_MASK_CVTTPD_EPU32;
                case "_MM512_MASKZ_CVTTPD_EPU32": return Intrinsic._MM512_MASKZ_CVTTPD_EPU32;
                case "_MM_CVTTPD_EPU64": return Intrinsic._MM_CVTTPD_EPU64;
                case "_MM_MASK_CVTTPD_EPU64": return Intrinsic._MM_MASK_CVTTPD_EPU64;
                case "_MM_MASKZ_CVTTPD_EPU64": return Intrinsic._MM_MASKZ_CVTTPD_EPU64;
                case "_MM256_CVTTPD_EPU64": return Intrinsic._MM256_CVTTPD_EPU64;
                case "_MM256_MASK_CVTTPD_EPU64": return Intrinsic._MM256_MASK_CVTTPD_EPU64;
                case "_MM256_MASKZ_CVTTPD_EPU64": return Intrinsic._MM256_MASKZ_CVTTPD_EPU64;
                case "_MM512_CVTTPD_EPU64": return Intrinsic._MM512_CVTTPD_EPU64;
                case "_MM512_MASK_CVTTPD_EPU64": return Intrinsic._MM512_MASK_CVTTPD_EPU64;
                case "_MM512_MASKZ_CVTTPD_EPU64": return Intrinsic._MM512_MASKZ_CVTTPD_EPU64;
                case "_MM_CVTTPD_PI32": return Intrinsic._MM_CVTTPD_PI32;
                case "_MM_CVTTPS_EPI32": return Intrinsic._MM_CVTTPS_EPI32;
                case "_MM_MASK_CVTTPS_EPI32": return Intrinsic._MM_MASK_CVTTPS_EPI32;
                case "_MM_MASKZ_CVTTPS_EPI32": return Intrinsic._MM_MASKZ_CVTTPS_EPI32;
                case "_MM256_CVTTPS_EPI32": return Intrinsic._MM256_CVTTPS_EPI32;
                case "_MM256_MASK_CVTTPS_EPI32": return Intrinsic._MM256_MASK_CVTTPS_EPI32;
                case "_MM256_MASKZ_CVTTPS_EPI32": return Intrinsic._MM256_MASKZ_CVTTPS_EPI32;
                case "_MM512_CVTTPS_EPI32": return Intrinsic._MM512_CVTTPS_EPI32;
                case "_MM512_MASK_CVTTPS_EPI32": return Intrinsic._MM512_MASK_CVTTPS_EPI32;
                case "_MM512_MASKZ_CVTTPS_EPI32": return Intrinsic._MM512_MASKZ_CVTTPS_EPI32;
                case "_MM_CVTTPS_EPI64": return Intrinsic._MM_CVTTPS_EPI64;
                case "_MM_MASK_CVTTPS_EPI64": return Intrinsic._MM_MASK_CVTTPS_EPI64;
                case "_MM_MASKZ_CVTTPS_EPI64": return Intrinsic._MM_MASKZ_CVTTPS_EPI64;
                case "_MM256_CVTTPS_EPI64": return Intrinsic._MM256_CVTTPS_EPI64;
                case "_MM256_MASK_CVTTPS_EPI64": return Intrinsic._MM256_MASK_CVTTPS_EPI64;
                case "_MM256_MASKZ_CVTTPS_EPI64": return Intrinsic._MM256_MASKZ_CVTTPS_EPI64;
                case "_MM512_CVTTPS_EPI64": return Intrinsic._MM512_CVTTPS_EPI64;
                case "_MM512_MASK_CVTTPS_EPI64": return Intrinsic._MM512_MASK_CVTTPS_EPI64;
                case "_MM512_MASKZ_CVTTPS_EPI64": return Intrinsic._MM512_MASKZ_CVTTPS_EPI64;
                case "_MM_CVTTPS_EPU32": return Intrinsic._MM_CVTTPS_EPU32;
                case "_MM_MASK_CVTTPS_EPU32": return Intrinsic._MM_MASK_CVTTPS_EPU32;
                case "_MM_MASKZ_CVTTPS_EPU32": return Intrinsic._MM_MASKZ_CVTTPS_EPU32;
                case "_MM256_CVTTPS_EPU32": return Intrinsic._MM256_CVTTPS_EPU32;
                case "_MM256_MASK_CVTTPS_EPU32": return Intrinsic._MM256_MASK_CVTTPS_EPU32;
                case "_MM256_MASKZ_CVTTPS_EPU32": return Intrinsic._MM256_MASKZ_CVTTPS_EPU32;
                case "_MM512_CVTTPS_EPU32": return Intrinsic._MM512_CVTTPS_EPU32;
                case "_MM512_MASK_CVTTPS_EPU32": return Intrinsic._MM512_MASK_CVTTPS_EPU32;
                case "_MM512_MASKZ_CVTTPS_EPU32": return Intrinsic._MM512_MASKZ_CVTTPS_EPU32;
                case "_MM_CVTTPS_EPU64": return Intrinsic._MM_CVTTPS_EPU64;
                case "_MM_MASK_CVTTPS_EPU64": return Intrinsic._MM_MASK_CVTTPS_EPU64;
                case "_MM_MASKZ_CVTTPS_EPU64": return Intrinsic._MM_MASKZ_CVTTPS_EPU64;
                case "_MM256_CVTTPS_EPU64": return Intrinsic._MM256_CVTTPS_EPU64;
                case "_MM256_MASK_CVTTPS_EPU64": return Intrinsic._MM256_MASK_CVTTPS_EPU64;
                case "_MM256_MASKZ_CVTTPS_EPU64": return Intrinsic._MM256_MASKZ_CVTTPS_EPU64;
                case "_MM512_CVTTPS_EPU64": return Intrinsic._MM512_CVTTPS_EPU64;
                case "_MM512_MASK_CVTTPS_EPU64": return Intrinsic._MM512_MASK_CVTTPS_EPU64;
                case "_MM512_MASKZ_CVTTPS_EPU64": return Intrinsic._MM512_MASKZ_CVTTPS_EPU64;
                case "_MM_CVTTPS_PI32": return Intrinsic._MM_CVTTPS_PI32;
                case "_MM_CVTTSD_I32": return Intrinsic._MM_CVTTSD_I32;
                case "_MM_CVTTSD_I64": return Intrinsic._MM_CVTTSD_I64;
                case "_MM_CVTTSD_SI32": return Intrinsic._MM_CVTTSD_SI32;
                case "_MM_CVTTSD_SI64": return Intrinsic._MM_CVTTSD_SI64;
                case "_MM_CVTTSD_SI64X": return Intrinsic._MM_CVTTSD_SI64X;
                case "_MM_CVTTSD_U32": return Intrinsic._MM_CVTTSD_U32;
                case "_MM_CVTTSD_U64": return Intrinsic._MM_CVTTSD_U64;
                case "_MM_CVTTSS_I32": return Intrinsic._MM_CVTTSS_I32;
                case "_MM_CVTTSS_I64": return Intrinsic._MM_CVTTSS_I64;
                case "_MM_CVTTSS_SI32": return Intrinsic._MM_CVTTSS_SI32;
                case "_MM_CVTTSS_SI64": return Intrinsic._MM_CVTTSS_SI64;
                case "_MM_CVTTSS_U32": return Intrinsic._MM_CVTTSS_U32;
                case "_MM_CVTTSS_U64": return Intrinsic._MM_CVTTSS_U64;
                case "_MM_CVTU32_SD": return Intrinsic._MM_CVTU32_SD;
                case "_MM_CVTU32_SS": return Intrinsic._MM_CVTU32_SS;
                case "_MM_CVTU64_SD": return Intrinsic._MM_CVTU64_SD;
                case "_MM_CVTU64_SS": return Intrinsic._MM_CVTU64_SS;
                case "_MM_CVTUSEPI16_EPI8": return Intrinsic._MM_CVTUSEPI16_EPI8;
                case "_MM_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM_MASK_CVTUSEPI16_EPI8;
                case "_MM_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI16_EPI8;
                case "_MM256_CVTUSEPI16_EPI8": return Intrinsic._MM256_CVTUSEPI16_EPI8;
                case "_MM256_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI16_EPI8;
                case "_MM256_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI16_EPI8;
                case "_MM512_CVTUSEPI16_EPI8": return Intrinsic._MM512_CVTUSEPI16_EPI8;
                case "_MM512_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI16_EPI8;
                case "_MM512_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI16_EPI8;
                case "_MM_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM_CVTUSEPI32_EPI16": return Intrinsic._MM_CVTUSEPI32_EPI16;
                case "_MM_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM_MASK_CVTUSEPI32_EPI16;
                case "_MM_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTUSEPI32_EPI16;
                case "_MM256_CVTUSEPI32_EPI16": return Intrinsic._MM256_CVTUSEPI32_EPI16;
                case "_MM256_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI32_EPI16;
                case "_MM256_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTUSEPI32_EPI16;
                case "_MM512_CVTUSEPI32_EPI16": return Intrinsic._MM512_CVTUSEPI32_EPI16;
                case "_MM512_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI32_EPI16;
                case "_MM512_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTUSEPI32_EPI16;
                case "_MM_CVTUSEPI32_EPI8": return Intrinsic._MM_CVTUSEPI32_EPI8;
                case "_MM_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM_MASK_CVTUSEPI32_EPI8;
                case "_MM_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI32_EPI8;
                case "_MM256_CVTUSEPI32_EPI8": return Intrinsic._MM256_CVTUSEPI32_EPI8;
                case "_MM256_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI32_EPI8;
                case "_MM256_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI32_EPI8;
                case "_MM512_CVTUSEPI32_EPI8": return Intrinsic._MM512_CVTUSEPI32_EPI8;
                case "_MM512_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI32_EPI8;
                case "_MM512_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI32_EPI8;
                case "_MM_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM_CVTUSEPI64_EPI16": return Intrinsic._MM_CVTUSEPI64_EPI16;
                case "_MM_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM_MASK_CVTUSEPI64_EPI16;
                case "_MM_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI16;
                case "_MM256_CVTUSEPI64_EPI16": return Intrinsic._MM256_CVTUSEPI64_EPI16;
                case "_MM256_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI16;
                case "_MM256_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI16;
                case "_MM512_CVTUSEPI64_EPI16": return Intrinsic._MM512_CVTUSEPI64_EPI16;
                case "_MM512_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI16;
                case "_MM512_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI16;
                case "_MM_CVTUSEPI64_EPI32": return Intrinsic._MM_CVTUSEPI64_EPI32;
                case "_MM_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM_MASK_CVTUSEPI64_EPI32;
                case "_MM_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI32;
                case "_MM256_CVTUSEPI64_EPI32": return Intrinsic._MM256_CVTUSEPI64_EPI32;
                case "_MM256_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI32;
                case "_MM256_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI32;
                case "_MM512_CVTUSEPI64_EPI32": return Intrinsic._MM512_CVTUSEPI64_EPI32;
                case "_MM512_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI32;
                case "_MM512_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI32;
                case "_MM_CVTUSEPI64_EPI8": return Intrinsic._MM_CVTUSEPI64_EPI8;
                case "_MM_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM_MASK_CVTUSEPI64_EPI8;
                case "_MM_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI8;
                case "_MM256_CVTUSEPI64_EPI8": return Intrinsic._MM256_CVTUSEPI64_EPI8;
                case "_MM256_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI8;
                case "_MM256_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI8;
                case "_MM512_CVTUSEPI64_EPI8": return Intrinsic._MM512_CVTUSEPI64_EPI8;
                case "_MM512_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI8;
                case "_MM512_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI8;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM_DBSAD_EPU8": return Intrinsic._MM_DBSAD_EPU8;
                case "_MM_MASK_DBSAD_EPU8": return Intrinsic._MM_MASK_DBSAD_EPU8;
                case "_MM_MASKZ_DBSAD_EPU8": return Intrinsic._MM_MASKZ_DBSAD_EPU8;
                case "_MM256_DBSAD_EPU8": return Intrinsic._MM256_DBSAD_EPU8;
                case "_MM256_MASK_DBSAD_EPU8": return Intrinsic._MM256_MASK_DBSAD_EPU8;
                case "_MM256_MASKZ_DBSAD_EPU8": return Intrinsic._MM256_MASKZ_DBSAD_EPU8;
                case "_MM512_DBSAD_EPU8": return Intrinsic._MM512_DBSAD_EPU8;
                case "_MM512_MASK_DBSAD_EPU8": return Intrinsic._MM512_MASK_DBSAD_EPU8;
                case "_MM512_MASKZ_DBSAD_EPU8": return Intrinsic._MM512_MASKZ_DBSAD_EPU8;
                case "_MM_DELAY_32": return Intrinsic._MM_DELAY_32;
                case "_MM_DELAY_64": return Intrinsic._MM_DELAY_64;
                case "_MM_DIV_EPI16": return Intrinsic._MM_DIV_EPI16;
                case "_MM256_DIV_EPI16": return Intrinsic._MM256_DIV_EPI16;
                case "_MM512_DIV_EPI16": return Intrinsic._MM512_DIV_EPI16;
                case "_MM_DIV_EPI32": return Intrinsic._MM_DIV_EPI32;
                case "_MM256_DIV_EPI32": return Intrinsic._MM256_DIV_EPI32;
                case "_MM512_DIV_EPI32": return Intrinsic._MM512_DIV_EPI32;
                case "_MM512_MASK_DIV_EPI32": return Intrinsic._MM512_MASK_DIV_EPI32;
                case "_MM_DIV_EPI64": return Intrinsic._MM_DIV_EPI64;
                case "_MM256_DIV_EPI64": return Intrinsic._MM256_DIV_EPI64;
                case "_MM512_DIV_EPI64": return Intrinsic._MM512_DIV_EPI64;
                case "_MM_DIV_EPI8": return Intrinsic._MM_DIV_EPI8;
                case "_MM256_DIV_EPI8": return Intrinsic._MM256_DIV_EPI8;
                case "_MM512_DIV_EPI8": return Intrinsic._MM512_DIV_EPI8;
                case "_MM_DIV_EPU16": return Intrinsic._MM_DIV_EPU16;
                case "_MM256_DIV_EPU16": return Intrinsic._MM256_DIV_EPU16;
                case "_MM512_DIV_EPU16": return Intrinsic._MM512_DIV_EPU16;
                case "_MM_DIV_EPU32": return Intrinsic._MM_DIV_EPU32;
                case "_MM256_DIV_EPU32": return Intrinsic._MM256_DIV_EPU32;
                case "_MM512_DIV_EPU32": return Intrinsic._MM512_DIV_EPU32;
                case "_MM512_MASK_DIV_EPU32": return Intrinsic._MM512_MASK_DIV_EPU32;
                case "_MM_DIV_EPU64": return Intrinsic._MM_DIV_EPU64;
                case "_MM256_DIV_EPU64": return Intrinsic._MM256_DIV_EPU64;
                case "_MM512_DIV_EPU64": return Intrinsic._MM512_DIV_EPU64;
                case "_MM_DIV_EPU8": return Intrinsic._MM_DIV_EPU8;
                case "_MM256_DIV_EPU8": return Intrinsic._MM256_DIV_EPU8;
                case "_MM512_DIV_EPU8": return Intrinsic._MM512_DIV_EPU8;
                case "_MM_DIV_PD": return Intrinsic._MM_DIV_PD;
                case "_MM_MASK_DIV_PD": return Intrinsic._MM_MASK_DIV_PD;
                case "_MM_MASKZ_DIV_PD": return Intrinsic._MM_MASKZ_DIV_PD;
                case "_MM256_DIV_PD": return Intrinsic._MM256_DIV_PD;
                case "_MM256_MASK_DIV_PD": return Intrinsic._MM256_MASK_DIV_PD;
                case "_MM256_MASKZ_DIV_PD": return Intrinsic._MM256_MASKZ_DIV_PD;
                case "_MM512_DIV_PD": return Intrinsic._MM512_DIV_PD;
                case "_MM512_MASK_DIV_PD": return Intrinsic._MM512_MASK_DIV_PD;
                case "_MM512_MASKZ_DIV_PD": return Intrinsic._MM512_MASKZ_DIV_PD;
                case "_MM_DIV_PS": return Intrinsic._MM_DIV_PS;
                case "_MM_MASK_DIV_PS": return Intrinsic._MM_MASK_DIV_PS;
                case "_MM_MASKZ_DIV_PS": return Intrinsic._MM_MASKZ_DIV_PS;
                case "_MM256_DIV_PS": return Intrinsic._MM256_DIV_PS;
                case "_MM256_MASK_DIV_PS": return Intrinsic._MM256_MASK_DIV_PS;
                case "_MM256_MASKZ_DIV_PS": return Intrinsic._MM256_MASKZ_DIV_PS;
                case "_MM512_DIV_PS": return Intrinsic._MM512_DIV_PS;
                case "_MM512_MASK_DIV_PS": return Intrinsic._MM512_MASK_DIV_PS;
                case "_MM512_MASKZ_DIV_PS": return Intrinsic._MM512_MASKZ_DIV_PS;
                case "_MM512_DIV_ROUND_PD": return Intrinsic._MM512_DIV_ROUND_PD;
                case "_MM512_MASK_DIV_ROUND_PD": return Intrinsic._MM512_MASK_DIV_ROUND_PD;
                case "_MM512_MASKZ_DIV_ROUND_PD": return Intrinsic._MM512_MASKZ_DIV_ROUND_PD;
                case "_MM512_DIV_ROUND_PS": return Intrinsic._MM512_DIV_ROUND_PS;
                case "_MM512_MASK_DIV_ROUND_PS": return Intrinsic._MM512_MASK_DIV_ROUND_PS;
                case "_MM512_MASKZ_DIV_ROUND_PS": return Intrinsic._MM512_MASKZ_DIV_ROUND_PS;
                case "_MM_DIV_ROUND_SD": return Intrinsic._MM_DIV_ROUND_SD;
                case "_MM_MASK_DIV_ROUND_SD": return Intrinsic._MM_MASK_DIV_ROUND_SD;
                case "_MM_MASKZ_DIV_ROUND_SD": return Intrinsic._MM_MASKZ_DIV_ROUND_SD;
                case "_MM_DIV_ROUND_SS": return Intrinsic._MM_DIV_ROUND_SS;
                case "_MM_MASK_DIV_ROUND_SS": return Intrinsic._MM_MASK_DIV_ROUND_SS;
                case "_MM_MASKZ_DIV_ROUND_SS": return Intrinsic._MM_MASKZ_DIV_ROUND_SS;
                case "_MM_DIV_SD": return Intrinsic._MM_DIV_SD;
                case "_MM_MASK_DIV_SD": return Intrinsic._MM_MASK_DIV_SD;
                case "_MM_MASKZ_DIV_SD": return Intrinsic._MM_MASKZ_DIV_SD;
                case "_MM_DIV_SS": return Intrinsic._MM_DIV_SS;
                case "_MM_MASK_DIV_SS": return Intrinsic._MM_MASK_DIV_SS;
                case "_MM_MASKZ_DIV_SS": return Intrinsic._MM_MASKZ_DIV_SS;
                case "_MM_DP_PD": return Intrinsic._MM_DP_PD;
                case "_MM_DP_PS": return Intrinsic._MM_DP_PS;
                case "_MM256_DP_PS": return Intrinsic._MM256_DP_PS;
                case "_M_EMPTY": return Intrinsic._M_EMPTY;
                case "_MM_EMPTY": return Intrinsic._MM_EMPTY;
                case "_MM_ERF_PD": return Intrinsic._MM_ERF_PD;
                case "_MM256_ERF_PD": return Intrinsic._MM256_ERF_PD;
                case "_MM512_ERF_PD": return Intrinsic._MM512_ERF_PD;
                case "_MM512_MASK_ERF_PD": return Intrinsic._MM512_MASK_ERF_PD;
                case "_MM_ERF_PS": return Intrinsic._MM_ERF_PS;
                case "_MM256_ERF_PS": return Intrinsic._MM256_ERF_PS;
                case "_MM512_ERF_PS": return Intrinsic._MM512_ERF_PS;
                case "_MM512_MASK_ERF_PS": return Intrinsic._MM512_MASK_ERF_PS;
                case "_MM_ERFC_PD": return Intrinsic._MM_ERFC_PD;
                case "_MM256_ERFC_PD": return Intrinsic._MM256_ERFC_PD;
                case "_MM512_ERFC_PD": return Intrinsic._MM512_ERFC_PD;
                case "_MM512_MASK_ERFC_PD": return Intrinsic._MM512_MASK_ERFC_PD;
                case "_MM_ERFC_PS": return Intrinsic._MM_ERFC_PS;
                case "_MM256_ERFC_PS": return Intrinsic._MM256_ERFC_PS;
                case "_MM512_ERFC_PS": return Intrinsic._MM512_ERFC_PS;
                case "_MM512_MASK_ERFC_PS": return Intrinsic._MM512_MASK_ERFC_PS;
                case "_MM_ERFCINV_PD": return Intrinsic._MM_ERFCINV_PD;
                case "_MM256_ERFCINV_PD": return Intrinsic._MM256_ERFCINV_PD;
                case "_MM512_ERFCINV_PD": return Intrinsic._MM512_ERFCINV_PD;
                case "_MM512_MASK_ERFCINV_PD": return Intrinsic._MM512_MASK_ERFCINV_PD;
                case "_MM_ERFCINV_PS": return Intrinsic._MM_ERFCINV_PS;
                case "_MM256_ERFCINV_PS": return Intrinsic._MM256_ERFCINV_PS;
                case "_MM512_ERFCINV_PS": return Intrinsic._MM512_ERFCINV_PS;
                case "_MM512_MASK_ERFCINV_PS": return Intrinsic._MM512_MASK_ERFCINV_PS;
                case "_MM_ERFINV_PD": return Intrinsic._MM_ERFINV_PD;
                case "_MM256_ERFINV_PD": return Intrinsic._MM256_ERFINV_PD;
                case "_MM512_ERFINV_PD": return Intrinsic._MM512_ERFINV_PD;
                case "_MM512_MASK_ERFINV_PD": return Intrinsic._MM512_MASK_ERFINV_PD;
                case "_MM_ERFINV_PS": return Intrinsic._MM_ERFINV_PS;
                case "_MM256_ERFINV_PS": return Intrinsic._MM256_ERFINV_PS;
                case "_MM512_ERFINV_PS": return Intrinsic._MM512_ERFINV_PS;
                case "_MM512_MASK_ERFINV_PS": return Intrinsic._MM512_MASK_ERFINV_PS;
                case "_MM_EXP_PD": return Intrinsic._MM_EXP_PD;
                case "_MM256_EXP_PD": return Intrinsic._MM256_EXP_PD;
                case "_MM512_EXP_PD": return Intrinsic._MM512_EXP_PD;
                case "_MM512_MASK_EXP_PD": return Intrinsic._MM512_MASK_EXP_PD;
                case "_MM_EXP_PS": return Intrinsic._MM_EXP_PS;
                case "_MM256_EXP_PS": return Intrinsic._MM256_EXP_PS;
                case "_MM512_EXP_PS": return Intrinsic._MM512_EXP_PS;
                case "_MM512_MASK_EXP_PS": return Intrinsic._MM512_MASK_EXP_PS;
                case "_MM_EXP10_PD": return Intrinsic._MM_EXP10_PD;
                case "_MM256_EXP10_PD": return Intrinsic._MM256_EXP10_PD;
                case "_MM512_EXP10_PD": return Intrinsic._MM512_EXP10_PD;
                case "_MM512_MASK_EXP10_PD": return Intrinsic._MM512_MASK_EXP10_PD;
                case "_MM_EXP10_PS": return Intrinsic._MM_EXP10_PS;
                case "_MM256_EXP10_PS": return Intrinsic._MM256_EXP10_PS;
                case "_MM512_EXP10_PS": return Intrinsic._MM512_EXP10_PS;
                case "_MM512_MASK_EXP10_PS": return Intrinsic._MM512_MASK_EXP10_PS;
                case "_MM_EXP2_PD": return Intrinsic._MM_EXP2_PD;
                case "_MM256_EXP2_PD": return Intrinsic._MM256_EXP2_PD;
                case "_MM512_EXP2_PD": return Intrinsic._MM512_EXP2_PD;
                case "_MM512_MASK_EXP2_PD": return Intrinsic._MM512_MASK_EXP2_PD;
                case "_MM_EXP2_PS": return Intrinsic._MM_EXP2_PS;
                case "_MM256_EXP2_PS": return Intrinsic._MM256_EXP2_PS;
                case "_MM512_EXP2_PS": return Intrinsic._MM512_EXP2_PS;
                case "_MM512_MASK_EXP2_PS": return Intrinsic._MM512_MASK_EXP2_PS;
                case "_MM512_EXP223_PS": return Intrinsic._MM512_EXP223_PS;
                case "_MM512_MASK_EXP223_PS": return Intrinsic._MM512_MASK_EXP223_PS;
                case "_MM512_EXP2A23_PD": return Intrinsic._MM512_EXP2A23_PD;
                case "_MM512_MASK_EXP2A23_PD": return Intrinsic._MM512_MASK_EXP2A23_PD;
                case "_MM512_MASKZ_EXP2A23_PD": return Intrinsic._MM512_MASKZ_EXP2A23_PD;
                case "_MM512_EXP2A23_PS": return Intrinsic._MM512_EXP2A23_PS;
                case "_MM512_MASK_EXP2A23_PS": return Intrinsic._MM512_MASK_EXP2A23_PS;
                case "_MM512_MASKZ_EXP2A23_PS": return Intrinsic._MM512_MASKZ_EXP2A23_PS;
                case "_MM512_EXP2A23_ROUND_PD": return Intrinsic._MM512_EXP2A23_ROUND_PD;
                case "_MM512_MASK_EXP2A23_ROUND_PD": return Intrinsic._MM512_MASK_EXP2A23_ROUND_PD;
                case "_MM512_MASKZ_EXP2A23_ROUND_PD": return Intrinsic._MM512_MASKZ_EXP2A23_ROUND_PD;
                case "_MM512_EXP2A23_ROUND_PS": return Intrinsic._MM512_EXP2A23_ROUND_PS;
                case "_MM512_MASK_EXP2A23_ROUND_PS": return Intrinsic._MM512_MASK_EXP2A23_ROUND_PS;
                case "_MM512_MASKZ_EXP2A23_ROUND_PS": return Intrinsic._MM512_MASKZ_EXP2A23_ROUND_PS;
                case "_MM_MASK_EXPAND_EPI32": return Intrinsic._MM_MASK_EXPAND_EPI32;
                case "_MM_MASKZ_EXPAND_EPI32": return Intrinsic._MM_MASKZ_EXPAND_EPI32;
                case "_MM256_MASK_EXPAND_EPI32": return Intrinsic._MM256_MASK_EXPAND_EPI32;
                case "_MM256_MASKZ_EXPAND_EPI32": return Intrinsic._MM256_MASKZ_EXPAND_EPI32;
                case "_MM512_MASK_EXPAND_EPI32": return Intrinsic._MM512_MASK_EXPAND_EPI32;
                case "_MM512_MASKZ_EXPAND_EPI32": return Intrinsic._MM512_MASKZ_EXPAND_EPI32;
                case "_MM_MASK_EXPAND_EPI64": return Intrinsic._MM_MASK_EXPAND_EPI64;
                case "_MM_MASKZ_EXPAND_EPI64": return Intrinsic._MM_MASKZ_EXPAND_EPI64;
                case "_MM256_MASK_EXPAND_EPI64": return Intrinsic._MM256_MASK_EXPAND_EPI64;
                case "_MM256_MASKZ_EXPAND_EPI64": return Intrinsic._MM256_MASKZ_EXPAND_EPI64;
                case "_MM512_MASK_EXPAND_EPI64": return Intrinsic._MM512_MASK_EXPAND_EPI64;
                case "_MM512_MASKZ_EXPAND_EPI64": return Intrinsic._MM512_MASKZ_EXPAND_EPI64;
                case "_MM_MASK_EXPAND_PD": return Intrinsic._MM_MASK_EXPAND_PD;
                case "_MM_MASKZ_EXPAND_PD": return Intrinsic._MM_MASKZ_EXPAND_PD;
                case "_MM256_MASK_EXPAND_PD": return Intrinsic._MM256_MASK_EXPAND_PD;
                case "_MM256_MASKZ_EXPAND_PD": return Intrinsic._MM256_MASKZ_EXPAND_PD;
                case "_MM512_MASK_EXPAND_PD": return Intrinsic._MM512_MASK_EXPAND_PD;
                case "_MM512_MASKZ_EXPAND_PD": return Intrinsic._MM512_MASKZ_EXPAND_PD;
                case "_MM_MASK_EXPAND_PS": return Intrinsic._MM_MASK_EXPAND_PS;
                case "_MM_MASKZ_EXPAND_PS": return Intrinsic._MM_MASKZ_EXPAND_PS;
                case "_MM256_MASK_EXPAND_PS": return Intrinsic._MM256_MASK_EXPAND_PS;
                case "_MM256_MASKZ_EXPAND_PS": return Intrinsic._MM256_MASKZ_EXPAND_PS;
                case "_MM512_MASK_EXPAND_PS": return Intrinsic._MM512_MASK_EXPAND_PS;
                case "_MM512_MASKZ_EXPAND_PS": return Intrinsic._MM512_MASKZ_EXPAND_PS;
                case "_MM_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM_MASK_EXPANDLOADU_EPI32;
                case "_MM_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM_MASKZ_EXPANDLOADU_EPI32;
                case "_MM256_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM256_MASK_EXPANDLOADU_EPI32;
                case "_MM256_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM256_MASKZ_EXPANDLOADU_EPI32;
                case "_MM512_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM512_MASK_EXPANDLOADU_EPI32;
                case "_MM512_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM512_MASKZ_EXPANDLOADU_EPI32;
                case "_MM_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM_MASK_EXPANDLOADU_EPI64;
                case "_MM_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM_MASKZ_EXPANDLOADU_EPI64;
                case "_MM256_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM256_MASK_EXPANDLOADU_EPI64;
                case "_MM256_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM256_MASKZ_EXPANDLOADU_EPI64;
                case "_MM512_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM512_MASK_EXPANDLOADU_EPI64;
                case "_MM512_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM512_MASKZ_EXPANDLOADU_EPI64;
                case "_MM_MASK_EXPANDLOADU_PD": return Intrinsic._MM_MASK_EXPANDLOADU_PD;
                case "_MM_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM_MASKZ_EXPANDLOADU_PD;
                case "_MM256_MASK_EXPANDLOADU_PD": return Intrinsic._MM256_MASK_EXPANDLOADU_PD;
                case "_MM256_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM256_MASKZ_EXPANDLOADU_PD;
                case "_MM512_MASK_EXPANDLOADU_PD": return Intrinsic._MM512_MASK_EXPANDLOADU_PD;
                case "_MM512_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM512_MASKZ_EXPANDLOADU_PD;
                case "_MM_MASK_EXPANDLOADU_PS": return Intrinsic._MM_MASK_EXPANDLOADU_PS;
                case "_MM_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM_MASKZ_EXPANDLOADU_PS;
                case "_MM256_MASK_EXPANDLOADU_PS": return Intrinsic._MM256_MASK_EXPANDLOADU_PS;
                case "_MM256_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM256_MASKZ_EXPANDLOADU_PS;
                case "_MM512_MASK_EXPANDLOADU_PS": return Intrinsic._MM512_MASK_EXPANDLOADU_PS;
                case "_MM512_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM512_MASKZ_EXPANDLOADU_PS;
                case "_MM_EXPM1_PD": return Intrinsic._MM_EXPM1_PD;
                case "_MM256_EXPM1_PD": return Intrinsic._MM256_EXPM1_PD;
                case "_MM512_EXPM1_PD": return Intrinsic._MM512_EXPM1_PD;
                case "_MM512_MASK_EXPM1_PD": return Intrinsic._MM512_MASK_EXPM1_PD;
                case "_MM_EXPM1_PS": return Intrinsic._MM_EXPM1_PS;
                case "_MM256_EXPM1_PS": return Intrinsic._MM256_EXPM1_PS;
                case "_MM512_EXPM1_PS": return Intrinsic._MM512_EXPM1_PS;
                case "_MM512_MASK_EXPM1_PS": return Intrinsic._MM512_MASK_EXPM1_PS;
                case "_MM512_EXTLOAD_EPI32": return Intrinsic._MM512_EXTLOAD_EPI32;
                case "_MM512_MASK_EXTLOAD_EPI32": return Intrinsic._MM512_MASK_EXTLOAD_EPI32;
                case "_MM512_EXTLOAD_EPI64": return Intrinsic._MM512_EXTLOAD_EPI64;
                case "_MM512_MASK_EXTLOAD_EPI64": return Intrinsic._MM512_MASK_EXTLOAD_EPI64;
                case "_MM512_EXTLOAD_PD": return Intrinsic._MM512_EXTLOAD_PD;
                case "_MM512_MASK_EXTLOAD_PD": return Intrinsic._MM512_MASK_EXTLOAD_PD;
                case "_MM512_EXTLOAD_PS": return Intrinsic._MM512_EXTLOAD_PS;
                case "_MM512_MASK_EXTLOAD_PS": return Intrinsic._MM512_MASK_EXTLOAD_PS;
                case "_MM512_EXTLOADUNPACKHI_EPI32": return Intrinsic._MM512_EXTLOADUNPACKHI_EPI32;
                case "_MM512_MASK_EXTLOADUNPACKHI_EPI32": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_EPI32;
                case "_MM512_EXTLOADUNPACKHI_EPI64": return Intrinsic._MM512_EXTLOADUNPACKHI_EPI64;
                case "_MM512_MASK_EXTLOADUNPACKHI_EPI64": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_EPI64;
                case "_MM512_EXTLOADUNPACKHI_PD": return Intrinsic._MM512_EXTLOADUNPACKHI_PD;
                case "_MM512_MASK_EXTLOADUNPACKHI_PD": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_PD;
                case "_MM512_EXTLOADUNPACKHI_PS": return Intrinsic._MM512_EXTLOADUNPACKHI_PS;
                case "_MM512_MASK_EXTLOADUNPACKHI_PS": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_PS;
                case "_MM512_EXTLOADUNPACKLO_EPI32": return Intrinsic._MM512_EXTLOADUNPACKLO_EPI32;
                case "_MM512_MASK_EXTLOADUNPACKLO_EPI32": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_EPI32;
                case "_MM512_EXTLOADUNPACKLO_EPI64": return Intrinsic._MM512_EXTLOADUNPACKLO_EPI64;
                case "_MM512_MASK_EXTLOADUNPACKLO_EPI64": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_EPI64;
                case "_MM512_EXTLOADUNPACKLO_PD": return Intrinsic._MM512_EXTLOADUNPACKLO_PD;
                case "_MM512_MASK_EXTLOADUNPACKLO_PD": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_PD;
                case "_MM512_EXTLOADUNPACKLO_PS": return Intrinsic._MM512_EXTLOADUNPACKLO_PS;
                case "_MM512_MASK_EXTLOADUNPACKLO_PS": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_PS;
                case "_MM512_EXTPACKSTOREHI_EPI32": return Intrinsic._MM512_EXTPACKSTOREHI_EPI32;
                case "_MM512_MASK_EXTPACKSTOREHI_EPI32": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_EPI32;
                case "_MM512_EXTPACKSTOREHI_EPI64": return Intrinsic._MM512_EXTPACKSTOREHI_EPI64;
                case "_MM512_MASK_EXTPACKSTOREHI_EPI64": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_EPI64;
                case "_MM512_EXTPACKSTOREHI_PD": return Intrinsic._MM512_EXTPACKSTOREHI_PD;
                case "_MM512_MASK_EXTPACKSTOREHI_PD": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_PD;
                case "_MM512_EXTPACKSTOREHI_PS": return Intrinsic._MM512_EXTPACKSTOREHI_PS;
                case "_MM512_MASK_EXTPACKSTOREHI_PS": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_PS;
                case "_MM512_EXTPACKSTORELO_EPI32": return Intrinsic._MM512_EXTPACKSTORELO_EPI32;
                case "_MM512_MASK_EXTPACKSTORELO_EPI32": return Intrinsic._MM512_MASK_EXTPACKSTORELO_EPI32;
                case "_MM512_EXTPACKSTORELO_EPI64": return Intrinsic._MM512_EXTPACKSTORELO_EPI64;
                case "_MM512_MASK_EXTPACKSTORELO_EPI64": return Intrinsic._MM512_MASK_EXTPACKSTORELO_EPI64;
                case "_MM512_EXTPACKSTORELO_PD": return Intrinsic._MM512_EXTPACKSTORELO_PD;
                case "_MM512_MASK_EXTPACKSTORELO_PD": return Intrinsic._MM512_MASK_EXTPACKSTORELO_PD;
                case "_MM512_EXTPACKSTORELO_PS": return Intrinsic._MM512_EXTPACKSTORELO_PS;
                case "_MM512_MASK_EXTPACKSTORELO_PS": return Intrinsic._MM512_MASK_EXTPACKSTORELO_PS;
                case "_MM_EXTRACT_EPI16": return Intrinsic._MM_EXTRACT_EPI16;
                case "_MM256_EXTRACT_EPI16": return Intrinsic._MM256_EXTRACT_EPI16;
                case "_MM_EXTRACT_EPI32": return Intrinsic._MM_EXTRACT_EPI32;
                case "_MM256_EXTRACT_EPI32": return Intrinsic._MM256_EXTRACT_EPI32;
                case "_MM_EXTRACT_EPI64": return Intrinsic._MM_EXTRACT_EPI64;
                case "_MM256_EXTRACT_EPI64": return Intrinsic._MM256_EXTRACT_EPI64;
                case "_MM_EXTRACT_EPI8": return Intrinsic._MM_EXTRACT_EPI8;
                case "_MM256_EXTRACT_EPI8": return Intrinsic._MM256_EXTRACT_EPI8;
                case "_MM_EXTRACT_PI16": return Intrinsic._MM_EXTRACT_PI16;
                case "_MM_EXTRACT_PS": return Intrinsic._MM_EXTRACT_PS;
                case "_MM256_EXTRACTF128_PD": return Intrinsic._MM256_EXTRACTF128_PD;
                case "_MM256_EXTRACTF128_PS": return Intrinsic._MM256_EXTRACTF128_PS;
                case "_MM256_EXTRACTF128_SI256": return Intrinsic._MM256_EXTRACTF128_SI256;
                case "_MM256_EXTRACTF32X4_PS": return Intrinsic._MM256_EXTRACTF32X4_PS;
                case "_MM256_MASK_EXTRACTF32X4_PS": return Intrinsic._MM256_MASK_EXTRACTF32X4_PS;
                case "_MM256_MASKZ_EXTRACTF32X4_PS": return Intrinsic._MM256_MASKZ_EXTRACTF32X4_PS;
                case "_MM512_EXTRACTF32X4_PS": return Intrinsic._MM512_EXTRACTF32X4_PS;
                case "_MM512_MASK_EXTRACTF32X4_PS": return Intrinsic._MM512_MASK_EXTRACTF32X4_PS;
                case "_MM512_MASKZ_EXTRACTF32X4_PS": return Intrinsic._MM512_MASKZ_EXTRACTF32X4_PS;
                case "_MM512_EXTRACTF32X8_PS": return Intrinsic._MM512_EXTRACTF32X8_PS;
                case "_MM512_MASK_EXTRACTF32X8_PS": return Intrinsic._MM512_MASK_EXTRACTF32X8_PS;
                case "_MM512_MASKZ_EXTRACTF32X8_PS": return Intrinsic._MM512_MASKZ_EXTRACTF32X8_PS;
                case "_MM256_EXTRACTF64X2_PD": return Intrinsic._MM256_EXTRACTF64X2_PD;
                case "_MM256_MASK_EXTRACTF64X2_PD": return Intrinsic._MM256_MASK_EXTRACTF64X2_PD;
                case "_MM256_MASKZ_EXTRACTF64X2_PD": return Intrinsic._MM256_MASKZ_EXTRACTF64X2_PD;
                case "_MM512_EXTRACTF64X2_PD": return Intrinsic._MM512_EXTRACTF64X2_PD;
                case "_MM512_MASK_EXTRACTF64X2_PD": return Intrinsic._MM512_MASK_EXTRACTF64X2_PD;
                case "_MM512_MASKZ_EXTRACTF64X2_PD": return Intrinsic._MM512_MASKZ_EXTRACTF64X2_PD;
                case "_MM512_EXTRACTF64X4_PD": return Intrinsic._MM512_EXTRACTF64X4_PD;
                case "_MM512_MASK_EXTRACTF64X4_PD": return Intrinsic._MM512_MASK_EXTRACTF64X4_PD;
                case "_MM512_MASKZ_EXTRACTF64X4_PD": return Intrinsic._MM512_MASKZ_EXTRACTF64X4_PD;
                case "_MM256_EXTRACTI128_SI256": return Intrinsic._MM256_EXTRACTI128_SI256;
                case "_MM256_EXTRACTI32X4_EPI32": return Intrinsic._MM256_EXTRACTI32X4_EPI32;
                case "_MM256_MASK_EXTRACTI32X4_EPI32": return Intrinsic._MM256_MASK_EXTRACTI32X4_EPI32;
                case "_MM256_MASKZ_EXTRACTI32X4_EPI32": return Intrinsic._MM256_MASKZ_EXTRACTI32X4_EPI32;
                case "_MM512_EXTRACTI32X4_EPI32": return Intrinsic._MM512_EXTRACTI32X4_EPI32;
                case "_MM512_MASK_EXTRACTI32X4_EPI32": return Intrinsic._MM512_MASK_EXTRACTI32X4_EPI32;
                case "_MM512_MASKZ_EXTRACTI32X4_EPI32": return Intrinsic._MM512_MASKZ_EXTRACTI32X4_EPI32;
                case "_MM512_EXTRACTI32X8_EPI32": return Intrinsic._MM512_EXTRACTI32X8_EPI32;
                case "_MM512_MASK_EXTRACTI32X8_EPI32": return Intrinsic._MM512_MASK_EXTRACTI32X8_EPI32;
                case "_MM512_MASKZ_EXTRACTI32X8_EPI32": return Intrinsic._MM512_MASKZ_EXTRACTI32X8_EPI32;
                case "_MM256_EXTRACTI64X2_EPI64": return Intrinsic._MM256_EXTRACTI64X2_EPI64;
                case "_MM256_MASK_EXTRACTI64X2_EPI64": return Intrinsic._MM256_MASK_EXTRACTI64X2_EPI64;
                case "_MM256_MASKZ_EXTRACTI64X2_EPI64": return Intrinsic._MM256_MASKZ_EXTRACTI64X2_EPI64;
                case "_MM512_EXTRACTI64X2_EPI64": return Intrinsic._MM512_EXTRACTI64X2_EPI64;
                case "_MM512_MASK_EXTRACTI64X2_EPI64": return Intrinsic._MM512_MASK_EXTRACTI64X2_EPI64;
                case "_MM512_MASKZ_EXTRACTI64X2_EPI64": return Intrinsic._MM512_MASKZ_EXTRACTI64X2_EPI64;
                case "_MM512_EXTRACTI64X4_EPI64": return Intrinsic._MM512_EXTRACTI64X4_EPI64;
                case "_MM512_MASK_EXTRACTI64X4_EPI64": return Intrinsic._MM512_MASK_EXTRACTI64X4_EPI64;
                case "_MM512_MASKZ_EXTRACTI64X4_EPI64": return Intrinsic._MM512_MASKZ_EXTRACTI64X4_EPI64;
                case "_MM512_EXTSTORE_EPI32": return Intrinsic._MM512_EXTSTORE_EPI32;
                case "_MM512_MASK_EXTSTORE_EPI32": return Intrinsic._MM512_MASK_EXTSTORE_EPI32;
                case "_MM512_EXTSTORE_EPI64": return Intrinsic._MM512_EXTSTORE_EPI64;
                case "_MM512_MASK_EXTSTORE_EPI64": return Intrinsic._MM512_MASK_EXTSTORE_EPI64;
                case "_MM512_EXTSTORE_PD": return Intrinsic._MM512_EXTSTORE_PD;
                case "_MM512_MASK_EXTSTORE_PD": return Intrinsic._MM512_MASK_EXTSTORE_PD;
                case "_MM512_EXTSTORE_PS": return Intrinsic._MM512_EXTSTORE_PS;
                case "_MM512_MASK_EXTSTORE_PS": return Intrinsic._MM512_MASK_EXTSTORE_PS;
                case "_MM_FIXUPIMM_PD": return Intrinsic._MM_FIXUPIMM_PD;
                case "_MM_MASK_FIXUPIMM_PD": return Intrinsic._MM_MASK_FIXUPIMM_PD;
                case "_MM_MASKZ_FIXUPIMM_PD": return Intrinsic._MM_MASKZ_FIXUPIMM_PD;
                case "_MM256_FIXUPIMM_PD": return Intrinsic._MM256_FIXUPIMM_PD;
                case "_MM256_MASK_FIXUPIMM_PD": return Intrinsic._MM256_MASK_FIXUPIMM_PD;
                case "_MM256_MASKZ_FIXUPIMM_PD": return Intrinsic._MM256_MASKZ_FIXUPIMM_PD;
                case "_MM512_FIXUPIMM_PD": return Intrinsic._MM512_FIXUPIMM_PD;
                case "_MM512_MASK_FIXUPIMM_PD": return Intrinsic._MM512_MASK_FIXUPIMM_PD;
                case "_MM512_MASKZ_FIXUPIMM_PD": return Intrinsic._MM512_MASKZ_FIXUPIMM_PD;
                case "_MM_FIXUPIMM_PS": return Intrinsic._MM_FIXUPIMM_PS;
                case "_MM_MASK_FIXUPIMM_PS": return Intrinsic._MM_MASK_FIXUPIMM_PS;
                case "_MM_MASKZ_FIXUPIMM_PS": return Intrinsic._MM_MASKZ_FIXUPIMM_PS;
                case "_MM256_FIXUPIMM_PS": return Intrinsic._MM256_FIXUPIMM_PS;
                case "_MM256_MASK_FIXUPIMM_PS": return Intrinsic._MM256_MASK_FIXUPIMM_PS;
                case "_MM256_MASKZ_FIXUPIMM_PS": return Intrinsic._MM256_MASKZ_FIXUPIMM_PS;
                case "_MM512_FIXUPIMM_PS": return Intrinsic._MM512_FIXUPIMM_PS;
                case "_MM512_MASK_FIXUPIMM_PS": return Intrinsic._MM512_MASK_FIXUPIMM_PS;
                case "_MM512_MASKZ_FIXUPIMM_PS": return Intrinsic._MM512_MASKZ_FIXUPIMM_PS;
                case "_MM512_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_FIXUPIMM_ROUND_PD;
                case "_MM512_MASK_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_MASK_FIXUPIMM_ROUND_PD;
                case "_MM512_MASKZ_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_MASKZ_FIXUPIMM_ROUND_PD;
                case "_MM512_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_FIXUPIMM_ROUND_PS;
                case "_MM512_MASK_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_MASK_FIXUPIMM_ROUND_PS;
                case "_MM512_MASKZ_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_MASKZ_FIXUPIMM_ROUND_PS;
                case "_MM_FIXUPIMM_ROUND_SD": return Intrinsic._MM_FIXUPIMM_ROUND_SD;
                case "_MM_MASK_FIXUPIMM_ROUND_SD": return Intrinsic._MM_MASK_FIXUPIMM_ROUND_SD;
                case "_MM_MASKZ_FIXUPIMM_ROUND_SD": return Intrinsic._MM_MASKZ_FIXUPIMM_ROUND_SD;
                case "_MM_FIXUPIMM_ROUND_SS": return Intrinsic._MM_FIXUPIMM_ROUND_SS;
                case "_MM_MASK_FIXUPIMM_ROUND_SS": return Intrinsic._MM_MASK_FIXUPIMM_ROUND_SS;
                case "_MM_MASKZ_FIXUPIMM_ROUND_SS": return Intrinsic._MM_MASKZ_FIXUPIMM_ROUND_SS;
                case "_MM_FIXUPIMM_SD": return Intrinsic._MM_FIXUPIMM_SD;
                case "_MM_MASK_FIXUPIMM_SD": return Intrinsic._MM_MASK_FIXUPIMM_SD;
                case "_MM_MASKZ_FIXUPIMM_SD": return Intrinsic._MM_MASKZ_FIXUPIMM_SD;
                case "_MM_FIXUPIMM_SS": return Intrinsic._MM_FIXUPIMM_SS;
                case "_MM_MASK_FIXUPIMM_SS": return Intrinsic._MM_MASK_FIXUPIMM_SS;
                case "_MM_MASKZ_FIXUPIMM_SS": return Intrinsic._MM_MASKZ_FIXUPIMM_SS;
                case "_MM512_FIXUPNAN_PD": return Intrinsic._MM512_FIXUPNAN_PD;
                case "_MM512_MASK_FIXUPNAN_PD": return Intrinsic._MM512_MASK_FIXUPNAN_PD;
                case "_MM512_FIXUPNAN_PS": return Intrinsic._MM512_FIXUPNAN_PS;
                case "_MM512_MASK_FIXUPNAN_PS": return Intrinsic._MM512_MASK_FIXUPNAN_PS;
                case "_MM_FLOOR_PD": return Intrinsic._MM_FLOOR_PD;
                case "_MM256_FLOOR_PD": return Intrinsic._MM256_FLOOR_PD;
                case "_MM512_FLOOR_PD": return Intrinsic._MM512_FLOOR_PD;
                case "_MM512_MASK_FLOOR_PD": return Intrinsic._MM512_MASK_FLOOR_PD;
                case "_MM_FLOOR_PS": return Intrinsic._MM_FLOOR_PS;
                case "_MM256_FLOOR_PS": return Intrinsic._MM256_FLOOR_PS;
                case "_MM512_FLOOR_PS": return Intrinsic._MM512_FLOOR_PS;
                case "_MM512_MASK_FLOOR_PS": return Intrinsic._MM512_MASK_FLOOR_PS;
                case "_MM_FLOOR_SD": return Intrinsic._MM_FLOOR_SD;
                case "_MM_FLOOR_SS": return Intrinsic._MM_FLOOR_SS;
                case "_MM512_FMADD_EPI32": return Intrinsic._MM512_FMADD_EPI32;
                case "_MM512_MASK_FMADD_EPI32": return Intrinsic._MM512_MASK_FMADD_EPI32;
                case "_MM512_MASK3_FMADD_EPI32": return Intrinsic._MM512_MASK3_FMADD_EPI32;
                case "_MM_FMADD_PD": return Intrinsic._MM_FMADD_PD;
                case "_MM_MASK_FMADD_PD": return Intrinsic._MM_MASK_FMADD_PD;
                case "_MM_MASK3_FMADD_PD": return Intrinsic._MM_MASK3_FMADD_PD;
                case "_MM_MASKZ_FMADD_PD": return Intrinsic._MM_MASKZ_FMADD_PD;
                case "_MM256_FMADD_PD": return Intrinsic._MM256_FMADD_PD;
                case "_MM256_MASK_FMADD_PD": return Intrinsic._MM256_MASK_FMADD_PD;
                case "_MM256_MASK3_FMADD_PD": return Intrinsic._MM256_MASK3_FMADD_PD;
                case "_MM256_MASKZ_FMADD_PD": return Intrinsic._MM256_MASKZ_FMADD_PD;
                case "_MM512_FMADD_PD": return Intrinsic._MM512_FMADD_PD;
                case "_MM512_MASK_FMADD_PD": return Intrinsic._MM512_MASK_FMADD_PD;
                case "_MM512_MASK3_FMADD_PD": return Intrinsic._MM512_MASK3_FMADD_PD;
                case "_MM512_MASKZ_FMADD_PD": return Intrinsic._MM512_MASKZ_FMADD_PD;
                case "_MM_FMADD_PS": return Intrinsic._MM_FMADD_PS;
                case "_MM_MASK_FMADD_PS": return Intrinsic._MM_MASK_FMADD_PS;
                case "_MM_MASK3_FMADD_PS": return Intrinsic._MM_MASK3_FMADD_PS;
                case "_MM_MASKZ_FMADD_PS": return Intrinsic._MM_MASKZ_FMADD_PS;
                case "_MM256_FMADD_PS": return Intrinsic._MM256_FMADD_PS;
                case "_MM256_MASK_FMADD_PS": return Intrinsic._MM256_MASK_FMADD_PS;
                case "_MM256_MASK3_FMADD_PS": return Intrinsic._MM256_MASK3_FMADD_PS;
                case "_MM256_MASKZ_FMADD_PS": return Intrinsic._MM256_MASKZ_FMADD_PS;
                case "_MM512_FMADD_PS": return Intrinsic._MM512_FMADD_PS;
                case "_MM512_MASK_FMADD_PS": return Intrinsic._MM512_MASK_FMADD_PS;
                case "_MM512_MASK3_FMADD_PS": return Intrinsic._MM512_MASK3_FMADD_PS;
                case "_MM512_MASKZ_FMADD_PS": return Intrinsic._MM512_MASKZ_FMADD_PS;
                case "_MM512_FMADD_ROUND_PD": return Intrinsic._MM512_FMADD_ROUND_PD;
                case "_MM512_MASK_FMADD_ROUND_PD": return Intrinsic._MM512_MASK_FMADD_ROUND_PD;
                case "_MM512_MASK3_FMADD_ROUND_PD": return Intrinsic._MM512_MASK3_FMADD_ROUND_PD;
                case "_MM512_MASKZ_FMADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FMADD_ROUND_PD;
                case "_MM512_FMADD_ROUND_PS": return Intrinsic._MM512_FMADD_ROUND_PS;
                case "_MM512_MASK_FMADD_ROUND_PS": return Intrinsic._MM512_MASK_FMADD_ROUND_PS;
                case "_MM512_MASK3_FMADD_ROUND_PS": return Intrinsic._MM512_MASK3_FMADD_ROUND_PS;
                case "_MM512_MASKZ_FMADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FMADD_ROUND_PS;
                case "_MM_MASK_FMADD_ROUND_SD": return Intrinsic._MM_MASK_FMADD_ROUND_SD;
                case "_MM_MASK3_FMADD_ROUND_SD": return Intrinsic._MM_MASK3_FMADD_ROUND_SD;
                case "_MM_MASKZ_FMADD_ROUND_SD": return Intrinsic._MM_MASKZ_FMADD_ROUND_SD;
                case "_MM_MASK_FMADD_ROUND_SS": return Intrinsic._MM_MASK_FMADD_ROUND_SS;
                case "_MM_MASK3_FMADD_ROUND_SS": return Intrinsic._MM_MASK3_FMADD_ROUND_SS;
                case "_MM_MASKZ_FMADD_ROUND_SS": return Intrinsic._MM_MASKZ_FMADD_ROUND_SS;
                case "_MM_FMADD_SD": return Intrinsic._MM_FMADD_SD;
                case "_MM_MASK_FMADD_SD": return Intrinsic._MM_MASK_FMADD_SD;
                case "_MM_MASK3_FMADD_SD": return Intrinsic._MM_MASK3_FMADD_SD;
                case "_MM_MASKZ_FMADD_SD": return Intrinsic._MM_MASKZ_FMADD_SD;
                case "_MM_FMADD_SS": return Intrinsic._MM_FMADD_SS;
                case "_MM_MASK_FMADD_SS": return Intrinsic._MM_MASK_FMADD_SS;
                case "_MM_MASK3_FMADD_SS": return Intrinsic._MM_MASK3_FMADD_SS;
                case "_MM_MASKZ_FMADD_SS": return Intrinsic._MM_MASKZ_FMADD_SS;
                case "_MM512_FMADD233_EPI32": return Intrinsic._MM512_FMADD233_EPI32;
                case "_MM512_MASK_FMADD233_EPI32": return Intrinsic._MM512_MASK_FMADD233_EPI32;
                case "_MM512_FMADD233_PS": return Intrinsic._MM512_FMADD233_PS;
                case "_MM512_MASK_FMADD233_PS": return Intrinsic._MM512_MASK_FMADD233_PS;
                case "_MM512_FMADD233_ROUND_PS": return Intrinsic._MM512_FMADD233_ROUND_PS;
                case "_MM512_MASK_FMADD233_ROUND_PS": return Intrinsic._MM512_MASK_FMADD233_ROUND_PS;
                case "_MM_FMADDSUB_PD": return Intrinsic._MM_FMADDSUB_PD;
                case "_MM_MASK_FMADDSUB_PD": return Intrinsic._MM_MASK_FMADDSUB_PD;
                case "_MM_MASK3_FMADDSUB_PD": return Intrinsic._MM_MASK3_FMADDSUB_PD;
                case "_MM_MASKZ_FMADDSUB_PD": return Intrinsic._MM_MASKZ_FMADDSUB_PD;
                case "_MM256_FMADDSUB_PD": return Intrinsic._MM256_FMADDSUB_PD;
                case "_MM256_MASK_FMADDSUB_PD": return Intrinsic._MM256_MASK_FMADDSUB_PD;
                case "_MM256_MASK3_FMADDSUB_PD": return Intrinsic._MM256_MASK3_FMADDSUB_PD;
                case "_MM256_MASKZ_FMADDSUB_PD": return Intrinsic._MM256_MASKZ_FMADDSUB_PD;
                case "_MM512_FMADDSUB_PD": return Intrinsic._MM512_FMADDSUB_PD;
                case "_MM512_MASK_FMADDSUB_PD": return Intrinsic._MM512_MASK_FMADDSUB_PD;
                case "_MM512_MASK3_FMADDSUB_PD": return Intrinsic._MM512_MASK3_FMADDSUB_PD;
                case "_MM512_MASKZ_FMADDSUB_PD": return Intrinsic._MM512_MASKZ_FMADDSUB_PD;
                case "_MM_FMADDSUB_PS": return Intrinsic._MM_FMADDSUB_PS;
                case "_MM_MASK_FMADDSUB_PS": return Intrinsic._MM_MASK_FMADDSUB_PS;
                case "_MM_MASK3_FMADDSUB_PS": return Intrinsic._MM_MASK3_FMADDSUB_PS;
                case "_MM_MASKZ_FMADDSUB_PS": return Intrinsic._MM_MASKZ_FMADDSUB_PS;
                case "_MM256_FMADDSUB_PS": return Intrinsic._MM256_FMADDSUB_PS;
                case "_MM256_MASK_FMADDSUB_PS": return Intrinsic._MM256_MASK_FMADDSUB_PS;
                case "_MM256_MASK3_FMADDSUB_PS": return Intrinsic._MM256_MASK3_FMADDSUB_PS;
                case "_MM256_MASKZ_FMADDSUB_PS": return Intrinsic._MM256_MASKZ_FMADDSUB_PS;
                case "_MM512_FMADDSUB_PS": return Intrinsic._MM512_FMADDSUB_PS;
                case "_MM512_MASK_FMADDSUB_PS": return Intrinsic._MM512_MASK_FMADDSUB_PS;
                case "_MM512_MASK3_FMADDSUB_PS": return Intrinsic._MM512_MASK3_FMADDSUB_PS;
                case "_MM512_MASKZ_FMADDSUB_PS": return Intrinsic._MM512_MASKZ_FMADDSUB_PS;
                case "_MM512_FMADDSUB_ROUND_PD": return Intrinsic._MM512_FMADDSUB_ROUND_PD;
                case "_MM512_MASK_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASK_FMADDSUB_ROUND_PD;
                case "_MM512_MASK3_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FMADDSUB_ROUND_PD;
                case "_MM512_MASKZ_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FMADDSUB_ROUND_PD;
                case "_MM512_FMADDSUB_ROUND_PS": return Intrinsic._MM512_FMADDSUB_ROUND_PS;
                case "_MM512_MASK_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASK_FMADDSUB_ROUND_PS;
                case "_MM512_MASK3_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FMADDSUB_ROUND_PS;
                case "_MM512_MASKZ_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FMADDSUB_ROUND_PS;
                case "_MM_FMSUB_PD": return Intrinsic._MM_FMSUB_PD;
                case "_MM_MASK_FMSUB_PD": return Intrinsic._MM_MASK_FMSUB_PD;
                case "_MM_MASK3_FMSUB_PD": return Intrinsic._MM_MASK3_FMSUB_PD;
                case "_MM_MASKZ_FMSUB_PD": return Intrinsic._MM_MASKZ_FMSUB_PD;
                case "_MM256_FMSUB_PD": return Intrinsic._MM256_FMSUB_PD;
                case "_MM256_MASK_FMSUB_PD": return Intrinsic._MM256_MASK_FMSUB_PD;
                case "_MM256_MASK3_FMSUB_PD": return Intrinsic._MM256_MASK3_FMSUB_PD;
                case "_MM256_MASKZ_FMSUB_PD": return Intrinsic._MM256_MASKZ_FMSUB_PD;
                case "_MM512_FMSUB_PD": return Intrinsic._MM512_FMSUB_PD;
                case "_MM512_MASK_FMSUB_PD": return Intrinsic._MM512_MASK_FMSUB_PD;
                case "_MM512_MASK3_FMSUB_PD": return Intrinsic._MM512_MASK3_FMSUB_PD;
                case "_MM512_MASKZ_FMSUB_PD": return Intrinsic._MM512_MASKZ_FMSUB_PD;
                case "_MM_FMSUB_PS": return Intrinsic._MM_FMSUB_PS;
                case "_MM_MASK_FMSUB_PS": return Intrinsic._MM_MASK_FMSUB_PS;
                case "_MM_MASK3_FMSUB_PS": return Intrinsic._MM_MASK3_FMSUB_PS;
                case "_MM_MASKZ_FMSUB_PS": return Intrinsic._MM_MASKZ_FMSUB_PS;
                case "_MM256_FMSUB_PS": return Intrinsic._MM256_FMSUB_PS;
                case "_MM256_MASK_FMSUB_PS": return Intrinsic._MM256_MASK_FMSUB_PS;
                case "_MM256_MASK3_FMSUB_PS": return Intrinsic._MM256_MASK3_FMSUB_PS;
                case "_MM256_MASKZ_FMSUB_PS": return Intrinsic._MM256_MASKZ_FMSUB_PS;
                case "_MM512_FMSUB_PS": return Intrinsic._MM512_FMSUB_PS;
                case "_MM512_MASK_FMSUB_PS": return Intrinsic._MM512_MASK_FMSUB_PS;
                case "_MM512_MASK3_FMSUB_PS": return Intrinsic._MM512_MASK3_FMSUB_PS;
                case "_MM512_MASKZ_FMSUB_PS": return Intrinsic._MM512_MASKZ_FMSUB_PS;
                case "_MM512_FMSUB_ROUND_PD": return Intrinsic._MM512_FMSUB_ROUND_PD;
                case "_MM512_MASK_FMSUB_ROUND_PD": return Intrinsic._MM512_MASK_FMSUB_ROUND_PD;
                case "_MM512_MASK3_FMSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FMSUB_ROUND_PD;
                case "_MM512_MASKZ_FMSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FMSUB_ROUND_PD;
                case "_MM512_FMSUB_ROUND_PS": return Intrinsic._MM512_FMSUB_ROUND_PS;
                case "_MM512_MASK_FMSUB_ROUND_PS": return Intrinsic._MM512_MASK_FMSUB_ROUND_PS;
                case "_MM512_MASK3_FMSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FMSUB_ROUND_PS;
                case "_MM512_MASKZ_FMSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FMSUB_ROUND_PS;
                case "_MM_MASK_FMSUB_ROUND_SD": return Intrinsic._MM_MASK_FMSUB_ROUND_SD;
                case "_MM_MASK3_FMSUB_ROUND_SD": return Intrinsic._MM_MASK3_FMSUB_ROUND_SD;
                case "_MM_MASKZ_FMSUB_ROUND_SD": return Intrinsic._MM_MASKZ_FMSUB_ROUND_SD;
                case "_MM_MASK_FMSUB_ROUND_SS": return Intrinsic._MM_MASK_FMSUB_ROUND_SS;
                case "_MM_MASK3_FMSUB_ROUND_SS": return Intrinsic._MM_MASK3_FMSUB_ROUND_SS;
                case "_MM_MASKZ_FMSUB_ROUND_SS": return Intrinsic._MM_MASKZ_FMSUB_ROUND_SS;
                case "_MM_FMSUB_SD": return Intrinsic._MM_FMSUB_SD;
                case "_MM_MASK_FMSUB_SD": return Intrinsic._MM_MASK_FMSUB_SD;
                case "_MM_MASK3_FMSUB_SD": return Intrinsic._MM_MASK3_FMSUB_SD;
                case "_MM_MASKZ_FMSUB_SD": return Intrinsic._MM_MASKZ_FMSUB_SD;
                case "_MM_FMSUB_SS": return Intrinsic._MM_FMSUB_SS;
                case "_MM_MASK_FMSUB_SS": return Intrinsic._MM_MASK_FMSUB_SS;
                case "_MM_MASK3_FMSUB_SS": return Intrinsic._MM_MASK3_FMSUB_SS;
                case "_MM_MASKZ_FMSUB_SS": return Intrinsic._MM_MASKZ_FMSUB_SS;
                case "_MM_FMSUBADD_PD": return Intrinsic._MM_FMSUBADD_PD;
                case "_MM_MASK_FMSUBADD_PD": return Intrinsic._MM_MASK_FMSUBADD_PD;
                case "_MM_MASK3_FMSUBADD_PD": return Intrinsic._MM_MASK3_FMSUBADD_PD;
                case "_MM_MASKZ_FMSUBADD_PD": return Intrinsic._MM_MASKZ_FMSUBADD_PD;
                case "_MM256_FMSUBADD_PD": return Intrinsic._MM256_FMSUBADD_PD;
                case "_MM256_MASK_FMSUBADD_PD": return Intrinsic._MM256_MASK_FMSUBADD_PD;
                case "_MM256_MASK3_FMSUBADD_PD": return Intrinsic._MM256_MASK3_FMSUBADD_PD;
                case "_MM256_MASKZ_FMSUBADD_PD": return Intrinsic._MM256_MASKZ_FMSUBADD_PD;
                case "_MM512_FMSUBADD_PD": return Intrinsic._MM512_FMSUBADD_PD;
                case "_MM512_MASK_FMSUBADD_PD": return Intrinsic._MM512_MASK_FMSUBADD_PD;
                case "_MM512_MASK3_FMSUBADD_PD": return Intrinsic._MM512_MASK3_FMSUBADD_PD;
                case "_MM512_MASKZ_FMSUBADD_PD": return Intrinsic._MM512_MASKZ_FMSUBADD_PD;
                case "_MM_FMSUBADD_PS": return Intrinsic._MM_FMSUBADD_PS;
                case "_MM_MASK_FMSUBADD_PS": return Intrinsic._MM_MASK_FMSUBADD_PS;
                case "_MM_MASK3_FMSUBADD_PS": return Intrinsic._MM_MASK3_FMSUBADD_PS;
                case "_MM_MASKZ_FMSUBADD_PS": return Intrinsic._MM_MASKZ_FMSUBADD_PS;
                case "_MM256_FMSUBADD_PS": return Intrinsic._MM256_FMSUBADD_PS;
                case "_MM256_MASK_FMSUBADD_PS": return Intrinsic._MM256_MASK_FMSUBADD_PS;
                case "_MM256_MASK3_FMSUBADD_PS": return Intrinsic._MM256_MASK3_FMSUBADD_PS;
                case "_MM256_MASKZ_FMSUBADD_PS": return Intrinsic._MM256_MASKZ_FMSUBADD_PS;
                case "_MM512_FMSUBADD_PS": return Intrinsic._MM512_FMSUBADD_PS;
                case "_MM512_MASK_FMSUBADD_PS": return Intrinsic._MM512_MASK_FMSUBADD_PS;
                case "_MM512_MASK3_FMSUBADD_PS": return Intrinsic._MM512_MASK3_FMSUBADD_PS;
                case "_MM512_MASKZ_FMSUBADD_PS": return Intrinsic._MM512_MASKZ_FMSUBADD_PS;
                case "_MM512_FMSUBADD_ROUND_PD": return Intrinsic._MM512_FMSUBADD_ROUND_PD;
                case "_MM512_MASK_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASK_FMSUBADD_ROUND_PD;
                case "_MM512_MASK3_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASK3_FMSUBADD_ROUND_PD;
                case "_MM512_MASKZ_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FMSUBADD_ROUND_PD;
                case "_MM512_FMSUBADD_ROUND_PS": return Intrinsic._MM512_FMSUBADD_ROUND_PS;
                case "_MM512_MASK_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASK_FMSUBADD_ROUND_PS;
                case "_MM512_MASK3_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASK3_FMSUBADD_ROUND_PS;
                case "_MM512_MASKZ_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FMSUBADD_ROUND_PS;
                case "_MM_FNMADD_PD": return Intrinsic._MM_FNMADD_PD;
                case "_MM_MASK_FNMADD_PD": return Intrinsic._MM_MASK_FNMADD_PD;
                case "_MM_MASK3_FNMADD_PD": return Intrinsic._MM_MASK3_FNMADD_PD;
                case "_MM_MASKZ_FNMADD_PD": return Intrinsic._MM_MASKZ_FNMADD_PD;
                case "_MM256_FNMADD_PD": return Intrinsic._MM256_FNMADD_PD;
                case "_MM256_MASK_FNMADD_PD": return Intrinsic._MM256_MASK_FNMADD_PD;
                case "_MM256_MASK3_FNMADD_PD": return Intrinsic._MM256_MASK3_FNMADD_PD;
                case "_MM256_MASKZ_FNMADD_PD": return Intrinsic._MM256_MASKZ_FNMADD_PD;
                case "_MM512_FNMADD_PD": return Intrinsic._MM512_FNMADD_PD;
                case "_MM512_MASK_FNMADD_PD": return Intrinsic._MM512_MASK_FNMADD_PD;
                case "_MM512_MASK3_FNMADD_PD": return Intrinsic._MM512_MASK3_FNMADD_PD;
                case "_MM512_MASKZ_FNMADD_PD": return Intrinsic._MM512_MASKZ_FNMADD_PD;
                case "_MM_FNMADD_PS": return Intrinsic._MM_FNMADD_PS;
                case "_MM_MASK_FNMADD_PS": return Intrinsic._MM_MASK_FNMADD_PS;
                case "_MM_MASK3_FNMADD_PS": return Intrinsic._MM_MASK3_FNMADD_PS;
                case "_MM_MASKZ_FNMADD_PS": return Intrinsic._MM_MASKZ_FNMADD_PS;
                case "_MM256_FNMADD_PS": return Intrinsic._MM256_FNMADD_PS;
                case "_MM256_MASK_FNMADD_PS": return Intrinsic._MM256_MASK_FNMADD_PS;
                case "_MM256_MASK3_FNMADD_PS": return Intrinsic._MM256_MASK3_FNMADD_PS;
                case "_MM256_MASKZ_FNMADD_PS": return Intrinsic._MM256_MASKZ_FNMADD_PS;
                case "_MM512_FNMADD_PS": return Intrinsic._MM512_FNMADD_PS;
                case "_MM512_MASK_FNMADD_PS": return Intrinsic._MM512_MASK_FNMADD_PS;
                case "_MM512_MASK3_FNMADD_PS": return Intrinsic._MM512_MASK3_FNMADD_PS;
                case "_MM512_MASKZ_FNMADD_PS": return Intrinsic._MM512_MASKZ_FNMADD_PS;
                case "_MM512_FNMADD_ROUND_PD": return Intrinsic._MM512_FNMADD_ROUND_PD;
                case "_MM512_MASK_FNMADD_ROUND_PD": return Intrinsic._MM512_MASK_FNMADD_ROUND_PD;
                case "_MM512_MASK3_FNMADD_ROUND_PD": return Intrinsic._MM512_MASK3_FNMADD_ROUND_PD;
                case "_MM512_MASKZ_FNMADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FNMADD_ROUND_PD;
                case "_MM512_FNMADD_ROUND_PS": return Intrinsic._MM512_FNMADD_ROUND_PS;
                case "_MM512_MASK_FNMADD_ROUND_PS": return Intrinsic._MM512_MASK_FNMADD_ROUND_PS;
                case "_MM512_MASK3_FNMADD_ROUND_PS": return Intrinsic._MM512_MASK3_FNMADD_ROUND_PS;
                case "_MM512_MASKZ_FNMADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FNMADD_ROUND_PS;
                case "_MM_MASK_FNMADD_ROUND_SD": return Intrinsic._MM_MASK_FNMADD_ROUND_SD;
                case "_MM_MASK3_FNMADD_ROUND_SD": return Intrinsic._MM_MASK3_FNMADD_ROUND_SD;
                case "_MM_MASKZ_FNMADD_ROUND_SD": return Intrinsic._MM_MASKZ_FNMADD_ROUND_SD;
                case "_MM_MASK_FNMADD_ROUND_SS": return Intrinsic._MM_MASK_FNMADD_ROUND_SS;
                case "_MM_MASK3_FNMADD_ROUND_SS": return Intrinsic._MM_MASK3_FNMADD_ROUND_SS;
                case "_MM_MASKZ_FNMADD_ROUND_SS": return Intrinsic._MM_MASKZ_FNMADD_ROUND_SS;
                case "_MM_FNMADD_SD": return Intrinsic._MM_FNMADD_SD;
                case "_MM_MASK_FNMADD_SD": return Intrinsic._MM_MASK_FNMADD_SD;
                case "_MM_MASK3_FNMADD_SD": return Intrinsic._MM_MASK3_FNMADD_SD;
                case "_MM_MASKZ_FNMADD_SD": return Intrinsic._MM_MASKZ_FNMADD_SD;
                case "_MM_FNMADD_SS": return Intrinsic._MM_FNMADD_SS;
                case "_MM_MASK_FNMADD_SS": return Intrinsic._MM_MASK_FNMADD_SS;
                case "_MM_MASK3_FNMADD_SS": return Intrinsic._MM_MASK3_FNMADD_SS;
                case "_MM_MASKZ_FNMADD_SS": return Intrinsic._MM_MASKZ_FNMADD_SS;
                case "_MM_FNMSUB_PD": return Intrinsic._MM_FNMSUB_PD;
                case "_MM_MASK_FNMSUB_PD": return Intrinsic._MM_MASK_FNMSUB_PD;
                case "_MM_MASK3_FNMSUB_PD": return Intrinsic._MM_MASK3_FNMSUB_PD;
                case "_MM_MASKZ_FNMSUB_PD": return Intrinsic._MM_MASKZ_FNMSUB_PD;
                case "_MM256_FNMSUB_PD": return Intrinsic._MM256_FNMSUB_PD;
                case "_MM256_MASK_FNMSUB_PD": return Intrinsic._MM256_MASK_FNMSUB_PD;
                case "_MM256_MASK3_FNMSUB_PD": return Intrinsic._MM256_MASK3_FNMSUB_PD;
                case "_MM256_MASKZ_FNMSUB_PD": return Intrinsic._MM256_MASKZ_FNMSUB_PD;
                case "_MM512_FNMSUB_PD": return Intrinsic._MM512_FNMSUB_PD;
                case "_MM512_MASK_FNMSUB_PD": return Intrinsic._MM512_MASK_FNMSUB_PD;
                case "_MM512_MASK3_FNMSUB_PD": return Intrinsic._MM512_MASK3_FNMSUB_PD;
                case "_MM512_MASKZ_FNMSUB_PD": return Intrinsic._MM512_MASKZ_FNMSUB_PD;
                case "_MM_FNMSUB_PS": return Intrinsic._MM_FNMSUB_PS;
                case "_MM_MASK_FNMSUB_PS": return Intrinsic._MM_MASK_FNMSUB_PS;
                case "_MM_MASK3_FNMSUB_PS": return Intrinsic._MM_MASK3_FNMSUB_PS;
                case "_MM_MASKZ_FNMSUB_PS": return Intrinsic._MM_MASKZ_FNMSUB_PS;
                case "_MM256_FNMSUB_PS": return Intrinsic._MM256_FNMSUB_PS;
                case "_MM256_MASK_FNMSUB_PS": return Intrinsic._MM256_MASK_FNMSUB_PS;
                case "_MM256_MASK3_FNMSUB_PS": return Intrinsic._MM256_MASK3_FNMSUB_PS;
                case "_MM256_MASKZ_FNMSUB_PS": return Intrinsic._MM256_MASKZ_FNMSUB_PS;
                case "_MM512_FNMSUB_PS": return Intrinsic._MM512_FNMSUB_PS;
                case "_MM512_MASK_FNMSUB_PS": return Intrinsic._MM512_MASK_FNMSUB_PS;
                case "_MM512_MASK3_FNMSUB_PS": return Intrinsic._MM512_MASK3_FNMSUB_PS;
                case "_MM512_MASKZ_FNMSUB_PS": return Intrinsic._MM512_MASKZ_FNMSUB_PS;
                case "_MM512_FNMSUB_ROUND_PD": return Intrinsic._MM512_FNMSUB_ROUND_PD;
                case "_MM512_MASK_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASK_FNMSUB_ROUND_PD;
                case "_MM512_MASK3_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FNMSUB_ROUND_PD;
                case "_MM512_MASKZ_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FNMSUB_ROUND_PD;
                case "_MM512_FNMSUB_ROUND_PS": return Intrinsic._MM512_FNMSUB_ROUND_PS;
                case "_MM512_MASK_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASK_FNMSUB_ROUND_PS;
                case "_MM512_MASK3_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FNMSUB_ROUND_PS;
                case "_MM512_MASKZ_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FNMSUB_ROUND_PS;
                case "_MM_MASK_FNMSUB_ROUND_SD": return Intrinsic._MM_MASK_FNMSUB_ROUND_SD;
                case "_MM_MASK3_FNMSUB_ROUND_SD": return Intrinsic._MM_MASK3_FNMSUB_ROUND_SD;
                case "_MM_MASKZ_FNMSUB_ROUND_SD": return Intrinsic._MM_MASKZ_FNMSUB_ROUND_SD;
                case "_MM_MASK_FNMSUB_ROUND_SS": return Intrinsic._MM_MASK_FNMSUB_ROUND_SS;
                case "_MM_MASK3_FNMSUB_ROUND_SS": return Intrinsic._MM_MASK3_FNMSUB_ROUND_SS;
                case "_MM_MASKZ_FNMSUB_ROUND_SS": return Intrinsic._MM_MASKZ_FNMSUB_ROUND_SS;
                case "_MM_FNMSUB_SD": return Intrinsic._MM_FNMSUB_SD;
                case "_MM_MASK_FNMSUB_SD": return Intrinsic._MM_MASK_FNMSUB_SD;
                case "_MM_MASK3_FNMSUB_SD": return Intrinsic._MM_MASK3_FNMSUB_SD;
                case "_MM_MASKZ_FNMSUB_SD": return Intrinsic._MM_MASKZ_FNMSUB_SD;
                case "_MM_FNMSUB_SS": return Intrinsic._MM_FNMSUB_SS;
                case "_MM_MASK_FNMSUB_SS": return Intrinsic._MM_MASK_FNMSUB_SS;
                case "_MM_MASK3_FNMSUB_SS": return Intrinsic._MM_MASK3_FNMSUB_SS;
                case "_MM_MASKZ_FNMSUB_SS": return Intrinsic._MM_MASKZ_FNMSUB_SS;
                case "_MM_FPCLASS_PD_MASK": return Intrinsic._MM_FPCLASS_PD_MASK;
                case "_MM_MASK_FPCLASS_PD_MASK": return Intrinsic._MM_MASK_FPCLASS_PD_MASK;
                case "_MM256_FPCLASS_PD_MASK": return Intrinsic._MM256_FPCLASS_PD_MASK;
                case "_MM256_MASK_FPCLASS_PD_MASK": return Intrinsic._MM256_MASK_FPCLASS_PD_MASK;
                case "_MM512_FPCLASS_PD_MASK": return Intrinsic._MM512_FPCLASS_PD_MASK;
                case "_MM512_MASK_FPCLASS_PD_MASK": return Intrinsic._MM512_MASK_FPCLASS_PD_MASK;
                case "_MM_FPCLASS_PS_MASK": return Intrinsic._MM_FPCLASS_PS_MASK;
                case "_MM_MASK_FPCLASS_PS_MASK": return Intrinsic._MM_MASK_FPCLASS_PS_MASK;
                case "_MM256_FPCLASS_PS_MASK": return Intrinsic._MM256_FPCLASS_PS_MASK;
                case "_MM256_MASK_FPCLASS_PS_MASK": return Intrinsic._MM256_MASK_FPCLASS_PS_MASK;
                case "_MM512_FPCLASS_PS_MASK": return Intrinsic._MM512_FPCLASS_PS_MASK;
                case "_MM512_MASK_FPCLASS_PS_MASK": return Intrinsic._MM512_MASK_FPCLASS_PS_MASK;
                case "_MM_FPCLASS_SD_MASK": return Intrinsic._MM_FPCLASS_SD_MASK;
                case "_MM_MASK_FPCLASS_SD_MASK": return Intrinsic._MM_MASK_FPCLASS_SD_MASK;
                case "_MM_FPCLASS_SS_MASK": return Intrinsic._MM_FPCLASS_SS_MASK;
                case "_MM_MASK_FPCLASS_SS_MASK": return Intrinsic._MM_MASK_FPCLASS_SS_MASK;
                case "_MM_FREE": return Intrinsic._MM_FREE;
                case "_M_FROM_INT": return Intrinsic._M_FROM_INT;
                case "_M_FROM_INT64": return Intrinsic._M_FROM_INT64;
                case "_FXRSTOR": return Intrinsic._FXRSTOR;
                case "_FXRSTOR64": return Intrinsic._FXRSTOR64;
                case "_FXSAVE": return Intrinsic._FXSAVE;
                case "_FXSAVE64": return Intrinsic._FXSAVE64;
                case "_MM_GET_EXCEPTION_MASK": return Intrinsic._MM_GET_EXCEPTION_MASK;
                case "_MM_GET_EXCEPTION_STATE": return Intrinsic._MM_GET_EXCEPTION_STATE;
                case "_MM_GET_FLUSH_ZERO_MODE": return Intrinsic._MM_GET_FLUSH_ZERO_MODE;
                case "_MM_GET_ROUNDING_MODE": return Intrinsic._MM_GET_ROUNDING_MODE;
                case "_MM_GETCSR": return Intrinsic._MM_GETCSR;
                case "_MM_GETEXP_PD": return Intrinsic._MM_GETEXP_PD;
                case "_MM_MASK_GETEXP_PD": return Intrinsic._MM_MASK_GETEXP_PD;
                case "_MM_MASKZ_GETEXP_PD": return Intrinsic._MM_MASKZ_GETEXP_PD;
                case "_MM256_GETEXP_PD": return Intrinsic._MM256_GETEXP_PD;
                case "_MM256_MASK_GETEXP_PD": return Intrinsic._MM256_MASK_GETEXP_PD;
                case "_MM256_MASKZ_GETEXP_PD": return Intrinsic._MM256_MASKZ_GETEXP_PD;
                case "_MM512_GETEXP_PD": return Intrinsic._MM512_GETEXP_PD;
                case "_MM512_MASK_GETEXP_PD": return Intrinsic._MM512_MASK_GETEXP_PD;
                case "_MM512_MASKZ_GETEXP_PD": return Intrinsic._MM512_MASKZ_GETEXP_PD;
                case "_MM_GETEXP_PS": return Intrinsic._MM_GETEXP_PS;
                case "_MM_MASK_GETEXP_PS": return Intrinsic._MM_MASK_GETEXP_PS;
                case "_MM_MASKZ_GETEXP_PS": return Intrinsic._MM_MASKZ_GETEXP_PS;
                case "_MM256_GETEXP_PS": return Intrinsic._MM256_GETEXP_PS;
                case "_MM256_MASK_GETEXP_PS": return Intrinsic._MM256_MASK_GETEXP_PS;
                case "_MM256_MASKZ_GETEXP_PS": return Intrinsic._MM256_MASKZ_GETEXP_PS;
                case "_MM512_GETEXP_PS": return Intrinsic._MM512_GETEXP_PS;
                case "_MM512_MASK_GETEXP_PS": return Intrinsic._MM512_MASK_GETEXP_PS;
                case "_MM512_MASKZ_GETEXP_PS": return Intrinsic._MM512_MASKZ_GETEXP_PS;
                case "_MM512_GETEXP_ROUND_PD": return Intrinsic._MM512_GETEXP_ROUND_PD;
                case "_MM512_MASK_GETEXP_ROUND_PD": return Intrinsic._MM512_MASK_GETEXP_ROUND_PD;
                case "_MM512_MASKZ_GETEXP_ROUND_PD": return Intrinsic._MM512_MASKZ_GETEXP_ROUND_PD;
                case "_MM512_GETEXP_ROUND_PS": return Intrinsic._MM512_GETEXP_ROUND_PS;
                case "_MM512_MASK_GETEXP_ROUND_PS": return Intrinsic._MM512_MASK_GETEXP_ROUND_PS;
                case "_MM512_MASKZ_GETEXP_ROUND_PS": return Intrinsic._MM512_MASKZ_GETEXP_ROUND_PS;
                case "_MM_GETEXP_ROUND_SD": return Intrinsic._MM_GETEXP_ROUND_SD;
                case "_MM_MASK_GETEXP_ROUND_SD": return Intrinsic._MM_MASK_GETEXP_ROUND_SD;
                case "_MM_MASKZ_GETEXP_ROUND_SD": return Intrinsic._MM_MASKZ_GETEXP_ROUND_SD;
                case "_MM_GETEXP_ROUND_SS": return Intrinsic._MM_GETEXP_ROUND_SS;
                case "_MM_MASK_GETEXP_ROUND_SS": return Intrinsic._MM_MASK_GETEXP_ROUND_SS;
                case "_MM_MASKZ_GETEXP_ROUND_SS": return Intrinsic._MM_MASKZ_GETEXP_ROUND_SS;
                case "_MM_GETEXP_SD": return Intrinsic._MM_GETEXP_SD;
                case "_MM_MASK_GETEXP_SD": return Intrinsic._MM_MASK_GETEXP_SD;
                case "_MM_MASKZ_GETEXP_SD": return Intrinsic._MM_MASKZ_GETEXP_SD;
                case "_MM_GETEXP_SS": return Intrinsic._MM_GETEXP_SS;
                case "_MM_MASK_GETEXP_SS": return Intrinsic._MM_MASK_GETEXP_SS;
                case "_MM_MASKZ_GETEXP_SS": return Intrinsic._MM_MASKZ_GETEXP_SS;
                case "_MM_GETMANT_PD": return Intrinsic._MM_GETMANT_PD;
                case "_MM_MASK_GETMANT_PD": return Intrinsic._MM_MASK_GETMANT_PD;
                case "_MM_MASKZ_GETMANT_PD": return Intrinsic._MM_MASKZ_GETMANT_PD;
                case "_MM256_GETMANT_PD": return Intrinsic._MM256_GETMANT_PD;
                case "_MM256_MASK_GETMANT_PD": return Intrinsic._MM256_MASK_GETMANT_PD;
                case "_MM256_MASKZ_GETMANT_PD": return Intrinsic._MM256_MASKZ_GETMANT_PD;
                case "_MM512_GETMANT_PD": return Intrinsic._MM512_GETMANT_PD;
                case "_MM512_MASK_GETMANT_PD": return Intrinsic._MM512_MASK_GETMANT_PD;
                case "_MM512_MASKZ_GETMANT_PD": return Intrinsic._MM512_MASKZ_GETMANT_PD;
                case "_MM_GETMANT_PS": return Intrinsic._MM_GETMANT_PS;
                case "_MM_MASK_GETMANT_PS": return Intrinsic._MM_MASK_GETMANT_PS;
                case "_MM_MASKZ_GETMANT_PS": return Intrinsic._MM_MASKZ_GETMANT_PS;
                case "_MM256_GETMANT_PS": return Intrinsic._MM256_GETMANT_PS;
                case "_MM256_MASK_GETMANT_PS": return Intrinsic._MM256_MASK_GETMANT_PS;
                case "_MM256_MASKZ_GETMANT_PS": return Intrinsic._MM256_MASKZ_GETMANT_PS;
                case "_MM512_GETMANT_PS": return Intrinsic._MM512_GETMANT_PS;
                case "_MM512_MASK_GETMANT_PS": return Intrinsic._MM512_MASK_GETMANT_PS;
                case "_MM512_MASKZ_GETMANT_PS": return Intrinsic._MM512_MASKZ_GETMANT_PS;
                case "_MM512_GETMANT_ROUND_PD": return Intrinsic._MM512_GETMANT_ROUND_PD;
                case "_MM512_MASK_GETMANT_ROUND_PD": return Intrinsic._MM512_MASK_GETMANT_ROUND_PD;
                case "_MM512_MASKZ_GETMANT_ROUND_PD": return Intrinsic._MM512_MASKZ_GETMANT_ROUND_PD;
                case "_MM512_GETMANT_ROUND_PS": return Intrinsic._MM512_GETMANT_ROUND_PS;
                case "_MM512_MASK_GETMANT_ROUND_PS": return Intrinsic._MM512_MASK_GETMANT_ROUND_PS;
                case "_MM512_MASKZ_GETMANT_ROUND_PS": return Intrinsic._MM512_MASKZ_GETMANT_ROUND_PS;
                case "_MM_GETMANT_ROUND_SD": return Intrinsic._MM_GETMANT_ROUND_SD;
                case "_MM_MASK_GETMANT_ROUND_SD": return Intrinsic._MM_MASK_GETMANT_ROUND_SD;
                case "_MM_MASKZ_GETMANT_ROUND_SD": return Intrinsic._MM_MASKZ_GETMANT_ROUND_SD;
                case "_MM_GETMANT_ROUND_SS": return Intrinsic._MM_GETMANT_ROUND_SS;
                case "_MM_MASK_GETMANT_ROUND_SS": return Intrinsic._MM_MASK_GETMANT_ROUND_SS;
                case "_MM_MASKZ_GETMANT_ROUND_SS": return Intrinsic._MM_MASKZ_GETMANT_ROUND_SS;
                case "_MM_GETMANT_SD": return Intrinsic._MM_GETMANT_SD;
                case "_MM_MASK_GETMANT_SD": return Intrinsic._MM_MASK_GETMANT_SD;
                case "_MM_MASKZ_GETMANT_SD": return Intrinsic._MM_MASKZ_GETMANT_SD;
                case "_MM_GETMANT_SS": return Intrinsic._MM_GETMANT_SS;
                case "_MM_MASK_GETMANT_SS": return Intrinsic._MM_MASK_GETMANT_SS;
                case "_MM_MASKZ_GETMANT_SS": return Intrinsic._MM_MASKZ_GETMANT_SS;
                case "_MM512_GMAX_PD": return Intrinsic._MM512_GMAX_PD;
                case "_MM512_MASK_GMAX_PD": return Intrinsic._MM512_MASK_GMAX_PD;
                case "_MM512_GMAX_PS": return Intrinsic._MM512_GMAX_PS;
                case "_MM512_MASK_GMAX_PS": return Intrinsic._MM512_MASK_GMAX_PS;
                case "_MM512_GMAXABS_PS": return Intrinsic._MM512_GMAXABS_PS;
                case "_MM512_MASK_GMAXABS_PS": return Intrinsic._MM512_MASK_GMAXABS_PS;
                case "_MM512_GMIN_PD": return Intrinsic._MM512_GMIN_PD;
                case "_MM512_MASK_GMIN_PD": return Intrinsic._MM512_MASK_GMIN_PD;
                case "_MM512_GMIN_PS": return Intrinsic._MM512_GMIN_PS;
                case "_MM512_MASK_GMIN_PS": return Intrinsic._MM512_MASK_GMIN_PS;
                case "_MM_HADD_EPI16": return Intrinsic._MM_HADD_EPI16;
                case "_MM256_HADD_EPI16": return Intrinsic._MM256_HADD_EPI16;
                case "_MM_HADD_EPI32": return Intrinsic._MM_HADD_EPI32;
                case "_MM256_HADD_EPI32": return Intrinsic._MM256_HADD_EPI32;
                case "_MM_HADD_PD": return Intrinsic._MM_HADD_PD;
                case "_MM256_HADD_PD": return Intrinsic._MM256_HADD_PD;
                case "_MM_HADD_PI16": return Intrinsic._MM_HADD_PI16;
                case "_MM_HADD_PI32": return Intrinsic._MM_HADD_PI32;
                case "_MM_HADD_PS": return Intrinsic._MM_HADD_PS;
                case "_MM256_HADD_PS": return Intrinsic._MM256_HADD_PS;
                case "_MM_HADDS_EPI16": return Intrinsic._MM_HADDS_EPI16;
                case "_MM256_HADDS_EPI16": return Intrinsic._MM256_HADDS_EPI16;
                case "_MM_HADDS_PI16": return Intrinsic._MM_HADDS_PI16;
                case "_MM_HSUB_EPI16": return Intrinsic._MM_HSUB_EPI16;
                case "_MM256_HSUB_EPI16": return Intrinsic._MM256_HSUB_EPI16;
                case "_MM_HSUB_EPI32": return Intrinsic._MM_HSUB_EPI32;
                case "_MM256_HSUB_EPI32": return Intrinsic._MM256_HSUB_EPI32;
                case "_MM_HSUB_PD": return Intrinsic._MM_HSUB_PD;
                case "_MM256_HSUB_PD": return Intrinsic._MM256_HSUB_PD;
                case "_MM_HSUB_PI16": return Intrinsic._MM_HSUB_PI16;
                case "_MM_HSUB_PI32": return Intrinsic._MM_HSUB_PI32;
                case "_MM_HSUB_PS": return Intrinsic._MM_HSUB_PS;
                case "_MM256_HSUB_PS": return Intrinsic._MM256_HSUB_PS;
                case "_MM_HSUBS_EPI16": return Intrinsic._MM_HSUBS_EPI16;
                case "_MM256_HSUBS_EPI16": return Intrinsic._MM256_HSUBS_EPI16;
                case "_MM_HSUBS_PI16": return Intrinsic._MM_HSUBS_PI16;
                case "_MM_HYPOT_PD": return Intrinsic._MM_HYPOT_PD;
                case "_MM256_HYPOT_PD": return Intrinsic._MM256_HYPOT_PD;
                case "_MM512_HYPOT_PD": return Intrinsic._MM512_HYPOT_PD;
                case "_MM512_MASK_HYPOT_PD": return Intrinsic._MM512_MASK_HYPOT_PD;
                case "_MM_HYPOT_PS": return Intrinsic._MM_HYPOT_PS;
                case "_MM256_HYPOT_PS": return Intrinsic._MM256_HYPOT_PS;
                case "_MM512_HYPOT_PS": return Intrinsic._MM512_HYPOT_PS;
                case "_MM512_MASK_HYPOT_PS": return Intrinsic._MM512_MASK_HYPOT_PS;
                case "_MM512_I32EXTGATHER_EPI32": return Intrinsic._MM512_I32EXTGATHER_EPI32;
                case "_MM512_MASK_I32EXTGATHER_EPI32": return Intrinsic._MM512_MASK_I32EXTGATHER_EPI32;
                case "_MM512_I32EXTGATHER_PS": return Intrinsic._MM512_I32EXTGATHER_PS;
                case "_MM512_MASK_I32EXTGATHER_PS": return Intrinsic._MM512_MASK_I32EXTGATHER_PS;
                case "_MM512_I32EXTSCATTER_EPI32": return Intrinsic._MM512_I32EXTSCATTER_EPI32;
                case "_MM512_MASK_I32EXTSCATTER_EPI32": return Intrinsic._MM512_MASK_I32EXTSCATTER_EPI32;
                case "_MM512_I32EXTSCATTER_PS": return Intrinsic._MM512_I32EXTSCATTER_PS;
                case "_MM512_MASK_I32EXTSCATTER_PS": return Intrinsic._MM512_MASK_I32EXTSCATTER_PS;
                case "_MM_I32GATHER_EPI32": return Intrinsic._MM_I32GATHER_EPI32;
                case "_MM_MASK_I32GATHER_EPI32": return Intrinsic._MM_MASK_I32GATHER_EPI32;
                case "_MM_MMASK_I32GATHER_EPI32": return Intrinsic._MM_MMASK_I32GATHER_EPI32;
                case "_MM256_I32GATHER_EPI32": return Intrinsic._MM256_I32GATHER_EPI32;
                case "_MM256_MASK_I32GATHER_EPI32": return Intrinsic._MM256_MASK_I32GATHER_EPI32;
                case "_MM256_MMASK_I32GATHER_EPI32": return Intrinsic._MM256_MMASK_I32GATHER_EPI32;
                case "_MM512_I32GATHER_EPI32": return Intrinsic._MM512_I32GATHER_EPI32;
                case "_MM512_MASK_I32GATHER_EPI32": return Intrinsic._MM512_MASK_I32GATHER_EPI32;
                case "_MM_I32GATHER_EPI64": return Intrinsic._MM_I32GATHER_EPI64;
                case "_MM_MASK_I32GATHER_EPI64": return Intrinsic._MM_MASK_I32GATHER_EPI64;
                case "_MM_MMASK_I32GATHER_EPI64": return Intrinsic._MM_MMASK_I32GATHER_EPI64;
                case "_MM256_I32GATHER_EPI64": return Intrinsic._MM256_I32GATHER_EPI64;
                case "_MM256_MASK_I32GATHER_EPI64": return Intrinsic._MM256_MASK_I32GATHER_EPI64;
                case "_MM256_MMASK_I32GATHER_EPI64": return Intrinsic._MM256_MMASK_I32GATHER_EPI64;
                case "_MM512_I32GATHER_EPI64": return Intrinsic._MM512_I32GATHER_EPI64;
                case "_MM512_MASK_I32GATHER_EPI64": return Intrinsic._MM512_MASK_I32GATHER_EPI64;
                case "_MM_I32GATHER_PD": return Intrinsic._MM_I32GATHER_PD;
                case "_MM_MASK_I32GATHER_PD": return Intrinsic._MM_MASK_I32GATHER_PD;
                case "_MM_MMASK_I32GATHER_PD": return Intrinsic._MM_MMASK_I32GATHER_PD;
                case "_MM256_I32GATHER_PD": return Intrinsic._MM256_I32GATHER_PD;
                case "_MM256_MASK_I32GATHER_PD": return Intrinsic._MM256_MASK_I32GATHER_PD;
                case "_MM256_MMASK_I32GATHER_PD": return Intrinsic._MM256_MMASK_I32GATHER_PD;
                case "_MM512_I32GATHER_PD": return Intrinsic._MM512_I32GATHER_PD;
                case "_MM512_MASK_I32GATHER_PD": return Intrinsic._MM512_MASK_I32GATHER_PD;
                case "_MM_I32GATHER_PS": return Intrinsic._MM_I32GATHER_PS;
                case "_MM_MASK_I32GATHER_PS": return Intrinsic._MM_MASK_I32GATHER_PS;
                case "_MM_MMASK_I32GATHER_PS": return Intrinsic._MM_MMASK_I32GATHER_PS;
                case "_MM256_I32GATHER_PS": return Intrinsic._MM256_I32GATHER_PS;
                case "_MM256_MASK_I32GATHER_PS": return Intrinsic._MM256_MASK_I32GATHER_PS;
                case "_MM256_MMASK_I32GATHER_PS": return Intrinsic._MM256_MMASK_I32GATHER_PS;
                case "_MM512_I32GATHER_PS": return Intrinsic._MM512_I32GATHER_PS;
                case "_MM512_MASK_I32GATHER_PS": return Intrinsic._MM512_MASK_I32GATHER_PS;
                case "_MM512_I32LOEXTGATHER_EPI64": return Intrinsic._MM512_I32LOEXTGATHER_EPI64;
                case "_MM512_MASK_I32LOEXTGATHER_EPI64": return Intrinsic._MM512_MASK_I32LOEXTGATHER_EPI64;
                case "_MM512_I32LOEXTGATHER_PD": return Intrinsic._MM512_I32LOEXTGATHER_PD;
                case "_MM512_MASK_I32LOEXTGATHER_PD": return Intrinsic._MM512_MASK_I32LOEXTGATHER_PD;
                case "_MM512_I32LOEXTSCATTER_EPI64": return Intrinsic._MM512_I32LOEXTSCATTER_EPI64;
                case "_MM512_MASK_I32LOEXTSCATTER_EPI64": return Intrinsic._MM512_MASK_I32LOEXTSCATTER_EPI64;
                case "_MM512_I32LOEXTSCATTER_PD": return Intrinsic._MM512_I32LOEXTSCATTER_PD;
                case "_MM512_MASK_I32LOEXTSCATTER_PD": return Intrinsic._MM512_MASK_I32LOEXTSCATTER_PD;
                case "_MM512_I32LOGATHER_EPI64": return Intrinsic._MM512_I32LOGATHER_EPI64;
                case "_MM512_MASK_I32LOGATHER_EPI64": return Intrinsic._MM512_MASK_I32LOGATHER_EPI64;
                case "_MM512_I32LOGATHER_PD": return Intrinsic._MM512_I32LOGATHER_PD;
                case "_MM512_MASK_I32LOGATHER_PD": return Intrinsic._MM512_MASK_I32LOGATHER_PD;
                case "_MM512_I32LOSCATTER_EPI64": return Intrinsic._MM512_I32LOSCATTER_EPI64;
                case "_MM512_MASK_I32LOSCATTER_EPI64": return Intrinsic._MM512_MASK_I32LOSCATTER_EPI64;
                case "_MM512_I32LOSCATTER_PD": return Intrinsic._MM512_I32LOSCATTER_PD;
                case "_MM512_MASK_I32LOSCATTER_PD": return Intrinsic._MM512_MASK_I32LOSCATTER_PD;
                case "_MM_I32SCATTER_EPI32": return Intrinsic._MM_I32SCATTER_EPI32;
                case "_MM_MASK_I32SCATTER_EPI32": return Intrinsic._MM_MASK_I32SCATTER_EPI32;
                case "_MM256_I32SCATTER_EPI32": return Intrinsic._MM256_I32SCATTER_EPI32;
                case "_MM256_MASK_I32SCATTER_EPI32": return Intrinsic._MM256_MASK_I32SCATTER_EPI32;
                case "_MM512_I32SCATTER_EPI32": return Intrinsic._MM512_I32SCATTER_EPI32;
                case "_MM512_MASK_I32SCATTER_EPI32": return Intrinsic._MM512_MASK_I32SCATTER_EPI32;
                case "_MM_I32SCATTER_EPI64": return Intrinsic._MM_I32SCATTER_EPI64;
                case "_MM_MASK_I32SCATTER_EPI64": return Intrinsic._MM_MASK_I32SCATTER_EPI64;
                case "_MM256_I32SCATTER_EPI64": return Intrinsic._MM256_I32SCATTER_EPI64;

                default: return Intrinsic.NONE;
            }
        }
    }
}
