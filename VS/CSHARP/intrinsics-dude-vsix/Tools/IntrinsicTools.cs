// The MIT License (MIT)
//
// Copyright (c) 2018 Henk-Jan Lebbink
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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Operations;

namespace IntrinsicsDude.Tools
{
    public static partial class IntrinsicTools {

        public enum SimdRegisterType
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
        public enum CpuID : long
        {
            /// <summary>
            /// NONE is used to denote no CPUID id is present
            /// </summary>
            NONE        = 0L,
            ADX         = 1L << 0,
            AES         = 1L << 1,
            AVX         = 1L << 2,
            AVX2        = 1L << 3,
            AVX512_BW    = 1L << 4,
            AVX512_CD    = 1L << 5,
            AVX512_DQ    = 1L << 6,
            AVX512_ER    = 1L << 7,
            AVX512_F     = 1L << 8,
            AVX512_PF    = 1L << 9,
            AVX512_VL    = 1L << 10,
            AVX512_IFMA52 = 1L << 28,
            AVX512_VBMI  = 1L << 31,
            AVX512_4VNNIW = 1L << 49,
            AVX512_4FMAPS = 1L << 50,
            AVX512_VPOPCNTDQ = 1L << 51,

            BMI1        = 1L << 11,
            BMI2        = 1L << 12,
            CLFLUSHOPT  = 1L << 13,
            FMA         = 1L << 14,
            FP16C       = 1L << 15,
            FXSR        = 1L << 16,
            KNCNI       = 1L << 17,
            MMX         = 1L << 18,
            MPX         = 1L << 19,
            PCLMULQDQ   = 1L << 20,
            SSE         = 1L << 21,
            SSE2        = 1L << 22,
            SSE3        = 1L << 23,
            SSE4_1      = 1L << 24,
            SSE4_2      = 1L << 25,
            SSSE3       = 1L << 26,

            LZCNT       = 1L << 27,
            INVPCID     = 1L << 29,
            MONITOR     = 1L << 30,
            POPCNT      = 1L << 32,
            RDRAND      = 1L << 33,
            RDSEED      = 1L << 34,
            TSC         = 1L << 35,
            RDTSCP      = 1L << 36,
            FSGSBASE    = 1L << 37,
            SHA         = 1L << 38,
            RTM         = 1L << 39,
            XSAVE       = 1L << 40,
            XSAVEC      = 1L << 41,
            XSS         = 1L << 42,
            XSAVEOPT    = 1L << 43,
            PREFETCHWT1 = 1L << 44,

            SVML        = 1L << 45,
            IA32        = 1L << 46,

            /// <summary>
            /// Read Processor ID
            /// </summary>
            RDPID       = 1L << 47,
            /// <summary>
            /// Cache Line Write Back
            /// </summary>
            CLWB        = 1L << 48,

            // bits 47-62 are reserved for future use

            /// <summary>
            /// UNKNOWN is used for an unknown or unrecognized CPUID.
            /// </summary>
            UNKNOWN = 1L << 63
        }

        public enum ReturnType
        {
            UNKNOWN,
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
            SHORT,
            UNSIGNED__INT32,
            UNSIGNED__INT64,
            UNSIGNED_CHAR,
            UNSIGNED_INT,
            UNSIGNED_LONG,
            UNSIGNED_SHORT,
            VOID,
            VOID_PTR
        }

        public enum ParamType
        {
            NONE,
            __INT8,
            __INT16,
            __INT32,
            __INT32_PTR,
            __INT64,
            __INT64_CONST_PTR,
            __INT64_PTR,
            __M128,
            __M128_CONST_PTR,
            __M128_PTR,
            __M128D,
            __M128D_CONST_PTR,
            __M128D_PTR,
            __M128I,
            __M128I_CONST_PTR,
            __M128I_PTR,
            __M256,
            __M256_PTR,
            __M256D,
            __M256D_PTR,
            __M256I,
            __M256I_CONST_PTR,
            __M256I_PTR,
            __M512,
            __M512_PTR,
            __M512D,
            __M512D_PTR,
            __M512I,
            __M64,
            __M64_CONST_PTR,
            __M64_PTR,
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
            _MM_PERM_ENUM,
            _MM_SWIZZLE_ENUM,
            CONST_MM_CMPINT_ENUM,
            CONST_INT,
            CONST_UNSIGNED_INT,
            CONST_VOID_PTR,
            CONST_VOID_PTR_PTR,
            CHAR,
            CHAR_CONST_PTR,
            CHAR_PTR,
            DOUBLE,
            DOUBLE_CONST_PTR,
            DOUBLE_PTR,
            FLOAT,
            FLOAT_CONST_PTR,
            FLOAT_PTR,
            INT,
            INT_CONST_PTR,
            INT_PTR,
            LONG_LONG,
            SIZE_T,
            SIZE_T_PTR,
            SHORT,
            UNSIGNED__INT32,
            UNSIGNED__INT32_PTR,
            UNSIGNED__INT64,
            UNSIGNED__INT64_PTR,
            UNSIGNED_CHAR,
            UNSIGNED_INT,
            UNSIGNED_INT_PTR,
            UNSIGNED_LONG,
            UNSIGNED_LONG_PTR,
            UNSIGNED_SHORT,
            UNSIGNED_SHORT_PTR,
            VOID,
            VOID_PTR,
            VOID_CONST_PTR
        }

        public static SimdRegisterType ParseSimdRegisterType(string str, bool warn = true)
        {
            if (!str.StartsWith("__")) return SimdRegisterType.NONE;
            switch (str.ToUpper())
            {
                case "__M128": return SimdRegisterType.__M128;
                case "__M128D": return SimdRegisterType.__M128D;
                case "__M128I": return SimdRegisterType.__M128I;
                case "__M256": return SimdRegisterType.__M256;
                case "__M256D": return SimdRegisterType.__M256D;
                case "__M256I": return SimdRegisterType.__M256I;
                case "__M512": return SimdRegisterType.__M512;
                case "__M512D": return SimdRegisterType.__M512D;
                case "__M512I": return SimdRegisterType.__M512I;
                case "__M64": return SimdRegisterType.__M64;
                case "__MMASK16": return SimdRegisterType.__MMASK16;
                case "__MMASK32": return SimdRegisterType.__MMASK32;
                case "__MMASK64": return SimdRegisterType.__MMASK64;
                case "__MMASK8": return SimdRegisterType.__MMASK8;
                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseIntrinsicRegisterType: unknown IntrinsicRegisterType \"" + str + "\".");
                    return SimdRegisterType.NONE;
            }
        }

        public static ReturnType ParseReturnType(string str, bool warn = true)
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
                case "SHORT": return ReturnType.SHORT;
                case "UNSIGNED __INT32": return ReturnType.UNSIGNED__INT32;
                case "UNSIGNED __INT64": return ReturnType.UNSIGNED__INT64;
                case "UNSIGNED CHAR": return ReturnType.UNSIGNED_CHAR;
                case "UNSIGNED INT": return ReturnType.UNSIGNED_INT;
                case "UNSIGNED LONG": return ReturnType.UNSIGNED_LONG;
                case "UNSIGNED SHORT": return ReturnType.UNSIGNED_SHORT;
                case "":
                case "VOID": return ReturnType.VOID;
                case "VOID*":
                case "VOID *": return ReturnType.VOID_PTR;
                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseReturnType: unknown ReturnType \"" + str + "\".");
                    return ReturnType.UNKNOWN;
            }
        }
        
        /// <summary>
        /// parse internal paramType name to ParamTYpe
        /// </summary>
        public static ParamType ParseParamType_InternalName(string str, bool warn = true)
        {
            switch (str)
            {
                case "__INT8": return ParamType.__INT8;
                case "__INT16": return ParamType.__INT16;
                case "__INT32": return ParamType.__INT32;
                case "__INT32_PTR": return ParamType.__INT32_PTR;
                case "__INT64": return ParamType.__INT64;
                case "__INT64_CONST_PTR": return ParamType.__INT64_CONST_PTR;
                case "__INT64_PTR": return ParamType.__INT64_PTR;
                case "__M128": return ParamType.__M128;
                case "__M128_CONST_PTR": return ParamType.__M128_CONST_PTR;
                case "__M128_PTR": return ParamType.__M128_PTR;
                case "__M128D": return ParamType.__M128D;
                case "__M128D_CONST_PTR": return ParamType.__M128D_CONST_PTR;
                case "__M128D_PTR": return ParamType.__M128D_PTR;
                case "__M128I": return ParamType.__M128I;
                case "__M128I_CONST_PTR": return ParamType.__M128I_CONST_PTR;
                case "__M128I_PTR": return ParamType.__M128I_PTR;
                case "__M256": return ParamType.__M256;
                case "__M256_PTR": return ParamType.__M256_PTR;
                case "__M256D": return ParamType.__M256D;
                case "__M256D_PTR": return ParamType.__M256D_PTR;
                case "__M256I": return ParamType.__M256I;
                case "__M256I_CONST_PTR": return ParamType.__M256I_CONST_PTR;
                case "__M256I_PTR": return ParamType.__M256I_PTR;
                case "__M512": return ParamType.__M512;
                case "__M512_PTR": return ParamType.__M512_PTR;
                case "__M512D": return ParamType.__M512D;
                case "__M512D_PTR": return ParamType.__M512D_PTR;
                case "__M512I": return ParamType.__M512I;
                case "__M64": return ParamType.__M64;
                case "__M64_CONST_PTR": return ParamType.__M64_CONST_PTR;
                case "__M64_PTR": return ParamType.__M64_PTR;
                case "__MMASK16": return ParamType.__MMASK16;
                case "__MMASK16_PTR": return ParamType.__MMASK16_PTR;
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
                case "_MM_PERM_ENUM": return ParamType._MM_PERM_ENUM;
                case "_MM_SWIZZLE_ENUM": return ParamType._MM_SWIZZLE_ENUM;
                case "CONST_MM_CMPINT_ENUM": return ParamType.CONST_MM_CMPINT_ENUM;
                case "CONST_INT": return ParamType.CONST_INT;
                case "CONST_UNSIGNED_INT": return ParamType.CONST_UNSIGNED_INT;
                case "CONST_VOID_PTR": return ParamType.CONST_VOID_PTR;
                case "CONST_VOID_PTR_PTR": return ParamType.CONST_VOID_PTR_PTR;
                case "CHAR": return ParamType.CHAR;
                case "CHAR_CONST_PTR": return ParamType.CHAR_CONST_PTR;
                case "CHAR_PTR": return ParamType.CHAR_PTR;
                case "DOUBLE": return ParamType.DOUBLE;
                case "DOUBLE_CONST_PTR": return ParamType.DOUBLE_CONST_PTR;
                case "DOUBLE_PTR": return ParamType.DOUBLE_PTR;
                case "FLOAT": return ParamType.FLOAT;
                case "FLOAT_CONST_PTR": return ParamType.FLOAT_CONST_PTR;
                case "FLOAT_PTR": return ParamType.FLOAT_PTR;
                case "INT": return ParamType.INT;
                case "INT_CONST_PTR": return ParamType.INT_CONST_PTR;
                case "INT_PTR": return ParamType.INT_PTR;
                case "LONG_LONG": return ParamType.LONG_LONG;
                case "SIZE_T": return ParamType.SIZE_T;
                case "SIZE_T_PTR": return ParamType.SIZE_T_PTR;
                case "SHORT": return ParamType.SHORT;
                case "UNSIGNED__INT32": return ParamType.UNSIGNED__INT32;
                case "UNSIGNED__INT32_PTR": return ParamType.UNSIGNED__INT32_PTR;
                case "UNSIGNED__INT64": return ParamType.UNSIGNED__INT64;
                case "UNSIGNED__INT64_PTR": return ParamType.UNSIGNED__INT64_PTR;
                case "UNSIGNED_CHAR": return ParamType.UNSIGNED_CHAR;
                case "UNSIGNED_INT": return ParamType.UNSIGNED_INT;
                case "UNSIGNED_INT_PTR": return ParamType.UNSIGNED_INT_PTR;
                case "UNSIGNED_LONG": return ParamType.UNSIGNED_LONG;
                case "UNSIGNED_LONG_PTR": return ParamType.UNSIGNED_LONG_PTR;
                case "UNSIGNED_SHORT": return ParamType.UNSIGNED_SHORT;
                case "UNSIGNED_SHORT_PTR": return ParamType.UNSIGNED_SHORT_PTR;
                case "VOID": return ParamType.VOID;
                case "VOID_PTR": return ParamType.VOID_PTR;
                case "VOID_CONST_PTR": return ParamType.VOID_CONST_PTR;
                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseParamType_InternalName: unknown ParamType \"" + str + "\".");
                    return ParamType.NONE;
            }
        }

        /// <summary>
        /// parse human readable text to ParamType
        /// </summary>
        public static ParamType ParseParamType(string str, bool warn = true)
        {
            string str2 = str.ToUpper().Replace(" *", "*");

            switch (str2) {
                case "__INT8": return ParamType.__INT8;
                case "__INT16": return ParamType.__INT16;
                case "__INT32": return ParamType.__INT32;
                case "__INT32*": return ParamType.__INT32_PTR;
                case "__INT64": return ParamType.__INT64;
                case "__INT64 CONST*": return ParamType.__INT64_CONST_PTR;
                case "__INT64*": return ParamType.__INT64_PTR;
                case "__M128": return ParamType.__M128;
                case "__M128 CONST*": return ParamType.__M128_CONST_PTR;
                case "__M128*": return ParamType.__M128_PTR;
                case "__M128D": return ParamType.__M128D;
                case "__M128D CONST*": return ParamType.__M128D_CONST_PTR;
                case "__M128D*": return ParamType.__M128D_PTR;
                case "__M128I": return ParamType.__M128I;
                case "__M128I CONST*": return ParamType.__M128I_CONST_PTR;
                case "CONST __M128I*": return ParamType.__M128I_CONST_PTR;
                case "_M128I*": return ParamType.__M128I_PTR;
                case "__M128I*": return ParamType.__M128I_PTR;
                case "__M256": return ParamType.__M256;
                case "__M256*": return ParamType.__M256_PTR;
                case "__M256D": return ParamType.__M256D;
                case "__M256D*": return ParamType.__M256D_PTR;
                case "__M256I": return ParamType.__M256I;
                case "__M256I CONST*": return ParamType.__M256I_CONST_PTR;
                case "__M256I*": return ParamType.__M256I_PTR;
                case "_M512": return ParamType.__M512;
                case "__M512": return ParamType.__M512;
                case "__M512*": return ParamType.__M512_PTR;
                case "__M512D": return ParamType.__M512D;
                case "__M512D*": return ParamType.__M512D_PTR;
                case "_M512I": return ParamType.__M512I;
                case "__M512I": return ParamType.__M512I;
                case "__M64": return ParamType.__M64;
                case "__M64*": return ParamType.__M64_PTR;
                case "__M64 CONST*": return ParamType.__M64_CONST_PTR;
                case "_MMASK16": return ParamType.__MMASK16;
                case "__MMASK16": return ParamType.__MMASK16;
                case "__MMASK16*": return ParamType.__MMASK16_PTR;
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
                case "_MM_PERM_ENUM": return ParamType._MM_PERM_ENUM;
                case "_MM_SWIZZLE_ENUM": return ParamType._MM_SWIZZLE_ENUM;
                case "CONST _MM_CMPINT_ENUM": return ParamType.CONST_MM_CMPINT_ENUM;
                case "CONST INT": return ParamType.CONST_INT;
                case "CONST UNSIGNED INT": return ParamType.CONST_UNSIGNED_INT;
                case "CONST VOID*": return ParamType.CONST_VOID_PTR;
                case "CONST VOID**": return ParamType.CONST_VOID_PTR_PTR;
                case "CHAR": return ParamType.CHAR;
                case "CHAR CONST*": return ParamType.CHAR_CONST_PTR;
                case "CHAR*": return ParamType.CHAR_PTR;
                case "DOUBLE": return ParamType.DOUBLE;
                case "CONST DOUBLE*":
                case "DOUBLE CONST*": return ParamType.DOUBLE_CONST_PTR;
                case "DOUBLE*": return ParamType.DOUBLE_PTR;
                case "FLOAT": return ParamType.FLOAT;
                case "CONST FLOAT*":
                case "FLOAT CONST*": return ParamType.FLOAT_CONST_PTR;
                case "FLOAT*": return ParamType.FLOAT_PTR;
                case "UNSIGNED":
                case "INT": return ParamType.INT;
                case "INT CONST*": return ParamType.INT_CONST_PTR;
                case "INT*": return ParamType.INT_PTR;
                case "LONG LONG": return ParamType.LONG_LONG;
                case "SIZE_T": return ParamType.SIZE_T;
                case "SIZE_T*": return ParamType.SIZE_T_PTR;
                case "SHORT": return ParamType.SHORT;
                case "UNSIGNED __INT32": return ParamType.UNSIGNED__INT32;
                case "UNSIGNED __INT32*": return ParamType.UNSIGNED__INT32_PTR;
                case "UNSIGNED __INT64": return ParamType.UNSIGNED__INT64;
                case "UNSIGNED __INT64*": return ParamType.UNSIGNED__INT64_PTR;
                case "UNSIGNED CHAR": return ParamType.UNSIGNED_CHAR;
                case "UNSIGNED INT": return ParamType.UNSIGNED_INT;
                case "UNSIGNED INT*": return ParamType.UNSIGNED_INT_PTR;
                case "UNSIGNED LONG": return ParamType.UNSIGNED_LONG;
                case "UNSIGNED LONG*": return ParamType.UNSIGNED_LONG_PTR;
                case "UNSIGNED SHORT": return ParamType.UNSIGNED_SHORT;
                case "UNSIGNED SHORT*": return ParamType.UNSIGNED_SHORT_PTR;
                case "VOID": return ParamType.VOID;
                case "VOID*": return ParamType.VOID_PTR;
                case "VOID CONST*": return ParamType.VOID_CONST_PTR;
                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseParamType: unknown ParamType: str=\"" + str + "\"; str2=\"" + str2 + "\".");
                    return ParamType.NONE;
            }
        }

        public static CpuID ParseCpuID(string str, bool warn = true)
        {
            switch (str.ToUpper())
            {
                case "":
                case "NONE": return CpuID.NONE;
                case "IA32": return CpuID.IA32;

                case "ADX": return CpuID.ADX;
                case "AES": return CpuID.AES;
                case "AVX": return CpuID.AVX;
                case "AVX2": return CpuID.AVX2;

                case "AVX512BW":
                case "AVX512_BW": return CpuID.AVX512_BW;
                case "AVX512CD":
                case "AVX512_CD": return CpuID.AVX512_CD;
                case "AVX512DQ":
                case "AVX512_DQ": return CpuID.AVX512_DQ;
                case "AVX512ER":
                case "AVX512_ER": return CpuID.AVX512_ER;
                case "AVX512":
                case "AVX512F":
                case "AVX512_F": return CpuID.AVX512_F;
                case "AVX512PF":
                case "AVX512_PF": return CpuID.AVX512_PF;
                case "AVX512VL":
                case "AVX512_VL": return CpuID.AVX512_VL;
                case "AVX5124VNNIW":
                case "AVX512_4VNNIW": return CpuID.AVX512_4VNNIW;
                case "AVX5124FMAPS":
                case "AVX512_4FMAPS": return CpuID.AVX512_4FMAPS;
                case "AVX512VPOPCNTDQ":
                case "AVX512_VPOPCNTDQ": return CpuID.AVX512_VPOPCNTDQ;

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
                case "SSE4_1":
                case "SSE4.1": return CpuID.SSE4_1;
                case "SSE4_2":
                case "SSE4.2": return CpuID.SSE4_2;
                case "SSSE3": return CpuID.SSSE3;

                case "LZCNT": return CpuID.LZCNT;
                case "AVX512IFMA52":
                case "AVX512_IFMA52": return CpuID.AVX512_IFMA52;
                case "INVPCID": return CpuID.INVPCID;
                case "MONITOR": return CpuID.MONITOR;
                case "AVX512VBMI":
                case "AVX512_VBMI": return CpuID.AVX512_VBMI;
                case "POPCNT": return CpuID.POPCNT;
                case "RDRAND": return CpuID.RDRAND;
                case "RDSEED": return CpuID.RDSEED;
                case "TSC": return CpuID.TSC;
                case "RDTSCP": return CpuID.RDTSCP;
                case "FSGSBASE": return CpuID.FSGSBASE;
                case "SHA": return CpuID.SHA;
                case "RTM": return CpuID.RTM;
                case "XSAVE": return CpuID.XSAVE;
                case "XSAVEC": return CpuID.XSAVEC;
                case "XSS": return CpuID.XSS;
                case "XSAVEOPT": return CpuID.XSAVEOPT;
                case "PREFETCHWT1": return CpuID.PREFETCHWT1;

                case "SVML": return CpuID.SVML;
                case "RDPID": return CpuID.RDPID;
                case "CLWB": return CpuID.CLWB;

                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseCpuID: unknown or unrecognized CpuID \"" + str + "\": returning "+CpuID.UNKNOWN);
                    return CpuID.UNKNOWN;
            }
        }

        public static CpuID ParseCpuID_multiple(string str, bool warn = true)
        {
            CpuID cpuID = CpuID.NONE;
            foreach (string cpuID_str in str.Split(','))
            {
                cpuID |= ParseCpuID(cpuID_str.Trim(), warn);
            }
            return cpuID;
        }

        public static bool IsSimdRegister(ReturnType type)
        {
            switch (type)
            {
                case ReturnType.__M128:
                case ReturnType.__M128D:
                case ReturnType.__M128I:
                case ReturnType.__M256:
                case ReturnType.__M256D:
                case ReturnType.__M256I:
                case ReturnType.__M512:
                case ReturnType.__M512D:
                case ReturnType.__M512I:
                case ReturnType.__M64:
                case ReturnType.__MMASK16:
                case ReturnType.__MMASK32:
                case ReturnType.__MMASK64:
                case ReturnType.__MMASK8:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsSimdRegister(ParamType type)
        {
            switch (type)
            {
                case ParamType.__M128:
                case ParamType.__M128_CONST_PTR:
                case ParamType.__M128_PTR:
                case ParamType.__M128D:
                case ParamType.__M128D_CONST_PTR:
                case ParamType.__M128D_PTR:
                case ParamType.__M128I:
                case ParamType.__M128I_CONST_PTR:
                case ParamType.__M128I_PTR:
                case ParamType.__M256:
                case ParamType.__M256_PTR:
                case ParamType.__M256D:
                case ParamType.__M256D_PTR:
                case ParamType.__M256I:
                case ParamType.__M256I_CONST_PTR:
                case ParamType.__M256I_PTR:
                case ParamType.__M512:
                case ParamType.__M512_PTR:
                case ParamType.__M512D:
                case ParamType.__M512D_PTR:
                case ParamType.__M512I:
                case ParamType.__M64:
                case ParamType.__M64_CONST_PTR:
                case ParamType.__M64_PTR:
                case ParamType.__MMASK16:
                case ParamType.__MMASK16_PTR:
                case ParamType.__MMASK32:
                case ParamType.__MMASK64:
                case ParamType.__MMASK8:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsSimdRegister(string str) {
            switch (str.ToUpper()) {
                case "__M128":
                case "__M128D":
                case "__M128I":
                case "__M256":
                case "__M256D":
                case "__M256I":
                case "__M512":
                case "__M512D":
                case "__M512I":
                case "__M64":
                case "__MMASK16":
                case "__MMASK32":
                case "__MMASK64":
                case "__MMASK8":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Write cpuIDs to string. If silence_DEFAULT is true, the CpuID.DEFAULT is not written.
        /// </summary>
        public static string ToString(CpuID cpuIDs)
        {
            StringBuilder sb = new StringBuilder();
            //TODO it is inefficient to test every bit, would be faster to do a bitscanforward
            foreach (CpuID value in Enum.GetValues(typeof(CpuID)))
            {
                if (value == CpuID.NONE) continue;
                if (cpuIDs.HasFlag(value))
                {
                    switch (value)
                    {
                        case CpuID.SSE4_1:
                            sb.Append("SSE4.1, ");
                            break;
                        case CpuID.SSE4_2:
                            sb.Append("SSE4.2, ");
                            break;
                        default:
                            sb.Append(value.ToString());
                            sb.Append(", ");
                            break;
                    }
                }
            }
            if (sb.Length > 0) sb.Length -= 2; // remove trailing comma
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
                case ParamType.__M128D_CONST_PTR: return "__m128d const *";
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
                case ParamType.CONST_MM_CMPINT_ENUM: return "const _MM_CMPINT_ENUM";
                case ParamType.CONST_INT: return "const int";
                case ParamType.CONST_VOID_PTR: return "const void *";
                case ParamType.CONST_VOID_PTR_PTR: return "const void **";
                case ParamType.DOUBLE: return "double";
                case ParamType.DOUBLE_CONST_PTR: return "double const *";
                case ParamType.FLOAT: return "float";
                case ParamType.FLOAT_CONST_PTR: return "float const *";
                case ParamType.INT: return "int";
                case ParamType.INT_CONST_PTR: return "int const *";
                case ParamType.SIZE_T: return "size_t";
                case ParamType.SHORT: return "short";
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

                case ParamType.__INT8: return "__int8";
                case ParamType.__INT16: return "__int16";
                case ParamType.__M128_PTR: return "__m128 *";
                case ParamType.__M128D_PTR: return "__m128d *";
                case ParamType.__M128I_CONST_PTR: return "__m128i const *";
                case ParamType.__M128I_PTR: return "__m128i *";
                case ParamType.__M256_PTR: return "__m256 *";
                case ParamType.__M256D_PTR: return "__m256d *";
                case ParamType.__M256I_CONST_PTR: return "__m256i const *";
                case ParamType.__M256I_PTR: return "__m256i *";
                case ParamType.__M512_PTR: return "__m512 *";
                case ParamType.__M512D_PTR: return "__m512d *";
                case ParamType.__M64_CONST_PTR: return "__m64 const *";
                case ParamType.__M64_PTR: return "__m64 *";
                case ParamType._MM_PERM_ENUM: return "_MM_PERM_ENUM";
                case ParamType._MM_SWIZZLE_ENUM: return "_MM_SWIZZLE_ENUM";
                case ParamType.CONST_UNSIGNED_INT: return "const unsigned int";
                case ParamType.CHAR: return "char";
                case ParamType.CHAR_CONST_PTR: return "char const *";
                case ParamType.CHAR_PTR: return "char *";
                case ParamType.DOUBLE_PTR: return "double *";
                case ParamType.FLOAT_PTR: return "float *";
                case ParamType.INT_PTR: return "int *";
                case ParamType.LONG_LONG: return "long long";
                case ParamType.UNSIGNED_LONG: return "unsigned long";
                case ParamType.UNSIGNED_LONG_PTR: return "unsigned long *";
                case ParamType.UNSIGNED_SHORT_PTR: return "unsigned short *";

                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: ToString: unknown ParamType \"" + type + "\".");
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
                case ReturnType.__M128I: return "__m128i";
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
                case ReturnType.SHORT: return "short";
                case ReturnType.UNSIGNED__INT32: return "unsigned __int32";
                case ReturnType.UNSIGNED__INT64: return "unsigned __int64";
                case ReturnType.UNSIGNED_CHAR: return "unsigned char";
                case ReturnType.UNSIGNED_INT: return "unsigned int";
                case ReturnType.UNSIGNED_SHORT: return "unsigned short";
                case ReturnType.UNSIGNED_LONG: return "unsigned long";
                case ReturnType.VOID: return "void";
                case ReturnType.VOID_PTR: return "void *";
                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: ToString: unknown ReturnType \"" + type + "\".");
                    return type.ToString();
                    break;
            }
        }

        public static string GetCpuID_Documentation(CpuID cpuID)
        {
            switch (cpuID)
            {
                case CpuID.NONE: return "";
                case CpuID.SVML: return "";
                case CpuID.IA32: return "";
                case CpuID.ADX: return "Multi-Precision Add-Carry Instruction Extension";
                case CpuID.AES: return "Advanced Encryption Standard Extension";
                case CpuID.AVX: return "";
                case CpuID.AVX2: return "";
                case CpuID.AVX512_F: return "Instruction set AVX512 Foundation (Xeon Phi Knights Landing, Xeon Skylake)";
                case CpuID.AVX512_CD: return "Instruction set AVX512 Conflict Detection (Xeon Phi Knights Landing, Xeon Skylake)";
                case CpuID.AVX512_ER: return "Instruction set AVX512 Exponential and Reciprocal (Xeon Phi Knights Landing)";
                case CpuID.AVX512_PF: return "Instruction set AVX512 Prefetch (Xeon Phi Knights Landing)";
                case CpuID.AVX512_BW: return "Instruction set AVX512 Byte and Word (Xeon Skylake)";
                case CpuID.AVX512_DQ: return "Instruction set AVX512 Doubleword and QuadWord (Xeon Skylake)";
                case CpuID.AVX512_VL: return "Instruction set AVX512 Vector Length Extensions (Xeon Skylake)";
                case CpuID.AVX512_IFMA52: return "Instruction set AVX512 52-bit Integer Multiply-Add (Xeon Cannonlake)";
                case CpuID.AVX512_VBMI: return "Instruction set AVX512 Vector Bit-Manipulation (Xeon Cannonlake)";

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

                case CpuID.LZCNT: return "";
                case CpuID.INVPCID: return "";
                case CpuID.MONITOR: return "";
                case CpuID.POPCNT: return "";
                case CpuID.RDRAND: return "";
                case CpuID.RDSEED: return "";
                case CpuID.TSC: return "";
                case CpuID.RDTSCP: return "";
                case CpuID.FSGSBASE: return "";
                case CpuID.SHA: return "";
                case CpuID.RTM: return "";
                case CpuID.XSAVE: return "";
                case CpuID.XSAVEC: return "";
                case CpuID.XSS: return "";
                case CpuID.XSAVEOPT: return "";
                case CpuID.PREFETCHWT1: return "";

                case CpuID.RDPID: return "Read Processor ID";
                case CpuID.CLWB: return "Cache Line Write Back";

                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: getCpuID_Documentation: unknown CpuID \"" + cpuID + "\".");
                    return "";
            }
        }

        /// <summary>return true if type2 be cast to type1; false otherwise</summary>
        public static bool IsConversionPossible(ReturnType type1, ReturnType type2) {

            if (type2 == ReturnType.UNKNOWN) return true;

            switch (type1) {
                case ReturnType.UNKNOWN: return true;

                case ReturnType.__M128: return (type2 == ReturnType.__M128);
                case ReturnType.__M128D: return (type2 == ReturnType.__M128D);
                case ReturnType.__M128I: return (type2 == ReturnType.__M128I);
                case ReturnType.__M256: return (type2 == ReturnType.__M256);
                case ReturnType.__M256D: return (type2 == ReturnType.__M256D);
                case ReturnType.__M256I: return (type2 == ReturnType.__M256I);
                case ReturnType.__M512: return (type2 == ReturnType.__M512);
                case ReturnType.__M512D: return (type2 == ReturnType.__M512D);
                case ReturnType.__M512I: return (type2 == ReturnType.__M512I);
                case ReturnType.__M64: return (type2 == ReturnType.__M64);
                case ReturnType.__MMASK16: return (type2 == ReturnType.__MMASK16);
                case ReturnType.__MMASK32: return (type2 == ReturnType.__MMASK32);
                case ReturnType.__MMASK64: return (type2 == ReturnType.__MMASK64);
                case ReturnType.__MMASK8: return (type2 == ReturnType.__MMASK8);

                case ReturnType.__INT16:
                case ReturnType.__INT32:
                case ReturnType.__INT64:
                case ReturnType.__INT8:
                case ReturnType.DOUBLE:
                case ReturnType.FLOAT:
                case ReturnType.INT:
                case ReturnType.SHORT:
                case ReturnType.UNSIGNED__INT32:
                case ReturnType.UNSIGNED__INT64:
                case ReturnType.UNSIGNED_CHAR:
                case ReturnType.UNSIGNED_INT:
                case ReturnType.UNSIGNED_LONG:
                case ReturnType.UNSIGNED_SHORT:
                case ReturnType.CONST_VOID_PTR:
                case ReturnType.VOID:
                case ReturnType.VOID_PTR:
                    switch (type2) {
                        case ReturnType.__M128:
                        case ReturnType.__M128D:
                        case ReturnType.__M128I:
                        case ReturnType.__M256:
                        case ReturnType.__M256D:
                        case ReturnType.__M256I:
                        case ReturnType.__M512:
                        case ReturnType.__M512D:
                        case ReturnType.__M512I:
                        case ReturnType.__M64:
                        case ReturnType.__MMASK16:
                        case ReturnType.__MMASK32:
                        case ReturnType.__MMASK64:
                        case ReturnType.__MMASK8:
                            return false;
                        default:
                            return true;
                    }
                    break;
                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: conversionPossible: unknown or unrecognized ReturnType \"" + type1 + "\": returning false");
                    return false;
            }
        }

        public static bool IsCpuID_Enabled(CpuID cpuID_intrisic, CpuID selectedArchitectures)
        {
            if (cpuID_intrisic.HasFlag(CpuID.SVML) && !selectedArchitectures.HasFlag(CpuID.SVML))
            {
                return false;
            }
            CpuID commonCpuID = (selectedArchitectures & cpuID_intrisic);
            //IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: isCpuID_Enabled: cpuID_intrisic=" + IntrinsicTools.ToString(cpuID_intrisic) + "; selectedArchitectures="+IntrinsicTools.ToString(selectedArchitectures) +"; commonCpuID " + IntrinsicTools.ToString(commonCpuID));
            return (commonCpuID != CpuID.NONE);
        }

        #region Text Wrap
        /// <summary>
        /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
        /// </summary>
        /// <param name="str">The string to wrap.</param>
        /// <param name="maxLength">The maximum number of characters per line.</param>
        /// <returns></returns>
        public static string Linewrap(this string str, int maxLength)
        {
            return Linewrap(str, maxLength, "");
        }

        /// <summary>
        /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
        /// </summary>
        /// <param name="str">The string to wrap.</param>
        /// <param name="maxLength">The maximum number of characters per line.</param>
        /// <param name="prefix">Adds this string to the beginning of each line.</param>
        /// <returns></returns>
        private static string Linewrap(string str, int maxLength, string prefix)
        {
            if (string.IsNullOrEmpty(str)) return "";
            if (maxLength <= 0) return prefix + str;

            IList<string> lines = new List<string>();

            // breaking the string into lines makes it easier to process.
            foreach (string line in str.Split("\n".ToCharArray()))
            {
                var remainingLine = line.Trim();
                do
                {
                    var newLine = GetLine(remainingLine, maxLength - prefix.Length);
                    lines.Add(newLine);
                    remainingLine = remainingLine.Substring(newLine.Length).TrimEnd();
                    // Keep iterating as int as we've got words remaining 
                    // in the line.
                } while (remainingLine.Length > 0);
            }

            return string.Join(Environment.NewLine + prefix, lines.ToArray());
        }
        private static string GetLine(string str, int maxLength)
        {
            // The string is less than the max length so just return it.
            if (str.Length <= maxLength) return str;

            // Search backwords in the string for a whitespace char
            // starting with the char one after the maximum length
            // (if the next char is a whitespace, the last word fits).
            for (int i = maxLength; i >= 0; i--)
            {
                if (IsTextSeparatorChar(str[i]))
                    return str.Substring(0, i).TrimEnd();
            }

            // No whitespace chars, just break the word at the maxlength.
            return str.Substring(0, maxLength);
        }

        private static bool IsTextSeparatorChar(char c)
        {
            return char.IsWhiteSpace(c) || c.Equals('.') || c.Equals(',') || c.Equals(';') || c.Equals('?') || c.Equals('!') || c.Equals(')') || c.Equals(']') || c.Equals('-');
        }

        #endregion Text Wrap

        /// <summary>
        /// Return true if the provided intrinsic uses a MMX register as its parameters or return type
        /// </summary>
        public static bool Uses_MMX_Register(Intrinsic intrinsic)
        {
            switch (intrinsic)
            {
                case Intrinsic._M_FROM_INT:
                case Intrinsic._M_FROM_INT64:
                case Intrinsic._M_MASKMOVQ:
                case Intrinsic._M_PACKSSDW:
                case Intrinsic._M_PACKSSWB:
                case Intrinsic._M_PACKUSWB:
                case Intrinsic._M_PADDB:
                case Intrinsic._M_PADDD:
                case Intrinsic._M_PADDSB:
                case Intrinsic._M_PADDSW:
                case Intrinsic._M_PADDUSB:
                case Intrinsic._M_PADDUSW:
                case Intrinsic._M_PADDW:
                case Intrinsic._M_PAND:
                case Intrinsic._M_PANDN:
                case Intrinsic._M_PAVGB:
                case Intrinsic._M_PAVGW:
                case Intrinsic._M_PCMPEQB:
                case Intrinsic._M_PCMPEQD:
                case Intrinsic._M_PCMPEQW:
                case Intrinsic._M_PCMPGTB:
                case Intrinsic._M_PCMPGTD:
                case Intrinsic._M_PCMPGTW:
                case Intrinsic._M_PEXTRW:
                case Intrinsic._M_PINSRW:
                case Intrinsic._M_PMADDWD:
                case Intrinsic._M_PMAXSW:
                case Intrinsic._M_PMAXUB:
                case Intrinsic._M_PMINSW:
                case Intrinsic._M_PMINUB:
                case Intrinsic._M_PMOVMSKB:
                case Intrinsic._M_PMULHUW:
                case Intrinsic._M_PMULHW:
                case Intrinsic._M_PMULLW:
                case Intrinsic._M_POR:
                case Intrinsic._M_PSADBW:
                case Intrinsic._M_PSHUFW:
                case Intrinsic._M_PSLLD:
                case Intrinsic._M_PSLLDI:
                case Intrinsic._M_PSLLQ:
                case Intrinsic._M_PSLLQI:
                case Intrinsic._M_PSLLW:
                case Intrinsic._M_PSLLWI:
                case Intrinsic._M_PSRAD:
                case Intrinsic._M_PSRADI:
                case Intrinsic._M_PSRAW:
                case Intrinsic._M_PSRAWI:
                case Intrinsic._M_PSRLD:
                case Intrinsic._M_PSRLDI:
                case Intrinsic._M_PSRLQ:
                case Intrinsic._M_PSRLQI:
                case Intrinsic._M_PSRLW:
                case Intrinsic._M_PSRLWI:
                case Intrinsic._M_PSUBB:
                case Intrinsic._M_PSUBD:
                case Intrinsic._M_PSUBSB:
                case Intrinsic._M_PSUBSW:
                case Intrinsic._M_PSUBUSB:
                case Intrinsic._M_PSUBUSW:
                case Intrinsic._M_PSUBW:
                case Intrinsic._M_PUNPCKHBW:
                case Intrinsic._M_PUNPCKHDQ:
                case Intrinsic._M_PUNPCKHWD:
                case Intrinsic._M_PUNPCKLBW:
                case Intrinsic._M_PUNPCKLDQ:
                case Intrinsic._M_PUNPCKLWD:
                case Intrinsic._M_PXOR:
                case Intrinsic._M_TO_INT:
                case Intrinsic._M_TO_INT64:
                case Intrinsic._MM_ABS_PI16:
                case Intrinsic._MM_ABS_PI32:
                case Intrinsic._MM_ABS_PI8:
                case Intrinsic._MM_ADD_PI16:
                case Intrinsic._MM_ADD_PI32:
                case Intrinsic._MM_ADD_PI8:
                case Intrinsic._MM_ADD_SI64:
                case Intrinsic._MM_ADDS_PI16:
                case Intrinsic._MM_ADDS_PI8:
                case Intrinsic._MM_ADDS_PU16:
                case Intrinsic._MM_ADDS_PU8:
                case Intrinsic._MM_ALIGNR_PI8:
                case Intrinsic._MM_AND_SI64:
                case Intrinsic._MM_ANDNOT_SI64:
                case Intrinsic._MM_AVG_PU16:
                case Intrinsic._MM_AVG_PU8:
                case Intrinsic._MM_CMPEQ_PI16:
                case Intrinsic._MM_CMPEQ_PI32:
                case Intrinsic._MM_CMPEQ_PI8:
                case Intrinsic._MM_CMPGT_PI16:
                case Intrinsic._MM_CMPGT_PI32:
                case Intrinsic._MM_CMPGT_PI8:
                case Intrinsic._MM_CVT_PI2PS:
                case Intrinsic._MM_CVT_PS2PI:
                case Intrinsic._MM_CVTM64_SI64:
                case Intrinsic._MM_CVTPD_PI32:
                case Intrinsic._MM_CVTPI16_PS:
                case Intrinsic._MM_CVTPI32_PD:
                case Intrinsic._MM_CVTPI32_PS:
                case Intrinsic._MM_CVTPI32X2_PS:
                case Intrinsic._MM_CVTPI8_PS:
                case Intrinsic._MM_CVTPS_PI16:
                case Intrinsic._MM_CVTPS_PI32:
                case Intrinsic._MM_CVTPS_PI8:
                case Intrinsic._MM_CVTPU16_PS:
                case Intrinsic._MM_CVTPU8_PS:
                case Intrinsic._MM_CVTSI32_SI64:
                case Intrinsic._MM_CVTSI64_M64:
                case Intrinsic._MM_CVTSI64_SI32:
                case Intrinsic._MM_CVTT_PS2PI:
                case Intrinsic._MM_CVTTPD_PI32:
                case Intrinsic._MM_CVTTPS_PI32:
                case Intrinsic._MM_EXTRACT_PI16:
                case Intrinsic._MM_HADD_PI16:
                case Intrinsic._MM_HADD_PI32:
                case Intrinsic._MM_HADDS_PI16:
                case Intrinsic._MM_HSUB_PI16:
                case Intrinsic._MM_HSUB_PI32:
                case Intrinsic._MM_HSUBS_PI16:
                case Intrinsic._MM_INSERT_PI16:
                case Intrinsic._MM_LOADH_PI:
                case Intrinsic._MM_LOADL_PI:
                case Intrinsic._MM_MADD_PI16:
                case Intrinsic._MM_MADDUBS_PI16:
                case Intrinsic._MM_MASKMOVE_SI64:
                case Intrinsic._MM_MAX_PI16:
                case Intrinsic._MM_MAX_PU8:
                case Intrinsic._MM_MIN_PI16:
                case Intrinsic._MM_MIN_PU8:
                case Intrinsic._MM_MOVEMASK_PI8:
                case Intrinsic._MM_MOVEPI64_PI64:
                case Intrinsic._MM_MOVPI64_EPI64:
                case Intrinsic._MM_MUL_SU32:
                case Intrinsic._MM_MULHI_PI16:
                case Intrinsic._MM_MULHI_PU16:
                case Intrinsic._MM_MULHRS_PI16:
                case Intrinsic._MM_MULLO_PI16:
                case Intrinsic._MM_OR_SI64:
                case Intrinsic._MM_PACKS_PI16:
                case Intrinsic._MM_PACKS_PI32:
                case Intrinsic._MM_PACKS_PU16:
                case Intrinsic._MM_SAD_PU8:
                case Intrinsic._MM_SET_EPI64:
                case Intrinsic._MM_SET_PI16:
                case Intrinsic._MM_SET_PI32:
                case Intrinsic._MM_SET_PI8:
                case Intrinsic._MM_SET1_EPI64:
                case Intrinsic._MM_SET1_PI16:
                case Intrinsic._MM_SET1_PI32:
                case Intrinsic._MM_SET1_PI8:
                case Intrinsic._MM_SETR_EPI64:
                case Intrinsic._MM_SETR_PI16:
                case Intrinsic._MM_SETR_PI32:
                case Intrinsic._MM_SETR_PI8:
                case Intrinsic._MM_SETZERO_SI64:
                case Intrinsic._MM_SHUFFLE_PI16:
                case Intrinsic._MM_SHUFFLE_PI8:
                case Intrinsic._MM_SIGN_PI16:
                case Intrinsic._MM_SIGN_PI32:
                case Intrinsic._MM_SIGN_PI8:
                case Intrinsic._MM_SLL_PI16:
                case Intrinsic._MM_SLL_PI32:
                case Intrinsic._MM_SLL_SI64:
                case Intrinsic._MM_SLLI_PI16:
                case Intrinsic._MM_SLLI_PI32:
                case Intrinsic._MM_SLLI_SI64:
                case Intrinsic._MM_SRA_PI16:
                case Intrinsic._MM_SRA_PI32:
                case Intrinsic._MM_SRAI_PI16:
                case Intrinsic._MM_SRAI_PI32:
                case Intrinsic._MM_SRL_PI16:
                case Intrinsic._MM_SRL_PI32:
                case Intrinsic._MM_SRL_SI64:
                case Intrinsic._MM_SRLI_PI16:
                case Intrinsic._MM_SRLI_PI32:
                case Intrinsic._MM_SRLI_SI64:
                case Intrinsic._MM_STOREH_PI:
                case Intrinsic._MM_STOREL_PI:
                case Intrinsic._MM_STREAM_PI:
                case Intrinsic._MM_SUB_PI16:
                case Intrinsic._MM_SUB_PI32:
                case Intrinsic._MM_SUB_PI8:
                case Intrinsic._MM_SUB_SI64:
                case Intrinsic._MM_SUBS_PI16:
                case Intrinsic._MM_SUBS_PI8:
                case Intrinsic._MM_SUBS_PU16:
                case Intrinsic._MM_SUBS_PU8:
                case Intrinsic._MM_UNPACKHI_PI16:
                case Intrinsic._MM_UNPACKHI_PI32:
                case Intrinsic._MM_UNPACKHI_PI8:
                case Intrinsic._MM_UNPACKLO_PI16:
                case Intrinsic._MM_UNPACKLO_PI32:
                case Intrinsic._MM_UNPACKLO_PI8:
                case Intrinsic._MM_XOR_SI64:
                    return true;
                default:
                    return false;
            }
        }

        public static Tuple<Intrinsic, int> GetIntrinsicAndParamIndex(SnapshotPoint point, ITextStructureNavigator nav)
        {
            int nClosingParenthesis = 0;
            int nParameters = 0;

            SnapshotPoint currentPos = point;
            for (int i = 0; i<1000; i++)
            {
                TextExtent extent = nav.GetExtentOfWord(currentPos);
                string word = extent.Span.GetText();
                //IntrinsicsDudeToolsStatic.Output("INFO: IntrSignHelpCommandHandler: getIntrinsicAndParamIndex: word=\"" + word+"\".");

                if (word.Contains(";")) break;
                if (word.Equals("=")) break;
                if (word.Equals(")"))
                {
                    nClosingParenthesis++;
                }
                else if (word.Equals("("))
                {
                    if (nClosingParenthesis == 0)
                    {
                        if (extent.Span.Start > 0)
                        {
                            string word2 = nav.GetExtentOfWord(extent.Span.Start - 1).Span.GetText();
                            return new Tuple<Intrinsic, int>(IntrinsicTools.ParseIntrinsic(word2, false), nParameters);
                        }
                    }
                    else
                    {
                        nClosingParenthesis--;
                    }
                }
                else if (word.Equals(","))
                {
                    if (nClosingParenthesis == 0)
                    {
                        nParameters++;
                    }
                }
                if (extent.Span.Start == 0) break;
                currentPos = extent.Span.Start - 1;
            }
            return new Tuple<Intrinsic, int>(Intrinsic.NONE, 0);
        }

        public static Intrinsic ParseIntrinsic(string str, bool warn = true)
        {
            if (str == null)
            {
                if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseIntrinsic: str is null");
                return Intrinsic.NONE;
            }
            if (str.Length < 4)
            {
                if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseIntrinsic: unknown Intrinsic \"" + str + "\".");
                return Intrinsic.NONE;
            }
            if (!str[0].Equals('_'))
            {
                if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseIntrinsic: unknown Intrinsic \"" + str + "\".");
                return Intrinsic.NONE;
            }
            switch (str.ToUpper())
            {
                case "__RDTSCP": return Intrinsic.__RDTSCP;
                case "_ADDCARRY_U32": return Intrinsic._ADDCARRY_U32;
                case "_ADDCARRY_U64": return Intrinsic._ADDCARRY_U64;
                case "_ADDCARRYX_U32": return Intrinsic._ADDCARRYX_U32;
                case "_ADDCARRYX_U64": return Intrinsic._ADDCARRYX_U64;
                case "_ALLOW_CPU_FEATURES": return Intrinsic._ALLOW_CPU_FEATURES;
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
                case "_BSWAP": return Intrinsic._BSWAP;
                case "_BSWAP64": return Intrinsic._BSWAP64;
                case "_BZHI_U32": return Intrinsic._BZHI_U32;
                case "_BZHI_U64": return Intrinsic._BZHI_U64;
                case "_CASTF32_U32": return Intrinsic._CASTF32_U32;
                case "_CASTF64_U64": return Intrinsic._CASTF64_U64;
                case "_CASTU32_F32": return Intrinsic._CASTU32_F32;
                case "_CASTU64_F64": return Intrinsic._CASTU64_F64;
                case "_CVTSH_SS": return Intrinsic._CVTSH_SS;
                case "_CVTSS_SH": return Intrinsic._CVTSS_SH;
                case "_FXRSTOR": return Intrinsic._FXRSTOR;
                case "_FXRSTOR64": return Intrinsic._FXRSTOR64;
                case "_FXSAVE": return Intrinsic._FXSAVE;
                case "_FXSAVE64": return Intrinsic._FXSAVE64;
                case "_INVPCID": return Intrinsic._INVPCID;
                case "_LOADBE_I16": return Intrinsic._LOADBE_I16;
                case "_LOADBE_I32": return Intrinsic._LOADBE_I32;
                case "_LOADBE_I64": return Intrinsic._LOADBE_I64;
                case "_LROTL": return Intrinsic._LROTL;
                case "_LROTR": return Intrinsic._LROTR;
                case "_LZCNT_U32": return Intrinsic._LZCNT_U32;
                case "_LZCNT_U64": return Intrinsic._LZCNT_U64;
                case "_M_EMPTY": return Intrinsic._M_EMPTY;
                case "_M_FROM_INT": return Intrinsic._M_FROM_INT;
                case "_M_FROM_INT64": return Intrinsic._M_FROM_INT64;
                case "_M_MASKMOVQ": return Intrinsic._M_MASKMOVQ;
                case "_M_PACKSSDW": return Intrinsic._M_PACKSSDW;
                case "_M_PACKSSWB": return Intrinsic._M_PACKSSWB;
                case "_M_PACKUSWB": return Intrinsic._M_PACKUSWB;
                case "_M_PADDB": return Intrinsic._M_PADDB;
                case "_M_PADDD": return Intrinsic._M_PADDD;
                case "_M_PADDSB": return Intrinsic._M_PADDSB;
                case "_M_PADDSW": return Intrinsic._M_PADDSW;
                case "_M_PADDUSB": return Intrinsic._M_PADDUSB;
                case "_M_PADDUSW": return Intrinsic._M_PADDUSW;
                case "_M_PADDW": return Intrinsic._M_PADDW;
                case "_M_PAND": return Intrinsic._M_PAND;
                case "_M_PANDN": return Intrinsic._M_PANDN;
                case "_M_PAVGB": return Intrinsic._M_PAVGB;
                case "_M_PAVGW": return Intrinsic._M_PAVGW;
                case "_M_PCMPEQB": return Intrinsic._M_PCMPEQB;
                case "_M_PCMPEQD": return Intrinsic._M_PCMPEQD;
                case "_M_PCMPEQW": return Intrinsic._M_PCMPEQW;
                case "_M_PCMPGTB": return Intrinsic._M_PCMPGTB;
                case "_M_PCMPGTD": return Intrinsic._M_PCMPGTD;
                case "_M_PCMPGTW": return Intrinsic._M_PCMPGTW;
                case "_M_PEXTRW": return Intrinsic._M_PEXTRW;
                case "_M_PINSRW": return Intrinsic._M_PINSRW;
                case "_M_PMADDWD": return Intrinsic._M_PMADDWD;
                case "_M_PMAXSW": return Intrinsic._M_PMAXSW;
                case "_M_PMAXUB": return Intrinsic._M_PMAXUB;
                case "_M_PMINSW": return Intrinsic._M_PMINSW;
                case "_M_PMINUB": return Intrinsic._M_PMINUB;
                case "_M_PMOVMSKB": return Intrinsic._M_PMOVMSKB;
                case "_M_PMULHUW": return Intrinsic._M_PMULHUW;
                case "_M_PMULHW": return Intrinsic._M_PMULHW;
                case "_M_PMULLW": return Intrinsic._M_PMULLW;
                case "_M_POR": return Intrinsic._M_POR;
                case "_M_PSADBW": return Intrinsic._M_PSADBW;
                case "_M_PSHUFW": return Intrinsic._M_PSHUFW;
                case "_M_PSLLD": return Intrinsic._M_PSLLD;
                case "_M_PSLLDI": return Intrinsic._M_PSLLDI;
                case "_M_PSLLQ": return Intrinsic._M_PSLLQ;
                case "_M_PSLLQI": return Intrinsic._M_PSLLQI;
                case "_M_PSLLW": return Intrinsic._M_PSLLW;
                case "_M_PSLLWI": return Intrinsic._M_PSLLWI;
                case "_M_PSRAD": return Intrinsic._M_PSRAD;
                case "_M_PSRADI": return Intrinsic._M_PSRADI;
                case "_M_PSRAW": return Intrinsic._M_PSRAW;
                case "_M_PSRAWI": return Intrinsic._M_PSRAWI;
                case "_M_PSRLD": return Intrinsic._M_PSRLD;
                case "_M_PSRLDI": return Intrinsic._M_PSRLDI;
                case "_M_PSRLQ": return Intrinsic._M_PSRLQ;
                case "_M_PSRLQI": return Intrinsic._M_PSRLQI;
                case "_M_PSRLW": return Intrinsic._M_PSRLW;
                case "_M_PSRLWI": return Intrinsic._M_PSRLWI;
                case "_M_PSUBB": return Intrinsic._M_PSUBB;
                case "_M_PSUBD": return Intrinsic._M_PSUBD;
                case "_M_PSUBSB": return Intrinsic._M_PSUBSB;
                case "_M_PSUBSW": return Intrinsic._M_PSUBSW;
                case "_M_PSUBUSB": return Intrinsic._M_PSUBUSB;
                case "_M_PSUBUSW": return Intrinsic._M_PSUBUSW;
                case "_M_PSUBW": return Intrinsic._M_PSUBW;
                case "_M_PUNPCKHBW": return Intrinsic._M_PUNPCKHBW;
                case "_M_PUNPCKHDQ": return Intrinsic._M_PUNPCKHDQ;
                case "_M_PUNPCKHWD": return Intrinsic._M_PUNPCKHWD;
                case "_M_PUNPCKLBW": return Intrinsic._M_PUNPCKLBW;
                case "_M_PUNPCKLDQ": return Intrinsic._M_PUNPCKLDQ;
                case "_M_PUNPCKLWD": return Intrinsic._M_PUNPCKLWD;
                case "_M_PXOR": return Intrinsic._M_PXOR;
                case "_M_TO_INT": return Intrinsic._M_TO_INT;
                case "_M_TO_INT64": return Intrinsic._M_TO_INT64;
                case "_MAY_I_USE_CPU_FEATURE": return Intrinsic._MAY_I_USE_CPU_FEATURE;
                case "_MM_ABS_EPI16": return Intrinsic._MM_ABS_EPI16;
                case "_MM_ABS_EPI32": return Intrinsic._MM_ABS_EPI32;
                case "_MM_ABS_EPI64": return Intrinsic._MM_ABS_EPI64;
                case "_MM_ABS_EPI8": return Intrinsic._MM_ABS_EPI8;
                case "_MM_ABS_PI16": return Intrinsic._MM_ABS_PI16;
                case "_MM_ABS_PI32": return Intrinsic._MM_ABS_PI32;
                case "_MM_ABS_PI8": return Intrinsic._MM_ABS_PI8;
                case "_MM_ACOS_PD": return Intrinsic._MM_ACOS_PD;
                case "_MM_ACOS_PS": return Intrinsic._MM_ACOS_PS;
                case "_MM_ACOSH_PD": return Intrinsic._MM_ACOSH_PD;
                case "_MM_ACOSH_PS": return Intrinsic._MM_ACOSH_PS;
                case "_MM_ADD_EPI16": return Intrinsic._MM_ADD_EPI16;
                case "_MM_ADD_EPI32": return Intrinsic._MM_ADD_EPI32;
                case "_MM_ADD_EPI64": return Intrinsic._MM_ADD_EPI64;
                case "_MM_ADD_EPI8": return Intrinsic._MM_ADD_EPI8;
                case "_MM_ADD_PD": return Intrinsic._MM_ADD_PD;
                case "_MM_ADD_PI16": return Intrinsic._MM_ADD_PI16;
                case "_MM_ADD_PI32": return Intrinsic._MM_ADD_PI32;
                case "_MM_ADD_PI8": return Intrinsic._MM_ADD_PI8;
                case "_MM_ADD_PS": return Intrinsic._MM_ADD_PS;
                case "_MM_ADD_ROUND_SD": return Intrinsic._MM_ADD_ROUND_SD;
                case "_MM_ADD_ROUND_SS": return Intrinsic._MM_ADD_ROUND_SS;
                case "_MM_ADD_SD": return Intrinsic._MM_ADD_SD;
                case "_MM_ADD_SI64": return Intrinsic._MM_ADD_SI64;
                case "_MM_ADD_SS": return Intrinsic._MM_ADD_SS;
                case "_MM_ADDS_EPI16": return Intrinsic._MM_ADDS_EPI16;
                case "_MM_ADDS_EPI8": return Intrinsic._MM_ADDS_EPI8;
                case "_MM_ADDS_EPU16": return Intrinsic._MM_ADDS_EPU16;
                case "_MM_ADDS_EPU8": return Intrinsic._MM_ADDS_EPU8;
                case "_MM_ADDS_PI16": return Intrinsic._MM_ADDS_PI16;
                case "_MM_ADDS_PI8": return Intrinsic._MM_ADDS_PI8;
                case "_MM_ADDS_PU16": return Intrinsic._MM_ADDS_PU16;
                case "_MM_ADDS_PU8": return Intrinsic._MM_ADDS_PU8;
                case "_MM_ADDSUB_PD": return Intrinsic._MM_ADDSUB_PD;
                case "_MM_ADDSUB_PS": return Intrinsic._MM_ADDSUB_PS;
                case "_MM_AESDEC_SI128": return Intrinsic._MM_AESDEC_SI128;
                case "_MM_AESDECLAST_SI128": return Intrinsic._MM_AESDECLAST_SI128;
                case "_MM_AESENC_SI128": return Intrinsic._MM_AESENC_SI128;
                case "_MM_AESENCLAST_SI128": return Intrinsic._MM_AESENCLAST_SI128;
                case "_MM_AESIMC_SI128": return Intrinsic._MM_AESIMC_SI128;
                case "_MM_AESKEYGENASSIST_SI128": return Intrinsic._MM_AESKEYGENASSIST_SI128;
                case "_MM_ALIGNR_EPI32": return Intrinsic._MM_ALIGNR_EPI32;
                case "_MM_ALIGNR_EPI64": return Intrinsic._MM_ALIGNR_EPI64;
                case "_MM_ALIGNR_EPI8": return Intrinsic._MM_ALIGNR_EPI8;
                case "_MM_ALIGNR_PI8": return Intrinsic._MM_ALIGNR_PI8;
                case "_MM_AND_PD": return Intrinsic._MM_AND_PD;
                case "_MM_AND_PS": return Intrinsic._MM_AND_PS;
                case "_MM_AND_SI128": return Intrinsic._MM_AND_SI128;
                case "_MM_AND_SI64": return Intrinsic._MM_AND_SI64;
                case "_MM_ANDNOT_PD": return Intrinsic._MM_ANDNOT_PD;
                case "_MM_ANDNOT_PS": return Intrinsic._MM_ANDNOT_PS;
                case "_MM_ANDNOT_SI128": return Intrinsic._MM_ANDNOT_SI128;
                case "_MM_ANDNOT_SI64": return Intrinsic._MM_ANDNOT_SI64;
                case "_MM_ASIN_PD": return Intrinsic._MM_ASIN_PD;
                case "_MM_ASIN_PS": return Intrinsic._MM_ASIN_PS;
                case "_MM_ASINH_PD": return Intrinsic._MM_ASINH_PD;
                case "_MM_ASINH_PS": return Intrinsic._MM_ASINH_PS;
                case "_MM_ATAN_PD": return Intrinsic._MM_ATAN_PD;
                case "_MM_ATAN_PS": return Intrinsic._MM_ATAN_PS;
                case "_MM_ATAN2_PD": return Intrinsic._MM_ATAN2_PD;
                case "_MM_ATAN2_PS": return Intrinsic._MM_ATAN2_PS;
                case "_MM_ATANH_PD": return Intrinsic._MM_ATANH_PD;
                case "_MM_ATANH_PS": return Intrinsic._MM_ATANH_PS;
                case "_MM_AVG_EPU16": return Intrinsic._MM_AVG_EPU16;
                case "_MM_AVG_EPU8": return Intrinsic._MM_AVG_EPU8;
                case "_MM_AVG_PU16": return Intrinsic._MM_AVG_PU16;
                case "_MM_AVG_PU8": return Intrinsic._MM_AVG_PU8;
                case "_MM_BLEND_EPI16": return Intrinsic._MM_BLEND_EPI16;
                case "_MM_BLEND_EPI32": return Intrinsic._MM_BLEND_EPI32;
                case "_MM_BLEND_PD": return Intrinsic._MM_BLEND_PD;
                case "_MM_BLEND_PS": return Intrinsic._MM_BLEND_PS;
                case "_MM_BLENDV_EPI8": return Intrinsic._MM_BLENDV_EPI8;
                case "_MM_BLENDV_PD": return Intrinsic._MM_BLENDV_PD;
                case "_MM_BLENDV_PS": return Intrinsic._MM_BLENDV_PS;
                case "_MM_BROADCAST_I32X2": return Intrinsic._MM_BROADCAST_I32X2;
                case "_MM_BROADCAST_SS": return Intrinsic._MM_BROADCAST_SS;
                case "_MM_BROADCASTB_EPI8": return Intrinsic._MM_BROADCASTB_EPI8;
                case "_MM_BROADCASTD_EPI32": return Intrinsic._MM_BROADCASTD_EPI32;
                case "_MM_BROADCASTMB_EPI64": return Intrinsic._MM_BROADCASTMB_EPI64;
                case "_MM_BROADCASTMW_EPI32": return Intrinsic._MM_BROADCASTMW_EPI32;
                case "_MM_BROADCASTQ_EPI64": return Intrinsic._MM_BROADCASTQ_EPI64;
                case "_MM_BROADCASTSD_PD": return Intrinsic._MM_BROADCASTSD_PD;
                case "_MM_BROADCASTSS_PS": return Intrinsic._MM_BROADCASTSS_PS;
                case "_MM_BROADCASTW_EPI16": return Intrinsic._MM_BROADCASTW_EPI16;
                case "_MM_BSLLI_SI128": return Intrinsic._MM_BSLLI_SI128;
                case "_MM_BSRLI_SI128": return Intrinsic._MM_BSRLI_SI128;
                case "_MM_CASTPD_PS": return Intrinsic._MM_CASTPD_PS;
                case "_MM_CASTPD_SI128": return Intrinsic._MM_CASTPD_SI128;
                case "_MM_CASTPS_PD": return Intrinsic._MM_CASTPS_PD;
                case "_MM_CASTPS_SI128": return Intrinsic._MM_CASTPS_SI128;
                case "_MM_CASTSI128_PD": return Intrinsic._MM_CASTSI128_PD;
                case "_MM_CASTSI128_PS": return Intrinsic._MM_CASTSI128_PS;
                case "_MM_CBRT_PD": return Intrinsic._MM_CBRT_PD;
                case "_MM_CBRT_PS": return Intrinsic._MM_CBRT_PS;
                case "_MM_CDFNORM_PD": return Intrinsic._MM_CDFNORM_PD;
                case "_MM_CDFNORM_PS": return Intrinsic._MM_CDFNORM_PS;
                case "_MM_CDFNORMINV_PD": return Intrinsic._MM_CDFNORMINV_PD;
                case "_MM_CDFNORMINV_PS": return Intrinsic._MM_CDFNORMINV_PS;
                case "_MM_CEIL_PD": return Intrinsic._MM_CEIL_PD;
                case "_MM_CEIL_PS": return Intrinsic._MM_CEIL_PS;
                case "_MM_CEIL_SD": return Intrinsic._MM_CEIL_SD;
                case "_MM_CEIL_SS": return Intrinsic._MM_CEIL_SS;
                case "_MM_CEXP_PS": return Intrinsic._MM_CEXP_PS;
                case "_MM_CLEVICT": return Intrinsic._MM_CLEVICT;
                case "_MM_CLFLUSH": return Intrinsic._MM_CLFLUSH;
                case "_MM_CLFLUSHOPT": return Intrinsic._MM_CLFLUSHOPT;
                case "_MM_CLMULEPI64_SI128": return Intrinsic._MM_CLMULEPI64_SI128;
                case "_MM_CLOG_PS": return Intrinsic._MM_CLOG_PS;
                case "_MM_CMP_EPI16_MASK": return Intrinsic._MM_CMP_EPI16_MASK;
                case "_MM_CMP_EPI32_MASK": return Intrinsic._MM_CMP_EPI32_MASK;
                case "_MM_CMP_EPI64_MASK": return Intrinsic._MM_CMP_EPI64_MASK;
                case "_MM_CMP_EPI8_MASK": return Intrinsic._MM_CMP_EPI8_MASK;
                case "_MM_CMP_EPU16_MASK": return Intrinsic._MM_CMP_EPU16_MASK;
                case "_MM_CMP_EPU32_MASK": return Intrinsic._MM_CMP_EPU32_MASK;
                case "_MM_CMP_EPU64_MASK": return Intrinsic._MM_CMP_EPU64_MASK;
                case "_MM_CMP_EPU8_MASK": return Intrinsic._MM_CMP_EPU8_MASK;
                case "_MM_CMP_PD": return Intrinsic._MM_CMP_PD;
                case "_MM_CMP_PD_MASK": return Intrinsic._MM_CMP_PD_MASK;
                case "_MM_CMP_PS": return Intrinsic._MM_CMP_PS;
                case "_MM_CMP_PS_MASK": return Intrinsic._MM_CMP_PS_MASK;
                case "_MM_CMP_ROUND_SD_MASK": return Intrinsic._MM_CMP_ROUND_SD_MASK;
                case "_MM_CMP_ROUND_SS_MASK": return Intrinsic._MM_CMP_ROUND_SS_MASK;
                case "_MM_CMP_SD": return Intrinsic._MM_CMP_SD;
                case "_MM_CMP_SD_MASK": return Intrinsic._MM_CMP_SD_MASK;
                case "_MM_CMP_SS": return Intrinsic._MM_CMP_SS;
                case "_MM_CMP_SS_MASK": return Intrinsic._MM_CMP_SS_MASK;
                case "_MM_CMPEQ_EPI16": return Intrinsic._MM_CMPEQ_EPI16;
                case "_MM_CMPEQ_EPI16_MASK": return Intrinsic._MM_CMPEQ_EPI16_MASK;
                case "_MM_CMPEQ_EPI32": return Intrinsic._MM_CMPEQ_EPI32;
                case "_MM_CMPEQ_EPI32_MASK": return Intrinsic._MM_CMPEQ_EPI32_MASK;
                case "_MM_CMPEQ_EPI64": return Intrinsic._MM_CMPEQ_EPI64;
                case "_MM_CMPEQ_EPI64_MASK": return Intrinsic._MM_CMPEQ_EPI64_MASK;
                case "_MM_CMPEQ_EPI8": return Intrinsic._MM_CMPEQ_EPI8;
                case "_MM_CMPEQ_EPI8_MASK": return Intrinsic._MM_CMPEQ_EPI8_MASK;
                case "_MM_CMPEQ_EPU16_MASK": return Intrinsic._MM_CMPEQ_EPU16_MASK;
                case "_MM_CMPEQ_EPU32_MASK": return Intrinsic._MM_CMPEQ_EPU32_MASK;
                case "_MM_CMPEQ_EPU64_MASK": return Intrinsic._MM_CMPEQ_EPU64_MASK;
                case "_MM_CMPEQ_EPU8_MASK": return Intrinsic._MM_CMPEQ_EPU8_MASK;
                case "_MM_CMPEQ_PD": return Intrinsic._MM_CMPEQ_PD;
                case "_MM_CMPEQ_PI16": return Intrinsic._MM_CMPEQ_PI16;
                case "_MM_CMPEQ_PI32": return Intrinsic._MM_CMPEQ_PI32;
                case "_MM_CMPEQ_PI8": return Intrinsic._MM_CMPEQ_PI8;
                case "_MM_CMPEQ_PS": return Intrinsic._MM_CMPEQ_PS;
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
                case "_MM_CMPGE_EPI32_MASK": return Intrinsic._MM_CMPGE_EPI32_MASK;
                case "_MM_CMPGE_EPI64_MASK": return Intrinsic._MM_CMPGE_EPI64_MASK;
                case "_MM_CMPGE_EPI8_MASK": return Intrinsic._MM_CMPGE_EPI8_MASK;
                case "_MM_CMPGE_EPU16_MASK": return Intrinsic._MM_CMPGE_EPU16_MASK;
                case "_MM_CMPGE_EPU32_MASK": return Intrinsic._MM_CMPGE_EPU32_MASK;
                case "_MM_CMPGE_EPU64_MASK": return Intrinsic._MM_CMPGE_EPU64_MASK;
                case "_MM_CMPGE_EPU8_MASK": return Intrinsic._MM_CMPGE_EPU8_MASK;
                case "_MM_CMPGE_PD": return Intrinsic._MM_CMPGE_PD;
                case "_MM_CMPGE_PS": return Intrinsic._MM_CMPGE_PS;
                case "_MM_CMPGE_SD": return Intrinsic._MM_CMPGE_SD;
                case "_MM_CMPGE_SS": return Intrinsic._MM_CMPGE_SS;
                case "_MM_CMPGT_EPI16": return Intrinsic._MM_CMPGT_EPI16;
                case "_MM_CMPGT_EPI16_MASK": return Intrinsic._MM_CMPGT_EPI16_MASK;
                case "_MM_CMPGT_EPI32": return Intrinsic._MM_CMPGT_EPI32;
                case "_MM_CMPGT_EPI32_MASK": return Intrinsic._MM_CMPGT_EPI32_MASK;
                case "_MM_CMPGT_EPI64": return Intrinsic._MM_CMPGT_EPI64;
                case "_MM_CMPGT_EPI64_MASK": return Intrinsic._MM_CMPGT_EPI64_MASK;
                case "_MM_CMPGT_EPI8": return Intrinsic._MM_CMPGT_EPI8;
                case "_MM_CMPGT_EPI8_MASK": return Intrinsic._MM_CMPGT_EPI8_MASK;
                case "_MM_CMPGT_EPU16_MASK": return Intrinsic._MM_CMPGT_EPU16_MASK;
                case "_MM_CMPGT_EPU32_MASK": return Intrinsic._MM_CMPGT_EPU32_MASK;
                case "_MM_CMPGT_EPU64_MASK": return Intrinsic._MM_CMPGT_EPU64_MASK;
                case "_MM_CMPGT_EPU8_MASK": return Intrinsic._MM_CMPGT_EPU8_MASK;
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
                case "_MM_CMPLE_EPI32_MASK": return Intrinsic._MM_CMPLE_EPI32_MASK;
                case "_MM_CMPLE_EPI64_MASK": return Intrinsic._MM_CMPLE_EPI64_MASK;
                case "_MM_CMPLE_EPI8_MASK": return Intrinsic._MM_CMPLE_EPI8_MASK;
                case "_MM_CMPLE_EPU16_MASK": return Intrinsic._MM_CMPLE_EPU16_MASK;
                case "_MM_CMPLE_EPU32_MASK": return Intrinsic._MM_CMPLE_EPU32_MASK;
                case "_MM_CMPLE_EPU64_MASK": return Intrinsic._MM_CMPLE_EPU64_MASK;
                case "_MM_CMPLE_EPU8_MASK": return Intrinsic._MM_CMPLE_EPU8_MASK;
                case "_MM_CMPLE_PD": return Intrinsic._MM_CMPLE_PD;
                case "_MM_CMPLE_PS": return Intrinsic._MM_CMPLE_PS;
                case "_MM_CMPLE_SD": return Intrinsic._MM_CMPLE_SD;
                case "_MM_CMPLE_SS": return Intrinsic._MM_CMPLE_SS;
                case "_MM_CMPLT_EPI16": return Intrinsic._MM_CMPLT_EPI16;
                case "_MM_CMPLT_EPI16_MASK": return Intrinsic._MM_CMPLT_EPI16_MASK;
                case "_MM_CMPLT_EPI32": return Intrinsic._MM_CMPLT_EPI32;
                case "_MM_CMPLT_EPI32_MASK": return Intrinsic._MM_CMPLT_EPI32_MASK;
                case "_MM_CMPLT_EPI64_MASK": return Intrinsic._MM_CMPLT_EPI64_MASK;
                case "_MM_CMPLT_EPI8": return Intrinsic._MM_CMPLT_EPI8;
                case "_MM_CMPLT_EPI8_MASK": return Intrinsic._MM_CMPLT_EPI8_MASK;
                case "_MM_CMPLT_EPU16_MASK": return Intrinsic._MM_CMPLT_EPU16_MASK;
                case "_MM_CMPLT_EPU32_MASK": return Intrinsic._MM_CMPLT_EPU32_MASK;
                case "_MM_CMPLT_EPU64_MASK": return Intrinsic._MM_CMPLT_EPU64_MASK;
                case "_MM_CMPLT_EPU8_MASK": return Intrinsic._MM_CMPLT_EPU8_MASK;
                case "_MM_CMPLT_PD": return Intrinsic._MM_CMPLT_PD;
                case "_MM_CMPLT_PS": return Intrinsic._MM_CMPLT_PS;
                case "_MM_CMPLT_SD": return Intrinsic._MM_CMPLT_SD;
                case "_MM_CMPLT_SS": return Intrinsic._MM_CMPLT_SS;
                case "_MM_CMPNEQ_EPI16_MASK": return Intrinsic._MM_CMPNEQ_EPI16_MASK;
                case "_MM_CMPNEQ_EPI32_MASK": return Intrinsic._MM_CMPNEQ_EPI32_MASK;
                case "_MM_CMPNEQ_EPI64_MASK": return Intrinsic._MM_CMPNEQ_EPI64_MASK;
                case "_MM_CMPNEQ_EPI8_MASK": return Intrinsic._MM_CMPNEQ_EPI8_MASK;
                case "_MM_CMPNEQ_EPU16_MASK": return Intrinsic._MM_CMPNEQ_EPU16_MASK;
                case "_MM_CMPNEQ_EPU32_MASK": return Intrinsic._MM_CMPNEQ_EPU32_MASK;
                case "_MM_CMPNEQ_EPU64_MASK": return Intrinsic._MM_CMPNEQ_EPU64_MASK;
                case "_MM_CMPNEQ_EPU8_MASK": return Intrinsic._MM_CMPNEQ_EPU8_MASK;
                case "_MM_CMPNEQ_PD": return Intrinsic._MM_CMPNEQ_PD;
                case "_MM_CMPNEQ_PS": return Intrinsic._MM_CMPNEQ_PS;
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
                case "_MM_CMPNLE_PS": return Intrinsic._MM_CMPNLE_PS;
                case "_MM_CMPNLE_SD": return Intrinsic._MM_CMPNLE_SD;
                case "_MM_CMPNLE_SS": return Intrinsic._MM_CMPNLE_SS;
                case "_MM_CMPNLT_PD": return Intrinsic._MM_CMPNLT_PD;
                case "_MM_CMPNLT_PS": return Intrinsic._MM_CMPNLT_PS;
                case "_MM_CMPNLT_SD": return Intrinsic._MM_CMPNLT_SD;
                case "_MM_CMPNLT_SS": return Intrinsic._MM_CMPNLT_SS;
                case "_MM_CMPORD_PD": return Intrinsic._MM_CMPORD_PD;
                case "_MM_CMPORD_PS": return Intrinsic._MM_CMPORD_PS;
                case "_MM_CMPORD_SD": return Intrinsic._MM_CMPORD_SD;
                case "_MM_CMPORD_SS": return Intrinsic._MM_CMPORD_SS;
                case "_MM_CMPUNORD_PD": return Intrinsic._MM_CMPUNORD_PD;
                case "_MM_CMPUNORD_PS": return Intrinsic._MM_CMPUNORD_PS;
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
                case "_MM_CONFLICT_EPI32": return Intrinsic._MM_CONFLICT_EPI32;
                case "_MM_CONFLICT_EPI64": return Intrinsic._MM_CONFLICT_EPI64;
                case "_MM_COS_PD": return Intrinsic._MM_COS_PD;
                case "_MM_COS_PS": return Intrinsic._MM_COS_PS;
                case "_MM_COSD_PD": return Intrinsic._MM_COSD_PD;
                case "_MM_COSD_PS": return Intrinsic._MM_COSD_PS;
                case "_MM_COSH_PD": return Intrinsic._MM_COSH_PD;
                case "_MM_COSH_PS": return Intrinsic._MM_COSH_PS;
                case "_MM_COUNTBITS_32": return Intrinsic._MM_COUNTBITS_32;
                case "_MM_COUNTBITS_64": return Intrinsic._MM_COUNTBITS_64;
                case "_MM_CRC32_U16": return Intrinsic._MM_CRC32_U16;
                case "_MM_CRC32_U32": return Intrinsic._MM_CRC32_U32;
                case "_MM_CRC32_U64": return Intrinsic._MM_CRC32_U64;
                case "_MM_CRC32_U8": return Intrinsic._MM_CRC32_U8;
                case "_MM_CSQRT_PS": return Intrinsic._MM_CSQRT_PS;
                case "_MM_CVT_PI2PS": return Intrinsic._MM_CVT_PI2PS;
                case "_MM_CVT_PS2PI": return Intrinsic._MM_CVT_PS2PI;
                case "_MM_CVT_ROUNDI32_SS": return Intrinsic._MM_CVT_ROUNDI32_SS;
                case "_MM_CVT_ROUNDI64_SD": return Intrinsic._MM_CVT_ROUNDI64_SD;
                case "_MM_CVT_ROUNDI64_SS": return Intrinsic._MM_CVT_ROUNDI64_SS;
                case "_MM_CVT_ROUNDSD_I32": return Intrinsic._MM_CVT_ROUNDSD_I32;
                case "_MM_CVT_ROUNDSD_I64": return Intrinsic._MM_CVT_ROUNDSD_I64;
                case "_MM_CVT_ROUNDSD_SI32": return Intrinsic._MM_CVT_ROUNDSD_SI32;
                case "_MM_CVT_ROUNDSD_SI64": return Intrinsic._MM_CVT_ROUNDSD_SI64;
                case "_MM_CVT_ROUNDSD_SS": return Intrinsic._MM_CVT_ROUNDSD_SS;
                case "_MM_CVT_ROUNDSD_U32": return Intrinsic._MM_CVT_ROUNDSD_U32;
                case "_MM_CVT_ROUNDSD_U64": return Intrinsic._MM_CVT_ROUNDSD_U64;
                case "_MM_CVT_ROUNDSI32_SS": return Intrinsic._MM_CVT_ROUNDSI32_SS;
                case "_MM_CVT_ROUNDSI64_SD": return Intrinsic._MM_CVT_ROUNDSI64_SD;
                case "_MM_CVT_ROUNDSI64_SS": return Intrinsic._MM_CVT_ROUNDSI64_SS;
                case "_MM_CVT_ROUNDSS_I32": return Intrinsic._MM_CVT_ROUNDSS_I32;
                case "_MM_CVT_ROUNDSS_I64": return Intrinsic._MM_CVT_ROUNDSS_I64;
                case "_MM_CVT_ROUNDSS_SD": return Intrinsic._MM_CVT_ROUNDSS_SD;
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
                case "_MM_CVTEPI16_EPI64": return Intrinsic._MM_CVTEPI16_EPI64;
                case "_MM_CVTEPI16_EPI8": return Intrinsic._MM_CVTEPI16_EPI8;
                case "_MM_CVTEPI32_EPI16": return Intrinsic._MM_CVTEPI32_EPI16;
                case "_MM_CVTEPI32_EPI64": return Intrinsic._MM_CVTEPI32_EPI64;
                case "_MM_CVTEPI32_EPI8": return Intrinsic._MM_CVTEPI32_EPI8;
                case "_MM_CVTEPI32_PD": return Intrinsic._MM_CVTEPI32_PD;
                case "_MM_CVTEPI32_PS": return Intrinsic._MM_CVTEPI32_PS;
                case "_MM_CVTEPI64_EPI16": return Intrinsic._MM_CVTEPI64_EPI16;
                case "_MM_CVTEPI64_EPI32": return Intrinsic._MM_CVTEPI64_EPI32;
                case "_MM_CVTEPI64_EPI8": return Intrinsic._MM_CVTEPI64_EPI8;
                case "_MM_CVTEPI64_PD": return Intrinsic._MM_CVTEPI64_PD;
                case "_MM_CVTEPI64_PS": return Intrinsic._MM_CVTEPI64_PS;
                case "_MM_CVTEPI8_EPI16": return Intrinsic._MM_CVTEPI8_EPI16;
                case "_MM_CVTEPI8_EPI32": return Intrinsic._MM_CVTEPI8_EPI32;
                case "_MM_CVTEPI8_EPI64": return Intrinsic._MM_CVTEPI8_EPI64;
                case "_MM_CVTEPU16_EPI32": return Intrinsic._MM_CVTEPU16_EPI32;
                case "_MM_CVTEPU16_EPI64": return Intrinsic._MM_CVTEPU16_EPI64;
                case "_MM_CVTEPU32_EPI64": return Intrinsic._MM_CVTEPU32_EPI64;
                case "_MM_CVTEPU32_PD": return Intrinsic._MM_CVTEPU32_PD;
                case "_MM_CVTEPU64_PD": return Intrinsic._MM_CVTEPU64_PD;
                case "_MM_CVTEPU64_PS": return Intrinsic._MM_CVTEPU64_PS;
                case "_MM_CVTEPU8_EPI16": return Intrinsic._MM_CVTEPU8_EPI16;
                case "_MM_CVTEPU8_EPI32": return Intrinsic._MM_CVTEPU8_EPI32;
                case "_MM_CVTEPU8_EPI64": return Intrinsic._MM_CVTEPU8_EPI64;
                case "_MM_CVTI32_SD": return Intrinsic._MM_CVTI32_SD;
                case "_MM_CVTI32_SS": return Intrinsic._MM_CVTI32_SS;
                case "_MM_CVTI64_SD": return Intrinsic._MM_CVTI64_SD;
                case "_MM_CVTI64_SS": return Intrinsic._MM_CVTI64_SS;
                case "_MM_CVTM64_SI64": return Intrinsic._MM_CVTM64_SI64;
                case "_MM_CVTPD_EPI32": return Intrinsic._MM_CVTPD_EPI32;
                case "_MM_CVTPD_EPI64": return Intrinsic._MM_CVTPD_EPI64;
                case "_MM_CVTPD_EPU32": return Intrinsic._MM_CVTPD_EPU32;
                case "_MM_CVTPD_EPU64": return Intrinsic._MM_CVTPD_EPU64;
                case "_MM_CVTPD_PI32": return Intrinsic._MM_CVTPD_PI32;
                case "_MM_CVTPD_PS": return Intrinsic._MM_CVTPD_PS;
                case "_MM_CVTPH_PS": return Intrinsic._MM_CVTPH_PS;
                case "_MM_CVTPI16_PS": return Intrinsic._MM_CVTPI16_PS;
                case "_MM_CVTPI32_PD": return Intrinsic._MM_CVTPI32_PD;
                case "_MM_CVTPI32_PS": return Intrinsic._MM_CVTPI32_PS;
                case "_MM_CVTPI32X2_PS": return Intrinsic._MM_CVTPI32X2_PS;
                case "_MM_CVTPI8_PS": return Intrinsic._MM_CVTPI8_PS;
                case "_MM_CVTPS_EPI32": return Intrinsic._MM_CVTPS_EPI32;
                case "_MM_CVTPS_EPI64": return Intrinsic._MM_CVTPS_EPI64;
                case "_MM_CVTPS_EPU32": return Intrinsic._MM_CVTPS_EPU32;
                case "_MM_CVTPS_EPU64": return Intrinsic._MM_CVTPS_EPU64;
                case "_MM_CVTPS_PD": return Intrinsic._MM_CVTPS_PD;
                case "_MM_CVTPS_PH": return Intrinsic._MM_CVTPS_PH;
                case "_MM_CVTPS_PI16": return Intrinsic._MM_CVTPS_PI16;
                case "_MM_CVTPS_PI32": return Intrinsic._MM_CVTPS_PI32;
                case "_MM_CVTPS_PI8": return Intrinsic._MM_CVTPS_PI8;
                case "_MM_CVTPU16_PS": return Intrinsic._MM_CVTPU16_PS;
                case "_MM_CVTPU8_PS": return Intrinsic._MM_CVTPU8_PS;
                case "_MM_CVTSD_F64": return Intrinsic._MM_CVTSD_F64;
                case "_MM_CVTSD_I32": return Intrinsic._MM_CVTSD_I32;
                case "_MM_CVTSD_I64": return Intrinsic._MM_CVTSD_I64;
                case "_MM_CVTSD_SI32": return Intrinsic._MM_CVTSD_SI32;
                case "_MM_CVTSD_SI64": return Intrinsic._MM_CVTSD_SI64;
                case "_MM_CVTSD_SI64X": return Intrinsic._MM_CVTSD_SI64X;
                case "_MM_CVTSD_SS": return Intrinsic._MM_CVTSD_SS;
                case "_MM_CVTSD_U32": return Intrinsic._MM_CVTSD_U32;
                case "_MM_CVTSD_U64": return Intrinsic._MM_CVTSD_U64;
                case "_MM_CVTSEPI16_EPI8": return Intrinsic._MM_CVTSEPI16_EPI8;
                case "_MM_CVTSEPI32_EPI16": return Intrinsic._MM_CVTSEPI32_EPI16;
                case "_MM_CVTSEPI32_EPI8": return Intrinsic._MM_CVTSEPI32_EPI8;
                case "_MM_CVTSEPI64_EPI16": return Intrinsic._MM_CVTSEPI64_EPI16;
                case "_MM_CVTSEPI64_EPI32": return Intrinsic._MM_CVTSEPI64_EPI32;
                case "_MM_CVTSEPI64_EPI8": return Intrinsic._MM_CVTSEPI64_EPI8;
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
                case "_MM_CVTSS_SI32": return Intrinsic._MM_CVTSS_SI32;
                case "_MM_CVTSS_SI64": return Intrinsic._MM_CVTSS_SI64;
                case "_MM_CVTSS_U32": return Intrinsic._MM_CVTSS_U32;
                case "_MM_CVTSS_U64": return Intrinsic._MM_CVTSS_U64;
                case "_MM_CVTT_PS2PI": return Intrinsic._MM_CVTT_PS2PI;
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
                case "_MM_CVTTPD_EPI64": return Intrinsic._MM_CVTTPD_EPI64;
                case "_MM_CVTTPD_EPU32": return Intrinsic._MM_CVTTPD_EPU32;
                case "_MM_CVTTPD_EPU64": return Intrinsic._MM_CVTTPD_EPU64;
                case "_MM_CVTTPD_PI32": return Intrinsic._MM_CVTTPD_PI32;
                case "_MM_CVTTPS_EPI32": return Intrinsic._MM_CVTTPS_EPI32;
                case "_MM_CVTTPS_EPI64": return Intrinsic._MM_CVTTPS_EPI64;
                case "_MM_CVTTPS_EPU32": return Intrinsic._MM_CVTTPS_EPU32;
                case "_MM_CVTTPS_EPU64": return Intrinsic._MM_CVTTPS_EPU64;
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
                case "_MM_CVTUSEPI32_EPI16": return Intrinsic._MM_CVTUSEPI32_EPI16;
                case "_MM_CVTUSEPI32_EPI8": return Intrinsic._MM_CVTUSEPI32_EPI8;
                case "_MM_CVTUSEPI64_EPI16": return Intrinsic._MM_CVTUSEPI64_EPI16;
                case "_MM_CVTUSEPI64_EPI32": return Intrinsic._MM_CVTUSEPI64_EPI32;
                case "_MM_CVTUSEPI64_EPI8": return Intrinsic._MM_CVTUSEPI64_EPI8;
                case "_MM_DBSAD_EPU8": return Intrinsic._MM_DBSAD_EPU8;
                case "_MM_DELAY_32": return Intrinsic._MM_DELAY_32;
                case "_MM_DELAY_64": return Intrinsic._MM_DELAY_64;
                case "_MM_DIV_EPI16": return Intrinsic._MM_DIV_EPI16;
                case "_MM_DIV_EPI32": return Intrinsic._MM_DIV_EPI32;
                case "_MM_DIV_EPI64": return Intrinsic._MM_DIV_EPI64;
                case "_MM_DIV_EPI8": return Intrinsic._MM_DIV_EPI8;
                case "_MM_DIV_EPU16": return Intrinsic._MM_DIV_EPU16;
                case "_MM_DIV_EPU32": return Intrinsic._MM_DIV_EPU32;
                case "_MM_DIV_EPU64": return Intrinsic._MM_DIV_EPU64;
                case "_MM_DIV_EPU8": return Intrinsic._MM_DIV_EPU8;
                case "_MM_DIV_PD": return Intrinsic._MM_DIV_PD;
                case "_MM_DIV_PS": return Intrinsic._MM_DIV_PS;
                case "_MM_DIV_ROUND_SD": return Intrinsic._MM_DIV_ROUND_SD;
                case "_MM_DIV_ROUND_SS": return Intrinsic._MM_DIV_ROUND_SS;
                case "_MM_DIV_SD": return Intrinsic._MM_DIV_SD;
                case "_MM_DIV_SS": return Intrinsic._MM_DIV_SS;
                case "_MM_DP_PD": return Intrinsic._MM_DP_PD;
                case "_MM_DP_PS": return Intrinsic._MM_DP_PS;
                case "_MM_EMPTY": return Intrinsic._MM_EMPTY;
                case "_MM_ERF_PD": return Intrinsic._MM_ERF_PD;
                case "_MM_ERF_PS": return Intrinsic._MM_ERF_PS;
                case "_MM_ERFC_PD": return Intrinsic._MM_ERFC_PD;
                case "_MM_ERFC_PS": return Intrinsic._MM_ERFC_PS;
                case "_MM_ERFCINV_PD": return Intrinsic._MM_ERFCINV_PD;
                case "_MM_ERFCINV_PS": return Intrinsic._MM_ERFCINV_PS;
                case "_MM_ERFINV_PD": return Intrinsic._MM_ERFINV_PD;
                case "_MM_ERFINV_PS": return Intrinsic._MM_ERFINV_PS;
                case "_MM_EXP_PD": return Intrinsic._MM_EXP_PD;
                case "_MM_EXP_PS": return Intrinsic._MM_EXP_PS;
                case "_MM_EXP10_PD": return Intrinsic._MM_EXP10_PD;
                case "_MM_EXP10_PS": return Intrinsic._MM_EXP10_PS;
                case "_MM_EXP2_PD": return Intrinsic._MM_EXP2_PD;
                case "_MM_EXP2_PS": return Intrinsic._MM_EXP2_PS;
                case "_MM_EXPM1_PD": return Intrinsic._MM_EXPM1_PD;
                case "_MM_EXPM1_PS": return Intrinsic._MM_EXPM1_PS;
                case "_MM_EXTRACT_EPI16": return Intrinsic._MM_EXTRACT_EPI16;
                case "_MM_EXTRACT_EPI32": return Intrinsic._MM_EXTRACT_EPI32;
                case "_MM_EXTRACT_EPI64": return Intrinsic._MM_EXTRACT_EPI64;
                case "_MM_EXTRACT_EPI8": return Intrinsic._MM_EXTRACT_EPI8;
                case "_MM_EXTRACT_PI16": return Intrinsic._MM_EXTRACT_PI16;
                case "_MM_EXTRACT_PS": return Intrinsic._MM_EXTRACT_PS;
                case "_MM_FIXUPIMM_PD": return Intrinsic._MM_FIXUPIMM_PD;
                case "_MM_FIXUPIMM_PS": return Intrinsic._MM_FIXUPIMM_PS;
                case "_MM_FIXUPIMM_ROUND_SD": return Intrinsic._MM_FIXUPIMM_ROUND_SD;
                case "_MM_FIXUPIMM_ROUND_SS": return Intrinsic._MM_FIXUPIMM_ROUND_SS;
                case "_MM_FIXUPIMM_SD": return Intrinsic._MM_FIXUPIMM_SD;
                case "_MM_FIXUPIMM_SS": return Intrinsic._MM_FIXUPIMM_SS;
                case "_MM_FLOOR_PD": return Intrinsic._MM_FLOOR_PD;
                case "_MM_FLOOR_PS": return Intrinsic._MM_FLOOR_PS;
                case "_MM_FLOOR_SD": return Intrinsic._MM_FLOOR_SD;
                case "_MM_FLOOR_SS": return Intrinsic._MM_FLOOR_SS;
                case "_MM_FMADD_PD": return Intrinsic._MM_FMADD_PD;
                case "_MM_FMADD_PS": return Intrinsic._MM_FMADD_PS;
                case "_MM_FMADD_SD": return Intrinsic._MM_FMADD_SD;
                case "_MM_FMADD_SS": return Intrinsic._MM_FMADD_SS;
                case "_MM_FMADDSUB_PD": return Intrinsic._MM_FMADDSUB_PD;
                case "_MM_FMADDSUB_PS": return Intrinsic._MM_FMADDSUB_PS;
                case "_MM_FMSUB_PD": return Intrinsic._MM_FMSUB_PD;
                case "_MM_FMSUB_PS": return Intrinsic._MM_FMSUB_PS;
                case "_MM_FMSUB_SD": return Intrinsic._MM_FMSUB_SD;
                case "_MM_FMSUB_SS": return Intrinsic._MM_FMSUB_SS;
                case "_MM_FMSUBADD_PD": return Intrinsic._MM_FMSUBADD_PD;
                case "_MM_FMSUBADD_PS": return Intrinsic._MM_FMSUBADD_PS;
                case "_MM_FNMADD_PD": return Intrinsic._MM_FNMADD_PD;
                case "_MM_FNMADD_PS": return Intrinsic._MM_FNMADD_PS;
                case "_MM_FNMADD_SD": return Intrinsic._MM_FNMADD_SD;
                case "_MM_FNMADD_SS": return Intrinsic._MM_FNMADD_SS;
                case "_MM_FNMSUB_PD": return Intrinsic._MM_FNMSUB_PD;
                case "_MM_FNMSUB_PS": return Intrinsic._MM_FNMSUB_PS;
                case "_MM_FNMSUB_SD": return Intrinsic._MM_FNMSUB_SD;
                case "_MM_FNMSUB_SS": return Intrinsic._MM_FNMSUB_SS;
                case "_MM_FPCLASS_PD_MASK": return Intrinsic._MM_FPCLASS_PD_MASK;
                case "_MM_FPCLASS_PS_MASK": return Intrinsic._MM_FPCLASS_PS_MASK;
                case "_MM_FPCLASS_SD_MASK": return Intrinsic._MM_FPCLASS_SD_MASK;
                case "_MM_FPCLASS_SS_MASK": return Intrinsic._MM_FPCLASS_SS_MASK;
                case "_MM_FREE": return Intrinsic._MM_FREE;
                case "_MM_GET_EXCEPTION_MASK": return Intrinsic._MM_GET_EXCEPTION_MASK;
                case "_MM_GET_EXCEPTION_STATE": return Intrinsic._MM_GET_EXCEPTION_STATE;
                case "_MM_GET_FLUSH_ZERO_MODE": return Intrinsic._MM_GET_FLUSH_ZERO_MODE;
                case "_MM_GET_ROUNDING_MODE": return Intrinsic._MM_GET_ROUNDING_MODE;
                case "_MM_GETCSR": return Intrinsic._MM_GETCSR;
                case "_MM_GETEXP_PD": return Intrinsic._MM_GETEXP_PD;
                case "_MM_GETEXP_PS": return Intrinsic._MM_GETEXP_PS;
                case "_MM_GETEXP_ROUND_SD": return Intrinsic._MM_GETEXP_ROUND_SD;
                case "_MM_GETEXP_ROUND_SS": return Intrinsic._MM_GETEXP_ROUND_SS;
                case "_MM_GETEXP_SD": return Intrinsic._MM_GETEXP_SD;
                case "_MM_GETEXP_SS": return Intrinsic._MM_GETEXP_SS;
                case "_MM_GETMANT_PD": return Intrinsic._MM_GETMANT_PD;
                case "_MM_GETMANT_PS": return Intrinsic._MM_GETMANT_PS;
                case "_MM_GETMANT_ROUND_SD": return Intrinsic._MM_GETMANT_ROUND_SD;
                case "_MM_GETMANT_ROUND_SS": return Intrinsic._MM_GETMANT_ROUND_SS;
                case "_MM_GETMANT_SD": return Intrinsic._MM_GETMANT_SD;
                case "_MM_GETMANT_SS": return Intrinsic._MM_GETMANT_SS;
                case "_MM_HADD_EPI16": return Intrinsic._MM_HADD_EPI16;
                case "_MM_HADD_EPI32": return Intrinsic._MM_HADD_EPI32;
                case "_MM_HADD_PD": return Intrinsic._MM_HADD_PD;
                case "_MM_HADD_PI16": return Intrinsic._MM_HADD_PI16;
                case "_MM_HADD_PI32": return Intrinsic._MM_HADD_PI32;
                case "_MM_HADD_PS": return Intrinsic._MM_HADD_PS;
                case "_MM_HADDS_EPI16": return Intrinsic._MM_HADDS_EPI16;
                case "_MM_HADDS_PI16": return Intrinsic._MM_HADDS_PI16;
                case "_MM_HSUB_EPI16": return Intrinsic._MM_HSUB_EPI16;
                case "_MM_HSUB_EPI32": return Intrinsic._MM_HSUB_EPI32;
                case "_MM_HSUB_PD": return Intrinsic._MM_HSUB_PD;
                case "_MM_HSUB_PI16": return Intrinsic._MM_HSUB_PI16;
                case "_MM_HSUB_PI32": return Intrinsic._MM_HSUB_PI32;
                case "_MM_HSUB_PS": return Intrinsic._MM_HSUB_PS;
                case "_MM_HSUBS_EPI16": return Intrinsic._MM_HSUBS_EPI16;
                case "_MM_HSUBS_PI16": return Intrinsic._MM_HSUBS_PI16;
                case "_MM_HYPOT_PD": return Intrinsic._MM_HYPOT_PD;
                case "_MM_HYPOT_PS": return Intrinsic._MM_HYPOT_PS;
                case "_MM_I32GATHER_EPI32": return Intrinsic._MM_I32GATHER_EPI32;
                case "_MM_I32GATHER_EPI64": return Intrinsic._MM_I32GATHER_EPI64;
                case "_MM_I32GATHER_PD": return Intrinsic._MM_I32GATHER_PD;
                case "_MM_I32GATHER_PS": return Intrinsic._MM_I32GATHER_PS;
                case "_MM_I32SCATTER_EPI32": return Intrinsic._MM_I32SCATTER_EPI32;
                case "_MM_I32SCATTER_EPI64": return Intrinsic._MM_I32SCATTER_EPI64;
                case "_MM_I32SCATTER_PD": return Intrinsic._MM_I32SCATTER_PD;
                case "_MM_I32SCATTER_PS": return Intrinsic._MM_I32SCATTER_PS;
                case "_MM_I64GATHER_EPI32": return Intrinsic._MM_I64GATHER_EPI32;
                case "_MM_I64GATHER_EPI64": return Intrinsic._MM_I64GATHER_EPI64;
                case "_MM_I64GATHER_PD": return Intrinsic._MM_I64GATHER_PD;
                case "_MM_I64GATHER_PS": return Intrinsic._MM_I64GATHER_PS;
                case "_MM_I64SCATTER_EPI32": return Intrinsic._MM_I64SCATTER_EPI32;
                case "_MM_I64SCATTER_EPI64": return Intrinsic._MM_I64SCATTER_EPI64;
                case "_MM_I64SCATTER_PD": return Intrinsic._MM_I64SCATTER_PD;
                case "_MM_I64SCATTER_PS": return Intrinsic._MM_I64SCATTER_PS;
                case "_MM_IDIV_EPI32": return Intrinsic._MM_IDIV_EPI32;
                case "_MM_IDIVREM_EPI32": return Intrinsic._MM_IDIVREM_EPI32;
                case "_MM_INSERT_EPI16": return Intrinsic._MM_INSERT_EPI16;
                case "_MM_INSERT_EPI32": return Intrinsic._MM_INSERT_EPI32;
                case "_MM_INSERT_EPI64": return Intrinsic._MM_INSERT_EPI64;
                case "_MM_INSERT_EPI8": return Intrinsic._MM_INSERT_EPI8;
                case "_MM_INSERT_PI16": return Intrinsic._MM_INSERT_PI16;
                case "_MM_INSERT_PS": return Intrinsic._MM_INSERT_PS;
                case "_MM_INVCBRT_PD": return Intrinsic._MM_INVCBRT_PD;
                case "_MM_INVCBRT_PS": return Intrinsic._MM_INVCBRT_PS;
                case "_MM_INVSQRT_PD": return Intrinsic._MM_INVSQRT_PD;
                case "_MM_INVSQRT_PS": return Intrinsic._MM_INVSQRT_PS;
                case "_MM_IREM_EPI32": return Intrinsic._MM_IREM_EPI32;
                case "_MM_LDDQU_SI128": return Intrinsic._MM_LDDQU_SI128;
                case "_MM_LFENCE": return Intrinsic._MM_LFENCE;
                case "_MM_LOAD_PD": return Intrinsic._MM_LOAD_PD;
                case "_MM_LOAD_PD1": return Intrinsic._MM_LOAD_PD1;
                case "_MM_LOAD_PS": return Intrinsic._MM_LOAD_PS;
                case "_MM_LOAD_PS1": return Intrinsic._MM_LOAD_PS1;
                case "_MM_LOAD_SD": return Intrinsic._MM_LOAD_SD;
                case "_MM_LOAD_SI128": return Intrinsic._MM_LOAD_SI128;
                case "_MM_LOAD_SS": return Intrinsic._MM_LOAD_SS;
                case "_MM_LOAD1_PD": return Intrinsic._MM_LOAD1_PD;
                case "_MM_LOAD1_PS": return Intrinsic._MM_LOAD1_PS;
                case "_MM_LOADDUP_PD": return Intrinsic._MM_LOADDUP_PD;
                case "_MM_LOADH_PD": return Intrinsic._MM_LOADH_PD;
                case "_MM_LOADH_PI": return Intrinsic._MM_LOADH_PI;
                case "_MM_LOADL_EPI64": return Intrinsic._MM_LOADL_EPI64;
                case "_MM_LOADL_PD": return Intrinsic._MM_LOADL_PD;
                case "_MM_LOADL_PI": return Intrinsic._MM_LOADL_PI;
                case "_MM_LOADR_PD": return Intrinsic._MM_LOADR_PD;
                case "_MM_LOADR_PS": return Intrinsic._MM_LOADR_PS;
                case "_MM_LOADU_PD": return Intrinsic._MM_LOADU_PD;
                case "_MM_LOADU_PS": return Intrinsic._MM_LOADU_PS;
                case "_MM_LOADU_SI128": return Intrinsic._MM_LOADU_SI128;
                case "_MM_LOADU_SI16": return Intrinsic._MM_LOADU_SI16;
                case "_MM_LOADU_SI32": return Intrinsic._MM_LOADU_SI32;
                case "_MM_LOADU_SI64": return Intrinsic._MM_LOADU_SI64;
                case "_MM_LOG_PD": return Intrinsic._MM_LOG_PD;
                case "_MM_LOG_PS": return Intrinsic._MM_LOG_PS;
                case "_MM_LOG10_PD": return Intrinsic._MM_LOG10_PD;
                case "_MM_LOG10_PS": return Intrinsic._MM_LOG10_PS;
                case "_MM_LOG1P_PD": return Intrinsic._MM_LOG1P_PD;
                case "_MM_LOG1P_PS": return Intrinsic._MM_LOG1P_PS;
                case "_MM_LOG2_PD": return Intrinsic._MM_LOG2_PD;
                case "_MM_LOG2_PS": return Intrinsic._MM_LOG2_PS;
                case "_MM_LOGB_PD": return Intrinsic._MM_LOGB_PD;
                case "_MM_LOGB_PS": return Intrinsic._MM_LOGB_PS;
                case "_MM_LZCNT_EPI32": return Intrinsic._MM_LZCNT_EPI32;
                case "_MM_LZCNT_EPI64": return Intrinsic._MM_LZCNT_EPI64;
                case "_MM_MADD_EPI16": return Intrinsic._MM_MADD_EPI16;
                case "_MM_MADD_PI16": return Intrinsic._MM_MADD_PI16;
                case "_MM_MADD52HI_EPU64": return Intrinsic._MM_MADD52HI_EPU64;
                case "_MM_MADD52LO_EPU64": return Intrinsic._MM_MADD52LO_EPU64;
                case "_MM_MADDUBS_EPI16": return Intrinsic._MM_MADDUBS_EPI16;
                case "_MM_MADDUBS_PI16": return Intrinsic._MM_MADDUBS_PI16;
                case "_MM_MALLOC": return Intrinsic._MM_MALLOC;
                case "_MM_MASK_ABS_EPI16": return Intrinsic._MM_MASK_ABS_EPI16;
                case "_MM_MASK_ABS_EPI32": return Intrinsic._MM_MASK_ABS_EPI32;
                case "_MM_MASK_ABS_EPI64": return Intrinsic._MM_MASK_ABS_EPI64;
                case "_MM_MASK_ABS_EPI8": return Intrinsic._MM_MASK_ABS_EPI8;
                case "_MM_MASK_ADD_EPI16": return Intrinsic._MM_MASK_ADD_EPI16;
                case "_MM_MASK_ADD_EPI32": return Intrinsic._MM_MASK_ADD_EPI32;
                case "_MM_MASK_ADD_EPI64": return Intrinsic._MM_MASK_ADD_EPI64;
                case "_MM_MASK_ADD_EPI8": return Intrinsic._MM_MASK_ADD_EPI8;
                case "_MM_MASK_ADD_PD": return Intrinsic._MM_MASK_ADD_PD;
                case "_MM_MASK_ADD_PS": return Intrinsic._MM_MASK_ADD_PS;
                case "_MM_MASK_ADD_ROUND_SD": return Intrinsic._MM_MASK_ADD_ROUND_SD;
                case "_MM_MASK_ADD_ROUND_SS": return Intrinsic._MM_MASK_ADD_ROUND_SS;
                case "_MM_MASK_ADD_SD": return Intrinsic._MM_MASK_ADD_SD;
                case "_MM_MASK_ADD_SS": return Intrinsic._MM_MASK_ADD_SS;
                case "_MM_MASK_ADDS_EPI16": return Intrinsic._MM_MASK_ADDS_EPI16;
                case "_MM_MASK_ADDS_EPI8": return Intrinsic._MM_MASK_ADDS_EPI8;
                case "_MM_MASK_ADDS_EPU16": return Intrinsic._MM_MASK_ADDS_EPU16;
                case "_MM_MASK_ADDS_EPU8": return Intrinsic._MM_MASK_ADDS_EPU8;
                case "_MM_MASK_ALIGNR_EPI32": return Intrinsic._MM_MASK_ALIGNR_EPI32;
                case "_MM_MASK_ALIGNR_EPI64": return Intrinsic._MM_MASK_ALIGNR_EPI64;
                case "_MM_MASK_ALIGNR_EPI8": return Intrinsic._MM_MASK_ALIGNR_EPI8;
                case "_MM_MASK_AND_EPI32": return Intrinsic._MM_MASK_AND_EPI32;
                case "_MM_MASK_AND_EPI64": return Intrinsic._MM_MASK_AND_EPI64;
                case "_MM_MASK_AND_PD": return Intrinsic._MM_MASK_AND_PD;
                case "_MM_MASK_AND_PS": return Intrinsic._MM_MASK_AND_PS;
                case "_MM_MASK_ANDNOT_EPI32": return Intrinsic._MM_MASK_ANDNOT_EPI32;
                case "_MM_MASK_ANDNOT_EPI64": return Intrinsic._MM_MASK_ANDNOT_EPI64;
                case "_MM_MASK_ANDNOT_PD": return Intrinsic._MM_MASK_ANDNOT_PD;
                case "_MM_MASK_ANDNOT_PS": return Intrinsic._MM_MASK_ANDNOT_PS;
                case "_MM_MASK_AVG_EPU16": return Intrinsic._MM_MASK_AVG_EPU16;
                case "_MM_MASK_AVG_EPU8": return Intrinsic._MM_MASK_AVG_EPU8;
                case "_MM_MASK_BLEND_EPI16": return Intrinsic._MM_MASK_BLEND_EPI16;
                case "_MM_MASK_BLEND_EPI32": return Intrinsic._MM_MASK_BLEND_EPI32;
                case "_MM_MASK_BLEND_EPI64": return Intrinsic._MM_MASK_BLEND_EPI64;
                case "_MM_MASK_BLEND_EPI8": return Intrinsic._MM_MASK_BLEND_EPI8;
                case "_MM_MASK_BLEND_PD": return Intrinsic._MM_MASK_BLEND_PD;
                case "_MM_MASK_BLEND_PS": return Intrinsic._MM_MASK_BLEND_PS;
                case "_MM_MASK_BROADCAST_I32X2": return Intrinsic._MM_MASK_BROADCAST_I32X2;
                case "_MM_MASK_BROADCASTB_EPI8": return Intrinsic._MM_MASK_BROADCASTB_EPI8;
                case "_MM_MASK_BROADCASTD_EPI32": return Intrinsic._MM_MASK_BROADCASTD_EPI32;
                case "_MM_MASK_BROADCASTQ_EPI64": return Intrinsic._MM_MASK_BROADCASTQ_EPI64;
                case "_MM_MASK_BROADCASTSS_PS": return Intrinsic._MM_MASK_BROADCASTSS_PS;
                case "_MM_MASK_BROADCASTW_EPI16": return Intrinsic._MM_MASK_BROADCASTW_EPI16;
                case "_MM_MASK_CMP_EPI16_MASK": return Intrinsic._MM_MASK_CMP_EPI16_MASK;
                case "_MM_MASK_CMP_EPI32_MASK": return Intrinsic._MM_MASK_CMP_EPI32_MASK;
                case "_MM_MASK_CMP_EPI64_MASK": return Intrinsic._MM_MASK_CMP_EPI64_MASK;
                case "_MM_MASK_CMP_EPI8_MASK": return Intrinsic._MM_MASK_CMP_EPI8_MASK;
                case "_MM_MASK_CMP_EPU16_MASK": return Intrinsic._MM_MASK_CMP_EPU16_MASK;
                case "_MM_MASK_CMP_EPU32_MASK": return Intrinsic._MM_MASK_CMP_EPU32_MASK;
                case "_MM_MASK_CMP_EPU64_MASK": return Intrinsic._MM_MASK_CMP_EPU64_MASK;
                case "_MM_MASK_CMP_EPU8_MASK": return Intrinsic._MM_MASK_CMP_EPU8_MASK;
                case "_MM_MASK_CMP_PD_MASK": return Intrinsic._MM_MASK_CMP_PD_MASK;
                case "_MM_MASK_CMP_PS_MASK": return Intrinsic._MM_MASK_CMP_PS_MASK;
                case "_MM_MASK_CMP_ROUND_SD_MASK": return Intrinsic._MM_MASK_CMP_ROUND_SD_MASK;
                case "_MM_MASK_CMP_ROUND_SS_MASK": return Intrinsic._MM_MASK_CMP_ROUND_SS_MASK;
                case "_MM_MASK_CMP_SD_MASK": return Intrinsic._MM_MASK_CMP_SD_MASK;
                case "_MM_MASK_CMP_SS_MASK": return Intrinsic._MM_MASK_CMP_SS_MASK;
                case "_MM_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI16_MASK;
                case "_MM_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI32_MASK;
                case "_MM_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI64_MASK;
                case "_MM_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM_MASK_CMPEQ_EPI8_MASK;
                case "_MM_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU16_MASK;
                case "_MM_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU32_MASK;
                case "_MM_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU64_MASK;
                case "_MM_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM_MASK_CMPEQ_EPU8_MASK;
                case "_MM_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM_MASK_CMPGE_EPI16_MASK;
                case "_MM_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM_MASK_CMPGE_EPI32_MASK;
                case "_MM_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM_MASK_CMPGE_EPI64_MASK;
                case "_MM_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM_MASK_CMPGE_EPI8_MASK;
                case "_MM_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM_MASK_CMPGE_EPU16_MASK;
                case "_MM_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM_MASK_CMPGE_EPU32_MASK;
                case "_MM_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM_MASK_CMPGE_EPU64_MASK;
                case "_MM_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM_MASK_CMPGE_EPU8_MASK;
                case "_MM_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM_MASK_CMPGT_EPI16_MASK;
                case "_MM_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM_MASK_CMPGT_EPI32_MASK;
                case "_MM_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM_MASK_CMPGT_EPI64_MASK;
                case "_MM_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM_MASK_CMPGT_EPI8_MASK;
                case "_MM_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM_MASK_CMPGT_EPU16_MASK;
                case "_MM_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM_MASK_CMPGT_EPU32_MASK;
                case "_MM_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM_MASK_CMPGT_EPU64_MASK;
                case "_MM_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM_MASK_CMPGT_EPU8_MASK;
                case "_MM_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM_MASK_CMPLE_EPI16_MASK;
                case "_MM_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM_MASK_CMPLE_EPI32_MASK;
                case "_MM_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM_MASK_CMPLE_EPI64_MASK;
                case "_MM_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM_MASK_CMPLE_EPI8_MASK;
                case "_MM_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM_MASK_CMPLE_EPU16_MASK;
                case "_MM_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM_MASK_CMPLE_EPU32_MASK;
                case "_MM_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM_MASK_CMPLE_EPU64_MASK;
                case "_MM_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM_MASK_CMPLE_EPU8_MASK;
                case "_MM_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM_MASK_CMPLT_EPI16_MASK;
                case "_MM_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM_MASK_CMPLT_EPI32_MASK;
                case "_MM_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM_MASK_CMPLT_EPI64_MASK;
                case "_MM_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM_MASK_CMPLT_EPI8_MASK;
                case "_MM_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM_MASK_CMPLT_EPU16_MASK;
                case "_MM_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM_MASK_CMPLT_EPU32_MASK;
                case "_MM_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM_MASK_CMPLT_EPU64_MASK;
                case "_MM_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM_MASK_CMPLT_EPU8_MASK;
                case "_MM_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI16_MASK;
                case "_MM_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI32_MASK;
                case "_MM_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI64_MASK;
                case "_MM_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPI8_MASK;
                case "_MM_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU16_MASK;
                case "_MM_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU32_MASK;
                case "_MM_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU64_MASK;
                case "_MM_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM_MASK_CMPNEQ_EPU8_MASK;
                case "_MM_MASK_COMPRESS_EPI32": return Intrinsic._MM_MASK_COMPRESS_EPI32;
                case "_MM_MASK_COMPRESS_EPI64": return Intrinsic._MM_MASK_COMPRESS_EPI64;
                case "_MM_MASK_COMPRESS_PD": return Intrinsic._MM_MASK_COMPRESS_PD;
                case "_MM_MASK_COMPRESS_PS": return Intrinsic._MM_MASK_COMPRESS_PS;
                case "_MM_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM_MASK_COMPRESSSTOREU_EPI32;
                case "_MM_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM_MASK_COMPRESSSTOREU_EPI64;
                case "_MM_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM_MASK_COMPRESSSTOREU_PD;
                case "_MM_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM_MASK_COMPRESSSTOREU_PS;
                case "_MM_MASK_CONFLICT_EPI32": return Intrinsic._MM_MASK_CONFLICT_EPI32;
                case "_MM_MASK_CONFLICT_EPI64": return Intrinsic._MM_MASK_CONFLICT_EPI64;
                case "_MM_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM_MASK_CVT_ROUNDPS_PH;
                case "_MM_MASK_CVT_ROUNDSD_SS": return Intrinsic._MM_MASK_CVT_ROUNDSD_SS;
                case "_MM_MASK_CVT_ROUNDSS_SD": return Intrinsic._MM_MASK_CVT_ROUNDSS_SD;
                case "_MM_MASK_CVTEPI16_EPI32": return Intrinsic._MM_MASK_CVTEPI16_EPI32;
                case "_MM_MASK_CVTEPI16_EPI64": return Intrinsic._MM_MASK_CVTEPI16_EPI64;
                case "_MM_MASK_CVTEPI16_EPI8": return Intrinsic._MM_MASK_CVTEPI16_EPI8;
                case "_MM_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM_MASK_CVTEPI32_EPI16": return Intrinsic._MM_MASK_CVTEPI32_EPI16;
                case "_MM_MASK_CVTEPI32_EPI64": return Intrinsic._MM_MASK_CVTEPI32_EPI64;
                case "_MM_MASK_CVTEPI32_EPI8": return Intrinsic._MM_MASK_CVTEPI32_EPI8;
                case "_MM_MASK_CVTEPI32_PD": return Intrinsic._MM_MASK_CVTEPI32_PD;
                case "_MM_MASK_CVTEPI32_PS": return Intrinsic._MM_MASK_CVTEPI32_PS;
                case "_MM_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM_MASK_CVTEPI64_EPI16": return Intrinsic._MM_MASK_CVTEPI64_EPI16;
                case "_MM_MASK_CVTEPI64_EPI32": return Intrinsic._MM_MASK_CVTEPI64_EPI32;
                case "_MM_MASK_CVTEPI64_EPI8": return Intrinsic._MM_MASK_CVTEPI64_EPI8;
                case "_MM_MASK_CVTEPI64_PD": return Intrinsic._MM_MASK_CVTEPI64_PD;
                case "_MM_MASK_CVTEPI64_PS": return Intrinsic._MM_MASK_CVTEPI64_PS;
                case "_MM_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM_MASK_CVTEPI8_EPI16": return Intrinsic._MM_MASK_CVTEPI8_EPI16;
                case "_MM_MASK_CVTEPI8_EPI32": return Intrinsic._MM_MASK_CVTEPI8_EPI32;
                case "_MM_MASK_CVTEPI8_EPI64": return Intrinsic._MM_MASK_CVTEPI8_EPI64;
                case "_MM_MASK_CVTEPU16_EPI32": return Intrinsic._MM_MASK_CVTEPU16_EPI32;
                case "_MM_MASK_CVTEPU16_EPI64": return Intrinsic._MM_MASK_CVTEPU16_EPI64;
                case "_MM_MASK_CVTEPU32_EPI64": return Intrinsic._MM_MASK_CVTEPU32_EPI64;
                case "_MM_MASK_CVTEPU32_PD": return Intrinsic._MM_MASK_CVTEPU32_PD;
                case "_MM_MASK_CVTEPU64_PD": return Intrinsic._MM_MASK_CVTEPU64_PD;
                case "_MM_MASK_CVTEPU64_PS": return Intrinsic._MM_MASK_CVTEPU64_PS;
                case "_MM_MASK_CVTEPU8_EPI16": return Intrinsic._MM_MASK_CVTEPU8_EPI16;
                case "_MM_MASK_CVTEPU8_EPI32": return Intrinsic._MM_MASK_CVTEPU8_EPI32;
                case "_MM_MASK_CVTEPU8_EPI64": return Intrinsic._MM_MASK_CVTEPU8_EPI64;
                case "_MM_MASK_CVTPD_EPI32": return Intrinsic._MM_MASK_CVTPD_EPI32;
                case "_MM_MASK_CVTPD_EPI64": return Intrinsic._MM_MASK_CVTPD_EPI64;
                case "_MM_MASK_CVTPD_EPU32": return Intrinsic._MM_MASK_CVTPD_EPU32;
                case "_MM_MASK_CVTPD_EPU64": return Intrinsic._MM_MASK_CVTPD_EPU64;
                case "_MM_MASK_CVTPD_PS": return Intrinsic._MM_MASK_CVTPD_PS;
                case "_MM_MASK_CVTPH_PS": return Intrinsic._MM_MASK_CVTPH_PS;
                case "_MM_MASK_CVTPS_EPI32": return Intrinsic._MM_MASK_CVTPS_EPI32;
                case "_MM_MASK_CVTPS_EPI64": return Intrinsic._MM_MASK_CVTPS_EPI64;
                case "_MM_MASK_CVTPS_EPU32": return Intrinsic._MM_MASK_CVTPS_EPU32;
                case "_MM_MASK_CVTPS_EPU64": return Intrinsic._MM_MASK_CVTPS_EPU64;
                case "_MM_MASK_CVTPS_PH": return Intrinsic._MM_MASK_CVTPS_PH;
                case "_MM_MASK_CVTSD_SS": return Intrinsic._MM_MASK_CVTSD_SS;
                case "_MM_MASK_CVTSEPI16_EPI8": return Intrinsic._MM_MASK_CVTSEPI16_EPI8;
                case "_MM_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM_MASK_CVTSEPI32_EPI16": return Intrinsic._MM_MASK_CVTSEPI32_EPI16;
                case "_MM_MASK_CVTSEPI32_EPI8": return Intrinsic._MM_MASK_CVTSEPI32_EPI8;
                case "_MM_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM_MASK_CVTSEPI64_EPI16": return Intrinsic._MM_MASK_CVTSEPI64_EPI16;
                case "_MM_MASK_CVTSEPI64_EPI32": return Intrinsic._MM_MASK_CVTSEPI64_EPI32;
                case "_MM_MASK_CVTSEPI64_EPI8": return Intrinsic._MM_MASK_CVTSEPI64_EPI8;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTSEPI64_STOREU_EPI8;
                case "_MM_MASK_CVTSS_SD": return Intrinsic._MM_MASK_CVTSS_SD;
                case "_MM_MASK_CVTTPD_EPI32": return Intrinsic._MM_MASK_CVTTPD_EPI32;
                case "_MM_MASK_CVTTPD_EPI64": return Intrinsic._MM_MASK_CVTTPD_EPI64;
                case "_MM_MASK_CVTTPD_EPU32": return Intrinsic._MM_MASK_CVTTPD_EPU32;
                case "_MM_MASK_CVTTPD_EPU64": return Intrinsic._MM_MASK_CVTTPD_EPU64;
                case "_MM_MASK_CVTTPS_EPI32": return Intrinsic._MM_MASK_CVTTPS_EPI32;
                case "_MM_MASK_CVTTPS_EPI64": return Intrinsic._MM_MASK_CVTTPS_EPI64;
                case "_MM_MASK_CVTTPS_EPU32": return Intrinsic._MM_MASK_CVTTPS_EPU32;
                case "_MM_MASK_CVTTPS_EPU64": return Intrinsic._MM_MASK_CVTTPS_EPU64;
                case "_MM_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM_MASK_CVTUSEPI16_EPI8;
                case "_MM_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM_MASK_CVTUSEPI32_EPI16;
                case "_MM_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM_MASK_CVTUSEPI32_EPI8;
                case "_MM_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM_MASK_CVTUSEPI64_EPI16;
                case "_MM_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM_MASK_CVTUSEPI64_EPI32;
                case "_MM_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM_MASK_CVTUSEPI64_EPI8;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM_MASK_DBSAD_EPU8": return Intrinsic._MM_MASK_DBSAD_EPU8;
                case "_MM_MASK_DIV_PD": return Intrinsic._MM_MASK_DIV_PD;
                case "_MM_MASK_DIV_PS": return Intrinsic._MM_MASK_DIV_PS;
                case "_MM_MASK_DIV_ROUND_SD": return Intrinsic._MM_MASK_DIV_ROUND_SD;
                case "_MM_MASK_DIV_ROUND_SS": return Intrinsic._MM_MASK_DIV_ROUND_SS;
                case "_MM_MASK_DIV_SD": return Intrinsic._MM_MASK_DIV_SD;
                case "_MM_MASK_DIV_SS": return Intrinsic._MM_MASK_DIV_SS;
                case "_MM_MASK_EXPAND_EPI32": return Intrinsic._MM_MASK_EXPAND_EPI32;
                case "_MM_MASK_EXPAND_EPI64": return Intrinsic._MM_MASK_EXPAND_EPI64;
                case "_MM_MASK_EXPAND_PD": return Intrinsic._MM_MASK_EXPAND_PD;
                case "_MM_MASK_EXPAND_PS": return Intrinsic._MM_MASK_EXPAND_PS;
                case "_MM_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM_MASK_EXPANDLOADU_EPI32;
                case "_MM_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM_MASK_EXPANDLOADU_EPI64;
                case "_MM_MASK_EXPANDLOADU_PD": return Intrinsic._MM_MASK_EXPANDLOADU_PD;
                case "_MM_MASK_EXPANDLOADU_PS": return Intrinsic._MM_MASK_EXPANDLOADU_PS;
                case "_MM_MASK_FIXUPIMM_PD": return Intrinsic._MM_MASK_FIXUPIMM_PD;
                case "_MM_MASK_FIXUPIMM_PS": return Intrinsic._MM_MASK_FIXUPIMM_PS;
                case "_MM_MASK_FIXUPIMM_ROUND_SD": return Intrinsic._MM_MASK_FIXUPIMM_ROUND_SD;
                case "_MM_MASK_FIXUPIMM_ROUND_SS": return Intrinsic._MM_MASK_FIXUPIMM_ROUND_SS;
                case "_MM_MASK_FIXUPIMM_SD": return Intrinsic._MM_MASK_FIXUPIMM_SD;
                case "_MM_MASK_FIXUPIMM_SS": return Intrinsic._MM_MASK_FIXUPIMM_SS;
                case "_MM_MASK_FMADD_PD": return Intrinsic._MM_MASK_FMADD_PD;
                case "_MM_MASK_FMADD_PS": return Intrinsic._MM_MASK_FMADD_PS;
                case "_MM_MASK_FMADD_ROUND_SD": return Intrinsic._MM_MASK_FMADD_ROUND_SD;
                case "_MM_MASK_FMADD_ROUND_SS": return Intrinsic._MM_MASK_FMADD_ROUND_SS;
                case "_MM_MASK_FMADD_SD": return Intrinsic._MM_MASK_FMADD_SD;
                case "_MM_MASK_FMADD_SS": return Intrinsic._MM_MASK_FMADD_SS;
                case "_MM_MASK_FMADDSUB_PD": return Intrinsic._MM_MASK_FMADDSUB_PD;
                case "_MM_MASK_FMADDSUB_PS": return Intrinsic._MM_MASK_FMADDSUB_PS;
                case "_MM_MASK_FMSUB_PD": return Intrinsic._MM_MASK_FMSUB_PD;
                case "_MM_MASK_FMSUB_PS": return Intrinsic._MM_MASK_FMSUB_PS;
                case "_MM_MASK_FMSUB_ROUND_SD": return Intrinsic._MM_MASK_FMSUB_ROUND_SD;
                case "_MM_MASK_FMSUB_ROUND_SS": return Intrinsic._MM_MASK_FMSUB_ROUND_SS;
                case "_MM_MASK_FMSUB_SD": return Intrinsic._MM_MASK_FMSUB_SD;
                case "_MM_MASK_FMSUB_SS": return Intrinsic._MM_MASK_FMSUB_SS;
                case "_MM_MASK_FMSUBADD_PD": return Intrinsic._MM_MASK_FMSUBADD_PD;
                case "_MM_MASK_FMSUBADD_PS": return Intrinsic._MM_MASK_FMSUBADD_PS;
                case "_MM_MASK_FNMADD_PD": return Intrinsic._MM_MASK_FNMADD_PD;
                case "_MM_MASK_FNMADD_PS": return Intrinsic._MM_MASK_FNMADD_PS;
                case "_MM_MASK_FNMADD_ROUND_SD": return Intrinsic._MM_MASK_FNMADD_ROUND_SD;
                case "_MM_MASK_FNMADD_ROUND_SS": return Intrinsic._MM_MASK_FNMADD_ROUND_SS;
                case "_MM_MASK_FNMADD_SD": return Intrinsic._MM_MASK_FNMADD_SD;
                case "_MM_MASK_FNMADD_SS": return Intrinsic._MM_MASK_FNMADD_SS;
                case "_MM_MASK_FNMSUB_PD": return Intrinsic._MM_MASK_FNMSUB_PD;
                case "_MM_MASK_FNMSUB_PS": return Intrinsic._MM_MASK_FNMSUB_PS;
                case "_MM_MASK_FNMSUB_ROUND_SD": return Intrinsic._MM_MASK_FNMSUB_ROUND_SD;
                case "_MM_MASK_FNMSUB_ROUND_SS": return Intrinsic._MM_MASK_FNMSUB_ROUND_SS;
                case "_MM_MASK_FNMSUB_SD": return Intrinsic._MM_MASK_FNMSUB_SD;
                case "_MM_MASK_FNMSUB_SS": return Intrinsic._MM_MASK_FNMSUB_SS;
                case "_MM_MASK_FPCLASS_PD_MASK": return Intrinsic._MM_MASK_FPCLASS_PD_MASK;
                case "_MM_MASK_FPCLASS_PS_MASK": return Intrinsic._MM_MASK_FPCLASS_PS_MASK;
                case "_MM_MASK_FPCLASS_SD_MASK": return Intrinsic._MM_MASK_FPCLASS_SD_MASK;
                case "_MM_MASK_FPCLASS_SS_MASK": return Intrinsic._MM_MASK_FPCLASS_SS_MASK;
                case "_MM_MASK_GETEXP_PD": return Intrinsic._MM_MASK_GETEXP_PD;
                case "_MM_MASK_GETEXP_PS": return Intrinsic._MM_MASK_GETEXP_PS;
                case "_MM_MASK_GETEXP_ROUND_SD": return Intrinsic._MM_MASK_GETEXP_ROUND_SD;
                case "_MM_MASK_GETEXP_ROUND_SS": return Intrinsic._MM_MASK_GETEXP_ROUND_SS;
                case "_MM_MASK_GETEXP_SD": return Intrinsic._MM_MASK_GETEXP_SD;
                case "_MM_MASK_GETEXP_SS": return Intrinsic._MM_MASK_GETEXP_SS;
                case "_MM_MASK_GETMANT_PD": return Intrinsic._MM_MASK_GETMANT_PD;
                case "_MM_MASK_GETMANT_PS": return Intrinsic._MM_MASK_GETMANT_PS;
                case "_MM_MASK_GETMANT_ROUND_SD": return Intrinsic._MM_MASK_GETMANT_ROUND_SD;
                case "_MM_MASK_GETMANT_ROUND_SS": return Intrinsic._MM_MASK_GETMANT_ROUND_SS;
                case "_MM_MASK_GETMANT_SD": return Intrinsic._MM_MASK_GETMANT_SD;
                case "_MM_MASK_GETMANT_SS": return Intrinsic._MM_MASK_GETMANT_SS;
                case "_MM_MASK_I32GATHER_EPI32": return Intrinsic._MM_MASK_I32GATHER_EPI32;
                case "_MM_MASK_I32GATHER_EPI64": return Intrinsic._MM_MASK_I32GATHER_EPI64;
                case "_MM_MASK_I32GATHER_PD": return Intrinsic._MM_MASK_I32GATHER_PD;
                case "_MM_MASK_I32GATHER_PS": return Intrinsic._MM_MASK_I32GATHER_PS;
                case "_MM_MASK_I32SCATTER_EPI32": return Intrinsic._MM_MASK_I32SCATTER_EPI32;
                case "_MM_MASK_I32SCATTER_EPI64": return Intrinsic._MM_MASK_I32SCATTER_EPI64;
                case "_MM_MASK_I32SCATTER_PD": return Intrinsic._MM_MASK_I32SCATTER_PD;
                case "_MM_MASK_I32SCATTER_PS": return Intrinsic._MM_MASK_I32SCATTER_PS;
                case "_MM_MASK_I64GATHER_EPI32": return Intrinsic._MM_MASK_I64GATHER_EPI32;
                case "_MM_MASK_I64GATHER_EPI64": return Intrinsic._MM_MASK_I64GATHER_EPI64;
                case "_MM_MASK_I64GATHER_PD": return Intrinsic._MM_MASK_I64GATHER_PD;
                case "_MM_MASK_I64GATHER_PS": return Intrinsic._MM_MASK_I64GATHER_PS;
                case "_MM_MASK_I64SCATTER_EPI32": return Intrinsic._MM_MASK_I64SCATTER_EPI32;
                case "_MM_MASK_I64SCATTER_EPI64": return Intrinsic._MM_MASK_I64SCATTER_EPI64;
                case "_MM_MASK_I64SCATTER_PD": return Intrinsic._MM_MASK_I64SCATTER_PD;
                case "_MM_MASK_I64SCATTER_PS": return Intrinsic._MM_MASK_I64SCATTER_PS;
                case "_MM_MASK_LOAD_EPI32": return Intrinsic._MM_MASK_LOAD_EPI32;
                case "_MM_MASK_LOAD_EPI64": return Intrinsic._MM_MASK_LOAD_EPI64;
                case "_MM_MASK_LOAD_PD": return Intrinsic._MM_MASK_LOAD_PD;
                case "_MM_MASK_LOAD_PS": return Intrinsic._MM_MASK_LOAD_PS;
                case "_MM_MASK_LOAD_SD": return Intrinsic._MM_MASK_LOAD_SD;
                case "_MM_MASK_LOAD_SS": return Intrinsic._MM_MASK_LOAD_SS;
                case "_MM_MASK_LOADU_EPI16": return Intrinsic._MM_MASK_LOADU_EPI16;
                case "_MM_MASK_LOADU_EPI32": return Intrinsic._MM_MASK_LOADU_EPI32;
                case "_MM_MASK_LOADU_EPI64": return Intrinsic._MM_MASK_LOADU_EPI64;
                case "_MM_MASK_LOADU_EPI8": return Intrinsic._MM_MASK_LOADU_EPI8;
                case "_MM_MASK_LOADU_PD": return Intrinsic._MM_MASK_LOADU_PD;
                case "_MM_MASK_LOADU_PS": return Intrinsic._MM_MASK_LOADU_PS;
                case "_MM_MASK_LZCNT_EPI32": return Intrinsic._MM_MASK_LZCNT_EPI32;
                case "_MM_MASK_LZCNT_EPI64": return Intrinsic._MM_MASK_LZCNT_EPI64;
                case "_MM_MASK_MADD_EPI16": return Intrinsic._MM_MASK_MADD_EPI16;
                case "_MM_MASK_MADD52HI_EPU64": return Intrinsic._MM_MASK_MADD52HI_EPU64;
                case "_MM_MASK_MADD52LO_EPU64": return Intrinsic._MM_MASK_MADD52LO_EPU64;
                case "_MM_MASK_MADDUBS_EPI16": return Intrinsic._MM_MASK_MADDUBS_EPI16;
                case "_MM_MASK_MAX_EPI16": return Intrinsic._MM_MASK_MAX_EPI16;
                case "_MM_MASK_MAX_EPI32": return Intrinsic._MM_MASK_MAX_EPI32;
                case "_MM_MASK_MAX_EPI64": return Intrinsic._MM_MASK_MAX_EPI64;
                case "_MM_MASK_MAX_EPI8": return Intrinsic._MM_MASK_MAX_EPI8;
                case "_MM_MASK_MAX_EPU16": return Intrinsic._MM_MASK_MAX_EPU16;
                case "_MM_MASK_MAX_EPU32": return Intrinsic._MM_MASK_MAX_EPU32;
                case "_MM_MASK_MAX_EPU64": return Intrinsic._MM_MASK_MAX_EPU64;
                case "_MM_MASK_MAX_EPU8": return Intrinsic._MM_MASK_MAX_EPU8;
                case "_MM_MASK_MAX_PD": return Intrinsic._MM_MASK_MAX_PD;
                case "_MM_MASK_MAX_PS": return Intrinsic._MM_MASK_MAX_PS;
                case "_MM_MASK_MAX_ROUND_SD": return Intrinsic._MM_MASK_MAX_ROUND_SD;
                case "_MM_MASK_MAX_ROUND_SS": return Intrinsic._MM_MASK_MAX_ROUND_SS;
                case "_MM_MASK_MAX_SD": return Intrinsic._MM_MASK_MAX_SD;
                case "_MM_MASK_MAX_SS": return Intrinsic._MM_MASK_MAX_SS;
                case "_MM_MASK_MIN_EPI16": return Intrinsic._MM_MASK_MIN_EPI16;
                case "_MM_MASK_MIN_EPI32": return Intrinsic._MM_MASK_MIN_EPI32;
                case "_MM_MASK_MIN_EPI64": return Intrinsic._MM_MASK_MIN_EPI64;
                case "_MM_MASK_MIN_EPI8": return Intrinsic._MM_MASK_MIN_EPI8;
                case "_MM_MASK_MIN_EPU16": return Intrinsic._MM_MASK_MIN_EPU16;
                case "_MM_MASK_MIN_EPU32": return Intrinsic._MM_MASK_MIN_EPU32;
                case "_MM_MASK_MIN_EPU64": return Intrinsic._MM_MASK_MIN_EPU64;
                case "_MM_MASK_MIN_EPU8": return Intrinsic._MM_MASK_MIN_EPU8;
                case "_MM_MASK_MIN_PD": return Intrinsic._MM_MASK_MIN_PD;
                case "_MM_MASK_MIN_PS": return Intrinsic._MM_MASK_MIN_PS;
                case "_MM_MASK_MIN_ROUND_SD": return Intrinsic._MM_MASK_MIN_ROUND_SD;
                case "_MM_MASK_MIN_ROUND_SS": return Intrinsic._MM_MASK_MIN_ROUND_SS;
                case "_MM_MASK_MIN_SD": return Intrinsic._MM_MASK_MIN_SD;
                case "_MM_MASK_MIN_SS": return Intrinsic._MM_MASK_MIN_SS;
                case "_MM_MASK_MOV_EPI16": return Intrinsic._MM_MASK_MOV_EPI16;
                case "_MM_MASK_MOV_EPI32": return Intrinsic._MM_MASK_MOV_EPI32;
                case "_MM_MASK_MOV_EPI64": return Intrinsic._MM_MASK_MOV_EPI64;
                case "_MM_MASK_MOV_EPI8": return Intrinsic._MM_MASK_MOV_EPI8;
                case "_MM_MASK_MOV_PD": return Intrinsic._MM_MASK_MOV_PD;
                case "_MM_MASK_MOV_PS": return Intrinsic._MM_MASK_MOV_PS;
                case "_MM_MASK_MOVE_SD": return Intrinsic._MM_MASK_MOVE_SD;
                case "_MM_MASK_MOVE_SS": return Intrinsic._MM_MASK_MOVE_SS;
                case "_MM_MASK_MOVEDUP_PD": return Intrinsic._MM_MASK_MOVEDUP_PD;
                case "_MM_MASK_MOVEHDUP_PS": return Intrinsic._MM_MASK_MOVEHDUP_PS;
                case "_MM_MASK_MOVELDUP_PS": return Intrinsic._MM_MASK_MOVELDUP_PS;
                case "_MM_MASK_MUL_EPI32": return Intrinsic._MM_MASK_MUL_EPI32;
                case "_MM_MASK_MUL_EPU32": return Intrinsic._MM_MASK_MUL_EPU32;
                case "_MM_MASK_MUL_PD": return Intrinsic._MM_MASK_MUL_PD;
                case "_MM_MASK_MUL_PS": return Intrinsic._MM_MASK_MUL_PS;
                case "_MM_MASK_MUL_ROUND_SD": return Intrinsic._MM_MASK_MUL_ROUND_SD;
                case "_MM_MASK_MUL_ROUND_SS": return Intrinsic._MM_MASK_MUL_ROUND_SS;
                case "_MM_MASK_MUL_SD": return Intrinsic._MM_MASK_MUL_SD;
                case "_MM_MASK_MUL_SS": return Intrinsic._MM_MASK_MUL_SS;
                case "_MM_MASK_MULHI_EPI16": return Intrinsic._MM_MASK_MULHI_EPI16;
                case "_MM_MASK_MULHI_EPU16": return Intrinsic._MM_MASK_MULHI_EPU16;
                case "_MM_MASK_MULHRS_EPI16": return Intrinsic._MM_MASK_MULHRS_EPI16;
                case "_MM_MASK_MULLO_EPI16": return Intrinsic._MM_MASK_MULLO_EPI16;
                case "_MM_MASK_MULLO_EPI32": return Intrinsic._MM_MASK_MULLO_EPI32;
                case "_MM_MASK_MULLO_EPI64": return Intrinsic._MM_MASK_MULLO_EPI64;
                case "_MM_MASK_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM_MASK_MULTISHIFT_EPI64_EPI8;
                case "_MM_MASK_OR_EPI32": return Intrinsic._MM_MASK_OR_EPI32;
                case "_MM_MASK_OR_EPI64": return Intrinsic._MM_MASK_OR_EPI64;
                case "_MM_MASK_OR_PD": return Intrinsic._MM_MASK_OR_PD;
                case "_MM_MASK_OR_PS": return Intrinsic._MM_MASK_OR_PS;
                case "_MM_MASK_PACKS_EPI16": return Intrinsic._MM_MASK_PACKS_EPI16;
                case "_MM_MASK_PACKS_EPI32": return Intrinsic._MM_MASK_PACKS_EPI32;
                case "_MM_MASK_PACKUS_EPI16": return Intrinsic._MM_MASK_PACKUS_EPI16;
                case "_MM_MASK_PACKUS_EPI32": return Intrinsic._MM_MASK_PACKUS_EPI32;
                case "_MM_MASK_PERMUTE_PD": return Intrinsic._MM_MASK_PERMUTE_PD;
                case "_MM_MASK_PERMUTE_PS": return Intrinsic._MM_MASK_PERMUTE_PS;
                case "_MM_MASK_PERMUTEVAR_PD": return Intrinsic._MM_MASK_PERMUTEVAR_PD;
                case "_MM_MASK_PERMUTEVAR_PS": return Intrinsic._MM_MASK_PERMUTEVAR_PS;
                case "_MM_MASK_PERMUTEX2VAR_EPI16": return Intrinsic._MM_MASK_PERMUTEX2VAR_EPI16;
                case "_MM_MASK_PERMUTEX2VAR_EPI32": return Intrinsic._MM_MASK_PERMUTEX2VAR_EPI32;
                case "_MM_MASK_PERMUTEX2VAR_EPI64": return Intrinsic._MM_MASK_PERMUTEX2VAR_EPI64;
                case "_MM_MASK_PERMUTEX2VAR_EPI8": return Intrinsic._MM_MASK_PERMUTEX2VAR_EPI8;
                case "_MM_MASK_PERMUTEX2VAR_PD": return Intrinsic._MM_MASK_PERMUTEX2VAR_PD;
                case "_MM_MASK_PERMUTEX2VAR_PS": return Intrinsic._MM_MASK_PERMUTEX2VAR_PS;
                case "_MM_MASK_PERMUTEXVAR_EPI16": return Intrinsic._MM_MASK_PERMUTEXVAR_EPI16;
                case "_MM_MASK_PERMUTEXVAR_EPI8": return Intrinsic._MM_MASK_PERMUTEXVAR_EPI8;
                case "_MM_MASK_RANGE_PD": return Intrinsic._MM_MASK_RANGE_PD;
                case "_MM_MASK_RANGE_PS": return Intrinsic._MM_MASK_RANGE_PS;
                case "_MM_MASK_RANGE_ROUND_SD": return Intrinsic._MM_MASK_RANGE_ROUND_SD;
                case "_MM_MASK_RANGE_ROUND_SS": return Intrinsic._MM_MASK_RANGE_ROUND_SS;
                case "_MM_MASK_RANGE_SD": return Intrinsic._MM_MASK_RANGE_SD;
                case "_MM_MASK_RANGE_SS": return Intrinsic._MM_MASK_RANGE_SS;
                case "_MM_MASK_RCP14_PD": return Intrinsic._MM_MASK_RCP14_PD;
                case "_MM_MASK_RCP14_PS": return Intrinsic._MM_MASK_RCP14_PS;
                case "_MM_MASK_RCP14_SD": return Intrinsic._MM_MASK_RCP14_SD;
                case "_MM_MASK_RCP14_SS": return Intrinsic._MM_MASK_RCP14_SS;
                case "_MM_MASK_RCP28_ROUND_SD": return Intrinsic._MM_MASK_RCP28_ROUND_SD;
                case "_MM_MASK_RCP28_ROUND_SS": return Intrinsic._MM_MASK_RCP28_ROUND_SS;
                case "_MM_MASK_RCP28_SD": return Intrinsic._MM_MASK_RCP28_SD;
                case "_MM_MASK_RCP28_SS": return Intrinsic._MM_MASK_RCP28_SS;
                case "_MM_MASK_REDUCE_PD": return Intrinsic._MM_MASK_REDUCE_PD;
                case "_MM_MASK_REDUCE_PS": return Intrinsic._MM_MASK_REDUCE_PS;
                case "_MM_MASK_REDUCE_ROUND_SD": return Intrinsic._MM_MASK_REDUCE_ROUND_SD;
                case "_MM_MASK_REDUCE_ROUND_SS": return Intrinsic._MM_MASK_REDUCE_ROUND_SS;
                case "_MM_MASK_REDUCE_SD": return Intrinsic._MM_MASK_REDUCE_SD;
                case "_MM_MASK_REDUCE_SS": return Intrinsic._MM_MASK_REDUCE_SS;
                case "_MM_MASK_ROL_EPI32": return Intrinsic._MM_MASK_ROL_EPI32;
                case "_MM_MASK_ROL_EPI64": return Intrinsic._MM_MASK_ROL_EPI64;
                case "_MM_MASK_ROLV_EPI32": return Intrinsic._MM_MASK_ROLV_EPI32;
                case "_MM_MASK_ROLV_EPI64": return Intrinsic._MM_MASK_ROLV_EPI64;
                case "_MM_MASK_ROR_EPI32": return Intrinsic._MM_MASK_ROR_EPI32;
                case "_MM_MASK_ROR_EPI64": return Intrinsic._MM_MASK_ROR_EPI64;
                case "_MM_MASK_RORV_EPI32": return Intrinsic._MM_MASK_RORV_EPI32;
                case "_MM_MASK_RORV_EPI64": return Intrinsic._MM_MASK_RORV_EPI64;
                case "_MM_MASK_ROUNDSCALE_PD": return Intrinsic._MM_MASK_ROUNDSCALE_PD;
                case "_MM_MASK_ROUNDSCALE_PS": return Intrinsic._MM_MASK_ROUNDSCALE_PS;
                case "_MM_MASK_ROUNDSCALE_ROUND_SD": return Intrinsic._MM_MASK_ROUNDSCALE_ROUND_SD;
                case "_MM_MASK_ROUNDSCALE_ROUND_SS": return Intrinsic._MM_MASK_ROUNDSCALE_ROUND_SS;
                case "_MM_MASK_ROUNDSCALE_SD": return Intrinsic._MM_MASK_ROUNDSCALE_SD;
                case "_MM_MASK_ROUNDSCALE_SS": return Intrinsic._MM_MASK_ROUNDSCALE_SS;
                case "_MM_MASK_RSQRT14_PD": return Intrinsic._MM_MASK_RSQRT14_PD;
                case "_MM_MASK_RSQRT14_PS": return Intrinsic._MM_MASK_RSQRT14_PS;
                case "_MM_MASK_RSQRT14_SD": return Intrinsic._MM_MASK_RSQRT14_SD;
                case "_MM_MASK_RSQRT14_SS": return Intrinsic._MM_MASK_RSQRT14_SS;
                case "_MM_MASK_RSQRT28_ROUND_SD": return Intrinsic._MM_MASK_RSQRT28_ROUND_SD;
                case "_MM_MASK_RSQRT28_ROUND_SS": return Intrinsic._MM_MASK_RSQRT28_ROUND_SS;
                case "_MM_MASK_RSQRT28_SD": return Intrinsic._MM_MASK_RSQRT28_SD;
                case "_MM_MASK_RSQRT28_SS": return Intrinsic._MM_MASK_RSQRT28_SS;
                case "_MM_MASK_SCALEF_PD": return Intrinsic._MM_MASK_SCALEF_PD;
                case "_MM_MASK_SCALEF_PS": return Intrinsic._MM_MASK_SCALEF_PS;
                case "_MM_MASK_SCALEF_ROUND_SD": return Intrinsic._MM_MASK_SCALEF_ROUND_SD;
                case "_MM_MASK_SCALEF_ROUND_SS": return Intrinsic._MM_MASK_SCALEF_ROUND_SS;
                case "_MM_MASK_SCALEF_SD": return Intrinsic._MM_MASK_SCALEF_SD;
                case "_MM_MASK_SCALEF_SS": return Intrinsic._MM_MASK_SCALEF_SS;
                case "_MM_MASK_SET1_EPI16": return Intrinsic._MM_MASK_SET1_EPI16;
                case "_MM_MASK_SET1_EPI32": return Intrinsic._MM_MASK_SET1_EPI32;
                case "_MM_MASK_SET1_EPI64": return Intrinsic._MM_MASK_SET1_EPI64;
                case "_MM_MASK_SET1_EPI8": return Intrinsic._MM_MASK_SET1_EPI8;
                case "_MM_MASK_SHUFFLE_EPI32": return Intrinsic._MM_MASK_SHUFFLE_EPI32;
                case "_MM_MASK_SHUFFLE_EPI8": return Intrinsic._MM_MASK_SHUFFLE_EPI8;
                case "_MM_MASK_SHUFFLE_PD": return Intrinsic._MM_MASK_SHUFFLE_PD;
                case "_MM_MASK_SHUFFLE_PS": return Intrinsic._MM_MASK_SHUFFLE_PS;
                case "_MM_MASK_SHUFFLEHI_EPI16": return Intrinsic._MM_MASK_SHUFFLEHI_EPI16;
                case "_MM_MASK_SHUFFLELO_EPI16": return Intrinsic._MM_MASK_SHUFFLELO_EPI16;
                case "_MM_MASK_SLL_EPI16": return Intrinsic._MM_MASK_SLL_EPI16;
                case "_MM_MASK_SLL_EPI32": return Intrinsic._MM_MASK_SLL_EPI32;
                case "_MM_MASK_SLL_EPI64": return Intrinsic._MM_MASK_SLL_EPI64;
                case "_MM_MASK_SLLI_EPI16": return Intrinsic._MM_MASK_SLLI_EPI16;
                case "_MM_MASK_SLLI_EPI32": return Intrinsic._MM_MASK_SLLI_EPI32;
                case "_MM_MASK_SLLI_EPI64": return Intrinsic._MM_MASK_SLLI_EPI64;
                case "_MM_MASK_SLLV_EPI16": return Intrinsic._MM_MASK_SLLV_EPI16;
                case "_MM_MASK_SLLV_EPI32": return Intrinsic._MM_MASK_SLLV_EPI32;
                case "_MM_MASK_SLLV_EPI64": return Intrinsic._MM_MASK_SLLV_EPI64;
                case "_MM_MASK_SQRT_PD": return Intrinsic._MM_MASK_SQRT_PD;
                case "_MM_MASK_SQRT_PS": return Intrinsic._MM_MASK_SQRT_PS;
                case "_MM_MASK_SQRT_ROUND_SD": return Intrinsic._MM_MASK_SQRT_ROUND_SD;
                case "_MM_MASK_SQRT_ROUND_SS": return Intrinsic._MM_MASK_SQRT_ROUND_SS;
                case "_MM_MASK_SQRT_SD": return Intrinsic._MM_MASK_SQRT_SD;
                case "_MM_MASK_SQRT_SS": return Intrinsic._MM_MASK_SQRT_SS;
                case "_MM_MASK_SRA_EPI16": return Intrinsic._MM_MASK_SRA_EPI16;
                case "_MM_MASK_SRA_EPI32": return Intrinsic._MM_MASK_SRA_EPI32;
                case "_MM_MASK_SRA_EPI64": return Intrinsic._MM_MASK_SRA_EPI64;
                case "_MM_MASK_SRAI_EPI16": return Intrinsic._MM_MASK_SRAI_EPI16;
                case "_MM_MASK_SRAI_EPI32": return Intrinsic._MM_MASK_SRAI_EPI32;
                case "_MM_MASK_SRAI_EPI64": return Intrinsic._MM_MASK_SRAI_EPI64;
                case "_MM_MASK_SRAV_EPI16": return Intrinsic._MM_MASK_SRAV_EPI16;
                case "_MM_MASK_SRAV_EPI32": return Intrinsic._MM_MASK_SRAV_EPI32;
                case "_MM_MASK_SRAV_EPI64": return Intrinsic._MM_MASK_SRAV_EPI64;
                case "_MM_MASK_SRL_EPI16": return Intrinsic._MM_MASK_SRL_EPI16;
                case "_MM_MASK_SRL_EPI32": return Intrinsic._MM_MASK_SRL_EPI32;
                case "_MM_MASK_SRL_EPI64": return Intrinsic._MM_MASK_SRL_EPI64;
                case "_MM_MASK_SRLI_EPI16": return Intrinsic._MM_MASK_SRLI_EPI16;
                case "_MM_MASK_SRLI_EPI32": return Intrinsic._MM_MASK_SRLI_EPI32;
                case "_MM_MASK_SRLI_EPI64": return Intrinsic._MM_MASK_SRLI_EPI64;
                case "_MM_MASK_SRLV_EPI16": return Intrinsic._MM_MASK_SRLV_EPI16;
                case "_MM_MASK_SRLV_EPI32": return Intrinsic._MM_MASK_SRLV_EPI32;
                case "_MM_MASK_SRLV_EPI64": return Intrinsic._MM_MASK_SRLV_EPI64;
                case "_MM_MASK_STORE_EPI32": return Intrinsic._MM_MASK_STORE_EPI32;
                case "_MM_MASK_STORE_EPI64": return Intrinsic._MM_MASK_STORE_EPI64;
                case "_MM_MASK_STORE_PD": return Intrinsic._MM_MASK_STORE_PD;
                case "_MM_MASK_STORE_PS": return Intrinsic._MM_MASK_STORE_PS;
                case "_MM_MASK_STORE_SD": return Intrinsic._MM_MASK_STORE_SD;
                case "_MM_MASK_STORE_SS": return Intrinsic._MM_MASK_STORE_SS;
                case "_MM_MASK_STOREU_EPI16": return Intrinsic._MM_MASK_STOREU_EPI16;
                case "_MM_MASK_STOREU_EPI32": return Intrinsic._MM_MASK_STOREU_EPI32;
                case "_MM_MASK_STOREU_EPI64": return Intrinsic._MM_MASK_STOREU_EPI64;
                case "_MM_MASK_STOREU_EPI8": return Intrinsic._MM_MASK_STOREU_EPI8;
                case "_MM_MASK_STOREU_PD": return Intrinsic._MM_MASK_STOREU_PD;
                case "_MM_MASK_STOREU_PS": return Intrinsic._MM_MASK_STOREU_PS;
                case "_MM_MASK_SUB_EPI16": return Intrinsic._MM_MASK_SUB_EPI16;
                case "_MM_MASK_SUB_EPI32": return Intrinsic._MM_MASK_SUB_EPI32;
                case "_MM_MASK_SUB_EPI64": return Intrinsic._MM_MASK_SUB_EPI64;
                case "_MM_MASK_SUB_EPI8": return Intrinsic._MM_MASK_SUB_EPI8;
                case "_MM_MASK_SUB_PD": return Intrinsic._MM_MASK_SUB_PD;
                case "_MM_MASK_SUB_PS": return Intrinsic._MM_MASK_SUB_PS;
                case "_MM_MASK_SUB_ROUND_SD": return Intrinsic._MM_MASK_SUB_ROUND_SD;
                case "_MM_MASK_SUB_ROUND_SS": return Intrinsic._MM_MASK_SUB_ROUND_SS;
                case "_MM_MASK_SUB_SD": return Intrinsic._MM_MASK_SUB_SD;
                case "_MM_MASK_SUB_SS": return Intrinsic._MM_MASK_SUB_SS;
                case "_MM_MASK_SUBS_EPI16": return Intrinsic._MM_MASK_SUBS_EPI16;
                case "_MM_MASK_SUBS_EPI8": return Intrinsic._MM_MASK_SUBS_EPI8;
                case "_MM_MASK_SUBS_EPU16": return Intrinsic._MM_MASK_SUBS_EPU16;
                case "_MM_MASK_SUBS_EPU8": return Intrinsic._MM_MASK_SUBS_EPU8;
                case "_MM_MASK_TERNARYLOGIC_EPI32": return Intrinsic._MM_MASK_TERNARYLOGIC_EPI32;
                case "_MM_MASK_TERNARYLOGIC_EPI64": return Intrinsic._MM_MASK_TERNARYLOGIC_EPI64;
                case "_MM_MASK_TEST_EPI16_MASK": return Intrinsic._MM_MASK_TEST_EPI16_MASK;
                case "_MM_MASK_TEST_EPI32_MASK": return Intrinsic._MM_MASK_TEST_EPI32_MASK;
                case "_MM_MASK_TEST_EPI64_MASK": return Intrinsic._MM_MASK_TEST_EPI64_MASK;
                case "_MM_MASK_TEST_EPI8_MASK": return Intrinsic._MM_MASK_TEST_EPI8_MASK;
                case "_MM_MASK_TESTN_EPI16_MASK": return Intrinsic._MM_MASK_TESTN_EPI16_MASK;
                case "_MM_MASK_TESTN_EPI32_MASK": return Intrinsic._MM_MASK_TESTN_EPI32_MASK;
                case "_MM_MASK_TESTN_EPI64_MASK": return Intrinsic._MM_MASK_TESTN_EPI64_MASK;
                case "_MM_MASK_TESTN_EPI8_MASK": return Intrinsic._MM_MASK_TESTN_EPI8_MASK;
                case "_MM_MASK_UNPACKHI_EPI16": return Intrinsic._MM_MASK_UNPACKHI_EPI16;
                case "_MM_MASK_UNPACKHI_EPI32": return Intrinsic._MM_MASK_UNPACKHI_EPI32;
                case "_MM_MASK_UNPACKHI_EPI64": return Intrinsic._MM_MASK_UNPACKHI_EPI64;
                case "_MM_MASK_UNPACKHI_EPI8": return Intrinsic._MM_MASK_UNPACKHI_EPI8;
                case "_MM_MASK_UNPACKHI_PD": return Intrinsic._MM_MASK_UNPACKHI_PD;
                case "_MM_MASK_UNPACKHI_PS": return Intrinsic._MM_MASK_UNPACKHI_PS;
                case "_MM_MASK_UNPACKLO_EPI16": return Intrinsic._MM_MASK_UNPACKLO_EPI16;
                case "_MM_MASK_UNPACKLO_EPI32": return Intrinsic._MM_MASK_UNPACKLO_EPI32;
                case "_MM_MASK_UNPACKLO_EPI64": return Intrinsic._MM_MASK_UNPACKLO_EPI64;
                case "_MM_MASK_UNPACKLO_EPI8": return Intrinsic._MM_MASK_UNPACKLO_EPI8;
                case "_MM_MASK_UNPACKLO_PD": return Intrinsic._MM_MASK_UNPACKLO_PD;
                case "_MM_MASK_UNPACKLO_PS": return Intrinsic._MM_MASK_UNPACKLO_PS;
                case "_MM_MASK_XOR_EPI32": return Intrinsic._MM_MASK_XOR_EPI32;
                case "_MM_MASK_XOR_EPI64": return Intrinsic._MM_MASK_XOR_EPI64;
                case "_MM_MASK_XOR_PD": return Intrinsic._MM_MASK_XOR_PD;
                case "_MM_MASK_XOR_PS": return Intrinsic._MM_MASK_XOR_PS;
                case "_MM_MASK2_PERMUTEX2VAR_EPI16": return Intrinsic._MM_MASK2_PERMUTEX2VAR_EPI16;
                case "_MM_MASK2_PERMUTEX2VAR_EPI32": return Intrinsic._MM_MASK2_PERMUTEX2VAR_EPI32;
                case "_MM_MASK2_PERMUTEX2VAR_EPI64": return Intrinsic._MM_MASK2_PERMUTEX2VAR_EPI64;
                case "_MM_MASK2_PERMUTEX2VAR_EPI8": return Intrinsic._MM_MASK2_PERMUTEX2VAR_EPI8;
                case "_MM_MASK2_PERMUTEX2VAR_PD": return Intrinsic._MM_MASK2_PERMUTEX2VAR_PD;
                case "_MM_MASK2_PERMUTEX2VAR_PS": return Intrinsic._MM_MASK2_PERMUTEX2VAR_PS;
                case "_MM_MASK3_FMADD_PD": return Intrinsic._MM_MASK3_FMADD_PD;
                case "_MM_MASK3_FMADD_PS": return Intrinsic._MM_MASK3_FMADD_PS;
                case "_MM_MASK3_FMADD_ROUND_SD": return Intrinsic._MM_MASK3_FMADD_ROUND_SD;
                case "_MM_MASK3_FMADD_ROUND_SS": return Intrinsic._MM_MASK3_FMADD_ROUND_SS;
                case "_MM_MASK3_FMADD_SD": return Intrinsic._MM_MASK3_FMADD_SD;
                case "_MM_MASK3_FMADD_SS": return Intrinsic._MM_MASK3_FMADD_SS;
                case "_MM_MASK3_FMADDSUB_PD": return Intrinsic._MM_MASK3_FMADDSUB_PD;
                case "_MM_MASK3_FMADDSUB_PS": return Intrinsic._MM_MASK3_FMADDSUB_PS;
                case "_MM_MASK3_FMSUB_PD": return Intrinsic._MM_MASK3_FMSUB_PD;
                case "_MM_MASK3_FMSUB_PS": return Intrinsic._MM_MASK3_FMSUB_PS;
                case "_MM_MASK3_FMSUB_ROUND_SD": return Intrinsic._MM_MASK3_FMSUB_ROUND_SD;
                case "_MM_MASK3_FMSUB_ROUND_SS": return Intrinsic._MM_MASK3_FMSUB_ROUND_SS;
                case "_MM_MASK3_FMSUB_SD": return Intrinsic._MM_MASK3_FMSUB_SD;
                case "_MM_MASK3_FMSUB_SS": return Intrinsic._MM_MASK3_FMSUB_SS;
                case "_MM_MASK3_FMSUBADD_PD": return Intrinsic._MM_MASK3_FMSUBADD_PD;
                case "_MM_MASK3_FMSUBADD_PS": return Intrinsic._MM_MASK3_FMSUBADD_PS;
                case "_MM_MASK3_FNMADD_PD": return Intrinsic._MM_MASK3_FNMADD_PD;
                case "_MM_MASK3_FNMADD_PS": return Intrinsic._MM_MASK3_FNMADD_PS;
                case "_MM_MASK3_FNMADD_ROUND_SD": return Intrinsic._MM_MASK3_FNMADD_ROUND_SD;
                case "_MM_MASK3_FNMADD_ROUND_SS": return Intrinsic._MM_MASK3_FNMADD_ROUND_SS;
                case "_MM_MASK3_FNMADD_SD": return Intrinsic._MM_MASK3_FNMADD_SD;
                case "_MM_MASK3_FNMADD_SS": return Intrinsic._MM_MASK3_FNMADD_SS;
                case "_MM_MASK3_FNMSUB_PD": return Intrinsic._MM_MASK3_FNMSUB_PD;
                case "_MM_MASK3_FNMSUB_PS": return Intrinsic._MM_MASK3_FNMSUB_PS;
                case "_MM_MASK3_FNMSUB_ROUND_SD": return Intrinsic._MM_MASK3_FNMSUB_ROUND_SD;
                case "_MM_MASK3_FNMSUB_ROUND_SS": return Intrinsic._MM_MASK3_FNMSUB_ROUND_SS;
                case "_MM_MASK3_FNMSUB_SD": return Intrinsic._MM_MASK3_FNMSUB_SD;
                case "_MM_MASK3_FNMSUB_SS": return Intrinsic._MM_MASK3_FNMSUB_SS;
                case "_MM_MASKLOAD_EPI32": return Intrinsic._MM_MASKLOAD_EPI32;
                case "_MM_MASKLOAD_EPI64": return Intrinsic._MM_MASKLOAD_EPI64;
                case "_MM_MASKLOAD_PD": return Intrinsic._MM_MASKLOAD_PD;
                case "_MM_MASKLOAD_PS": return Intrinsic._MM_MASKLOAD_PS;
                case "_MM_MASKMOVE_SI64": return Intrinsic._MM_MASKMOVE_SI64;
                case "_MM_MASKMOVEU_SI128": return Intrinsic._MM_MASKMOVEU_SI128;
                case "_MM_MASKSTORE_EPI32": return Intrinsic._MM_MASKSTORE_EPI32;
                case "_MM_MASKSTORE_EPI64": return Intrinsic._MM_MASKSTORE_EPI64;
                case "_MM_MASKSTORE_PD": return Intrinsic._MM_MASKSTORE_PD;
                case "_MM_MASKSTORE_PS": return Intrinsic._MM_MASKSTORE_PS;
                case "_MM_MASKZ_ABS_EPI16": return Intrinsic._MM_MASKZ_ABS_EPI16;
                case "_MM_MASKZ_ABS_EPI32": return Intrinsic._MM_MASKZ_ABS_EPI32;
                case "_MM_MASKZ_ABS_EPI64": return Intrinsic._MM_MASKZ_ABS_EPI64;
                case "_MM_MASKZ_ABS_EPI8": return Intrinsic._MM_MASKZ_ABS_EPI8;
                case "_MM_MASKZ_ADD_EPI16": return Intrinsic._MM_MASKZ_ADD_EPI16;
                case "_MM_MASKZ_ADD_EPI32": return Intrinsic._MM_MASKZ_ADD_EPI32;
                case "_MM_MASKZ_ADD_EPI64": return Intrinsic._MM_MASKZ_ADD_EPI64;
                case "_MM_MASKZ_ADD_EPI8": return Intrinsic._MM_MASKZ_ADD_EPI8;
                case "_MM_MASKZ_ADD_PD": return Intrinsic._MM_MASKZ_ADD_PD;
                case "_MM_MASKZ_ADD_PS": return Intrinsic._MM_MASKZ_ADD_PS;
                case "_MM_MASKZ_ADD_ROUND_SD": return Intrinsic._MM_MASKZ_ADD_ROUND_SD;
                case "_MM_MASKZ_ADD_ROUND_SS": return Intrinsic._MM_MASKZ_ADD_ROUND_SS;
                case "_MM_MASKZ_ADD_SD": return Intrinsic._MM_MASKZ_ADD_SD;
                case "_MM_MASKZ_ADD_SS": return Intrinsic._MM_MASKZ_ADD_SS;
                case "_MM_MASKZ_ADDS_EPI16": return Intrinsic._MM_MASKZ_ADDS_EPI16;
                case "_MM_MASKZ_ADDS_EPI8": return Intrinsic._MM_MASKZ_ADDS_EPI8;
                case "_MM_MASKZ_ADDS_EPU16": return Intrinsic._MM_MASKZ_ADDS_EPU16;
                case "_MM_MASKZ_ADDS_EPU8": return Intrinsic._MM_MASKZ_ADDS_EPU8;
                case "_MM_MASKZ_ALIGNR_EPI32": return Intrinsic._MM_MASKZ_ALIGNR_EPI32;
                case "_MM_MASKZ_ALIGNR_EPI64": return Intrinsic._MM_MASKZ_ALIGNR_EPI64;
                case "_MM_MASKZ_ALIGNR_EPI8": return Intrinsic._MM_MASKZ_ALIGNR_EPI8;
                case "_MM_MASKZ_AND_EPI32": return Intrinsic._MM_MASKZ_AND_EPI32;
                case "_MM_MASKZ_AND_EPI64": return Intrinsic._MM_MASKZ_AND_EPI64;
                case "_MM_MASKZ_AND_PD": return Intrinsic._MM_MASKZ_AND_PD;
                case "_MM_MASKZ_AND_PS": return Intrinsic._MM_MASKZ_AND_PS;
                case "_MM_MASKZ_ANDNOT_EPI32": return Intrinsic._MM_MASKZ_ANDNOT_EPI32;
                case "_MM_MASKZ_ANDNOT_EPI64": return Intrinsic._MM_MASKZ_ANDNOT_EPI64;
                case "_MM_MASKZ_ANDNOT_PD": return Intrinsic._MM_MASKZ_ANDNOT_PD;
                case "_MM_MASKZ_ANDNOT_PS": return Intrinsic._MM_MASKZ_ANDNOT_PS;
                case "_MM_MASKZ_AVG_EPU16": return Intrinsic._MM_MASKZ_AVG_EPU16;
                case "_MM_MASKZ_AVG_EPU8": return Intrinsic._MM_MASKZ_AVG_EPU8;
                case "_MM_MASKZ_BROADCAST_I32X2": return Intrinsic._MM_MASKZ_BROADCAST_I32X2;
                case "_MM_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM_MASKZ_BROADCASTB_EPI8;
                case "_MM_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM_MASKZ_BROADCASTD_EPI32;
                case "_MM_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM_MASKZ_BROADCASTQ_EPI64;
                case "_MM_MASKZ_BROADCASTSS_PS": return Intrinsic._MM_MASKZ_BROADCASTSS_PS;
                case "_MM_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM_MASKZ_BROADCASTW_EPI16;
                case "_MM_MASKZ_COMPRESS_EPI32": return Intrinsic._MM_MASKZ_COMPRESS_EPI32;
                case "_MM_MASKZ_COMPRESS_EPI64": return Intrinsic._MM_MASKZ_COMPRESS_EPI64;
                case "_MM_MASKZ_COMPRESS_PD": return Intrinsic._MM_MASKZ_COMPRESS_PD;
                case "_MM_MASKZ_COMPRESS_PS": return Intrinsic._MM_MASKZ_COMPRESS_PS;
                case "_MM_MASKZ_CONFLICT_EPI32": return Intrinsic._MM_MASKZ_CONFLICT_EPI32;
                case "_MM_MASKZ_CONFLICT_EPI64": return Intrinsic._MM_MASKZ_CONFLICT_EPI64;
                case "_MM_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM_MASKZ_CVT_ROUNDPS_PH;
                case "_MM_MASKZ_CVT_ROUNDSD_SS": return Intrinsic._MM_MASKZ_CVT_ROUNDSD_SS;
                case "_MM_MASKZ_CVT_ROUNDSS_SD": return Intrinsic._MM_MASKZ_CVT_ROUNDSS_SD;
                case "_MM_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM_MASKZ_CVTEPI16_EPI32;
                case "_MM_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM_MASKZ_CVTEPI16_EPI64;
                case "_MM_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTEPI16_EPI8;
                case "_MM_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTEPI32_EPI16;
                case "_MM_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM_MASKZ_CVTEPI32_EPI64;
                case "_MM_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTEPI32_EPI8;
                case "_MM_MASKZ_CVTEPI32_PD": return Intrinsic._MM_MASKZ_CVTEPI32_PD;
                case "_MM_MASKZ_CVTEPI32_PS": return Intrinsic._MM_MASKZ_CVTEPI32_PS;
                case "_MM_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTEPI64_EPI16;
                case "_MM_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTEPI64_EPI32;
                case "_MM_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTEPI64_EPI8;
                case "_MM_MASKZ_CVTEPI64_PD": return Intrinsic._MM_MASKZ_CVTEPI64_PD;
                case "_MM_MASKZ_CVTEPI64_PS": return Intrinsic._MM_MASKZ_CVTEPI64_PS;
                case "_MM_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM_MASKZ_CVTEPI8_EPI16;
                case "_MM_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM_MASKZ_CVTEPI8_EPI32;
                case "_MM_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM_MASKZ_CVTEPI8_EPI64;
                case "_MM_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM_MASKZ_CVTEPU16_EPI32;
                case "_MM_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM_MASKZ_CVTEPU16_EPI64;
                case "_MM_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM_MASKZ_CVTEPU32_EPI64;
                case "_MM_MASKZ_CVTEPU32_PD": return Intrinsic._MM_MASKZ_CVTEPU32_PD;
                case "_MM_MASKZ_CVTEPU64_PD": return Intrinsic._MM_MASKZ_CVTEPU64_PD;
                case "_MM_MASKZ_CVTEPU64_PS": return Intrinsic._MM_MASKZ_CVTEPU64_PS;
                case "_MM_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM_MASKZ_CVTEPU8_EPI16;
                case "_MM_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM_MASKZ_CVTEPU8_EPI32;
                case "_MM_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM_MASKZ_CVTEPU8_EPI64;
                case "_MM_MASKZ_CVTPD_EPI32": return Intrinsic._MM_MASKZ_CVTPD_EPI32;
                case "_MM_MASKZ_CVTPD_EPI64": return Intrinsic._MM_MASKZ_CVTPD_EPI64;
                case "_MM_MASKZ_CVTPD_EPU32": return Intrinsic._MM_MASKZ_CVTPD_EPU32;
                case "_MM_MASKZ_CVTPD_EPU64": return Intrinsic._MM_MASKZ_CVTPD_EPU64;
                case "_MM_MASKZ_CVTPD_PS": return Intrinsic._MM_MASKZ_CVTPD_PS;
                case "_MM_MASKZ_CVTPH_PS": return Intrinsic._MM_MASKZ_CVTPH_PS;
                case "_MM_MASKZ_CVTPS_EPI32": return Intrinsic._MM_MASKZ_CVTPS_EPI32;
                case "_MM_MASKZ_CVTPS_EPI64": return Intrinsic._MM_MASKZ_CVTPS_EPI64;
                case "_MM_MASKZ_CVTPS_EPU32": return Intrinsic._MM_MASKZ_CVTPS_EPU32;
                case "_MM_MASKZ_CVTPS_EPU64": return Intrinsic._MM_MASKZ_CVTPS_EPU64;
                case "_MM_MASKZ_CVTPS_PH": return Intrinsic._MM_MASKZ_CVTPS_PH;
                case "_MM_MASKZ_CVTSD_SS": return Intrinsic._MM_MASKZ_CVTSD_SS;
                case "_MM_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI16_EPI8;
                case "_MM_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTSEPI32_EPI16;
                case "_MM_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI32_EPI8;
                case "_MM_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI16;
                case "_MM_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI32;
                case "_MM_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTSEPI64_EPI8;
                case "_MM_MASKZ_CVTSS_SD": return Intrinsic._MM_MASKZ_CVTSS_SD;
                case "_MM_MASKZ_CVTTPD_EPI32": return Intrinsic._MM_MASKZ_CVTTPD_EPI32;
                case "_MM_MASKZ_CVTTPD_EPI64": return Intrinsic._MM_MASKZ_CVTTPD_EPI64;
                case "_MM_MASKZ_CVTTPD_EPU32": return Intrinsic._MM_MASKZ_CVTTPD_EPU32;
                case "_MM_MASKZ_CVTTPD_EPU64": return Intrinsic._MM_MASKZ_CVTTPD_EPU64;
                case "_MM_MASKZ_CVTTPS_EPI32": return Intrinsic._MM_MASKZ_CVTTPS_EPI32;
                case "_MM_MASKZ_CVTTPS_EPI64": return Intrinsic._MM_MASKZ_CVTTPS_EPI64;
                case "_MM_MASKZ_CVTTPS_EPU32": return Intrinsic._MM_MASKZ_CVTTPS_EPU32;
                case "_MM_MASKZ_CVTTPS_EPU64": return Intrinsic._MM_MASKZ_CVTTPS_EPU64;
                case "_MM_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI16_EPI8;
                case "_MM_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM_MASKZ_CVTUSEPI32_EPI16;
                case "_MM_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI32_EPI8;
                case "_MM_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI16;
                case "_MM_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI32;
                case "_MM_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM_MASKZ_CVTUSEPI64_EPI8;
                case "_MM_MASKZ_DBSAD_EPU8": return Intrinsic._MM_MASKZ_DBSAD_EPU8;
                case "_MM_MASKZ_DIV_PD": return Intrinsic._MM_MASKZ_DIV_PD;
                case "_MM_MASKZ_DIV_PS": return Intrinsic._MM_MASKZ_DIV_PS;
                case "_MM_MASKZ_DIV_ROUND_SD": return Intrinsic._MM_MASKZ_DIV_ROUND_SD;
                case "_MM_MASKZ_DIV_ROUND_SS": return Intrinsic._MM_MASKZ_DIV_ROUND_SS;
                case "_MM_MASKZ_DIV_SD": return Intrinsic._MM_MASKZ_DIV_SD;
                case "_MM_MASKZ_DIV_SS": return Intrinsic._MM_MASKZ_DIV_SS;
                case "_MM_MASKZ_EXPAND_EPI32": return Intrinsic._MM_MASKZ_EXPAND_EPI32;
                case "_MM_MASKZ_EXPAND_EPI64": return Intrinsic._MM_MASKZ_EXPAND_EPI64;
                case "_MM_MASKZ_EXPAND_PD": return Intrinsic._MM_MASKZ_EXPAND_PD;
                case "_MM_MASKZ_EXPAND_PS": return Intrinsic._MM_MASKZ_EXPAND_PS;
                case "_MM_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM_MASKZ_EXPANDLOADU_EPI32;
                case "_MM_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM_MASKZ_EXPANDLOADU_EPI64;
                case "_MM_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM_MASKZ_EXPANDLOADU_PD;
                case "_MM_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM_MASKZ_EXPANDLOADU_PS;
                case "_MM_MASKZ_FIXUPIMM_PD": return Intrinsic._MM_MASKZ_FIXUPIMM_PD;
                case "_MM_MASKZ_FIXUPIMM_PS": return Intrinsic._MM_MASKZ_FIXUPIMM_PS;
                case "_MM_MASKZ_FIXUPIMM_ROUND_SD": return Intrinsic._MM_MASKZ_FIXUPIMM_ROUND_SD;
                case "_MM_MASKZ_FIXUPIMM_ROUND_SS": return Intrinsic._MM_MASKZ_FIXUPIMM_ROUND_SS;
                case "_MM_MASKZ_FIXUPIMM_SD": return Intrinsic._MM_MASKZ_FIXUPIMM_SD;
                case "_MM_MASKZ_FIXUPIMM_SS": return Intrinsic._MM_MASKZ_FIXUPIMM_SS;
                case "_MM_MASKZ_FMADD_PD": return Intrinsic._MM_MASKZ_FMADD_PD;
                case "_MM_MASKZ_FMADD_PS": return Intrinsic._MM_MASKZ_FMADD_PS;
                case "_MM_MASKZ_FMADD_ROUND_SD": return Intrinsic._MM_MASKZ_FMADD_ROUND_SD;
                case "_MM_MASKZ_FMADD_ROUND_SS": return Intrinsic._MM_MASKZ_FMADD_ROUND_SS;
                case "_MM_MASKZ_FMADD_SD": return Intrinsic._MM_MASKZ_FMADD_SD;
                case "_MM_MASKZ_FMADD_SS": return Intrinsic._MM_MASKZ_FMADD_SS;
                case "_MM_MASKZ_FMADDSUB_PD": return Intrinsic._MM_MASKZ_FMADDSUB_PD;
                case "_MM_MASKZ_FMADDSUB_PS": return Intrinsic._MM_MASKZ_FMADDSUB_PS;
                case "_MM_MASKZ_FMSUB_PD": return Intrinsic._MM_MASKZ_FMSUB_PD;
                case "_MM_MASKZ_FMSUB_PS": return Intrinsic._MM_MASKZ_FMSUB_PS;
                case "_MM_MASKZ_FMSUB_ROUND_SD": return Intrinsic._MM_MASKZ_FMSUB_ROUND_SD;
                case "_MM_MASKZ_FMSUB_ROUND_SS": return Intrinsic._MM_MASKZ_FMSUB_ROUND_SS;
                case "_MM_MASKZ_FMSUB_SD": return Intrinsic._MM_MASKZ_FMSUB_SD;
                case "_MM_MASKZ_FMSUB_SS": return Intrinsic._MM_MASKZ_FMSUB_SS;
                case "_MM_MASKZ_FMSUBADD_PD": return Intrinsic._MM_MASKZ_FMSUBADD_PD;
                case "_MM_MASKZ_FMSUBADD_PS": return Intrinsic._MM_MASKZ_FMSUBADD_PS;
                case "_MM_MASKZ_FNMADD_PD": return Intrinsic._MM_MASKZ_FNMADD_PD;
                case "_MM_MASKZ_FNMADD_PS": return Intrinsic._MM_MASKZ_FNMADD_PS;
                case "_MM_MASKZ_FNMADD_ROUND_SD": return Intrinsic._MM_MASKZ_FNMADD_ROUND_SD;
                case "_MM_MASKZ_FNMADD_ROUND_SS": return Intrinsic._MM_MASKZ_FNMADD_ROUND_SS;
                case "_MM_MASKZ_FNMADD_SD": return Intrinsic._MM_MASKZ_FNMADD_SD;
                case "_MM_MASKZ_FNMADD_SS": return Intrinsic._MM_MASKZ_FNMADD_SS;
                case "_MM_MASKZ_FNMSUB_PD": return Intrinsic._MM_MASKZ_FNMSUB_PD;
                case "_MM_MASKZ_FNMSUB_PS": return Intrinsic._MM_MASKZ_FNMSUB_PS;
                case "_MM_MASKZ_FNMSUB_ROUND_SD": return Intrinsic._MM_MASKZ_FNMSUB_ROUND_SD;
                case "_MM_MASKZ_FNMSUB_ROUND_SS": return Intrinsic._MM_MASKZ_FNMSUB_ROUND_SS;
                case "_MM_MASKZ_FNMSUB_SD": return Intrinsic._MM_MASKZ_FNMSUB_SD;
                case "_MM_MASKZ_FNMSUB_SS": return Intrinsic._MM_MASKZ_FNMSUB_SS;
                case "_MM_MASKZ_GETEXP_PD": return Intrinsic._MM_MASKZ_GETEXP_PD;
                case "_MM_MASKZ_GETEXP_PS": return Intrinsic._MM_MASKZ_GETEXP_PS;
                case "_MM_MASKZ_GETEXP_ROUND_SD": return Intrinsic._MM_MASKZ_GETEXP_ROUND_SD;
                case "_MM_MASKZ_GETEXP_ROUND_SS": return Intrinsic._MM_MASKZ_GETEXP_ROUND_SS;
                case "_MM_MASKZ_GETEXP_SD": return Intrinsic._MM_MASKZ_GETEXP_SD;
                case "_MM_MASKZ_GETEXP_SS": return Intrinsic._MM_MASKZ_GETEXP_SS;
                case "_MM_MASKZ_GETMANT_PD": return Intrinsic._MM_MASKZ_GETMANT_PD;
                case "_MM_MASKZ_GETMANT_PS": return Intrinsic._MM_MASKZ_GETMANT_PS;
                case "_MM_MASKZ_GETMANT_ROUND_SD": return Intrinsic._MM_MASKZ_GETMANT_ROUND_SD;
                case "_MM_MASKZ_GETMANT_ROUND_SS": return Intrinsic._MM_MASKZ_GETMANT_ROUND_SS;
                case "_MM_MASKZ_GETMANT_SD": return Intrinsic._MM_MASKZ_GETMANT_SD;
                case "_MM_MASKZ_GETMANT_SS": return Intrinsic._MM_MASKZ_GETMANT_SS;
                case "_MM_MASKZ_LOAD_EPI32": return Intrinsic._MM_MASKZ_LOAD_EPI32;
                case "_MM_MASKZ_LOAD_EPI64": return Intrinsic._MM_MASKZ_LOAD_EPI64;
                case "_MM_MASKZ_LOAD_PD": return Intrinsic._MM_MASKZ_LOAD_PD;
                case "_MM_MASKZ_LOAD_PS": return Intrinsic._MM_MASKZ_LOAD_PS;
                case "_MM_MASKZ_LOAD_SD": return Intrinsic._MM_MASKZ_LOAD_SD;
                case "_MM_MASKZ_LOAD_SS": return Intrinsic._MM_MASKZ_LOAD_SS;
                case "_MM_MASKZ_LOADU_EPI16": return Intrinsic._MM_MASKZ_LOADU_EPI16;
                case "_MM_MASKZ_LOADU_EPI32": return Intrinsic._MM_MASKZ_LOADU_EPI32;
                case "_MM_MASKZ_LOADU_EPI64": return Intrinsic._MM_MASKZ_LOADU_EPI64;
                case "_MM_MASKZ_LOADU_EPI8": return Intrinsic._MM_MASKZ_LOADU_EPI8;
                case "_MM_MASKZ_LOADU_PD": return Intrinsic._MM_MASKZ_LOADU_PD;
                case "_MM_MASKZ_LOADU_PS": return Intrinsic._MM_MASKZ_LOADU_PS;
                case "_MM_MASKZ_LZCNT_EPI32": return Intrinsic._MM_MASKZ_LZCNT_EPI32;
                case "_MM_MASKZ_LZCNT_EPI64": return Intrinsic._MM_MASKZ_LZCNT_EPI64;
                case "_MM_MASKZ_MADD_EPI16": return Intrinsic._MM_MASKZ_MADD_EPI16;
                case "_MM_MASKZ_MADD52HI_EPU64": return Intrinsic._MM_MASKZ_MADD52HI_EPU64;
                case "_MM_MASKZ_MADD52LO_EPU64": return Intrinsic._MM_MASKZ_MADD52LO_EPU64;
                case "_MM_MASKZ_MADDUBS_EPI16": return Intrinsic._MM_MASKZ_MADDUBS_EPI16;
                case "_MM_MASKZ_MAX_EPI16": return Intrinsic._MM_MASKZ_MAX_EPI16;
                case "_MM_MASKZ_MAX_EPI32": return Intrinsic._MM_MASKZ_MAX_EPI32;
                case "_MM_MASKZ_MAX_EPI64": return Intrinsic._MM_MASKZ_MAX_EPI64;
                case "_MM_MASKZ_MAX_EPI8": return Intrinsic._MM_MASKZ_MAX_EPI8;
                case "_MM_MASKZ_MAX_EPU16": return Intrinsic._MM_MASKZ_MAX_EPU16;
                case "_MM_MASKZ_MAX_EPU32": return Intrinsic._MM_MASKZ_MAX_EPU32;
                case "_MM_MASKZ_MAX_EPU64": return Intrinsic._MM_MASKZ_MAX_EPU64;
                case "_MM_MASKZ_MAX_EPU8": return Intrinsic._MM_MASKZ_MAX_EPU8;
                case "_MM_MASKZ_MAX_PD": return Intrinsic._MM_MASKZ_MAX_PD;
                case "_MM_MASKZ_MAX_PS": return Intrinsic._MM_MASKZ_MAX_PS;
                case "_MM_MASKZ_MAX_ROUND_SD": return Intrinsic._MM_MASKZ_MAX_ROUND_SD;
                case "_MM_MASKZ_MAX_ROUND_SS": return Intrinsic._MM_MASKZ_MAX_ROUND_SS;
                case "_MM_MASKZ_MAX_SD": return Intrinsic._MM_MASKZ_MAX_SD;
                case "_MM_MASKZ_MAX_SS": return Intrinsic._MM_MASKZ_MAX_SS;
                case "_MM_MASKZ_MIN_EPI16": return Intrinsic._MM_MASKZ_MIN_EPI16;
                case "_MM_MASKZ_MIN_EPI32": return Intrinsic._MM_MASKZ_MIN_EPI32;
                case "_MM_MASKZ_MIN_EPI64": return Intrinsic._MM_MASKZ_MIN_EPI64;
                case "_MM_MASKZ_MIN_EPI8": return Intrinsic._MM_MASKZ_MIN_EPI8;
                case "_MM_MASKZ_MIN_EPU16": return Intrinsic._MM_MASKZ_MIN_EPU16;
                case "_MM_MASKZ_MIN_EPU32": return Intrinsic._MM_MASKZ_MIN_EPU32;
                case "_MM_MASKZ_MIN_EPU64": return Intrinsic._MM_MASKZ_MIN_EPU64;
                case "_MM_MASKZ_MIN_EPU8": return Intrinsic._MM_MASKZ_MIN_EPU8;
                case "_MM_MASKZ_MIN_PD": return Intrinsic._MM_MASKZ_MIN_PD;
                case "_MM_MASKZ_MIN_PS": return Intrinsic._MM_MASKZ_MIN_PS;
                case "_MM_MASKZ_MIN_ROUND_SD": return Intrinsic._MM_MASKZ_MIN_ROUND_SD;
                case "_MM_MASKZ_MIN_ROUND_SS": return Intrinsic._MM_MASKZ_MIN_ROUND_SS;
                case "_MM_MASKZ_MIN_SD": return Intrinsic._MM_MASKZ_MIN_SD;
                case "_MM_MASKZ_MIN_SS": return Intrinsic._MM_MASKZ_MIN_SS;
                case "_MM_MASKZ_MOV_EPI16": return Intrinsic._MM_MASKZ_MOV_EPI16;
                case "_MM_MASKZ_MOV_EPI32": return Intrinsic._MM_MASKZ_MOV_EPI32;
                case "_MM_MASKZ_MOV_EPI64": return Intrinsic._MM_MASKZ_MOV_EPI64;
                case "_MM_MASKZ_MOV_EPI8": return Intrinsic._MM_MASKZ_MOV_EPI8;
                case "_MM_MASKZ_MOV_PD": return Intrinsic._MM_MASKZ_MOV_PD;
                case "_MM_MASKZ_MOV_PS": return Intrinsic._MM_MASKZ_MOV_PS;
                case "_MM_MASKZ_MOVE_SD": return Intrinsic._MM_MASKZ_MOVE_SD;
                case "_MM_MASKZ_MOVE_SS": return Intrinsic._MM_MASKZ_MOVE_SS;
                case "_MM_MASKZ_MOVEDUP_PD": return Intrinsic._MM_MASKZ_MOVEDUP_PD;
                case "_MM_MASKZ_MOVEHDUP_PS": return Intrinsic._MM_MASKZ_MOVEHDUP_PS;
                case "_MM_MASKZ_MOVELDUP_PS": return Intrinsic._MM_MASKZ_MOVELDUP_PS;
                case "_MM_MASKZ_MUL_EPI32": return Intrinsic._MM_MASKZ_MUL_EPI32;
                case "_MM_MASKZ_MUL_EPU32": return Intrinsic._MM_MASKZ_MUL_EPU32;
                case "_MM_MASKZ_MUL_PD": return Intrinsic._MM_MASKZ_MUL_PD;
                case "_MM_MASKZ_MUL_PS": return Intrinsic._MM_MASKZ_MUL_PS;
                case "_MM_MASKZ_MUL_ROUND_SD": return Intrinsic._MM_MASKZ_MUL_ROUND_SD;
                case "_MM_MASKZ_MUL_ROUND_SS": return Intrinsic._MM_MASKZ_MUL_ROUND_SS;
                case "_MM_MASKZ_MUL_SD": return Intrinsic._MM_MASKZ_MUL_SD;
                case "_MM_MASKZ_MUL_SS": return Intrinsic._MM_MASKZ_MUL_SS;
                case "_MM_MASKZ_MULHI_EPI16": return Intrinsic._MM_MASKZ_MULHI_EPI16;
                case "_MM_MASKZ_MULHI_EPU16": return Intrinsic._MM_MASKZ_MULHI_EPU16;
                case "_MM_MASKZ_MULHRS_EPI16": return Intrinsic._MM_MASKZ_MULHRS_EPI16;
                case "_MM_MASKZ_MULLO_EPI16": return Intrinsic._MM_MASKZ_MULLO_EPI16;
                case "_MM_MASKZ_MULLO_EPI32": return Intrinsic._MM_MASKZ_MULLO_EPI32;
                case "_MM_MASKZ_MULLO_EPI64": return Intrinsic._MM_MASKZ_MULLO_EPI64;
                case "_MM_MASKZ_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM_MASKZ_MULTISHIFT_EPI64_EPI8;
                case "_MM_MASKZ_OR_EPI32": return Intrinsic._MM_MASKZ_OR_EPI32;
                case "_MM_MASKZ_OR_EPI64": return Intrinsic._MM_MASKZ_OR_EPI64;
                case "_MM_MASKZ_OR_PD": return Intrinsic._MM_MASKZ_OR_PD;
                case "_MM_MASKZ_OR_PS": return Intrinsic._MM_MASKZ_OR_PS;
                case "_MM_MASKZ_PACKS_EPI16": return Intrinsic._MM_MASKZ_PACKS_EPI16;
                case "_MM_MASKZ_PACKS_EPI32": return Intrinsic._MM_MASKZ_PACKS_EPI32;
                case "_MM_MASKZ_PACKUS_EPI16": return Intrinsic._MM_MASKZ_PACKUS_EPI16;
                case "_MM_MASKZ_PACKUS_EPI32": return Intrinsic._MM_MASKZ_PACKUS_EPI32;
                case "_MM_MASKZ_PERMUTE_PD": return Intrinsic._MM_MASKZ_PERMUTE_PD;
                case "_MM_MASKZ_PERMUTE_PS": return Intrinsic._MM_MASKZ_PERMUTE_PS;
                case "_MM_MASKZ_PERMUTEVAR_PD": return Intrinsic._MM_MASKZ_PERMUTEVAR_PD;
                case "_MM_MASKZ_PERMUTEVAR_PS": return Intrinsic._MM_MASKZ_PERMUTEVAR_PS;
                case "_MM_MASKZ_PERMUTEX2VAR_EPI16": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_EPI16;
                case "_MM_MASKZ_PERMUTEX2VAR_EPI32": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_EPI32;
                case "_MM_MASKZ_PERMUTEX2VAR_EPI64": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_EPI64;
                case "_MM_MASKZ_PERMUTEX2VAR_EPI8": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_EPI8;
                case "_MM_MASKZ_PERMUTEX2VAR_PD": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_PD;
                case "_MM_MASKZ_PERMUTEX2VAR_PS": return Intrinsic._MM_MASKZ_PERMUTEX2VAR_PS;
                case "_MM_MASKZ_PERMUTEXVAR_EPI16": return Intrinsic._MM_MASKZ_PERMUTEXVAR_EPI16;
                case "_MM_MASKZ_PERMUTEXVAR_EPI8": return Intrinsic._MM_MASKZ_PERMUTEXVAR_EPI8;
                case "_MM_MASKZ_RANGE_PD": return Intrinsic._MM_MASKZ_RANGE_PD;
                case "_MM_MASKZ_RANGE_PS": return Intrinsic._MM_MASKZ_RANGE_PS;
                case "_MM_MASKZ_RANGE_ROUND_SD": return Intrinsic._MM_MASKZ_RANGE_ROUND_SD;
                case "_MM_MASKZ_RANGE_ROUND_SS": return Intrinsic._MM_MASKZ_RANGE_ROUND_SS;
                case "_MM_MASKZ_RANGE_SD": return Intrinsic._MM_MASKZ_RANGE_SD;
                case "_MM_MASKZ_RANGE_SS": return Intrinsic._MM_MASKZ_RANGE_SS;
                case "_MM_MASKZ_RCP14_PD": return Intrinsic._MM_MASKZ_RCP14_PD;
                case "_MM_MASKZ_RCP14_PS": return Intrinsic._MM_MASKZ_RCP14_PS;
                case "_MM_MASKZ_RCP14_SD": return Intrinsic._MM_MASKZ_RCP14_SD;
                case "_MM_MASKZ_RCP14_SS": return Intrinsic._MM_MASKZ_RCP14_SS;
                case "_MM_MASKZ_RCP28_ROUND_SD": return Intrinsic._MM_MASKZ_RCP28_ROUND_SD;
                case "_MM_MASKZ_RCP28_ROUND_SS": return Intrinsic._MM_MASKZ_RCP28_ROUND_SS;
                case "_MM_MASKZ_RCP28_SD": return Intrinsic._MM_MASKZ_RCP28_SD;
                case "_MM_MASKZ_RCP28_SS": return Intrinsic._MM_MASKZ_RCP28_SS;
                case "_MM_MASKZ_REDUCE_PD": return Intrinsic._MM_MASKZ_REDUCE_PD;
                case "_MM_MASKZ_REDUCE_PS": return Intrinsic._MM_MASKZ_REDUCE_PS;
                case "_MM_MASKZ_REDUCE_ROUND_SD": return Intrinsic._MM_MASKZ_REDUCE_ROUND_SD;
                case "_MM_MASKZ_REDUCE_ROUND_SS": return Intrinsic._MM_MASKZ_REDUCE_ROUND_SS;
                case "_MM_MASKZ_REDUCE_SD": return Intrinsic._MM_MASKZ_REDUCE_SD;
                case "_MM_MASKZ_REDUCE_SS": return Intrinsic._MM_MASKZ_REDUCE_SS;
                case "_MM_MASKZ_ROL_EPI32": return Intrinsic._MM_MASKZ_ROL_EPI32;
                case "_MM_MASKZ_ROL_EPI64": return Intrinsic._MM_MASKZ_ROL_EPI64;
                case "_MM_MASKZ_ROLV_EPI32": return Intrinsic._MM_MASKZ_ROLV_EPI32;
                case "_MM_MASKZ_ROLV_EPI64": return Intrinsic._MM_MASKZ_ROLV_EPI64;
                case "_MM_MASKZ_ROR_EPI32": return Intrinsic._MM_MASKZ_ROR_EPI32;
                case "_MM_MASKZ_ROR_EPI64": return Intrinsic._MM_MASKZ_ROR_EPI64;
                case "_MM_MASKZ_RORV_EPI32": return Intrinsic._MM_MASKZ_RORV_EPI32;
                case "_MM_MASKZ_RORV_EPI64": return Intrinsic._MM_MASKZ_RORV_EPI64;
                case "_MM_MASKZ_ROUNDSCALE_PD": return Intrinsic._MM_MASKZ_ROUNDSCALE_PD;
                case "_MM_MASKZ_ROUNDSCALE_PS": return Intrinsic._MM_MASKZ_ROUNDSCALE_PS;
                case "_MM_MASKZ_ROUNDSCALE_ROUND_SD": return Intrinsic._MM_MASKZ_ROUNDSCALE_ROUND_SD;
                case "_MM_MASKZ_ROUNDSCALE_ROUND_SS": return Intrinsic._MM_MASKZ_ROUNDSCALE_ROUND_SS;
                case "_MM_MASKZ_ROUNDSCALE_SD": return Intrinsic._MM_MASKZ_ROUNDSCALE_SD;
                case "_MM_MASKZ_ROUNDSCALE_SS": return Intrinsic._MM_MASKZ_ROUNDSCALE_SS;
                case "_MM_MASKZ_RSQRT14_PD": return Intrinsic._MM_MASKZ_RSQRT14_PD;
                case "_MM_MASKZ_RSQRT14_PS": return Intrinsic._MM_MASKZ_RSQRT14_PS;
                case "_MM_MASKZ_RSQRT14_SD": return Intrinsic._MM_MASKZ_RSQRT14_SD;
                case "_MM_MASKZ_RSQRT14_SS": return Intrinsic._MM_MASKZ_RSQRT14_SS;
                case "_MM_MASKZ_RSQRT28_ROUND_SD": return Intrinsic._MM_MASKZ_RSQRT28_ROUND_SD;
                case "_MM_MASKZ_RSQRT28_ROUND_SS": return Intrinsic._MM_MASKZ_RSQRT28_ROUND_SS;
                case "_MM_MASKZ_RSQRT28_SD": return Intrinsic._MM_MASKZ_RSQRT28_SD;
                case "_MM_MASKZ_RSQRT28_SS": return Intrinsic._MM_MASKZ_RSQRT28_SS;
                case "_MM_MASKZ_SCALEF_PD": return Intrinsic._MM_MASKZ_SCALEF_PD;
                case "_MM_MASKZ_SCALEF_PS": return Intrinsic._MM_MASKZ_SCALEF_PS;
                case "_MM_MASKZ_SCALEF_ROUND_SD": return Intrinsic._MM_MASKZ_SCALEF_ROUND_SD;
                case "_MM_MASKZ_SCALEF_ROUND_SS": return Intrinsic._MM_MASKZ_SCALEF_ROUND_SS;
                case "_MM_MASKZ_SCALEF_SD": return Intrinsic._MM_MASKZ_SCALEF_SD;
                case "_MM_MASKZ_SCALEF_SS": return Intrinsic._MM_MASKZ_SCALEF_SS;
                case "_MM_MASKZ_SET1_EPI16": return Intrinsic._MM_MASKZ_SET1_EPI16;
                case "_MM_MASKZ_SET1_EPI32": return Intrinsic._MM_MASKZ_SET1_EPI32;
                case "_MM_MASKZ_SET1_EPI64": return Intrinsic._MM_MASKZ_SET1_EPI64;
                case "_MM_MASKZ_SET1_EPI8": return Intrinsic._MM_MASKZ_SET1_EPI8;
                case "_MM_MASKZ_SHUFFLE_EPI32": return Intrinsic._MM_MASKZ_SHUFFLE_EPI32;
                case "_MM_MASKZ_SHUFFLE_EPI8": return Intrinsic._MM_MASKZ_SHUFFLE_EPI8;
                case "_MM_MASKZ_SHUFFLE_PD": return Intrinsic._MM_MASKZ_SHUFFLE_PD;
                case "_MM_MASKZ_SHUFFLE_PS": return Intrinsic._MM_MASKZ_SHUFFLE_PS;
                case "_MM_MASKZ_SHUFFLEHI_EPI16": return Intrinsic._MM_MASKZ_SHUFFLEHI_EPI16;
                case "_MM_MASKZ_SHUFFLELO_EPI16": return Intrinsic._MM_MASKZ_SHUFFLELO_EPI16;
                case "_MM_MASKZ_SLL_EPI16": return Intrinsic._MM_MASKZ_SLL_EPI16;
                case "_MM_MASKZ_SLL_EPI32": return Intrinsic._MM_MASKZ_SLL_EPI32;
                case "_MM_MASKZ_SLL_EPI64": return Intrinsic._MM_MASKZ_SLL_EPI64;
                case "_MM_MASKZ_SLLI_EPI16": return Intrinsic._MM_MASKZ_SLLI_EPI16;
                case "_MM_MASKZ_SLLI_EPI32": return Intrinsic._MM_MASKZ_SLLI_EPI32;
                case "_MM_MASKZ_SLLI_EPI64": return Intrinsic._MM_MASKZ_SLLI_EPI64;
                case "_MM_MASKZ_SLLV_EPI16": return Intrinsic._MM_MASKZ_SLLV_EPI16;
                case "_MM_MASKZ_SLLV_EPI32": return Intrinsic._MM_MASKZ_SLLV_EPI32;
                case "_MM_MASKZ_SLLV_EPI64": return Intrinsic._MM_MASKZ_SLLV_EPI64;
                case "_MM_MASKZ_SQRT_PD": return Intrinsic._MM_MASKZ_SQRT_PD;
                case "_MM_MASKZ_SQRT_PS": return Intrinsic._MM_MASKZ_SQRT_PS;
                case "_MM_MASKZ_SQRT_ROUND_SD": return Intrinsic._MM_MASKZ_SQRT_ROUND_SD;
                case "_MM_MASKZ_SQRT_ROUND_SS": return Intrinsic._MM_MASKZ_SQRT_ROUND_SS;
                case "_MM_MASKZ_SQRT_SD": return Intrinsic._MM_MASKZ_SQRT_SD;
                case "_MM_MASKZ_SQRT_SS": return Intrinsic._MM_MASKZ_SQRT_SS;
                case "_MM_MASKZ_SRA_EPI16": return Intrinsic._MM_MASKZ_SRA_EPI16;
                case "_MM_MASKZ_SRA_EPI32": return Intrinsic._MM_MASKZ_SRA_EPI32;
                case "_MM_MASKZ_SRA_EPI64": return Intrinsic._MM_MASKZ_SRA_EPI64;
                case "_MM_MASKZ_SRAI_EPI16": return Intrinsic._MM_MASKZ_SRAI_EPI16;
                case "_MM_MASKZ_SRAI_EPI32": return Intrinsic._MM_MASKZ_SRAI_EPI32;
                case "_MM_MASKZ_SRAI_EPI64": return Intrinsic._MM_MASKZ_SRAI_EPI64;
                case "_MM_MASKZ_SRAV_EPI16": return Intrinsic._MM_MASKZ_SRAV_EPI16;
                case "_MM_MASKZ_SRAV_EPI32": return Intrinsic._MM_MASKZ_SRAV_EPI32;
                case "_MM_MASKZ_SRAV_EPI64": return Intrinsic._MM_MASKZ_SRAV_EPI64;
                case "_MM_MASKZ_SRL_EPI16": return Intrinsic._MM_MASKZ_SRL_EPI16;
                case "_MM_MASKZ_SRL_EPI32": return Intrinsic._MM_MASKZ_SRL_EPI32;
                case "_MM_MASKZ_SRL_EPI64": return Intrinsic._MM_MASKZ_SRL_EPI64;
                case "_MM_MASKZ_SRLI_EPI16": return Intrinsic._MM_MASKZ_SRLI_EPI16;
                case "_MM_MASKZ_SRLI_EPI32": return Intrinsic._MM_MASKZ_SRLI_EPI32;
                case "_MM_MASKZ_SRLI_EPI64": return Intrinsic._MM_MASKZ_SRLI_EPI64;
                case "_MM_MASKZ_SRLV_EPI16": return Intrinsic._MM_MASKZ_SRLV_EPI16;
                case "_MM_MASKZ_SRLV_EPI32": return Intrinsic._MM_MASKZ_SRLV_EPI32;
                case "_MM_MASKZ_SRLV_EPI64": return Intrinsic._MM_MASKZ_SRLV_EPI64;
                case "_MM_MASKZ_SUB_EPI16": return Intrinsic._MM_MASKZ_SUB_EPI16;
                case "_MM_MASKZ_SUB_EPI32": return Intrinsic._MM_MASKZ_SUB_EPI32;
                case "_MM_MASKZ_SUB_EPI64": return Intrinsic._MM_MASKZ_SUB_EPI64;
                case "_MM_MASKZ_SUB_EPI8": return Intrinsic._MM_MASKZ_SUB_EPI8;
                case "_MM_MASKZ_SUB_PD": return Intrinsic._MM_MASKZ_SUB_PD;
                case "_MM_MASKZ_SUB_PS": return Intrinsic._MM_MASKZ_SUB_PS;
                case "_MM_MASKZ_SUB_ROUND_SD": return Intrinsic._MM_MASKZ_SUB_ROUND_SD;
                case "_MM_MASKZ_SUB_ROUND_SS": return Intrinsic._MM_MASKZ_SUB_ROUND_SS;
                case "_MM_MASKZ_SUB_SD": return Intrinsic._MM_MASKZ_SUB_SD;
                case "_MM_MASKZ_SUB_SS": return Intrinsic._MM_MASKZ_SUB_SS;
                case "_MM_MASKZ_SUBS_EPI16": return Intrinsic._MM_MASKZ_SUBS_EPI16;
                case "_MM_MASKZ_SUBS_EPI8": return Intrinsic._MM_MASKZ_SUBS_EPI8;
                case "_MM_MASKZ_SUBS_EPU16": return Intrinsic._MM_MASKZ_SUBS_EPU16;
                case "_MM_MASKZ_SUBS_EPU8": return Intrinsic._MM_MASKZ_SUBS_EPU8;
                case "_MM_MASKZ_TERNARYLOGIC_EPI32": return Intrinsic._MM_MASKZ_TERNARYLOGIC_EPI32;
                case "_MM_MASKZ_TERNARYLOGIC_EPI64": return Intrinsic._MM_MASKZ_TERNARYLOGIC_EPI64;
                case "_MM_MASKZ_UNPACKHI_EPI16": return Intrinsic._MM_MASKZ_UNPACKHI_EPI16;
                case "_MM_MASKZ_UNPACKHI_EPI32": return Intrinsic._MM_MASKZ_UNPACKHI_EPI32;
                case "_MM_MASKZ_UNPACKHI_EPI64": return Intrinsic._MM_MASKZ_UNPACKHI_EPI64;
                case "_MM_MASKZ_UNPACKHI_EPI8": return Intrinsic._MM_MASKZ_UNPACKHI_EPI8;
                case "_MM_MASKZ_UNPACKHI_PD": return Intrinsic._MM_MASKZ_UNPACKHI_PD;
                case "_MM_MASKZ_UNPACKHI_PS": return Intrinsic._MM_MASKZ_UNPACKHI_PS;
                case "_MM_MASKZ_UNPACKLO_EPI16": return Intrinsic._MM_MASKZ_UNPACKLO_EPI16;
                case "_MM_MASKZ_UNPACKLO_EPI32": return Intrinsic._MM_MASKZ_UNPACKLO_EPI32;
                case "_MM_MASKZ_UNPACKLO_EPI64": return Intrinsic._MM_MASKZ_UNPACKLO_EPI64;
                case "_MM_MASKZ_UNPACKLO_EPI8": return Intrinsic._MM_MASKZ_UNPACKLO_EPI8;
                case "_MM_MASKZ_UNPACKLO_PD": return Intrinsic._MM_MASKZ_UNPACKLO_PD;
                case "_MM_MASKZ_UNPACKLO_PS": return Intrinsic._MM_MASKZ_UNPACKLO_PS;
                case "_MM_MASKZ_XOR_EPI32": return Intrinsic._MM_MASKZ_XOR_EPI32;
                case "_MM_MASKZ_XOR_EPI64": return Intrinsic._MM_MASKZ_XOR_EPI64;
                case "_MM_MASKZ_XOR_PD": return Intrinsic._MM_MASKZ_XOR_PD;
                case "_MM_MASKZ_XOR_PS": return Intrinsic._MM_MASKZ_XOR_PS;
                case "_MM_MAX_EPI16": return Intrinsic._MM_MAX_EPI16;
                case "_MM_MAX_EPI32": return Intrinsic._MM_MAX_EPI32;
                case "_MM_MAX_EPI64": return Intrinsic._MM_MAX_EPI64;
                case "_MM_MAX_EPI8": return Intrinsic._MM_MAX_EPI8;
                case "_MM_MAX_EPU16": return Intrinsic._MM_MAX_EPU16;
                case "_MM_MAX_EPU32": return Intrinsic._MM_MAX_EPU32;
                case "_MM_MAX_EPU64": return Intrinsic._MM_MAX_EPU64;
                case "_MM_MAX_EPU8": return Intrinsic._MM_MAX_EPU8;
                case "_MM_MAX_PD": return Intrinsic._MM_MAX_PD;
                case "_MM_MAX_PI16": return Intrinsic._MM_MAX_PI16;
                case "_MM_MAX_PS": return Intrinsic._MM_MAX_PS;
                case "_MM_MAX_PU8": return Intrinsic._MM_MAX_PU8;
                case "_MM_MAX_ROUND_SD": return Intrinsic._MM_MAX_ROUND_SD;
                case "_MM_MAX_ROUND_SS": return Intrinsic._MM_MAX_ROUND_SS;
                case "_MM_MAX_SD": return Intrinsic._MM_MAX_SD;
                case "_MM_MAX_SS": return Intrinsic._MM_MAX_SS;
                case "_MM_MFENCE": return Intrinsic._MM_MFENCE;
                case "_MM_MIN_EPI16": return Intrinsic._MM_MIN_EPI16;
                case "_MM_MIN_EPI32": return Intrinsic._MM_MIN_EPI32;
                case "_MM_MIN_EPI64": return Intrinsic._MM_MIN_EPI64;
                case "_MM_MIN_EPI8": return Intrinsic._MM_MIN_EPI8;
                case "_MM_MIN_EPU16": return Intrinsic._MM_MIN_EPU16;
                case "_MM_MIN_EPU32": return Intrinsic._MM_MIN_EPU32;
                case "_MM_MIN_EPU64": return Intrinsic._MM_MIN_EPU64;
                case "_MM_MIN_EPU8": return Intrinsic._MM_MIN_EPU8;
                case "_MM_MIN_PD": return Intrinsic._MM_MIN_PD;
                case "_MM_MIN_PI16": return Intrinsic._MM_MIN_PI16;
                case "_MM_MIN_PS": return Intrinsic._MM_MIN_PS;
                case "_MM_MIN_PU8": return Intrinsic._MM_MIN_PU8;
                case "_MM_MIN_ROUND_SD": return Intrinsic._MM_MIN_ROUND_SD;
                case "_MM_MIN_ROUND_SS": return Intrinsic._MM_MIN_ROUND_SS;
                case "_MM_MIN_SD": return Intrinsic._MM_MIN_SD;
                case "_MM_MIN_SS": return Intrinsic._MM_MIN_SS;
                case "_MM_MINPOS_EPU16": return Intrinsic._MM_MINPOS_EPU16;
                case "_MM_MMASK_I32GATHER_EPI32": return Intrinsic._MM_MMASK_I32GATHER_EPI32;
                case "_MM_MMASK_I32GATHER_EPI64": return Intrinsic._MM_MMASK_I32GATHER_EPI64;
                case "_MM_MMASK_I32GATHER_PD": return Intrinsic._MM_MMASK_I32GATHER_PD;
                case "_MM_MMASK_I32GATHER_PS": return Intrinsic._MM_MMASK_I32GATHER_PS;
                case "_MM_MMASK_I64GATHER_EPI32": return Intrinsic._MM_MMASK_I64GATHER_EPI32;
                case "_MM_MMASK_I64GATHER_EPI64": return Intrinsic._MM_MMASK_I64GATHER_EPI64;
                case "_MM_MMASK_I64GATHER_PD": return Intrinsic._MM_MMASK_I64GATHER_PD;
                case "_MM_MMASK_I64GATHER_PS": return Intrinsic._MM_MMASK_I64GATHER_PS;
                case "_MM_MONITOR": return Intrinsic._MM_MONITOR;
                case "_MM_MOVE_EPI64": return Intrinsic._MM_MOVE_EPI64;
                case "_MM_MOVE_SD": return Intrinsic._MM_MOVE_SD;
                case "_MM_MOVE_SS": return Intrinsic._MM_MOVE_SS;
                case "_MM_MOVEDUP_PD": return Intrinsic._MM_MOVEDUP_PD;
                case "_MM_MOVEHDUP_PS": return Intrinsic._MM_MOVEHDUP_PS;
                case "_MM_MOVEHL_PS": return Intrinsic._MM_MOVEHL_PS;
                case "_MM_MOVELDUP_PS": return Intrinsic._MM_MOVELDUP_PS;
                case "_MM_MOVELH_PS": return Intrinsic._MM_MOVELH_PS;
                case "_MM_MOVEMASK_EPI8": return Intrinsic._MM_MOVEMASK_EPI8;
                case "_MM_MOVEMASK_PD": return Intrinsic._MM_MOVEMASK_PD;
                case "_MM_MOVEMASK_PI8": return Intrinsic._MM_MOVEMASK_PI8;
                case "_MM_MOVEMASK_PS": return Intrinsic._MM_MOVEMASK_PS;
                case "_MM_MOVEPI16_MASK": return Intrinsic._MM_MOVEPI16_MASK;
                case "_MM_MOVEPI32_MASK": return Intrinsic._MM_MOVEPI32_MASK;
                case "_MM_MOVEPI64_MASK": return Intrinsic._MM_MOVEPI64_MASK;
                case "_MM_MOVEPI64_PI64": return Intrinsic._MM_MOVEPI64_PI64;
                case "_MM_MOVEPI8_MASK": return Intrinsic._MM_MOVEPI8_MASK;
                case "_MM_MOVM_EPI16": return Intrinsic._MM_MOVM_EPI16;
                case "_MM_MOVM_EPI32": return Intrinsic._MM_MOVM_EPI32;
                case "_MM_MOVM_EPI64": return Intrinsic._MM_MOVM_EPI64;
                case "_MM_MOVM_EPI8": return Intrinsic._MM_MOVM_EPI8;
                case "_MM_MOVPI64_EPI64": return Intrinsic._MM_MOVPI64_EPI64;
                case "_MM_MPSADBW_EPU8": return Intrinsic._MM_MPSADBW_EPU8;
                case "_MM_MUL_EPI32": return Intrinsic._MM_MUL_EPI32;
                case "_MM_MUL_EPU32": return Intrinsic._MM_MUL_EPU32;
                case "_MM_MUL_PD": return Intrinsic._MM_MUL_PD;
                case "_MM_MUL_PS": return Intrinsic._MM_MUL_PS;
                case "_MM_MUL_ROUND_SD": return Intrinsic._MM_MUL_ROUND_SD;
                case "_MM_MUL_ROUND_SS": return Intrinsic._MM_MUL_ROUND_SS;
                case "_MM_MUL_SD": return Intrinsic._MM_MUL_SD;
                case "_MM_MUL_SS": return Intrinsic._MM_MUL_SS;
                case "_MM_MUL_SU32": return Intrinsic._MM_MUL_SU32;
                case "_MM_MULHI_EPI16": return Intrinsic._MM_MULHI_EPI16;
                case "_MM_MULHI_EPU16": return Intrinsic._MM_MULHI_EPU16;
                case "_MM_MULHI_PI16": return Intrinsic._MM_MULHI_PI16;
                case "_MM_MULHI_PU16": return Intrinsic._MM_MULHI_PU16;
                case "_MM_MULHRS_EPI16": return Intrinsic._MM_MULHRS_EPI16;
                case "_MM_MULHRS_PI16": return Intrinsic._MM_MULHRS_PI16;
                case "_MM_MULLO_EPI16": return Intrinsic._MM_MULLO_EPI16;
                case "_MM_MULLO_EPI32": return Intrinsic._MM_MULLO_EPI32;
                case "_MM_MULLO_EPI64": return Intrinsic._MM_MULLO_EPI64;
                case "_MM_MULLO_PI16": return Intrinsic._MM_MULLO_PI16;
                case "_MM_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM_MULTISHIFT_EPI64_EPI8;
                case "_MM_MWAIT": return Intrinsic._MM_MWAIT;
                case "_MM_OR_PD": return Intrinsic._MM_OR_PD;
                case "_MM_OR_PS": return Intrinsic._MM_OR_PS;
                case "_MM_OR_SI128": return Intrinsic._MM_OR_SI128;
                case "_MM_OR_SI64": return Intrinsic._MM_OR_SI64;
                case "_MM_PACKS_EPI16": return Intrinsic._MM_PACKS_EPI16;
                case "_MM_PACKS_EPI32": return Intrinsic._MM_PACKS_EPI32;
                case "_MM_PACKS_PI16": return Intrinsic._MM_PACKS_PI16;
                case "_MM_PACKS_PI32": return Intrinsic._MM_PACKS_PI32;
                case "_MM_PACKS_PU16": return Intrinsic._MM_PACKS_PU16;
                case "_MM_PACKUS_EPI16": return Intrinsic._MM_PACKUS_EPI16;
                case "_MM_PACKUS_EPI32": return Intrinsic._MM_PACKUS_EPI32;
                case "_MM_PAUSE": return Intrinsic._MM_PAUSE;
                case "_MM_PERMUTE_PD": return Intrinsic._MM_PERMUTE_PD;
                case "_MM_PERMUTE_PS": return Intrinsic._MM_PERMUTE_PS;
                case "_MM_PERMUTEVAR_PD": return Intrinsic._MM_PERMUTEVAR_PD;
                case "_MM_PERMUTEVAR_PS": return Intrinsic._MM_PERMUTEVAR_PS;
                case "_MM_PERMUTEX2VAR_EPI16": return Intrinsic._MM_PERMUTEX2VAR_EPI16;
                case "_MM_PERMUTEX2VAR_EPI32": return Intrinsic._MM_PERMUTEX2VAR_EPI32;
                case "_MM_PERMUTEX2VAR_EPI64": return Intrinsic._MM_PERMUTEX2VAR_EPI64;
                case "_MM_PERMUTEX2VAR_EPI8": return Intrinsic._MM_PERMUTEX2VAR_EPI8;
                case "_MM_PERMUTEX2VAR_PD": return Intrinsic._MM_PERMUTEX2VAR_PD;
                case "_MM_PERMUTEX2VAR_PS": return Intrinsic._MM_PERMUTEX2VAR_PS;
                case "_MM_PERMUTEXVAR_EPI16": return Intrinsic._MM_PERMUTEXVAR_EPI16;
                case "_MM_PERMUTEXVAR_EPI8": return Intrinsic._MM_PERMUTEXVAR_EPI8;
                case "_MM_POPCNT_U32": return Intrinsic._MM_POPCNT_U32;
                case "_MM_POPCNT_U64": return Intrinsic._MM_POPCNT_U64;
                case "_MM_POW_PD": return Intrinsic._MM_POW_PD;
                case "_MM_POW_PS": return Intrinsic._MM_POW_PS;
                case "_MM_PREFETCH": return Intrinsic._MM_PREFETCH;
                case "_MM_RANGE_PD": return Intrinsic._MM_RANGE_PD;
                case "_MM_RANGE_PS": return Intrinsic._MM_RANGE_PS;
                case "_MM_RANGE_ROUND_SD": return Intrinsic._MM_RANGE_ROUND_SD;
                case "_MM_RANGE_ROUND_SS": return Intrinsic._MM_RANGE_ROUND_SS;
                case "_MM_RCP_PS": return Intrinsic._MM_RCP_PS;
                case "_MM_RCP_SS": return Intrinsic._MM_RCP_SS;
                case "_MM_RCP14_PD": return Intrinsic._MM_RCP14_PD;
                case "_MM_RCP14_PS": return Intrinsic._MM_RCP14_PS;
                case "_MM_RCP14_SD": return Intrinsic._MM_RCP14_SD;
                case "_MM_RCP14_SS": return Intrinsic._MM_RCP14_SS;
                case "_MM_RCP28_ROUND_SD": return Intrinsic._MM_RCP28_ROUND_SD;
                case "_MM_RCP28_ROUND_SS": return Intrinsic._MM_RCP28_ROUND_SS;
                case "_MM_RCP28_SD": return Intrinsic._MM_RCP28_SD;
                case "_MM_RCP28_SS": return Intrinsic._MM_RCP28_SS;
                case "_MM_REDUCE_PD": return Intrinsic._MM_REDUCE_PD;
                case "_MM_REDUCE_PS": return Intrinsic._MM_REDUCE_PS;
                case "_MM_REDUCE_ROUND_SD": return Intrinsic._MM_REDUCE_ROUND_SD;
                case "_MM_REDUCE_ROUND_SS": return Intrinsic._MM_REDUCE_ROUND_SS;
                case "_MM_REDUCE_SD": return Intrinsic._MM_REDUCE_SD;
                case "_MM_REDUCE_SS": return Intrinsic._MM_REDUCE_SS;
                case "_MM_REM_EPI16": return Intrinsic._MM_REM_EPI16;
                case "_MM_REM_EPI32": return Intrinsic._MM_REM_EPI32;
                case "_MM_REM_EPI64": return Intrinsic._MM_REM_EPI64;
                case "_MM_REM_EPI8": return Intrinsic._MM_REM_EPI8;
                case "_MM_REM_EPU16": return Intrinsic._MM_REM_EPU16;
                case "_MM_REM_EPU32": return Intrinsic._MM_REM_EPU32;
                case "_MM_REM_EPU64": return Intrinsic._MM_REM_EPU64;
                case "_MM_REM_EPU8": return Intrinsic._MM_REM_EPU8;
                case "_MM_ROL_EPI32": return Intrinsic._MM_ROL_EPI32;
                case "_MM_ROL_EPI64": return Intrinsic._MM_ROL_EPI64;
                case "_MM_ROLV_EPI32": return Intrinsic._MM_ROLV_EPI32;
                case "_MM_ROLV_EPI64": return Intrinsic._MM_ROLV_EPI64;
                case "_MM_ROR_EPI32": return Intrinsic._MM_ROR_EPI32;
                case "_MM_ROR_EPI64": return Intrinsic._MM_ROR_EPI64;
                case "_MM_RORV_EPI32": return Intrinsic._MM_RORV_EPI32;
                case "_MM_RORV_EPI64": return Intrinsic._MM_RORV_EPI64;
                case "_MM_ROUND_PD": return Intrinsic._MM_ROUND_PD;
                case "_MM_ROUND_PS": return Intrinsic._MM_ROUND_PS;
                case "_MM_ROUND_SD": return Intrinsic._MM_ROUND_SD;
                case "_MM_ROUND_SS": return Intrinsic._MM_ROUND_SS;
                case "_MM_ROUNDSCALE_PD": return Intrinsic._MM_ROUNDSCALE_PD;
                case "_MM_ROUNDSCALE_PS": return Intrinsic._MM_ROUNDSCALE_PS;
                case "_MM_ROUNDSCALE_ROUND_SD": return Intrinsic._MM_ROUNDSCALE_ROUND_SD;
                case "_MM_ROUNDSCALE_ROUND_SS": return Intrinsic._MM_ROUNDSCALE_ROUND_SS;
                case "_MM_ROUNDSCALE_SD": return Intrinsic._MM_ROUNDSCALE_SD;
                case "_MM_ROUNDSCALE_SS": return Intrinsic._MM_ROUNDSCALE_SS;
                case "_MM_RSQRT_PS": return Intrinsic._MM_RSQRT_PS;
                case "_MM_RSQRT_SS": return Intrinsic._MM_RSQRT_SS;
                case "_MM_RSQRT14_SD": return Intrinsic._MM_RSQRT14_SD;
                case "_MM_RSQRT14_SS": return Intrinsic._MM_RSQRT14_SS;
                case "_MM_RSQRT28_ROUND_SD": return Intrinsic._MM_RSQRT28_ROUND_SD;
                case "_MM_RSQRT28_ROUND_SS": return Intrinsic._MM_RSQRT28_ROUND_SS;
                case "_MM_RSQRT28_SD": return Intrinsic._MM_RSQRT28_SD;
                case "_MM_RSQRT28_SS": return Intrinsic._MM_RSQRT28_SS;
                case "_MM_SAD_EPU8": return Intrinsic._MM_SAD_EPU8;
                case "_MM_SAD_PU8": return Intrinsic._MM_SAD_PU8;
                case "_MM_SCALEF_PD": return Intrinsic._MM_SCALEF_PD;
                case "_MM_SCALEF_PS": return Intrinsic._MM_SCALEF_PS;
                case "_MM_SCALEF_ROUND_SD": return Intrinsic._MM_SCALEF_ROUND_SD;
                case "_MM_SCALEF_ROUND_SS": return Intrinsic._MM_SCALEF_ROUND_SS;
                case "_MM_SCALEF_SD": return Intrinsic._MM_SCALEF_SD;
                case "_MM_SCALEF_SS": return Intrinsic._MM_SCALEF_SS;
                case "_MM_SET_EPI16": return Intrinsic._MM_SET_EPI16;
                case "_MM_SET_EPI32": return Intrinsic._MM_SET_EPI32;
                case "_MM_SET_EPI64": return Intrinsic._MM_SET_EPI64;
                case "_MM_SET_EPI64X": return Intrinsic._MM_SET_EPI64X;
                case "_MM_SET_EPI8": return Intrinsic._MM_SET_EPI8;
                case "_MM_SET_EXCEPTION_MASK": return Intrinsic._MM_SET_EXCEPTION_MASK;
                case "_MM_SET_EXCEPTION_STATE": return Intrinsic._MM_SET_EXCEPTION_STATE;
                case "_MM_SET_FLUSH_ZERO_MODE": return Intrinsic._MM_SET_FLUSH_ZERO_MODE;
                case "_MM_SET_PD": return Intrinsic._MM_SET_PD;
                case "_MM_SET_PD1": return Intrinsic._MM_SET_PD1;
                case "_MM_SET_PI16": return Intrinsic._MM_SET_PI16;
                case "_MM_SET_PI32": return Intrinsic._MM_SET_PI32;
                case "_MM_SET_PI8": return Intrinsic._MM_SET_PI8;
                case "_MM_SET_PS": return Intrinsic._MM_SET_PS;
                case "_MM_SET_PS1": return Intrinsic._MM_SET_PS1;
                case "_MM_SET_ROUNDING_MODE": return Intrinsic._MM_SET_ROUNDING_MODE;
                case "_MM_SET_SD": return Intrinsic._MM_SET_SD;
                case "_MM_SET_SS": return Intrinsic._MM_SET_SS;
                case "_MM_SET1_EPI16": return Intrinsic._MM_SET1_EPI16;
                case "_MM_SET1_EPI32": return Intrinsic._MM_SET1_EPI32;
                case "_MM_SET1_EPI64": return Intrinsic._MM_SET1_EPI64;
                case "_MM_SET1_EPI64X": return Intrinsic._MM_SET1_EPI64X;
                case "_MM_SET1_EPI8": return Intrinsic._MM_SET1_EPI8;
                case "_MM_SET1_PD": return Intrinsic._MM_SET1_PD;
                case "_MM_SET1_PI16": return Intrinsic._MM_SET1_PI16;
                case "_MM_SET1_PI32": return Intrinsic._MM_SET1_PI32;
                case "_MM_SET1_PI8": return Intrinsic._MM_SET1_PI8;
                case "_MM_SET1_PS": return Intrinsic._MM_SET1_PS;
                case "_MM_SETCSR": return Intrinsic._MM_SETCSR;
                case "_MM_SETR_EPI16": return Intrinsic._MM_SETR_EPI16;
                case "_MM_SETR_EPI32": return Intrinsic._MM_SETR_EPI32;
                case "_MM_SETR_EPI64": return Intrinsic._MM_SETR_EPI64;
                case "_MM_SETR_EPI8": return Intrinsic._MM_SETR_EPI8;
                case "_MM_SETR_PD": return Intrinsic._MM_SETR_PD;
                case "_MM_SETR_PI16": return Intrinsic._MM_SETR_PI16;
                case "_MM_SETR_PI32": return Intrinsic._MM_SETR_PI32;
                case "_MM_SETR_PI8": return Intrinsic._MM_SETR_PI8;
                case "_MM_SETR_PS": return Intrinsic._MM_SETR_PS;
                case "_MM_SETZERO_PD": return Intrinsic._MM_SETZERO_PD;
                case "_MM_SETZERO_PS": return Intrinsic._MM_SETZERO_PS;
                case "_MM_SETZERO_SI128": return Intrinsic._MM_SETZERO_SI128;
                case "_MM_SETZERO_SI64": return Intrinsic._MM_SETZERO_SI64;
                case "_MM_SFENCE": return Intrinsic._MM_SFENCE;
                case "_MM_SHA1MSG1_EPU32": return Intrinsic._MM_SHA1MSG1_EPU32;
                case "_MM_SHA1MSG2_EPU32": return Intrinsic._MM_SHA1MSG2_EPU32;
                case "_MM_SHA1NEXTE_EPU32": return Intrinsic._MM_SHA1NEXTE_EPU32;
                case "_MM_SHA1RNDS4_EPU32": return Intrinsic._MM_SHA1RNDS4_EPU32;
                case "_MM_SHA256MSG1_EPU32": return Intrinsic._MM_SHA256MSG1_EPU32;
                case "_MM_SHA256MSG2_EPU32": return Intrinsic._MM_SHA256MSG2_EPU32;
                case "_MM_SHA256RNDS2_EPU32": return Intrinsic._MM_SHA256RNDS2_EPU32;
                case "_MM_SHUFFLE_EPI32": return Intrinsic._MM_SHUFFLE_EPI32;
                case "_MM_SHUFFLE_EPI8": return Intrinsic._MM_SHUFFLE_EPI8;
                case "_MM_SHUFFLE_PD": return Intrinsic._MM_SHUFFLE_PD;
                case "_MM_SHUFFLE_PI16": return Intrinsic._MM_SHUFFLE_PI16;
                case "_MM_SHUFFLE_PI8": return Intrinsic._MM_SHUFFLE_PI8;
                case "_MM_SHUFFLE_PS": return Intrinsic._MM_SHUFFLE_PS;
                case "_MM_SHUFFLEHI_EPI16": return Intrinsic._MM_SHUFFLEHI_EPI16;
                case "_MM_SHUFFLELO_EPI16": return Intrinsic._MM_SHUFFLELO_EPI16;
                case "_MM_SIGN_EPI16": return Intrinsic._MM_SIGN_EPI16;
                case "_MM_SIGN_EPI32": return Intrinsic._MM_SIGN_EPI32;
                case "_MM_SIGN_EPI8": return Intrinsic._MM_SIGN_EPI8;
                case "_MM_SIGN_PI16": return Intrinsic._MM_SIGN_PI16;
                case "_MM_SIGN_PI32": return Intrinsic._MM_SIGN_PI32;
                case "_MM_SIGN_PI8": return Intrinsic._MM_SIGN_PI8;
                case "_MM_SIN_PD": return Intrinsic._MM_SIN_PD;
                case "_MM_SIN_PS": return Intrinsic._MM_SIN_PS;
                case "_MM_SINCOS_PD": return Intrinsic._MM_SINCOS_PD;
                case "_MM_SINCOS_PS": return Intrinsic._MM_SINCOS_PS;
                case "_MM_SIND_PD": return Intrinsic._MM_SIND_PD;
                case "_MM_SIND_PS": return Intrinsic._MM_SIND_PS;
                case "_MM_SINH_PD": return Intrinsic._MM_SINH_PD;
                case "_MM_SINH_PS": return Intrinsic._MM_SINH_PS;
                case "_MM_SLL_EPI16": return Intrinsic._MM_SLL_EPI16;
                case "_MM_SLL_EPI32": return Intrinsic._MM_SLL_EPI32;
                case "_MM_SLL_EPI64": return Intrinsic._MM_SLL_EPI64;
                case "_MM_SLL_PI16": return Intrinsic._MM_SLL_PI16;
                case "_MM_SLL_PI32": return Intrinsic._MM_SLL_PI32;
                case "_MM_SLL_SI64": return Intrinsic._MM_SLL_SI64;
                case "_MM_SLLI_EPI16": return Intrinsic._MM_SLLI_EPI16;
                case "_MM_SLLI_EPI32": return Intrinsic._MM_SLLI_EPI32;
                case "_MM_SLLI_EPI64": return Intrinsic._MM_SLLI_EPI64;
                case "_MM_SLLI_PI16": return Intrinsic._MM_SLLI_PI16;
                case "_MM_SLLI_PI32": return Intrinsic._MM_SLLI_PI32;
                case "_MM_SLLI_SI128": return Intrinsic._MM_SLLI_SI128;
                case "_MM_SLLI_SI64": return Intrinsic._MM_SLLI_SI64;
                case "_MM_SLLV_EPI16": return Intrinsic._MM_SLLV_EPI16;
                case "_MM_SLLV_EPI32": return Intrinsic._MM_SLLV_EPI32;
                case "_MM_SLLV_EPI64": return Intrinsic._MM_SLLV_EPI64;
                case "_MM_SPFLT_32": return Intrinsic._MM_SPFLT_32;
                case "_MM_SPFLT_64": return Intrinsic._MM_SPFLT_64;
                case "_MM_SQRT_PD": return Intrinsic._MM_SQRT_PD;
                case "_MM_SQRT_PS": return Intrinsic._MM_SQRT_PS;
                case "_MM_SQRT_ROUND_SD": return Intrinsic._MM_SQRT_ROUND_SD;
                case "_MM_SQRT_ROUND_SS": return Intrinsic._MM_SQRT_ROUND_SS;
                case "_MM_SQRT_SD": return Intrinsic._MM_SQRT_SD;
                case "_MM_SQRT_SS": return Intrinsic._MM_SQRT_SS;
                case "_MM_SRA_EPI16": return Intrinsic._MM_SRA_EPI16;
                case "_MM_SRA_EPI32": return Intrinsic._MM_SRA_EPI32;
                case "_MM_SRA_EPI64": return Intrinsic._MM_SRA_EPI64;
                case "_MM_SRA_PI16": return Intrinsic._MM_SRA_PI16;
                case "_MM_SRA_PI32": return Intrinsic._MM_SRA_PI32;
                case "_MM_SRAI_EPI16": return Intrinsic._MM_SRAI_EPI16;
                case "_MM_SRAI_EPI32": return Intrinsic._MM_SRAI_EPI32;
                case "_MM_SRAI_EPI64": return Intrinsic._MM_SRAI_EPI64;
                case "_MM_SRAI_PI16": return Intrinsic._MM_SRAI_PI16;
                case "_MM_SRAI_PI32": return Intrinsic._MM_SRAI_PI32;
                case "_MM_SRAV_EPI16": return Intrinsic._MM_SRAV_EPI16;
                case "_MM_SRAV_EPI32": return Intrinsic._MM_SRAV_EPI32;
                case "_MM_SRAV_EPI64": return Intrinsic._MM_SRAV_EPI64;
                case "_MM_SRL_EPI16": return Intrinsic._MM_SRL_EPI16;
                case "_MM_SRL_EPI32": return Intrinsic._MM_SRL_EPI32;
                case "_MM_SRL_EPI64": return Intrinsic._MM_SRL_EPI64;
                case "_MM_SRL_PI16": return Intrinsic._MM_SRL_PI16;
                case "_MM_SRL_PI32": return Intrinsic._MM_SRL_PI32;
                case "_MM_SRL_SI64": return Intrinsic._MM_SRL_SI64;
                case "_MM_SRLI_EPI16": return Intrinsic._MM_SRLI_EPI16;
                case "_MM_SRLI_EPI32": return Intrinsic._MM_SRLI_EPI32;
                case "_MM_SRLI_EPI64": return Intrinsic._MM_SRLI_EPI64;
                case "_MM_SRLI_PI16": return Intrinsic._MM_SRLI_PI16;
                case "_MM_SRLI_PI32": return Intrinsic._MM_SRLI_PI32;
                case "_MM_SRLI_SI128": return Intrinsic._MM_SRLI_SI128;
                case "_MM_SRLI_SI64": return Intrinsic._MM_SRLI_SI64;
                case "_MM_SRLV_EPI16": return Intrinsic._MM_SRLV_EPI16;
                case "_MM_SRLV_EPI32": return Intrinsic._MM_SRLV_EPI32;
                case "_MM_SRLV_EPI64": return Intrinsic._MM_SRLV_EPI64;
                case "_MM_STORE_PD": return Intrinsic._MM_STORE_PD;
                case "_MM_STORE_PD1": return Intrinsic._MM_STORE_PD1;
                case "_MM_STORE_PS": return Intrinsic._MM_STORE_PS;
                case "_MM_STORE_PS1": return Intrinsic._MM_STORE_PS1;
                case "_MM_STORE_SD": return Intrinsic._MM_STORE_SD;
                case "_MM_STORE_SI128": return Intrinsic._MM_STORE_SI128;
                case "_MM_STORE_SS": return Intrinsic._MM_STORE_SS;
                case "_MM_STORE1_PD": return Intrinsic._MM_STORE1_PD;
                case "_MM_STORE1_PS": return Intrinsic._MM_STORE1_PS;
                case "_MM_STOREH_PD": return Intrinsic._MM_STOREH_PD;
                case "_MM_STOREH_PI": return Intrinsic._MM_STOREH_PI;
                case "_MM_STOREL_EPI64": return Intrinsic._MM_STOREL_EPI64;
                case "_MM_STOREL_PD": return Intrinsic._MM_STOREL_PD;
                case "_MM_STOREL_PI": return Intrinsic._MM_STOREL_PI;
                case "_MM_STORER_PD": return Intrinsic._MM_STORER_PD;
                case "_MM_STORER_PS": return Intrinsic._MM_STORER_PS;
                case "_MM_STOREU_PD": return Intrinsic._MM_STOREU_PD;
                case "_MM_STOREU_PS": return Intrinsic._MM_STOREU_PS;
                case "_MM_STOREU_SI128": return Intrinsic._MM_STOREU_SI128;
                case "_MM_STOREU_SI16": return Intrinsic._MM_STOREU_SI16;
                case "_MM_STOREU_SI32": return Intrinsic._MM_STOREU_SI32;
                case "_MM_STOREU_SI64": return Intrinsic._MM_STOREU_SI64;
                case "_MM_STREAM_LOAD_SI128": return Intrinsic._MM_STREAM_LOAD_SI128;
                case "_MM_STREAM_PD": return Intrinsic._MM_STREAM_PD;
                case "_MM_STREAM_PI": return Intrinsic._MM_STREAM_PI;
                case "_MM_STREAM_PS": return Intrinsic._MM_STREAM_PS;
                case "_MM_STREAM_SI128": return Intrinsic._MM_STREAM_SI128;
                case "_MM_STREAM_SI32": return Intrinsic._MM_STREAM_SI32;
                case "_MM_STREAM_SI64": return Intrinsic._MM_STREAM_SI64;
                case "_MM_SUB_EPI16": return Intrinsic._MM_SUB_EPI16;
                case "_MM_SUB_EPI32": return Intrinsic._MM_SUB_EPI32;
                case "_MM_SUB_EPI64": return Intrinsic._MM_SUB_EPI64;
                case "_MM_SUB_EPI8": return Intrinsic._MM_SUB_EPI8;
                case "_MM_SUB_PD": return Intrinsic._MM_SUB_PD;
                case "_MM_SUB_PI16": return Intrinsic._MM_SUB_PI16;
                case "_MM_SUB_PI32": return Intrinsic._MM_SUB_PI32;
                case "_MM_SUB_PI8": return Intrinsic._MM_SUB_PI8;
                case "_MM_SUB_PS": return Intrinsic._MM_SUB_PS;
                case "_MM_SUB_ROUND_SD": return Intrinsic._MM_SUB_ROUND_SD;
                case "_MM_SUB_ROUND_SS": return Intrinsic._MM_SUB_ROUND_SS;
                case "_MM_SUB_SD": return Intrinsic._MM_SUB_SD;
                case "_MM_SUB_SI64": return Intrinsic._MM_SUB_SI64;
                case "_MM_SUB_SS": return Intrinsic._MM_SUB_SS;
                case "_MM_SUBS_EPI16": return Intrinsic._MM_SUBS_EPI16;
                case "_MM_SUBS_EPI8": return Intrinsic._MM_SUBS_EPI8;
                case "_MM_SUBS_EPU16": return Intrinsic._MM_SUBS_EPU16;
                case "_MM_SUBS_EPU8": return Intrinsic._MM_SUBS_EPU8;
                case "_MM_SUBS_PI16": return Intrinsic._MM_SUBS_PI16;
                case "_MM_SUBS_PI8": return Intrinsic._MM_SUBS_PI8;
                case "_MM_SUBS_PU16": return Intrinsic._MM_SUBS_PU16;
                case "_MM_SUBS_PU8": return Intrinsic._MM_SUBS_PU8;
                case "_MM_SVML_CEIL_PD": return Intrinsic._MM_SVML_CEIL_PD;
                case "_MM_SVML_CEIL_PS": return Intrinsic._MM_SVML_CEIL_PS;
                case "_MM_SVML_FLOOR_PD": return Intrinsic._MM_SVML_FLOOR_PD;
                case "_MM_SVML_FLOOR_PS": return Intrinsic._MM_SVML_FLOOR_PS;
                case "_MM_SVML_ROUND_PD": return Intrinsic._MM_SVML_ROUND_PD;
                case "_MM_SVML_ROUND_PS": return Intrinsic._MM_SVML_ROUND_PS;
                case "_MM_SVML_SQRT_PD": return Intrinsic._MM_SVML_SQRT_PD;
                case "_MM_SVML_SQRT_PS": return Intrinsic._MM_SVML_SQRT_PS;
                case "_MM_TAN_PD": return Intrinsic._MM_TAN_PD;
                case "_MM_TAN_PS": return Intrinsic._MM_TAN_PS;
                case "_MM_TAND_PD": return Intrinsic._MM_TAND_PD;
                case "_MM_TAND_PS": return Intrinsic._MM_TAND_PS;
                case "_MM_TANH_PD": return Intrinsic._MM_TANH_PD;
                case "_MM_TANH_PS": return Intrinsic._MM_TANH_PS;
                case "_MM_TERNARYLOGIC_EPI32": return Intrinsic._MM_TERNARYLOGIC_EPI32;
                case "_MM_TERNARYLOGIC_EPI64": return Intrinsic._MM_TERNARYLOGIC_EPI64;
                case "_MM_TEST_ALL_ONES": return Intrinsic._MM_TEST_ALL_ONES;
                case "_MM_TEST_ALL_ZEROS": return Intrinsic._MM_TEST_ALL_ZEROS;
                case "_MM_TEST_EPI16_MASK": return Intrinsic._MM_TEST_EPI16_MASK;
                case "_MM_TEST_EPI32_MASK": return Intrinsic._MM_TEST_EPI32_MASK;
                case "_MM_TEST_EPI64_MASK": return Intrinsic._MM_TEST_EPI64_MASK;
                case "_MM_TEST_EPI8_MASK": return Intrinsic._MM_TEST_EPI8_MASK;
                case "_MM_TEST_MIX_ONES_ZEROS": return Intrinsic._MM_TEST_MIX_ONES_ZEROS;
                case "_MM_TESTC_PD": return Intrinsic._MM_TESTC_PD;
                case "_MM_TESTC_PS": return Intrinsic._MM_TESTC_PS;
                case "_MM_TESTC_SI128": return Intrinsic._MM_TESTC_SI128;
                case "_MM_TESTN_EPI16_MASK": return Intrinsic._MM_TESTN_EPI16_MASK;
                case "_MM_TESTN_EPI32_MASK": return Intrinsic._MM_TESTN_EPI32_MASK;
                case "_MM_TESTN_EPI64_MASK": return Intrinsic._MM_TESTN_EPI64_MASK;
                case "_MM_TESTN_EPI8_MASK": return Intrinsic._MM_TESTN_EPI8_MASK;
                case "_MM_TESTNZC_PD": return Intrinsic._MM_TESTNZC_PD;
                case "_MM_TESTNZC_PS": return Intrinsic._MM_TESTNZC_PS;
                case "_MM_TESTNZC_SI128": return Intrinsic._MM_TESTNZC_SI128;
                case "_MM_TESTZ_PD": return Intrinsic._MM_TESTZ_PD;
                case "_MM_TESTZ_PS": return Intrinsic._MM_TESTZ_PS;
                case "_MM_TESTZ_SI128": return Intrinsic._MM_TESTZ_SI128;
                case "_MM_TRANSPOSE4_PS": return Intrinsic._MM_TRANSPOSE4_PS;
                case "_MM_TRUNC_PD": return Intrinsic._MM_TRUNC_PD;
                case "_MM_TRUNC_PS": return Intrinsic._MM_TRUNC_PS;
                case "_MM_TZCNT_32": return Intrinsic._MM_TZCNT_32;
                case "_MM_TZCNT_64": return Intrinsic._MM_TZCNT_64;
                case "_MM_TZCNTI_32": return Intrinsic._MM_TZCNTI_32;
                case "_MM_TZCNTI_64": return Intrinsic._MM_TZCNTI_64;
                case "_MM_UCOMIEQ_SD": return Intrinsic._MM_UCOMIEQ_SD;
                case "_MM_UCOMIEQ_SS": return Intrinsic._MM_UCOMIEQ_SS;
                case "_MM_UCOMIGE_SD": return Intrinsic._MM_UCOMIGE_SD;
                case "_MM_UCOMIGE_SS": return Intrinsic._MM_UCOMIGE_SS;
                case "_MM_UCOMIGT_SD": return Intrinsic._MM_UCOMIGT_SD;
                case "_MM_UCOMIGT_SS": return Intrinsic._MM_UCOMIGT_SS;
                case "_MM_UCOMILE_SD": return Intrinsic._MM_UCOMILE_SD;
                case "_MM_UCOMILE_SS": return Intrinsic._MM_UCOMILE_SS;
                case "_MM_UCOMILT_SD": return Intrinsic._MM_UCOMILT_SD;
                case "_MM_UCOMILT_SS": return Intrinsic._MM_UCOMILT_SS;
                case "_MM_UCOMINEQ_SD": return Intrinsic._MM_UCOMINEQ_SD;
                case "_MM_UCOMINEQ_SS": return Intrinsic._MM_UCOMINEQ_SS;
                case "_MM_UDIV_EPI32": return Intrinsic._MM_UDIV_EPI32;
                case "_MM_UDIVREM_EPI32": return Intrinsic._MM_UDIVREM_EPI32;
                case "_MM_UNDEFINED_PD": return Intrinsic._MM_UNDEFINED_PD;
                case "_MM_UNDEFINED_PS": return Intrinsic._MM_UNDEFINED_PS;
                case "_MM_UNDEFINED_SI128": return Intrinsic._MM_UNDEFINED_SI128;
                case "_MM_UNPACKHI_EPI16": return Intrinsic._MM_UNPACKHI_EPI16;
                case "_MM_UNPACKHI_EPI32": return Intrinsic._MM_UNPACKHI_EPI32;
                case "_MM_UNPACKHI_EPI64": return Intrinsic._MM_UNPACKHI_EPI64;
                case "_MM_UNPACKHI_EPI8": return Intrinsic._MM_UNPACKHI_EPI8;
                case "_MM_UNPACKHI_PD": return Intrinsic._MM_UNPACKHI_PD;
                case "_MM_UNPACKHI_PI16": return Intrinsic._MM_UNPACKHI_PI16;
                case "_MM_UNPACKHI_PI32": return Intrinsic._MM_UNPACKHI_PI32;
                case "_MM_UNPACKHI_PI8": return Intrinsic._MM_UNPACKHI_PI8;
                case "_MM_UNPACKHI_PS": return Intrinsic._MM_UNPACKHI_PS;
                case "_MM_UNPACKLO_EPI16": return Intrinsic._MM_UNPACKLO_EPI16;
                case "_MM_UNPACKLO_EPI32": return Intrinsic._MM_UNPACKLO_EPI32;
                case "_MM_UNPACKLO_EPI64": return Intrinsic._MM_UNPACKLO_EPI64;
                case "_MM_UNPACKLO_EPI8": return Intrinsic._MM_UNPACKLO_EPI8;
                case "_MM_UNPACKLO_PD": return Intrinsic._MM_UNPACKLO_PD;
                case "_MM_UNPACKLO_PI16": return Intrinsic._MM_UNPACKLO_PI16;
                case "_MM_UNPACKLO_PI32": return Intrinsic._MM_UNPACKLO_PI32;
                case "_MM_UNPACKLO_PI8": return Intrinsic._MM_UNPACKLO_PI8;
                case "_MM_UNPACKLO_PS": return Intrinsic._MM_UNPACKLO_PS;
                case "_MM_UREM_EPI32": return Intrinsic._MM_UREM_EPI32;
                case "_MM_XOR_PD": return Intrinsic._MM_XOR_PD;
                case "_MM_XOR_PS": return Intrinsic._MM_XOR_PS;
                case "_MM_XOR_SI128": return Intrinsic._MM_XOR_SI128;
                case "_MM_XOR_SI64": return Intrinsic._MM_XOR_SI64;
                case "_MM256_ABS_EPI16": return Intrinsic._MM256_ABS_EPI16;
                case "_MM256_ABS_EPI32": return Intrinsic._MM256_ABS_EPI32;
                case "_MM256_ABS_EPI64": return Intrinsic._MM256_ABS_EPI64;
                case "_MM256_ABS_EPI8": return Intrinsic._MM256_ABS_EPI8;
                case "_MM256_ACOS_PD": return Intrinsic._MM256_ACOS_PD;
                case "_MM256_ACOS_PS": return Intrinsic._MM256_ACOS_PS;
                case "_MM256_ACOSH_PD": return Intrinsic._MM256_ACOSH_PD;
                case "_MM256_ACOSH_PS": return Intrinsic._MM256_ACOSH_PS;
                case "_MM256_ADD_EPI16": return Intrinsic._MM256_ADD_EPI16;
                case "_MM256_ADD_EPI32": return Intrinsic._MM256_ADD_EPI32;
                case "_MM256_ADD_EPI64": return Intrinsic._MM256_ADD_EPI64;
                case "_MM256_ADD_EPI8": return Intrinsic._MM256_ADD_EPI8;
                case "_MM256_ADD_PD": return Intrinsic._MM256_ADD_PD;
                case "_MM256_ADD_PS": return Intrinsic._MM256_ADD_PS;
                case "_MM256_ADDS_EPI16": return Intrinsic._MM256_ADDS_EPI16;
                case "_MM256_ADDS_EPI8": return Intrinsic._MM256_ADDS_EPI8;
                case "_MM256_ADDS_EPU16": return Intrinsic._MM256_ADDS_EPU16;
                case "_MM256_ADDS_EPU8": return Intrinsic._MM256_ADDS_EPU8;
                case "_MM256_ADDSUB_PD": return Intrinsic._MM256_ADDSUB_PD;
                case "_MM256_ADDSUB_PS": return Intrinsic._MM256_ADDSUB_PS;
                case "_MM256_ALIGNR_EPI32": return Intrinsic._MM256_ALIGNR_EPI32;
                case "_MM256_ALIGNR_EPI64": return Intrinsic._MM256_ALIGNR_EPI64;
                case "_MM256_ALIGNR_EPI8": return Intrinsic._MM256_ALIGNR_EPI8;
                case "_MM256_AND_PD": return Intrinsic._MM256_AND_PD;
                case "_MM256_AND_PS": return Intrinsic._MM256_AND_PS;
                case "_MM256_AND_SI256": return Intrinsic._MM256_AND_SI256;
                case "_MM256_ANDNOT_PD": return Intrinsic._MM256_ANDNOT_PD;
                case "_MM256_ANDNOT_PS": return Intrinsic._MM256_ANDNOT_PS;
                case "_MM256_ANDNOT_SI256": return Intrinsic._MM256_ANDNOT_SI256;
                case "_MM256_ASIN_PD": return Intrinsic._MM256_ASIN_PD;
                case "_MM256_ASIN_PS": return Intrinsic._MM256_ASIN_PS;
                case "_MM256_ASINH_PD": return Intrinsic._MM256_ASINH_PD;
                case "_MM256_ASINH_PS": return Intrinsic._MM256_ASINH_PS;
                case "_MM256_ATAN_PD": return Intrinsic._MM256_ATAN_PD;
                case "_MM256_ATAN_PS": return Intrinsic._MM256_ATAN_PS;
                case "_MM256_ATAN2_PD": return Intrinsic._MM256_ATAN2_PD;
                case "_MM256_ATAN2_PS": return Intrinsic._MM256_ATAN2_PS;
                case "_MM256_ATANH_PD": return Intrinsic._MM256_ATANH_PD;
                case "_MM256_ATANH_PS": return Intrinsic._MM256_ATANH_PS;
                case "_MM256_AVG_EPU16": return Intrinsic._MM256_AVG_EPU16;
                case "_MM256_AVG_EPU8": return Intrinsic._MM256_AVG_EPU8;
                case "_MM256_BLEND_EPI16": return Intrinsic._MM256_BLEND_EPI16;
                case "_MM256_BLEND_EPI32": return Intrinsic._MM256_BLEND_EPI32;
                case "_MM256_BLEND_PD": return Intrinsic._MM256_BLEND_PD;
                case "_MM256_BLEND_PS": return Intrinsic._MM256_BLEND_PS;
                case "_MM256_BLENDV_EPI8": return Intrinsic._MM256_BLENDV_EPI8;
                case "_MM256_BLENDV_PD": return Intrinsic._MM256_BLENDV_PD;
                case "_MM256_BLENDV_PS": return Intrinsic._MM256_BLENDV_PS;
                case "_MM256_BROADCAST_F32X2": return Intrinsic._MM256_BROADCAST_F32X2;
                case "_MM256_BROADCAST_F32X4": return Intrinsic._MM256_BROADCAST_F32X4;
                case "_MM256_BROADCAST_F64X2": return Intrinsic._MM256_BROADCAST_F64X2;
                case "_MM256_BROADCAST_I32X2": return Intrinsic._MM256_BROADCAST_I32X2;
                case "_MM256_BROADCAST_I32X4": return Intrinsic._MM256_BROADCAST_I32X4;
                case "_MM256_BROADCAST_I64X2": return Intrinsic._MM256_BROADCAST_I64X2;
                case "_MM256_BROADCAST_PD": return Intrinsic._MM256_BROADCAST_PD;
                case "_MM256_BROADCAST_PS": return Intrinsic._MM256_BROADCAST_PS;
                case "_MM256_BROADCAST_SD": return Intrinsic._MM256_BROADCAST_SD;
                case "_MM256_BROADCAST_SS": return Intrinsic._MM256_BROADCAST_SS;
                case "_MM256_BROADCASTB_EPI8": return Intrinsic._MM256_BROADCASTB_EPI8;
                case "_MM256_BROADCASTD_EPI32": return Intrinsic._MM256_BROADCASTD_EPI32;
                case "_MM256_BROADCASTMB_EPI64": return Intrinsic._MM256_BROADCASTMB_EPI64;
                case "_MM256_BROADCASTMW_EPI32": return Intrinsic._MM256_BROADCASTMW_EPI32;
                case "_MM256_BROADCASTQ_EPI64": return Intrinsic._MM256_BROADCASTQ_EPI64;
                case "_MM256_BROADCASTSD_PD": return Intrinsic._MM256_BROADCASTSD_PD;
                case "_MM256_BROADCASTSI128_SI256": return Intrinsic._MM256_BROADCASTSI128_SI256;
                case "_MM256_BROADCASTSS_PS": return Intrinsic._MM256_BROADCASTSS_PS;
                case "_MM256_BROADCASTW_EPI16": return Intrinsic._MM256_BROADCASTW_EPI16;
                case "_MM256_BSLLI_EPI128": return Intrinsic._MM256_BSLLI_EPI128;
                case "_MM256_BSRLI_EPI128": return Intrinsic._MM256_BSRLI_EPI128;
                case "_MM256_CASTPD_PS": return Intrinsic._MM256_CASTPD_PS;
                case "_MM256_CASTPD_SI256": return Intrinsic._MM256_CASTPD_SI256;
                case "_MM256_CASTPD128_PD256": return Intrinsic._MM256_CASTPD128_PD256;
                case "_MM256_CASTPD256_PD128": return Intrinsic._MM256_CASTPD256_PD128;
                case "_MM256_CASTPS_PD": return Intrinsic._MM256_CASTPS_PD;
                case "_MM256_CASTPS_SI256": return Intrinsic._MM256_CASTPS_SI256;
                case "_MM256_CASTPS128_PS256": return Intrinsic._MM256_CASTPS128_PS256;
                case "_MM256_CASTPS256_PS128": return Intrinsic._MM256_CASTPS256_PS128;
                case "_MM256_CASTSI128_SI256": return Intrinsic._MM256_CASTSI128_SI256;
                case "_MM256_CASTSI256_PD": return Intrinsic._MM256_CASTSI256_PD;
                case "_MM256_CASTSI256_PS": return Intrinsic._MM256_CASTSI256_PS;
                case "_MM256_CASTSI256_SI128": return Intrinsic._MM256_CASTSI256_SI128;
                case "_MM256_CBRT_PD": return Intrinsic._MM256_CBRT_PD;
                case "_MM256_CBRT_PS": return Intrinsic._MM256_CBRT_PS;
                case "_MM256_CDFNORM_PD": return Intrinsic._MM256_CDFNORM_PD;
                case "_MM256_CDFNORM_PS": return Intrinsic._MM256_CDFNORM_PS;
                case "_MM256_CDFNORMINV_PD": return Intrinsic._MM256_CDFNORMINV_PD;
                case "_MM256_CDFNORMINV_PS": return Intrinsic._MM256_CDFNORMINV_PS;
                case "_MM256_CEIL_PD": return Intrinsic._MM256_CEIL_PD;
                case "_MM256_CEIL_PS": return Intrinsic._MM256_CEIL_PS;
                case "_MM256_CEXP_PS": return Intrinsic._MM256_CEXP_PS;
                case "_MM256_CLOG_PS": return Intrinsic._MM256_CLOG_PS;
                case "_MM256_CMP_EPI16_MASK": return Intrinsic._MM256_CMP_EPI16_MASK;
                case "_MM256_CMP_EPI32_MASK": return Intrinsic._MM256_CMP_EPI32_MASK;
                case "_MM256_CMP_EPI64_MASK": return Intrinsic._MM256_CMP_EPI64_MASK;
                case "_MM256_CMP_EPI8_MASK": return Intrinsic._MM256_CMP_EPI8_MASK;
                case "_MM256_CMP_EPU16_MASK": return Intrinsic._MM256_CMP_EPU16_MASK;
                case "_MM256_CMP_EPU32_MASK": return Intrinsic._MM256_CMP_EPU32_MASK;
                case "_MM256_CMP_EPU64_MASK": return Intrinsic._MM256_CMP_EPU64_MASK;
                case "_MM256_CMP_EPU8_MASK": return Intrinsic._MM256_CMP_EPU8_MASK;
                case "_MM256_CMP_PD": return Intrinsic._MM256_CMP_PD;
                case "_MM256_CMP_PD_MASK": return Intrinsic._MM256_CMP_PD_MASK;
                case "_MM256_CMP_PS": return Intrinsic._MM256_CMP_PS;
                case "_MM256_CMP_PS_MASK": return Intrinsic._MM256_CMP_PS_MASK;
                case "_MM256_CMPEQ_EPI16": return Intrinsic._MM256_CMPEQ_EPI16;
                case "_MM256_CMPEQ_EPI16_MASK": return Intrinsic._MM256_CMPEQ_EPI16_MASK;
                case "_MM256_CMPEQ_EPI32": return Intrinsic._MM256_CMPEQ_EPI32;
                case "_MM256_CMPEQ_EPI32_MASK": return Intrinsic._MM256_CMPEQ_EPI32_MASK;
                case "_MM256_CMPEQ_EPI64": return Intrinsic._MM256_CMPEQ_EPI64;
                case "_MM256_CMPEQ_EPI64_MASK": return Intrinsic._MM256_CMPEQ_EPI64_MASK;
                case "_MM256_CMPEQ_EPI8": return Intrinsic._MM256_CMPEQ_EPI8;
                case "_MM256_CMPEQ_EPI8_MASK": return Intrinsic._MM256_CMPEQ_EPI8_MASK;
                case "_MM256_CMPEQ_EPU16_MASK": return Intrinsic._MM256_CMPEQ_EPU16_MASK;
                case "_MM256_CMPEQ_EPU32_MASK": return Intrinsic._MM256_CMPEQ_EPU32_MASK;
                case "_MM256_CMPEQ_EPU64_MASK": return Intrinsic._MM256_CMPEQ_EPU64_MASK;
                case "_MM256_CMPEQ_EPU8_MASK": return Intrinsic._MM256_CMPEQ_EPU8_MASK;
                case "_MM256_CMPGE_EPI16_MASK": return Intrinsic._MM256_CMPGE_EPI16_MASK;
                case "_MM256_CMPGE_EPI32_MASK": return Intrinsic._MM256_CMPGE_EPI32_MASK;
                case "_MM256_CMPGE_EPI64_MASK": return Intrinsic._MM256_CMPGE_EPI64_MASK;
                case "_MM256_CMPGE_EPI8_MASK": return Intrinsic._MM256_CMPGE_EPI8_MASK;
                case "_MM256_CMPGE_EPU16_MASK": return Intrinsic._MM256_CMPGE_EPU16_MASK;
                case "_MM256_CMPGE_EPU32_MASK": return Intrinsic._MM256_CMPGE_EPU32_MASK;
                case "_MM256_CMPGE_EPU64_MASK": return Intrinsic._MM256_CMPGE_EPU64_MASK;
                case "_MM256_CMPGE_EPU8_MASK": return Intrinsic._MM256_CMPGE_EPU8_MASK;
                case "_MM256_CMPGT_EPI16": return Intrinsic._MM256_CMPGT_EPI16;
                case "_MM256_CMPGT_EPI16_MASK": return Intrinsic._MM256_CMPGT_EPI16_MASK;
                case "_MM256_CMPGT_EPI32": return Intrinsic._MM256_CMPGT_EPI32;
                case "_MM256_CMPGT_EPI32_MASK": return Intrinsic._MM256_CMPGT_EPI32_MASK;
                case "_MM256_CMPGT_EPI64": return Intrinsic._MM256_CMPGT_EPI64;
                case "_MM256_CMPGT_EPI64_MASK": return Intrinsic._MM256_CMPGT_EPI64_MASK;
                case "_MM256_CMPGT_EPI8": return Intrinsic._MM256_CMPGT_EPI8;
                case "_MM256_CMPGT_EPI8_MASK": return Intrinsic._MM256_CMPGT_EPI8_MASK;
                case "_MM256_CMPGT_EPU16_MASK": return Intrinsic._MM256_CMPGT_EPU16_MASK;
                case "_MM256_CMPGT_EPU32_MASK": return Intrinsic._MM256_CMPGT_EPU32_MASK;
                case "_MM256_CMPGT_EPU64_MASK": return Intrinsic._MM256_CMPGT_EPU64_MASK;
                case "_MM256_CMPGT_EPU8_MASK": return Intrinsic._MM256_CMPGT_EPU8_MASK;
                case "_MM256_CMPLE_EPI16_MASK": return Intrinsic._MM256_CMPLE_EPI16_MASK;
                case "_MM256_CMPLE_EPI32_MASK": return Intrinsic._MM256_CMPLE_EPI32_MASK;
                case "_MM256_CMPLE_EPI64_MASK": return Intrinsic._MM256_CMPLE_EPI64_MASK;
                case "_MM256_CMPLE_EPI8_MASK": return Intrinsic._MM256_CMPLE_EPI8_MASK;
                case "_MM256_CMPLE_EPU16_MASK": return Intrinsic._MM256_CMPLE_EPU16_MASK;
                case "_MM256_CMPLE_EPU32_MASK": return Intrinsic._MM256_CMPLE_EPU32_MASK;
                case "_MM256_CMPLE_EPU64_MASK": return Intrinsic._MM256_CMPLE_EPU64_MASK;
                case "_MM256_CMPLE_EPU8_MASK": return Intrinsic._MM256_CMPLE_EPU8_MASK;
                case "_MM256_CMPLT_EPI16_MASK": return Intrinsic._MM256_CMPLT_EPI16_MASK;
                case "_MM256_CMPLT_EPI32_MASK": return Intrinsic._MM256_CMPLT_EPI32_MASK;
                case "_MM256_CMPLT_EPI64_MASK": return Intrinsic._MM256_CMPLT_EPI64_MASK;
                case "_MM256_CMPLT_EPI8_MASK": return Intrinsic._MM256_CMPLT_EPI8_MASK;
                case "_MM256_CMPLT_EPU16_MASK": return Intrinsic._MM256_CMPLT_EPU16_MASK;
                case "_MM256_CMPLT_EPU32_MASK": return Intrinsic._MM256_CMPLT_EPU32_MASK;
                case "_MM256_CMPLT_EPU64_MASK": return Intrinsic._MM256_CMPLT_EPU64_MASK;
                case "_MM256_CMPLT_EPU8_MASK": return Intrinsic._MM256_CMPLT_EPU8_MASK;
                case "_MM256_CMPNEQ_EPI16_MASK": return Intrinsic._MM256_CMPNEQ_EPI16_MASK;
                case "_MM256_CMPNEQ_EPI32_MASK": return Intrinsic._MM256_CMPNEQ_EPI32_MASK;
                case "_MM256_CMPNEQ_EPI64_MASK": return Intrinsic._MM256_CMPNEQ_EPI64_MASK;
                case "_MM256_CMPNEQ_EPI8_MASK": return Intrinsic._MM256_CMPNEQ_EPI8_MASK;
                case "_MM256_CMPNEQ_EPU16_MASK": return Intrinsic._MM256_CMPNEQ_EPU16_MASK;
                case "_MM256_CMPNEQ_EPU32_MASK": return Intrinsic._MM256_CMPNEQ_EPU32_MASK;
                case "_MM256_CMPNEQ_EPU64_MASK": return Intrinsic._MM256_CMPNEQ_EPU64_MASK;
                case "_MM256_CMPNEQ_EPU8_MASK": return Intrinsic._MM256_CMPNEQ_EPU8_MASK;
                case "_MM256_CONFLICT_EPI32": return Intrinsic._MM256_CONFLICT_EPI32;
                case "_MM256_CONFLICT_EPI64": return Intrinsic._MM256_CONFLICT_EPI64;
                case "_MM256_COS_PD": return Intrinsic._MM256_COS_PD;
                case "_MM256_COS_PS": return Intrinsic._MM256_COS_PS;
                case "_MM256_COSD_PD": return Intrinsic._MM256_COSD_PD;
                case "_MM256_COSD_PS": return Intrinsic._MM256_COSD_PS;
                case "_MM256_COSH_PD": return Intrinsic._MM256_COSH_PD;
                case "_MM256_COSH_PS": return Intrinsic._MM256_COSH_PS;
                case "_MM256_CSQRT_PS": return Intrinsic._MM256_CSQRT_PS;
                case "_MM256_CVTEPI16_EPI32": return Intrinsic._MM256_CVTEPI16_EPI32;
                case "_MM256_CVTEPI16_EPI64": return Intrinsic._MM256_CVTEPI16_EPI64;
                case "_MM256_CVTEPI16_EPI8": return Intrinsic._MM256_CVTEPI16_EPI8;
                case "_MM256_CVTEPI32_EPI16": return Intrinsic._MM256_CVTEPI32_EPI16;
                case "_MM256_CVTEPI32_EPI64": return Intrinsic._MM256_CVTEPI32_EPI64;
                case "_MM256_CVTEPI32_EPI8": return Intrinsic._MM256_CVTEPI32_EPI8;
                case "_MM256_CVTEPI32_PD": return Intrinsic._MM256_CVTEPI32_PD;
                case "_MM256_CVTEPI32_PS": return Intrinsic._MM256_CVTEPI32_PS;
                case "_MM256_CVTEPI64_EPI16": return Intrinsic._MM256_CVTEPI64_EPI16;
                case "_MM256_CVTEPI64_EPI32": return Intrinsic._MM256_CVTEPI64_EPI32;
                case "_MM256_CVTEPI64_EPI8": return Intrinsic._MM256_CVTEPI64_EPI8;
                case "_MM256_CVTEPI64_PD": return Intrinsic._MM256_CVTEPI64_PD;
                case "_MM256_CVTEPI64_PS": return Intrinsic._MM256_CVTEPI64_PS;
                case "_MM256_CVTEPI8_EPI16": return Intrinsic._MM256_CVTEPI8_EPI16;
                case "_MM256_CVTEPI8_EPI32": return Intrinsic._MM256_CVTEPI8_EPI32;
                case "_MM256_CVTEPI8_EPI64": return Intrinsic._MM256_CVTEPI8_EPI64;
                case "_MM256_CVTEPU16_EPI32": return Intrinsic._MM256_CVTEPU16_EPI32;
                case "_MM256_CVTEPU16_EPI64": return Intrinsic._MM256_CVTEPU16_EPI64;
                case "_MM256_CVTEPU32_EPI64": return Intrinsic._MM256_CVTEPU32_EPI64;
                case "_MM256_CVTEPU32_PD": return Intrinsic._MM256_CVTEPU32_PD;
                case "_MM256_CVTEPU64_PD": return Intrinsic._MM256_CVTEPU64_PD;
                case "_MM256_CVTEPU64_PS": return Intrinsic._MM256_CVTEPU64_PS;
                case "_MM256_CVTEPU8_EPI16": return Intrinsic._MM256_CVTEPU8_EPI16;
                case "_MM256_CVTEPU8_EPI32": return Intrinsic._MM256_CVTEPU8_EPI32;
                case "_MM256_CVTEPU8_EPI64": return Intrinsic._MM256_CVTEPU8_EPI64;
                case "_MM256_CVTPD_EPI32": return Intrinsic._MM256_CVTPD_EPI32;
                case "_MM256_CVTPD_EPI64": return Intrinsic._MM256_CVTPD_EPI64;
                case "_MM256_CVTPD_EPU32": return Intrinsic._MM256_CVTPD_EPU32;
                case "_MM256_CVTPD_EPU64": return Intrinsic._MM256_CVTPD_EPU64;
                case "_MM256_CVTPD_PS": return Intrinsic._MM256_CVTPD_PS;
                case "_MM256_CVTPH_PS": return Intrinsic._MM256_CVTPH_PS;
                case "_MM256_CVTPS_EPI32": return Intrinsic._MM256_CVTPS_EPI32;
                case "_MM256_CVTPS_EPI64": return Intrinsic._MM256_CVTPS_EPI64;
                case "_MM256_CVTPS_EPU32": return Intrinsic._MM256_CVTPS_EPU32;
                case "_MM256_CVTPS_EPU64": return Intrinsic._MM256_CVTPS_EPU64;
                case "_MM256_CVTPS_PD": return Intrinsic._MM256_CVTPS_PD;
                case "_MM256_CVTPS_PH": return Intrinsic._MM256_CVTPS_PH;
                case "_MM256_CVTSEPI16_EPI8": return Intrinsic._MM256_CVTSEPI16_EPI8;
                case "_MM256_CVTSEPI32_EPI16": return Intrinsic._MM256_CVTSEPI32_EPI16;
                case "_MM256_CVTSEPI32_EPI8": return Intrinsic._MM256_CVTSEPI32_EPI8;
                case "_MM256_CVTSEPI64_EPI16": return Intrinsic._MM256_CVTSEPI64_EPI16;
                case "_MM256_CVTSEPI64_EPI32": return Intrinsic._MM256_CVTSEPI64_EPI32;
                case "_MM256_CVTSEPI64_EPI8": return Intrinsic._MM256_CVTSEPI64_EPI8;
                case "_MM256_CVTTPD_EPI32": return Intrinsic._MM256_CVTTPD_EPI32;
                case "_MM256_CVTTPD_EPI64": return Intrinsic._MM256_CVTTPD_EPI64;
                case "_MM256_CVTTPD_EPU32": return Intrinsic._MM256_CVTTPD_EPU32;
                case "_MM256_CVTTPD_EPU64": return Intrinsic._MM256_CVTTPD_EPU64;
                case "_MM256_CVTTPS_EPI32": return Intrinsic._MM256_CVTTPS_EPI32;
                case "_MM256_CVTTPS_EPI64": return Intrinsic._MM256_CVTTPS_EPI64;
                case "_MM256_CVTTPS_EPU32": return Intrinsic._MM256_CVTTPS_EPU32;
                case "_MM256_CVTTPS_EPU64": return Intrinsic._MM256_CVTTPS_EPU64;
                case "_MM256_CVTUSEPI16_EPI8": return Intrinsic._MM256_CVTUSEPI16_EPI8;
                case "_MM256_CVTUSEPI32_EPI16": return Intrinsic._MM256_CVTUSEPI32_EPI16;
                case "_MM256_CVTUSEPI32_EPI8": return Intrinsic._MM256_CVTUSEPI32_EPI8;
                case "_MM256_CVTUSEPI64_EPI16": return Intrinsic._MM256_CVTUSEPI64_EPI16;
                case "_MM256_CVTUSEPI64_EPI32": return Intrinsic._MM256_CVTUSEPI64_EPI32;
                case "_MM256_CVTUSEPI64_EPI8": return Intrinsic._MM256_CVTUSEPI64_EPI8;
                case "_MM256_DBSAD_EPU8": return Intrinsic._MM256_DBSAD_EPU8;
                case "_MM256_DIV_EPI16": return Intrinsic._MM256_DIV_EPI16;
                case "_MM256_DIV_EPI32": return Intrinsic._MM256_DIV_EPI32;
                case "_MM256_DIV_EPI64": return Intrinsic._MM256_DIV_EPI64;
                case "_MM256_DIV_EPI8": return Intrinsic._MM256_DIV_EPI8;
                case "_MM256_DIV_EPU16": return Intrinsic._MM256_DIV_EPU16;
                case "_MM256_DIV_EPU32": return Intrinsic._MM256_DIV_EPU32;
                case "_MM256_DIV_EPU64": return Intrinsic._MM256_DIV_EPU64;
                case "_MM256_DIV_EPU8": return Intrinsic._MM256_DIV_EPU8;
                case "_MM256_DIV_PD": return Intrinsic._MM256_DIV_PD;
                case "_MM256_DIV_PS": return Intrinsic._MM256_DIV_PS;
                case "_MM256_DP_PS": return Intrinsic._MM256_DP_PS;
                case "_MM256_ERF_PD": return Intrinsic._MM256_ERF_PD;
                case "_MM256_ERF_PS": return Intrinsic._MM256_ERF_PS;
                case "_MM256_ERFC_PD": return Intrinsic._MM256_ERFC_PD;
                case "_MM256_ERFC_PS": return Intrinsic._MM256_ERFC_PS;
                case "_MM256_ERFCINV_PD": return Intrinsic._MM256_ERFCINV_PD;
                case "_MM256_ERFCINV_PS": return Intrinsic._MM256_ERFCINV_PS;
                case "_MM256_ERFINV_PD": return Intrinsic._MM256_ERFINV_PD;
                case "_MM256_ERFINV_PS": return Intrinsic._MM256_ERFINV_PS;
                case "_MM256_EXP_PD": return Intrinsic._MM256_EXP_PD;
                case "_MM256_EXP_PS": return Intrinsic._MM256_EXP_PS;
                case "_MM256_EXP10_PD": return Intrinsic._MM256_EXP10_PD;
                case "_MM256_EXP10_PS": return Intrinsic._MM256_EXP10_PS;
                case "_MM256_EXP2_PD": return Intrinsic._MM256_EXP2_PD;
                case "_MM256_EXP2_PS": return Intrinsic._MM256_EXP2_PS;
                case "_MM256_EXPM1_PD": return Intrinsic._MM256_EXPM1_PD;
                case "_MM256_EXPM1_PS": return Intrinsic._MM256_EXPM1_PS;
                case "_MM256_EXTRACT_EPI16": return Intrinsic._MM256_EXTRACT_EPI16;
                case "_MM256_EXTRACT_EPI32": return Intrinsic._MM256_EXTRACT_EPI32;
                case "_MM256_EXTRACT_EPI64": return Intrinsic._MM256_EXTRACT_EPI64;
                case "_MM256_EXTRACT_EPI8": return Intrinsic._MM256_EXTRACT_EPI8;
                case "_MM256_EXTRACTF128_PD": return Intrinsic._MM256_EXTRACTF128_PD;
                case "_MM256_EXTRACTF128_PS": return Intrinsic._MM256_EXTRACTF128_PS;
                case "_MM256_EXTRACTF128_SI256": return Intrinsic._MM256_EXTRACTF128_SI256;
                case "_MM256_EXTRACTF32X4_PS": return Intrinsic._MM256_EXTRACTF32X4_PS;
                case "_MM256_EXTRACTF64X2_PD": return Intrinsic._MM256_EXTRACTF64X2_PD;
                case "_MM256_EXTRACTI128_SI256": return Intrinsic._MM256_EXTRACTI128_SI256;
                case "_MM256_EXTRACTI32X4_EPI32": return Intrinsic._MM256_EXTRACTI32X4_EPI32;
                case "_MM256_EXTRACTI64X2_EPI64": return Intrinsic._MM256_EXTRACTI64X2_EPI64;
                case "_MM256_FIXUPIMM_PD": return Intrinsic._MM256_FIXUPIMM_PD;
                case "_MM256_FIXUPIMM_PS": return Intrinsic._MM256_FIXUPIMM_PS;
                case "_MM256_FLOOR_PD": return Intrinsic._MM256_FLOOR_PD;
                case "_MM256_FLOOR_PS": return Intrinsic._MM256_FLOOR_PS;
                case "_MM256_FMADD_PD": return Intrinsic._MM256_FMADD_PD;
                case "_MM256_FMADD_PS": return Intrinsic._MM256_FMADD_PS;
                case "_MM256_FMADDSUB_PD": return Intrinsic._MM256_FMADDSUB_PD;
                case "_MM256_FMADDSUB_PS": return Intrinsic._MM256_FMADDSUB_PS;
                case "_MM256_FMSUB_PD": return Intrinsic._MM256_FMSUB_PD;
                case "_MM256_FMSUB_PS": return Intrinsic._MM256_FMSUB_PS;
                case "_MM256_FMSUBADD_PD": return Intrinsic._MM256_FMSUBADD_PD;
                case "_MM256_FMSUBADD_PS": return Intrinsic._MM256_FMSUBADD_PS;
                case "_MM256_FNMADD_PD": return Intrinsic._MM256_FNMADD_PD;
                case "_MM256_FNMADD_PS": return Intrinsic._MM256_FNMADD_PS;
                case "_MM256_FNMSUB_PD": return Intrinsic._MM256_FNMSUB_PD;
                case "_MM256_FNMSUB_PS": return Intrinsic._MM256_FNMSUB_PS;
                case "_MM256_FPCLASS_PD_MASK": return Intrinsic._MM256_FPCLASS_PD_MASK;
                case "_MM256_FPCLASS_PS_MASK": return Intrinsic._MM256_FPCLASS_PS_MASK;
                case "_MM256_GETEXP_PD": return Intrinsic._MM256_GETEXP_PD;
                case "_MM256_GETEXP_PS": return Intrinsic._MM256_GETEXP_PS;
                case "_MM256_GETMANT_PD": return Intrinsic._MM256_GETMANT_PD;
                case "_MM256_GETMANT_PS": return Intrinsic._MM256_GETMANT_PS;
                case "_MM256_HADD_EPI16": return Intrinsic._MM256_HADD_EPI16;
                case "_MM256_HADD_EPI32": return Intrinsic._MM256_HADD_EPI32;
                case "_MM256_HADD_PD": return Intrinsic._MM256_HADD_PD;
                case "_MM256_HADD_PS": return Intrinsic._MM256_HADD_PS;
                case "_MM256_HADDS_EPI16": return Intrinsic._MM256_HADDS_EPI16;
                case "_MM256_HSUB_EPI16": return Intrinsic._MM256_HSUB_EPI16;
                case "_MM256_HSUB_EPI32": return Intrinsic._MM256_HSUB_EPI32;
                case "_MM256_HSUB_PD": return Intrinsic._MM256_HSUB_PD;
                case "_MM256_HSUB_PS": return Intrinsic._MM256_HSUB_PS;
                case "_MM256_HSUBS_EPI16": return Intrinsic._MM256_HSUBS_EPI16;
                case "_MM256_HYPOT_PD": return Intrinsic._MM256_HYPOT_PD;
                case "_MM256_HYPOT_PS": return Intrinsic._MM256_HYPOT_PS;
                case "_MM256_I32GATHER_EPI32": return Intrinsic._MM256_I32GATHER_EPI32;
                case "_MM256_I32GATHER_EPI64": return Intrinsic._MM256_I32GATHER_EPI64;
                case "_MM256_I32GATHER_PD": return Intrinsic._MM256_I32GATHER_PD;
                case "_MM256_I32GATHER_PS": return Intrinsic._MM256_I32GATHER_PS;
                case "_MM256_I32SCATTER_EPI32": return Intrinsic._MM256_I32SCATTER_EPI32;
                case "_MM256_I32SCATTER_EPI64": return Intrinsic._MM256_I32SCATTER_EPI64;
                case "_MM256_I32SCATTER_PD": return Intrinsic._MM256_I32SCATTER_PD;
                case "_MM256_I32SCATTER_PS": return Intrinsic._MM256_I32SCATTER_PS;
                case "_MM256_I64GATHER_EPI32": return Intrinsic._MM256_I64GATHER_EPI32;
                case "_MM256_I64GATHER_EPI64": return Intrinsic._MM256_I64GATHER_EPI64;
                case "_MM256_I64GATHER_PD": return Intrinsic._MM256_I64GATHER_PD;
                case "_MM256_I64GATHER_PS": return Intrinsic._MM256_I64GATHER_PS;
                case "_MM256_I64SCATTER_EPI32": return Intrinsic._MM256_I64SCATTER_EPI32;
                case "_MM256_I64SCATTER_EPI64": return Intrinsic._MM256_I64SCATTER_EPI64;
                case "_MM256_I64SCATTER_PD": return Intrinsic._MM256_I64SCATTER_PD;
                case "_MM256_I64SCATTER_PS": return Intrinsic._MM256_I64SCATTER_PS;
                case "_MM256_IDIV_EPI32": return Intrinsic._MM256_IDIV_EPI32;
                case "_MM256_IDIVREM_EPI32": return Intrinsic._MM256_IDIVREM_EPI32;
                case "_MM256_INSERT_EPI16": return Intrinsic._MM256_INSERT_EPI16;
                case "_MM256_INSERT_EPI32": return Intrinsic._MM256_INSERT_EPI32;
                case "_MM256_INSERT_EPI64": return Intrinsic._MM256_INSERT_EPI64;
                case "_MM256_INSERT_EPI8": return Intrinsic._MM256_INSERT_EPI8;
                case "_MM256_INSERTF128_PD": return Intrinsic._MM256_INSERTF128_PD;
                case "_MM256_INSERTF128_PS": return Intrinsic._MM256_INSERTF128_PS;
                case "_MM256_INSERTF128_SI256": return Intrinsic._MM256_INSERTF128_SI256;
                case "_MM256_INSERTF32X4": return Intrinsic._MM256_INSERTF32X4;
                case "_MM256_INSERTF64X2": return Intrinsic._MM256_INSERTF64X2;
                case "_MM256_INSERTI128_SI256": return Intrinsic._MM256_INSERTI128_SI256;
                case "_MM256_INSERTI32X4": return Intrinsic._MM256_INSERTI32X4;
                case "_MM256_INSERTI64X2": return Intrinsic._MM256_INSERTI64X2;
                case "_MM256_INVCBRT_PD": return Intrinsic._MM256_INVCBRT_PD;
                case "_MM256_INVCBRT_PS": return Intrinsic._MM256_INVCBRT_PS;
                case "_MM256_INVSQRT_PD": return Intrinsic._MM256_INVSQRT_PD;
                case "_MM256_INVSQRT_PS": return Intrinsic._MM256_INVSQRT_PS;
                case "_MM256_IREM_EPI32": return Intrinsic._MM256_IREM_EPI32;
                case "_MM256_LDDQU_SI256": return Intrinsic._MM256_LDDQU_SI256;
                case "_MM256_LOAD_PD": return Intrinsic._MM256_LOAD_PD;
                case "_MM256_LOAD_PS": return Intrinsic._MM256_LOAD_PS;
                case "_MM256_LOAD_SI256": return Intrinsic._MM256_LOAD_SI256;
                case "_MM256_LOADU_PD": return Intrinsic._MM256_LOADU_PD;
                case "_MM256_LOADU_PS": return Intrinsic._MM256_LOADU_PS;
                case "_MM256_LOADU_SI256": return Intrinsic._MM256_LOADU_SI256;
                case "_MM256_LOADU2_M128": return Intrinsic._MM256_LOADU2_M128;
                case "_MM256_LOADU2_M128D": return Intrinsic._MM256_LOADU2_M128D;
                case "_MM256_LOADU2_M128I": return Intrinsic._MM256_LOADU2_M128I;
                case "_MM256_LOG_PD": return Intrinsic._MM256_LOG_PD;
                case "_MM256_LOG_PS": return Intrinsic._MM256_LOG_PS;
                case "_MM256_LOG10_PD": return Intrinsic._MM256_LOG10_PD;
                case "_MM256_LOG10_PS": return Intrinsic._MM256_LOG10_PS;
                case "_MM256_LOG1P_PD": return Intrinsic._MM256_LOG1P_PD;
                case "_MM256_LOG1P_PS": return Intrinsic._MM256_LOG1P_PS;
                case "_MM256_LOG2_PD": return Intrinsic._MM256_LOG2_PD;
                case "_MM256_LOG2_PS": return Intrinsic._MM256_LOG2_PS;
                case "_MM256_LOGB_PD": return Intrinsic._MM256_LOGB_PD;
                case "_MM256_LOGB_PS": return Intrinsic._MM256_LOGB_PS;
                case "_MM256_LZCNT_EPI32": return Intrinsic._MM256_LZCNT_EPI32;
                case "_MM256_LZCNT_EPI64": return Intrinsic._MM256_LZCNT_EPI64;
                case "_MM256_MADD_EPI16": return Intrinsic._MM256_MADD_EPI16;
                case "_MM256_MADD52HI_EPU64": return Intrinsic._MM256_MADD52HI_EPU64;
                case "_MM256_MADD52LO_EPU64": return Intrinsic._MM256_MADD52LO_EPU64;
                case "_MM256_MADDUBS_EPI16": return Intrinsic._MM256_MADDUBS_EPI16;
                case "_MM256_MASK_ABS_EPI16": return Intrinsic._MM256_MASK_ABS_EPI16;
                case "_MM256_MASK_ABS_EPI32": return Intrinsic._MM256_MASK_ABS_EPI32;
                case "_MM256_MASK_ABS_EPI64": return Intrinsic._MM256_MASK_ABS_EPI64;
                case "_MM256_MASK_ABS_EPI8": return Intrinsic._MM256_MASK_ABS_EPI8;
                case "_MM256_MASK_ADD_EPI16": return Intrinsic._MM256_MASK_ADD_EPI16;
                case "_MM256_MASK_ADD_EPI32": return Intrinsic._MM256_MASK_ADD_EPI32;
                case "_MM256_MASK_ADD_EPI64": return Intrinsic._MM256_MASK_ADD_EPI64;
                case "_MM256_MASK_ADD_EPI8": return Intrinsic._MM256_MASK_ADD_EPI8;
                case "_MM256_MASK_ADD_PD": return Intrinsic._MM256_MASK_ADD_PD;
                case "_MM256_MASK_ADD_PS": return Intrinsic._MM256_MASK_ADD_PS;
                case "_MM256_MASK_ADDS_EPI16": return Intrinsic._MM256_MASK_ADDS_EPI16;
                case "_MM256_MASK_ADDS_EPI8": return Intrinsic._MM256_MASK_ADDS_EPI8;
                case "_MM256_MASK_ADDS_EPU16": return Intrinsic._MM256_MASK_ADDS_EPU16;
                case "_MM256_MASK_ADDS_EPU8": return Intrinsic._MM256_MASK_ADDS_EPU8;
                case "_MM256_MASK_ALIGNR_EPI32": return Intrinsic._MM256_MASK_ALIGNR_EPI32;
                case "_MM256_MASK_ALIGNR_EPI64": return Intrinsic._MM256_MASK_ALIGNR_EPI64;
                case "_MM256_MASK_ALIGNR_EPI8": return Intrinsic._MM256_MASK_ALIGNR_EPI8;
                case "_MM256_MASK_AND_EPI32": return Intrinsic._MM256_MASK_AND_EPI32;
                case "_MM256_MASK_AND_EPI64": return Intrinsic._MM256_MASK_AND_EPI64;
                case "_MM256_MASK_AND_PD": return Intrinsic._MM256_MASK_AND_PD;
                case "_MM256_MASK_AND_PS": return Intrinsic._MM256_MASK_AND_PS;
                case "_MM256_MASK_ANDNOT_EPI32": return Intrinsic._MM256_MASK_ANDNOT_EPI32;
                case "_MM256_MASK_ANDNOT_EPI64": return Intrinsic._MM256_MASK_ANDNOT_EPI64;
                case "_MM256_MASK_ANDNOT_PD": return Intrinsic._MM256_MASK_ANDNOT_PD;
                case "_MM256_MASK_ANDNOT_PS": return Intrinsic._MM256_MASK_ANDNOT_PS;
                case "_MM256_MASK_AVG_EPU16": return Intrinsic._MM256_MASK_AVG_EPU16;
                case "_MM256_MASK_AVG_EPU8": return Intrinsic._MM256_MASK_AVG_EPU8;
                case "_MM256_MASK_BLEND_EPI16": return Intrinsic._MM256_MASK_BLEND_EPI16;
                case "_MM256_MASK_BLEND_EPI32": return Intrinsic._MM256_MASK_BLEND_EPI32;
                case "_MM256_MASK_BLEND_EPI64": return Intrinsic._MM256_MASK_BLEND_EPI64;
                case "_MM256_MASK_BLEND_EPI8": return Intrinsic._MM256_MASK_BLEND_EPI8;
                case "_MM256_MASK_BLEND_PD": return Intrinsic._MM256_MASK_BLEND_PD;
                case "_MM256_MASK_BLEND_PS": return Intrinsic._MM256_MASK_BLEND_PS;
                case "_MM256_MASK_BROADCAST_F32X2": return Intrinsic._MM256_MASK_BROADCAST_F32X2;
                case "_MM256_MASK_BROADCAST_F32X4": return Intrinsic._MM256_MASK_BROADCAST_F32X4;
                case "_MM256_MASK_BROADCAST_F64X2": return Intrinsic._MM256_MASK_BROADCAST_F64X2;
                case "_MM256_MASK_BROADCAST_I32X2": return Intrinsic._MM256_MASK_BROADCAST_I32X2;
                case "_MM256_MASK_BROADCAST_I32X4": return Intrinsic._MM256_MASK_BROADCAST_I32X4;
                case "_MM256_MASK_BROADCAST_I64X2": return Intrinsic._MM256_MASK_BROADCAST_I64X2;
                case "_MM256_MASK_BROADCASTB_EPI8": return Intrinsic._MM256_MASK_BROADCASTB_EPI8;
                case "_MM256_MASK_BROADCASTD_EPI32": return Intrinsic._MM256_MASK_BROADCASTD_EPI32;
                case "_MM256_MASK_BROADCASTQ_EPI64": return Intrinsic._MM256_MASK_BROADCASTQ_EPI64;
                case "_MM256_MASK_BROADCASTSD_PD": return Intrinsic._MM256_MASK_BROADCASTSD_PD;
                case "_MM256_MASK_BROADCASTSS_PS": return Intrinsic._MM256_MASK_BROADCASTSS_PS;
                case "_MM256_MASK_BROADCASTW_EPI16": return Intrinsic._MM256_MASK_BROADCASTW_EPI16;
                case "_MM256_MASK_CMP_EPI16_MASK": return Intrinsic._MM256_MASK_CMP_EPI16_MASK;
                case "_MM256_MASK_CMP_EPI32_MASK": return Intrinsic._MM256_MASK_CMP_EPI32_MASK;
                case "_MM256_MASK_CMP_EPI64_MASK": return Intrinsic._MM256_MASK_CMP_EPI64_MASK;
                case "_MM256_MASK_CMP_EPI8_MASK": return Intrinsic._MM256_MASK_CMP_EPI8_MASK;
                case "_MM256_MASK_CMP_EPU16_MASK": return Intrinsic._MM256_MASK_CMP_EPU16_MASK;
                case "_MM256_MASK_CMP_EPU32_MASK": return Intrinsic._MM256_MASK_CMP_EPU32_MASK;
                case "_MM256_MASK_CMP_EPU64_MASK": return Intrinsic._MM256_MASK_CMP_EPU64_MASK;
                case "_MM256_MASK_CMP_EPU8_MASK": return Intrinsic._MM256_MASK_CMP_EPU8_MASK;
                case "_MM256_MASK_CMP_PD_MASK": return Intrinsic._MM256_MASK_CMP_PD_MASK;
                case "_MM256_MASK_CMP_PS_MASK": return Intrinsic._MM256_MASK_CMP_PS_MASK;
                case "_MM256_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI16_MASK;
                case "_MM256_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI32_MASK;
                case "_MM256_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI64_MASK;
                case "_MM256_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPI8_MASK;
                case "_MM256_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU16_MASK;
                case "_MM256_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU32_MASK;
                case "_MM256_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU64_MASK;
                case "_MM256_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM256_MASK_CMPEQ_EPU8_MASK;
                case "_MM256_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI16_MASK;
                case "_MM256_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI32_MASK;
                case "_MM256_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI64_MASK;
                case "_MM256_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM256_MASK_CMPGE_EPI8_MASK;
                case "_MM256_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU16_MASK;
                case "_MM256_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU32_MASK;
                case "_MM256_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU64_MASK;
                case "_MM256_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM256_MASK_CMPGE_EPU8_MASK;
                case "_MM256_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI16_MASK;
                case "_MM256_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI32_MASK;
                case "_MM256_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI64_MASK;
                case "_MM256_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM256_MASK_CMPGT_EPI8_MASK;
                case "_MM256_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU16_MASK;
                case "_MM256_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU32_MASK;
                case "_MM256_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU64_MASK;
                case "_MM256_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM256_MASK_CMPGT_EPU8_MASK;
                case "_MM256_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI16_MASK;
                case "_MM256_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI32_MASK;
                case "_MM256_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI64_MASK;
                case "_MM256_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM256_MASK_CMPLE_EPI8_MASK;
                case "_MM256_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU16_MASK;
                case "_MM256_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU32_MASK;
                case "_MM256_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU64_MASK;
                case "_MM256_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM256_MASK_CMPLE_EPU8_MASK;
                case "_MM256_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI16_MASK;
                case "_MM256_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI32_MASK;
                case "_MM256_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI64_MASK;
                case "_MM256_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM256_MASK_CMPLT_EPI8_MASK;
                case "_MM256_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU16_MASK;
                case "_MM256_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU32_MASK;
                case "_MM256_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU64_MASK;
                case "_MM256_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM256_MASK_CMPLT_EPU8_MASK;
                case "_MM256_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI16_MASK;
                case "_MM256_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI32_MASK;
                case "_MM256_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI64_MASK;
                case "_MM256_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPI8_MASK;
                case "_MM256_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU16_MASK;
                case "_MM256_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU32_MASK;
                case "_MM256_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU64_MASK;
                case "_MM256_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM256_MASK_CMPNEQ_EPU8_MASK;
                case "_MM256_MASK_COMPRESS_EPI32": return Intrinsic._MM256_MASK_COMPRESS_EPI32;
                case "_MM256_MASK_COMPRESS_EPI64": return Intrinsic._MM256_MASK_COMPRESS_EPI64;
                case "_MM256_MASK_COMPRESS_PD": return Intrinsic._MM256_MASK_COMPRESS_PD;
                case "_MM256_MASK_COMPRESS_PS": return Intrinsic._MM256_MASK_COMPRESS_PS;
                case "_MM256_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM256_MASK_COMPRESSSTOREU_EPI32;
                case "_MM256_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM256_MASK_COMPRESSSTOREU_EPI64;
                case "_MM256_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM256_MASK_COMPRESSSTOREU_PD;
                case "_MM256_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM256_MASK_COMPRESSSTOREU_PS;
                case "_MM256_MASK_CONFLICT_EPI32": return Intrinsic._MM256_MASK_CONFLICT_EPI32;
                case "_MM256_MASK_CONFLICT_EPI64": return Intrinsic._MM256_MASK_CONFLICT_EPI64;
                case "_MM256_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM256_MASK_CVT_ROUNDPS_PH;
                case "_MM256_MASK_CVTEPI16_EPI32": return Intrinsic._MM256_MASK_CVTEPI16_EPI32;
                case "_MM256_MASK_CVTEPI16_EPI64": return Intrinsic._MM256_MASK_CVTEPI16_EPI64;
                case "_MM256_MASK_CVTEPI16_EPI8": return Intrinsic._MM256_MASK_CVTEPI16_EPI8;
                case "_MM256_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI32_EPI16": return Intrinsic._MM256_MASK_CVTEPI32_EPI16;
                case "_MM256_MASK_CVTEPI32_EPI64": return Intrinsic._MM256_MASK_CVTEPI32_EPI64;
                case "_MM256_MASK_CVTEPI32_EPI8": return Intrinsic._MM256_MASK_CVTEPI32_EPI8;
                case "_MM256_MASK_CVTEPI32_PD": return Intrinsic._MM256_MASK_CVTEPI32_PD;
                case "_MM256_MASK_CVTEPI32_PS": return Intrinsic._MM256_MASK_CVTEPI32_PS;
                case "_MM256_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI64_EPI16": return Intrinsic._MM256_MASK_CVTEPI64_EPI16;
                case "_MM256_MASK_CVTEPI64_EPI32": return Intrinsic._MM256_MASK_CVTEPI64_EPI32;
                case "_MM256_MASK_CVTEPI64_EPI8": return Intrinsic._MM256_MASK_CVTEPI64_EPI8;
                case "_MM256_MASK_CVTEPI64_PD": return Intrinsic._MM256_MASK_CVTEPI64_PD;
                case "_MM256_MASK_CVTEPI64_PS": return Intrinsic._MM256_MASK_CVTEPI64_PS;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM256_MASK_CVTEPI8_EPI16": return Intrinsic._MM256_MASK_CVTEPI8_EPI16;
                case "_MM256_MASK_CVTEPI8_EPI32": return Intrinsic._MM256_MASK_CVTEPI8_EPI32;
                case "_MM256_MASK_CVTEPI8_EPI64": return Intrinsic._MM256_MASK_CVTEPI8_EPI64;
                case "_MM256_MASK_CVTEPU16_EPI32": return Intrinsic._MM256_MASK_CVTEPU16_EPI32;
                case "_MM256_MASK_CVTEPU16_EPI64": return Intrinsic._MM256_MASK_CVTEPU16_EPI64;
                case "_MM256_MASK_CVTEPU32_EPI64": return Intrinsic._MM256_MASK_CVTEPU32_EPI64;
                case "_MM256_MASK_CVTEPU32_PD": return Intrinsic._MM256_MASK_CVTEPU32_PD;
                case "_MM256_MASK_CVTEPU64_PD": return Intrinsic._MM256_MASK_CVTEPU64_PD;
                case "_MM256_MASK_CVTEPU64_PS": return Intrinsic._MM256_MASK_CVTEPU64_PS;
                case "_MM256_MASK_CVTEPU8_EPI16": return Intrinsic._MM256_MASK_CVTEPU8_EPI16;
                case "_MM256_MASK_CVTEPU8_EPI32": return Intrinsic._MM256_MASK_CVTEPU8_EPI32;
                case "_MM256_MASK_CVTEPU8_EPI64": return Intrinsic._MM256_MASK_CVTEPU8_EPI64;
                case "_MM256_MASK_CVTPD_EPI32": return Intrinsic._MM256_MASK_CVTPD_EPI32;
                case "_MM256_MASK_CVTPD_EPI64": return Intrinsic._MM256_MASK_CVTPD_EPI64;
                case "_MM256_MASK_CVTPD_EPU32": return Intrinsic._MM256_MASK_CVTPD_EPU32;
                case "_MM256_MASK_CVTPD_EPU64": return Intrinsic._MM256_MASK_CVTPD_EPU64;
                case "_MM256_MASK_CVTPD_PS": return Intrinsic._MM256_MASK_CVTPD_PS;
                case "_MM256_MASK_CVTPH_PS": return Intrinsic._MM256_MASK_CVTPH_PS;
                case "_MM256_MASK_CVTPS_EPI32": return Intrinsic._MM256_MASK_CVTPS_EPI32;
                case "_MM256_MASK_CVTPS_EPI64": return Intrinsic._MM256_MASK_CVTPS_EPI64;
                case "_MM256_MASK_CVTPS_EPU32": return Intrinsic._MM256_MASK_CVTPS_EPU32;
                case "_MM256_MASK_CVTPS_EPU64": return Intrinsic._MM256_MASK_CVTPS_EPU64;
                case "_MM256_MASK_CVTPS_PH": return Intrinsic._MM256_MASK_CVTPS_PH;
                case "_MM256_MASK_CVTSEPI16_EPI8": return Intrinsic._MM256_MASK_CVTSEPI16_EPI8;
                case "_MM256_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTSEPI32_EPI16": return Intrinsic._MM256_MASK_CVTSEPI32_EPI16;
                case "_MM256_MASK_CVTSEPI32_EPI8": return Intrinsic._MM256_MASK_CVTSEPI32_EPI8;
                case "_MM256_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTSEPI64_EPI16": return Intrinsic._MM256_MASK_CVTSEPI64_EPI16;
                case "_MM256_MASK_CVTSEPI64_EPI32": return Intrinsic._MM256_MASK_CVTSEPI64_EPI32;
                case "_MM256_MASK_CVTSEPI64_EPI8": return Intrinsic._MM256_MASK_CVTSEPI64_EPI8;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTSEPI64_STOREU_EPI8;
                case "_MM256_MASK_CVTTPD_EPI32": return Intrinsic._MM256_MASK_CVTTPD_EPI32;
                case "_MM256_MASK_CVTTPD_EPI64": return Intrinsic._MM256_MASK_CVTTPD_EPI64;
                case "_MM256_MASK_CVTTPD_EPU32": return Intrinsic._MM256_MASK_CVTTPD_EPU32;
                case "_MM256_MASK_CVTTPD_EPU64": return Intrinsic._MM256_MASK_CVTTPD_EPU64;
                case "_MM256_MASK_CVTTPS_EPI32": return Intrinsic._MM256_MASK_CVTTPS_EPI32;
                case "_MM256_MASK_CVTTPS_EPI64": return Intrinsic._MM256_MASK_CVTTPS_EPI64;
                case "_MM256_MASK_CVTTPS_EPU32": return Intrinsic._MM256_MASK_CVTTPS_EPU32;
                case "_MM256_MASK_CVTTPS_EPU64": return Intrinsic._MM256_MASK_CVTTPS_EPU64;
                case "_MM256_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI16_EPI8;
                case "_MM256_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM256_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI32_EPI16;
                case "_MM256_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI32_EPI8;
                case "_MM256_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM256_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM256_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI16;
                case "_MM256_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI32;
                case "_MM256_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI64_EPI8;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM256_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM256_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM256_MASK_DBSAD_EPU8": return Intrinsic._MM256_MASK_DBSAD_EPU8;
                case "_MM256_MASK_DIV_PD": return Intrinsic._MM256_MASK_DIV_PD;
                case "_MM256_MASK_DIV_PS": return Intrinsic._MM256_MASK_DIV_PS;
                case "_MM256_MASK_EXPAND_EPI32": return Intrinsic._MM256_MASK_EXPAND_EPI32;
                case "_MM256_MASK_EXPAND_EPI64": return Intrinsic._MM256_MASK_EXPAND_EPI64;
                case "_MM256_MASK_EXPAND_PD": return Intrinsic._MM256_MASK_EXPAND_PD;
                case "_MM256_MASK_EXPAND_PS": return Intrinsic._MM256_MASK_EXPAND_PS;
                case "_MM256_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM256_MASK_EXPANDLOADU_EPI32;
                case "_MM256_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM256_MASK_EXPANDLOADU_EPI64;
                case "_MM256_MASK_EXPANDLOADU_PD": return Intrinsic._MM256_MASK_EXPANDLOADU_PD;
                case "_MM256_MASK_EXPANDLOADU_PS": return Intrinsic._MM256_MASK_EXPANDLOADU_PS;
                case "_MM256_MASK_EXTRACTF32X4_PS": return Intrinsic._MM256_MASK_EXTRACTF32X4_PS;
                case "_MM256_MASK_EXTRACTF64X2_PD": return Intrinsic._MM256_MASK_EXTRACTF64X2_PD;
                case "_MM256_MASK_EXTRACTI32X4_EPI32": return Intrinsic._MM256_MASK_EXTRACTI32X4_EPI32;
                case "_MM256_MASK_EXTRACTI64X2_EPI64": return Intrinsic._MM256_MASK_EXTRACTI64X2_EPI64;
                case "_MM256_MASK_FIXUPIMM_PD": return Intrinsic._MM256_MASK_FIXUPIMM_PD;
                case "_MM256_MASK_FIXUPIMM_PS": return Intrinsic._MM256_MASK_FIXUPIMM_PS;
                case "_MM256_MASK_FMADD_PD": return Intrinsic._MM256_MASK_FMADD_PD;
                case "_MM256_MASK_FMADD_PS": return Intrinsic._MM256_MASK_FMADD_PS;
                case "_MM256_MASK_FMADDSUB_PD": return Intrinsic._MM256_MASK_FMADDSUB_PD;
                case "_MM256_MASK_FMADDSUB_PS": return Intrinsic._MM256_MASK_FMADDSUB_PS;
                case "_MM256_MASK_FMSUB_PD": return Intrinsic._MM256_MASK_FMSUB_PD;
                case "_MM256_MASK_FMSUB_PS": return Intrinsic._MM256_MASK_FMSUB_PS;
                case "_MM256_MASK_FMSUBADD_PD": return Intrinsic._MM256_MASK_FMSUBADD_PD;
                case "_MM256_MASK_FMSUBADD_PS": return Intrinsic._MM256_MASK_FMSUBADD_PS;
                case "_MM256_MASK_FNMADD_PD": return Intrinsic._MM256_MASK_FNMADD_PD;
                case "_MM256_MASK_FNMADD_PS": return Intrinsic._MM256_MASK_FNMADD_PS;
                case "_MM256_MASK_FNMSUB_PD": return Intrinsic._MM256_MASK_FNMSUB_PD;
                case "_MM256_MASK_FNMSUB_PS": return Intrinsic._MM256_MASK_FNMSUB_PS;
                case "_MM256_MASK_FPCLASS_PD_MASK": return Intrinsic._MM256_MASK_FPCLASS_PD_MASK;
                case "_MM256_MASK_FPCLASS_PS_MASK": return Intrinsic._MM256_MASK_FPCLASS_PS_MASK;
                case "_MM256_MASK_GETEXP_PD": return Intrinsic._MM256_MASK_GETEXP_PD;
                case "_MM256_MASK_GETEXP_PS": return Intrinsic._MM256_MASK_GETEXP_PS;
                case "_MM256_MASK_GETMANT_PD": return Intrinsic._MM256_MASK_GETMANT_PD;
                case "_MM256_MASK_GETMANT_PS": return Intrinsic._MM256_MASK_GETMANT_PS;
                case "_MM256_MASK_I32GATHER_EPI32": return Intrinsic._MM256_MASK_I32GATHER_EPI32;
                case "_MM256_MASK_I32GATHER_EPI64": return Intrinsic._MM256_MASK_I32GATHER_EPI64;
                case "_MM256_MASK_I32GATHER_PD": return Intrinsic._MM256_MASK_I32GATHER_PD;
                case "_MM256_MASK_I32GATHER_PS": return Intrinsic._MM256_MASK_I32GATHER_PS;
                case "_MM256_MASK_I32SCATTER_EPI32": return Intrinsic._MM256_MASK_I32SCATTER_EPI32;
                case "_MM256_MASK_I32SCATTER_EPI64": return Intrinsic._MM256_MASK_I32SCATTER_EPI64;
                case "_MM256_MASK_I32SCATTER_PD": return Intrinsic._MM256_MASK_I32SCATTER_PD;
                case "_MM256_MASK_I32SCATTER_PS": return Intrinsic._MM256_MASK_I32SCATTER_PS;
                case "_MM256_MASK_I64GATHER_EPI32": return Intrinsic._MM256_MASK_I64GATHER_EPI32;
                case "_MM256_MASK_I64GATHER_EPI64": return Intrinsic._MM256_MASK_I64GATHER_EPI64;
                case "_MM256_MASK_I64GATHER_PD": return Intrinsic._MM256_MASK_I64GATHER_PD;
                case "_MM256_MASK_I64GATHER_PS": return Intrinsic._MM256_MASK_I64GATHER_PS;
                case "_MM256_MASK_I64SCATTER_EPI32": return Intrinsic._MM256_MASK_I64SCATTER_EPI32;
                case "_MM256_MASK_I64SCATTER_EPI64": return Intrinsic._MM256_MASK_I64SCATTER_EPI64;
                case "_MM256_MASK_I64SCATTER_PD": return Intrinsic._MM256_MASK_I64SCATTER_PD;
                case "_MM256_MASK_I64SCATTER_PS": return Intrinsic._MM256_MASK_I64SCATTER_PS;
                case "_MM256_MASK_INSERTF32X4": return Intrinsic._MM256_MASK_INSERTF32X4;
                case "_MM256_MASK_INSERTF64X2": return Intrinsic._MM256_MASK_INSERTF64X2;
                case "_MM256_MASK_INSERTI32X4": return Intrinsic._MM256_MASK_INSERTI32X4;
                case "_MM256_MASK_INSERTI64X2": return Intrinsic._MM256_MASK_INSERTI64X2;
                case "_MM256_MASK_LOAD_EPI32": return Intrinsic._MM256_MASK_LOAD_EPI32;
                case "_MM256_MASK_LOAD_EPI64": return Intrinsic._MM256_MASK_LOAD_EPI64;
                case "_MM256_MASK_LOAD_PD": return Intrinsic._MM256_MASK_LOAD_PD;
                case "_MM256_MASK_LOAD_PS": return Intrinsic._MM256_MASK_LOAD_PS;
                case "_MM256_MASK_LOADU_EPI16": return Intrinsic._MM256_MASK_LOADU_EPI16;
                case "_MM256_MASK_LOADU_EPI32": return Intrinsic._MM256_MASK_LOADU_EPI32;
                case "_MM256_MASK_LOADU_EPI64": return Intrinsic._MM256_MASK_LOADU_EPI64;
                case "_MM256_MASK_LOADU_EPI8": return Intrinsic._MM256_MASK_LOADU_EPI8;
                case "_MM256_MASK_LOADU_PD": return Intrinsic._MM256_MASK_LOADU_PD;
                case "_MM256_MASK_LOADU_PS": return Intrinsic._MM256_MASK_LOADU_PS;
                case "_MM256_MASK_LZCNT_EPI32": return Intrinsic._MM256_MASK_LZCNT_EPI32;
                case "_MM256_MASK_LZCNT_EPI64": return Intrinsic._MM256_MASK_LZCNT_EPI64;
                case "_MM256_MASK_MADD_EPI16": return Intrinsic._MM256_MASK_MADD_EPI16;
                case "_MM256_MASK_MADD52HI_EPU64": return Intrinsic._MM256_MASK_MADD52HI_EPU64;
                case "_MM256_MASK_MADD52LO_EPU64": return Intrinsic._MM256_MASK_MADD52LO_EPU64;
                case "_MM256_MASK_MADDUBS_EPI16": return Intrinsic._MM256_MASK_MADDUBS_EPI16;
                case "_MM256_MASK_MAX_EPI16": return Intrinsic._MM256_MASK_MAX_EPI16;
                case "_MM256_MASK_MAX_EPI32": return Intrinsic._MM256_MASK_MAX_EPI32;
                case "_MM256_MASK_MAX_EPI64": return Intrinsic._MM256_MASK_MAX_EPI64;
                case "_MM256_MASK_MAX_EPI8": return Intrinsic._MM256_MASK_MAX_EPI8;
                case "_MM256_MASK_MAX_EPU16": return Intrinsic._MM256_MASK_MAX_EPU16;
                case "_MM256_MASK_MAX_EPU32": return Intrinsic._MM256_MASK_MAX_EPU32;
                case "_MM256_MASK_MAX_EPU64": return Intrinsic._MM256_MASK_MAX_EPU64;
                case "_MM256_MASK_MAX_EPU8": return Intrinsic._MM256_MASK_MAX_EPU8;
                case "_MM256_MASK_MAX_PD": return Intrinsic._MM256_MASK_MAX_PD;
                case "_MM256_MASK_MAX_PS": return Intrinsic._MM256_MASK_MAX_PS;
                case "_MM256_MASK_MIN_EPI16": return Intrinsic._MM256_MASK_MIN_EPI16;
                case "_MM256_MASK_MIN_EPI32": return Intrinsic._MM256_MASK_MIN_EPI32;
                case "_MM256_MASK_MIN_EPI64": return Intrinsic._MM256_MASK_MIN_EPI64;
                case "_MM256_MASK_MIN_EPI8": return Intrinsic._MM256_MASK_MIN_EPI8;
                case "_MM256_MASK_MIN_EPU16": return Intrinsic._MM256_MASK_MIN_EPU16;
                case "_MM256_MASK_MIN_EPU32": return Intrinsic._MM256_MASK_MIN_EPU32;
                case "_MM256_MASK_MIN_EPU64": return Intrinsic._MM256_MASK_MIN_EPU64;
                case "_MM256_MASK_MIN_EPU8": return Intrinsic._MM256_MASK_MIN_EPU8;
                case "_MM256_MASK_MIN_PD": return Intrinsic._MM256_MASK_MIN_PD;
                case "_MM256_MASK_MIN_PS": return Intrinsic._MM256_MASK_MIN_PS;
                case "_MM256_MASK_MOV_EPI16": return Intrinsic._MM256_MASK_MOV_EPI16;
                case "_MM256_MASK_MOV_EPI32": return Intrinsic._MM256_MASK_MOV_EPI32;
                case "_MM256_MASK_MOV_EPI64": return Intrinsic._MM256_MASK_MOV_EPI64;
                case "_MM256_MASK_MOV_EPI8": return Intrinsic._MM256_MASK_MOV_EPI8;
                case "_MM256_MASK_MOV_PD": return Intrinsic._MM256_MASK_MOV_PD;
                case "_MM256_MASK_MOV_PS": return Intrinsic._MM256_MASK_MOV_PS;
                case "_MM256_MASK_MOVEDUP_PD": return Intrinsic._MM256_MASK_MOVEDUP_PD;
                case "_MM256_MASK_MOVEHDUP_PS": return Intrinsic._MM256_MASK_MOVEHDUP_PS;
                case "_MM256_MASK_MOVELDUP_PS": return Intrinsic._MM256_MASK_MOVELDUP_PS;
                case "_MM256_MASK_MUL_EPI32": return Intrinsic._MM256_MASK_MUL_EPI32;
                case "_MM256_MASK_MUL_EPU32": return Intrinsic._MM256_MASK_MUL_EPU32;
                case "_MM256_MASK_MUL_PD": return Intrinsic._MM256_MASK_MUL_PD;
                case "_MM256_MASK_MUL_PS": return Intrinsic._MM256_MASK_MUL_PS;
                case "_MM256_MASK_MULHI_EPI16": return Intrinsic._MM256_MASK_MULHI_EPI16;
                case "_MM256_MASK_MULHI_EPU16": return Intrinsic._MM256_MASK_MULHI_EPU16;
                case "_MM256_MASK_MULHRS_EPI16": return Intrinsic._MM256_MASK_MULHRS_EPI16;
                case "_MM256_MASK_MULLO_EPI16": return Intrinsic._MM256_MASK_MULLO_EPI16;
                case "_MM256_MASK_MULLO_EPI32": return Intrinsic._MM256_MASK_MULLO_EPI32;
                case "_MM256_MASK_MULLO_EPI64": return Intrinsic._MM256_MASK_MULLO_EPI64;
                case "_MM256_MASK_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM256_MASK_MULTISHIFT_EPI64_EPI8;
                case "_MM256_MASK_OR_EPI32": return Intrinsic._MM256_MASK_OR_EPI32;
                case "_MM256_MASK_OR_EPI64": return Intrinsic._MM256_MASK_OR_EPI64;
                case "_MM256_MASK_OR_PD": return Intrinsic._MM256_MASK_OR_PD;
                case "_MM256_MASK_OR_PS": return Intrinsic._MM256_MASK_OR_PS;
                case "_MM256_MASK_PACKS_EPI16": return Intrinsic._MM256_MASK_PACKS_EPI16;
                case "_MM256_MASK_PACKS_EPI32": return Intrinsic._MM256_MASK_PACKS_EPI32;
                case "_MM256_MASK_PACKUS_EPI16": return Intrinsic._MM256_MASK_PACKUS_EPI16;
                case "_MM256_MASK_PACKUS_EPI32": return Intrinsic._MM256_MASK_PACKUS_EPI32;
                case "_MM256_MASK_PERMUTE_PD": return Intrinsic._MM256_MASK_PERMUTE_PD;
                case "_MM256_MASK_PERMUTE_PS": return Intrinsic._MM256_MASK_PERMUTE_PS;
                case "_MM256_MASK_PERMUTEVAR_PD": return Intrinsic._MM256_MASK_PERMUTEVAR_PD;
                case "_MM256_MASK_PERMUTEVAR_PS": return Intrinsic._MM256_MASK_PERMUTEVAR_PS;
                case "_MM256_MASK_PERMUTEX_EPI64": return Intrinsic._MM256_MASK_PERMUTEX_EPI64;
                case "_MM256_MASK_PERMUTEX_PD": return Intrinsic._MM256_MASK_PERMUTEX_PD;
                case "_MM256_MASK_PERMUTEX2VAR_EPI16": return Intrinsic._MM256_MASK_PERMUTEX2VAR_EPI16;
                case "_MM256_MASK_PERMUTEX2VAR_EPI32": return Intrinsic._MM256_MASK_PERMUTEX2VAR_EPI32;
                case "_MM256_MASK_PERMUTEX2VAR_EPI64": return Intrinsic._MM256_MASK_PERMUTEX2VAR_EPI64;
                case "_MM256_MASK_PERMUTEX2VAR_EPI8": return Intrinsic._MM256_MASK_PERMUTEX2VAR_EPI8;
                case "_MM256_MASK_PERMUTEX2VAR_PD": return Intrinsic._MM256_MASK_PERMUTEX2VAR_PD;
                case "_MM256_MASK_PERMUTEX2VAR_PS": return Intrinsic._MM256_MASK_PERMUTEX2VAR_PS;
                case "_MM256_MASK_PERMUTEXVAR_EPI16": return Intrinsic._MM256_MASK_PERMUTEXVAR_EPI16;
                case "_MM256_MASK_PERMUTEXVAR_EPI32": return Intrinsic._MM256_MASK_PERMUTEXVAR_EPI32;
                case "_MM256_MASK_PERMUTEXVAR_EPI64": return Intrinsic._MM256_MASK_PERMUTEXVAR_EPI64;
                case "_MM256_MASK_PERMUTEXVAR_EPI8": return Intrinsic._MM256_MASK_PERMUTEXVAR_EPI8;
                case "_MM256_MASK_PERMUTEXVAR_PD": return Intrinsic._MM256_MASK_PERMUTEXVAR_PD;
                case "_MM256_MASK_PERMUTEXVAR_PS": return Intrinsic._MM256_MASK_PERMUTEXVAR_PS;
                case "_MM256_MASK_RANGE_PD": return Intrinsic._MM256_MASK_RANGE_PD;
                case "_MM256_MASK_RANGE_PS": return Intrinsic._MM256_MASK_RANGE_PS;
                case "_MM256_MASK_RCP14_PD": return Intrinsic._MM256_MASK_RCP14_PD;
                case "_MM256_MASK_RCP14_PS": return Intrinsic._MM256_MASK_RCP14_PS;
                case "_MM256_MASK_REDUCE_PD": return Intrinsic._MM256_MASK_REDUCE_PD;
                case "_MM256_MASK_REDUCE_PS": return Intrinsic._MM256_MASK_REDUCE_PS;
                case "_MM256_MASK_ROL_EPI32": return Intrinsic._MM256_MASK_ROL_EPI32;
                case "_MM256_MASK_ROL_EPI64": return Intrinsic._MM256_MASK_ROL_EPI64;
                case "_MM256_MASK_ROLV_EPI32": return Intrinsic._MM256_MASK_ROLV_EPI32;
                case "_MM256_MASK_ROLV_EPI64": return Intrinsic._MM256_MASK_ROLV_EPI64;
                case "_MM256_MASK_ROR_EPI32": return Intrinsic._MM256_MASK_ROR_EPI32;
                case "_MM256_MASK_ROR_EPI64": return Intrinsic._MM256_MASK_ROR_EPI64;
                case "_MM256_MASK_RORV_EPI32": return Intrinsic._MM256_MASK_RORV_EPI32;
                case "_MM256_MASK_RORV_EPI64": return Intrinsic._MM256_MASK_RORV_EPI64;
                case "_MM256_MASK_ROUNDSCALE_PD": return Intrinsic._MM256_MASK_ROUNDSCALE_PD;
                case "_MM256_MASK_ROUNDSCALE_PS": return Intrinsic._MM256_MASK_ROUNDSCALE_PS;
                case "_MM256_MASK_RSQRT14_PD": return Intrinsic._MM256_MASK_RSQRT14_PD;
                case "_MM256_MASK_RSQRT14_PS": return Intrinsic._MM256_MASK_RSQRT14_PS;
                case "_MM256_MASK_SCALEF_PD": return Intrinsic._MM256_MASK_SCALEF_PD;
                case "_MM256_MASK_SCALEF_PS": return Intrinsic._MM256_MASK_SCALEF_PS;
                case "_MM256_MASK_SET1_EPI16": return Intrinsic._MM256_MASK_SET1_EPI16;
                case "_MM256_MASK_SET1_EPI32": return Intrinsic._MM256_MASK_SET1_EPI32;
                case "_MM256_MASK_SET1_EPI64": return Intrinsic._MM256_MASK_SET1_EPI64;
                case "_MM256_MASK_SET1_EPI8": return Intrinsic._MM256_MASK_SET1_EPI8;
                case "_MM256_MASK_SHUFFLE_EPI32": return Intrinsic._MM256_MASK_SHUFFLE_EPI32;
                case "_MM256_MASK_SHUFFLE_EPI8": return Intrinsic._MM256_MASK_SHUFFLE_EPI8;
                case "_MM256_MASK_SHUFFLE_F32X4": return Intrinsic._MM256_MASK_SHUFFLE_F32X4;
                case "_MM256_MASK_SHUFFLE_F64X2": return Intrinsic._MM256_MASK_SHUFFLE_F64X2;
                case "_MM256_MASK_SHUFFLE_I32X4": return Intrinsic._MM256_MASK_SHUFFLE_I32X4;
                case "_MM256_MASK_SHUFFLE_I64X2": return Intrinsic._MM256_MASK_SHUFFLE_I64X2;
                case "_MM256_MASK_SHUFFLE_PD": return Intrinsic._MM256_MASK_SHUFFLE_PD;
                case "_MM256_MASK_SHUFFLE_PS": return Intrinsic._MM256_MASK_SHUFFLE_PS;
                case "_MM256_MASK_SHUFFLEHI_EPI16": return Intrinsic._MM256_MASK_SHUFFLEHI_EPI16;
                case "_MM256_MASK_SHUFFLELO_EPI16": return Intrinsic._MM256_MASK_SHUFFLELO_EPI16;
                case "_MM256_MASK_SLL_EPI16": return Intrinsic._MM256_MASK_SLL_EPI16;
                case "_MM256_MASK_SLL_EPI32": return Intrinsic._MM256_MASK_SLL_EPI32;
                case "_MM256_MASK_SLL_EPI64": return Intrinsic._MM256_MASK_SLL_EPI64;
                case "_MM256_MASK_SLLI_EPI16": return Intrinsic._MM256_MASK_SLLI_EPI16;
                case "_MM256_MASK_SLLI_EPI32": return Intrinsic._MM256_MASK_SLLI_EPI32;
                case "_MM256_MASK_SLLI_EPI64": return Intrinsic._MM256_MASK_SLLI_EPI64;
                case "_MM256_MASK_SLLV_EPI16": return Intrinsic._MM256_MASK_SLLV_EPI16;
                case "_MM256_MASK_SLLV_EPI32": return Intrinsic._MM256_MASK_SLLV_EPI32;
                case "_MM256_MASK_SLLV_EPI64": return Intrinsic._MM256_MASK_SLLV_EPI64;
                case "_MM256_MASK_SQRT_PD": return Intrinsic._MM256_MASK_SQRT_PD;
                case "_MM256_MASK_SQRT_PS": return Intrinsic._MM256_MASK_SQRT_PS;
                case "_MM256_MASK_SRA_EPI16": return Intrinsic._MM256_MASK_SRA_EPI16;
                case "_MM256_MASK_SRA_EPI32": return Intrinsic._MM256_MASK_SRA_EPI32;
                case "_MM256_MASK_SRA_EPI64": return Intrinsic._MM256_MASK_SRA_EPI64;
                case "_MM256_MASK_SRAI_EPI16": return Intrinsic._MM256_MASK_SRAI_EPI16;
                case "_MM256_MASK_SRAI_EPI32": return Intrinsic._MM256_MASK_SRAI_EPI32;
                case "_MM256_MASK_SRAI_EPI64": return Intrinsic._MM256_MASK_SRAI_EPI64;
                case "_MM256_MASK_SRAV_EPI16": return Intrinsic._MM256_MASK_SRAV_EPI16;
                case "_MM256_MASK_SRAV_EPI32": return Intrinsic._MM256_MASK_SRAV_EPI32;
                case "_MM256_MASK_SRAV_EPI64": return Intrinsic._MM256_MASK_SRAV_EPI64;
                case "_MM256_MASK_SRL_EPI16": return Intrinsic._MM256_MASK_SRL_EPI16;
                case "_MM256_MASK_SRL_EPI32": return Intrinsic._MM256_MASK_SRL_EPI32;
                case "_MM256_MASK_SRL_EPI64": return Intrinsic._MM256_MASK_SRL_EPI64;
                case "_MM256_MASK_SRLI_EPI16": return Intrinsic._MM256_MASK_SRLI_EPI16;
                case "_MM256_MASK_SRLI_EPI32": return Intrinsic._MM256_MASK_SRLI_EPI32;
                case "_MM256_MASK_SRLI_EPI64": return Intrinsic._MM256_MASK_SRLI_EPI64;
                case "_MM256_MASK_SRLV_EPI16": return Intrinsic._MM256_MASK_SRLV_EPI16;
                case "_MM256_MASK_SRLV_EPI32": return Intrinsic._MM256_MASK_SRLV_EPI32;
                case "_MM256_MASK_SRLV_EPI64": return Intrinsic._MM256_MASK_SRLV_EPI64;
                case "_MM256_MASK_STORE_EPI32": return Intrinsic._MM256_MASK_STORE_EPI32;
                case "_MM256_MASK_STORE_EPI64": return Intrinsic._MM256_MASK_STORE_EPI64;
                case "_MM256_MASK_STORE_PD": return Intrinsic._MM256_MASK_STORE_PD;
                case "_MM256_MASK_STORE_PS": return Intrinsic._MM256_MASK_STORE_PS;
                case "_MM256_MASK_STOREU_EPI16": return Intrinsic._MM256_MASK_STOREU_EPI16;
                case "_MM256_MASK_STOREU_EPI32": return Intrinsic._MM256_MASK_STOREU_EPI32;
                case "_MM256_MASK_STOREU_EPI64": return Intrinsic._MM256_MASK_STOREU_EPI64;
                case "_MM256_MASK_STOREU_EPI8": return Intrinsic._MM256_MASK_STOREU_EPI8;
                case "_MM256_MASK_STOREU_PD": return Intrinsic._MM256_MASK_STOREU_PD;
                case "_MM256_MASK_STOREU_PS": return Intrinsic._MM256_MASK_STOREU_PS;
                case "_MM256_MASK_SUB_EPI16": return Intrinsic._MM256_MASK_SUB_EPI16;
                case "_MM256_MASK_SUB_EPI32": return Intrinsic._MM256_MASK_SUB_EPI32;
                case "_MM256_MASK_SUB_EPI64": return Intrinsic._MM256_MASK_SUB_EPI64;
                case "_MM256_MASK_SUB_EPI8": return Intrinsic._MM256_MASK_SUB_EPI8;
                case "_MM256_MASK_SUB_PD": return Intrinsic._MM256_MASK_SUB_PD;
                case "_MM256_MASK_SUB_PS": return Intrinsic._MM256_MASK_SUB_PS;
                case "_MM256_MASK_SUBS_EPI16": return Intrinsic._MM256_MASK_SUBS_EPI16;
                case "_MM256_MASK_SUBS_EPI8": return Intrinsic._MM256_MASK_SUBS_EPI8;
                case "_MM256_MASK_SUBS_EPU16": return Intrinsic._MM256_MASK_SUBS_EPU16;
                case "_MM256_MASK_SUBS_EPU8": return Intrinsic._MM256_MASK_SUBS_EPU8;
                case "_MM256_MASK_TERNARYLOGIC_EPI32": return Intrinsic._MM256_MASK_TERNARYLOGIC_EPI32;
                case "_MM256_MASK_TERNARYLOGIC_EPI64": return Intrinsic._MM256_MASK_TERNARYLOGIC_EPI64;
                case "_MM256_MASK_TEST_EPI16_MASK": return Intrinsic._MM256_MASK_TEST_EPI16_MASK;
                case "_MM256_MASK_TEST_EPI32_MASK": return Intrinsic._MM256_MASK_TEST_EPI32_MASK;
                case "_MM256_MASK_TEST_EPI64_MASK": return Intrinsic._MM256_MASK_TEST_EPI64_MASK;
                case "_MM256_MASK_TEST_EPI8_MASK": return Intrinsic._MM256_MASK_TEST_EPI8_MASK;
                case "_MM256_MASK_TESTN_EPI16_MASK": return Intrinsic._MM256_MASK_TESTN_EPI16_MASK;
                case "_MM256_MASK_TESTN_EPI32_MASK": return Intrinsic._MM256_MASK_TESTN_EPI32_MASK;
                case "_MM256_MASK_TESTN_EPI64_MASK": return Intrinsic._MM256_MASK_TESTN_EPI64_MASK;
                case "_MM256_MASK_TESTN_EPI8_MASK": return Intrinsic._MM256_MASK_TESTN_EPI8_MASK;
                case "_MM256_MASK_UNPACKHI_EPI16": return Intrinsic._MM256_MASK_UNPACKHI_EPI16;
                case "_MM256_MASK_UNPACKHI_EPI32": return Intrinsic._MM256_MASK_UNPACKHI_EPI32;
                case "_MM256_MASK_UNPACKHI_EPI64": return Intrinsic._MM256_MASK_UNPACKHI_EPI64;
                case "_MM256_MASK_UNPACKHI_EPI8": return Intrinsic._MM256_MASK_UNPACKHI_EPI8;
                case "_MM256_MASK_UNPACKHI_PD": return Intrinsic._MM256_MASK_UNPACKHI_PD;
                case "_MM256_MASK_UNPACKHI_PS": return Intrinsic._MM256_MASK_UNPACKHI_PS;
                case "_MM256_MASK_UNPACKLO_EPI16": return Intrinsic._MM256_MASK_UNPACKLO_EPI16;
                case "_MM256_MASK_UNPACKLO_EPI32": return Intrinsic._MM256_MASK_UNPACKLO_EPI32;
                case "_MM256_MASK_UNPACKLO_EPI64": return Intrinsic._MM256_MASK_UNPACKLO_EPI64;
                case "_MM256_MASK_UNPACKLO_EPI8": return Intrinsic._MM256_MASK_UNPACKLO_EPI8;
                case "_MM256_MASK_UNPACKLO_PD": return Intrinsic._MM256_MASK_UNPACKLO_PD;
                case "_MM256_MASK_UNPACKLO_PS": return Intrinsic._MM256_MASK_UNPACKLO_PS;
                case "_MM256_MASK_XOR_EPI32": return Intrinsic._MM256_MASK_XOR_EPI32;
                case "_MM256_MASK_XOR_EPI64": return Intrinsic._MM256_MASK_XOR_EPI64;
                case "_MM256_MASK_XOR_PD": return Intrinsic._MM256_MASK_XOR_PD;
                case "_MM256_MASK_XOR_PS": return Intrinsic._MM256_MASK_XOR_PS;
                case "_MM256_MASK2_PERMUTEX2VAR_EPI16": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_EPI16;
                case "_MM256_MASK2_PERMUTEX2VAR_EPI32": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_EPI32;
                case "_MM256_MASK2_PERMUTEX2VAR_EPI64": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_EPI64;
                case "_MM256_MASK2_PERMUTEX2VAR_EPI8": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_EPI8;
                case "_MM256_MASK2_PERMUTEX2VAR_PD": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_PD;
                case "_MM256_MASK2_PERMUTEX2VAR_PS": return Intrinsic._MM256_MASK2_PERMUTEX2VAR_PS;
                case "_MM256_MASK3_FMADD_PD": return Intrinsic._MM256_MASK3_FMADD_PD;
                case "_MM256_MASK3_FMADD_PS": return Intrinsic._MM256_MASK3_FMADD_PS;
                case "_MM256_MASK3_FMADDSUB_PD": return Intrinsic._MM256_MASK3_FMADDSUB_PD;
                case "_MM256_MASK3_FMADDSUB_PS": return Intrinsic._MM256_MASK3_FMADDSUB_PS;
                case "_MM256_MASK3_FMSUB_PD": return Intrinsic._MM256_MASK3_FMSUB_PD;
                case "_MM256_MASK3_FMSUB_PS": return Intrinsic._MM256_MASK3_FMSUB_PS;
                case "_MM256_MASK3_FMSUBADD_PD": return Intrinsic._MM256_MASK3_FMSUBADD_PD;
                case "_MM256_MASK3_FMSUBADD_PS": return Intrinsic._MM256_MASK3_FMSUBADD_PS;
                case "_MM256_MASK3_FNMADD_PD": return Intrinsic._MM256_MASK3_FNMADD_PD;
                case "_MM256_MASK3_FNMADD_PS": return Intrinsic._MM256_MASK3_FNMADD_PS;
                case "_MM256_MASK3_FNMSUB_PD": return Intrinsic._MM256_MASK3_FNMSUB_PD;
                case "_MM256_MASK3_FNMSUB_PS": return Intrinsic._MM256_MASK3_FNMSUB_PS;
                case "_MM256_MASKLOAD_EPI32": return Intrinsic._MM256_MASKLOAD_EPI32;
                case "_MM256_MASKLOAD_EPI64": return Intrinsic._MM256_MASKLOAD_EPI64;
                case "_MM256_MASKLOAD_PD": return Intrinsic._MM256_MASKLOAD_PD;
                case "_MM256_MASKLOAD_PS": return Intrinsic._MM256_MASKLOAD_PS;
                case "_MM256_MASKSTORE_EPI32": return Intrinsic._MM256_MASKSTORE_EPI32;
                case "_MM256_MASKSTORE_EPI64": return Intrinsic._MM256_MASKSTORE_EPI64;
                case "_MM256_MASKSTORE_PD": return Intrinsic._MM256_MASKSTORE_PD;
                case "_MM256_MASKSTORE_PS": return Intrinsic._MM256_MASKSTORE_PS;
                case "_MM256_MASKZ_ABS_EPI16": return Intrinsic._MM256_MASKZ_ABS_EPI16;
                case "_MM256_MASKZ_ABS_EPI32": return Intrinsic._MM256_MASKZ_ABS_EPI32;
                case "_MM256_MASKZ_ABS_EPI64": return Intrinsic._MM256_MASKZ_ABS_EPI64;
                case "_MM256_MASKZ_ABS_EPI8": return Intrinsic._MM256_MASKZ_ABS_EPI8;
                case "_MM256_MASKZ_ADD_EPI16": return Intrinsic._MM256_MASKZ_ADD_EPI16;
                case "_MM256_MASKZ_ADD_EPI32": return Intrinsic._MM256_MASKZ_ADD_EPI32;
                case "_MM256_MASKZ_ADD_EPI64": return Intrinsic._MM256_MASKZ_ADD_EPI64;
                case "_MM256_MASKZ_ADD_EPI8": return Intrinsic._MM256_MASKZ_ADD_EPI8;
                case "_MM256_MASKZ_ADD_PD": return Intrinsic._MM256_MASKZ_ADD_PD;
                case "_MM256_MASKZ_ADD_PS": return Intrinsic._MM256_MASKZ_ADD_PS;
                case "_MM256_MASKZ_ADDS_EPI16": return Intrinsic._MM256_MASKZ_ADDS_EPI16;
                case "_MM256_MASKZ_ADDS_EPI8": return Intrinsic._MM256_MASKZ_ADDS_EPI8;
                case "_MM256_MASKZ_ADDS_EPU16": return Intrinsic._MM256_MASKZ_ADDS_EPU16;
                case "_MM256_MASKZ_ADDS_EPU8": return Intrinsic._MM256_MASKZ_ADDS_EPU8;
                case "_MM256_MASKZ_ALIGNR_EPI32": return Intrinsic._MM256_MASKZ_ALIGNR_EPI32;
                case "_MM256_MASKZ_ALIGNR_EPI64": return Intrinsic._MM256_MASKZ_ALIGNR_EPI64;
                case "_MM256_MASKZ_ALIGNR_EPI8": return Intrinsic._MM256_MASKZ_ALIGNR_EPI8;
                case "_MM256_MASKZ_AND_EPI32": return Intrinsic._MM256_MASKZ_AND_EPI32;
                case "_MM256_MASKZ_AND_EPI64": return Intrinsic._MM256_MASKZ_AND_EPI64;
                case "_MM256_MASKZ_AND_PD": return Intrinsic._MM256_MASKZ_AND_PD;
                case "_MM256_MASKZ_AND_PS": return Intrinsic._MM256_MASKZ_AND_PS;
                case "_MM256_MASKZ_ANDNOT_EPI32": return Intrinsic._MM256_MASKZ_ANDNOT_EPI32;
                case "_MM256_MASKZ_ANDNOT_EPI64": return Intrinsic._MM256_MASKZ_ANDNOT_EPI64;
                case "_MM256_MASKZ_ANDNOT_PD": return Intrinsic._MM256_MASKZ_ANDNOT_PD;
                case "_MM256_MASKZ_ANDNOT_PS": return Intrinsic._MM256_MASKZ_ANDNOT_PS;
                case "_MM256_MASKZ_AVG_EPU16": return Intrinsic._MM256_MASKZ_AVG_EPU16;
                case "_MM256_MASKZ_AVG_EPU8": return Intrinsic._MM256_MASKZ_AVG_EPU8;
                case "_MM256_MASKZ_BROADCAST_F32X2": return Intrinsic._MM256_MASKZ_BROADCAST_F32X2;
                case "_MM256_MASKZ_BROADCAST_F32X4": return Intrinsic._MM256_MASKZ_BROADCAST_F32X4;
                case "_MM256_MASKZ_BROADCAST_F64X2": return Intrinsic._MM256_MASKZ_BROADCAST_F64X2;
                case "_MM256_MASKZ_BROADCAST_I32X2": return Intrinsic._MM256_MASKZ_BROADCAST_I32X2;
                case "_MM256_MASKZ_BROADCAST_I32X4": return Intrinsic._MM256_MASKZ_BROADCAST_I32X4;
                case "_MM256_MASKZ_BROADCAST_I64X2": return Intrinsic._MM256_MASKZ_BROADCAST_I64X2;
                case "_MM256_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM256_MASKZ_BROADCASTB_EPI8;
                case "_MM256_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM256_MASKZ_BROADCASTD_EPI32;
                case "_MM256_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM256_MASKZ_BROADCASTQ_EPI64;
                case "_MM256_MASKZ_BROADCASTSD_PD": return Intrinsic._MM256_MASKZ_BROADCASTSD_PD;
                case "_MM256_MASKZ_BROADCASTSS_PS": return Intrinsic._MM256_MASKZ_BROADCASTSS_PS;
                case "_MM256_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM256_MASKZ_BROADCASTW_EPI16;
                case "_MM256_MASKZ_COMPRESS_EPI32": return Intrinsic._MM256_MASKZ_COMPRESS_EPI32;
                case "_MM256_MASKZ_COMPRESS_EPI64": return Intrinsic._MM256_MASKZ_COMPRESS_EPI64;
                case "_MM256_MASKZ_COMPRESS_PD": return Intrinsic._MM256_MASKZ_COMPRESS_PD;
                case "_MM256_MASKZ_COMPRESS_PS": return Intrinsic._MM256_MASKZ_COMPRESS_PS;
                case "_MM256_MASKZ_CONFLICT_EPI32": return Intrinsic._MM256_MASKZ_CONFLICT_EPI32;
                case "_MM256_MASKZ_CONFLICT_EPI64": return Intrinsic._MM256_MASKZ_CONFLICT_EPI64;
                case "_MM256_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM256_MASKZ_CVT_ROUNDPS_PH;
                case "_MM256_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI32;
                case "_MM256_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI64;
                case "_MM256_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI16_EPI8;
                case "_MM256_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI16;
                case "_MM256_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI64;
                case "_MM256_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI32_EPI8;
                case "_MM256_MASKZ_CVTEPI32_PD": return Intrinsic._MM256_MASKZ_CVTEPI32_PD;
                case "_MM256_MASKZ_CVTEPI32_PS": return Intrinsic._MM256_MASKZ_CVTEPI32_PS;
                case "_MM256_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI16;
                case "_MM256_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI32;
                case "_MM256_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTEPI64_EPI8;
                case "_MM256_MASKZ_CVTEPI64_PD": return Intrinsic._MM256_MASKZ_CVTEPI64_PD;
                case "_MM256_MASKZ_CVTEPI64_PS": return Intrinsic._MM256_MASKZ_CVTEPI64_PS;
                case "_MM256_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI16;
                case "_MM256_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI32;
                case "_MM256_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM256_MASKZ_CVTEPI8_EPI64;
                case "_MM256_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM256_MASKZ_CVTEPU16_EPI32;
                case "_MM256_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU16_EPI64;
                case "_MM256_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU32_EPI64;
                case "_MM256_MASKZ_CVTEPU32_PD": return Intrinsic._MM256_MASKZ_CVTEPU32_PD;
                case "_MM256_MASKZ_CVTEPU64_PD": return Intrinsic._MM256_MASKZ_CVTEPU64_PD;
                case "_MM256_MASKZ_CVTEPU64_PS": return Intrinsic._MM256_MASKZ_CVTEPU64_PS;
                case "_MM256_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI16;
                case "_MM256_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI32;
                case "_MM256_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM256_MASKZ_CVTEPU8_EPI64;
                case "_MM256_MASKZ_CVTPD_EPI32": return Intrinsic._MM256_MASKZ_CVTPD_EPI32;
                case "_MM256_MASKZ_CVTPD_EPI64": return Intrinsic._MM256_MASKZ_CVTPD_EPI64;
                case "_MM256_MASKZ_CVTPD_EPU32": return Intrinsic._MM256_MASKZ_CVTPD_EPU32;
                case "_MM256_MASKZ_CVTPD_EPU64": return Intrinsic._MM256_MASKZ_CVTPD_EPU64;
                case "_MM256_MASKZ_CVTPD_PS": return Intrinsic._MM256_MASKZ_CVTPD_PS;
                case "_MM256_MASKZ_CVTPH_PS": return Intrinsic._MM256_MASKZ_CVTPH_PS;
                case "_MM256_MASKZ_CVTPS_EPI32": return Intrinsic._MM256_MASKZ_CVTPS_EPI32;
                case "_MM256_MASKZ_CVTPS_EPI64": return Intrinsic._MM256_MASKZ_CVTPS_EPI64;
                case "_MM256_MASKZ_CVTPS_EPU32": return Intrinsic._MM256_MASKZ_CVTPS_EPU32;
                case "_MM256_MASKZ_CVTPS_EPU64": return Intrinsic._MM256_MASKZ_CVTPS_EPU64;
                case "_MM256_MASKZ_CVTPS_PH": return Intrinsic._MM256_MASKZ_CVTPS_PH;
                case "_MM256_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI16_EPI8;
                case "_MM256_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTSEPI32_EPI16;
                case "_MM256_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI32_EPI8;
                case "_MM256_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI16;
                case "_MM256_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI32;
                case "_MM256_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTSEPI64_EPI8;
                case "_MM256_MASKZ_CVTTPD_EPI32": return Intrinsic._MM256_MASKZ_CVTTPD_EPI32;
                case "_MM256_MASKZ_CVTTPD_EPI64": return Intrinsic._MM256_MASKZ_CVTTPD_EPI64;
                case "_MM256_MASKZ_CVTTPD_EPU32": return Intrinsic._MM256_MASKZ_CVTTPD_EPU32;
                case "_MM256_MASKZ_CVTTPD_EPU64": return Intrinsic._MM256_MASKZ_CVTTPD_EPU64;
                case "_MM256_MASKZ_CVTTPS_EPI32": return Intrinsic._MM256_MASKZ_CVTTPS_EPI32;
                case "_MM256_MASKZ_CVTTPS_EPI64": return Intrinsic._MM256_MASKZ_CVTTPS_EPI64;
                case "_MM256_MASKZ_CVTTPS_EPU32": return Intrinsic._MM256_MASKZ_CVTTPS_EPU32;
                case "_MM256_MASKZ_CVTTPS_EPU64": return Intrinsic._MM256_MASKZ_CVTTPS_EPU64;
                case "_MM256_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI16_EPI8;
                case "_MM256_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM256_MASKZ_CVTUSEPI32_EPI16;
                case "_MM256_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI32_EPI8;
                case "_MM256_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI16;
                case "_MM256_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI32;
                case "_MM256_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM256_MASKZ_CVTUSEPI64_EPI8;
                case "_MM256_MASKZ_DBSAD_EPU8": return Intrinsic._MM256_MASKZ_DBSAD_EPU8;
                case "_MM256_MASKZ_DIV_PD": return Intrinsic._MM256_MASKZ_DIV_PD;
                case "_MM256_MASKZ_DIV_PS": return Intrinsic._MM256_MASKZ_DIV_PS;
                case "_MM256_MASKZ_EXPAND_EPI32": return Intrinsic._MM256_MASKZ_EXPAND_EPI32;
                case "_MM256_MASKZ_EXPAND_EPI64": return Intrinsic._MM256_MASKZ_EXPAND_EPI64;
                case "_MM256_MASKZ_EXPAND_PD": return Intrinsic._MM256_MASKZ_EXPAND_PD;
                case "_MM256_MASKZ_EXPAND_PS": return Intrinsic._MM256_MASKZ_EXPAND_PS;
                case "_MM256_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM256_MASKZ_EXPANDLOADU_EPI32;
                case "_MM256_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM256_MASKZ_EXPANDLOADU_EPI64;
                case "_MM256_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM256_MASKZ_EXPANDLOADU_PD;
                case "_MM256_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM256_MASKZ_EXPANDLOADU_PS;
                case "_MM256_MASKZ_EXTRACTF32X4_PS": return Intrinsic._MM256_MASKZ_EXTRACTF32X4_PS;
                case "_MM256_MASKZ_EXTRACTF64X2_PD": return Intrinsic._MM256_MASKZ_EXTRACTF64X2_PD;
                case "_MM256_MASKZ_EXTRACTI32X4_EPI32": return Intrinsic._MM256_MASKZ_EXTRACTI32X4_EPI32;
                case "_MM256_MASKZ_EXTRACTI64X2_EPI64": return Intrinsic._MM256_MASKZ_EXTRACTI64X2_EPI64;
                case "_MM256_MASKZ_FIXUPIMM_PD": return Intrinsic._MM256_MASKZ_FIXUPIMM_PD;
                case "_MM256_MASKZ_FIXUPIMM_PS": return Intrinsic._MM256_MASKZ_FIXUPIMM_PS;
                case "_MM256_MASKZ_FMADD_PD": return Intrinsic._MM256_MASKZ_FMADD_PD;
                case "_MM256_MASKZ_FMADD_PS": return Intrinsic._MM256_MASKZ_FMADD_PS;
                case "_MM256_MASKZ_FMADDSUB_PD": return Intrinsic._MM256_MASKZ_FMADDSUB_PD;
                case "_MM256_MASKZ_FMADDSUB_PS": return Intrinsic._MM256_MASKZ_FMADDSUB_PS;
                case "_MM256_MASKZ_FMSUB_PD": return Intrinsic._MM256_MASKZ_FMSUB_PD;
                case "_MM256_MASKZ_FMSUB_PS": return Intrinsic._MM256_MASKZ_FMSUB_PS;
                case "_MM256_MASKZ_FMSUBADD_PD": return Intrinsic._MM256_MASKZ_FMSUBADD_PD;
                case "_MM256_MASKZ_FMSUBADD_PS": return Intrinsic._MM256_MASKZ_FMSUBADD_PS;
                case "_MM256_MASKZ_FNMADD_PD": return Intrinsic._MM256_MASKZ_FNMADD_PD;
                case "_MM256_MASKZ_FNMADD_PS": return Intrinsic._MM256_MASKZ_FNMADD_PS;
                case "_MM256_MASKZ_FNMSUB_PD": return Intrinsic._MM256_MASKZ_FNMSUB_PD;
                case "_MM256_MASKZ_FNMSUB_PS": return Intrinsic._MM256_MASKZ_FNMSUB_PS;
                case "_MM256_MASKZ_GETEXP_PD": return Intrinsic._MM256_MASKZ_GETEXP_PD;
                case "_MM256_MASKZ_GETEXP_PS": return Intrinsic._MM256_MASKZ_GETEXP_PS;
                case "_MM256_MASKZ_GETMANT_PD": return Intrinsic._MM256_MASKZ_GETMANT_PD;
                case "_MM256_MASKZ_GETMANT_PS": return Intrinsic._MM256_MASKZ_GETMANT_PS;
                case "_MM256_MASKZ_INSERTF32X4": return Intrinsic._MM256_MASKZ_INSERTF32X4;
                case "_MM256_MASKZ_INSERTF64X2": return Intrinsic._MM256_MASKZ_INSERTF64X2;
                case "_MM256_MASKZ_INSERTI32X4": return Intrinsic._MM256_MASKZ_INSERTI32X4;
                case "_MM256_MASKZ_INSERTI64X2": return Intrinsic._MM256_MASKZ_INSERTI64X2;
                case "_MM256_MASKZ_LOAD_EPI32": return Intrinsic._MM256_MASKZ_LOAD_EPI32;
                case "_MM256_MASKZ_LOAD_EPI64": return Intrinsic._MM256_MASKZ_LOAD_EPI64;
                case "_MM256_MASKZ_LOAD_PD": return Intrinsic._MM256_MASKZ_LOAD_PD;
                case "_MM256_MASKZ_LOAD_PS": return Intrinsic._MM256_MASKZ_LOAD_PS;
                case "_MM256_MASKZ_LOADU_EPI16": return Intrinsic._MM256_MASKZ_LOADU_EPI16;
                case "_MM256_MASKZ_LOADU_EPI32": return Intrinsic._MM256_MASKZ_LOADU_EPI32;
                case "_MM256_MASKZ_LOADU_EPI64": return Intrinsic._MM256_MASKZ_LOADU_EPI64;
                case "_MM256_MASKZ_LOADU_EPI8": return Intrinsic._MM256_MASKZ_LOADU_EPI8;
                case "_MM256_MASKZ_LOADU_PD": return Intrinsic._MM256_MASKZ_LOADU_PD;
                case "_MM256_MASKZ_LOADU_PS": return Intrinsic._MM256_MASKZ_LOADU_PS;
                case "_MM256_MASKZ_LZCNT_EPI32": return Intrinsic._MM256_MASKZ_LZCNT_EPI32;
                case "_MM256_MASKZ_LZCNT_EPI64": return Intrinsic._MM256_MASKZ_LZCNT_EPI64;
                case "_MM256_MASKZ_MADD_EPI16": return Intrinsic._MM256_MASKZ_MADD_EPI16;
                case "_MM256_MASKZ_MADD52HI_EPU64": return Intrinsic._MM256_MASKZ_MADD52HI_EPU64;
                case "_MM256_MASKZ_MADD52LO_EPU64": return Intrinsic._MM256_MASKZ_MADD52LO_EPU64;
                case "_MM256_MASKZ_MADDUBS_EPI16": return Intrinsic._MM256_MASKZ_MADDUBS_EPI16;
                case "_MM256_MASKZ_MAX_EPI16": return Intrinsic._MM256_MASKZ_MAX_EPI16;
                case "_MM256_MASKZ_MAX_EPI32": return Intrinsic._MM256_MASKZ_MAX_EPI32;
                case "_MM256_MASKZ_MAX_EPI64": return Intrinsic._MM256_MASKZ_MAX_EPI64;
                case "_MM256_MASKZ_MAX_EPI8": return Intrinsic._MM256_MASKZ_MAX_EPI8;
                case "_MM256_MASKZ_MAX_EPU16": return Intrinsic._MM256_MASKZ_MAX_EPU16;
                case "_MM256_MASKZ_MAX_EPU32": return Intrinsic._MM256_MASKZ_MAX_EPU32;
                case "_MM256_MASKZ_MAX_EPU64": return Intrinsic._MM256_MASKZ_MAX_EPU64;
                case "_MM256_MASKZ_MAX_EPU8": return Intrinsic._MM256_MASKZ_MAX_EPU8;
                case "_MM256_MASKZ_MAX_PD": return Intrinsic._MM256_MASKZ_MAX_PD;
                case "_MM256_MASKZ_MAX_PS": return Intrinsic._MM256_MASKZ_MAX_PS;
                case "_MM256_MASKZ_MIN_EPI16": return Intrinsic._MM256_MASKZ_MIN_EPI16;
                case "_MM256_MASKZ_MIN_EPI32": return Intrinsic._MM256_MASKZ_MIN_EPI32;
                case "_MM256_MASKZ_MIN_EPI64": return Intrinsic._MM256_MASKZ_MIN_EPI64;
                case "_MM256_MASKZ_MIN_EPI8": return Intrinsic._MM256_MASKZ_MIN_EPI8;
                case "_MM256_MASKZ_MIN_EPU16": return Intrinsic._MM256_MASKZ_MIN_EPU16;
                case "_MM256_MASKZ_MIN_EPU32": return Intrinsic._MM256_MASKZ_MIN_EPU32;
                case "_MM256_MASKZ_MIN_EPU64": return Intrinsic._MM256_MASKZ_MIN_EPU64;
                case "_MM256_MASKZ_MIN_EPU8": return Intrinsic._MM256_MASKZ_MIN_EPU8;
                case "_MM256_MASKZ_MIN_PD": return Intrinsic._MM256_MASKZ_MIN_PD;
                case "_MM256_MASKZ_MIN_PS": return Intrinsic._MM256_MASKZ_MIN_PS;
                case "_MM256_MASKZ_MOV_EPI16": return Intrinsic._MM256_MASKZ_MOV_EPI16;
                case "_MM256_MASKZ_MOV_EPI32": return Intrinsic._MM256_MASKZ_MOV_EPI32;
                case "_MM256_MASKZ_MOV_EPI64": return Intrinsic._MM256_MASKZ_MOV_EPI64;
                case "_MM256_MASKZ_MOV_EPI8": return Intrinsic._MM256_MASKZ_MOV_EPI8;
                case "_MM256_MASKZ_MOV_PD": return Intrinsic._MM256_MASKZ_MOV_PD;
                case "_MM256_MASKZ_MOV_PS": return Intrinsic._MM256_MASKZ_MOV_PS;
                case "_MM256_MASKZ_MOVEDUP_PD": return Intrinsic._MM256_MASKZ_MOVEDUP_PD;
                case "_MM256_MASKZ_MOVEHDUP_PS": return Intrinsic._MM256_MASKZ_MOVEHDUP_PS;
                case "_MM256_MASKZ_MOVELDUP_PS": return Intrinsic._MM256_MASKZ_MOVELDUP_PS;
                case "_MM256_MASKZ_MUL_EPI32": return Intrinsic._MM256_MASKZ_MUL_EPI32;
                case "_MM256_MASKZ_MUL_EPU32": return Intrinsic._MM256_MASKZ_MUL_EPU32;
                case "_MM256_MASKZ_MUL_PD": return Intrinsic._MM256_MASKZ_MUL_PD;
                case "_MM256_MASKZ_MUL_PS": return Intrinsic._MM256_MASKZ_MUL_PS;
                case "_MM256_MASKZ_MULHI_EPI16": return Intrinsic._MM256_MASKZ_MULHI_EPI16;
                case "_MM256_MASKZ_MULHI_EPU16": return Intrinsic._MM256_MASKZ_MULHI_EPU16;
                case "_MM256_MASKZ_MULHRS_EPI16": return Intrinsic._MM256_MASKZ_MULHRS_EPI16;
                case "_MM256_MASKZ_MULLO_EPI16": return Intrinsic._MM256_MASKZ_MULLO_EPI16;
                case "_MM256_MASKZ_MULLO_EPI32": return Intrinsic._MM256_MASKZ_MULLO_EPI32;
                case "_MM256_MASKZ_MULLO_EPI64": return Intrinsic._MM256_MASKZ_MULLO_EPI64;
                case "_MM256_MASKZ_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM256_MASKZ_MULTISHIFT_EPI64_EPI8;
                case "_MM256_MASKZ_OR_EPI32": return Intrinsic._MM256_MASKZ_OR_EPI32;
                case "_MM256_MASKZ_OR_EPI64": return Intrinsic._MM256_MASKZ_OR_EPI64;
                case "_MM256_MASKZ_OR_PD": return Intrinsic._MM256_MASKZ_OR_PD;
                case "_MM256_MASKZ_OR_PS": return Intrinsic._MM256_MASKZ_OR_PS;
                case "_MM256_MASKZ_PACKS_EPI16": return Intrinsic._MM256_MASKZ_PACKS_EPI16;
                case "_MM256_MASKZ_PACKS_EPI32": return Intrinsic._MM256_MASKZ_PACKS_EPI32;
                case "_MM256_MASKZ_PACKUS_EPI16": return Intrinsic._MM256_MASKZ_PACKUS_EPI16;
                case "_MM256_MASKZ_PACKUS_EPI32": return Intrinsic._MM256_MASKZ_PACKUS_EPI32;
                case "_MM256_MASKZ_PERMUTE_PD": return Intrinsic._MM256_MASKZ_PERMUTE_PD;
                case "_MM256_MASKZ_PERMUTE_PS": return Intrinsic._MM256_MASKZ_PERMUTE_PS;
                case "_MM256_MASKZ_PERMUTEVAR_PD": return Intrinsic._MM256_MASKZ_PERMUTEVAR_PD;
                case "_MM256_MASKZ_PERMUTEVAR_PS": return Intrinsic._MM256_MASKZ_PERMUTEVAR_PS;
                case "_MM256_MASKZ_PERMUTEX_EPI64": return Intrinsic._MM256_MASKZ_PERMUTEX_EPI64;
                case "_MM256_MASKZ_PERMUTEX_PD": return Intrinsic._MM256_MASKZ_PERMUTEX_PD;
                case "_MM256_MASKZ_PERMUTEX2VAR_EPI16": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_EPI16;
                case "_MM256_MASKZ_PERMUTEX2VAR_EPI32": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_EPI32;
                case "_MM256_MASKZ_PERMUTEX2VAR_EPI64": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_EPI64;
                case "_MM256_MASKZ_PERMUTEX2VAR_EPI8": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_EPI8;
                case "_MM256_MASKZ_PERMUTEX2VAR_PD": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_PD;
                case "_MM256_MASKZ_PERMUTEX2VAR_PS": return Intrinsic._MM256_MASKZ_PERMUTEX2VAR_PS;
                case "_MM256_MASKZ_PERMUTEXVAR_EPI16": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_EPI16;
                case "_MM256_MASKZ_PERMUTEXVAR_EPI32": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_EPI32;
                case "_MM256_MASKZ_PERMUTEXVAR_EPI64": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_EPI64;
                case "_MM256_MASKZ_PERMUTEXVAR_EPI8": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_EPI8;
                case "_MM256_MASKZ_PERMUTEXVAR_PD": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_PD;
                case "_MM256_MASKZ_PERMUTEXVAR_PS": return Intrinsic._MM256_MASKZ_PERMUTEXVAR_PS;
                case "_MM256_MASKZ_RANGE_PD": return Intrinsic._MM256_MASKZ_RANGE_PD;
                case "_MM256_MASKZ_RANGE_PS": return Intrinsic._MM256_MASKZ_RANGE_PS;
                case "_MM256_MASKZ_RCP14_PD": return Intrinsic._MM256_MASKZ_RCP14_PD;
                case "_MM256_MASKZ_RCP14_PS": return Intrinsic._MM256_MASKZ_RCP14_PS;
                case "_MM256_MASKZ_REDUCE_PD": return Intrinsic._MM256_MASKZ_REDUCE_PD;
                case "_MM256_MASKZ_REDUCE_PS": return Intrinsic._MM256_MASKZ_REDUCE_PS;
                case "_MM256_MASKZ_ROL_EPI32": return Intrinsic._MM256_MASKZ_ROL_EPI32;
                case "_MM256_MASKZ_ROL_EPI64": return Intrinsic._MM256_MASKZ_ROL_EPI64;
                case "_MM256_MASKZ_ROLV_EPI32": return Intrinsic._MM256_MASKZ_ROLV_EPI32;
                case "_MM256_MASKZ_ROLV_EPI64": return Intrinsic._MM256_MASKZ_ROLV_EPI64;
                case "_MM256_MASKZ_ROR_EPI32": return Intrinsic._MM256_MASKZ_ROR_EPI32;
                case "_MM256_MASKZ_ROR_EPI64": return Intrinsic._MM256_MASKZ_ROR_EPI64;
                case "_MM256_MASKZ_RORV_EPI32": return Intrinsic._MM256_MASKZ_RORV_EPI32;
                case "_MM256_MASKZ_RORV_EPI64": return Intrinsic._MM256_MASKZ_RORV_EPI64;
                case "_MM256_MASKZ_ROUNDSCALE_PD": return Intrinsic._MM256_MASKZ_ROUNDSCALE_PD;
                case "_MM256_MASKZ_ROUNDSCALE_PS": return Intrinsic._MM256_MASKZ_ROUNDSCALE_PS;
                case "_MM256_MASKZ_RSQRT14_PD": return Intrinsic._MM256_MASKZ_RSQRT14_PD;
                case "_MM256_MASKZ_RSQRT14_PS": return Intrinsic._MM256_MASKZ_RSQRT14_PS;
                case "_MM256_MASKZ_SCALEF_PD": return Intrinsic._MM256_MASKZ_SCALEF_PD;
                case "_MM256_MASKZ_SCALEF_PS": return Intrinsic._MM256_MASKZ_SCALEF_PS;
                case "_MM256_MASKZ_SET1_EPI16": return Intrinsic._MM256_MASKZ_SET1_EPI16;
                case "_MM256_MASKZ_SET1_EPI32": return Intrinsic._MM256_MASKZ_SET1_EPI32;
                case "_MM256_MASKZ_SET1_EPI64": return Intrinsic._MM256_MASKZ_SET1_EPI64;
                case "_MM256_MASKZ_SET1_EPI8": return Intrinsic._MM256_MASKZ_SET1_EPI8;
                case "_MM256_MASKZ_SHUFFLE_EPI32": return Intrinsic._MM256_MASKZ_SHUFFLE_EPI32;
                case "_MM256_MASKZ_SHUFFLE_EPI8": return Intrinsic._MM256_MASKZ_SHUFFLE_EPI8;
                case "_MM256_MASKZ_SHUFFLE_F32X4": return Intrinsic._MM256_MASKZ_SHUFFLE_F32X4;
                case "_MM256_MASKZ_SHUFFLE_F64X2": return Intrinsic._MM256_MASKZ_SHUFFLE_F64X2;
                case "_MM256_MASKZ_SHUFFLE_I32X4": return Intrinsic._MM256_MASKZ_SHUFFLE_I32X4;
                case "_MM256_MASKZ_SHUFFLE_I64X2": return Intrinsic._MM256_MASKZ_SHUFFLE_I64X2;
                case "_MM256_MASKZ_SHUFFLE_PD": return Intrinsic._MM256_MASKZ_SHUFFLE_PD;
                case "_MM256_MASKZ_SHUFFLE_PS": return Intrinsic._MM256_MASKZ_SHUFFLE_PS;
                case "_MM256_MASKZ_SHUFFLEHI_EPI16": return Intrinsic._MM256_MASKZ_SHUFFLEHI_EPI16;
                case "_MM256_MASKZ_SHUFFLELO_EPI16": return Intrinsic._MM256_MASKZ_SHUFFLELO_EPI16;
                case "_MM256_MASKZ_SLL_EPI16": return Intrinsic._MM256_MASKZ_SLL_EPI16;
                case "_MM256_MASKZ_SLL_EPI32": return Intrinsic._MM256_MASKZ_SLL_EPI32;
                case "_MM256_MASKZ_SLL_EPI64": return Intrinsic._MM256_MASKZ_SLL_EPI64;
                case "_MM256_MASKZ_SLLI_EPI16": return Intrinsic._MM256_MASKZ_SLLI_EPI16;
                case "_MM256_MASKZ_SLLI_EPI32": return Intrinsic._MM256_MASKZ_SLLI_EPI32;
                case "_MM256_MASKZ_SLLI_EPI64": return Intrinsic._MM256_MASKZ_SLLI_EPI64;
                case "_MM256_MASKZ_SLLV_EPI16": return Intrinsic._MM256_MASKZ_SLLV_EPI16;
                case "_MM256_MASKZ_SLLV_EPI32": return Intrinsic._MM256_MASKZ_SLLV_EPI32;
                case "_MM256_MASKZ_SLLV_EPI64": return Intrinsic._MM256_MASKZ_SLLV_EPI64;
                case "_MM256_MASKZ_SQRT_PD": return Intrinsic._MM256_MASKZ_SQRT_PD;
                case "_MM256_MASKZ_SQRT_PS": return Intrinsic._MM256_MASKZ_SQRT_PS;
                case "_MM256_MASKZ_SRA_EPI16": return Intrinsic._MM256_MASKZ_SRA_EPI16;
                case "_MM256_MASKZ_SRA_EPI32": return Intrinsic._MM256_MASKZ_SRA_EPI32;
                case "_MM256_MASKZ_SRA_EPI64": return Intrinsic._MM256_MASKZ_SRA_EPI64;
                case "_MM256_MASKZ_SRAI_EPI16": return Intrinsic._MM256_MASKZ_SRAI_EPI16;
                case "_MM256_MASKZ_SRAI_EPI32": return Intrinsic._MM256_MASKZ_SRAI_EPI32;
                case "_MM256_MASKZ_SRAI_EPI64": return Intrinsic._MM256_MASKZ_SRAI_EPI64;
                case "_MM256_MASKZ_SRAV_EPI16": return Intrinsic._MM256_MASKZ_SRAV_EPI16;
                case "_MM256_MASKZ_SRAV_EPI32": return Intrinsic._MM256_MASKZ_SRAV_EPI32;
                case "_MM256_MASKZ_SRAV_EPI64": return Intrinsic._MM256_MASKZ_SRAV_EPI64;
                case "_MM256_MASKZ_SRL_EPI16": return Intrinsic._MM256_MASKZ_SRL_EPI16;
                case "_MM256_MASKZ_SRL_EPI32": return Intrinsic._MM256_MASKZ_SRL_EPI32;
                case "_MM256_MASKZ_SRL_EPI64": return Intrinsic._MM256_MASKZ_SRL_EPI64;
                case "_MM256_MASKZ_SRLI_EPI16": return Intrinsic._MM256_MASKZ_SRLI_EPI16;
                case "_MM256_MASKZ_SRLI_EPI32": return Intrinsic._MM256_MASKZ_SRLI_EPI32;
                case "_MM256_MASKZ_SRLI_EPI64": return Intrinsic._MM256_MASKZ_SRLI_EPI64;
                case "_MM256_MASKZ_SRLV_EPI16": return Intrinsic._MM256_MASKZ_SRLV_EPI16;
                case "_MM256_MASKZ_SRLV_EPI32": return Intrinsic._MM256_MASKZ_SRLV_EPI32;
                case "_MM256_MASKZ_SRLV_EPI64": return Intrinsic._MM256_MASKZ_SRLV_EPI64;
                case "_MM256_MASKZ_SUB_EPI16": return Intrinsic._MM256_MASKZ_SUB_EPI16;
                case "_MM256_MASKZ_SUB_EPI32": return Intrinsic._MM256_MASKZ_SUB_EPI32;
                case "_MM256_MASKZ_SUB_EPI64": return Intrinsic._MM256_MASKZ_SUB_EPI64;
                case "_MM256_MASKZ_SUB_EPI8": return Intrinsic._MM256_MASKZ_SUB_EPI8;
                case "_MM256_MASKZ_SUB_PD": return Intrinsic._MM256_MASKZ_SUB_PD;
                case "_MM256_MASKZ_SUB_PS": return Intrinsic._MM256_MASKZ_SUB_PS;
                case "_MM256_MASKZ_SUBS_EPI16": return Intrinsic._MM256_MASKZ_SUBS_EPI16;
                case "_MM256_MASKZ_SUBS_EPI8": return Intrinsic._MM256_MASKZ_SUBS_EPI8;
                case "_MM256_MASKZ_SUBS_EPU16": return Intrinsic._MM256_MASKZ_SUBS_EPU16;
                case "_MM256_MASKZ_SUBS_EPU8": return Intrinsic._MM256_MASKZ_SUBS_EPU8;
                case "_MM256_MASKZ_TERNARYLOGIC_EPI32": return Intrinsic._MM256_MASKZ_TERNARYLOGIC_EPI32;
                case "_MM256_MASKZ_TERNARYLOGIC_EPI64": return Intrinsic._MM256_MASKZ_TERNARYLOGIC_EPI64;
                case "_MM256_MASKZ_UNPACKHI_EPI16": return Intrinsic._MM256_MASKZ_UNPACKHI_EPI16;
                case "_MM256_MASKZ_UNPACKHI_EPI32": return Intrinsic._MM256_MASKZ_UNPACKHI_EPI32;
                case "_MM256_MASKZ_UNPACKHI_EPI64": return Intrinsic._MM256_MASKZ_UNPACKHI_EPI64;
                case "_MM256_MASKZ_UNPACKHI_EPI8": return Intrinsic._MM256_MASKZ_UNPACKHI_EPI8;
                case "_MM256_MASKZ_UNPACKHI_PD": return Intrinsic._MM256_MASKZ_UNPACKHI_PD;
                case "_MM256_MASKZ_UNPACKHI_PS": return Intrinsic._MM256_MASKZ_UNPACKHI_PS;
                case "_MM256_MASKZ_UNPACKLO_EPI16": return Intrinsic._MM256_MASKZ_UNPACKLO_EPI16;
                case "_MM256_MASKZ_UNPACKLO_EPI32": return Intrinsic._MM256_MASKZ_UNPACKLO_EPI32;
                case "_MM256_MASKZ_UNPACKLO_EPI64": return Intrinsic._MM256_MASKZ_UNPACKLO_EPI64;
                case "_MM256_MASKZ_UNPACKLO_EPI8": return Intrinsic._MM256_MASKZ_UNPACKLO_EPI8;
                case "_MM256_MASKZ_UNPACKLO_PD": return Intrinsic._MM256_MASKZ_UNPACKLO_PD;
                case "_MM256_MASKZ_UNPACKLO_PS": return Intrinsic._MM256_MASKZ_UNPACKLO_PS;
                case "_MM256_MASKZ_XOR_EPI32": return Intrinsic._MM256_MASKZ_XOR_EPI32;
                case "_MM256_MASKZ_XOR_EPI64": return Intrinsic._MM256_MASKZ_XOR_EPI64;
                case "_MM256_MASKZ_XOR_PD": return Intrinsic._MM256_MASKZ_XOR_PD;
                case "_MM256_MASKZ_XOR_PS": return Intrinsic._MM256_MASKZ_XOR_PS;
                case "_MM256_MAX_EPI16": return Intrinsic._MM256_MAX_EPI16;
                case "_MM256_MAX_EPI32": return Intrinsic._MM256_MAX_EPI32;
                case "_MM256_MAX_EPI64": return Intrinsic._MM256_MAX_EPI64;
                case "_MM256_MAX_EPI8": return Intrinsic._MM256_MAX_EPI8;
                case "_MM256_MAX_EPU16": return Intrinsic._MM256_MAX_EPU16;
                case "_MM256_MAX_EPU32": return Intrinsic._MM256_MAX_EPU32;
                case "_MM256_MAX_EPU64": return Intrinsic._MM256_MAX_EPU64;
                case "_MM256_MAX_EPU8": return Intrinsic._MM256_MAX_EPU8;
                case "_MM256_MAX_PD": return Intrinsic._MM256_MAX_PD;
                case "_MM256_MAX_PS": return Intrinsic._MM256_MAX_PS;
                case "_MM256_MIN_EPI16": return Intrinsic._MM256_MIN_EPI16;
                case "_MM256_MIN_EPI32": return Intrinsic._MM256_MIN_EPI32;
                case "_MM256_MIN_EPI64": return Intrinsic._MM256_MIN_EPI64;
                case "_MM256_MIN_EPI8": return Intrinsic._MM256_MIN_EPI8;
                case "_MM256_MIN_EPU16": return Intrinsic._MM256_MIN_EPU16;
                case "_MM256_MIN_EPU32": return Intrinsic._MM256_MIN_EPU32;
                case "_MM256_MIN_EPU64": return Intrinsic._MM256_MIN_EPU64;
                case "_MM256_MIN_EPU8": return Intrinsic._MM256_MIN_EPU8;
                case "_MM256_MIN_PD": return Intrinsic._MM256_MIN_PD;
                case "_MM256_MIN_PS": return Intrinsic._MM256_MIN_PS;
                case "_MM256_MMASK_I32GATHER_EPI32": return Intrinsic._MM256_MMASK_I32GATHER_EPI32;
                case "_MM256_MMASK_I32GATHER_EPI64": return Intrinsic._MM256_MMASK_I32GATHER_EPI64;
                case "_MM256_MMASK_I32GATHER_PD": return Intrinsic._MM256_MMASK_I32GATHER_PD;
                case "_MM256_MMASK_I32GATHER_PS": return Intrinsic._MM256_MMASK_I32GATHER_PS;
                case "_MM256_MMASK_I64GATHER_EPI32": return Intrinsic._MM256_MMASK_I64GATHER_EPI32;
                case "_MM256_MMASK_I64GATHER_EPI64": return Intrinsic._MM256_MMASK_I64GATHER_EPI64;
                case "_MM256_MMASK_I64GATHER_PD": return Intrinsic._MM256_MMASK_I64GATHER_PD;
                case "_MM256_MMASK_I64GATHER_PS": return Intrinsic._MM256_MMASK_I64GATHER_PS;
                case "_MM256_MOVEDUP_PD": return Intrinsic._MM256_MOVEDUP_PD;
                case "_MM256_MOVEHDUP_PS": return Intrinsic._MM256_MOVEHDUP_PS;
                case "_MM256_MOVELDUP_PS": return Intrinsic._MM256_MOVELDUP_PS;
                case "_MM256_MOVEMASK_EPI8": return Intrinsic._MM256_MOVEMASK_EPI8;
                case "_MM256_MOVEMASK_PD": return Intrinsic._MM256_MOVEMASK_PD;
                case "_MM256_MOVEMASK_PS": return Intrinsic._MM256_MOVEMASK_PS;
                case "_MM256_MOVEPI16_MASK": return Intrinsic._MM256_MOVEPI16_MASK;
                case "_MM256_MOVEPI32_MASK": return Intrinsic._MM256_MOVEPI32_MASK;
                case "_MM256_MOVEPI64_MASK": return Intrinsic._MM256_MOVEPI64_MASK;
                case "_MM256_MOVEPI8_MASK": return Intrinsic._MM256_MOVEPI8_MASK;
                case "_MM256_MOVM_EPI16": return Intrinsic._MM256_MOVM_EPI16;
                case "_MM256_MOVM_EPI32": return Intrinsic._MM256_MOVM_EPI32;
                case "_MM256_MOVM_EPI64": return Intrinsic._MM256_MOVM_EPI64;
                case "_MM256_MOVM_EPI8": return Intrinsic._MM256_MOVM_EPI8;
                case "_MM256_MPSADBW_EPU8": return Intrinsic._MM256_MPSADBW_EPU8;
                case "_MM256_MUL_EPI32": return Intrinsic._MM256_MUL_EPI32;
                case "_MM256_MUL_EPU32": return Intrinsic._MM256_MUL_EPU32;
                case "_MM256_MUL_PD": return Intrinsic._MM256_MUL_PD;
                case "_MM256_MUL_PS": return Intrinsic._MM256_MUL_PS;
                case "_MM256_MULHI_EPI16": return Intrinsic._MM256_MULHI_EPI16;
                case "_MM256_MULHI_EPU16": return Intrinsic._MM256_MULHI_EPU16;
                case "_MM256_MULHRS_EPI16": return Intrinsic._MM256_MULHRS_EPI16;
                case "_MM256_MULLO_EPI16": return Intrinsic._MM256_MULLO_EPI16;
                case "_MM256_MULLO_EPI32": return Intrinsic._MM256_MULLO_EPI32;
                case "_MM256_MULLO_EPI64": return Intrinsic._MM256_MULLO_EPI64;
                case "_MM256_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM256_MULTISHIFT_EPI64_EPI8;
                case "_MM256_OR_PD": return Intrinsic._MM256_OR_PD;
                case "_MM256_OR_PS": return Intrinsic._MM256_OR_PS;
                case "_MM256_OR_SI256": return Intrinsic._MM256_OR_SI256;
                case "_MM256_PACKS_EPI16": return Intrinsic._MM256_PACKS_EPI16;
                case "_MM256_PACKS_EPI32": return Intrinsic._MM256_PACKS_EPI32;
                case "_MM256_PACKUS_EPI16": return Intrinsic._MM256_PACKUS_EPI16;
                case "_MM256_PACKUS_EPI32": return Intrinsic._MM256_PACKUS_EPI32;
                case "_MM256_PERMUTE_PD": return Intrinsic._MM256_PERMUTE_PD;
                case "_MM256_PERMUTE_PS": return Intrinsic._MM256_PERMUTE_PS;
                case "_MM256_PERMUTE2F128_PD": return Intrinsic._MM256_PERMUTE2F128_PD;
                case "_MM256_PERMUTE2F128_PS": return Intrinsic._MM256_PERMUTE2F128_PS;
                case "_MM256_PERMUTE2F128_SI256": return Intrinsic._MM256_PERMUTE2F128_SI256;
                case "_MM256_PERMUTE2X128_SI256": return Intrinsic._MM256_PERMUTE2X128_SI256;
                case "_MM256_PERMUTE4X64_EPI64": return Intrinsic._MM256_PERMUTE4X64_EPI64;
                case "_MM256_PERMUTE4X64_PD": return Intrinsic._MM256_PERMUTE4X64_PD;
                case "_MM256_PERMUTEVAR_PD": return Intrinsic._MM256_PERMUTEVAR_PD;
                case "_MM256_PERMUTEVAR_PS": return Intrinsic._MM256_PERMUTEVAR_PS;
                case "_MM256_PERMUTEVAR8X32_EPI32": return Intrinsic._MM256_PERMUTEVAR8X32_EPI32;
                case "_MM256_PERMUTEVAR8X32_PS": return Intrinsic._MM256_PERMUTEVAR8X32_PS;
                case "_MM256_PERMUTEX_EPI64": return Intrinsic._MM256_PERMUTEX_EPI64;
                case "_MM256_PERMUTEX_PD": return Intrinsic._MM256_PERMUTEX_PD;
                case "_MM256_PERMUTEX2VAR_EPI16": return Intrinsic._MM256_PERMUTEX2VAR_EPI16;
                case "_MM256_PERMUTEX2VAR_EPI32": return Intrinsic._MM256_PERMUTEX2VAR_EPI32;
                case "_MM256_PERMUTEX2VAR_EPI64": return Intrinsic._MM256_PERMUTEX2VAR_EPI64;
                case "_MM256_PERMUTEX2VAR_EPI8": return Intrinsic._MM256_PERMUTEX2VAR_EPI8;
                case "_MM256_PERMUTEX2VAR_PD": return Intrinsic._MM256_PERMUTEX2VAR_PD;
                case "_MM256_PERMUTEX2VAR_PS": return Intrinsic._MM256_PERMUTEX2VAR_PS;
                case "_MM256_PERMUTEXVAR_EPI16": return Intrinsic._MM256_PERMUTEXVAR_EPI16;
                case "_MM256_PERMUTEXVAR_EPI32": return Intrinsic._MM256_PERMUTEXVAR_EPI32;
                case "_MM256_PERMUTEXVAR_EPI64": return Intrinsic._MM256_PERMUTEXVAR_EPI64;
                case "_MM256_PERMUTEXVAR_EPI8": return Intrinsic._MM256_PERMUTEXVAR_EPI8;
                case "_MM256_PERMUTEXVAR_PD": return Intrinsic._MM256_PERMUTEXVAR_PD;
                case "_MM256_PERMUTEXVAR_PS": return Intrinsic._MM256_PERMUTEXVAR_PS;
                case "_MM256_POW_PD": return Intrinsic._MM256_POW_PD;
                case "_MM256_POW_PS": return Intrinsic._MM256_POW_PS;
                case "_MM256_RANGE_PD": return Intrinsic._MM256_RANGE_PD;
                case "_MM256_RANGE_PS": return Intrinsic._MM256_RANGE_PS;
                case "_MM256_RCP_PS": return Intrinsic._MM256_RCP_PS;
                case "_MM256_RCP14_PD": return Intrinsic._MM256_RCP14_PD;
                case "_MM256_RCP14_PS": return Intrinsic._MM256_RCP14_PS;
                case "_MM256_REDUCE_PD": return Intrinsic._MM256_REDUCE_PD;
                case "_MM256_REDUCE_PS": return Intrinsic._MM256_REDUCE_PS;
                case "_MM256_REM_EPI16": return Intrinsic._MM256_REM_EPI16;
                case "_MM256_REM_EPI32": return Intrinsic._MM256_REM_EPI32;
                case "_MM256_REM_EPI64": return Intrinsic._MM256_REM_EPI64;
                case "_MM256_REM_EPI8": return Intrinsic._MM256_REM_EPI8;
                case "_MM256_REM_EPU16": return Intrinsic._MM256_REM_EPU16;
                case "_MM256_REM_EPU32": return Intrinsic._MM256_REM_EPU32;
                case "_MM256_REM_EPU64": return Intrinsic._MM256_REM_EPU64;
                case "_MM256_REM_EPU8": return Intrinsic._MM256_REM_EPU8;
                case "_MM256_ROL_EPI32": return Intrinsic._MM256_ROL_EPI32;
                case "_MM256_ROL_EPI64": return Intrinsic._MM256_ROL_EPI64;
                case "_MM256_ROLV_EPI32": return Intrinsic._MM256_ROLV_EPI32;
                case "_MM256_ROLV_EPI64": return Intrinsic._MM256_ROLV_EPI64;
                case "_MM256_ROR_EPI32": return Intrinsic._MM256_ROR_EPI32;
                case "_MM256_ROR_EPI64": return Intrinsic._MM256_ROR_EPI64;
                case "_MM256_RORV_EPI32": return Intrinsic._MM256_RORV_EPI32;
                case "_MM256_RORV_EPI64": return Intrinsic._MM256_RORV_EPI64;
                case "_MM256_ROUND_PD": return Intrinsic._MM256_ROUND_PD;
                case "_MM256_ROUND_PS": return Intrinsic._MM256_ROUND_PS;
                case "_MM256_ROUNDSCALE_PD": return Intrinsic._MM256_ROUNDSCALE_PD;
                case "_MM256_ROUNDSCALE_PS": return Intrinsic._MM256_ROUNDSCALE_PS;
                case "_MM256_RSQRT_PS": return Intrinsic._MM256_RSQRT_PS;
                case "_MM256_SAD_EPU8": return Intrinsic._MM256_SAD_EPU8;
                case "_MM256_SCALEF_PD": return Intrinsic._MM256_SCALEF_PD;
                case "_MM256_SCALEF_PS": return Intrinsic._MM256_SCALEF_PS;
                case "_MM256_SET_EPI16": return Intrinsic._MM256_SET_EPI16;
                case "_MM256_SET_EPI32": return Intrinsic._MM256_SET_EPI32;
                case "_MM256_SET_EPI64X": return Intrinsic._MM256_SET_EPI64X;
                case "_MM256_SET_EPI8": return Intrinsic._MM256_SET_EPI8;
                case "_MM256_SET_M128": return Intrinsic._MM256_SET_M128;
                case "_MM256_SET_M128D": return Intrinsic._MM256_SET_M128D;
                case "_MM256_SET_M128I": return Intrinsic._MM256_SET_M128I;
                case "_MM256_SET_PD": return Intrinsic._MM256_SET_PD;
                case "_MM256_SET_PS": return Intrinsic._MM256_SET_PS;
                case "_MM256_SET1_EPI16": return Intrinsic._MM256_SET1_EPI16;
                case "_MM256_SET1_EPI32": return Intrinsic._MM256_SET1_EPI32;
                case "_MM256_SET1_EPI64X": return Intrinsic._MM256_SET1_EPI64X;
                case "_MM256_SET1_EPI8": return Intrinsic._MM256_SET1_EPI8;
                case "_MM256_SET1_PD": return Intrinsic._MM256_SET1_PD;
                case "_MM256_SET1_PS": return Intrinsic._MM256_SET1_PS;
                case "_MM256_SETR_EPI16": return Intrinsic._MM256_SETR_EPI16;
                case "_MM256_SETR_EPI32": return Intrinsic._MM256_SETR_EPI32;
                case "_MM256_SETR_EPI64X": return Intrinsic._MM256_SETR_EPI64X;
                case "_MM256_SETR_EPI8": return Intrinsic._MM256_SETR_EPI8;
                case "_MM256_SETR_M128": return Intrinsic._MM256_SETR_M128;
                case "_MM256_SETR_M128D": return Intrinsic._MM256_SETR_M128D;
                case "_MM256_SETR_M128I": return Intrinsic._MM256_SETR_M128I;
                case "_MM256_SETR_PD": return Intrinsic._MM256_SETR_PD;
                case "_MM256_SETR_PS": return Intrinsic._MM256_SETR_PS;
                case "_MM256_SETZERO_PD": return Intrinsic._MM256_SETZERO_PD;
                case "_MM256_SETZERO_PS": return Intrinsic._MM256_SETZERO_PS;
                case "_MM256_SETZERO_SI256": return Intrinsic._MM256_SETZERO_SI256;
                case "_MM256_SHUFFLE_EPI32": return Intrinsic._MM256_SHUFFLE_EPI32;
                case "_MM256_SHUFFLE_EPI8": return Intrinsic._MM256_SHUFFLE_EPI8;
                case "_MM256_SHUFFLE_F32X4": return Intrinsic._MM256_SHUFFLE_F32X4;
                case "_MM256_SHUFFLE_F64X2": return Intrinsic._MM256_SHUFFLE_F64X2;
                case "_MM256_SHUFFLE_I32X4": return Intrinsic._MM256_SHUFFLE_I32X4;
                case "_MM256_SHUFFLE_I64X2": return Intrinsic._MM256_SHUFFLE_I64X2;
                case "_MM256_SHUFFLE_PD": return Intrinsic._MM256_SHUFFLE_PD;
                case "_MM256_SHUFFLE_PS": return Intrinsic._MM256_SHUFFLE_PS;
                case "_MM256_SHUFFLEHI_EPI16": return Intrinsic._MM256_SHUFFLEHI_EPI16;
                case "_MM256_SHUFFLELO_EPI16": return Intrinsic._MM256_SHUFFLELO_EPI16;
                case "_MM256_SIGN_EPI16": return Intrinsic._MM256_SIGN_EPI16;
                case "_MM256_SIGN_EPI32": return Intrinsic._MM256_SIGN_EPI32;
                case "_MM256_SIGN_EPI8": return Intrinsic._MM256_SIGN_EPI8;
                case "_MM256_SIN_PD": return Intrinsic._MM256_SIN_PD;
                case "_MM256_SIN_PS": return Intrinsic._MM256_SIN_PS;
                case "_MM256_SINCOS_PD": return Intrinsic._MM256_SINCOS_PD;
                case "_MM256_SINCOS_PS": return Intrinsic._MM256_SINCOS_PS;
                case "_MM256_SIND_PD": return Intrinsic._MM256_SIND_PD;
                case "_MM256_SIND_PS": return Intrinsic._MM256_SIND_PS;
                case "_MM256_SINH_PD": return Intrinsic._MM256_SINH_PD;
                case "_MM256_SINH_PS": return Intrinsic._MM256_SINH_PS;
                case "_MM256_SLL_EPI16": return Intrinsic._MM256_SLL_EPI16;
                case "_MM256_SLL_EPI32": return Intrinsic._MM256_SLL_EPI32;
                case "_MM256_SLL_EPI64": return Intrinsic._MM256_SLL_EPI64;
                case "_MM256_SLLI_EPI16": return Intrinsic._MM256_SLLI_EPI16;
                case "_MM256_SLLI_EPI32": return Intrinsic._MM256_SLLI_EPI32;
                case "_MM256_SLLI_EPI64": return Intrinsic._MM256_SLLI_EPI64;
                case "_MM256_SLLI_SI256": return Intrinsic._MM256_SLLI_SI256;
                case "_MM256_SLLV_EPI16": return Intrinsic._MM256_SLLV_EPI16;
                case "_MM256_SLLV_EPI32": return Intrinsic._MM256_SLLV_EPI32;
                case "_MM256_SLLV_EPI64": return Intrinsic._MM256_SLLV_EPI64;
                case "_MM256_SQRT_PD": return Intrinsic._MM256_SQRT_PD;
                case "_MM256_SQRT_PS": return Intrinsic._MM256_SQRT_PS;
                case "_MM256_SRA_EPI16": return Intrinsic._MM256_SRA_EPI16;
                case "_MM256_SRA_EPI32": return Intrinsic._MM256_SRA_EPI32;
                case "_MM256_SRA_EPI64": return Intrinsic._MM256_SRA_EPI64;
                case "_MM256_SRAI_EPI16": return Intrinsic._MM256_SRAI_EPI16;
                case "_MM256_SRAI_EPI32": return Intrinsic._MM256_SRAI_EPI32;
                case "_MM256_SRAI_EPI64": return Intrinsic._MM256_SRAI_EPI64;
                case "_MM256_SRAV_EPI16": return Intrinsic._MM256_SRAV_EPI16;
                case "_MM256_SRAV_EPI32": return Intrinsic._MM256_SRAV_EPI32;
                case "_MM256_SRAV_EPI64": return Intrinsic._MM256_SRAV_EPI64;
                case "_MM256_SRL_EPI16": return Intrinsic._MM256_SRL_EPI16;
                case "_MM256_SRL_EPI32": return Intrinsic._MM256_SRL_EPI32;
                case "_MM256_SRL_EPI64": return Intrinsic._MM256_SRL_EPI64;
                case "_MM256_SRLI_EPI16": return Intrinsic._MM256_SRLI_EPI16;
                case "_MM256_SRLI_EPI32": return Intrinsic._MM256_SRLI_EPI32;
                case "_MM256_SRLI_EPI64": return Intrinsic._MM256_SRLI_EPI64;
                case "_MM256_SRLI_SI256": return Intrinsic._MM256_SRLI_SI256;
                case "_MM256_SRLV_EPI16": return Intrinsic._MM256_SRLV_EPI16;
                case "_MM256_SRLV_EPI32": return Intrinsic._MM256_SRLV_EPI32;
                case "_MM256_SRLV_EPI64": return Intrinsic._MM256_SRLV_EPI64;
                case "_MM256_STORE_PD": return Intrinsic._MM256_STORE_PD;
                case "_MM256_STORE_PS": return Intrinsic._MM256_STORE_PS;
                case "_MM256_STORE_SI256": return Intrinsic._MM256_STORE_SI256;
                case "_MM256_STOREU_PD": return Intrinsic._MM256_STOREU_PD;
                case "_MM256_STOREU_PS": return Intrinsic._MM256_STOREU_PS;
                case "_MM256_STOREU_SI256": return Intrinsic._MM256_STOREU_SI256;
                case "_MM256_STOREU2_M128": return Intrinsic._MM256_STOREU2_M128;
                case "_MM256_STOREU2_M128D": return Intrinsic._MM256_STOREU2_M128D;
                case "_MM256_STOREU2_M128I": return Intrinsic._MM256_STOREU2_M128I;
                case "_MM256_STREAM_LOAD_SI256": return Intrinsic._MM256_STREAM_LOAD_SI256;
                case "_MM256_STREAM_PD": return Intrinsic._MM256_STREAM_PD;
                case "_MM256_STREAM_PS": return Intrinsic._MM256_STREAM_PS;
                case "_MM256_STREAM_SI256": return Intrinsic._MM256_STREAM_SI256;
                case "_MM256_SUB_EPI16": return Intrinsic._MM256_SUB_EPI16;
                case "_MM256_SUB_EPI32": return Intrinsic._MM256_SUB_EPI32;
                case "_MM256_SUB_EPI64": return Intrinsic._MM256_SUB_EPI64;
                case "_MM256_SUB_EPI8": return Intrinsic._MM256_SUB_EPI8;
                case "_MM256_SUB_PD": return Intrinsic._MM256_SUB_PD;
                case "_MM256_SUB_PS": return Intrinsic._MM256_SUB_PS;
                case "_MM256_SUBS_EPI16": return Intrinsic._MM256_SUBS_EPI16;
                case "_MM256_SUBS_EPI8": return Intrinsic._MM256_SUBS_EPI8;
                case "_MM256_SUBS_EPU16": return Intrinsic._MM256_SUBS_EPU16;
                case "_MM256_SUBS_EPU8": return Intrinsic._MM256_SUBS_EPU8;
                case "_MM256_SVML_CEIL_PD": return Intrinsic._MM256_SVML_CEIL_PD;
                case "_MM256_SVML_CEIL_PS": return Intrinsic._MM256_SVML_CEIL_PS;
                case "_MM256_SVML_FLOOR_PD": return Intrinsic._MM256_SVML_FLOOR_PD;
                case "_MM256_SVML_FLOOR_PS": return Intrinsic._MM256_SVML_FLOOR_PS;
                case "_MM256_SVML_ROUND_PD": return Intrinsic._MM256_SVML_ROUND_PD;
                case "_MM256_SVML_ROUND_PS": return Intrinsic._MM256_SVML_ROUND_PS;
                case "_MM256_SVML_SQRT_PD": return Intrinsic._MM256_SVML_SQRT_PD;
                case "_MM256_SVML_SQRT_PS": return Intrinsic._MM256_SVML_SQRT_PS;
                case "_MM256_TAN_PD": return Intrinsic._MM256_TAN_PD;
                case "_MM256_TAN_PS": return Intrinsic._MM256_TAN_PS;
                case "_MM256_TAND_PD": return Intrinsic._MM256_TAND_PD;
                case "_MM256_TAND_PS": return Intrinsic._MM256_TAND_PS;
                case "_MM256_TANH_PD": return Intrinsic._MM256_TANH_PD;
                case "_MM256_TANH_PS": return Intrinsic._MM256_TANH_PS;
                case "_MM256_TERNARYLOGIC_EPI32": return Intrinsic._MM256_TERNARYLOGIC_EPI32;
                case "_MM256_TERNARYLOGIC_EPI64": return Intrinsic._MM256_TERNARYLOGIC_EPI64;
                case "_MM256_TEST_EPI16_MASK": return Intrinsic._MM256_TEST_EPI16_MASK;
                case "_MM256_TEST_EPI32_MASK": return Intrinsic._MM256_TEST_EPI32_MASK;
                case "_MM256_TEST_EPI64_MASK": return Intrinsic._MM256_TEST_EPI64_MASK;
                case "_MM256_TEST_EPI8_MASK": return Intrinsic._MM256_TEST_EPI8_MASK;
                case "_MM256_TESTC_PD": return Intrinsic._MM256_TESTC_PD;
                case "_MM256_TESTC_PS": return Intrinsic._MM256_TESTC_PS;
                case "_MM256_TESTC_SI256": return Intrinsic._MM256_TESTC_SI256;
                case "_MM256_TESTN_EPI16_MASK": return Intrinsic._MM256_TESTN_EPI16_MASK;
                case "_MM256_TESTN_EPI32_MASK": return Intrinsic._MM256_TESTN_EPI32_MASK;
                case "_MM256_TESTN_EPI64_MASK": return Intrinsic._MM256_TESTN_EPI64_MASK;
                case "_MM256_TESTN_EPI8_MASK": return Intrinsic._MM256_TESTN_EPI8_MASK;
                case "_MM256_TESTNZC_PD": return Intrinsic._MM256_TESTNZC_PD;
                case "_MM256_TESTNZC_PS": return Intrinsic._MM256_TESTNZC_PS;
                case "_MM256_TESTNZC_SI256": return Intrinsic._MM256_TESTNZC_SI256;
                case "_MM256_TESTZ_PD": return Intrinsic._MM256_TESTZ_PD;
                case "_MM256_TESTZ_PS": return Intrinsic._MM256_TESTZ_PS;
                case "_MM256_TESTZ_SI256": return Intrinsic._MM256_TESTZ_SI256;
                case "_MM256_TRUNC_PD": return Intrinsic._MM256_TRUNC_PD;
                case "_MM256_TRUNC_PS": return Intrinsic._MM256_TRUNC_PS;
                case "_MM256_UDIV_EPI32": return Intrinsic._MM256_UDIV_EPI32;
                case "_MM256_UDIVREM_EPI32": return Intrinsic._MM256_UDIVREM_EPI32;
                case "_MM256_UNDEFINED_PD": return Intrinsic._MM256_UNDEFINED_PD;
                case "_MM256_UNDEFINED_PS": return Intrinsic._MM256_UNDEFINED_PS;
                case "_MM256_UNDEFINED_SI256": return Intrinsic._MM256_UNDEFINED_SI256;
                case "_MM256_UNPACKHI_EPI16": return Intrinsic._MM256_UNPACKHI_EPI16;
                case "_MM256_UNPACKHI_EPI32": return Intrinsic._MM256_UNPACKHI_EPI32;
                case "_MM256_UNPACKHI_EPI64": return Intrinsic._MM256_UNPACKHI_EPI64;
                case "_MM256_UNPACKHI_EPI8": return Intrinsic._MM256_UNPACKHI_EPI8;
                case "_MM256_UNPACKHI_PD": return Intrinsic._MM256_UNPACKHI_PD;
                case "_MM256_UNPACKHI_PS": return Intrinsic._MM256_UNPACKHI_PS;
                case "_MM256_UNPACKLO_EPI16": return Intrinsic._MM256_UNPACKLO_EPI16;
                case "_MM256_UNPACKLO_EPI32": return Intrinsic._MM256_UNPACKLO_EPI32;
                case "_MM256_UNPACKLO_EPI64": return Intrinsic._MM256_UNPACKLO_EPI64;
                case "_MM256_UNPACKLO_EPI8": return Intrinsic._MM256_UNPACKLO_EPI8;
                case "_MM256_UNPACKLO_PD": return Intrinsic._MM256_UNPACKLO_PD;
                case "_MM256_UNPACKLO_PS": return Intrinsic._MM256_UNPACKLO_PS;
                case "_MM256_UREM_EPI32": return Intrinsic._MM256_UREM_EPI32;
                case "_MM256_XOR_PD": return Intrinsic._MM256_XOR_PD;
                case "_MM256_XOR_PS": return Intrinsic._MM256_XOR_PS;
                case "_MM256_XOR_SI256": return Intrinsic._MM256_XOR_SI256;
                case "_MM256_ZEROALL": return Intrinsic._MM256_ZEROALL;
                case "_MM256_ZEROUPPER": return Intrinsic._MM256_ZEROUPPER;
                case "_MM512_ABS_EPI16": return Intrinsic._MM512_ABS_EPI16;
                case "_MM512_ABS_EPI32": return Intrinsic._MM512_ABS_EPI32;
                case "_MM512_ABS_EPI64": return Intrinsic._MM512_ABS_EPI64;
                case "_MM512_ABS_EPI8": return Intrinsic._MM512_ABS_EPI8;
                case "_MM512_ABS_PD": return Intrinsic._MM512_ABS_PD;
                case "_MM512_ABS_PS": return Intrinsic._MM512_ABS_PS;
                case "_MM512_ACOS_PD": return Intrinsic._MM512_ACOS_PD;
                case "_MM512_ACOS_PS": return Intrinsic._MM512_ACOS_PS;
                case "_MM512_ACOSH_PD": return Intrinsic._MM512_ACOSH_PD;
                case "_MM512_ACOSH_PS": return Intrinsic._MM512_ACOSH_PS;
                case "_MM512_ADC_EPI32": return Intrinsic._MM512_ADC_EPI32;
                case "_MM512_ADD_EPI16": return Intrinsic._MM512_ADD_EPI16;
                case "_MM512_ADD_EPI32": return Intrinsic._MM512_ADD_EPI32;
                case "_MM512_ADD_EPI64": return Intrinsic._MM512_ADD_EPI64;
                case "_MM512_ADD_EPI8": return Intrinsic._MM512_ADD_EPI8;
                case "_MM512_ADD_PD": return Intrinsic._MM512_ADD_PD;
                case "_MM512_ADD_PS": return Intrinsic._MM512_ADD_PS;
                case "_MM512_ADD_ROUND_PD": return Intrinsic._MM512_ADD_ROUND_PD;
                case "_MM512_ADD_ROUND_PS": return Intrinsic._MM512_ADD_ROUND_PS;
                case "_MM512_ADDN_PD": return Intrinsic._MM512_ADDN_PD;
                case "_MM512_ADDN_PS": return Intrinsic._MM512_ADDN_PS;
                case "_MM512_ADDN_ROUND_PD": return Intrinsic._MM512_ADDN_ROUND_PD;
                case "_MM512_ADDN_ROUND_PS": return Intrinsic._MM512_ADDN_ROUND_PS;
                case "_MM512_ADDS_EPI16": return Intrinsic._MM512_ADDS_EPI16;
                case "_MM512_ADDS_EPI8": return Intrinsic._MM512_ADDS_EPI8;
                case "_MM512_ADDS_EPU16": return Intrinsic._MM512_ADDS_EPU16;
                case "_MM512_ADDS_EPU8": return Intrinsic._MM512_ADDS_EPU8;
                case "_MM512_ADDSETC_EPI32": return Intrinsic._MM512_ADDSETC_EPI32;
                case "_MM512_ADDSETS_EPI32": return Intrinsic._MM512_ADDSETS_EPI32;
                case "_MM512_ADDSETS_PS": return Intrinsic._MM512_ADDSETS_PS;
                case "_MM512_ADDSETS_ROUND_PS": return Intrinsic._MM512_ADDSETS_ROUND_PS;
                case "_MM512_ALIGNR_EPI32": return Intrinsic._MM512_ALIGNR_EPI32;
                case "_MM512_ALIGNR_EPI64": return Intrinsic._MM512_ALIGNR_EPI64;
                case "_MM512_ALIGNR_EPI8": return Intrinsic._MM512_ALIGNR_EPI8;
                case "_MM512_AND_EPI32": return Intrinsic._MM512_AND_EPI32;
                case "_MM512_AND_EPI64": return Intrinsic._MM512_AND_EPI64;
                case "_MM512_AND_PD": return Intrinsic._MM512_AND_PD;
                case "_MM512_AND_PS": return Intrinsic._MM512_AND_PS;
                case "_MM512_AND_SI512": return Intrinsic._MM512_AND_SI512;
                case "_MM512_ANDNOT_EPI32": return Intrinsic._MM512_ANDNOT_EPI32;
                case "_MM512_ANDNOT_EPI64": return Intrinsic._MM512_ANDNOT_EPI64;
                case "_MM512_ANDNOT_PD": return Intrinsic._MM512_ANDNOT_PD;
                case "_MM512_ANDNOT_PS": return Intrinsic._MM512_ANDNOT_PS;
                case "_MM512_ANDNOT_SI512": return Intrinsic._MM512_ANDNOT_SI512;
                case "_MM512_ASIN_PD": return Intrinsic._MM512_ASIN_PD;
                case "_MM512_ASIN_PS": return Intrinsic._MM512_ASIN_PS;
                case "_MM512_ASINH_PD": return Intrinsic._MM512_ASINH_PD;
                case "_MM512_ASINH_PS": return Intrinsic._MM512_ASINH_PS;
                case "_MM512_ATAN_PD": return Intrinsic._MM512_ATAN_PD;
                case "_MM512_ATAN_PS": return Intrinsic._MM512_ATAN_PS;
                case "_MM512_ATAN2_PD": return Intrinsic._MM512_ATAN2_PD;
                case "_MM512_ATAN2_PS": return Intrinsic._MM512_ATAN2_PS;
                case "_MM512_ATANH_PD": return Intrinsic._MM512_ATANH_PD;
                case "_MM512_ATANH_PS": return Intrinsic._MM512_ATANH_PS;
                case "_MM512_AVG_EPU16": return Intrinsic._MM512_AVG_EPU16;
                case "_MM512_AVG_EPU8": return Intrinsic._MM512_AVG_EPU8;
                case "_MM512_BROADCAST_F32X2": return Intrinsic._MM512_BROADCAST_F32X2;
                case "_MM512_BROADCAST_F32X4": return Intrinsic._MM512_BROADCAST_F32X4;
                case "_MM512_BROADCAST_F32X8": return Intrinsic._MM512_BROADCAST_F32X8;
                case "_MM512_BROADCAST_F64X2": return Intrinsic._MM512_BROADCAST_F64X2;
                case "_MM512_BROADCAST_F64X4": return Intrinsic._MM512_BROADCAST_F64X4;
                case "_MM512_BROADCAST_I32X2": return Intrinsic._MM512_BROADCAST_I32X2;
                case "_MM512_BROADCAST_I32X4": return Intrinsic._MM512_BROADCAST_I32X4;
                case "_MM512_BROADCAST_I32X8": return Intrinsic._MM512_BROADCAST_I32X8;
                case "_MM512_BROADCAST_I64X2": return Intrinsic._MM512_BROADCAST_I64X2;
                case "_MM512_BROADCAST_I64X4": return Intrinsic._MM512_BROADCAST_I64X4;
                case "_MM512_BROADCASTB_EPI8": return Intrinsic._MM512_BROADCASTB_EPI8;
                case "_MM512_BROADCASTD_EPI32": return Intrinsic._MM512_BROADCASTD_EPI32;
                case "_MM512_BROADCASTMB_EPI64": return Intrinsic._MM512_BROADCASTMB_EPI64;
                case "_MM512_BROADCASTMW_EPI32": return Intrinsic._MM512_BROADCASTMW_EPI32;
                case "_MM512_BROADCASTQ_EPI64": return Intrinsic._MM512_BROADCASTQ_EPI64;
                case "_MM512_BROADCASTSD_PD": return Intrinsic._MM512_BROADCASTSD_PD;
                case "_MM512_BROADCASTSS_PS": return Intrinsic._MM512_BROADCASTSS_PS;
                case "_MM512_BROADCASTW_EPI16": return Intrinsic._MM512_BROADCASTW_EPI16;
                case "_MM512_BSLLI_EPI128": return Intrinsic._MM512_BSLLI_EPI128;
                case "_MM512_BSRLI_EPI128": return Intrinsic._MM512_BSRLI_EPI128;
                case "_MM512_CASTPD_PS": return Intrinsic._MM512_CASTPD_PS;
                case "_MM512_CASTPD_SI512": return Intrinsic._MM512_CASTPD_SI512;
                case "_MM512_CASTPD128_PD512": return Intrinsic._MM512_CASTPD128_PD512;
                case "_MM512_CASTPD256_PD512": return Intrinsic._MM512_CASTPD256_PD512;
                case "_MM512_CASTPD512_PD128": return Intrinsic._MM512_CASTPD512_PD128;
                case "_MM512_CASTPD512_PD256": return Intrinsic._MM512_CASTPD512_PD256;
                case "_MM512_CASTPS_PD": return Intrinsic._MM512_CASTPS_PD;
                case "_MM512_CASTPS_SI512": return Intrinsic._MM512_CASTPS_SI512;
                case "_MM512_CASTPS128_PS512": return Intrinsic._MM512_CASTPS128_PS512;
                case "_MM512_CASTPS256_PS512": return Intrinsic._MM512_CASTPS256_PS512;
                case "_MM512_CASTPS512_PS128": return Intrinsic._MM512_CASTPS512_PS128;
                case "_MM512_CASTPS512_PS256": return Intrinsic._MM512_CASTPS512_PS256;
                case "_MM512_CASTSI128_SI512": return Intrinsic._MM512_CASTSI128_SI512;
                case "_MM512_CASTSI256_SI512": return Intrinsic._MM512_CASTSI256_SI512;
                case "_MM512_CASTSI512_PD": return Intrinsic._MM512_CASTSI512_PD;
                case "_MM512_CASTSI512_PS": return Intrinsic._MM512_CASTSI512_PS;
                case "_MM512_CASTSI512_SI128": return Intrinsic._MM512_CASTSI512_SI128;
                case "_MM512_CASTSI512_SI256": return Intrinsic._MM512_CASTSI512_SI256;
                case "_MM512_CBRT_PD": return Intrinsic._MM512_CBRT_PD;
                case "_MM512_CBRT_PS": return Intrinsic._MM512_CBRT_PS;
                case "_MM512_CDFNORM_PD": return Intrinsic._MM512_CDFNORM_PD;
                case "_MM512_CDFNORM_PS": return Intrinsic._MM512_CDFNORM_PS;
                case "_MM512_CDFNORMINV_PD": return Intrinsic._MM512_CDFNORMINV_PD;
                case "_MM512_CDFNORMINV_PS": return Intrinsic._MM512_CDFNORMINV_PS;
                case "_MM512_CEIL_PD": return Intrinsic._MM512_CEIL_PD;
                case "_MM512_CEIL_PS": return Intrinsic._MM512_CEIL_PS;
                case "_MM512_CMP_EPI16_MASK": return Intrinsic._MM512_CMP_EPI16_MASK;
                case "_MM512_CMP_EPI32_MASK": return Intrinsic._MM512_CMP_EPI32_MASK;
                case "_MM512_CMP_EPI64_MASK": return Intrinsic._MM512_CMP_EPI64_MASK;
                case "_MM512_CMP_EPI8_MASK": return Intrinsic._MM512_CMP_EPI8_MASK;
                case "_MM512_CMP_EPU16_MASK": return Intrinsic._MM512_CMP_EPU16_MASK;
                case "_MM512_CMP_EPU32_MASK": return Intrinsic._MM512_CMP_EPU32_MASK;
                case "_MM512_CMP_EPU64_MASK": return Intrinsic._MM512_CMP_EPU64_MASK;
                case "_MM512_CMP_EPU8_MASK": return Intrinsic._MM512_CMP_EPU8_MASK;
                case "_MM512_CMP_PD_MASK": return Intrinsic._MM512_CMP_PD_MASK;
                case "_MM512_CMP_PS_MASK": return Intrinsic._MM512_CMP_PS_MASK;
                case "_MM512_CMP_ROUND_PD_MASK": return Intrinsic._MM512_CMP_ROUND_PD_MASK;
                case "_MM512_CMP_ROUND_PS_MASK": return Intrinsic._MM512_CMP_ROUND_PS_MASK;
                case "_MM512_CMPEQ_EPI16_MASK": return Intrinsic._MM512_CMPEQ_EPI16_MASK;
                case "_MM512_CMPEQ_EPI32_MASK": return Intrinsic._MM512_CMPEQ_EPI32_MASK;
                case "_MM512_CMPEQ_EPI64_MASK": return Intrinsic._MM512_CMPEQ_EPI64_MASK;
                case "_MM512_CMPEQ_EPI8_MASK": return Intrinsic._MM512_CMPEQ_EPI8_MASK;
                case "_MM512_CMPEQ_EPU16_MASK": return Intrinsic._MM512_CMPEQ_EPU16_MASK;
                case "_MM512_CMPEQ_EPU32_MASK": return Intrinsic._MM512_CMPEQ_EPU32_MASK;
                case "_MM512_CMPEQ_EPU64_MASK": return Intrinsic._MM512_CMPEQ_EPU64_MASK;
                case "_MM512_CMPEQ_EPU8_MASK": return Intrinsic._MM512_CMPEQ_EPU8_MASK;
                case "_MM512_CMPEQ_PD_MASK": return Intrinsic._MM512_CMPEQ_PD_MASK;
                case "_MM512_CMPEQ_PS_MASK": return Intrinsic._MM512_CMPEQ_PS_MASK;
                case "_MM512_CMPGE_EPI16_MASK": return Intrinsic._MM512_CMPGE_EPI16_MASK;
                case "_MM512_CMPGE_EPI32_MASK": return Intrinsic._MM512_CMPGE_EPI32_MASK;
                case "_MM512_CMPGE_EPI64_MASK": return Intrinsic._MM512_CMPGE_EPI64_MASK;
                case "_MM512_CMPGE_EPI8_MASK": return Intrinsic._MM512_CMPGE_EPI8_MASK;
                case "_MM512_CMPGE_EPU16_MASK": return Intrinsic._MM512_CMPGE_EPU16_MASK;
                case "_MM512_CMPGE_EPU32_MASK": return Intrinsic._MM512_CMPGE_EPU32_MASK;
                case "_MM512_CMPGE_EPU64_MASK": return Intrinsic._MM512_CMPGE_EPU64_MASK;
                case "_MM512_CMPGE_EPU8_MASK": return Intrinsic._MM512_CMPGE_EPU8_MASK;
                case "_MM512_CMPGT_EPI16_MASK": return Intrinsic._MM512_CMPGT_EPI16_MASK;
                case "_MM512_CMPGT_EPI32_MASK": return Intrinsic._MM512_CMPGT_EPI32_MASK;
                case "_MM512_CMPGT_EPI64_MASK": return Intrinsic._MM512_CMPGT_EPI64_MASK;
                case "_MM512_CMPGT_EPI8_MASK": return Intrinsic._MM512_CMPGT_EPI8_MASK;
                case "_MM512_CMPGT_EPU16_MASK": return Intrinsic._MM512_CMPGT_EPU16_MASK;
                case "_MM512_CMPGT_EPU32_MASK": return Intrinsic._MM512_CMPGT_EPU32_MASK;
                case "_MM512_CMPGT_EPU64_MASK": return Intrinsic._MM512_CMPGT_EPU64_MASK;
                case "_MM512_CMPGT_EPU8_MASK": return Intrinsic._MM512_CMPGT_EPU8_MASK;
                case "_MM512_CMPLE_EPI16_MASK": return Intrinsic._MM512_CMPLE_EPI16_MASK;
                case "_MM512_CMPLE_EPI32_MASK": return Intrinsic._MM512_CMPLE_EPI32_MASK;
                case "_MM512_CMPLE_EPI64_MASK": return Intrinsic._MM512_CMPLE_EPI64_MASK;
                case "_MM512_CMPLE_EPI8_MASK": return Intrinsic._MM512_CMPLE_EPI8_MASK;
                case "_MM512_CMPLE_EPU16_MASK": return Intrinsic._MM512_CMPLE_EPU16_MASK;
                case "_MM512_CMPLE_EPU32_MASK": return Intrinsic._MM512_CMPLE_EPU32_MASK;
                case "_MM512_CMPLE_EPU64_MASK": return Intrinsic._MM512_CMPLE_EPU64_MASK;
                case "_MM512_CMPLE_EPU8_MASK": return Intrinsic._MM512_CMPLE_EPU8_MASK;
                case "_MM512_CMPLE_PD_MASK": return Intrinsic._MM512_CMPLE_PD_MASK;
                case "_MM512_CMPLE_PS_MASK": return Intrinsic._MM512_CMPLE_PS_MASK;
                case "_MM512_CMPLT_EPI16_MASK": return Intrinsic._MM512_CMPLT_EPI16_MASK;
                case "_MM512_CMPLT_EPI32_MASK": return Intrinsic._MM512_CMPLT_EPI32_MASK;
                case "_MM512_CMPLT_EPI64_MASK": return Intrinsic._MM512_CMPLT_EPI64_MASK;
                case "_MM512_CMPLT_EPI8_MASK": return Intrinsic._MM512_CMPLT_EPI8_MASK;
                case "_MM512_CMPLT_EPU16_MASK": return Intrinsic._MM512_CMPLT_EPU16_MASK;
                case "_MM512_CMPLT_EPU32_MASK": return Intrinsic._MM512_CMPLT_EPU32_MASK;
                case "_MM512_CMPLT_EPU64_MASK": return Intrinsic._MM512_CMPLT_EPU64_MASK;
                case "_MM512_CMPLT_EPU8_MASK": return Intrinsic._MM512_CMPLT_EPU8_MASK;
                case "_MM512_CMPLT_PD_MASK": return Intrinsic._MM512_CMPLT_PD_MASK;
                case "_MM512_CMPLT_PS_MASK": return Intrinsic._MM512_CMPLT_PS_MASK;
                case "_MM512_CMPNEQ_EPI16_MASK": return Intrinsic._MM512_CMPNEQ_EPI16_MASK;
                case "_MM512_CMPNEQ_EPI32_MASK": return Intrinsic._MM512_CMPNEQ_EPI32_MASK;
                case "_MM512_CMPNEQ_EPI64_MASK": return Intrinsic._MM512_CMPNEQ_EPI64_MASK;
                case "_MM512_CMPNEQ_EPI8_MASK": return Intrinsic._MM512_CMPNEQ_EPI8_MASK;
                case "_MM512_CMPNEQ_EPU16_MASK": return Intrinsic._MM512_CMPNEQ_EPU16_MASK;
                case "_MM512_CMPNEQ_EPU32_MASK": return Intrinsic._MM512_CMPNEQ_EPU32_MASK;
                case "_MM512_CMPNEQ_EPU64_MASK": return Intrinsic._MM512_CMPNEQ_EPU64_MASK;
                case "_MM512_CMPNEQ_EPU8_MASK": return Intrinsic._MM512_CMPNEQ_EPU8_MASK;
                case "_MM512_CMPNEQ_PD_MASK": return Intrinsic._MM512_CMPNEQ_PD_MASK;
                case "_MM512_CMPNEQ_PS_MASK": return Intrinsic._MM512_CMPNEQ_PS_MASK;
                case "_MM512_CMPNLE_PD_MASK": return Intrinsic._MM512_CMPNLE_PD_MASK;
                case "_MM512_CMPNLE_PS_MASK": return Intrinsic._MM512_CMPNLE_PS_MASK;
                case "_MM512_CMPNLT_PD_MASK": return Intrinsic._MM512_CMPNLT_PD_MASK;
                case "_MM512_CMPNLT_PS_MASK": return Intrinsic._MM512_CMPNLT_PS_MASK;
                case "_MM512_CMPORD_PD_MASK": return Intrinsic._MM512_CMPORD_PD_MASK;
                case "_MM512_CMPORD_PS_MASK": return Intrinsic._MM512_CMPORD_PS_MASK;
                case "_MM512_CMPUNORD_PD_MASK": return Intrinsic._MM512_CMPUNORD_PD_MASK;
                case "_MM512_CMPUNORD_PS_MASK": return Intrinsic._MM512_CMPUNORD_PS_MASK;
                case "_MM512_CONFLICT_EPI32": return Intrinsic._MM512_CONFLICT_EPI32;
                case "_MM512_CONFLICT_EPI64": return Intrinsic._MM512_CONFLICT_EPI64;
                case "_MM512_COS_PD": return Intrinsic._MM512_COS_PD;
                case "_MM512_COS_PS": return Intrinsic._MM512_COS_PS;
                case "_MM512_COSD_PD": return Intrinsic._MM512_COSD_PD;
                case "_MM512_COSD_PS": return Intrinsic._MM512_COSD_PS;
                case "_MM512_COSH_PD": return Intrinsic._MM512_COSH_PD;
                case "_MM512_COSH_PS": return Intrinsic._MM512_COSH_PS;
                case "_MM512_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_CVT_ROUNDEPI32_PS;
                case "_MM512_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_CVT_ROUNDEPI64_PD;
                case "_MM512_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_CVT_ROUNDEPI64_PS;
                case "_MM512_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_CVT_ROUNDEPU32_PS;
                case "_MM512_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_CVT_ROUNDEPU64_PD;
                case "_MM512_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_CVT_ROUNDEPU64_PS;
                case "_MM512_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_CVT_ROUNDPD_EPI32;
                case "_MM512_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_CVT_ROUNDPD_EPI64;
                case "_MM512_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_CVT_ROUNDPD_EPU32;
                case "_MM512_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_CVT_ROUNDPD_EPU64;
                case "_MM512_CVT_ROUNDPD_PS": return Intrinsic._MM512_CVT_ROUNDPD_PS;
                case "_MM512_CVT_ROUNDPD_PSLO": return Intrinsic._MM512_CVT_ROUNDPD_PSLO;
                case "_MM512_CVT_ROUNDPH_PS": return Intrinsic._MM512_CVT_ROUNDPH_PS;
                case "_MM512_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_CVT_ROUNDPS_EPI32;
                case "_MM512_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_CVT_ROUNDPS_EPI64;
                case "_MM512_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_CVT_ROUNDPS_EPU32;
                case "_MM512_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_CVT_ROUNDPS_EPU64;
                case "_MM512_CVT_ROUNDPS_PD": return Intrinsic._MM512_CVT_ROUNDPS_PD;
                case "_MM512_CVT_ROUNDPS_PH": return Intrinsic._MM512_CVT_ROUNDPS_PH;
                case "_MM512_CVTEPI16_EPI32": return Intrinsic._MM512_CVTEPI16_EPI32;
                case "_MM512_CVTEPI16_EPI64": return Intrinsic._MM512_CVTEPI16_EPI64;
                case "_MM512_CVTEPI16_EPI8": return Intrinsic._MM512_CVTEPI16_EPI8;
                case "_MM512_CVTEPI32_EPI16": return Intrinsic._MM512_CVTEPI32_EPI16;
                case "_MM512_CVTEPI32_EPI64": return Intrinsic._MM512_CVTEPI32_EPI64;
                case "_MM512_CVTEPI32_EPI8": return Intrinsic._MM512_CVTEPI32_EPI8;
                case "_MM512_CVTEPI32_PD": return Intrinsic._MM512_CVTEPI32_PD;
                case "_MM512_CVTEPI32_PS": return Intrinsic._MM512_CVTEPI32_PS;
                case "_MM512_CVTEPI32LO_PD": return Intrinsic._MM512_CVTEPI32LO_PD;
                case "_MM512_CVTEPI64_EPI16": return Intrinsic._MM512_CVTEPI64_EPI16;
                case "_MM512_CVTEPI64_EPI32": return Intrinsic._MM512_CVTEPI64_EPI32;
                case "_MM512_CVTEPI64_EPI8": return Intrinsic._MM512_CVTEPI64_EPI8;
                case "_MM512_CVTEPI64_PD": return Intrinsic._MM512_CVTEPI64_PD;
                case "_MM512_CVTEPI64_PS": return Intrinsic._MM512_CVTEPI64_PS;
                case "_MM512_CVTEPI8_EPI16": return Intrinsic._MM512_CVTEPI8_EPI16;
                case "_MM512_CVTEPI8_EPI32": return Intrinsic._MM512_CVTEPI8_EPI32;
                case "_MM512_CVTEPI8_EPI64": return Intrinsic._MM512_CVTEPI8_EPI64;
                case "_MM512_CVTEPU16_EPI32": return Intrinsic._MM512_CVTEPU16_EPI32;
                case "_MM512_CVTEPU16_EPI64": return Intrinsic._MM512_CVTEPU16_EPI64;
                case "_MM512_CVTEPU32_EPI64": return Intrinsic._MM512_CVTEPU32_EPI64;
                case "_MM512_CVTEPU32_PD": return Intrinsic._MM512_CVTEPU32_PD;
                case "_MM512_CVTEPU32_PS": return Intrinsic._MM512_CVTEPU32_PS;
                case "_MM512_CVTEPU32LO_PD": return Intrinsic._MM512_CVTEPU32LO_PD;
                case "_MM512_CVTEPU64_PD": return Intrinsic._MM512_CVTEPU64_PD;
                case "_MM512_CVTEPU64_PS": return Intrinsic._MM512_CVTEPU64_PS;
                case "_MM512_CVTEPU8_EPI16": return Intrinsic._MM512_CVTEPU8_EPI16;
                case "_MM512_CVTEPU8_EPI32": return Intrinsic._MM512_CVTEPU8_EPI32;
                case "_MM512_CVTEPU8_EPI64": return Intrinsic._MM512_CVTEPU8_EPI64;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTEPI32_PS": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTEPI32_PS;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTEPU32_PS": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTEPU32_PS;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTPS_EPI32": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTPS_EPI32;
                case "_MM512_CVTFXPNT_ROUND_ADJUSTPS_EPU32": return Intrinsic._MM512_CVTFXPNT_ROUND_ADJUSTPS_EPU32;
                case "_MM512_CVTFXPNT_ROUNDPD_EPI32LO": return Intrinsic._MM512_CVTFXPNT_ROUNDPD_EPI32LO;
                case "_MM512_CVTFXPNT_ROUNDPD_EPU32LO": return Intrinsic._MM512_CVTFXPNT_ROUNDPD_EPU32LO;
                case "_MM512_CVTPD_EPI32": return Intrinsic._MM512_CVTPD_EPI32;
                case "_MM512_CVTPD_EPI64": return Intrinsic._MM512_CVTPD_EPI64;
                case "_MM512_CVTPD_EPU32": return Intrinsic._MM512_CVTPD_EPU32;
                case "_MM512_CVTPD_EPU64": return Intrinsic._MM512_CVTPD_EPU64;
                case "_MM512_CVTPD_PS": return Intrinsic._MM512_CVTPD_PS;
                case "_MM512_CVTPD_PSLO": return Intrinsic._MM512_CVTPD_PSLO;
                case "_MM512_CVTPH_PS": return Intrinsic._MM512_CVTPH_PS;
                case "_MM512_CVTPS_EPI32": return Intrinsic._MM512_CVTPS_EPI32;
                case "_MM512_CVTPS_EPI64": return Intrinsic._MM512_CVTPS_EPI64;
                case "_MM512_CVTPS_EPU32": return Intrinsic._MM512_CVTPS_EPU32;
                case "_MM512_CVTPS_EPU64": return Intrinsic._MM512_CVTPS_EPU64;
                case "_MM512_CVTPS_PD": return Intrinsic._MM512_CVTPS_PD;
                case "_MM512_CVTPS_PH": return Intrinsic._MM512_CVTPS_PH;
                case "_MM512_CVTPSLO_PD": return Intrinsic._MM512_CVTPSLO_PD;
                case "_MM512_CVTSEPI16_EPI8": return Intrinsic._MM512_CVTSEPI16_EPI8;
                case "_MM512_CVTSEPI32_EPI16": return Intrinsic._MM512_CVTSEPI32_EPI16;
                case "_MM512_CVTSEPI32_EPI8": return Intrinsic._MM512_CVTSEPI32_EPI8;
                case "_MM512_CVTSEPI64_EPI16": return Intrinsic._MM512_CVTSEPI64_EPI16;
                case "_MM512_CVTSEPI64_EPI32": return Intrinsic._MM512_CVTSEPI64_EPI32;
                case "_MM512_CVTSEPI64_EPI8": return Intrinsic._MM512_CVTSEPI64_EPI8;
                case "_MM512_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_CVTT_ROUNDPD_EPI32;
                case "_MM512_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_CVTT_ROUNDPD_EPI64;
                case "_MM512_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_CVTT_ROUNDPD_EPU32;
                case "_MM512_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_CVTT_ROUNDPD_EPU64;
                case "_MM512_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_CVTT_ROUNDPS_EPI32;
                case "_MM512_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_CVTT_ROUNDPS_EPI64;
                case "_MM512_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_CVTT_ROUNDPS_EPU32;
                case "_MM512_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_CVTT_ROUNDPS_EPU64;
                case "_MM512_CVTTPD_EPI32": return Intrinsic._MM512_CVTTPD_EPI32;
                case "_MM512_CVTTPD_EPI64": return Intrinsic._MM512_CVTTPD_EPI64;
                case "_MM512_CVTTPD_EPU32": return Intrinsic._MM512_CVTTPD_EPU32;
                case "_MM512_CVTTPD_EPU64": return Intrinsic._MM512_CVTTPD_EPU64;
                case "_MM512_CVTTPS_EPI32": return Intrinsic._MM512_CVTTPS_EPI32;
                case "_MM512_CVTTPS_EPI64": return Intrinsic._MM512_CVTTPS_EPI64;
                case "_MM512_CVTTPS_EPU32": return Intrinsic._MM512_CVTTPS_EPU32;
                case "_MM512_CVTTPS_EPU64": return Intrinsic._MM512_CVTTPS_EPU64;
                case "_MM512_CVTUSEPI16_EPI8": return Intrinsic._MM512_CVTUSEPI16_EPI8;
                case "_MM512_CVTUSEPI32_EPI16": return Intrinsic._MM512_CVTUSEPI32_EPI16;
                case "_MM512_CVTUSEPI32_EPI8": return Intrinsic._MM512_CVTUSEPI32_EPI8;
                case "_MM512_CVTUSEPI64_EPI16": return Intrinsic._MM512_CVTUSEPI64_EPI16;
                case "_MM512_CVTUSEPI64_EPI32": return Intrinsic._MM512_CVTUSEPI64_EPI32;
                case "_MM512_CVTUSEPI64_EPI8": return Intrinsic._MM512_CVTUSEPI64_EPI8;
                case "_MM512_DBSAD_EPU8": return Intrinsic._MM512_DBSAD_EPU8;
                case "_MM512_DIV_EPI16": return Intrinsic._MM512_DIV_EPI16;
                case "_MM512_DIV_EPI32": return Intrinsic._MM512_DIV_EPI32;
                case "_MM512_DIV_EPI64": return Intrinsic._MM512_DIV_EPI64;
                case "_MM512_DIV_EPI8": return Intrinsic._MM512_DIV_EPI8;
                case "_MM512_DIV_EPU16": return Intrinsic._MM512_DIV_EPU16;
                case "_MM512_DIV_EPU32": return Intrinsic._MM512_DIV_EPU32;
                case "_MM512_DIV_EPU64": return Intrinsic._MM512_DIV_EPU64;
                case "_MM512_DIV_EPU8": return Intrinsic._MM512_DIV_EPU8;
                case "_MM512_DIV_PD": return Intrinsic._MM512_DIV_PD;
                case "_MM512_DIV_PS": return Intrinsic._MM512_DIV_PS;
                case "_MM512_DIV_ROUND_PD": return Intrinsic._MM512_DIV_ROUND_PD;
                case "_MM512_DIV_ROUND_PS": return Intrinsic._MM512_DIV_ROUND_PS;
                case "_MM512_ERF_PD": return Intrinsic._MM512_ERF_PD;
                case "_MM512_ERF_PS": return Intrinsic._MM512_ERF_PS;
                case "_MM512_ERFC_PD": return Intrinsic._MM512_ERFC_PD;
                case "_MM512_ERFC_PS": return Intrinsic._MM512_ERFC_PS;
                case "_MM512_ERFCINV_PD": return Intrinsic._MM512_ERFCINV_PD;
                case "_MM512_ERFCINV_PS": return Intrinsic._MM512_ERFCINV_PS;
                case "_MM512_ERFINV_PD": return Intrinsic._MM512_ERFINV_PD;
                case "_MM512_ERFINV_PS": return Intrinsic._MM512_ERFINV_PS;
                case "_MM512_EXP_PD": return Intrinsic._MM512_EXP_PD;
                case "_MM512_EXP_PS": return Intrinsic._MM512_EXP_PS;
                case "_MM512_EXP10_PD": return Intrinsic._MM512_EXP10_PD;
                case "_MM512_EXP10_PS": return Intrinsic._MM512_EXP10_PS;
                case "_MM512_EXP2_PD": return Intrinsic._MM512_EXP2_PD;
                case "_MM512_EXP2_PS": return Intrinsic._MM512_EXP2_PS;
                case "_MM512_EXP223_PS": return Intrinsic._MM512_EXP223_PS;
                case "_MM512_EXP2A23_PD": return Intrinsic._MM512_EXP2A23_PD;
                case "_MM512_EXP2A23_PS": return Intrinsic._MM512_EXP2A23_PS;
                case "_MM512_EXP2A23_ROUND_PD": return Intrinsic._MM512_EXP2A23_ROUND_PD;
                case "_MM512_EXP2A23_ROUND_PS": return Intrinsic._MM512_EXP2A23_ROUND_PS;
                case "_MM512_EXPM1_PD": return Intrinsic._MM512_EXPM1_PD;
                case "_MM512_EXPM1_PS": return Intrinsic._MM512_EXPM1_PS;
                case "_MM512_EXTLOAD_EPI32": return Intrinsic._MM512_EXTLOAD_EPI32;
                case "_MM512_EXTLOAD_EPI64": return Intrinsic._MM512_EXTLOAD_EPI64;
                case "_MM512_EXTLOAD_PD": return Intrinsic._MM512_EXTLOAD_PD;
                case "_MM512_EXTLOAD_PS": return Intrinsic._MM512_EXTLOAD_PS;
                case "_MM512_EXTLOADUNPACKHI_EPI32": return Intrinsic._MM512_EXTLOADUNPACKHI_EPI32;
                case "_MM512_EXTLOADUNPACKHI_EPI64": return Intrinsic._MM512_EXTLOADUNPACKHI_EPI64;
                case "_MM512_EXTLOADUNPACKHI_PD": return Intrinsic._MM512_EXTLOADUNPACKHI_PD;
                case "_MM512_EXTLOADUNPACKHI_PS": return Intrinsic._MM512_EXTLOADUNPACKHI_PS;
                case "_MM512_EXTLOADUNPACKLO_EPI32": return Intrinsic._MM512_EXTLOADUNPACKLO_EPI32;
                case "_MM512_EXTLOADUNPACKLO_EPI64": return Intrinsic._MM512_EXTLOADUNPACKLO_EPI64;
                case "_MM512_EXTLOADUNPACKLO_PD": return Intrinsic._MM512_EXTLOADUNPACKLO_PD;
                case "_MM512_EXTLOADUNPACKLO_PS": return Intrinsic._MM512_EXTLOADUNPACKLO_PS;
                case "_MM512_EXTPACKSTOREHI_EPI32": return Intrinsic._MM512_EXTPACKSTOREHI_EPI32;
                case "_MM512_EXTPACKSTOREHI_EPI64": return Intrinsic._MM512_EXTPACKSTOREHI_EPI64;
                case "_MM512_EXTPACKSTOREHI_PD": return Intrinsic._MM512_EXTPACKSTOREHI_PD;
                case "_MM512_EXTPACKSTOREHI_PS": return Intrinsic._MM512_EXTPACKSTOREHI_PS;
                case "_MM512_EXTPACKSTORELO_EPI32": return Intrinsic._MM512_EXTPACKSTORELO_EPI32;
                case "_MM512_EXTPACKSTORELO_EPI64": return Intrinsic._MM512_EXTPACKSTORELO_EPI64;
                case "_MM512_EXTPACKSTORELO_PD": return Intrinsic._MM512_EXTPACKSTORELO_PD;
                case "_MM512_EXTPACKSTORELO_PS": return Intrinsic._MM512_EXTPACKSTORELO_PS;
                case "_MM512_EXTRACTF32X4_PS": return Intrinsic._MM512_EXTRACTF32X4_PS;
                case "_MM512_EXTRACTF32X8_PS": return Intrinsic._MM512_EXTRACTF32X8_PS;
                case "_MM512_EXTRACTF64X2_PD": return Intrinsic._MM512_EXTRACTF64X2_PD;
                case "_MM512_EXTRACTF64X4_PD": return Intrinsic._MM512_EXTRACTF64X4_PD;
                case "_MM512_EXTRACTI32X4_EPI32": return Intrinsic._MM512_EXTRACTI32X4_EPI32;
                case "_MM512_EXTRACTI32X8_EPI32": return Intrinsic._MM512_EXTRACTI32X8_EPI32;
                case "_MM512_EXTRACTI64X2_EPI64": return Intrinsic._MM512_EXTRACTI64X2_EPI64;
                case "_MM512_EXTRACTI64X4_EPI64": return Intrinsic._MM512_EXTRACTI64X4_EPI64;
                case "_MM512_EXTSTORE_EPI32": return Intrinsic._MM512_EXTSTORE_EPI32;
                case "_MM512_EXTSTORE_EPI64": return Intrinsic._MM512_EXTSTORE_EPI64;
                case "_MM512_EXTSTORE_PD": return Intrinsic._MM512_EXTSTORE_PD;
                case "_MM512_EXTSTORE_PS": return Intrinsic._MM512_EXTSTORE_PS;
                case "_MM512_FIXUPIMM_PD": return Intrinsic._MM512_FIXUPIMM_PD;
                case "_MM512_FIXUPIMM_PS": return Intrinsic._MM512_FIXUPIMM_PS;
                case "_MM512_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_FIXUPIMM_ROUND_PD;
                case "_MM512_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_FIXUPIMM_ROUND_PS;
                case "_MM512_FIXUPNAN_PD": return Intrinsic._MM512_FIXUPNAN_PD;
                case "_MM512_FIXUPNAN_PS": return Intrinsic._MM512_FIXUPNAN_PS;
                case "_MM512_FLOOR_PD": return Intrinsic._MM512_FLOOR_PD;
                case "_MM512_FLOOR_PS": return Intrinsic._MM512_FLOOR_PS;
                case "_MM512_FMADD_EPI32": return Intrinsic._MM512_FMADD_EPI32;
                case "_MM512_FMADD_PD": return Intrinsic._MM512_FMADD_PD;
                case "_MM512_FMADD_PS": return Intrinsic._MM512_FMADD_PS;
                case "_MM512_FMADD_ROUND_PD": return Intrinsic._MM512_FMADD_ROUND_PD;
                case "_MM512_FMADD_ROUND_PS": return Intrinsic._MM512_FMADD_ROUND_PS;
                case "_MM512_FMADD233_EPI32": return Intrinsic._MM512_FMADD233_EPI32;
                case "_MM512_FMADD233_PS": return Intrinsic._MM512_FMADD233_PS;
                case "_MM512_FMADD233_ROUND_PS": return Intrinsic._MM512_FMADD233_ROUND_PS;
                case "_MM512_FMADDSUB_PD": return Intrinsic._MM512_FMADDSUB_PD;
                case "_MM512_FMADDSUB_PS": return Intrinsic._MM512_FMADDSUB_PS;
                case "_MM512_FMADDSUB_ROUND_PD": return Intrinsic._MM512_FMADDSUB_ROUND_PD;
                case "_MM512_FMADDSUB_ROUND_PS": return Intrinsic._MM512_FMADDSUB_ROUND_PS;
                case "_MM512_FMSUB_PD": return Intrinsic._MM512_FMSUB_PD;
                case "_MM512_FMSUB_PS": return Intrinsic._MM512_FMSUB_PS;
                case "_MM512_FMSUB_ROUND_PD": return Intrinsic._MM512_FMSUB_ROUND_PD;
                case "_MM512_FMSUB_ROUND_PS": return Intrinsic._MM512_FMSUB_ROUND_PS;
                case "_MM512_FMSUBADD_PD": return Intrinsic._MM512_FMSUBADD_PD;
                case "_MM512_FMSUBADD_PS": return Intrinsic._MM512_FMSUBADD_PS;
                case "_MM512_FMSUBADD_ROUND_PD": return Intrinsic._MM512_FMSUBADD_ROUND_PD;
                case "_MM512_FMSUBADD_ROUND_PS": return Intrinsic._MM512_FMSUBADD_ROUND_PS;
                case "_MM512_FNMADD_PD": return Intrinsic._MM512_FNMADD_PD;
                case "_MM512_FNMADD_PS": return Intrinsic._MM512_FNMADD_PS;
                case "_MM512_FNMADD_ROUND_PD": return Intrinsic._MM512_FNMADD_ROUND_PD;
                case "_MM512_FNMADD_ROUND_PS": return Intrinsic._MM512_FNMADD_ROUND_PS;
                case "_MM512_FNMSUB_PD": return Intrinsic._MM512_FNMSUB_PD;
                case "_MM512_FNMSUB_PS": return Intrinsic._MM512_FNMSUB_PS;
                case "_MM512_FNMSUB_ROUND_PD": return Intrinsic._MM512_FNMSUB_ROUND_PD;
                case "_MM512_FNMSUB_ROUND_PS": return Intrinsic._MM512_FNMSUB_ROUND_PS;
                case "_MM512_FPCLASS_PD_MASK": return Intrinsic._MM512_FPCLASS_PD_MASK;
                case "_MM512_FPCLASS_PS_MASK": return Intrinsic._MM512_FPCLASS_PS_MASK;
                case "_MM512_GETEXP_PD": return Intrinsic._MM512_GETEXP_PD;
                case "_MM512_GETEXP_PS": return Intrinsic._MM512_GETEXP_PS;
                case "_MM512_GETEXP_ROUND_PD": return Intrinsic._MM512_GETEXP_ROUND_PD;
                case "_MM512_GETEXP_ROUND_PS": return Intrinsic._MM512_GETEXP_ROUND_PS;
                case "_MM512_GETMANT_PD": return Intrinsic._MM512_GETMANT_PD;
                case "_MM512_GETMANT_PS": return Intrinsic._MM512_GETMANT_PS;
                case "_MM512_GETMANT_ROUND_PD": return Intrinsic._MM512_GETMANT_ROUND_PD;
                case "_MM512_GETMANT_ROUND_PS": return Intrinsic._MM512_GETMANT_ROUND_PS;
                case "_MM512_GMAX_PD": return Intrinsic._MM512_GMAX_PD;
                case "_MM512_GMAX_PS": return Intrinsic._MM512_GMAX_PS;
                case "_MM512_GMAXABS_PS": return Intrinsic._MM512_GMAXABS_PS;
                case "_MM512_GMIN_PD": return Intrinsic._MM512_GMIN_PD;
                case "_MM512_GMIN_PS": return Intrinsic._MM512_GMIN_PS;
                case "_MM512_HYPOT_PD": return Intrinsic._MM512_HYPOT_PD;
                case "_MM512_HYPOT_PS": return Intrinsic._MM512_HYPOT_PS;
                case "_MM512_I32EXTGATHER_EPI32": return Intrinsic._MM512_I32EXTGATHER_EPI32;
                case "_MM512_I32EXTGATHER_PS": return Intrinsic._MM512_I32EXTGATHER_PS;
                case "_MM512_I32EXTSCATTER_EPI32": return Intrinsic._MM512_I32EXTSCATTER_EPI32;
                case "_MM512_I32EXTSCATTER_PS": return Intrinsic._MM512_I32EXTSCATTER_PS;
                case "_MM512_I32GATHER_EPI32": return Intrinsic._MM512_I32GATHER_EPI32;
                case "_MM512_I32GATHER_EPI64": return Intrinsic._MM512_I32GATHER_EPI64;
                case "_MM512_I32GATHER_PD": return Intrinsic._MM512_I32GATHER_PD;
                case "_MM512_I32GATHER_PS": return Intrinsic._MM512_I32GATHER_PS;
                case "_MM512_I32LOEXTGATHER_EPI64": return Intrinsic._MM512_I32LOEXTGATHER_EPI64;
                case "_MM512_I32LOEXTGATHER_PD": return Intrinsic._MM512_I32LOEXTGATHER_PD;
                case "_MM512_I32LOEXTSCATTER_EPI64": return Intrinsic._MM512_I32LOEXTSCATTER_EPI64;
                case "_MM512_I32LOEXTSCATTER_PD": return Intrinsic._MM512_I32LOEXTSCATTER_PD;
                case "_MM512_I32LOGATHER_EPI64": return Intrinsic._MM512_I32LOGATHER_EPI64;
                case "_MM512_I32LOGATHER_PD": return Intrinsic._MM512_I32LOGATHER_PD;
                case "_MM512_I32LOSCATTER_EPI64": return Intrinsic._MM512_I32LOSCATTER_EPI64;
                case "_MM512_I32LOSCATTER_PD": return Intrinsic._MM512_I32LOSCATTER_PD;
                case "_MM512_I32SCATTER_EPI32": return Intrinsic._MM512_I32SCATTER_EPI32;
                case "_MM512_I32SCATTER_EPI64": return Intrinsic._MM512_I32SCATTER_EPI64;
                case "_MM512_I32SCATTER_PD": return Intrinsic._MM512_I32SCATTER_PD;
                case "_MM512_I32SCATTER_PS": return Intrinsic._MM512_I32SCATTER_PS;
                case "_MM512_I64EXTGATHER_EPI32LO": return Intrinsic._MM512_I64EXTGATHER_EPI32LO;
                case "_MM512_I64EXTGATHER_EPI64": return Intrinsic._MM512_I64EXTGATHER_EPI64;
                case "_MM512_I64EXTGATHER_PD": return Intrinsic._MM512_I64EXTGATHER_PD;
                case "_MM512_I64EXTGATHER_PSLO": return Intrinsic._MM512_I64EXTGATHER_PSLO;
                case "_MM512_I64EXTSCATTER_EPI32LO": return Intrinsic._MM512_I64EXTSCATTER_EPI32LO;
                case "_MM512_I64EXTSCATTER_EPI64": return Intrinsic._MM512_I64EXTSCATTER_EPI64;
                case "_MM512_I64EXTSCATTER_PD": return Intrinsic._MM512_I64EXTSCATTER_PD;
                case "_MM512_I64EXTSCATTER_PSLO": return Intrinsic._MM512_I64EXTSCATTER_PSLO;
                case "_MM512_I64GATHER_EPI32": return Intrinsic._MM512_I64GATHER_EPI32;
                case "_MM512_I64GATHER_EPI32LO": return Intrinsic._MM512_I64GATHER_EPI32LO;
                case "_MM512_I64GATHER_EPI64": return Intrinsic._MM512_I64GATHER_EPI64;
                case "_MM512_I64GATHER_PD": return Intrinsic._MM512_I64GATHER_PD;
                case "_MM512_I64GATHER_PS": return Intrinsic._MM512_I64GATHER_PS;
                case "_MM512_I64GATHER_PSLO": return Intrinsic._MM512_I64GATHER_PSLO;
                case "_MM512_I64SCATTER_EPI32": return Intrinsic._MM512_I64SCATTER_EPI32;
                case "_MM512_I64SCATTER_EPI32LO": return Intrinsic._MM512_I64SCATTER_EPI32LO;
                case "_MM512_I64SCATTER_EPI64": return Intrinsic._MM512_I64SCATTER_EPI64;
                case "_MM512_I64SCATTER_PD": return Intrinsic._MM512_I64SCATTER_PD;
                case "_MM512_I64SCATTER_PS": return Intrinsic._MM512_I64SCATTER_PS;
                case "_MM512_I64SCATTER_PSLO": return Intrinsic._MM512_I64SCATTER_PSLO;
                case "_MM512_INSERTF32X4": return Intrinsic._MM512_INSERTF32X4;
                case "_MM512_INSERTF32X8": return Intrinsic._MM512_INSERTF32X8;
                case "_MM512_INSERTF64X2": return Intrinsic._MM512_INSERTF64X2;
                case "_MM512_INSERTF64X4": return Intrinsic._MM512_INSERTF64X4;
                case "_MM512_INSERTI32X4": return Intrinsic._MM512_INSERTI32X4;
                case "_MM512_INSERTI32X8": return Intrinsic._MM512_INSERTI32X8;
                case "_MM512_INSERTI64X2": return Intrinsic._MM512_INSERTI64X2;
                case "_MM512_INSERTI64X4": return Intrinsic._MM512_INSERTI64X4;
                case "_MM512_INT2MASK": return Intrinsic._MM512_INT2MASK;
                case "_MM512_INVSQRT_PD": return Intrinsic._MM512_INVSQRT_PD;
                case "_MM512_INVSQRT_PS": return Intrinsic._MM512_INVSQRT_PS;
                case "_MM512_KAND": return Intrinsic._MM512_KAND;
                case "_MM512_KANDN": return Intrinsic._MM512_KANDN;
                case "_MM512_KANDNR": return Intrinsic._MM512_KANDNR;
                case "_MM512_KCONCATHI_64": return Intrinsic._MM512_KCONCATHI_64;
                case "_MM512_KCONCATLO_64": return Intrinsic._MM512_KCONCATLO_64;
                case "_MM512_KEXTRACT_64": return Intrinsic._MM512_KEXTRACT_64;
                case "_MM512_KMERGE2L1H": return Intrinsic._MM512_KMERGE2L1H;
                case "_MM512_KMERGE2L1L": return Intrinsic._MM512_KMERGE2L1L;
                case "_MM512_KMOV": return Intrinsic._MM512_KMOV;
                case "_MM512_KMOVLHB": return Intrinsic._MM512_KMOVLHB;
                case "_MM512_KNOT": return Intrinsic._MM512_KNOT;
                case "_MM512_KOR": return Intrinsic._MM512_KOR;
                case "_MM512_KORTESTC": return Intrinsic._MM512_KORTESTC;
                case "_MM512_KORTESTZ": return Intrinsic._MM512_KORTESTZ;
                case "_MM512_KSWAPB": return Intrinsic._MM512_KSWAPB;
                case "_MM512_KUNPACKB": return Intrinsic._MM512_KUNPACKB;
                case "_MM512_KUNPACKD": return Intrinsic._MM512_KUNPACKD;
                case "_MM512_KUNPACKW": return Intrinsic._MM512_KUNPACKW;
                case "_MM512_KXNOR": return Intrinsic._MM512_KXNOR;
                case "_MM512_KXOR": return Intrinsic._MM512_KXOR;
                case "_MM512_LOAD_EPI32": return Intrinsic._MM512_LOAD_EPI32;
                case "_MM512_LOAD_EPI64": return Intrinsic._MM512_LOAD_EPI64;
                case "_MM512_LOAD_PD": return Intrinsic._MM512_LOAD_PD;
                case "_MM512_LOAD_PS": return Intrinsic._MM512_LOAD_PS;
                case "_MM512_LOAD_SI512": return Intrinsic._MM512_LOAD_SI512;
                case "_MM512_LOADU_PD": return Intrinsic._MM512_LOADU_PD;
                case "_MM512_LOADU_PS": return Intrinsic._MM512_LOADU_PS;
                case "_MM512_LOADU_SI512": return Intrinsic._MM512_LOADU_SI512;
                case "_MM512_LOADUNPACKHI_EPI32": return Intrinsic._MM512_LOADUNPACKHI_EPI32;
                case "_MM512_LOADUNPACKHI_EPI64": return Intrinsic._MM512_LOADUNPACKHI_EPI64;
                case "_MM512_LOADUNPACKHI_PD": return Intrinsic._MM512_LOADUNPACKHI_PD;
                case "_MM512_LOADUNPACKHI_PS": return Intrinsic._MM512_LOADUNPACKHI_PS;
                case "_MM512_LOADUNPACKLO_EPI32": return Intrinsic._MM512_LOADUNPACKLO_EPI32;
                case "_MM512_LOADUNPACKLO_EPI64": return Intrinsic._MM512_LOADUNPACKLO_EPI64;
                case "_MM512_LOADUNPACKLO_PD": return Intrinsic._MM512_LOADUNPACKLO_PD;
                case "_MM512_LOADUNPACKLO_PS": return Intrinsic._MM512_LOADUNPACKLO_PS;
                case "_MM512_LOG_PD": return Intrinsic._MM512_LOG_PD;
                case "_MM512_LOG_PS": return Intrinsic._MM512_LOG_PS;
                case "_MM512_LOG10_PD": return Intrinsic._MM512_LOG10_PD;
                case "_MM512_LOG10_PS": return Intrinsic._MM512_LOG10_PS;
                case "_MM512_LOG1P_PD": return Intrinsic._MM512_LOG1P_PD;
                case "_MM512_LOG1P_PS": return Intrinsic._MM512_LOG1P_PS;
                case "_MM512_LOG2_PD": return Intrinsic._MM512_LOG2_PD;
                case "_MM512_LOG2_PS": return Intrinsic._MM512_LOG2_PS;
                case "_MM512_LOG2AE23_PS": return Intrinsic._MM512_LOG2AE23_PS;
                case "_MM512_LOGB_PD": return Intrinsic._MM512_LOGB_PD;
                case "_MM512_LOGB_PS": return Intrinsic._MM512_LOGB_PS;
                case "_MM512_LZCNT_EPI32": return Intrinsic._MM512_LZCNT_EPI32;
                case "_MM512_LZCNT_EPI64": return Intrinsic._MM512_LZCNT_EPI64;
                case "_MM512_MADD_EPI16": return Intrinsic._MM512_MADD_EPI16;
                case "_MM512_MADD52HI_EPU64": return Intrinsic._MM512_MADD52HI_EPU64;
                case "_MM512_MADD52LO_EPU64": return Intrinsic._MM512_MADD52LO_EPU64;
                case "_MM512_MADDUBS_EPI16": return Intrinsic._MM512_MADDUBS_EPI16;
                case "_MM512_MASK_ABS_EPI16": return Intrinsic._MM512_MASK_ABS_EPI16;
                case "_MM512_MASK_ABS_EPI32": return Intrinsic._MM512_MASK_ABS_EPI32;
                case "_MM512_MASK_ABS_EPI64": return Intrinsic._MM512_MASK_ABS_EPI64;
                case "_MM512_MASK_ABS_EPI8": return Intrinsic._MM512_MASK_ABS_EPI8;
                case "_MM512_MASK_ABS_PD": return Intrinsic._MM512_MASK_ABS_PD;
                case "_MM512_MASK_ABS_PS": return Intrinsic._MM512_MASK_ABS_PS;
                case "_MM512_MASK_ACOS_PD": return Intrinsic._MM512_MASK_ACOS_PD;
                case "_MM512_MASK_ACOS_PS": return Intrinsic._MM512_MASK_ACOS_PS;
                case "_MM512_MASK_ACOSH_PD": return Intrinsic._MM512_MASK_ACOSH_PD;
                case "_MM512_MASK_ACOSH_PS": return Intrinsic._MM512_MASK_ACOSH_PS;
                case "_MM512_MASK_ADC_EPI32": return Intrinsic._MM512_MASK_ADC_EPI32;
                case "_MM512_MASK_ADD_EPI16": return Intrinsic._MM512_MASK_ADD_EPI16;
                case "_MM512_MASK_ADD_EPI32": return Intrinsic._MM512_MASK_ADD_EPI32;
                case "_MM512_MASK_ADD_EPI64": return Intrinsic._MM512_MASK_ADD_EPI64;
                case "_MM512_MASK_ADD_EPI8": return Intrinsic._MM512_MASK_ADD_EPI8;
                case "_MM512_MASK_ADD_PD": return Intrinsic._MM512_MASK_ADD_PD;
                case "_MM512_MASK_ADD_PS": return Intrinsic._MM512_MASK_ADD_PS;
                case "_MM512_MASK_ADD_ROUND_PD": return Intrinsic._MM512_MASK_ADD_ROUND_PD;
                case "_MM512_MASK_ADD_ROUND_PS": return Intrinsic._MM512_MASK_ADD_ROUND_PS;
                case "_MM512_MASK_ADDN_PD": return Intrinsic._MM512_MASK_ADDN_PD;
                case "_MM512_MASK_ADDN_PS": return Intrinsic._MM512_MASK_ADDN_PS;
                case "_MM512_MASK_ADDN_ROUND_PD": return Intrinsic._MM512_MASK_ADDN_ROUND_PD;
                case "_MM512_MASK_ADDN_ROUND_PS": return Intrinsic._MM512_MASK_ADDN_ROUND_PS;
                case "_MM512_MASK_ADDS_EPI16": return Intrinsic._MM512_MASK_ADDS_EPI16;
                case "_MM512_MASK_ADDS_EPI8": return Intrinsic._MM512_MASK_ADDS_EPI8;
                case "_MM512_MASK_ADDS_EPU16": return Intrinsic._MM512_MASK_ADDS_EPU16;
                case "_MM512_MASK_ADDS_EPU8": return Intrinsic._MM512_MASK_ADDS_EPU8;
                case "_MM512_MASK_ADDSETC_EPI32": return Intrinsic._MM512_MASK_ADDSETC_EPI32;
                case "_MM512_MASK_ADDSETS_EPI32": return Intrinsic._MM512_MASK_ADDSETS_EPI32;
                case "_MM512_MASK_ADDSETS_PS": return Intrinsic._MM512_MASK_ADDSETS_PS;
                case "_MM512_MASK_ADDSETS_ROUND_PS": return Intrinsic._MM512_MASK_ADDSETS_ROUND_PS;
                case "_MM512_MASK_ALIGNR_EPI32": return Intrinsic._MM512_MASK_ALIGNR_EPI32;
                case "_MM512_MASK_ALIGNR_EPI64": return Intrinsic._MM512_MASK_ALIGNR_EPI64;
                case "_MM512_MASK_ALIGNR_EPI8": return Intrinsic._MM512_MASK_ALIGNR_EPI8;
                case "_MM512_MASK_AND_EPI32": return Intrinsic._MM512_MASK_AND_EPI32;
                case "_MM512_MASK_AND_EPI64": return Intrinsic._MM512_MASK_AND_EPI64;
                case "_MM512_MASK_AND_PD": return Intrinsic._MM512_MASK_AND_PD;
                case "_MM512_MASK_AND_PS": return Intrinsic._MM512_MASK_AND_PS;
                case "_MM512_MASK_ANDNOT_EPI32": return Intrinsic._MM512_MASK_ANDNOT_EPI32;
                case "_MM512_MASK_ANDNOT_EPI64": return Intrinsic._MM512_MASK_ANDNOT_EPI64;
                case "_MM512_MASK_ANDNOT_PD": return Intrinsic._MM512_MASK_ANDNOT_PD;
                case "_MM512_MASK_ANDNOT_PS": return Intrinsic._MM512_MASK_ANDNOT_PS;
                case "_MM512_MASK_ASIN_PD": return Intrinsic._MM512_MASK_ASIN_PD;
                case "_MM512_MASK_ASIN_PS": return Intrinsic._MM512_MASK_ASIN_PS;
                case "_MM512_MASK_ASINH_PD": return Intrinsic._MM512_MASK_ASINH_PD;
                case "_MM512_MASK_ASINH_PS": return Intrinsic._MM512_MASK_ASINH_PS;
                case "_MM512_MASK_ATAN_PD": return Intrinsic._MM512_MASK_ATAN_PD;
                case "_MM512_MASK_ATAN_PS": return Intrinsic._MM512_MASK_ATAN_PS;
                case "_MM512_MASK_ATAN2_PD": return Intrinsic._MM512_MASK_ATAN2_PD;
                case "_MM512_MASK_ATAN2_PS": return Intrinsic._MM512_MASK_ATAN2_PS;
                case "_MM512_MASK_ATANH_PD": return Intrinsic._MM512_MASK_ATANH_PD;
                case "_MM512_MASK_ATANH_PS": return Intrinsic._MM512_MASK_ATANH_PS;
                case "_MM512_MASK_AVG_EPU16": return Intrinsic._MM512_MASK_AVG_EPU16;
                case "_MM512_MASK_AVG_EPU8": return Intrinsic._MM512_MASK_AVG_EPU8;
                case "_MM512_MASK_BLEND_EPI16": return Intrinsic._MM512_MASK_BLEND_EPI16;
                case "_MM512_MASK_BLEND_EPI32": return Intrinsic._MM512_MASK_BLEND_EPI32;
                case "_MM512_MASK_BLEND_EPI64": return Intrinsic._MM512_MASK_BLEND_EPI64;
                case "_MM512_MASK_BLEND_EPI8": return Intrinsic._MM512_MASK_BLEND_EPI8;
                case "_MM512_MASK_BLEND_PD": return Intrinsic._MM512_MASK_BLEND_PD;
                case "_MM512_MASK_BLEND_PS": return Intrinsic._MM512_MASK_BLEND_PS;
                case "_MM512_MASK_BROADCAST_F32X2": return Intrinsic._MM512_MASK_BROADCAST_F32X2;
                case "_MM512_MASK_BROADCAST_F32X4": return Intrinsic._MM512_MASK_BROADCAST_F32X4;
                case "_MM512_MASK_BROADCAST_F32X8": return Intrinsic._MM512_MASK_BROADCAST_F32X8;
                case "_MM512_MASK_BROADCAST_F64X2": return Intrinsic._MM512_MASK_BROADCAST_F64X2;
                case "_MM512_MASK_BROADCAST_F64X4": return Intrinsic._MM512_MASK_BROADCAST_F64X4;
                case "_MM512_MASK_BROADCAST_I32X2": return Intrinsic._MM512_MASK_BROADCAST_I32X2;
                case "_MM512_MASK_BROADCAST_I32X4": return Intrinsic._MM512_MASK_BROADCAST_I32X4;
                case "_MM512_MASK_BROADCAST_I32X8": return Intrinsic._MM512_MASK_BROADCAST_I32X8;
                case "_MM512_MASK_BROADCAST_I64X2": return Intrinsic._MM512_MASK_BROADCAST_I64X2;
                case "_MM512_MASK_BROADCAST_I64X4": return Intrinsic._MM512_MASK_BROADCAST_I64X4;
                case "_MM512_MASK_BROADCASTB_EPI8": return Intrinsic._MM512_MASK_BROADCASTB_EPI8;
                case "_MM512_MASK_BROADCASTD_EPI32": return Intrinsic._MM512_MASK_BROADCASTD_EPI32;
                case "_MM512_MASK_BROADCASTQ_EPI64": return Intrinsic._MM512_MASK_BROADCASTQ_EPI64;
                case "_MM512_MASK_BROADCASTSD_PD": return Intrinsic._MM512_MASK_BROADCASTSD_PD;
                case "_MM512_MASK_BROADCASTSS_PS": return Intrinsic._MM512_MASK_BROADCASTSS_PS;
                case "_MM512_MASK_BROADCASTW_EPI16": return Intrinsic._MM512_MASK_BROADCASTW_EPI16;
                case "_MM512_MASK_CBRT_PD": return Intrinsic._MM512_MASK_CBRT_PD;
                case "_MM512_MASK_CBRT_PS": return Intrinsic._MM512_MASK_CBRT_PS;
                case "_MM512_MASK_CDFNORM_PD": return Intrinsic._MM512_MASK_CDFNORM_PD;
                case "_MM512_MASK_CDFNORM_PS": return Intrinsic._MM512_MASK_CDFNORM_PS;
                case "_MM512_MASK_CDFNORMINV_PD": return Intrinsic._MM512_MASK_CDFNORMINV_PD;
                case "_MM512_MASK_CDFNORMINV_PS": return Intrinsic._MM512_MASK_CDFNORMINV_PS;
                case "_MM512_MASK_CEIL_PD": return Intrinsic._MM512_MASK_CEIL_PD;
                case "_MM512_MASK_CEIL_PS": return Intrinsic._MM512_MASK_CEIL_PS;
                case "_MM512_MASK_CMP_EPI16_MASK": return Intrinsic._MM512_MASK_CMP_EPI16_MASK;
                case "_MM512_MASK_CMP_EPI32_MASK": return Intrinsic._MM512_MASK_CMP_EPI32_MASK;
                case "_MM512_MASK_CMP_EPI64_MASK": return Intrinsic._MM512_MASK_CMP_EPI64_MASK;
                case "_MM512_MASK_CMP_EPI8_MASK": return Intrinsic._MM512_MASK_CMP_EPI8_MASK;
                case "_MM512_MASK_CMP_EPU16_MASK": return Intrinsic._MM512_MASK_CMP_EPU16_MASK;
                case "_MM512_MASK_CMP_EPU32_MASK": return Intrinsic._MM512_MASK_CMP_EPU32_MASK;
                case "_MM512_MASK_CMP_EPU64_MASK": return Intrinsic._MM512_MASK_CMP_EPU64_MASK;
                case "_MM512_MASK_CMP_EPU8_MASK": return Intrinsic._MM512_MASK_CMP_EPU8_MASK;
                case "_MM512_MASK_CMP_PD_MASK": return Intrinsic._MM512_MASK_CMP_PD_MASK;
                case "_MM512_MASK_CMP_PS_MASK": return Intrinsic._MM512_MASK_CMP_PS_MASK;
                case "_MM512_MASK_CMP_ROUND_PD_MASK": return Intrinsic._MM512_MASK_CMP_ROUND_PD_MASK;
                case "_MM512_MASK_CMP_ROUND_PS_MASK": return Intrinsic._MM512_MASK_CMP_ROUND_PS_MASK;
                case "_MM512_MASK_CMPEQ_EPI16_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI16_MASK;
                case "_MM512_MASK_CMPEQ_EPI32_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI32_MASK;
                case "_MM512_MASK_CMPEQ_EPI64_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI64_MASK;
                case "_MM512_MASK_CMPEQ_EPI8_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPI8_MASK;
                case "_MM512_MASK_CMPEQ_EPU16_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU16_MASK;
                case "_MM512_MASK_CMPEQ_EPU32_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU32_MASK;
                case "_MM512_MASK_CMPEQ_EPU64_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU64_MASK;
                case "_MM512_MASK_CMPEQ_EPU8_MASK": return Intrinsic._MM512_MASK_CMPEQ_EPU8_MASK;
                case "_MM512_MASK_CMPEQ_PD_MASK": return Intrinsic._MM512_MASK_CMPEQ_PD_MASK;
                case "_MM512_MASK_CMPEQ_PS_MASK": return Intrinsic._MM512_MASK_CMPEQ_PS_MASK;
                case "_MM512_MASK_CMPGE_EPI16_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI16_MASK;
                case "_MM512_MASK_CMPGE_EPI32_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI32_MASK;
                case "_MM512_MASK_CMPGE_EPI64_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI64_MASK;
                case "_MM512_MASK_CMPGE_EPI8_MASK": return Intrinsic._MM512_MASK_CMPGE_EPI8_MASK;
                case "_MM512_MASK_CMPGE_EPU16_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU16_MASK;
                case "_MM512_MASK_CMPGE_EPU32_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU32_MASK;
                case "_MM512_MASK_CMPGE_EPU64_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU64_MASK;
                case "_MM512_MASK_CMPGE_EPU8_MASK": return Intrinsic._MM512_MASK_CMPGE_EPU8_MASK;
                case "_MM512_MASK_CMPGT_EPI16_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI16_MASK;
                case "_MM512_MASK_CMPGT_EPI32_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI32_MASK;
                case "_MM512_MASK_CMPGT_EPI64_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI64_MASK;
                case "_MM512_MASK_CMPGT_EPI8_MASK": return Intrinsic._MM512_MASK_CMPGT_EPI8_MASK;
                case "_MM512_MASK_CMPGT_EPU16_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU16_MASK;
                case "_MM512_MASK_CMPGT_EPU32_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU32_MASK;
                case "_MM512_MASK_CMPGT_EPU64_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU64_MASK;
                case "_MM512_MASK_CMPGT_EPU8_MASK": return Intrinsic._MM512_MASK_CMPGT_EPU8_MASK;
                case "_MM512_MASK_CMPLE_EPI16_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI16_MASK;
                case "_MM512_MASK_CMPLE_EPI32_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI32_MASK;
                case "_MM512_MASK_CMPLE_EPI64_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI64_MASK;
                case "_MM512_MASK_CMPLE_EPI8_MASK": return Intrinsic._MM512_MASK_CMPLE_EPI8_MASK;
                case "_MM512_MASK_CMPLE_EPU16_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU16_MASK;
                case "_MM512_MASK_CMPLE_EPU32_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU32_MASK;
                case "_MM512_MASK_CMPLE_EPU64_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU64_MASK;
                case "_MM512_MASK_CMPLE_EPU8_MASK": return Intrinsic._MM512_MASK_CMPLE_EPU8_MASK;
                case "_MM512_MASK_CMPLE_PD_MASK": return Intrinsic._MM512_MASK_CMPLE_PD_MASK;
                case "_MM512_MASK_CMPLE_PS_MASK": return Intrinsic._MM512_MASK_CMPLE_PS_MASK;
                case "_MM512_MASK_CMPLT_EPI16_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI16_MASK;
                case "_MM512_MASK_CMPLT_EPI32_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI32_MASK;
                case "_MM512_MASK_CMPLT_EPI64_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI64_MASK;
                case "_MM512_MASK_CMPLT_EPI8_MASK": return Intrinsic._MM512_MASK_CMPLT_EPI8_MASK;
                case "_MM512_MASK_CMPLT_EPU16_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU16_MASK;
                case "_MM512_MASK_CMPLT_EPU32_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU32_MASK;
                case "_MM512_MASK_CMPLT_EPU64_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU64_MASK;
                case "_MM512_MASK_CMPLT_EPU8_MASK": return Intrinsic._MM512_MASK_CMPLT_EPU8_MASK;
                case "_MM512_MASK_CMPLT_PD_MASK": return Intrinsic._MM512_MASK_CMPLT_PD_MASK;
                case "_MM512_MASK_CMPLT_PS_MASK": return Intrinsic._MM512_MASK_CMPLT_PS_MASK;
                case "_MM512_MASK_CMPNEQ_EPI16_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI16_MASK;
                case "_MM512_MASK_CMPNEQ_EPI32_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI32_MASK;
                case "_MM512_MASK_CMPNEQ_EPI64_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI64_MASK;
                case "_MM512_MASK_CMPNEQ_EPI8_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPI8_MASK;
                case "_MM512_MASK_CMPNEQ_EPU16_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU16_MASK;
                case "_MM512_MASK_CMPNEQ_EPU32_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU32_MASK;
                case "_MM512_MASK_CMPNEQ_EPU64_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU64_MASK;
                case "_MM512_MASK_CMPNEQ_EPU8_MASK": return Intrinsic._MM512_MASK_CMPNEQ_EPU8_MASK;
                case "_MM512_MASK_CMPNEQ_PD_MASK": return Intrinsic._MM512_MASK_CMPNEQ_PD_MASK;
                case "_MM512_MASK_CMPNEQ_PS_MASK": return Intrinsic._MM512_MASK_CMPNEQ_PS_MASK;
                case "_MM512_MASK_CMPNLE_PD_MASK": return Intrinsic._MM512_MASK_CMPNLE_PD_MASK;
                case "_MM512_MASK_CMPNLE_PS_MASK": return Intrinsic._MM512_MASK_CMPNLE_PS_MASK;
                case "_MM512_MASK_CMPNLT_PD_MASK": return Intrinsic._MM512_MASK_CMPNLT_PD_MASK;
                case "_MM512_MASK_CMPNLT_PS_MASK": return Intrinsic._MM512_MASK_CMPNLT_PS_MASK;
                case "_MM512_MASK_CMPORD_PD_MASK": return Intrinsic._MM512_MASK_CMPORD_PD_MASK;
                case "_MM512_MASK_CMPORD_PS_MASK": return Intrinsic._MM512_MASK_CMPORD_PS_MASK;
                case "_MM512_MASK_CMPUNORD_PD_MASK": return Intrinsic._MM512_MASK_CMPUNORD_PD_MASK;
                case "_MM512_MASK_CMPUNORD_PS_MASK": return Intrinsic._MM512_MASK_CMPUNORD_PS_MASK;
                case "_MM512_MASK_COMPRESS_EPI32": return Intrinsic._MM512_MASK_COMPRESS_EPI32;
                case "_MM512_MASK_COMPRESS_EPI64": return Intrinsic._MM512_MASK_COMPRESS_EPI64;
                case "_MM512_MASK_COMPRESS_PD": return Intrinsic._MM512_MASK_COMPRESS_PD;
                case "_MM512_MASK_COMPRESS_PS": return Intrinsic._MM512_MASK_COMPRESS_PS;
                case "_MM512_MASK_COMPRESSSTOREU_EPI32": return Intrinsic._MM512_MASK_COMPRESSSTOREU_EPI32;
                case "_MM512_MASK_COMPRESSSTOREU_EPI64": return Intrinsic._MM512_MASK_COMPRESSSTOREU_EPI64;
                case "_MM512_MASK_COMPRESSSTOREU_PD": return Intrinsic._MM512_MASK_COMPRESSSTOREU_PD;
                case "_MM512_MASK_COMPRESSSTOREU_PS": return Intrinsic._MM512_MASK_COMPRESSSTOREU_PS;
                case "_MM512_MASK_CONFLICT_EPI32": return Intrinsic._MM512_MASK_CONFLICT_EPI32;
                case "_MM512_MASK_CONFLICT_EPI64": return Intrinsic._MM512_MASK_CONFLICT_EPI64;
                case "_MM512_MASK_COS_PD": return Intrinsic._MM512_MASK_COS_PD;
                case "_MM512_MASK_COS_PS": return Intrinsic._MM512_MASK_COS_PS;
                case "_MM512_MASK_COSD_PD": return Intrinsic._MM512_MASK_COSD_PD;
                case "_MM512_MASK_COSD_PS": return Intrinsic._MM512_MASK_COSD_PS;
                case "_MM512_MASK_COSH_PD": return Intrinsic._MM512_MASK_COSH_PD;
                case "_MM512_MASK_COSH_PS": return Intrinsic._MM512_MASK_COSH_PS;
                case "_MM512_MASK_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPI32_PS;
                case "_MM512_MASK_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_MASK_CVT_ROUNDEPI64_PD;
                case "_MM512_MASK_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPI64_PS;
                case "_MM512_MASK_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPU32_PS;
                case "_MM512_MASK_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_MASK_CVT_ROUNDEPU64_PD;
                case "_MM512_MASK_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_MASK_CVT_ROUNDEPU64_PS;
                case "_MM512_MASK_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPI32;
                case "_MM512_MASK_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPI64;
                case "_MM512_MASK_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPU32;
                case "_MM512_MASK_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_MASK_CVT_ROUNDPD_EPU64;
                case "_MM512_MASK_CVT_ROUNDPD_PS": return Intrinsic._MM512_MASK_CVT_ROUNDPD_PS;
                case "_MM512_MASK_CVT_ROUNDPD_PSLO": return Intrinsic._MM512_MASK_CVT_ROUNDPD_PSLO;
                case "_MM512_MASK_CVT_ROUNDPH_PS": return Intrinsic._MM512_MASK_CVT_ROUNDPH_PS;
                case "_MM512_MASK_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPI32;
                case "_MM512_MASK_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPI64;
                case "_MM512_MASK_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPU32;
                case "_MM512_MASK_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_MASK_CVT_ROUNDPS_EPU64;
                case "_MM512_MASK_CVT_ROUNDPS_PD": return Intrinsic._MM512_MASK_CVT_ROUNDPS_PD;
                case "_MM512_MASK_CVT_ROUNDPS_PH": return Intrinsic._MM512_MASK_CVT_ROUNDPS_PH;
                case "_MM512_MASK_CVTEPI16_EPI32": return Intrinsic._MM512_MASK_CVTEPI16_EPI32;
                case "_MM512_MASK_CVTEPI16_EPI64": return Intrinsic._MM512_MASK_CVTEPI16_EPI64;
                case "_MM512_MASK_CVTEPI16_EPI8": return Intrinsic._MM512_MASK_CVTEPI16_EPI8;
                case "_MM512_MASK_CVTEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI32_EPI16": return Intrinsic._MM512_MASK_CVTEPI32_EPI16;
                case "_MM512_MASK_CVTEPI32_EPI64": return Intrinsic._MM512_MASK_CVTEPI32_EPI64;
                case "_MM512_MASK_CVTEPI32_EPI8": return Intrinsic._MM512_MASK_CVTEPI32_EPI8;
                case "_MM512_MASK_CVTEPI32_PD": return Intrinsic._MM512_MASK_CVTEPI32_PD;
                case "_MM512_MASK_CVTEPI32_PS": return Intrinsic._MM512_MASK_CVTEPI32_PS;
                case "_MM512_MASK_CVTEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI32LO_PD": return Intrinsic._MM512_MASK_CVTEPI32LO_PD;
                case "_MM512_MASK_CVTEPI64_EPI16": return Intrinsic._MM512_MASK_CVTEPI64_EPI16;
                case "_MM512_MASK_CVTEPI64_EPI32": return Intrinsic._MM512_MASK_CVTEPI64_EPI32;
                case "_MM512_MASK_CVTEPI64_EPI8": return Intrinsic._MM512_MASK_CVTEPI64_EPI8;
                case "_MM512_MASK_CVTEPI64_PD": return Intrinsic._MM512_MASK_CVTEPI64_PD;
                case "_MM512_MASK_CVTEPI64_PS": return Intrinsic._MM512_MASK_CVTEPI64_PS;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTEPI64_STOREU_EPI8;
                case "_MM512_MASK_CVTEPI8_EPI16": return Intrinsic._MM512_MASK_CVTEPI8_EPI16;
                case "_MM512_MASK_CVTEPI8_EPI32": return Intrinsic._MM512_MASK_CVTEPI8_EPI32;
                case "_MM512_MASK_CVTEPI8_EPI64": return Intrinsic._MM512_MASK_CVTEPI8_EPI64;
                case "_MM512_MASK_CVTEPU16_EPI32": return Intrinsic._MM512_MASK_CVTEPU16_EPI32;
                case "_MM512_MASK_CVTEPU16_EPI64": return Intrinsic._MM512_MASK_CVTEPU16_EPI64;
                case "_MM512_MASK_CVTEPU32_EPI64": return Intrinsic._MM512_MASK_CVTEPU32_EPI64;
                case "_MM512_MASK_CVTEPU32_PD": return Intrinsic._MM512_MASK_CVTEPU32_PD;
                case "_MM512_MASK_CVTEPU32_PS": return Intrinsic._MM512_MASK_CVTEPU32_PS;
                case "_MM512_MASK_CVTEPU32LO_PD": return Intrinsic._MM512_MASK_CVTEPU32LO_PD;
                case "_MM512_MASK_CVTEPU64_PD": return Intrinsic._MM512_MASK_CVTEPU64_PD;
                case "_MM512_MASK_CVTEPU64_PS": return Intrinsic._MM512_MASK_CVTEPU64_PS;
                case "_MM512_MASK_CVTEPU8_EPI16": return Intrinsic._MM512_MASK_CVTEPU8_EPI16;
                case "_MM512_MASK_CVTEPU8_EPI32": return Intrinsic._MM512_MASK_CVTEPU8_EPI32;
                case "_MM512_MASK_CVTEPU8_EPI64": return Intrinsic._MM512_MASK_CVTEPU8_EPI64;
                case "_MM512_MASK_CVTFXPNT_ROUND_ADJUSTEPU32_PS": return Intrinsic._MM512_MASK_CVTFXPNT_ROUND_ADJUSTEPU32_PS;
                case "_MM512_MASK_CVTFXPNT_ROUNDPD_EPI32LO": return Intrinsic._MM512_MASK_CVTFXPNT_ROUNDPD_EPI32LO;
                case "_MM512_MASK_CVTFXPNT_ROUNDPD_EPU32LO": return Intrinsic._MM512_MASK_CVTFXPNT_ROUNDPD_EPU32LO;
                case "_MM512_MASK_CVTPD_EPI32": return Intrinsic._MM512_MASK_CVTPD_EPI32;
                case "_MM512_MASK_CVTPD_EPI64": return Intrinsic._MM512_MASK_CVTPD_EPI64;
                case "_MM512_MASK_CVTPD_EPU32": return Intrinsic._MM512_MASK_CVTPD_EPU32;
                case "_MM512_MASK_CVTPD_EPU64": return Intrinsic._MM512_MASK_CVTPD_EPU64;
                case "_MM512_MASK_CVTPD_PS": return Intrinsic._MM512_MASK_CVTPD_PS;
                case "_MM512_MASK_CVTPD_PSLO": return Intrinsic._MM512_MASK_CVTPD_PSLO;
                case "_MM512_MASK_CVTPH_PS": return Intrinsic._MM512_MASK_CVTPH_PS;
                case "_MM512_MASK_CVTPS_EPI32": return Intrinsic._MM512_MASK_CVTPS_EPI32;
                case "_MM512_MASK_CVTPS_EPI64": return Intrinsic._MM512_MASK_CVTPS_EPI64;
                case "_MM512_MASK_CVTPS_EPU32": return Intrinsic._MM512_MASK_CVTPS_EPU32;
                case "_MM512_MASK_CVTPS_EPU64": return Intrinsic._MM512_MASK_CVTPS_EPU64;
                case "_MM512_MASK_CVTPS_PD": return Intrinsic._MM512_MASK_CVTPS_PD;
                case "_MM512_MASK_CVTPS_PH": return Intrinsic._MM512_MASK_CVTPS_PH;
                case "_MM512_MASK_CVTPSLO_PD": return Intrinsic._MM512_MASK_CVTPSLO_PD;
                case "_MM512_MASK_CVTSEPI16_EPI8": return Intrinsic._MM512_MASK_CVTSEPI16_EPI8;
                case "_MM512_MASK_CVTSEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTSEPI32_EPI16": return Intrinsic._MM512_MASK_CVTSEPI32_EPI16;
                case "_MM512_MASK_CVTSEPI32_EPI8": return Intrinsic._MM512_MASK_CVTSEPI32_EPI8;
                case "_MM512_MASK_CVTSEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTSEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTSEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTSEPI64_EPI16": return Intrinsic._MM512_MASK_CVTSEPI64_EPI16;
                case "_MM512_MASK_CVTSEPI64_EPI32": return Intrinsic._MM512_MASK_CVTSEPI64_EPI32;
                case "_MM512_MASK_CVTSEPI64_EPI8": return Intrinsic._MM512_MASK_CVTSEPI64_EPI8;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTSEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTSEPI64_STOREU_EPI8;
                case "_MM512_MASK_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPI32;
                case "_MM512_MASK_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPI64;
                case "_MM512_MASK_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPU32;
                case "_MM512_MASK_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_MASK_CVTT_ROUNDPD_EPU64;
                case "_MM512_MASK_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPI32;
                case "_MM512_MASK_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPI64;
                case "_MM512_MASK_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPU32;
                case "_MM512_MASK_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_MASK_CVTT_ROUNDPS_EPU64;
                case "_MM512_MASK_CVTTPD_EPI32": return Intrinsic._MM512_MASK_CVTTPD_EPI32;
                case "_MM512_MASK_CVTTPD_EPI64": return Intrinsic._MM512_MASK_CVTTPD_EPI64;
                case "_MM512_MASK_CVTTPD_EPU32": return Intrinsic._MM512_MASK_CVTTPD_EPU32;
                case "_MM512_MASK_CVTTPD_EPU64": return Intrinsic._MM512_MASK_CVTTPD_EPU64;
                case "_MM512_MASK_CVTTPS_EPI32": return Intrinsic._MM512_MASK_CVTTPS_EPI32;
                case "_MM512_MASK_CVTTPS_EPI64": return Intrinsic._MM512_MASK_CVTTPS_EPI64;
                case "_MM512_MASK_CVTTPS_EPU32": return Intrinsic._MM512_MASK_CVTTPS_EPU32;
                case "_MM512_MASK_CVTTPS_EPU64": return Intrinsic._MM512_MASK_CVTTPS_EPU64;
                case "_MM512_MASK_CVTUSEPI16_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI16_EPI8;
                case "_MM512_MASK_CVTUSEPI16_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI16_STOREU_EPI8;
                case "_MM512_MASK_CVTUSEPI32_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI32_EPI16;
                case "_MM512_MASK_CVTUSEPI32_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI32_EPI8;
                case "_MM512_MASK_CVTUSEPI32_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI32_STOREU_EPI16;
                case "_MM512_MASK_CVTUSEPI32_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI32_STOREU_EPI8;
                case "_MM512_MASK_CVTUSEPI64_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI16;
                case "_MM512_MASK_CVTUSEPI64_EPI32": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI32;
                case "_MM512_MASK_CVTUSEPI64_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI64_EPI8;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI16": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI16;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI32": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI32;
                case "_MM512_MASK_CVTUSEPI64_STOREU_EPI8": return Intrinsic._MM512_MASK_CVTUSEPI64_STOREU_EPI8;
                case "_MM512_MASK_DBSAD_EPU8": return Intrinsic._MM512_MASK_DBSAD_EPU8;
                case "_MM512_MASK_DIV_EPI32": return Intrinsic._MM512_MASK_DIV_EPI32;
                case "_MM512_MASK_DIV_EPU32": return Intrinsic._MM512_MASK_DIV_EPU32;
                case "_MM512_MASK_DIV_PD": return Intrinsic._MM512_MASK_DIV_PD;
                case "_MM512_MASK_DIV_PS": return Intrinsic._MM512_MASK_DIV_PS;
                case "_MM512_MASK_DIV_ROUND_PD": return Intrinsic._MM512_MASK_DIV_ROUND_PD;
                case "_MM512_MASK_DIV_ROUND_PS": return Intrinsic._MM512_MASK_DIV_ROUND_PS;
                case "_MM512_MASK_ERF_PD": return Intrinsic._MM512_MASK_ERF_PD;
                case "_MM512_MASK_ERF_PS": return Intrinsic._MM512_MASK_ERF_PS;
                case "_MM512_MASK_ERFC_PD": return Intrinsic._MM512_MASK_ERFC_PD;
                case "_MM512_MASK_ERFC_PS": return Intrinsic._MM512_MASK_ERFC_PS;
                case "_MM512_MASK_ERFCINV_PD": return Intrinsic._MM512_MASK_ERFCINV_PD;
                case "_MM512_MASK_ERFCINV_PS": return Intrinsic._MM512_MASK_ERFCINV_PS;
                case "_MM512_MASK_ERFINV_PD": return Intrinsic._MM512_MASK_ERFINV_PD;
                case "_MM512_MASK_ERFINV_PS": return Intrinsic._MM512_MASK_ERFINV_PS;
                case "_MM512_MASK_EXP_PD": return Intrinsic._MM512_MASK_EXP_PD;
                case "_MM512_MASK_EXP_PS": return Intrinsic._MM512_MASK_EXP_PS;
                case "_MM512_MASK_EXP10_PD": return Intrinsic._MM512_MASK_EXP10_PD;
                case "_MM512_MASK_EXP10_PS": return Intrinsic._MM512_MASK_EXP10_PS;
                case "_MM512_MASK_EXP2_PD": return Intrinsic._MM512_MASK_EXP2_PD;
                case "_MM512_MASK_EXP2_PS": return Intrinsic._MM512_MASK_EXP2_PS;
                case "_MM512_MASK_EXP223_PS": return Intrinsic._MM512_MASK_EXP223_PS;
                case "_MM512_MASK_EXP2A23_PD": return Intrinsic._MM512_MASK_EXP2A23_PD;
                case "_MM512_MASK_EXP2A23_PS": return Intrinsic._MM512_MASK_EXP2A23_PS;
                case "_MM512_MASK_EXP2A23_ROUND_PD": return Intrinsic._MM512_MASK_EXP2A23_ROUND_PD;
                case "_MM512_MASK_EXP2A23_ROUND_PS": return Intrinsic._MM512_MASK_EXP2A23_ROUND_PS;
                case "_MM512_MASK_EXPAND_EPI32": return Intrinsic._MM512_MASK_EXPAND_EPI32;
                case "_MM512_MASK_EXPAND_EPI64": return Intrinsic._MM512_MASK_EXPAND_EPI64;
                case "_MM512_MASK_EXPAND_PD": return Intrinsic._MM512_MASK_EXPAND_PD;
                case "_MM512_MASK_EXPAND_PS": return Intrinsic._MM512_MASK_EXPAND_PS;
                case "_MM512_MASK_EXPANDLOADU_EPI32": return Intrinsic._MM512_MASK_EXPANDLOADU_EPI32;
                case "_MM512_MASK_EXPANDLOADU_EPI64": return Intrinsic._MM512_MASK_EXPANDLOADU_EPI64;
                case "_MM512_MASK_EXPANDLOADU_PD": return Intrinsic._MM512_MASK_EXPANDLOADU_PD;
                case "_MM512_MASK_EXPANDLOADU_PS": return Intrinsic._MM512_MASK_EXPANDLOADU_PS;
                case "_MM512_MASK_EXPM1_PD": return Intrinsic._MM512_MASK_EXPM1_PD;
                case "_MM512_MASK_EXPM1_PS": return Intrinsic._MM512_MASK_EXPM1_PS;
                case "_MM512_MASK_EXTLOAD_EPI32": return Intrinsic._MM512_MASK_EXTLOAD_EPI32;
                case "_MM512_MASK_EXTLOAD_EPI64": return Intrinsic._MM512_MASK_EXTLOAD_EPI64;
                case "_MM512_MASK_EXTLOAD_PD": return Intrinsic._MM512_MASK_EXTLOAD_PD;
                case "_MM512_MASK_EXTLOAD_PS": return Intrinsic._MM512_MASK_EXTLOAD_PS;
                case "_MM512_MASK_EXTLOADUNPACKHI_EPI32": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_EPI32;
                case "_MM512_MASK_EXTLOADUNPACKHI_EPI64": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_EPI64;
                case "_MM512_MASK_EXTLOADUNPACKHI_PD": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_PD;
                case "_MM512_MASK_EXTLOADUNPACKHI_PS": return Intrinsic._MM512_MASK_EXTLOADUNPACKHI_PS;
                case "_MM512_MASK_EXTLOADUNPACKLO_EPI32": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_EPI32;
                case "_MM512_MASK_EXTLOADUNPACKLO_EPI64": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_EPI64;
                case "_MM512_MASK_EXTLOADUNPACKLO_PD": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_PD;
                case "_MM512_MASK_EXTLOADUNPACKLO_PS": return Intrinsic._MM512_MASK_EXTLOADUNPACKLO_PS;
                case "_MM512_MASK_EXTPACKSTOREHI_EPI32": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_EPI32;
                case "_MM512_MASK_EXTPACKSTOREHI_EPI64": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_EPI64;
                case "_MM512_MASK_EXTPACKSTOREHI_PD": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_PD;
                case "_MM512_MASK_EXTPACKSTOREHI_PS": return Intrinsic._MM512_MASK_EXTPACKSTOREHI_PS;
                case "_MM512_MASK_EXTPACKSTORELO_EPI32": return Intrinsic._MM512_MASK_EXTPACKSTORELO_EPI32;
                case "_MM512_MASK_EXTPACKSTORELO_EPI64": return Intrinsic._MM512_MASK_EXTPACKSTORELO_EPI64;
                case "_MM512_MASK_EXTPACKSTORELO_PD": return Intrinsic._MM512_MASK_EXTPACKSTORELO_PD;
                case "_MM512_MASK_EXTPACKSTORELO_PS": return Intrinsic._MM512_MASK_EXTPACKSTORELO_PS;
                case "_MM512_MASK_EXTRACTF32X4_PS": return Intrinsic._MM512_MASK_EXTRACTF32X4_PS;
                case "_MM512_MASK_EXTRACTF32X8_PS": return Intrinsic._MM512_MASK_EXTRACTF32X8_PS;
                case "_MM512_MASK_EXTRACTF64X2_PD": return Intrinsic._MM512_MASK_EXTRACTF64X2_PD;
                case "_MM512_MASK_EXTRACTF64X4_PD": return Intrinsic._MM512_MASK_EXTRACTF64X4_PD;
                case "_MM512_MASK_EXTRACTI32X4_EPI32": return Intrinsic._MM512_MASK_EXTRACTI32X4_EPI32;
                case "_MM512_MASK_EXTRACTI32X8_EPI32": return Intrinsic._MM512_MASK_EXTRACTI32X8_EPI32;
                case "_MM512_MASK_EXTRACTI64X2_EPI64": return Intrinsic._MM512_MASK_EXTRACTI64X2_EPI64;
                case "_MM512_MASK_EXTRACTI64X4_EPI64": return Intrinsic._MM512_MASK_EXTRACTI64X4_EPI64;
                case "_MM512_MASK_EXTSTORE_EPI32": return Intrinsic._MM512_MASK_EXTSTORE_EPI32;
                case "_MM512_MASK_EXTSTORE_EPI64": return Intrinsic._MM512_MASK_EXTSTORE_EPI64;
                case "_MM512_MASK_EXTSTORE_PD": return Intrinsic._MM512_MASK_EXTSTORE_PD;
                case "_MM512_MASK_EXTSTORE_PS": return Intrinsic._MM512_MASK_EXTSTORE_PS;
                case "_MM512_MASK_FIXUPIMM_PD": return Intrinsic._MM512_MASK_FIXUPIMM_PD;
                case "_MM512_MASK_FIXUPIMM_PS": return Intrinsic._MM512_MASK_FIXUPIMM_PS;
                case "_MM512_MASK_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_MASK_FIXUPIMM_ROUND_PD;
                case "_MM512_MASK_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_MASK_FIXUPIMM_ROUND_PS;
                case "_MM512_MASK_FIXUPNAN_PD": return Intrinsic._MM512_MASK_FIXUPNAN_PD;
                case "_MM512_MASK_FIXUPNAN_PS": return Intrinsic._MM512_MASK_FIXUPNAN_PS;
                case "_MM512_MASK_FLOOR_PD": return Intrinsic._MM512_MASK_FLOOR_PD;
                case "_MM512_MASK_FLOOR_PS": return Intrinsic._MM512_MASK_FLOOR_PS;
                case "_MM512_MASK_FMADD_EPI32": return Intrinsic._MM512_MASK_FMADD_EPI32;
                case "_MM512_MASK_FMADD_PD": return Intrinsic._MM512_MASK_FMADD_PD;
                case "_MM512_MASK_FMADD_PS": return Intrinsic._MM512_MASK_FMADD_PS;
                case "_MM512_MASK_FMADD_ROUND_PD": return Intrinsic._MM512_MASK_FMADD_ROUND_PD;
                case "_MM512_MASK_FMADD_ROUND_PS": return Intrinsic._MM512_MASK_FMADD_ROUND_PS;
                case "_MM512_MASK_FMADD233_EPI32": return Intrinsic._MM512_MASK_FMADD233_EPI32;
                case "_MM512_MASK_FMADD233_PS": return Intrinsic._MM512_MASK_FMADD233_PS;
                case "_MM512_MASK_FMADD233_ROUND_PS": return Intrinsic._MM512_MASK_FMADD233_ROUND_PS;
                case "_MM512_MASK_FMADDSUB_PD": return Intrinsic._MM512_MASK_FMADDSUB_PD;
                case "_MM512_MASK_FMADDSUB_PS": return Intrinsic._MM512_MASK_FMADDSUB_PS;
                case "_MM512_MASK_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASK_FMADDSUB_ROUND_PD;
                case "_MM512_MASK_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASK_FMADDSUB_ROUND_PS;
                case "_MM512_MASK_FMSUB_PD": return Intrinsic._MM512_MASK_FMSUB_PD;
                case "_MM512_MASK_FMSUB_PS": return Intrinsic._MM512_MASK_FMSUB_PS;
                case "_MM512_MASK_FMSUB_ROUND_PD": return Intrinsic._MM512_MASK_FMSUB_ROUND_PD;
                case "_MM512_MASK_FMSUB_ROUND_PS": return Intrinsic._MM512_MASK_FMSUB_ROUND_PS;
                case "_MM512_MASK_FMSUBADD_PD": return Intrinsic._MM512_MASK_FMSUBADD_PD;
                case "_MM512_MASK_FMSUBADD_PS": return Intrinsic._MM512_MASK_FMSUBADD_PS;
                case "_MM512_MASK_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASK_FMSUBADD_ROUND_PD;
                case "_MM512_MASK_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASK_FMSUBADD_ROUND_PS;
                case "_MM512_MASK_FNMADD_PD": return Intrinsic._MM512_MASK_FNMADD_PD;
                case "_MM512_MASK_FNMADD_PS": return Intrinsic._MM512_MASK_FNMADD_PS;
                case "_MM512_MASK_FNMADD_ROUND_PD": return Intrinsic._MM512_MASK_FNMADD_ROUND_PD;
                case "_MM512_MASK_FNMADD_ROUND_PS": return Intrinsic._MM512_MASK_FNMADD_ROUND_PS;
                case "_MM512_MASK_FNMSUB_PD": return Intrinsic._MM512_MASK_FNMSUB_PD;
                case "_MM512_MASK_FNMSUB_PS": return Intrinsic._MM512_MASK_FNMSUB_PS;
                case "_MM512_MASK_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASK_FNMSUB_ROUND_PD;
                case "_MM512_MASK_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASK_FNMSUB_ROUND_PS;
                case "_MM512_MASK_FPCLASS_PD_MASK": return Intrinsic._MM512_MASK_FPCLASS_PD_MASK;
                case "_MM512_MASK_FPCLASS_PS_MASK": return Intrinsic._MM512_MASK_FPCLASS_PS_MASK;
                case "_MM512_MASK_GETEXP_PD": return Intrinsic._MM512_MASK_GETEXP_PD;
                case "_MM512_MASK_GETEXP_PS": return Intrinsic._MM512_MASK_GETEXP_PS;
                case "_MM512_MASK_GETEXP_ROUND_PD": return Intrinsic._MM512_MASK_GETEXP_ROUND_PD;
                case "_MM512_MASK_GETEXP_ROUND_PS": return Intrinsic._MM512_MASK_GETEXP_ROUND_PS;
                case "_MM512_MASK_GETMANT_PD": return Intrinsic._MM512_MASK_GETMANT_PD;
                case "_MM512_MASK_GETMANT_PS": return Intrinsic._MM512_MASK_GETMANT_PS;
                case "_MM512_MASK_GETMANT_ROUND_PD": return Intrinsic._MM512_MASK_GETMANT_ROUND_PD;
                case "_MM512_MASK_GETMANT_ROUND_PS": return Intrinsic._MM512_MASK_GETMANT_ROUND_PS;
                case "_MM512_MASK_GMAX_PD": return Intrinsic._MM512_MASK_GMAX_PD;
                case "_MM512_MASK_GMAX_PS": return Intrinsic._MM512_MASK_GMAX_PS;
                case "_MM512_MASK_GMAXABS_PS": return Intrinsic._MM512_MASK_GMAXABS_PS;
                case "_MM512_MASK_GMIN_PD": return Intrinsic._MM512_MASK_GMIN_PD;
                case "_MM512_MASK_GMIN_PS": return Intrinsic._MM512_MASK_GMIN_PS;
                case "_MM512_MASK_HYPOT_PD": return Intrinsic._MM512_MASK_HYPOT_PD;
                case "_MM512_MASK_HYPOT_PS": return Intrinsic._MM512_MASK_HYPOT_PS;
                case "_MM512_MASK_I32EXTGATHER_EPI32": return Intrinsic._MM512_MASK_I32EXTGATHER_EPI32;
                case "_MM512_MASK_I32EXTGATHER_PS": return Intrinsic._MM512_MASK_I32EXTGATHER_PS;
                case "_MM512_MASK_I32EXTSCATTER_EPI32": return Intrinsic._MM512_MASK_I32EXTSCATTER_EPI32;
                case "_MM512_MASK_I32EXTSCATTER_PS": return Intrinsic._MM512_MASK_I32EXTSCATTER_PS;
                case "_MM512_MASK_I32GATHER_EPI32": return Intrinsic._MM512_MASK_I32GATHER_EPI32;
                case "_MM512_MASK_I32GATHER_EPI64": return Intrinsic._MM512_MASK_I32GATHER_EPI64;
                case "_MM512_MASK_I32GATHER_PD": return Intrinsic._MM512_MASK_I32GATHER_PD;
                case "_MM512_MASK_I32GATHER_PS": return Intrinsic._MM512_MASK_I32GATHER_PS;
                case "_MM512_MASK_I32LOEXTGATHER_EPI64": return Intrinsic._MM512_MASK_I32LOEXTGATHER_EPI64;
                case "_MM512_MASK_I32LOEXTGATHER_PD": return Intrinsic._MM512_MASK_I32LOEXTGATHER_PD;
                case "_MM512_MASK_I32LOEXTSCATTER_EPI64": return Intrinsic._MM512_MASK_I32LOEXTSCATTER_EPI64;
                case "_MM512_MASK_I32LOEXTSCATTER_PD": return Intrinsic._MM512_MASK_I32LOEXTSCATTER_PD;
                case "_MM512_MASK_I32LOGATHER_EPI64": return Intrinsic._MM512_MASK_I32LOGATHER_EPI64;
                case "_MM512_MASK_I32LOGATHER_PD": return Intrinsic._MM512_MASK_I32LOGATHER_PD;
                case "_MM512_MASK_I32LOSCATTER_EPI64": return Intrinsic._MM512_MASK_I32LOSCATTER_EPI64;
                case "_MM512_MASK_I32LOSCATTER_PD": return Intrinsic._MM512_MASK_I32LOSCATTER_PD;
                case "_MM512_MASK_I32SCATTER_EPI32": return Intrinsic._MM512_MASK_I32SCATTER_EPI32;
                case "_MM512_MASK_I32SCATTER_EPI64": return Intrinsic._MM512_MASK_I32SCATTER_EPI64;
                case "_MM512_MASK_I32SCATTER_PD": return Intrinsic._MM512_MASK_I32SCATTER_PD;
                case "_MM512_MASK_I32SCATTER_PS": return Intrinsic._MM512_MASK_I32SCATTER_PS;
                case "_MM512_MASK_I64EXTGATHER_EPI32LO": return Intrinsic._MM512_MASK_I64EXTGATHER_EPI32LO;
                case "_MM512_MASK_I64EXTGATHER_EPI64": return Intrinsic._MM512_MASK_I64EXTGATHER_EPI64;
                case "_MM512_MASK_I64EXTGATHER_PD": return Intrinsic._MM512_MASK_I64EXTGATHER_PD;
                case "_MM512_MASK_I64EXTGATHER_PSLO": return Intrinsic._MM512_MASK_I64EXTGATHER_PSLO;
                case "_MM512_MASK_I64EXTSCATTER_EPI32LO": return Intrinsic._MM512_MASK_I64EXTSCATTER_EPI32LO;
                case "_MM512_MASK_I64EXTSCATTER_EPI64": return Intrinsic._MM512_MASK_I64EXTSCATTER_EPI64;
                case "_MM512_MASK_I64EXTSCATTER_PD": return Intrinsic._MM512_MASK_I64EXTSCATTER_PD;
                case "_MM512_MASK_I64EXTSCATTER_PSLO": return Intrinsic._MM512_MASK_I64EXTSCATTER_PSLO;
                case "_MM512_MASK_I64GATHER_EPI32": return Intrinsic._MM512_MASK_I64GATHER_EPI32;
                case "_MM512_MASK_I64GATHER_EPI32LO": return Intrinsic._MM512_MASK_I64GATHER_EPI32LO;
                case "_MM512_MASK_I64GATHER_EPI64": return Intrinsic._MM512_MASK_I64GATHER_EPI64;
                case "_MM512_MASK_I64GATHER_PD": return Intrinsic._MM512_MASK_I64GATHER_PD;
                case "_MM512_MASK_I64GATHER_PS": return Intrinsic._MM512_MASK_I64GATHER_PS;
                case "_MM512_MASK_I64GATHER_PSLO": return Intrinsic._MM512_MASK_I64GATHER_PSLO;
                case "_MM512_MASK_I64SCATTER_EPI32": return Intrinsic._MM512_MASK_I64SCATTER_EPI32;
                case "_MM512_MASK_I64SCATTER_EPI32LO": return Intrinsic._MM512_MASK_I64SCATTER_EPI32LO;
                case "_MM512_MASK_I64SCATTER_EPI64": return Intrinsic._MM512_MASK_I64SCATTER_EPI64;
                case "_MM512_MASK_I64SCATTER_PD": return Intrinsic._MM512_MASK_I64SCATTER_PD;
                case "_MM512_MASK_I64SCATTER_PS": return Intrinsic._MM512_MASK_I64SCATTER_PS;
                case "_MM512_MASK_I64SCATTER_PSLO": return Intrinsic._MM512_MASK_I64SCATTER_PSLO;
                case "_MM512_MASK_INSERTF32X4": return Intrinsic._MM512_MASK_INSERTF32X4;
                case "_MM512_MASK_INSERTF32X8": return Intrinsic._MM512_MASK_INSERTF32X8;
                case "_MM512_MASK_INSERTF64X2": return Intrinsic._MM512_MASK_INSERTF64X2;
                case "_MM512_MASK_INSERTF64X4": return Intrinsic._MM512_MASK_INSERTF64X4;
                case "_MM512_MASK_INSERTI32X4": return Intrinsic._MM512_MASK_INSERTI32X4;
                case "_MM512_MASK_INSERTI32X8": return Intrinsic._MM512_MASK_INSERTI32X8;
                case "_MM512_MASK_INSERTI64X2": return Intrinsic._MM512_MASK_INSERTI64X2;
                case "_MM512_MASK_INSERTI64X4": return Intrinsic._MM512_MASK_INSERTI64X4;
                case "_MM512_MASK_INVSQRT_PD": return Intrinsic._MM512_MASK_INVSQRT_PD;
                case "_MM512_MASK_INVSQRT_PS": return Intrinsic._MM512_MASK_INVSQRT_PS;
                case "_MM512_MASK_LOAD_EPI32": return Intrinsic._MM512_MASK_LOAD_EPI32;
                case "_MM512_MASK_LOAD_EPI64": return Intrinsic._MM512_MASK_LOAD_EPI64;
                case "_MM512_MASK_LOAD_PD": return Intrinsic._MM512_MASK_LOAD_PD;
                case "_MM512_MASK_LOAD_PS": return Intrinsic._MM512_MASK_LOAD_PS;
                case "_MM512_MASK_LOADU_EPI16": return Intrinsic._MM512_MASK_LOADU_EPI16;
                case "_MM512_MASK_LOADU_EPI32": return Intrinsic._MM512_MASK_LOADU_EPI32;
                case "_MM512_MASK_LOADU_EPI64": return Intrinsic._MM512_MASK_LOADU_EPI64;
                case "_MM512_MASK_LOADU_EPI8": return Intrinsic._MM512_MASK_LOADU_EPI8;
                case "_MM512_MASK_LOADU_PD": return Intrinsic._MM512_MASK_LOADU_PD;
                case "_MM512_MASK_LOADU_PS": return Intrinsic._MM512_MASK_LOADU_PS;
                case "_MM512_MASK_LOADUNPACKHI_EPI32": return Intrinsic._MM512_MASK_LOADUNPACKHI_EPI32;
                case "_MM512_MASK_LOADUNPACKHI_EPI64": return Intrinsic._MM512_MASK_LOADUNPACKHI_EPI64;
                case "_MM512_MASK_LOADUNPACKHI_PD": return Intrinsic._MM512_MASK_LOADUNPACKHI_PD;
                case "_MM512_MASK_LOADUNPACKHI_PS": return Intrinsic._MM512_MASK_LOADUNPACKHI_PS;
                case "_MM512_MASK_LOADUNPACKLO_EPI32": return Intrinsic._MM512_MASK_LOADUNPACKLO_EPI32;
                case "_MM512_MASK_LOADUNPACKLO_EPI64": return Intrinsic._MM512_MASK_LOADUNPACKLO_EPI64;
                case "_MM512_MASK_LOADUNPACKLO_PD": return Intrinsic._MM512_MASK_LOADUNPACKLO_PD;
                case "_MM512_MASK_LOADUNPACKLO_PS": return Intrinsic._MM512_MASK_LOADUNPACKLO_PS;
                case "_MM512_MASK_LOG_PD": return Intrinsic._MM512_MASK_LOG_PD;
                case "_MM512_MASK_LOG_PS": return Intrinsic._MM512_MASK_LOG_PS;
                case "_MM512_MASK_LOG10_PD": return Intrinsic._MM512_MASK_LOG10_PD;
                case "_MM512_MASK_LOG10_PS": return Intrinsic._MM512_MASK_LOG10_PS;
                case "_MM512_MASK_LOG1P_PD": return Intrinsic._MM512_MASK_LOG1P_PD;
                case "_MM512_MASK_LOG1P_PS": return Intrinsic._MM512_MASK_LOG1P_PS;
                case "_MM512_MASK_LOG2_PD": return Intrinsic._MM512_MASK_LOG2_PD;
                case "_MM512_MASK_LOG2_PS": return Intrinsic._MM512_MASK_LOG2_PS;
                case "_MM512_MASK_LOG2AE23_PS": return Intrinsic._MM512_MASK_LOG2AE23_PS;
                case "_MM512_MASK_LOGB_PD": return Intrinsic._MM512_MASK_LOGB_PD;
                case "_MM512_MASK_LOGB_PS": return Intrinsic._MM512_MASK_LOGB_PS;
                case "_MM512_MASK_LZCNT_EPI32": return Intrinsic._MM512_MASK_LZCNT_EPI32;
                case "_MM512_MASK_LZCNT_EPI64": return Intrinsic._MM512_MASK_LZCNT_EPI64;
                case "_MM512_MASK_MADD_EPI16": return Intrinsic._MM512_MASK_MADD_EPI16;
                case "_MM512_MASK_MADD52HI_EPU64": return Intrinsic._MM512_MASK_MADD52HI_EPU64;
                case "_MM512_MASK_MADD52LO_EPU64": return Intrinsic._MM512_MASK_MADD52LO_EPU64;
                case "_MM512_MASK_MADDUBS_EPI16": return Intrinsic._MM512_MASK_MADDUBS_EPI16;
                case "_MM512_MASK_MAX_EPI16": return Intrinsic._MM512_MASK_MAX_EPI16;
                case "_MM512_MASK_MAX_EPI32": return Intrinsic._MM512_MASK_MAX_EPI32;
                case "_MM512_MASK_MAX_EPI64": return Intrinsic._MM512_MASK_MAX_EPI64;
                case "_MM512_MASK_MAX_EPI8": return Intrinsic._MM512_MASK_MAX_EPI8;
                case "_MM512_MASK_MAX_EPU16": return Intrinsic._MM512_MASK_MAX_EPU16;
                case "_MM512_MASK_MAX_EPU32": return Intrinsic._MM512_MASK_MAX_EPU32;
                case "_MM512_MASK_MAX_EPU64": return Intrinsic._MM512_MASK_MAX_EPU64;
                case "_MM512_MASK_MAX_EPU8": return Intrinsic._MM512_MASK_MAX_EPU8;
                case "_MM512_MASK_MAX_PD": return Intrinsic._MM512_MASK_MAX_PD;
                case "_MM512_MASK_MAX_PS": return Intrinsic._MM512_MASK_MAX_PS;
                case "_MM512_MASK_MAX_ROUND_PD": return Intrinsic._MM512_MASK_MAX_ROUND_PD;
                case "_MM512_MASK_MAX_ROUND_PS": return Intrinsic._MM512_MASK_MAX_ROUND_PS;
                case "_MM512_MASK_MAXABS_PS": return Intrinsic._MM512_MASK_MAXABS_PS;
                case "_MM512_MASK_MIN_EPI16": return Intrinsic._MM512_MASK_MIN_EPI16;
                case "_MM512_MASK_MIN_EPI32": return Intrinsic._MM512_MASK_MIN_EPI32;
                case "_MM512_MASK_MIN_EPI64": return Intrinsic._MM512_MASK_MIN_EPI64;
                case "_MM512_MASK_MIN_EPI8": return Intrinsic._MM512_MASK_MIN_EPI8;
                case "_MM512_MASK_MIN_EPU16": return Intrinsic._MM512_MASK_MIN_EPU16;
                case "_MM512_MASK_MIN_EPU32": return Intrinsic._MM512_MASK_MIN_EPU32;
                case "_MM512_MASK_MIN_EPU64": return Intrinsic._MM512_MASK_MIN_EPU64;
                case "_MM512_MASK_MIN_EPU8": return Intrinsic._MM512_MASK_MIN_EPU8;
                case "_MM512_MASK_MIN_PD": return Intrinsic._MM512_MASK_MIN_PD;
                case "_MM512_MASK_MIN_PS": return Intrinsic._MM512_MASK_MIN_PS;
                case "_MM512_MASK_MIN_ROUND_PD": return Intrinsic._MM512_MASK_MIN_ROUND_PD;
                case "_MM512_MASK_MIN_ROUND_PS": return Intrinsic._MM512_MASK_MIN_ROUND_PS;
                case "_MM512_MASK_MOV_EPI16": return Intrinsic._MM512_MASK_MOV_EPI16;
                case "_MM512_MASK_MOV_EPI32": return Intrinsic._MM512_MASK_MOV_EPI32;
                case "_MM512_MASK_MOV_EPI64": return Intrinsic._MM512_MASK_MOV_EPI64;
                case "_MM512_MASK_MOV_EPI8": return Intrinsic._MM512_MASK_MOV_EPI8;
                case "_MM512_MASK_MOV_PD": return Intrinsic._MM512_MASK_MOV_PD;
                case "_MM512_MASK_MOV_PS": return Intrinsic._MM512_MASK_MOV_PS;
                case "_MM512_MASK_MOVEDUP_PD": return Intrinsic._MM512_MASK_MOVEDUP_PD;
                case "_MM512_MASK_MOVEHDUP_PS": return Intrinsic._MM512_MASK_MOVEHDUP_PS;
                case "_MM512_MASK_MOVELDUP_PS": return Intrinsic._MM512_MASK_MOVELDUP_PS;
                case "_MM512_MASK_MUL_EPI32": return Intrinsic._MM512_MASK_MUL_EPI32;
                case "_MM512_MASK_MUL_EPU32": return Intrinsic._MM512_MASK_MUL_EPU32;
                case "_MM512_MASK_MUL_PD": return Intrinsic._MM512_MASK_MUL_PD;
                case "_MM512_MASK_MUL_PS": return Intrinsic._MM512_MASK_MUL_PS;
                case "_MM512_MASK_MUL_ROUND_PD": return Intrinsic._MM512_MASK_MUL_ROUND_PD;
                case "_MM512_MASK_MUL_ROUND_PS": return Intrinsic._MM512_MASK_MUL_ROUND_PS;
                case "_MM512_MASK_MULHI_EPI16": return Intrinsic._MM512_MASK_MULHI_EPI16;
                case "_MM512_MASK_MULHI_EPI32": return Intrinsic._MM512_MASK_MULHI_EPI32;
                case "_MM512_MASK_MULHI_EPU16": return Intrinsic._MM512_MASK_MULHI_EPU16;
                case "_MM512_MASK_MULHI_EPU32": return Intrinsic._MM512_MASK_MULHI_EPU32;
                case "_MM512_MASK_MULHRS_EPI16": return Intrinsic._MM512_MASK_MULHRS_EPI16;
                case "_MM512_MASK_MULLO_EPI16": return Intrinsic._MM512_MASK_MULLO_EPI16;
                case "_MM512_MASK_MULLO_EPI32": return Intrinsic._MM512_MASK_MULLO_EPI32;
                case "_MM512_MASK_MULLO_EPI64": return Intrinsic._MM512_MASK_MULLO_EPI64;
                case "_MM512_MASK_MULLOX_EPI64": return Intrinsic._MM512_MASK_MULLOX_EPI64;
                case "_MM512_MASK_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM512_MASK_MULTISHIFT_EPI64_EPI8;
                case "_MM512_MASK_NEARBYINT_PD": return Intrinsic._MM512_MASK_NEARBYINT_PD;
                case "_MM512_MASK_NEARBYINT_PS": return Intrinsic._MM512_MASK_NEARBYINT_PS;
                case "_MM512_MASK_OR_EPI32": return Intrinsic._MM512_MASK_OR_EPI32;
                case "_MM512_MASK_OR_EPI64": return Intrinsic._MM512_MASK_OR_EPI64;
                case "_MM512_MASK_OR_PD": return Intrinsic._MM512_MASK_OR_PD;
                case "_MM512_MASK_OR_PS": return Intrinsic._MM512_MASK_OR_PS;
                case "_MM512_MASK_PACKS_EPI16": return Intrinsic._MM512_MASK_PACKS_EPI16;
                case "_MM512_MASK_PACKS_EPI32": return Intrinsic._MM512_MASK_PACKS_EPI32;
                case "_MM512_MASK_PACKSTOREHI_EPI32": return Intrinsic._MM512_MASK_PACKSTOREHI_EPI32;
                case "_MM512_MASK_PACKSTOREHI_EPI64": return Intrinsic._MM512_MASK_PACKSTOREHI_EPI64;
                case "_MM512_MASK_PACKSTOREHI_PD": return Intrinsic._MM512_MASK_PACKSTOREHI_PD;
                case "_MM512_MASK_PACKSTOREHI_PS": return Intrinsic._MM512_MASK_PACKSTOREHI_PS;
                case "_MM512_MASK_PACKSTORELO_EPI32": return Intrinsic._MM512_MASK_PACKSTORELO_EPI32;
                case "_MM512_MASK_PACKSTORELO_EPI64": return Intrinsic._MM512_MASK_PACKSTORELO_EPI64;
                case "_MM512_MASK_PACKSTORELO_PD": return Intrinsic._MM512_MASK_PACKSTORELO_PD;
                case "_MM512_MASK_PACKSTORELO_PS": return Intrinsic._MM512_MASK_PACKSTORELO_PS;
                case "_MM512_MASK_PACKUS_EPI16": return Intrinsic._MM512_MASK_PACKUS_EPI16;
                case "_MM512_MASK_PACKUS_EPI32": return Intrinsic._MM512_MASK_PACKUS_EPI32;
                case "_MM512_MASK_PERMUTE_PD": return Intrinsic._MM512_MASK_PERMUTE_PD;
                case "_MM512_MASK_PERMUTE_PS": return Intrinsic._MM512_MASK_PERMUTE_PS;
                case "_MM512_MASK_PERMUTE4F128_EPI32": return Intrinsic._MM512_MASK_PERMUTE4F128_EPI32;
                case "_MM512_MASK_PERMUTE4F128_PS": return Intrinsic._MM512_MASK_PERMUTE4F128_PS;
                case "_MM512_MASK_PERMUTEVAR_EPI32": return Intrinsic._MM512_MASK_PERMUTEVAR_EPI32;
                case "_MM512_MASK_PERMUTEVAR_PD": return Intrinsic._MM512_MASK_PERMUTEVAR_PD;
                case "_MM512_MASK_PERMUTEVAR_PS": return Intrinsic._MM512_MASK_PERMUTEVAR_PS;
                case "_MM512_MASK_PERMUTEX_EPI64": return Intrinsic._MM512_MASK_PERMUTEX_EPI64;
                case "_MM512_MASK_PERMUTEX_PD": return Intrinsic._MM512_MASK_PERMUTEX_PD;
                case "_MM512_MASK_PERMUTEX2VAR_EPI16": return Intrinsic._MM512_MASK_PERMUTEX2VAR_EPI16;
                case "_MM512_MASK_PERMUTEX2VAR_EPI32": return Intrinsic._MM512_MASK_PERMUTEX2VAR_EPI32;
                case "_MM512_MASK_PERMUTEX2VAR_EPI64": return Intrinsic._MM512_MASK_PERMUTEX2VAR_EPI64;
                case "_MM512_MASK_PERMUTEX2VAR_EPI8": return Intrinsic._MM512_MASK_PERMUTEX2VAR_EPI8;
                case "_MM512_MASK_PERMUTEX2VAR_PD": return Intrinsic._MM512_MASK_PERMUTEX2VAR_PD;
                case "_MM512_MASK_PERMUTEX2VAR_PS": return Intrinsic._MM512_MASK_PERMUTEX2VAR_PS;
                case "_MM512_MASK_PERMUTEXVAR_EPI16": return Intrinsic._MM512_MASK_PERMUTEXVAR_EPI16;
                case "_MM512_MASK_PERMUTEXVAR_EPI32": return Intrinsic._MM512_MASK_PERMUTEXVAR_EPI32;
                case "_MM512_MASK_PERMUTEXVAR_EPI64": return Intrinsic._MM512_MASK_PERMUTEXVAR_EPI64;
                case "_MM512_MASK_PERMUTEXVAR_EPI8": return Intrinsic._MM512_MASK_PERMUTEXVAR_EPI8;
                case "_MM512_MASK_PERMUTEXVAR_PD": return Intrinsic._MM512_MASK_PERMUTEXVAR_PD;
                case "_MM512_MASK_PERMUTEXVAR_PS": return Intrinsic._MM512_MASK_PERMUTEXVAR_PS;
                case "_MM512_MASK_POW_PD": return Intrinsic._MM512_MASK_POW_PD;
                case "_MM512_MASK_POW_PS": return Intrinsic._MM512_MASK_POW_PS;
                case "_MM512_MASK_PREFETCH_I32EXTGATHER_PS": return Intrinsic._MM512_MASK_PREFETCH_I32EXTGATHER_PS;
                case "_MM512_MASK_PREFETCH_I32EXTSCATTER_PS": return Intrinsic._MM512_MASK_PREFETCH_I32EXTSCATTER_PS;
                case "_MM512_MASK_PREFETCH_I32GATHER_PD": return Intrinsic._MM512_MASK_PREFETCH_I32GATHER_PD;
                case "_MM512_MASK_PREFETCH_I32GATHER_PS": return Intrinsic._MM512_MASK_PREFETCH_I32GATHER_PS;
                case "_MM512_MASK_PREFETCH_I32SCATTER_PD": return Intrinsic._MM512_MASK_PREFETCH_I32SCATTER_PD;
                case "_MM512_MASK_PREFETCH_I32SCATTER_PS": return Intrinsic._MM512_MASK_PREFETCH_I32SCATTER_PS;
                case "_MM512_MASK_PREFETCH_I64GATHER_PD": return Intrinsic._MM512_MASK_PREFETCH_I64GATHER_PD;
                case "_MM512_MASK_PREFETCH_I64GATHER_PS": return Intrinsic._MM512_MASK_PREFETCH_I64GATHER_PS;
                case "_MM512_MASK_PREFETCH_I64SCATTER_PD": return Intrinsic._MM512_MASK_PREFETCH_I64SCATTER_PD;
                case "_MM512_MASK_PREFETCH_I64SCATTER_PS": return Intrinsic._MM512_MASK_PREFETCH_I64SCATTER_PS;
                case "_MM512_MASK_RANGE_PD": return Intrinsic._MM512_MASK_RANGE_PD;
                case "_MM512_MASK_RANGE_PS": return Intrinsic._MM512_MASK_RANGE_PS;
                case "_MM512_MASK_RANGE_ROUND_PD": return Intrinsic._MM512_MASK_RANGE_ROUND_PD;
                case "_MM512_MASK_RANGE_ROUND_PS": return Intrinsic._MM512_MASK_RANGE_ROUND_PS;
                case "_MM512_MASK_RCP14_PD": return Intrinsic._MM512_MASK_RCP14_PD;
                case "_MM512_MASK_RCP14_PS": return Intrinsic._MM512_MASK_RCP14_PS;
                case "_MM512_MASK_RCP23_PS": return Intrinsic._MM512_MASK_RCP23_PS;
                case "_MM512_MASK_RCP28_PD": return Intrinsic._MM512_MASK_RCP28_PD;
                case "_MM512_MASK_RCP28_PS": return Intrinsic._MM512_MASK_RCP28_PS;
                case "_MM512_MASK_RCP28_ROUND_PD": return Intrinsic._MM512_MASK_RCP28_ROUND_PD;
                case "_MM512_MASK_RCP28_ROUND_PS": return Intrinsic._MM512_MASK_RCP28_ROUND_PS;
                case "_MM512_MASK_RECIP_PD": return Intrinsic._MM512_MASK_RECIP_PD;
                case "_MM512_MASK_RECIP_PS": return Intrinsic._MM512_MASK_RECIP_PS;
                case "_MM512_MASK_REDUCE_ADD_EPI32": return Intrinsic._MM512_MASK_REDUCE_ADD_EPI32;
                case "_MM512_MASK_REDUCE_ADD_EPI64": return Intrinsic._MM512_MASK_REDUCE_ADD_EPI64;
                case "_MM512_MASK_REDUCE_ADD_PD": return Intrinsic._MM512_MASK_REDUCE_ADD_PD;
                case "_MM512_MASK_REDUCE_ADD_PS": return Intrinsic._MM512_MASK_REDUCE_ADD_PS;
                case "_MM512_MASK_REDUCE_AND_EPI32": return Intrinsic._MM512_MASK_REDUCE_AND_EPI32;
                case "_MM512_MASK_REDUCE_AND_EPI64": return Intrinsic._MM512_MASK_REDUCE_AND_EPI64;
                case "_MM512_MASK_REDUCE_GMAX_PD": return Intrinsic._MM512_MASK_REDUCE_GMAX_PD;
                case "_MM512_MASK_REDUCE_GMAX_PS": return Intrinsic._MM512_MASK_REDUCE_GMAX_PS;
                case "_MM512_MASK_REDUCE_GMIN_PD": return Intrinsic._MM512_MASK_REDUCE_GMIN_PD;
                case "_MM512_MASK_REDUCE_GMIN_PS": return Intrinsic._MM512_MASK_REDUCE_GMIN_PS;
                case "_MM512_MASK_REDUCE_MAX_EPI32": return Intrinsic._MM512_MASK_REDUCE_MAX_EPI32;
                case "_MM512_MASK_REDUCE_MAX_EPI64": return Intrinsic._MM512_MASK_REDUCE_MAX_EPI64;
                case "_MM512_MASK_REDUCE_MAX_EPU32": return Intrinsic._MM512_MASK_REDUCE_MAX_EPU32;
                case "_MM512_MASK_REDUCE_MAX_EPU64": return Intrinsic._MM512_MASK_REDUCE_MAX_EPU64;
                case "_MM512_MASK_REDUCE_MAX_PD": return Intrinsic._MM512_MASK_REDUCE_MAX_PD;
                case "_MM512_MASK_REDUCE_MAX_PS": return Intrinsic._MM512_MASK_REDUCE_MAX_PS;
                case "_MM512_MASK_REDUCE_MIN_EPI32": return Intrinsic._MM512_MASK_REDUCE_MIN_EPI32;
                case "_MM512_MASK_REDUCE_MIN_EPI64": return Intrinsic._MM512_MASK_REDUCE_MIN_EPI64;
                case "_MM512_MASK_REDUCE_MIN_EPU32": return Intrinsic._MM512_MASK_REDUCE_MIN_EPU32;
                case "_MM512_MASK_REDUCE_MIN_EPU64": return Intrinsic._MM512_MASK_REDUCE_MIN_EPU64;
                case "_MM512_MASK_REDUCE_MIN_PD": return Intrinsic._MM512_MASK_REDUCE_MIN_PD;
                case "_MM512_MASK_REDUCE_MIN_PS": return Intrinsic._MM512_MASK_REDUCE_MIN_PS;
                case "_MM512_MASK_REDUCE_MUL_EPI32": return Intrinsic._MM512_MASK_REDUCE_MUL_EPI32;
                case "_MM512_MASK_REDUCE_MUL_EPI64": return Intrinsic._MM512_MASK_REDUCE_MUL_EPI64;
                case "_MM512_MASK_REDUCE_MUL_PD": return Intrinsic._MM512_MASK_REDUCE_MUL_PD;
                case "_MM512_MASK_REDUCE_MUL_PS": return Intrinsic._MM512_MASK_REDUCE_MUL_PS;
                case "_MM512_MASK_REDUCE_OR_EPI32": return Intrinsic._MM512_MASK_REDUCE_OR_EPI32;
                case "_MM512_MASK_REDUCE_OR_EPI64": return Intrinsic._MM512_MASK_REDUCE_OR_EPI64;
                case "_MM512_MASK_REDUCE_PD": return Intrinsic._MM512_MASK_REDUCE_PD;
                case "_MM512_MASK_REDUCE_PS": return Intrinsic._MM512_MASK_REDUCE_PS;
                case "_MM512_MASK_REDUCE_ROUND_PD": return Intrinsic._MM512_MASK_REDUCE_ROUND_PD;
                case "_MM512_MASK_REDUCE_ROUND_PS": return Intrinsic._MM512_MASK_REDUCE_ROUND_PS;
                case "_MM512_MASK_REM_EPI32": return Intrinsic._MM512_MASK_REM_EPI32;
                case "_MM512_MASK_REM_EPU32": return Intrinsic._MM512_MASK_REM_EPU32;
                case "_MM512_MASK_RINT_PD": return Intrinsic._MM512_MASK_RINT_PD;
                case "_MM512_MASK_RINT_PS": return Intrinsic._MM512_MASK_RINT_PS;
                case "_MM512_MASK_ROL_EPI32": return Intrinsic._MM512_MASK_ROL_EPI32;
                case "_MM512_MASK_ROL_EPI64": return Intrinsic._MM512_MASK_ROL_EPI64;
                case "_MM512_MASK_ROLV_EPI32": return Intrinsic._MM512_MASK_ROLV_EPI32;
                case "_MM512_MASK_ROLV_EPI64": return Intrinsic._MM512_MASK_ROLV_EPI64;
                case "_MM512_MASK_ROR_EPI32": return Intrinsic._MM512_MASK_ROR_EPI32;
                case "_MM512_MASK_ROR_EPI64": return Intrinsic._MM512_MASK_ROR_EPI64;
                case "_MM512_MASK_RORV_EPI32": return Intrinsic._MM512_MASK_RORV_EPI32;
                case "_MM512_MASK_RORV_EPI64": return Intrinsic._MM512_MASK_RORV_EPI64;
                case "_MM512_MASK_ROUND_PS": return Intrinsic._MM512_MASK_ROUND_PS;
                case "_MM512_MASK_ROUNDFXPNT_ADJUST_PD": return Intrinsic._MM512_MASK_ROUNDFXPNT_ADJUST_PD;
                case "_MM512_MASK_ROUNDFXPNT_ADJUST_PS": return Intrinsic._MM512_MASK_ROUNDFXPNT_ADJUST_PS;
                case "_MM512_MASK_ROUNDSCALE_PD": return Intrinsic._MM512_MASK_ROUNDSCALE_PD;
                case "_MM512_MASK_ROUNDSCALE_PS": return Intrinsic._MM512_MASK_ROUNDSCALE_PS;
                case "_MM512_MASK_ROUNDSCALE_ROUND_PD": return Intrinsic._MM512_MASK_ROUNDSCALE_ROUND_PD;
                case "_MM512_MASK_ROUNDSCALE_ROUND_PS": return Intrinsic._MM512_MASK_ROUNDSCALE_ROUND_PS;
                case "_MM512_MASK_RSQRT14_PD": return Intrinsic._MM512_MASK_RSQRT14_PD;
                case "_MM512_MASK_RSQRT14_PS": return Intrinsic._MM512_MASK_RSQRT14_PS;
                case "_MM512_MASK_RSQRT23_PS": return Intrinsic._MM512_MASK_RSQRT23_PS;
                case "_MM512_MASK_RSQRT28_PD": return Intrinsic._MM512_MASK_RSQRT28_PD;
                case "_MM512_MASK_RSQRT28_PS": return Intrinsic._MM512_MASK_RSQRT28_PS;
                case "_MM512_MASK_RSQRT28_ROUND_PD": return Intrinsic._MM512_MASK_RSQRT28_ROUND_PD;
                case "_MM512_MASK_RSQRT28_ROUND_PS": return Intrinsic._MM512_MASK_RSQRT28_ROUND_PS;
                case "_MM512_MASK_SBB_EPI32": return Intrinsic._MM512_MASK_SBB_EPI32;
                case "_MM512_MASK_SBBR_EPI32": return Intrinsic._MM512_MASK_SBBR_EPI32;
                case "_MM512_MASK_SCALE_PS": return Intrinsic._MM512_MASK_SCALE_PS;
                case "_MM512_MASK_SCALE_ROUND_PS": return Intrinsic._MM512_MASK_SCALE_ROUND_PS;
                case "_MM512_MASK_SCALEF_PD": return Intrinsic._MM512_MASK_SCALEF_PD;
                case "_MM512_MASK_SCALEF_PS": return Intrinsic._MM512_MASK_SCALEF_PS;
                case "_MM512_MASK_SCALEF_ROUND_PD": return Intrinsic._MM512_MASK_SCALEF_ROUND_PD;
                case "_MM512_MASK_SCALEF_ROUND_PS": return Intrinsic._MM512_MASK_SCALEF_ROUND_PS;
                case "_MM512_MASK_SET1_EPI16": return Intrinsic._MM512_MASK_SET1_EPI16;
                case "_MM512_MASK_SET1_EPI32": return Intrinsic._MM512_MASK_SET1_EPI32;
                case "_MM512_MASK_SET1_EPI64": return Intrinsic._MM512_MASK_SET1_EPI64;
                case "_MM512_MASK_SET1_EPI8": return Intrinsic._MM512_MASK_SET1_EPI8;
                case "_MM512_MASK_SHUFFLE_EPI32": return Intrinsic._MM512_MASK_SHUFFLE_EPI32;
                case "_MM512_MASK_SHUFFLE_EPI8": return Intrinsic._MM512_MASK_SHUFFLE_EPI8;
                case "_MM512_MASK_SHUFFLE_F32X4": return Intrinsic._MM512_MASK_SHUFFLE_F32X4;
                case "_MM512_MASK_SHUFFLE_F64X2": return Intrinsic._MM512_MASK_SHUFFLE_F64X2;
                case "_MM512_MASK_SHUFFLE_I32X4": return Intrinsic._MM512_MASK_SHUFFLE_I32X4;
                case "_MM512_MASK_SHUFFLE_I64X2": return Intrinsic._MM512_MASK_SHUFFLE_I64X2;
                case "_MM512_MASK_SHUFFLE_PD": return Intrinsic._MM512_MASK_SHUFFLE_PD;
                case "_MM512_MASK_SHUFFLE_PS": return Intrinsic._MM512_MASK_SHUFFLE_PS;
                case "_MM512_MASK_SHUFFLEHI_EPI16": return Intrinsic._MM512_MASK_SHUFFLEHI_EPI16;
                case "_MM512_MASK_SHUFFLELO_EPI16": return Intrinsic._MM512_MASK_SHUFFLELO_EPI16;
                case "_MM512_MASK_SIN_PD": return Intrinsic._MM512_MASK_SIN_PD;
                case "_MM512_MASK_SIN_PS": return Intrinsic._MM512_MASK_SIN_PS;
                case "_MM512_MASK_SINCOS_PD": return Intrinsic._MM512_MASK_SINCOS_PD;
                case "_MM512_MASK_SINCOS_PS": return Intrinsic._MM512_MASK_SINCOS_PS;
                case "_MM512_MASK_SIND_PD": return Intrinsic._MM512_MASK_SIND_PD;
                case "_MM512_MASK_SIND_PS": return Intrinsic._MM512_MASK_SIND_PS;
                case "_MM512_MASK_SINH_PD": return Intrinsic._MM512_MASK_SINH_PD;
                case "_MM512_MASK_SINH_PS": return Intrinsic._MM512_MASK_SINH_PS;
                case "_MM512_MASK_SLL_EPI16": return Intrinsic._MM512_MASK_SLL_EPI16;
                case "_MM512_MASK_SLL_EPI32": return Intrinsic._MM512_MASK_SLL_EPI32;
                case "_MM512_MASK_SLL_EPI64": return Intrinsic._MM512_MASK_SLL_EPI64;
                case "_MM512_MASK_SLLI_EPI16": return Intrinsic._MM512_MASK_SLLI_EPI16;
                case "_MM512_MASK_SLLI_EPI32": return Intrinsic._MM512_MASK_SLLI_EPI32;
                case "_MM512_MASK_SLLI_EPI64": return Intrinsic._MM512_MASK_SLLI_EPI64;
                case "_MM512_MASK_SLLV_EPI16": return Intrinsic._MM512_MASK_SLLV_EPI16;
                case "_MM512_MASK_SLLV_EPI32": return Intrinsic._MM512_MASK_SLLV_EPI32;
                case "_MM512_MASK_SLLV_EPI64": return Intrinsic._MM512_MASK_SLLV_EPI64;
                case "_MM512_MASK_SQRT_PD": return Intrinsic._MM512_MASK_SQRT_PD;
                case "_MM512_MASK_SQRT_PS": return Intrinsic._MM512_MASK_SQRT_PS;
                case "_MM512_MASK_SQRT_ROUND_PD": return Intrinsic._MM512_MASK_SQRT_ROUND_PD;
                case "_MM512_MASK_SQRT_ROUND_PS": return Intrinsic._MM512_MASK_SQRT_ROUND_PS;
                case "_MM512_MASK_SRA_EPI16": return Intrinsic._MM512_MASK_SRA_EPI16;
                case "_MM512_MASK_SRA_EPI32": return Intrinsic._MM512_MASK_SRA_EPI32;
                case "_MM512_MASK_SRA_EPI64": return Intrinsic._MM512_MASK_SRA_EPI64;
                case "_MM512_MASK_SRAI_EPI16": return Intrinsic._MM512_MASK_SRAI_EPI16;
                case "_MM512_MASK_SRAI_EPI32": return Intrinsic._MM512_MASK_SRAI_EPI32;
                case "_MM512_MASK_SRAI_EPI64": return Intrinsic._MM512_MASK_SRAI_EPI64;
                case "_MM512_MASK_SRAV_EPI16": return Intrinsic._MM512_MASK_SRAV_EPI16;
                case "_MM512_MASK_SRAV_EPI32": return Intrinsic._MM512_MASK_SRAV_EPI32;
                case "_MM512_MASK_SRAV_EPI64": return Intrinsic._MM512_MASK_SRAV_EPI64;
                case "_MM512_MASK_SRL_EPI16": return Intrinsic._MM512_MASK_SRL_EPI16;
                case "_MM512_MASK_SRL_EPI32": return Intrinsic._MM512_MASK_SRL_EPI32;
                case "_MM512_MASK_SRL_EPI64": return Intrinsic._MM512_MASK_SRL_EPI64;
                case "_MM512_MASK_SRLI_EPI16": return Intrinsic._MM512_MASK_SRLI_EPI16;
                case "_MM512_MASK_SRLI_EPI32": return Intrinsic._MM512_MASK_SRLI_EPI32;
                case "_MM512_MASK_SRLI_EPI64": return Intrinsic._MM512_MASK_SRLI_EPI64;
                case "_MM512_MASK_SRLV_EPI16": return Intrinsic._MM512_MASK_SRLV_EPI16;
                case "_MM512_MASK_SRLV_EPI32": return Intrinsic._MM512_MASK_SRLV_EPI32;
                case "_MM512_MASK_SRLV_EPI64": return Intrinsic._MM512_MASK_SRLV_EPI64;
                case "_MM512_MASK_STORE_EPI32": return Intrinsic._MM512_MASK_STORE_EPI32;
                case "_MM512_MASK_STORE_EPI64": return Intrinsic._MM512_MASK_STORE_EPI64;
                case "_MM512_MASK_STORE_PD": return Intrinsic._MM512_MASK_STORE_PD;
                case "_MM512_MASK_STORE_PS": return Intrinsic._MM512_MASK_STORE_PS;
                case "_MM512_MASK_STOREU_EPI16": return Intrinsic._MM512_MASK_STOREU_EPI16;
                case "_MM512_MASK_STOREU_EPI32": return Intrinsic._MM512_MASK_STOREU_EPI32;
                case "_MM512_MASK_STOREU_EPI64": return Intrinsic._MM512_MASK_STOREU_EPI64;
                case "_MM512_MASK_STOREU_EPI8": return Intrinsic._MM512_MASK_STOREU_EPI8;
                case "_MM512_MASK_STOREU_PD": return Intrinsic._MM512_MASK_STOREU_PD;
                case "_MM512_MASK_STOREU_PS": return Intrinsic._MM512_MASK_STOREU_PS;
                case "_MM512_MASK_SUB_EPI16": return Intrinsic._MM512_MASK_SUB_EPI16;
                case "_MM512_MASK_SUB_EPI32": return Intrinsic._MM512_MASK_SUB_EPI32;
                case "_MM512_MASK_SUB_EPI64": return Intrinsic._MM512_MASK_SUB_EPI64;
                case "_MM512_MASK_SUB_EPI8": return Intrinsic._MM512_MASK_SUB_EPI8;
                case "_MM512_MASK_SUB_PD": return Intrinsic._MM512_MASK_SUB_PD;
                case "_MM512_MASK_SUB_PS": return Intrinsic._MM512_MASK_SUB_PS;
                case "_MM512_MASK_SUB_ROUND_PD": return Intrinsic._MM512_MASK_SUB_ROUND_PD;
                case "_MM512_MASK_SUB_ROUND_PS": return Intrinsic._MM512_MASK_SUB_ROUND_PS;
                case "_MM512_MASK_SUBR_EPI32": return Intrinsic._MM512_MASK_SUBR_EPI32;
                case "_MM512_MASK_SUBR_PD": return Intrinsic._MM512_MASK_SUBR_PD;
                case "_MM512_MASK_SUBR_PS": return Intrinsic._MM512_MASK_SUBR_PS;
                case "_MM512_MASK_SUBR_ROUND_PD": return Intrinsic._MM512_MASK_SUBR_ROUND_PD;
                case "_MM512_MASK_SUBR_ROUND_PS": return Intrinsic._MM512_MASK_SUBR_ROUND_PS;
                case "_MM512_MASK_SUBRSETB_EPI32": return Intrinsic._MM512_MASK_SUBRSETB_EPI32;
                case "_MM512_MASK_SUBS_EPI16": return Intrinsic._MM512_MASK_SUBS_EPI16;
                case "_MM512_MASK_SUBS_EPI8": return Intrinsic._MM512_MASK_SUBS_EPI8;
                case "_MM512_MASK_SUBS_EPU16": return Intrinsic._MM512_MASK_SUBS_EPU16;
                case "_MM512_MASK_SUBS_EPU8": return Intrinsic._MM512_MASK_SUBS_EPU8;
                case "_MM512_MASK_SUBSETB_EPI32": return Intrinsic._MM512_MASK_SUBSETB_EPI32;
                case "_MM512_MASK_SVML_ROUND_PD": return Intrinsic._MM512_MASK_SVML_ROUND_PD;
                case "_MM512_MASK_SWIZZLE_EPI32": return Intrinsic._MM512_MASK_SWIZZLE_EPI32;
                case "_MM512_MASK_SWIZZLE_EPI64": return Intrinsic._MM512_MASK_SWIZZLE_EPI64;
                case "_MM512_MASK_SWIZZLE_PD": return Intrinsic._MM512_MASK_SWIZZLE_PD;
                case "_MM512_MASK_SWIZZLE_PS": return Intrinsic._MM512_MASK_SWIZZLE_PS;
                case "_MM512_MASK_TAN_PD": return Intrinsic._MM512_MASK_TAN_PD;
                case "_MM512_MASK_TAN_PS": return Intrinsic._MM512_MASK_TAN_PS;
                case "_MM512_MASK_TAND_PD": return Intrinsic._MM512_MASK_TAND_PD;
                case "_MM512_MASK_TAND_PS": return Intrinsic._MM512_MASK_TAND_PS;
                case "_MM512_MASK_TANH_PD": return Intrinsic._MM512_MASK_TANH_PD;
                case "_MM512_MASK_TANH_PS": return Intrinsic._MM512_MASK_TANH_PS;
                case "_MM512_MASK_TERNARYLOGIC_EPI32": return Intrinsic._MM512_MASK_TERNARYLOGIC_EPI32;
                case "_MM512_MASK_TERNARYLOGIC_EPI64": return Intrinsic._MM512_MASK_TERNARYLOGIC_EPI64;
                case "_MM512_MASK_TEST_EPI16_MASK": return Intrinsic._MM512_MASK_TEST_EPI16_MASK;
                case "_MM512_MASK_TEST_EPI32_MASK": return Intrinsic._MM512_MASK_TEST_EPI32_MASK;
                case "_MM512_MASK_TEST_EPI64_MASK": return Intrinsic._MM512_MASK_TEST_EPI64_MASK;
                case "_MM512_MASK_TEST_EPI8_MASK": return Intrinsic._MM512_MASK_TEST_EPI8_MASK;
                case "_MM512_MASK_TESTN_EPI16_MASK": return Intrinsic._MM512_MASK_TESTN_EPI16_MASK;
                case "_MM512_MASK_TESTN_EPI32_MASK": return Intrinsic._MM512_MASK_TESTN_EPI32_MASK;
                case "_MM512_MASK_TESTN_EPI64_MASK": return Intrinsic._MM512_MASK_TESTN_EPI64_MASK;
                case "_MM512_MASK_TESTN_EPI8_MASK": return Intrinsic._MM512_MASK_TESTN_EPI8_MASK;
                case "_MM512_MASK_TRUNC_PD": return Intrinsic._MM512_MASK_TRUNC_PD;
                case "_MM512_MASK_TRUNC_PS": return Intrinsic._MM512_MASK_TRUNC_PS;
                case "_MM512_MASK_UNPACKHI_EPI16": return Intrinsic._MM512_MASK_UNPACKHI_EPI16;
                case "_MM512_MASK_UNPACKHI_EPI32": return Intrinsic._MM512_MASK_UNPACKHI_EPI32;
                case "_MM512_MASK_UNPACKHI_EPI64": return Intrinsic._MM512_MASK_UNPACKHI_EPI64;
                case "_MM512_MASK_UNPACKHI_EPI8": return Intrinsic._MM512_MASK_UNPACKHI_EPI8;
                case "_MM512_MASK_UNPACKHI_PD": return Intrinsic._MM512_MASK_UNPACKHI_PD;
                case "_MM512_MASK_UNPACKHI_PS": return Intrinsic._MM512_MASK_UNPACKHI_PS;
                case "_MM512_MASK_UNPACKLO_EPI16": return Intrinsic._MM512_MASK_UNPACKLO_EPI16;
                case "_MM512_MASK_UNPACKLO_EPI32": return Intrinsic._MM512_MASK_UNPACKLO_EPI32;
                case "_MM512_MASK_UNPACKLO_EPI64": return Intrinsic._MM512_MASK_UNPACKLO_EPI64;
                case "_MM512_MASK_UNPACKLO_EPI8": return Intrinsic._MM512_MASK_UNPACKLO_EPI8;
                case "_MM512_MASK_UNPACKLO_PD": return Intrinsic._MM512_MASK_UNPACKLO_PD;
                case "_MM512_MASK_UNPACKLO_PS": return Intrinsic._MM512_MASK_UNPACKLO_PS;
                case "_MM512_MASK_XOR_EPI32": return Intrinsic._MM512_MASK_XOR_EPI32;
                case "_MM512_MASK_XOR_EPI64": return Intrinsic._MM512_MASK_XOR_EPI64;
                case "_MM512_MASK_XOR_PD": return Intrinsic._MM512_MASK_XOR_PD;
                case "_MM512_MASK_XOR_PS": return Intrinsic._MM512_MASK_XOR_PS;
                case "_MM512_MASK2_PERMUTEX2VAR_EPI16": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_EPI16;
                case "_MM512_MASK2_PERMUTEX2VAR_EPI32": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_EPI32;
                case "_MM512_MASK2_PERMUTEX2VAR_EPI64": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_EPI64;
                case "_MM512_MASK2_PERMUTEX2VAR_EPI8": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_EPI8;
                case "_MM512_MASK2_PERMUTEX2VAR_PD": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_PD;
                case "_MM512_MASK2_PERMUTEX2VAR_PS": return Intrinsic._MM512_MASK2_PERMUTEX2VAR_PS;
                case "_MM512_MASK2INT": return Intrinsic._MM512_MASK2INT;
                case "_MM512_MASK3_FMADD_EPI32": return Intrinsic._MM512_MASK3_FMADD_EPI32;
                case "_MM512_MASK3_FMADD_PD": return Intrinsic._MM512_MASK3_FMADD_PD;
                case "_MM512_MASK3_FMADD_PS": return Intrinsic._MM512_MASK3_FMADD_PS;
                case "_MM512_MASK3_FMADD_ROUND_PD": return Intrinsic._MM512_MASK3_FMADD_ROUND_PD;
                case "_MM512_MASK3_FMADD_ROUND_PS": return Intrinsic._MM512_MASK3_FMADD_ROUND_PS;
                case "_MM512_MASK3_FMADDSUB_PD": return Intrinsic._MM512_MASK3_FMADDSUB_PD;
                case "_MM512_MASK3_FMADDSUB_PS": return Intrinsic._MM512_MASK3_FMADDSUB_PS;
                case "_MM512_MASK3_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FMADDSUB_ROUND_PD;
                case "_MM512_MASK3_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FMADDSUB_ROUND_PS;
                case "_MM512_MASK3_FMSUB_PD": return Intrinsic._MM512_MASK3_FMSUB_PD;
                case "_MM512_MASK3_FMSUB_PS": return Intrinsic._MM512_MASK3_FMSUB_PS;
                case "_MM512_MASK3_FMSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FMSUB_ROUND_PD;
                case "_MM512_MASK3_FMSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FMSUB_ROUND_PS;
                case "_MM512_MASK3_FMSUBADD_PD": return Intrinsic._MM512_MASK3_FMSUBADD_PD;
                case "_MM512_MASK3_FMSUBADD_PS": return Intrinsic._MM512_MASK3_FMSUBADD_PS;
                case "_MM512_MASK3_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASK3_FMSUBADD_ROUND_PD;
                case "_MM512_MASK3_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASK3_FMSUBADD_ROUND_PS;
                case "_MM512_MASK3_FNMADD_PD": return Intrinsic._MM512_MASK3_FNMADD_PD;
                case "_MM512_MASK3_FNMADD_PS": return Intrinsic._MM512_MASK3_FNMADD_PS;
                case "_MM512_MASK3_FNMADD_ROUND_PD": return Intrinsic._MM512_MASK3_FNMADD_ROUND_PD;
                case "_MM512_MASK3_FNMADD_ROUND_PS": return Intrinsic._MM512_MASK3_FNMADD_ROUND_PS;
                case "_MM512_MASK3_FNMSUB_PD": return Intrinsic._MM512_MASK3_FNMSUB_PD;
                case "_MM512_MASK3_FNMSUB_PS": return Intrinsic._MM512_MASK3_FNMSUB_PS;
                case "_MM512_MASK3_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASK3_FNMSUB_ROUND_PD;
                case "_MM512_MASK3_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASK3_FNMSUB_ROUND_PS;
                case "_MM512_MASKZ_ABS_EPI16": return Intrinsic._MM512_MASKZ_ABS_EPI16;
                case "_MM512_MASKZ_ABS_EPI32": return Intrinsic._MM512_MASKZ_ABS_EPI32;
                case "_MM512_MASKZ_ABS_EPI64": return Intrinsic._MM512_MASKZ_ABS_EPI64;
                case "_MM512_MASKZ_ABS_EPI8": return Intrinsic._MM512_MASKZ_ABS_EPI8;
                case "_MM512_MASKZ_ADD_EPI16": return Intrinsic._MM512_MASKZ_ADD_EPI16;
                case "_MM512_MASKZ_ADD_EPI32": return Intrinsic._MM512_MASKZ_ADD_EPI32;
                case "_MM512_MASKZ_ADD_EPI64": return Intrinsic._MM512_MASKZ_ADD_EPI64;
                case "_MM512_MASKZ_ADD_EPI8": return Intrinsic._MM512_MASKZ_ADD_EPI8;
                case "_MM512_MASKZ_ADD_PD": return Intrinsic._MM512_MASKZ_ADD_PD;
                case "_MM512_MASKZ_ADD_PS": return Intrinsic._MM512_MASKZ_ADD_PS;
                case "_MM512_MASKZ_ADD_ROUND_PD": return Intrinsic._MM512_MASKZ_ADD_ROUND_PD;
                case "_MM512_MASKZ_ADD_ROUND_PS": return Intrinsic._MM512_MASKZ_ADD_ROUND_PS;
                case "_MM512_MASKZ_ADDS_EPI16": return Intrinsic._MM512_MASKZ_ADDS_EPI16;
                case "_MM512_MASKZ_ADDS_EPI8": return Intrinsic._MM512_MASKZ_ADDS_EPI8;
                case "_MM512_MASKZ_ADDS_EPU16": return Intrinsic._MM512_MASKZ_ADDS_EPU16;
                case "_MM512_MASKZ_ADDS_EPU8": return Intrinsic._MM512_MASKZ_ADDS_EPU8;
                case "_MM512_MASKZ_ALIGNR_EPI32": return Intrinsic._MM512_MASKZ_ALIGNR_EPI32;
                case "_MM512_MASKZ_ALIGNR_EPI64": return Intrinsic._MM512_MASKZ_ALIGNR_EPI64;
                case "_MM512_MASKZ_ALIGNR_EPI8": return Intrinsic._MM512_MASKZ_ALIGNR_EPI8;
                case "_MM512_MASKZ_AND_EPI32": return Intrinsic._MM512_MASKZ_AND_EPI32;
                case "_MM512_MASKZ_AND_EPI64": return Intrinsic._MM512_MASKZ_AND_EPI64;
                case "_MM512_MASKZ_AND_PD": return Intrinsic._MM512_MASKZ_AND_PD;
                case "_MM512_MASKZ_AND_PS": return Intrinsic._MM512_MASKZ_AND_PS;
                case "_MM512_MASKZ_ANDNOT_EPI32": return Intrinsic._MM512_MASKZ_ANDNOT_EPI32;
                case "_MM512_MASKZ_ANDNOT_EPI64": return Intrinsic._MM512_MASKZ_ANDNOT_EPI64;
                case "_MM512_MASKZ_ANDNOT_PD": return Intrinsic._MM512_MASKZ_ANDNOT_PD;
                case "_MM512_MASKZ_ANDNOT_PS": return Intrinsic._MM512_MASKZ_ANDNOT_PS;
                case "_MM512_MASKZ_AVG_EPU16": return Intrinsic._MM512_MASKZ_AVG_EPU16;
                case "_MM512_MASKZ_AVG_EPU8": return Intrinsic._MM512_MASKZ_AVG_EPU8;
                case "_MM512_MASKZ_BROADCAST_F32X2": return Intrinsic._MM512_MASKZ_BROADCAST_F32X2;
                case "_MM512_MASKZ_BROADCAST_F32X4": return Intrinsic._MM512_MASKZ_BROADCAST_F32X4;
                case "_MM512_MASKZ_BROADCAST_F32X8": return Intrinsic._MM512_MASKZ_BROADCAST_F32X8;
                case "_MM512_MASKZ_BROADCAST_F64X2": return Intrinsic._MM512_MASKZ_BROADCAST_F64X2;
                case "_MM512_MASKZ_BROADCAST_F64X4": return Intrinsic._MM512_MASKZ_BROADCAST_F64X4;
                case "_MM512_MASKZ_BROADCAST_I32X2": return Intrinsic._MM512_MASKZ_BROADCAST_I32X2;
                case "_MM512_MASKZ_BROADCAST_I32X4": return Intrinsic._MM512_MASKZ_BROADCAST_I32X4;
                case "_MM512_MASKZ_BROADCAST_I32X8": return Intrinsic._MM512_MASKZ_BROADCAST_I32X8;
                case "_MM512_MASKZ_BROADCAST_I64X2": return Intrinsic._MM512_MASKZ_BROADCAST_I64X2;
                case "_MM512_MASKZ_BROADCAST_I64X4": return Intrinsic._MM512_MASKZ_BROADCAST_I64X4;
                case "_MM512_MASKZ_BROADCASTB_EPI8": return Intrinsic._MM512_MASKZ_BROADCASTB_EPI8;
                case "_MM512_MASKZ_BROADCASTD_EPI32": return Intrinsic._MM512_MASKZ_BROADCASTD_EPI32;
                case "_MM512_MASKZ_BROADCASTQ_EPI64": return Intrinsic._MM512_MASKZ_BROADCASTQ_EPI64;
                case "_MM512_MASKZ_BROADCASTSD_PD": return Intrinsic._MM512_MASKZ_BROADCASTSD_PD;
                case "_MM512_MASKZ_BROADCASTSS_PS": return Intrinsic._MM512_MASKZ_BROADCASTSS_PS;
                case "_MM512_MASKZ_BROADCASTW_EPI16": return Intrinsic._MM512_MASKZ_BROADCASTW_EPI16;
                case "_MM512_MASKZ_COMPRESS_EPI32": return Intrinsic._MM512_MASKZ_COMPRESS_EPI32;
                case "_MM512_MASKZ_COMPRESS_EPI64": return Intrinsic._MM512_MASKZ_COMPRESS_EPI64;
                case "_MM512_MASKZ_COMPRESS_PD": return Intrinsic._MM512_MASKZ_COMPRESS_PD;
                case "_MM512_MASKZ_COMPRESS_PS": return Intrinsic._MM512_MASKZ_COMPRESS_PS;
                case "_MM512_MASKZ_CONFLICT_EPI32": return Intrinsic._MM512_MASKZ_CONFLICT_EPI32;
                case "_MM512_MASKZ_CONFLICT_EPI64": return Intrinsic._MM512_MASKZ_CONFLICT_EPI64;
                case "_MM512_MASKZ_CVT_ROUNDEPI32_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI32_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPI64_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI64_PD;
                case "_MM512_MASKZ_CVT_ROUNDEPI64_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPI64_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPU32_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU32_PS;
                case "_MM512_MASKZ_CVT_ROUNDEPU64_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU64_PD;
                case "_MM512_MASKZ_CVT_ROUNDEPU64_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDEPU64_PS;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPI32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPI32;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPI64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPI64;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPU32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPU32;
                case "_MM512_MASKZ_CVT_ROUNDPD_EPU64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_EPU64;
                case "_MM512_MASKZ_CVT_ROUNDPD_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDPD_PS;
                case "_MM512_MASKZ_CVT_ROUNDPH_PS": return Intrinsic._MM512_MASKZ_CVT_ROUNDPH_PS;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPI32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPI32;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPI64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPI64;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPU32": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPU32;
                case "_MM512_MASKZ_CVT_ROUNDPS_EPU64": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_EPU64;
                case "_MM512_MASKZ_CVT_ROUNDPS_PD": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_PD;
                case "_MM512_MASKZ_CVT_ROUNDPS_PH": return Intrinsic._MM512_MASKZ_CVT_ROUNDPS_PH;
                case "_MM512_MASKZ_CVTEPI16_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI32;
                case "_MM512_MASKZ_CVTEPI16_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI64;
                case "_MM512_MASKZ_CVTEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI16_EPI8;
                case "_MM512_MASKZ_CVTEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI16;
                case "_MM512_MASKZ_CVTEPI32_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI64;
                case "_MM512_MASKZ_CVTEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI32_EPI8;
                case "_MM512_MASKZ_CVTEPI32_PD": return Intrinsic._MM512_MASKZ_CVTEPI32_PD;
                case "_MM512_MASKZ_CVTEPI32_PS": return Intrinsic._MM512_MASKZ_CVTEPI32_PS;
                case "_MM512_MASKZ_CVTEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI16;
                case "_MM512_MASKZ_CVTEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI32;
                case "_MM512_MASKZ_CVTEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTEPI64_EPI8;
                case "_MM512_MASKZ_CVTEPI64_PD": return Intrinsic._MM512_MASKZ_CVTEPI64_PD;
                case "_MM512_MASKZ_CVTEPI64_PS": return Intrinsic._MM512_MASKZ_CVTEPI64_PS;
                case "_MM512_MASKZ_CVTEPI8_EPI16": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI16;
                case "_MM512_MASKZ_CVTEPI8_EPI32": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI32;
                case "_MM512_MASKZ_CVTEPI8_EPI64": return Intrinsic._MM512_MASKZ_CVTEPI8_EPI64;
                case "_MM512_MASKZ_CVTEPU16_EPI32": return Intrinsic._MM512_MASKZ_CVTEPU16_EPI32;
                case "_MM512_MASKZ_CVTEPU16_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU16_EPI64;
                case "_MM512_MASKZ_CVTEPU32_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU32_EPI64;
                case "_MM512_MASKZ_CVTEPU32_PD": return Intrinsic._MM512_MASKZ_CVTEPU32_PD;
                case "_MM512_MASKZ_CVTEPU32_PS": return Intrinsic._MM512_MASKZ_CVTEPU32_PS;
                case "_MM512_MASKZ_CVTEPU64_PD": return Intrinsic._MM512_MASKZ_CVTEPU64_PD;
                case "_MM512_MASKZ_CVTEPU64_PS": return Intrinsic._MM512_MASKZ_CVTEPU64_PS;
                case "_MM512_MASKZ_CVTEPU8_EPI16": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI16;
                case "_MM512_MASKZ_CVTEPU8_EPI32": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI32;
                case "_MM512_MASKZ_CVTEPU8_EPI64": return Intrinsic._MM512_MASKZ_CVTEPU8_EPI64;
                case "_MM512_MASKZ_CVTPD_EPI32": return Intrinsic._MM512_MASKZ_CVTPD_EPI32;
                case "_MM512_MASKZ_CVTPD_EPI64": return Intrinsic._MM512_MASKZ_CVTPD_EPI64;
                case "_MM512_MASKZ_CVTPD_EPU32": return Intrinsic._MM512_MASKZ_CVTPD_EPU32;
                case "_MM512_MASKZ_CVTPD_EPU64": return Intrinsic._MM512_MASKZ_CVTPD_EPU64;
                case "_MM512_MASKZ_CVTPD_PS": return Intrinsic._MM512_MASKZ_CVTPD_PS;
                case "_MM512_MASKZ_CVTPH_PS": return Intrinsic._MM512_MASKZ_CVTPH_PS;
                case "_MM512_MASKZ_CVTPS_EPI32": return Intrinsic._MM512_MASKZ_CVTPS_EPI32;
                case "_MM512_MASKZ_CVTPS_EPI64": return Intrinsic._MM512_MASKZ_CVTPS_EPI64;
                case "_MM512_MASKZ_CVTPS_EPU32": return Intrinsic._MM512_MASKZ_CVTPS_EPU32;
                case "_MM512_MASKZ_CVTPS_EPU64": return Intrinsic._MM512_MASKZ_CVTPS_EPU64;
                case "_MM512_MASKZ_CVTPS_PD": return Intrinsic._MM512_MASKZ_CVTPS_PD;
                case "_MM512_MASKZ_CVTPS_PH": return Intrinsic._MM512_MASKZ_CVTPS_PH;
                case "_MM512_MASKZ_CVTSEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI16_EPI8;
                case "_MM512_MASKZ_CVTSEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTSEPI32_EPI16;
                case "_MM512_MASKZ_CVTSEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI32_EPI8;
                case "_MM512_MASKZ_CVTSEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI16;
                case "_MM512_MASKZ_CVTSEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI32;
                case "_MM512_MASKZ_CVTSEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTSEPI64_EPI8;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPI32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPI32;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPI64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPI64;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPU32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPU32;
                case "_MM512_MASKZ_CVTT_ROUNDPD_EPU64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPD_EPU64;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPI32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPI32;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPI64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPI64;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPU32": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPU32;
                case "_MM512_MASKZ_CVTT_ROUNDPS_EPU64": return Intrinsic._MM512_MASKZ_CVTT_ROUNDPS_EPU64;
                case "_MM512_MASKZ_CVTTPD_EPI32": return Intrinsic._MM512_MASKZ_CVTTPD_EPI32;
                case "_MM512_MASKZ_CVTTPD_EPI64": return Intrinsic._MM512_MASKZ_CVTTPD_EPI64;
                case "_MM512_MASKZ_CVTTPD_EPU32": return Intrinsic._MM512_MASKZ_CVTTPD_EPU32;
                case "_MM512_MASKZ_CVTTPD_EPU64": return Intrinsic._MM512_MASKZ_CVTTPD_EPU64;
                case "_MM512_MASKZ_CVTTPS_EPI32": return Intrinsic._MM512_MASKZ_CVTTPS_EPI32;
                case "_MM512_MASKZ_CVTTPS_EPI64": return Intrinsic._MM512_MASKZ_CVTTPS_EPI64;
                case "_MM512_MASKZ_CVTTPS_EPU32": return Intrinsic._MM512_MASKZ_CVTTPS_EPU32;
                case "_MM512_MASKZ_CVTTPS_EPU64": return Intrinsic._MM512_MASKZ_CVTTPS_EPU64;
                case "_MM512_MASKZ_CVTUSEPI16_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI16_EPI8;
                case "_MM512_MASKZ_CVTUSEPI32_EPI16": return Intrinsic._MM512_MASKZ_CVTUSEPI32_EPI16;
                case "_MM512_MASKZ_CVTUSEPI32_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI32_EPI8;
                case "_MM512_MASKZ_CVTUSEPI64_EPI16": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI16;
                case "_MM512_MASKZ_CVTUSEPI64_EPI32": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI32;
                case "_MM512_MASKZ_CVTUSEPI64_EPI8": return Intrinsic._MM512_MASKZ_CVTUSEPI64_EPI8;
                case "_MM512_MASKZ_DBSAD_EPU8": return Intrinsic._MM512_MASKZ_DBSAD_EPU8;
                case "_MM512_MASKZ_DIV_PD": return Intrinsic._MM512_MASKZ_DIV_PD;
                case "_MM512_MASKZ_DIV_PS": return Intrinsic._MM512_MASKZ_DIV_PS;
                case "_MM512_MASKZ_DIV_ROUND_PD": return Intrinsic._MM512_MASKZ_DIV_ROUND_PD;
                case "_MM512_MASKZ_DIV_ROUND_PS": return Intrinsic._MM512_MASKZ_DIV_ROUND_PS;
                case "_MM512_MASKZ_EXP2A23_PD": return Intrinsic._MM512_MASKZ_EXP2A23_PD;
                case "_MM512_MASKZ_EXP2A23_PS": return Intrinsic._MM512_MASKZ_EXP2A23_PS;
                case "_MM512_MASKZ_EXP2A23_ROUND_PD": return Intrinsic._MM512_MASKZ_EXP2A23_ROUND_PD;
                case "_MM512_MASKZ_EXP2A23_ROUND_PS": return Intrinsic._MM512_MASKZ_EXP2A23_ROUND_PS;
                case "_MM512_MASKZ_EXPAND_EPI32": return Intrinsic._MM512_MASKZ_EXPAND_EPI32;
                case "_MM512_MASKZ_EXPAND_EPI64": return Intrinsic._MM512_MASKZ_EXPAND_EPI64;
                case "_MM512_MASKZ_EXPAND_PD": return Intrinsic._MM512_MASKZ_EXPAND_PD;
                case "_MM512_MASKZ_EXPAND_PS": return Intrinsic._MM512_MASKZ_EXPAND_PS;
                case "_MM512_MASKZ_EXPANDLOADU_EPI32": return Intrinsic._MM512_MASKZ_EXPANDLOADU_EPI32;
                case "_MM512_MASKZ_EXPANDLOADU_EPI64": return Intrinsic._MM512_MASKZ_EXPANDLOADU_EPI64;
                case "_MM512_MASKZ_EXPANDLOADU_PD": return Intrinsic._MM512_MASKZ_EXPANDLOADU_PD;
                case "_MM512_MASKZ_EXPANDLOADU_PS": return Intrinsic._MM512_MASKZ_EXPANDLOADU_PS;
                case "_MM512_MASKZ_EXTRACTF32X4_PS": return Intrinsic._MM512_MASKZ_EXTRACTF32X4_PS;
                case "_MM512_MASKZ_EXTRACTF32X8_PS": return Intrinsic._MM512_MASKZ_EXTRACTF32X8_PS;
                case "_MM512_MASKZ_EXTRACTF64X2_PD": return Intrinsic._MM512_MASKZ_EXTRACTF64X2_PD;
                case "_MM512_MASKZ_EXTRACTF64X4_PD": return Intrinsic._MM512_MASKZ_EXTRACTF64X4_PD;
                case "_MM512_MASKZ_EXTRACTI32X4_EPI32": return Intrinsic._MM512_MASKZ_EXTRACTI32X4_EPI32;
                case "_MM512_MASKZ_EXTRACTI32X8_EPI32": return Intrinsic._MM512_MASKZ_EXTRACTI32X8_EPI32;
                case "_MM512_MASKZ_EXTRACTI64X2_EPI64": return Intrinsic._MM512_MASKZ_EXTRACTI64X2_EPI64;
                case "_MM512_MASKZ_EXTRACTI64X4_EPI64": return Intrinsic._MM512_MASKZ_EXTRACTI64X4_EPI64;
                case "_MM512_MASKZ_FIXUPIMM_PD": return Intrinsic._MM512_MASKZ_FIXUPIMM_PD;
                case "_MM512_MASKZ_FIXUPIMM_PS": return Intrinsic._MM512_MASKZ_FIXUPIMM_PS;
                case "_MM512_MASKZ_FIXUPIMM_ROUND_PD": return Intrinsic._MM512_MASKZ_FIXUPIMM_ROUND_PD;
                case "_MM512_MASKZ_FIXUPIMM_ROUND_PS": return Intrinsic._MM512_MASKZ_FIXUPIMM_ROUND_PS;
                case "_MM512_MASKZ_FMADD_PD": return Intrinsic._MM512_MASKZ_FMADD_PD;
                case "_MM512_MASKZ_FMADD_PS": return Intrinsic._MM512_MASKZ_FMADD_PS;
                case "_MM512_MASKZ_FMADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FMADD_ROUND_PD;
                case "_MM512_MASKZ_FMADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FMADD_ROUND_PS;
                case "_MM512_MASKZ_FMADDSUB_PD": return Intrinsic._MM512_MASKZ_FMADDSUB_PD;
                case "_MM512_MASKZ_FMADDSUB_PS": return Intrinsic._MM512_MASKZ_FMADDSUB_PS;
                case "_MM512_MASKZ_FMADDSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FMADDSUB_ROUND_PD;
                case "_MM512_MASKZ_FMADDSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FMADDSUB_ROUND_PS;
                case "_MM512_MASKZ_FMSUB_PD": return Intrinsic._MM512_MASKZ_FMSUB_PD;
                case "_MM512_MASKZ_FMSUB_PS": return Intrinsic._MM512_MASKZ_FMSUB_PS;
                case "_MM512_MASKZ_FMSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FMSUB_ROUND_PD;
                case "_MM512_MASKZ_FMSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FMSUB_ROUND_PS;
                case "_MM512_MASKZ_FMSUBADD_PD": return Intrinsic._MM512_MASKZ_FMSUBADD_PD;
                case "_MM512_MASKZ_FMSUBADD_PS": return Intrinsic._MM512_MASKZ_FMSUBADD_PS;
                case "_MM512_MASKZ_FMSUBADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FMSUBADD_ROUND_PD;
                case "_MM512_MASKZ_FMSUBADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FMSUBADD_ROUND_PS;
                case "_MM512_MASKZ_FNMADD_PD": return Intrinsic._MM512_MASKZ_FNMADD_PD;
                case "_MM512_MASKZ_FNMADD_PS": return Intrinsic._MM512_MASKZ_FNMADD_PS;
                case "_MM512_MASKZ_FNMADD_ROUND_PD": return Intrinsic._MM512_MASKZ_FNMADD_ROUND_PD;
                case "_MM512_MASKZ_FNMADD_ROUND_PS": return Intrinsic._MM512_MASKZ_FNMADD_ROUND_PS;
                case "_MM512_MASKZ_FNMSUB_PD": return Intrinsic._MM512_MASKZ_FNMSUB_PD;
                case "_MM512_MASKZ_FNMSUB_PS": return Intrinsic._MM512_MASKZ_FNMSUB_PS;
                case "_MM512_MASKZ_FNMSUB_ROUND_PD": return Intrinsic._MM512_MASKZ_FNMSUB_ROUND_PD;
                case "_MM512_MASKZ_FNMSUB_ROUND_PS": return Intrinsic._MM512_MASKZ_FNMSUB_ROUND_PS;
                case "_MM512_MASKZ_GETEXP_PD": return Intrinsic._MM512_MASKZ_GETEXP_PD;
                case "_MM512_MASKZ_GETEXP_PS": return Intrinsic._MM512_MASKZ_GETEXP_PS;
                case "_MM512_MASKZ_GETEXP_ROUND_PD": return Intrinsic._MM512_MASKZ_GETEXP_ROUND_PD;
                case "_MM512_MASKZ_GETEXP_ROUND_PS": return Intrinsic._MM512_MASKZ_GETEXP_ROUND_PS;
                case "_MM512_MASKZ_GETMANT_PD": return Intrinsic._MM512_MASKZ_GETMANT_PD;
                case "_MM512_MASKZ_GETMANT_PS": return Intrinsic._MM512_MASKZ_GETMANT_PS;
                case "_MM512_MASKZ_GETMANT_ROUND_PD": return Intrinsic._MM512_MASKZ_GETMANT_ROUND_PD;
                case "_MM512_MASKZ_GETMANT_ROUND_PS": return Intrinsic._MM512_MASKZ_GETMANT_ROUND_PS;
                case "_MM512_MASKZ_INSERTF32X4": return Intrinsic._MM512_MASKZ_INSERTF32X4;
                case "_MM512_MASKZ_INSERTF32X8": return Intrinsic._MM512_MASKZ_INSERTF32X8;
                case "_MM512_MASKZ_INSERTF64X2": return Intrinsic._MM512_MASKZ_INSERTF64X2;
                case "_MM512_MASKZ_INSERTF64X4": return Intrinsic._MM512_MASKZ_INSERTF64X4;
                case "_MM512_MASKZ_INSERTI32X4": return Intrinsic._MM512_MASKZ_INSERTI32X4;
                case "_MM512_MASKZ_INSERTI32X8": return Intrinsic._MM512_MASKZ_INSERTI32X8;
                case "_MM512_MASKZ_INSERTI64X2": return Intrinsic._MM512_MASKZ_INSERTI64X2;
                case "_MM512_MASKZ_INSERTI64X4": return Intrinsic._MM512_MASKZ_INSERTI64X4;
                case "_MM512_MASKZ_LOAD_EPI32": return Intrinsic._MM512_MASKZ_LOAD_EPI32;
                case "_MM512_MASKZ_LOAD_EPI64": return Intrinsic._MM512_MASKZ_LOAD_EPI64;
                case "_MM512_MASKZ_LOAD_PD": return Intrinsic._MM512_MASKZ_LOAD_PD;
                case "_MM512_MASKZ_LOAD_PS": return Intrinsic._MM512_MASKZ_LOAD_PS;
                case "_MM512_MASKZ_LOADU_EPI16": return Intrinsic._MM512_MASKZ_LOADU_EPI16;
                case "_MM512_MASKZ_LOADU_EPI32": return Intrinsic._MM512_MASKZ_LOADU_EPI32;
                case "_MM512_MASKZ_LOADU_EPI64": return Intrinsic._MM512_MASKZ_LOADU_EPI64;
                case "_MM512_MASKZ_LOADU_EPI8": return Intrinsic._MM512_MASKZ_LOADU_EPI8;
                case "_MM512_MASKZ_LOADU_PD": return Intrinsic._MM512_MASKZ_LOADU_PD;
                case "_MM512_MASKZ_LOADU_PS": return Intrinsic._MM512_MASKZ_LOADU_PS;
                case "_MM512_MASKZ_LZCNT_EPI32": return Intrinsic._MM512_MASKZ_LZCNT_EPI32;
                case "_MM512_MASKZ_LZCNT_EPI64": return Intrinsic._MM512_MASKZ_LZCNT_EPI64;
                case "_MM512_MASKZ_MADD_EPI16": return Intrinsic._MM512_MASKZ_MADD_EPI16;
                case "_MM512_MASKZ_MADD52HI_EPU64": return Intrinsic._MM512_MASKZ_MADD52HI_EPU64;
                case "_MM512_MASKZ_MADD52LO_EPU64": return Intrinsic._MM512_MASKZ_MADD52LO_EPU64;
                case "_MM512_MASKZ_MADDUBS_EPI16": return Intrinsic._MM512_MASKZ_MADDUBS_EPI16;
                case "_MM512_MASKZ_MAX_EPI16": return Intrinsic._MM512_MASKZ_MAX_EPI16;
                case "_MM512_MASKZ_MAX_EPI32": return Intrinsic._MM512_MASKZ_MAX_EPI32;
                case "_MM512_MASKZ_MAX_EPI64": return Intrinsic._MM512_MASKZ_MAX_EPI64;
                case "_MM512_MASKZ_MAX_EPI8": return Intrinsic._MM512_MASKZ_MAX_EPI8;
                case "_MM512_MASKZ_MAX_EPU16": return Intrinsic._MM512_MASKZ_MAX_EPU16;
                case "_MM512_MASKZ_MAX_EPU32": return Intrinsic._MM512_MASKZ_MAX_EPU32;
                case "_MM512_MASKZ_MAX_EPU64": return Intrinsic._MM512_MASKZ_MAX_EPU64;
                case "_MM512_MASKZ_MAX_EPU8": return Intrinsic._MM512_MASKZ_MAX_EPU8;
                case "_MM512_MASKZ_MAX_PD": return Intrinsic._MM512_MASKZ_MAX_PD;
                case "_MM512_MASKZ_MAX_PS": return Intrinsic._MM512_MASKZ_MAX_PS;
                case "_MM512_MASKZ_MAX_ROUND_PD": return Intrinsic._MM512_MASKZ_MAX_ROUND_PD;
                case "_MM512_MASKZ_MAX_ROUND_PS": return Intrinsic._MM512_MASKZ_MAX_ROUND_PS;
                case "_MM512_MASKZ_MIN_EPI16": return Intrinsic._MM512_MASKZ_MIN_EPI16;
                case "_MM512_MASKZ_MIN_EPI32": return Intrinsic._MM512_MASKZ_MIN_EPI32;
                case "_MM512_MASKZ_MIN_EPI64": return Intrinsic._MM512_MASKZ_MIN_EPI64;
                case "_MM512_MASKZ_MIN_EPI8": return Intrinsic._MM512_MASKZ_MIN_EPI8;
                case "_MM512_MASKZ_MIN_EPU16": return Intrinsic._MM512_MASKZ_MIN_EPU16;
                case "_MM512_MASKZ_MIN_EPU32": return Intrinsic._MM512_MASKZ_MIN_EPU32;
                case "_MM512_MASKZ_MIN_EPU64": return Intrinsic._MM512_MASKZ_MIN_EPU64;
                case "_MM512_MASKZ_MIN_EPU8": return Intrinsic._MM512_MASKZ_MIN_EPU8;
                case "_MM512_MASKZ_MIN_PD": return Intrinsic._MM512_MASKZ_MIN_PD;
                case "_MM512_MASKZ_MIN_PS": return Intrinsic._MM512_MASKZ_MIN_PS;
                case "_MM512_MASKZ_MIN_ROUND_PD": return Intrinsic._MM512_MASKZ_MIN_ROUND_PD;
                case "_MM512_MASKZ_MIN_ROUND_PS": return Intrinsic._MM512_MASKZ_MIN_ROUND_PS;
                case "_MM512_MASKZ_MOV_EPI16": return Intrinsic._MM512_MASKZ_MOV_EPI16;
                case "_MM512_MASKZ_MOV_EPI32": return Intrinsic._MM512_MASKZ_MOV_EPI32;
                case "_MM512_MASKZ_MOV_EPI64": return Intrinsic._MM512_MASKZ_MOV_EPI64;
                case "_MM512_MASKZ_MOV_EPI8": return Intrinsic._MM512_MASKZ_MOV_EPI8;
                case "_MM512_MASKZ_MOV_PD": return Intrinsic._MM512_MASKZ_MOV_PD;
                case "_MM512_MASKZ_MOV_PS": return Intrinsic._MM512_MASKZ_MOV_PS;
                case "_MM512_MASKZ_MOVEDUP_PD": return Intrinsic._MM512_MASKZ_MOVEDUP_PD;
                case "_MM512_MASKZ_MOVEHDUP_PS": return Intrinsic._MM512_MASKZ_MOVEHDUP_PS;
                case "_MM512_MASKZ_MOVELDUP_PS": return Intrinsic._MM512_MASKZ_MOVELDUP_PS;
                case "_MM512_MASKZ_MUL_EPI32": return Intrinsic._MM512_MASKZ_MUL_EPI32;
                case "_MM512_MASKZ_MUL_EPU32": return Intrinsic._MM512_MASKZ_MUL_EPU32;
                case "_MM512_MASKZ_MUL_PD": return Intrinsic._MM512_MASKZ_MUL_PD;
                case "_MM512_MASKZ_MUL_PS": return Intrinsic._MM512_MASKZ_MUL_PS;
                case "_MM512_MASKZ_MUL_ROUND_PD": return Intrinsic._MM512_MASKZ_MUL_ROUND_PD;
                case "_MM512_MASKZ_MUL_ROUND_PS": return Intrinsic._MM512_MASKZ_MUL_ROUND_PS;
                case "_MM512_MASKZ_MULHI_EPI16": return Intrinsic._MM512_MASKZ_MULHI_EPI16;
                case "_MM512_MASKZ_MULHI_EPU16": return Intrinsic._MM512_MASKZ_MULHI_EPU16;
                case "_MM512_MASKZ_MULHRS_EPI16": return Intrinsic._MM512_MASKZ_MULHRS_EPI16;
                case "_MM512_MASKZ_MULLO_EPI16": return Intrinsic._MM512_MASKZ_MULLO_EPI16;
                case "_MM512_MASKZ_MULLO_EPI32": return Intrinsic._MM512_MASKZ_MULLO_EPI32;
                case "_MM512_MASKZ_MULLO_EPI64": return Intrinsic._MM512_MASKZ_MULLO_EPI64;
                case "_MM512_MASKZ_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM512_MASKZ_MULTISHIFT_EPI64_EPI8;
                case "_MM512_MASKZ_OR_EPI32": return Intrinsic._MM512_MASKZ_OR_EPI32;
                case "_MM512_MASKZ_OR_EPI64": return Intrinsic._MM512_MASKZ_OR_EPI64;
                case "_MM512_MASKZ_OR_PD": return Intrinsic._MM512_MASKZ_OR_PD;
                case "_MM512_MASKZ_OR_PS": return Intrinsic._MM512_MASKZ_OR_PS;
                case "_MM512_MASKZ_PACKS_EPI16": return Intrinsic._MM512_MASKZ_PACKS_EPI16;
                case "_MM512_MASKZ_PACKS_EPI32": return Intrinsic._MM512_MASKZ_PACKS_EPI32;
                case "_MM512_MASKZ_PACKUS_EPI16": return Intrinsic._MM512_MASKZ_PACKUS_EPI16;
                case "_MM512_MASKZ_PACKUS_EPI32": return Intrinsic._MM512_MASKZ_PACKUS_EPI32;
                case "_MM512_MASKZ_PERMUTE_PD": return Intrinsic._MM512_MASKZ_PERMUTE_PD;
                case "_MM512_MASKZ_PERMUTE_PS": return Intrinsic._MM512_MASKZ_PERMUTE_PS;
                case "_MM512_MASKZ_PERMUTEVAR_PD": return Intrinsic._MM512_MASKZ_PERMUTEVAR_PD;
                case "_MM512_MASKZ_PERMUTEVAR_PS": return Intrinsic._MM512_MASKZ_PERMUTEVAR_PS;
                case "_MM512_MASKZ_PERMUTEX_EPI64": return Intrinsic._MM512_MASKZ_PERMUTEX_EPI64;
                case "_MM512_MASKZ_PERMUTEX_PD": return Intrinsic._MM512_MASKZ_PERMUTEX_PD;
                case "_MM512_MASKZ_PERMUTEX2VAR_EPI16": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_EPI16;
                case "_MM512_MASKZ_PERMUTEX2VAR_EPI32": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_EPI32;
                case "_MM512_MASKZ_PERMUTEX2VAR_EPI64": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_EPI64;
                case "_MM512_MASKZ_PERMUTEX2VAR_EPI8": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_EPI8;
                case "_MM512_MASKZ_PERMUTEX2VAR_PD": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_PD;
                case "_MM512_MASKZ_PERMUTEX2VAR_PS": return Intrinsic._MM512_MASKZ_PERMUTEX2VAR_PS;
                case "_MM512_MASKZ_PERMUTEXVAR_EPI16": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_EPI16;
                case "_MM512_MASKZ_PERMUTEXVAR_EPI32": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_EPI32;
                case "_MM512_MASKZ_PERMUTEXVAR_EPI64": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_EPI64;
                case "_MM512_MASKZ_PERMUTEXVAR_EPI8": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_EPI8;
                case "_MM512_MASKZ_PERMUTEXVAR_PD": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_PD;
                case "_MM512_MASKZ_PERMUTEXVAR_PS": return Intrinsic._MM512_MASKZ_PERMUTEXVAR_PS;
                case "_MM512_MASKZ_RANGE_PD": return Intrinsic._MM512_MASKZ_RANGE_PD;
                case "_MM512_MASKZ_RANGE_PS": return Intrinsic._MM512_MASKZ_RANGE_PS;
                case "_MM512_MASKZ_RANGE_ROUND_PD": return Intrinsic._MM512_MASKZ_RANGE_ROUND_PD;
                case "_MM512_MASKZ_RANGE_ROUND_PS": return Intrinsic._MM512_MASKZ_RANGE_ROUND_PS;
                case "_MM512_MASKZ_RCP14_PD": return Intrinsic._MM512_MASKZ_RCP14_PD;
                case "_MM512_MASKZ_RCP14_PS": return Intrinsic._MM512_MASKZ_RCP14_PS;
                case "_MM512_MASKZ_RCP28_PD": return Intrinsic._MM512_MASKZ_RCP28_PD;
                case "_MM512_MASKZ_RCP28_PS": return Intrinsic._MM512_MASKZ_RCP28_PS;
                case "_MM512_MASKZ_RCP28_ROUND_PD": return Intrinsic._MM512_MASKZ_RCP28_ROUND_PD;
                case "_MM512_MASKZ_RCP28_ROUND_PS": return Intrinsic._MM512_MASKZ_RCP28_ROUND_PS;
                case "_MM512_MASKZ_REDUCE_PD": return Intrinsic._MM512_MASKZ_REDUCE_PD;
                case "_MM512_MASKZ_REDUCE_PS": return Intrinsic._MM512_MASKZ_REDUCE_PS;
                case "_MM512_MASKZ_REDUCE_ROUND_PD": return Intrinsic._MM512_MASKZ_REDUCE_ROUND_PD;
                case "_MM512_MASKZ_REDUCE_ROUND_PS": return Intrinsic._MM512_MASKZ_REDUCE_ROUND_PS;
                case "_MM512_MASKZ_ROL_EPI32": return Intrinsic._MM512_MASKZ_ROL_EPI32;
                case "_MM512_MASKZ_ROL_EPI64": return Intrinsic._MM512_MASKZ_ROL_EPI64;
                case "_MM512_MASKZ_ROLV_EPI32": return Intrinsic._MM512_MASKZ_ROLV_EPI32;
                case "_MM512_MASKZ_ROLV_EPI64": return Intrinsic._MM512_MASKZ_ROLV_EPI64;
                case "_MM512_MASKZ_ROR_EPI32": return Intrinsic._MM512_MASKZ_ROR_EPI32;
                case "_MM512_MASKZ_ROR_EPI64": return Intrinsic._MM512_MASKZ_ROR_EPI64;
                case "_MM512_MASKZ_RORV_EPI32": return Intrinsic._MM512_MASKZ_RORV_EPI32;
                case "_MM512_MASKZ_RORV_EPI64": return Intrinsic._MM512_MASKZ_RORV_EPI64;
                case "_MM512_MASKZ_ROUNDSCALE_PD": return Intrinsic._MM512_MASKZ_ROUNDSCALE_PD;
                case "_MM512_MASKZ_ROUNDSCALE_PS": return Intrinsic._MM512_MASKZ_ROUNDSCALE_PS;
                case "_MM512_MASKZ_ROUNDSCALE_ROUND_PD": return Intrinsic._MM512_MASKZ_ROUNDSCALE_ROUND_PD;
                case "_MM512_MASKZ_ROUNDSCALE_ROUND_PS": return Intrinsic._MM512_MASKZ_ROUNDSCALE_ROUND_PS;
                case "_MM512_MASKZ_RSQRT14_PD": return Intrinsic._MM512_MASKZ_RSQRT14_PD;
                case "_MM512_MASKZ_RSQRT14_PS": return Intrinsic._MM512_MASKZ_RSQRT14_PS;
                case "_MM512_MASKZ_RSQRT28_PD": return Intrinsic._MM512_MASKZ_RSQRT28_PD;
                case "_MM512_MASKZ_RSQRT28_PS": return Intrinsic._MM512_MASKZ_RSQRT28_PS;
                case "_MM512_MASKZ_RSQRT28_ROUND_PD": return Intrinsic._MM512_MASKZ_RSQRT28_ROUND_PD;
                case "_MM512_MASKZ_RSQRT28_ROUND_PS": return Intrinsic._MM512_MASKZ_RSQRT28_ROUND_PS;
                case "_MM512_MASKZ_SCALEF_PD": return Intrinsic._MM512_MASKZ_SCALEF_PD;
                case "_MM512_MASKZ_SCALEF_PS": return Intrinsic._MM512_MASKZ_SCALEF_PS;
                case "_MM512_MASKZ_SCALEF_ROUND_PD": return Intrinsic._MM512_MASKZ_SCALEF_ROUND_PD;
                case "_MM512_MASKZ_SCALEF_ROUND_PS": return Intrinsic._MM512_MASKZ_SCALEF_ROUND_PS;
                case "_MM512_MASKZ_SET1_EPI16": return Intrinsic._MM512_MASKZ_SET1_EPI16;
                case "_MM512_MASKZ_SET1_EPI32": return Intrinsic._MM512_MASKZ_SET1_EPI32;
                case "_MM512_MASKZ_SET1_EPI64": return Intrinsic._MM512_MASKZ_SET1_EPI64;
                case "_MM512_MASKZ_SET1_EPI8": return Intrinsic._MM512_MASKZ_SET1_EPI8;
                case "_MM512_MASKZ_SHUFFLE_EPI32": return Intrinsic._MM512_MASKZ_SHUFFLE_EPI32;
                case "_MM512_MASKZ_SHUFFLE_EPI8": return Intrinsic._MM512_MASKZ_SHUFFLE_EPI8;
                case "_MM512_MASKZ_SHUFFLE_F32X4": return Intrinsic._MM512_MASKZ_SHUFFLE_F32X4;
                case "_MM512_MASKZ_SHUFFLE_F64X2": return Intrinsic._MM512_MASKZ_SHUFFLE_F64X2;
                case "_MM512_MASKZ_SHUFFLE_I32X4": return Intrinsic._MM512_MASKZ_SHUFFLE_I32X4;
                case "_MM512_MASKZ_SHUFFLE_I64X2": return Intrinsic._MM512_MASKZ_SHUFFLE_I64X2;
                case "_MM512_MASKZ_SHUFFLE_PD": return Intrinsic._MM512_MASKZ_SHUFFLE_PD;
                case "_MM512_MASKZ_SHUFFLE_PS": return Intrinsic._MM512_MASKZ_SHUFFLE_PS;
                case "_MM512_MASKZ_SHUFFLEHI_EPI16": return Intrinsic._MM512_MASKZ_SHUFFLEHI_EPI16;
                case "_MM512_MASKZ_SHUFFLELO_EPI16": return Intrinsic._MM512_MASKZ_SHUFFLELO_EPI16;
                case "_MM512_MASKZ_SLL_EPI16": return Intrinsic._MM512_MASKZ_SLL_EPI16;
                case "_MM512_MASKZ_SLL_EPI32": return Intrinsic._MM512_MASKZ_SLL_EPI32;
                case "_MM512_MASKZ_SLL_EPI64": return Intrinsic._MM512_MASKZ_SLL_EPI64;
                case "_MM512_MASKZ_SLLI_EPI16": return Intrinsic._MM512_MASKZ_SLLI_EPI16;
                case "_MM512_MASKZ_SLLI_EPI32": return Intrinsic._MM512_MASKZ_SLLI_EPI32;
                case "_MM512_MASKZ_SLLI_EPI64": return Intrinsic._MM512_MASKZ_SLLI_EPI64;
                case "_MM512_MASKZ_SLLV_EPI16": return Intrinsic._MM512_MASKZ_SLLV_EPI16;
                case "_MM512_MASKZ_SLLV_EPI32": return Intrinsic._MM512_MASKZ_SLLV_EPI32;
                case "_MM512_MASKZ_SLLV_EPI64": return Intrinsic._MM512_MASKZ_SLLV_EPI64;
                case "_MM512_MASKZ_SQRT_PD": return Intrinsic._MM512_MASKZ_SQRT_PD;
                case "_MM512_MASKZ_SQRT_PS": return Intrinsic._MM512_MASKZ_SQRT_PS;
                case "_MM512_MASKZ_SQRT_ROUND_PD": return Intrinsic._MM512_MASKZ_SQRT_ROUND_PD;
                case "_MM512_MASKZ_SQRT_ROUND_PS": return Intrinsic._MM512_MASKZ_SQRT_ROUND_PS;
                case "_MM512_MASKZ_SRA_EPI16": return Intrinsic._MM512_MASKZ_SRA_EPI16;
                case "_MM512_MASKZ_SRA_EPI32": return Intrinsic._MM512_MASKZ_SRA_EPI32;
                case "_MM512_MASKZ_SRA_EPI64": return Intrinsic._MM512_MASKZ_SRA_EPI64;
                case "_MM512_MASKZ_SRAI_EPI16": return Intrinsic._MM512_MASKZ_SRAI_EPI16;
                case "_MM512_MASKZ_SRAI_EPI32": return Intrinsic._MM512_MASKZ_SRAI_EPI32;
                case "_MM512_MASKZ_SRAI_EPI64": return Intrinsic._MM512_MASKZ_SRAI_EPI64;
                case "_MM512_MASKZ_SRAV_EPI16": return Intrinsic._MM512_MASKZ_SRAV_EPI16;
                case "_MM512_MASKZ_SRAV_EPI32": return Intrinsic._MM512_MASKZ_SRAV_EPI32;
                case "_MM512_MASKZ_SRAV_EPI64": return Intrinsic._MM512_MASKZ_SRAV_EPI64;
                case "_MM512_MASKZ_SRL_EPI16": return Intrinsic._MM512_MASKZ_SRL_EPI16;
                case "_MM512_MASKZ_SRL_EPI32": return Intrinsic._MM512_MASKZ_SRL_EPI32;
                case "_MM512_MASKZ_SRL_EPI64": return Intrinsic._MM512_MASKZ_SRL_EPI64;
                case "_MM512_MASKZ_SRLI_EPI16": return Intrinsic._MM512_MASKZ_SRLI_EPI16;
                case "_MM512_MASKZ_SRLI_EPI32": return Intrinsic._MM512_MASKZ_SRLI_EPI32;
                case "_MM512_MASKZ_SRLI_EPI64": return Intrinsic._MM512_MASKZ_SRLI_EPI64;
                case "_MM512_MASKZ_SRLV_EPI16": return Intrinsic._MM512_MASKZ_SRLV_EPI16;
                case "_MM512_MASKZ_SRLV_EPI32": return Intrinsic._MM512_MASKZ_SRLV_EPI32;
                case "_MM512_MASKZ_SRLV_EPI64": return Intrinsic._MM512_MASKZ_SRLV_EPI64;
                case "_MM512_MASKZ_SUB_EPI16": return Intrinsic._MM512_MASKZ_SUB_EPI16;
                case "_MM512_MASKZ_SUB_EPI32": return Intrinsic._MM512_MASKZ_SUB_EPI32;
                case "_MM512_MASKZ_SUB_EPI64": return Intrinsic._MM512_MASKZ_SUB_EPI64;
                case "_MM512_MASKZ_SUB_EPI8": return Intrinsic._MM512_MASKZ_SUB_EPI8;
                case "_MM512_MASKZ_SUB_PD": return Intrinsic._MM512_MASKZ_SUB_PD;
                case "_MM512_MASKZ_SUB_PS": return Intrinsic._MM512_MASKZ_SUB_PS;
                case "_MM512_MASKZ_SUB_ROUND_PD": return Intrinsic._MM512_MASKZ_SUB_ROUND_PD;
                case "_MM512_MASKZ_SUB_ROUND_PS": return Intrinsic._MM512_MASKZ_SUB_ROUND_PS;
                case "_MM512_MASKZ_SUBS_EPI16": return Intrinsic._MM512_MASKZ_SUBS_EPI16;
                case "_MM512_MASKZ_SUBS_EPI8": return Intrinsic._MM512_MASKZ_SUBS_EPI8;
                case "_MM512_MASKZ_SUBS_EPU16": return Intrinsic._MM512_MASKZ_SUBS_EPU16;
                case "_MM512_MASKZ_SUBS_EPU8": return Intrinsic._MM512_MASKZ_SUBS_EPU8;
                case "_MM512_MASKZ_TERNARYLOGIC_EPI32": return Intrinsic._MM512_MASKZ_TERNARYLOGIC_EPI32;
                case "_MM512_MASKZ_TERNARYLOGIC_EPI64": return Intrinsic._MM512_MASKZ_TERNARYLOGIC_EPI64;
                case "_MM512_MASKZ_UNPACKHI_EPI16": return Intrinsic._MM512_MASKZ_UNPACKHI_EPI16;
                case "_MM512_MASKZ_UNPACKHI_EPI32": return Intrinsic._MM512_MASKZ_UNPACKHI_EPI32;
                case "_MM512_MASKZ_UNPACKHI_EPI64": return Intrinsic._MM512_MASKZ_UNPACKHI_EPI64;
                case "_MM512_MASKZ_UNPACKHI_EPI8": return Intrinsic._MM512_MASKZ_UNPACKHI_EPI8;
                case "_MM512_MASKZ_UNPACKHI_PD": return Intrinsic._MM512_MASKZ_UNPACKHI_PD;
                case "_MM512_MASKZ_UNPACKHI_PS": return Intrinsic._MM512_MASKZ_UNPACKHI_PS;
                case "_MM512_MASKZ_UNPACKLO_EPI16": return Intrinsic._MM512_MASKZ_UNPACKLO_EPI16;
                case "_MM512_MASKZ_UNPACKLO_EPI32": return Intrinsic._MM512_MASKZ_UNPACKLO_EPI32;
                case "_MM512_MASKZ_UNPACKLO_EPI64": return Intrinsic._MM512_MASKZ_UNPACKLO_EPI64;
                case "_MM512_MASKZ_UNPACKLO_EPI8": return Intrinsic._MM512_MASKZ_UNPACKLO_EPI8;
                case "_MM512_MASKZ_UNPACKLO_PD": return Intrinsic._MM512_MASKZ_UNPACKLO_PD;
                case "_MM512_MASKZ_UNPACKLO_PS": return Intrinsic._MM512_MASKZ_UNPACKLO_PS;
                case "_MM512_MASKZ_XOR_EPI32": return Intrinsic._MM512_MASKZ_XOR_EPI32;
                case "_MM512_MASKZ_XOR_EPI64": return Intrinsic._MM512_MASKZ_XOR_EPI64;
                case "_MM512_MASKZ_XOR_PD": return Intrinsic._MM512_MASKZ_XOR_PD;
                case "_MM512_MASKZ_XOR_PS": return Intrinsic._MM512_MASKZ_XOR_PS;
                case "_MM512_MAX_EPI16": return Intrinsic._MM512_MAX_EPI16;
                case "_MM512_MAX_EPI32": return Intrinsic._MM512_MAX_EPI32;
                case "_MM512_MAX_EPI64": return Intrinsic._MM512_MAX_EPI64;
                case "_MM512_MAX_EPI8": return Intrinsic._MM512_MAX_EPI8;
                case "_MM512_MAX_EPU16": return Intrinsic._MM512_MAX_EPU16;
                case "_MM512_MAX_EPU32": return Intrinsic._MM512_MAX_EPU32;
                case "_MM512_MAX_EPU64": return Intrinsic._MM512_MAX_EPU64;
                case "_MM512_MAX_EPU8": return Intrinsic._MM512_MAX_EPU8;
                case "_MM512_MAX_PD": return Intrinsic._MM512_MAX_PD;
                case "_MM512_MAX_PS": return Intrinsic._MM512_MAX_PS;
                case "_MM512_MAX_ROUND_PD": return Intrinsic._MM512_MAX_ROUND_PD;
                case "_MM512_MAX_ROUND_PS": return Intrinsic._MM512_MAX_ROUND_PS;
                case "_MM512_MAXABS_PS": return Intrinsic._MM512_MAXABS_PS;
                case "_MM512_MIN_EPI16": return Intrinsic._MM512_MIN_EPI16;
                case "_MM512_MIN_EPI32": return Intrinsic._MM512_MIN_EPI32;
                case "_MM512_MIN_EPI64": return Intrinsic._MM512_MIN_EPI64;
                case "_MM512_MIN_EPI8": return Intrinsic._MM512_MIN_EPI8;
                case "_MM512_MIN_EPU16": return Intrinsic._MM512_MIN_EPU16;
                case "_MM512_MIN_EPU32": return Intrinsic._MM512_MIN_EPU32;
                case "_MM512_MIN_EPU64": return Intrinsic._MM512_MIN_EPU64;
                case "_MM512_MIN_EPU8": return Intrinsic._MM512_MIN_EPU8;
                case "_MM512_MIN_PD": return Intrinsic._MM512_MIN_PD;
                case "_MM512_MIN_PS": return Intrinsic._MM512_MIN_PS;
                case "_MM512_MIN_ROUND_PD": return Intrinsic._MM512_MIN_ROUND_PD;
                case "_MM512_MIN_ROUND_PS": return Intrinsic._MM512_MIN_ROUND_PS;
                case "_MM512_MOVEDUP_PD": return Intrinsic._MM512_MOVEDUP_PD;
                case "_MM512_MOVEHDUP_PS": return Intrinsic._MM512_MOVEHDUP_PS;
                case "_MM512_MOVELDUP_PS": return Intrinsic._MM512_MOVELDUP_PS;
                case "_MM512_MOVEPI16_MASK": return Intrinsic._MM512_MOVEPI16_MASK;
                case "_MM512_MOVEPI32_MASK": return Intrinsic._MM512_MOVEPI32_MASK;
                case "_MM512_MOVEPI64_MASK": return Intrinsic._MM512_MOVEPI64_MASK;
                case "_MM512_MOVEPI8_MASK": return Intrinsic._MM512_MOVEPI8_MASK;
                case "_MM512_MOVM_EPI16": return Intrinsic._MM512_MOVM_EPI16;
                case "_MM512_MOVM_EPI32": return Intrinsic._MM512_MOVM_EPI32;
                case "_MM512_MOVM_EPI64": return Intrinsic._MM512_MOVM_EPI64;
                case "_MM512_MOVM_EPI8": return Intrinsic._MM512_MOVM_EPI8;
                case "_MM512_MUL_EPI32": return Intrinsic._MM512_MUL_EPI32;
                case "_MM512_MUL_EPU32": return Intrinsic._MM512_MUL_EPU32;
                case "_MM512_MUL_PD": return Intrinsic._MM512_MUL_PD;
                case "_MM512_MUL_PS": return Intrinsic._MM512_MUL_PS;
                case "_MM512_MUL_ROUND_PD": return Intrinsic._MM512_MUL_ROUND_PD;
                case "_MM512_MUL_ROUND_PS": return Intrinsic._MM512_MUL_ROUND_PS;
                case "_MM512_MULHI_EPI16": return Intrinsic._MM512_MULHI_EPI16;
                case "_MM512_MULHI_EPI32": return Intrinsic._MM512_MULHI_EPI32;
                case "_MM512_MULHI_EPU16": return Intrinsic._MM512_MULHI_EPU16;
                case "_MM512_MULHI_EPU32": return Intrinsic._MM512_MULHI_EPU32;
                case "_MM512_MULHRS_EPI16": return Intrinsic._MM512_MULHRS_EPI16;
                case "_MM512_MULLO_EPI16": return Intrinsic._MM512_MULLO_EPI16;
                case "_MM512_MULLO_EPI32": return Intrinsic._MM512_MULLO_EPI32;
                case "_MM512_MULLO_EPI64": return Intrinsic._MM512_MULLO_EPI64;
                case "_MM512_MULLOX_EPI64": return Intrinsic._MM512_MULLOX_EPI64;
                case "_MM512_MULTISHIFT_EPI64_EPI8": return Intrinsic._MM512_MULTISHIFT_EPI64_EPI8;
                case "_MM512_NEARBYINT_PD": return Intrinsic._MM512_NEARBYINT_PD;
                case "_MM512_NEARBYINT_PS": return Intrinsic._MM512_NEARBYINT_PS;
                case "_MM512_OR_EPI32": return Intrinsic._MM512_OR_EPI32;
                case "_MM512_OR_EPI64": return Intrinsic._MM512_OR_EPI64;
                case "_MM512_OR_PD": return Intrinsic._MM512_OR_PD;
                case "_MM512_OR_PS": return Intrinsic._MM512_OR_PS;
                case "_MM512_OR_SI512": return Intrinsic._MM512_OR_SI512;
                case "_MM512_PACKS_EPI16": return Intrinsic._MM512_PACKS_EPI16;
                case "_MM512_PACKS_EPI32": return Intrinsic._MM512_PACKS_EPI32;
                case "_MM512_PACKSTOREHI_EPI32": return Intrinsic._MM512_PACKSTOREHI_EPI32;
                case "_MM512_PACKSTOREHI_EPI64": return Intrinsic._MM512_PACKSTOREHI_EPI64;
                case "_MM512_PACKSTOREHI_PD": return Intrinsic._MM512_PACKSTOREHI_PD;
                case "_MM512_PACKSTOREHI_PS": return Intrinsic._MM512_PACKSTOREHI_PS;
                case "_MM512_PACKSTORELO_EPI32": return Intrinsic._MM512_PACKSTORELO_EPI32;
                case "_MM512_PACKSTORELO_EPI64": return Intrinsic._MM512_PACKSTORELO_EPI64;
                case "_MM512_PACKSTORELO_PD": return Intrinsic._MM512_PACKSTORELO_PD;
                case "_MM512_PACKSTORELO_PS": return Intrinsic._MM512_PACKSTORELO_PS;
                case "_MM512_PACKUS_EPI16": return Intrinsic._MM512_PACKUS_EPI16;
                case "_MM512_PACKUS_EPI32": return Intrinsic._MM512_PACKUS_EPI32;
                case "_MM512_PERMUTE_PD": return Intrinsic._MM512_PERMUTE_PD;
                case "_MM512_PERMUTE_PS": return Intrinsic._MM512_PERMUTE_PS;
                case "_MM512_PERMUTE4F128_EPI32": return Intrinsic._MM512_PERMUTE4F128_EPI32;
                case "_MM512_PERMUTE4F128_PS": return Intrinsic._MM512_PERMUTE4F128_PS;
                case "_MM512_PERMUTEVAR_EPI32": return Intrinsic._MM512_PERMUTEVAR_EPI32;
                case "_MM512_PERMUTEVAR_PD": return Intrinsic._MM512_PERMUTEVAR_PD;
                case "_MM512_PERMUTEVAR_PS": return Intrinsic._MM512_PERMUTEVAR_PS;
                case "_MM512_PERMUTEX_EPI64": return Intrinsic._MM512_PERMUTEX_EPI64;
                case "_MM512_PERMUTEX_PD": return Intrinsic._MM512_PERMUTEX_PD;
                case "_MM512_PERMUTEX2VAR_EPI16": return Intrinsic._MM512_PERMUTEX2VAR_EPI16;
                case "_MM512_PERMUTEX2VAR_EPI32": return Intrinsic._MM512_PERMUTEX2VAR_EPI32;
                case "_MM512_PERMUTEX2VAR_EPI64": return Intrinsic._MM512_PERMUTEX2VAR_EPI64;
                case "_MM512_PERMUTEX2VAR_EPI8": return Intrinsic._MM512_PERMUTEX2VAR_EPI8;
                case "_MM512_PERMUTEX2VAR_PD": return Intrinsic._MM512_PERMUTEX2VAR_PD;
                case "_MM512_PERMUTEX2VAR_PS": return Intrinsic._MM512_PERMUTEX2VAR_PS;
                case "_MM512_PERMUTEXVAR_EPI16": return Intrinsic._MM512_PERMUTEXVAR_EPI16;
                case "_MM512_PERMUTEXVAR_EPI32": return Intrinsic._MM512_PERMUTEXVAR_EPI32;
                case "_MM512_PERMUTEXVAR_EPI64": return Intrinsic._MM512_PERMUTEXVAR_EPI64;
                case "_MM512_PERMUTEXVAR_EPI8": return Intrinsic._MM512_PERMUTEXVAR_EPI8;
                case "_MM512_PERMUTEXVAR_PD": return Intrinsic._MM512_PERMUTEXVAR_PD;
                case "_MM512_PERMUTEXVAR_PS": return Intrinsic._MM512_PERMUTEXVAR_PS;
                case "_MM512_POW_PD": return Intrinsic._MM512_POW_PD;
                case "_MM512_POW_PS": return Intrinsic._MM512_POW_PS;
                case "_MM512_PREFETCH_I32EXTGATHER_PS": return Intrinsic._MM512_PREFETCH_I32EXTGATHER_PS;
                case "_MM512_PREFETCH_I32EXTSCATTER_PS": return Intrinsic._MM512_PREFETCH_I32EXTSCATTER_PS;
                case "_MM512_PREFETCH_I32GATHER_PD": return Intrinsic._MM512_PREFETCH_I32GATHER_PD;
                case "_MM512_PREFETCH_I32GATHER_PS": return Intrinsic._MM512_PREFETCH_I32GATHER_PS;
                case "_MM512_PREFETCH_I32SCATTER_PD": return Intrinsic._MM512_PREFETCH_I32SCATTER_PD;
                case "_MM512_PREFETCH_I32SCATTER_PS": return Intrinsic._MM512_PREFETCH_I32SCATTER_PS;
                case "_MM512_PREFETCH_I64GATHER_PD": return Intrinsic._MM512_PREFETCH_I64GATHER_PD;
                case "_MM512_PREFETCH_I64GATHER_PS": return Intrinsic._MM512_PREFETCH_I64GATHER_PS;
                case "_MM512_PREFETCH_I64SCATTER_PD": return Intrinsic._MM512_PREFETCH_I64SCATTER_PD;
                case "_MM512_PREFETCH_I64SCATTER_PS": return Intrinsic._MM512_PREFETCH_I64SCATTER_PS;
                case "_MM512_RANGE_PD": return Intrinsic._MM512_RANGE_PD;
                case "_MM512_RANGE_PS": return Intrinsic._MM512_RANGE_PS;
                case "_MM512_RANGE_ROUND_PD": return Intrinsic._MM512_RANGE_ROUND_PD;
                case "_MM512_RANGE_ROUND_PS": return Intrinsic._MM512_RANGE_ROUND_PS;
                case "_MM512_RCP14_PD": return Intrinsic._MM512_RCP14_PD;
                case "_MM512_RCP14_PS": return Intrinsic._MM512_RCP14_PS;
                case "_MM512_RCP23_PS": return Intrinsic._MM512_RCP23_PS;
                case "_MM512_RCP28_PD": return Intrinsic._MM512_RCP28_PD;
                case "_MM512_RCP28_PS": return Intrinsic._MM512_RCP28_PS;
                case "_MM512_RCP28_ROUND_PD": return Intrinsic._MM512_RCP28_ROUND_PD;
                case "_MM512_RCP28_ROUND_PS": return Intrinsic._MM512_RCP28_ROUND_PS;
                case "_MM512_RECIP_PD": return Intrinsic._MM512_RECIP_PD;
                case "_MM512_RECIP_PS": return Intrinsic._MM512_RECIP_PS;
                case "_MM512_REDUCE_ADD_EPI32": return Intrinsic._MM512_REDUCE_ADD_EPI32;
                case "_MM512_REDUCE_ADD_EPI64": return Intrinsic._MM512_REDUCE_ADD_EPI64;
                case "_MM512_REDUCE_ADD_PD": return Intrinsic._MM512_REDUCE_ADD_PD;
                case "_MM512_REDUCE_ADD_PS": return Intrinsic._MM512_REDUCE_ADD_PS;
                case "_MM512_REDUCE_AND_EPI32": return Intrinsic._MM512_REDUCE_AND_EPI32;
                case "_MM512_REDUCE_AND_EPI64": return Intrinsic._MM512_REDUCE_AND_EPI64;
                case "_MM512_REDUCE_GMAX_PD": return Intrinsic._MM512_REDUCE_GMAX_PD;
                case "_MM512_REDUCE_GMAX_PS": return Intrinsic._MM512_REDUCE_GMAX_PS;
                case "_MM512_REDUCE_GMIN_PD": return Intrinsic._MM512_REDUCE_GMIN_PD;
                case "_MM512_REDUCE_GMIN_PS": return Intrinsic._MM512_REDUCE_GMIN_PS;
                case "_MM512_REDUCE_MAX_EPI32": return Intrinsic._MM512_REDUCE_MAX_EPI32;
                case "_MM512_REDUCE_MAX_EPI64": return Intrinsic._MM512_REDUCE_MAX_EPI64;
                case "_MM512_REDUCE_MAX_EPU32": return Intrinsic._MM512_REDUCE_MAX_EPU32;
                case "_MM512_REDUCE_MAX_EPU64": return Intrinsic._MM512_REDUCE_MAX_EPU64;
                case "_MM512_REDUCE_MAX_PD": return Intrinsic._MM512_REDUCE_MAX_PD;
                case "_MM512_REDUCE_MAX_PS": return Intrinsic._MM512_REDUCE_MAX_PS;
                case "_MM512_REDUCE_MIN_EPI32": return Intrinsic._MM512_REDUCE_MIN_EPI32;
                case "_MM512_REDUCE_MIN_EPI64": return Intrinsic._MM512_REDUCE_MIN_EPI64;
                case "_MM512_REDUCE_MIN_EPU32": return Intrinsic._MM512_REDUCE_MIN_EPU32;
                case "_MM512_REDUCE_MIN_EPU64": return Intrinsic._MM512_REDUCE_MIN_EPU64;
                case "_MM512_REDUCE_MIN_PD": return Intrinsic._MM512_REDUCE_MIN_PD;
                case "_MM512_REDUCE_MIN_PS": return Intrinsic._MM512_REDUCE_MIN_PS;
                case "_MM512_REDUCE_MUL_EPI32": return Intrinsic._MM512_REDUCE_MUL_EPI32;
                case "_MM512_REDUCE_MUL_EPI64": return Intrinsic._MM512_REDUCE_MUL_EPI64;
                case "_MM512_REDUCE_MUL_PD": return Intrinsic._MM512_REDUCE_MUL_PD;
                case "_MM512_REDUCE_MUL_PS": return Intrinsic._MM512_REDUCE_MUL_PS;
                case "_MM512_REDUCE_OR_EPI32": return Intrinsic._MM512_REDUCE_OR_EPI32;
                case "_MM512_REDUCE_OR_EPI64": return Intrinsic._MM512_REDUCE_OR_EPI64;
                case "_MM512_REDUCE_PD": return Intrinsic._MM512_REDUCE_PD;
                case "_MM512_REDUCE_PS": return Intrinsic._MM512_REDUCE_PS;
                case "_MM512_REDUCE_ROUND_PD": return Intrinsic._MM512_REDUCE_ROUND_PD;
                case "_MM512_REDUCE_ROUND_PS": return Intrinsic._MM512_REDUCE_ROUND_PS;
                case "_MM512_REM_EPI16": return Intrinsic._MM512_REM_EPI16;
                case "_MM512_REM_EPI32": return Intrinsic._MM512_REM_EPI32;
                case "_MM512_REM_EPI64": return Intrinsic._MM512_REM_EPI64;
                case "_MM512_REM_EPI8": return Intrinsic._MM512_REM_EPI8;
                case "_MM512_REM_EPU16": return Intrinsic._MM512_REM_EPU16;
                case "_MM512_REM_EPU32": return Intrinsic._MM512_REM_EPU32;
                case "_MM512_REM_EPU64": return Intrinsic._MM512_REM_EPU64;
                case "_MM512_REM_EPU8": return Intrinsic._MM512_REM_EPU8;
                case "_MM512_RINT_PD": return Intrinsic._MM512_RINT_PD;
                case "_MM512_RINT_PS": return Intrinsic._MM512_RINT_PS;
                case "_MM512_ROL_EPI32": return Intrinsic._MM512_ROL_EPI32;
                case "_MM512_ROL_EPI64": return Intrinsic._MM512_ROL_EPI64;
                case "_MM512_ROLV_EPI32": return Intrinsic._MM512_ROLV_EPI32;
                case "_MM512_ROLV_EPI64": return Intrinsic._MM512_ROLV_EPI64;
                case "_MM512_ROR_EPI32": return Intrinsic._MM512_ROR_EPI32;
                case "_MM512_ROR_EPI64": return Intrinsic._MM512_ROR_EPI64;
                case "_MM512_RORV_EPI32": return Intrinsic._MM512_RORV_EPI32;
                case "_MM512_RORV_EPI64": return Intrinsic._MM512_RORV_EPI64;
                case "_MM512_ROUND_PS": return Intrinsic._MM512_ROUND_PS;
                case "_MM512_ROUNDFXPNT_ADJUST_PD": return Intrinsic._MM512_ROUNDFXPNT_ADJUST_PD;
                case "_MM512_ROUNDFXPNT_ADJUST_PS": return Intrinsic._MM512_ROUNDFXPNT_ADJUST_PS;
                case "_MM512_ROUNDSCALE_PD": return Intrinsic._MM512_ROUNDSCALE_PD;
                case "_MM512_ROUNDSCALE_PS": return Intrinsic._MM512_ROUNDSCALE_PS;
                case "_MM512_ROUNDSCALE_ROUND_PD": return Intrinsic._MM512_ROUNDSCALE_ROUND_PD;
                case "_MM512_ROUNDSCALE_ROUND_PS": return Intrinsic._MM512_ROUNDSCALE_ROUND_PS;
                case "_MM512_RSQRT14_PD": return Intrinsic._MM512_RSQRT14_PD;
                case "_MM512_RSQRT14_PS": return Intrinsic._MM512_RSQRT14_PS;
                case "_MM512_RSQRT23_PS": return Intrinsic._MM512_RSQRT23_PS;
                case "_MM512_RSQRT28_PD": return Intrinsic._MM512_RSQRT28_PD;
                case "_MM512_RSQRT28_PS": return Intrinsic._MM512_RSQRT28_PS;
                case "_MM512_RSQRT28_ROUND_PD": return Intrinsic._MM512_RSQRT28_ROUND_PD;
                case "_MM512_RSQRT28_ROUND_PS": return Intrinsic._MM512_RSQRT28_ROUND_PS;
                case "_MM512_SAD_EPU8": return Intrinsic._MM512_SAD_EPU8;
                case "_MM512_SBB_EPI32": return Intrinsic._MM512_SBB_EPI32;
                case "_MM512_SBBR_EPI32": return Intrinsic._MM512_SBBR_EPI32;
                case "_MM512_SCALE_PS": return Intrinsic._MM512_SCALE_PS;
                case "_MM512_SCALE_ROUND_PS": return Intrinsic._MM512_SCALE_ROUND_PS;
                case "_MM512_SCALEF_PD": return Intrinsic._MM512_SCALEF_PD;
                case "_MM512_SCALEF_PS": return Intrinsic._MM512_SCALEF_PS;
                case "_MM512_SCALEF_ROUND_PD": return Intrinsic._MM512_SCALEF_ROUND_PD;
                case "_MM512_SCALEF_ROUND_PS": return Intrinsic._MM512_SCALEF_ROUND_PS;
                case "_MM512_SET_EPI32": return Intrinsic._MM512_SET_EPI32;
                case "_MM512_SET_EPI64": return Intrinsic._MM512_SET_EPI64;
                case "_MM512_SET_PD": return Intrinsic._MM512_SET_PD;
                case "_MM512_SET_PS": return Intrinsic._MM512_SET_PS;
                case "_MM512_SET1_EPI16": return Intrinsic._MM512_SET1_EPI16;
                case "_MM512_SET1_EPI32": return Intrinsic._MM512_SET1_EPI32;
                case "_MM512_SET1_EPI64": return Intrinsic._MM512_SET1_EPI64;
                case "_MM512_SET1_EPI8": return Intrinsic._MM512_SET1_EPI8;
                case "_MM512_SET1_PD": return Intrinsic._MM512_SET1_PD;
                case "_MM512_SET1_PS": return Intrinsic._MM512_SET1_PS;
                case "_MM512_SET4_EPI32": return Intrinsic._MM512_SET4_EPI32;
                case "_MM512_SET4_EPI64": return Intrinsic._MM512_SET4_EPI64;
                case "_MM512_SET4_PD": return Intrinsic._MM512_SET4_PD;
                case "_MM512_SET4_PS": return Intrinsic._MM512_SET4_PS;
                case "_MM512_SETR_EPI32": return Intrinsic._MM512_SETR_EPI32;
                case "_MM512_SETR_EPI64": return Intrinsic._MM512_SETR_EPI64;
                case "_MM512_SETR_PD": return Intrinsic._MM512_SETR_PD;
                case "_MM512_SETR_PS": return Intrinsic._MM512_SETR_PS;
                case "_MM512_SETR4_EPI32": return Intrinsic._MM512_SETR4_EPI32;
                case "_MM512_SETR4_EPI64": return Intrinsic._MM512_SETR4_EPI64;
                case "_MM512_SETR4_PD": return Intrinsic._MM512_SETR4_PD;
                case "_MM512_SETR4_PS": return Intrinsic._MM512_SETR4_PS;
                case "_MM512_SETZERO": return Intrinsic._MM512_SETZERO;
                case "_MM512_SETZERO_EPI32": return Intrinsic._MM512_SETZERO_EPI32;
                case "_MM512_SETZERO_PD": return Intrinsic._MM512_SETZERO_PD;
                case "_MM512_SETZERO_PS": return Intrinsic._MM512_SETZERO_PS;
                case "_MM512_SETZERO_SI512": return Intrinsic._MM512_SETZERO_SI512;
                case "_MM512_SHUFFLE_EPI32": return Intrinsic._MM512_SHUFFLE_EPI32;
                case "_MM512_SHUFFLE_EPI8": return Intrinsic._MM512_SHUFFLE_EPI8;
                case "_MM512_SHUFFLE_F32X4": return Intrinsic._MM512_SHUFFLE_F32X4;
                case "_MM512_SHUFFLE_F64X2": return Intrinsic._MM512_SHUFFLE_F64X2;
                case "_MM512_SHUFFLE_I32X4": return Intrinsic._MM512_SHUFFLE_I32X4;
                case "_MM512_SHUFFLE_I64X2": return Intrinsic._MM512_SHUFFLE_I64X2;
                case "_MM512_SHUFFLE_PD": return Intrinsic._MM512_SHUFFLE_PD;
                case "_MM512_SHUFFLE_PS": return Intrinsic._MM512_SHUFFLE_PS;
                case "_MM512_SHUFFLEHI_EPI16": return Intrinsic._MM512_SHUFFLEHI_EPI16;
                case "_MM512_SHUFFLELO_EPI16": return Intrinsic._MM512_SHUFFLELO_EPI16;
                case "_MM512_SIN_PD": return Intrinsic._MM512_SIN_PD;
                case "_MM512_SIN_PS": return Intrinsic._MM512_SIN_PS;
                case "_MM512_SINCOS_PD": return Intrinsic._MM512_SINCOS_PD;
                case "_MM512_SINCOS_PS": return Intrinsic._MM512_SINCOS_PS;
                case "_MM512_SIND_PD": return Intrinsic._MM512_SIND_PD;
                case "_MM512_SIND_PS": return Intrinsic._MM512_SIND_PS;
                case "_MM512_SINH_PD": return Intrinsic._MM512_SINH_PD;
                case "_MM512_SINH_PS": return Intrinsic._MM512_SINH_PS;
                case "_MM512_SLL_EPI16": return Intrinsic._MM512_SLL_EPI16;
                case "_MM512_SLL_EPI32": return Intrinsic._MM512_SLL_EPI32;
                case "_MM512_SLL_EPI64": return Intrinsic._MM512_SLL_EPI64;
                case "_MM512_SLLI_EPI16": return Intrinsic._MM512_SLLI_EPI16;
                case "_MM512_SLLI_EPI32": return Intrinsic._MM512_SLLI_EPI32;
                case "_MM512_SLLI_EPI64": return Intrinsic._MM512_SLLI_EPI64;
                case "_MM512_SLLV_EPI16": return Intrinsic._MM512_SLLV_EPI16;
                case "_MM512_SLLV_EPI32": return Intrinsic._MM512_SLLV_EPI32;
                case "_MM512_SLLV_EPI64": return Intrinsic._MM512_SLLV_EPI64;
                case "_MM512_SQRT_PD": return Intrinsic._MM512_SQRT_PD;
                case "_MM512_SQRT_PS": return Intrinsic._MM512_SQRT_PS;
                case "_MM512_SQRT_ROUND_PD": return Intrinsic._MM512_SQRT_ROUND_PD;
                case "_MM512_SQRT_ROUND_PS": return Intrinsic._MM512_SQRT_ROUND_PS;
                case "_MM512_SRA_EPI16": return Intrinsic._MM512_SRA_EPI16;
                case "_MM512_SRA_EPI32": return Intrinsic._MM512_SRA_EPI32;
                case "_MM512_SRA_EPI64": return Intrinsic._MM512_SRA_EPI64;
                case "_MM512_SRAI_EPI16": return Intrinsic._MM512_SRAI_EPI16;
                case "_MM512_SRAI_EPI32": return Intrinsic._MM512_SRAI_EPI32;
                case "_MM512_SRAI_EPI64": return Intrinsic._MM512_SRAI_EPI64;
                case "_MM512_SRAV_EPI16": return Intrinsic._MM512_SRAV_EPI16;
                case "_MM512_SRAV_EPI32": return Intrinsic._MM512_SRAV_EPI32;
                case "_MM512_SRAV_EPI64": return Intrinsic._MM512_SRAV_EPI64;
                case "_MM512_SRL_EPI16": return Intrinsic._MM512_SRL_EPI16;
                case "_MM512_SRL_EPI32": return Intrinsic._MM512_SRL_EPI32;
                case "_MM512_SRL_EPI64": return Intrinsic._MM512_SRL_EPI64;
                case "_MM512_SRLI_EPI16": return Intrinsic._MM512_SRLI_EPI16;
                case "_MM512_SRLI_EPI32": return Intrinsic._MM512_SRLI_EPI32;
                case "_MM512_SRLI_EPI64": return Intrinsic._MM512_SRLI_EPI64;
                case "_MM512_SRLV_EPI16": return Intrinsic._MM512_SRLV_EPI16;
                case "_MM512_SRLV_EPI32": return Intrinsic._MM512_SRLV_EPI32;
                case "_MM512_SRLV_EPI64": return Intrinsic._MM512_SRLV_EPI64;
                case "_MM512_STORE_EPI32": return Intrinsic._MM512_STORE_EPI32;
                case "_MM512_STORE_EPI64": return Intrinsic._MM512_STORE_EPI64;
                case "_MM512_STORE_PD": return Intrinsic._MM512_STORE_PD;
                case "_MM512_STORE_PS": return Intrinsic._MM512_STORE_PS;
                case "_MM512_STORE_SI512": return Intrinsic._MM512_STORE_SI512;
                case "_MM512_STORENR_PD": return Intrinsic._MM512_STORENR_PD;
                case "_MM512_STORENR_PS": return Intrinsic._MM512_STORENR_PS;
                case "_MM512_STORENRNGO_PD": return Intrinsic._MM512_STORENRNGO_PD;
                case "_MM512_STORENRNGO_PS": return Intrinsic._MM512_STORENRNGO_PS;
                case "_MM512_STOREU_PD": return Intrinsic._MM512_STOREU_PD;
                case "_MM512_STOREU_PS": return Intrinsic._MM512_STOREU_PS;
                case "_MM512_STOREU_SI512": return Intrinsic._MM512_STOREU_SI512;
                case "_MM512_STREAM_LOAD_SI512": return Intrinsic._MM512_STREAM_LOAD_SI512;
                case "_MM512_STREAM_PD": return Intrinsic._MM512_STREAM_PD;
                case "_MM512_STREAM_PS": return Intrinsic._MM512_STREAM_PS;
                case "_MM512_STREAM_SI512": return Intrinsic._MM512_STREAM_SI512;
                case "_MM512_SUB_EPI16": return Intrinsic._MM512_SUB_EPI16;
                case "_MM512_SUB_EPI32": return Intrinsic._MM512_SUB_EPI32;
                case "_MM512_SUB_EPI64": return Intrinsic._MM512_SUB_EPI64;
                case "_MM512_SUB_EPI8": return Intrinsic._MM512_SUB_EPI8;
                case "_MM512_SUB_PD": return Intrinsic._MM512_SUB_PD;
                case "_MM512_SUB_PS": return Intrinsic._MM512_SUB_PS;
                case "_MM512_SUB_ROUND_PD": return Intrinsic._MM512_SUB_ROUND_PD;
                case "_MM512_SUB_ROUND_PS": return Intrinsic._MM512_SUB_ROUND_PS;
                case "_MM512_SUBR_EPI32": return Intrinsic._MM512_SUBR_EPI32;
                case "_MM512_SUBR_PD": return Intrinsic._MM512_SUBR_PD;
                case "_MM512_SUBR_PS": return Intrinsic._MM512_SUBR_PS;
                case "_MM512_SUBR_ROUND_PD": return Intrinsic._MM512_SUBR_ROUND_PD;
                case "_MM512_SUBR_ROUND_PS": return Intrinsic._MM512_SUBR_ROUND_PS;
                case "_MM512_SUBRSETB_EPI32": return Intrinsic._MM512_SUBRSETB_EPI32;
                case "_MM512_SUBS_EPI16": return Intrinsic._MM512_SUBS_EPI16;
                case "_MM512_SUBS_EPI8": return Intrinsic._MM512_SUBS_EPI8;
                case "_MM512_SUBS_EPU16": return Intrinsic._MM512_SUBS_EPU16;
                case "_MM512_SUBS_EPU8": return Intrinsic._MM512_SUBS_EPU8;
                case "_MM512_SUBSETB_EPI32": return Intrinsic._MM512_SUBSETB_EPI32;
                case "_MM512_SVML_ROUND_PD": return Intrinsic._MM512_SVML_ROUND_PD;
                case "_MM512_SWIZZLE_EPI32": return Intrinsic._MM512_SWIZZLE_EPI32;
                case "_MM512_SWIZZLE_EPI64": return Intrinsic._MM512_SWIZZLE_EPI64;
                case "_MM512_SWIZZLE_PD": return Intrinsic._MM512_SWIZZLE_PD;
                case "_MM512_SWIZZLE_PS": return Intrinsic._MM512_SWIZZLE_PS;
                case "_MM512_TAN_PD": return Intrinsic._MM512_TAN_PD;
                case "_MM512_TAN_PS": return Intrinsic._MM512_TAN_PS;
                case "_MM512_TAND_PD": return Intrinsic._MM512_TAND_PD;
                case "_MM512_TAND_PS": return Intrinsic._MM512_TAND_PS;
                case "_MM512_TANH_PD": return Intrinsic._MM512_TANH_PD;
                case "_MM512_TANH_PS": return Intrinsic._MM512_TANH_PS;
                case "_MM512_TERNARYLOGIC_EPI32": return Intrinsic._MM512_TERNARYLOGIC_EPI32;
                case "_MM512_TERNARYLOGIC_EPI64": return Intrinsic._MM512_TERNARYLOGIC_EPI64;
                case "_MM512_TEST_EPI16_MASK": return Intrinsic._MM512_TEST_EPI16_MASK;
                case "_MM512_TEST_EPI32_MASK": return Intrinsic._MM512_TEST_EPI32_MASK;
                case "_MM512_TEST_EPI64_MASK": return Intrinsic._MM512_TEST_EPI64_MASK;
                case "_MM512_TEST_EPI8_MASK": return Intrinsic._MM512_TEST_EPI8_MASK;
                case "_MM512_TESTN_EPI16_MASK": return Intrinsic._MM512_TESTN_EPI16_MASK;
                case "_MM512_TESTN_EPI32_MASK": return Intrinsic._MM512_TESTN_EPI32_MASK;
                case "_MM512_TESTN_EPI64_MASK": return Intrinsic._MM512_TESTN_EPI64_MASK;
                case "_MM512_TESTN_EPI8_MASK": return Intrinsic._MM512_TESTN_EPI8_MASK;
                case "_MM512_TRUNC_PD": return Intrinsic._MM512_TRUNC_PD;
                case "_MM512_TRUNC_PS": return Intrinsic._MM512_TRUNC_PS;
                case "_MM512_UNDEFINED": return Intrinsic._MM512_UNDEFINED;
                case "_MM512_UNDEFINED_EPI32": return Intrinsic._MM512_UNDEFINED_EPI32;
                case "_MM512_UNDEFINED_PD": return Intrinsic._MM512_UNDEFINED_PD;
                case "_MM512_UNDEFINED_PS": return Intrinsic._MM512_UNDEFINED_PS;
                case "_MM512_UNPACKHI_EPI16": return Intrinsic._MM512_UNPACKHI_EPI16;
                case "_MM512_UNPACKHI_EPI32": return Intrinsic._MM512_UNPACKHI_EPI32;
                case "_MM512_UNPACKHI_EPI64": return Intrinsic._MM512_UNPACKHI_EPI64;
                case "_MM512_UNPACKHI_EPI8": return Intrinsic._MM512_UNPACKHI_EPI8;
                case "_MM512_UNPACKHI_PD": return Intrinsic._MM512_UNPACKHI_PD;
                case "_MM512_UNPACKHI_PS": return Intrinsic._MM512_UNPACKHI_PS;
                case "_MM512_UNPACKLO_EPI16": return Intrinsic._MM512_UNPACKLO_EPI16;
                case "_MM512_UNPACKLO_EPI32": return Intrinsic._MM512_UNPACKLO_EPI32;
                case "_MM512_UNPACKLO_EPI64": return Intrinsic._MM512_UNPACKLO_EPI64;
                case "_MM512_UNPACKLO_EPI8": return Intrinsic._MM512_UNPACKLO_EPI8;
                case "_MM512_UNPACKLO_PD": return Intrinsic._MM512_UNPACKLO_PD;
                case "_MM512_UNPACKLO_PS": return Intrinsic._MM512_UNPACKLO_PS;
                case "_MM512_XOR_EPI32": return Intrinsic._MM512_XOR_EPI32;
                case "_MM512_XOR_EPI64": return Intrinsic._MM512_XOR_EPI64;
                case "_MM512_XOR_PD": return Intrinsic._MM512_XOR_PD;
                case "_MM512_XOR_PS": return Intrinsic._MM512_XOR_PS;
                case "_MM512_XOR_SI512": return Intrinsic._MM512_XOR_SI512;
                case "_PDEP_U32": return Intrinsic._PDEP_U32;
                case "_PDEP_U64": return Intrinsic._PDEP_U64;
                case "_PEXT_U32": return Intrinsic._PEXT_U32;
                case "_PEXT_U64": return Intrinsic._PEXT_U64;
                case "_POPCNT32": return Intrinsic._POPCNT32;
                case "_POPCNT64": return Intrinsic._POPCNT64;
                case "_RDPMC": return Intrinsic._RDPMC;
                case "_RDRAND16_STEP": return Intrinsic._RDRAND16_STEP;
                case "_RDRAND32_STEP": return Intrinsic._RDRAND32_STEP;
                case "_RDRAND64_STEP": return Intrinsic._RDRAND64_STEP;
                case "_RDSEED16_STEP": return Intrinsic._RDSEED16_STEP;
                case "_RDSEED32_STEP": return Intrinsic._RDSEED32_STEP;
                case "_RDSEED64_STEP": return Intrinsic._RDSEED64_STEP;
                case "_RDTSC": return Intrinsic._RDTSC;
                case "_READFSBASE_U32": return Intrinsic._READFSBASE_U32;
                case "_READFSBASE_U64": return Intrinsic._READFSBASE_U64;
                case "_READGSBASE_U32": return Intrinsic._READGSBASE_U32;
                case "_READGSBASE_U64": return Intrinsic._READGSBASE_U64;
                case "_ROTL": return Intrinsic._ROTL;
                case "_ROTR": return Intrinsic._ROTR;
                case "_ROTWL": return Intrinsic._ROTWL;
                case "_ROTWR": return Intrinsic._ROTWR;
                case "_STOREBE_I16": return Intrinsic._STOREBE_I16;
                case "_STOREBE_I32": return Intrinsic._STOREBE_I32;
                case "_STOREBE_I64": return Intrinsic._STOREBE_I64;
                case "_SUBBORROW_U32": return Intrinsic._SUBBORROW_U32;
                case "_SUBBORROW_U64": return Intrinsic._SUBBORROW_U64;
                case "_TZCNT_U32": return Intrinsic._TZCNT_U32;
                case "_TZCNT_U64": return Intrinsic._TZCNT_U64;
                case "_WRITEFSBASE_U32": return Intrinsic._WRITEFSBASE_U32;
                case "_WRITEFSBASE_U64": return Intrinsic._WRITEFSBASE_U64;
                case "_WRITEGSBASE_U32": return Intrinsic._WRITEGSBASE_U32;
                case "_WRITEGSBASE_U64": return Intrinsic._WRITEGSBASE_U64;
                case "_XABORT": return Intrinsic._XABORT;
                case "_XBEGIN": return Intrinsic._XBEGIN;
                case "_XEND": return Intrinsic._XEND;
                case "_XGETBV": return Intrinsic._XGETBV;
                case "_XRSTOR": return Intrinsic._XRSTOR;
                case "_XRSTOR64": return Intrinsic._XRSTOR64;
                case "_XRSTORS": return Intrinsic._XRSTORS;
                case "_XRSTORS64": return Intrinsic._XRSTORS64;
                case "_XSAVE": return Intrinsic._XSAVE;
                case "_XSAVE64": return Intrinsic._XSAVE64;
                case "_XSAVEC": return Intrinsic._XSAVEC;
                case "_XSAVEC64": return Intrinsic._XSAVEC64;
                case "_XSAVEOPT": return Intrinsic._XSAVEOPT;
                case "_XSAVEOPT64": return Intrinsic._XSAVEOPT64;
                case "_XSAVES": return Intrinsic._XSAVES;
                case "_XSAVES64": return Intrinsic._XSAVES64;
                case "_XSETBV": return Intrinsic._XSETBV;
                case "_XTEST": return Intrinsic._XTEST;

                case "_ANDN_U32": return Intrinsic._ANDN_U32;
                case "_ANDN_U64": return Intrinsic._ANDN_U64;
                case "_BEXTR2_U32": return Intrinsic._BEXTR2_U32;
                case "_BEXTR2_U64": return Intrinsic._BEXTR2_U64;
                case "_MM_BROADCASTSI128_SI256": return Intrinsic._MM_BROADCASTSI128_SI256;
                case "_MM_CLWB": return Intrinsic._MM_CLWB;
                case "_MM256_CVTSD_F64": return Intrinsic._MM256_CVTSD_F64;
                case "_MM512_CVTSD_F64": return Intrinsic._MM512_CVTSD_F64;
                case "_MM256_CVTSI256_SI32": return Intrinsic._MM256_CVTSI256_SI32;
                case "_MM512_CVTSI512_SI32": return Intrinsic._MM512_CVTSI512_SI32;
                case "_MM256_CVTSS_F32": return Intrinsic._MM256_CVTSS_F32;
                case "_MM512_CVTSS_F32": return Intrinsic._MM512_CVTSS_F32;
                case "_MM_FMADD_ROUND_SD": return Intrinsic._MM_FMADD_ROUND_SD;
                case "_MM_FMADD_ROUND_SS": return Intrinsic._MM_FMADD_ROUND_SS;
                case "_MM_FMSUB_ROUND_SD": return Intrinsic._MM_FMSUB_ROUND_SD;
                case "_MM_FMSUB_ROUND_SS": return Intrinsic._MM_FMSUB_ROUND_SS;
                case "_MM_FNMADD_ROUND_SD": return Intrinsic._MM_FNMADD_ROUND_SD;
                case "_MM_FNMADD_ROUND_SS": return Intrinsic._MM_FNMADD_ROUND_SS;
                case "_MM_FNMSUB_ROUND_SD": return Intrinsic._MM_FNMSUB_ROUND_SD;
                case "_MM_FNMSUB_ROUND_SS": return Intrinsic._MM_FNMSUB_ROUND_SS;
                case "_MULX_U32": return Intrinsic._MULX_U32;
                case "_MULX_U64": return Intrinsic._MULX_U64;
                case "_RDPID_U32": return Intrinsic._RDPID_U32;
                case "_ROTL64": return Intrinsic._ROTL64;
                case "_ROTR64": return Intrinsic._ROTR64;
                case "_MM512_SET_EPI16": return Intrinsic._MM512_SET_EPI16;
                case "_MM512_SET_EPI8": return Intrinsic._MM512_SET_EPI8;
                case "_MM256_ZEXTPD128_PD256": return Intrinsic._MM256_ZEXTPD128_PD256;
                case "_MM512_ZEXTPD128_PD512": return Intrinsic._MM512_ZEXTPD128_PD512;
                case "_MM512_ZEXTPD256_PD512": return Intrinsic._MM512_ZEXTPD256_PD512;
                case "_MM256_ZEXTPS128_PS256": return Intrinsic._MM256_ZEXTPS128_PS256;
                case "_MM512_ZEXTPS128_PS512": return Intrinsic._MM512_ZEXTPS128_PS512;
                case "_MM512_ZEXTPS256_PS512": return Intrinsic._MM512_ZEXTPS256_PS512;
                case "_MM256_ZEXTSI128_SI256": return Intrinsic._MM256_ZEXTSI128_SI256;
                case "_MM512_ZEXTSI128_SI512": return Intrinsic._MM512_ZEXTSI128_SI512;
                case "_MM512_ZEXTSI256_SI512": return Intrinsic._MM512_ZEXTSI256_SI512;

                case "_MM512_4DPWSSD_EPI32": return Intrinsic._MM512_4DPWSSD_EPI32;
                case "_MM512_MASK_4DPWSSD_EPI32": return Intrinsic._MM512_MASK_4DPWSSD_EPI32;
                case "_MM512_MASKZ_4DPWSSD_EPI32": return Intrinsic._MM512_MASKZ_4DPWSSD_EPI32;
                case "_MM512_4DPWSSDS_EPI32": return Intrinsic._MM512_4DPWSSDS_EPI32;
                case "_MM512_MASK_4DPWSSDS_EPI32": return Intrinsic._MM512_MASK_4DPWSSDS_EPI32;
                case "_MM512_MASKZ_4DPWSSDS_EPI32": return Intrinsic._MM512_MASKZ_4DPWSSDS_EPI32;
                case "_MM512_4FMADD_PS": return Intrinsic._MM512_4FMADD_PS;
                case "_MM512_MASK_4FMADD_PS": return Intrinsic._MM512_MASK_4FMADD_PS;
                case "_MM512_MASKZ_4FMADD_PS": return Intrinsic._MM512_MASKZ_4FMADD_PS;
                case "_MM_4FMADD_SS": return Intrinsic._MM_4FMADD_SS;
                case "_MM_MASK_4FMADD_SS": return Intrinsic._MM_MASK_4FMADD_SS;
                case "_MM_MASKZ_4FMADD_SS": return Intrinsic._MM_MASKZ_4FMADD_SS;
                case "_MM512_4FNMADD_PS": return Intrinsic._MM512_4FNMADD_PS;
                case "_MM512_MASK_4FNMADD_PS": return Intrinsic._MM512_MASK_4FNMADD_PS;
                case "_MM512_MASKZ_4FNMADD_PS": return Intrinsic._MM512_MASKZ_4FNMADD_PS;
                case "_MM_4FNMADD_SS": return Intrinsic._MM_4FNMADD_SS;
                case "_MM_MASK_4FNMADD_SS": return Intrinsic._MM_MASK_4FNMADD_SS;
                case "_MM_MASKZ_4FNMADD_SS": return Intrinsic._MM_MASKZ_4FNMADD_SS;
                case "_MM512_MASK_POPCNT_EPI32": return Intrinsic._MM512_MASK_POPCNT_EPI32;
                case "_MM512_MASKZ_POPCNT_EPI32": return Intrinsic._MM512_MASKZ_POPCNT_EPI32;
                case "_MM512_POPCNT_EPI32": return Intrinsic._MM512_POPCNT_EPI32;
                case "_MM512_MASK_POPCNT_EPI64": return Intrinsic._MM512_MASK_POPCNT_EPI64;
                case "_MM512_MASKZ_POPCNT_EPI64": return Intrinsic._MM512_MASKZ_POPCNT_EPI64;
                case "_MM512_POPCNT_EPI64": return Intrinsic._MM512_POPCNT_EPI64;

                case "_ENCLS_U32": return Intrinsic._ENCLS_U32;
                case "_ENCLU_U32": return Intrinsic._ENCLU_U32;
                case "_PTWRITE32": return Intrinsic._PTWRITE32;
                case "_PTWRITE64": return Intrinsic._PTWRITE64;
                default:
                    if (warn) IntrinsicsDudeToolsStatic.Output("WARNING: IntrinsicTools: parseIntrinsic: unknown Intrinsic \"" + str + "\".");
                    return Intrinsic.NONE;
            }
        }
    }
}
