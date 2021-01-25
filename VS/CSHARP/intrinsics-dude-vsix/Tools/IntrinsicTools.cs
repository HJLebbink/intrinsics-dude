// The MIT License (MIT)
//
// Copyright (c) 2021 Henk-Jan Lebbink
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
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.Text;
    using Microsoft.VisualStudio.Text.Operations;

    public static partial class IntrinsicTools
    {
        private static readonly Dictionary<string, Intrinsic> _intrinsic_cache;

        /// <summary>Static class initializer for AsmSourceTools</summary>
        static IntrinsicTools()
        {
            _intrinsic_cache = new Dictionary<string, Intrinsic>();
            foreach (Intrinsic intrinsic in Enum.GetValues(typeof(Intrinsic)))
            {
                _intrinsic_cache.Add(intrinsic.ToString(), intrinsic);
            }
        }

        private static string ToCapitals(string str, bool strIsCapitals)
        {
#if DEBUG
            if (strIsCapitals && (str != str.ToUpper()))
            {
                throw new Exception();
            }
#endif
            return (strIsCapitals) ? str : str.ToUpper();
        }

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
            ARCH_NONE = 0L,
            ARCH_ADX = 1L << 0,
            ARCH_AES = 1L << 1,
            ARCH_AVX = 1L << 2,
            ARCH_AVX2 = 1L << 3,
            ARCH_AVX512_BW = 1L << 4,
            ARCH_AVX512_CD = 1L << 5,
            ARCH_AVX512_DQ = 1L << 6,
            ARCH_AVX512_ER = 1L << 7,
            ARCH_AVX512_F = 1L << 8,
            ARCH_AVX512_PF = 1L << 9,
            ARCH_AVX512_VL = 1L << 10,
            ARCH_AVX512_IFMA = 1L << 11,
            ARCH_AVX512_VBMI = 1L << 12,
            ARCH_AVX512_4VNNIW = 1L << 13,
            ARCH_AVX512_4FMAPS = 1L << 14,
            ARCH_AVX512_VPOPCNTDQ = 1L << 15,
            ARCH_AVX512_VBMI2 = 1L << 16,
            ARCH_AVX512_VNNI = 1L << 17,
            ARCH_AVX512_BITALG = 1L << 18,
            ARCH_AVX512_GFNI = 1L << 19,
            ARCH_AVX512_VAES = 1L << 20,
            ARCH_AVX512_VPCLMULQDQ = 1L << 21,
            ARCH_AVX512_BF16 = 1L << 22,
            ARCH_AVX512_VP2INTERSECT = 1L << 23,

            ARCH_BMI1 = 1L << 24,
            ARCH_BMI2 = 1L << 25,
            ARCH_CLFLUSHOPT = 1L << 26,
            ARCH_FMA = 1L << 27,
            ARCH_FP16C = 1L << 28,
            ARCH_FXSR = 1L << 29,
            ARCH_KNCNI = 1L << 30,
            ARCH_MMX = 1L << 31,
            ARCH_MPX = 1L << 32,
            ARCH_PCLMULQDQ = 1L << 33,
            ARCH_SSE = 1L << 34,
            ARCH_SSE2 = 1L << 35,
            ARCH_SSE3 = 1L << 36,
            ARCH_SSE41 = 1L << 37,
            ARCH_SSE42 = 1L << 38,
            ARCH_SSSE3 = 1L << 39,

            ARCH_LZCNT = 1L << 40,
            ARCH_INVPCID = 1L << 41,
            ARCH_MONITOR = 1L << 42,
            ARCH_POPCNT = 1L << 43,
            ARCH_RDRAND = 1L << 44,
            ARCH_RDSEED = 1L << 45,
            ARCH_TSC = 1L << 46,
            ARCH_RDTSCP = 1L << 47,
            ARCH_FSGSBASE = 1L << 48,
            ARCH_SHA = 1L << 49,
            ARCH_RTM = 1L << 50,
            ARCH_XSAVE = 1L << 51,
            ARCH_XSAVEC = 1L << 52,
            ARCH_XSS = 1L << 53,
            ARCH_XSAVEOPT = 1L << 54,
            ARCH_PREFETCHWT1 = 1L << 55,

            ARCH_SVML = 1L << 56,
            ARCH_IA32 = 1L << 57,

            /// <summary>
            /// Read Processor ID
            /// </summary>
            ARCH_RDPID = 1L << 58,

            /// <summary>
            /// Cache Line Write Back
            /// </summary>
            ARCH_CLWB = 1L << 59,

            // bits 47-62 are reserved for future use

            /// <summary>
            /// UNKNOWN is used for an unknown or unrecognized CPUID.
            /// </summary>
            ARCH_UNKNOWN = 1L << 63,
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
            VOID_PTR,
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
            VOID_CONST_PTR,
        }

        public static SimdRegisterType ParseSimdRegisterType(string str, bool strIsCapitals, bool warn)
        {
            if (!str.StartsWith("__"))
            {
                return SimdRegisterType.NONE;
            }

            switch (ToCapitals(str, strIsCapitals))
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
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: parseIntrinsicRegisterType: unknown IntrinsicRegisterType \"" + str + "\".");
                    }

                    return SimdRegisterType.NONE;
            }
        }

        public static ReturnType ParseReturnType(string str, bool strIsCapitals, bool warn)
        {
            switch (ToCapitals(str, strIsCapitals))
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
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: parseReturnType: unknown ReturnType \"" + str + "\".");
                    }

                    return ReturnType.UNKNOWN;
            }
        }

        /// <summary>
        /// parse internal paramType name to ParamTYpe
        /// </summary>
        public static ParamType ParseParamType_InternalName(string str, bool warn)
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
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: parseParamType_InternalName: unknown ParamType \"" + str + "\".");
                    }

                    return ParamType.NONE;
            }
        }

        /// <summary>
        /// parse human readable text to ParamType
        /// </summary>
        public static ParamType ParseParamType(string str, bool strIsCapitals, bool warn)
        {
            string str2 = ToCapitals(str, strIsCapitals).Replace(" *", "*");

            switch (str2)
            {
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
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: parseParamType: unknown ParamType: str=\"" + str + "\"; str2=\"" + str2 + "\".");
                    }

                    return ParamType.NONE;
            }
        }

        public static CpuID ParseCpuID(string str, bool strIsCapitals, bool warn)
        {
            switch (ToCapitals(str, strIsCapitals))
            {
                case "":
                case "NONE": return CpuID.ARCH_NONE;
                case "IA32": return CpuID.ARCH_IA32;

                case "ADX": return CpuID.ARCH_ADX;
                case "AES": return CpuID.ARCH_AES;
                case "AVX": return CpuID.ARCH_AVX;
                case "AVX2": return CpuID.ARCH_AVX2;

                case "AVX512BW":
                case "AVX512_BW": return CpuID.ARCH_AVX512_BW;
                case "AVX512CD":
                case "AVX512_CD": return CpuID.ARCH_AVX512_CD;
                case "AVX512DQ":
                case "AVX512_DQ": return CpuID.ARCH_AVX512_DQ;
                case "AVX512ER":
                case "AVX512_ER": return CpuID.ARCH_AVX512_ER;
                case "AVX512":
                case "AVX512F":
                case "AVX512_F": return CpuID.ARCH_AVX512_F;
                case "AVX512PF":
                case "AVX512_PF": return CpuID.ARCH_AVX512_PF;
                case "AVX512VL":
                case "AVX512_VL": return CpuID.ARCH_AVX512_VL;
                case "AVX5124VNNIW":
                case "AVX512_4VNNIW": return CpuID.ARCH_AVX512_4VNNIW;
                case "AVX5124FMAPS":
                case "AVX512_4FMAPS": return CpuID.ARCH_AVX512_4FMAPS;
                case "AVX512VPOPCNTDQ":
                case "AVX512_VPOPCNTDQ": return CpuID.ARCH_AVX512_VPOPCNTDQ;

                case "BMI1": return CpuID.ARCH_BMI1;
                case "BMI2": return CpuID.ARCH_BMI2;
                case "CLFLUSHOPT": return CpuID.ARCH_CLFLUSHOPT;
                case "FMA": return CpuID.ARCH_FMA;
                case "FP16C": return CpuID.ARCH_FP16C;
                case "FXSR": return CpuID.ARCH_FXSR;
                case "KNCNI": return CpuID.ARCH_KNCNI;
                case "MMX": return CpuID.ARCH_MMX;
                case "MPX": return CpuID.ARCH_MPX;
                case "PCLMULQDQ": return CpuID.ARCH_PCLMULQDQ;
                case "SSE": return CpuID.ARCH_SSE;
                case "SSE2": return CpuID.ARCH_SSE2;
                case "SSE3": return CpuID.ARCH_SSE3;
                case "SSE4_1":
                case "SSE4.1": return CpuID.ARCH_SSE41;
                case "SSE4_2":
                case "SSE4.2": return CpuID.ARCH_SSE42;
                case "SSSE3": return CpuID.ARCH_SSSE3;

                case "LZCNT": return CpuID.ARCH_LZCNT;
                case "AVX512IFMA52":
                case "AVX512IFMA":
                case "AVX512_IFMA":
                case "AVX512_IFMA52": return CpuID.ARCH_AVX512_IFMA;
                case "INVPCID": return CpuID.ARCH_INVPCID;
                case "MONITOR": return CpuID.ARCH_MONITOR;
                case "AVX512VBMI":
                case "AVX512_VBMI": return CpuID.ARCH_AVX512_VBMI;
                case "POPCNT": return CpuID.ARCH_POPCNT;
                case "RDRAND": return CpuID.ARCH_RDRAND;
                case "RDSEED": return CpuID.ARCH_RDSEED;
                case "TSC": return CpuID.ARCH_TSC;
                case "RDTSCP": return CpuID.ARCH_RDTSCP;
                case "FSGSBASE": return CpuID.ARCH_FSGSBASE;
                case "SHA": return CpuID.ARCH_SHA;
                case "RTM": return CpuID.ARCH_RTM;
                case "XSAVE": return CpuID.ARCH_XSAVE;
                case "XSAVEC": return CpuID.ARCH_XSAVEC;
                case "XSS": return CpuID.ARCH_XSS;
                case "XSAVEOPT": return CpuID.ARCH_XSAVEOPT;
                case "PREFETCHWT1": return CpuID.ARCH_PREFETCHWT1;

                case "SVML": return CpuID.ARCH_SVML;
                case "RDPID": return CpuID.ARCH_RDPID;
                case "CLWB": return CpuID.ARCH_CLWB;

                default:
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: parseCpuID: unknown or unrecognized CpuID \"" + str + "\": returning " + CpuID.ARCH_UNKNOWN);
                    }

                    return CpuID.ARCH_UNKNOWN;
            }
        }

        public static CpuID ParseCpuID_multiple(string str, bool strIsCapitals, bool warn)
        {
            CpuID cpuID = CpuID.ARCH_NONE;
            foreach (string cpuID_str in str.Split(','))
            {
                cpuID |= ParseCpuID(cpuID_str.Trim(), strIsCapitals, warn);
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

        public static bool IsSimdRegister(string str, bool strIsCapitals)
        {
            switch (ToCapitals(str, strIsCapitals))
            {
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
                if (value == CpuID.ARCH_NONE)
                {
                    continue;
                }

                if (cpuIDs.HasFlag(value))
                {
                    switch (value)
                    {
                        case CpuID.ARCH_SSE41:
                            sb.Append("SSE4.1, ");
                            break;
                        case CpuID.ARCH_SSE42:
                            sb.Append("SSE4.2, ");
                            break;
                        default:
                            sb.Append(value.ToString());
                            sb.Append(", ");
                            break;
                    }
                }
            }

            if (sb.Length > 0)
            {
                sb.Length -= 2; // remove trailing comma
            }

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
                case ParamType.SIZE_T_PTR: return "size_t *";
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
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: ToString: unknown ParamType \"" + type + "\".");
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
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: ToString: unknown ReturnType \"" + type + "\".");
                    return type.ToString();
                    break;
            }
        }

        public static string GetCpuID_Documentation(CpuID cpuID)
        {
            switch (cpuID)
            {
                case CpuID.ARCH_NONE: return string.Empty;
                case CpuID.ARCH_SVML: return string.Empty;
                case CpuID.ARCH_IA32: return string.Empty;
                case CpuID.ARCH_ADX: return "Multi-Precision Add-Carry Instruction Extension";
                case CpuID.ARCH_AES: return "Advanced Encryption Standard Extension";
                case CpuID.ARCH_AVX: return string.Empty;
                case CpuID.ARCH_AVX2: return string.Empty;

                case CpuID.ARCH_AVX512_F: return "AVX512-F - Foundation";
                case CpuID.ARCH_AVX512_CD: return "AVX512-CD - Conflict Detection";
                case CpuID.ARCH_AVX512_ER: return "AVX512-ER - Exponential and Reciprocal";
                case CpuID.ARCH_AVX512_PF: return "AVX512-PF - Prefetch";
                case CpuID.ARCH_AVX512_BW: return "AVX512-BW - Byte and Word";
                case CpuID.ARCH_AVX512_DQ: return "AVX512-DQ - Doubleword and QuadWord";
                case CpuID.ARCH_AVX512_VL: return "AVX512-VL - Vector Length Extensions";
                case CpuID.ARCH_AVX512_IFMA: return "AVX512-IFMA - Integer Fused Multiply Add";
                case CpuID.ARCH_AVX512_VBMI: return "AVX512-VBMI - Vector Byte Manipulation Instructions";
                case CpuID.ARCH_AVX512_VPOPCNTDQ: return "AVX512-VPOPCNTDQ - Vector Population Count instructions for Dwords and Qwords";
                case CpuID.ARCH_AVX512_4VNNIW: return "AVX512-4VNNIW - Vector Neural Network Instructions Word variable precision";
                case CpuID.ARCH_AVX512_4FMAPS: return "AVX512-4FMAPS - Fused Multiply Accumulation Packed Single precision";
                case CpuID.ARCH_AVX512_VBMI2: return "AVX512-VBMI2 - Vector Byte Manipulation Instructions 2";
                case CpuID.ARCH_AVX512_VNNI: return "AVX512-VNNI - Vector Neural Network Instructions";
                case CpuID.ARCH_AVX512_BITALG: return "AVX512-BITALG - Bit Algorithms";
                case CpuID.ARCH_AVX512_GFNI: return " AVX512-GFNI - Galois Field New Instructions";
                case CpuID.ARCH_AVX512_VAES: return "AVX512-VPCLMULQDQ - EVEX-encoded Advanced Encryption Standard";
                case CpuID.ARCH_AVX512_VPCLMULQDQ: return "AVX512-VPCLMULQDQ";
                case CpuID.ARCH_AVX512_BF16: return "AVX512-BF16 - Brain Float 16 extension (Bfloat16)";
                case CpuID.ARCH_AVX512_VP2INTERSECT: return "AVX512-VP2INTERSECT - ";

                case CpuID.ARCH_BMI1: return "Bit Manipulation Instruction Set 1";
                case CpuID.ARCH_BMI2: return "Bit Manipulation Instruction Set 2";
                case CpuID.ARCH_CLFLUSHOPT: return string.Empty;
                case CpuID.ARCH_FMA: return "Fused Multiply-Add Instructions";
                case CpuID.ARCH_FP16C: return "Half Precision Floating Point Conversion Instructions";
                case CpuID.ARCH_FXSR: return string.Empty;
                case CpuID.ARCH_KNCNI: return string.Empty;
                case CpuID.ARCH_MMX: return string.Empty;
                case CpuID.ARCH_MPX: return "Memory Protection Extensions";
                case CpuID.ARCH_PCLMULQDQ: return "Carry-Less Multiplication Instructions";
                case CpuID.ARCH_SSE: return string.Empty;
                case CpuID.ARCH_SSE2: return string.Empty;
                case CpuID.ARCH_SSE3: return string.Empty;
                case CpuID.ARCH_SSE41: return string.Empty;
                case CpuID.ARCH_SSE42: return string.Empty;
                case CpuID.ARCH_SSSE3: return string.Empty;

                case CpuID.ARCH_LZCNT: return string.Empty;
                case CpuID.ARCH_INVPCID: return string.Empty;
                case CpuID.ARCH_MONITOR: return string.Empty;
                case CpuID.ARCH_POPCNT: return string.Empty;
                case CpuID.ARCH_RDRAND: return string.Empty;
                case CpuID.ARCH_RDSEED: return string.Empty;
                case CpuID.ARCH_TSC: return string.Empty;
                case CpuID.ARCH_RDTSCP: return string.Empty;
                case CpuID.ARCH_FSGSBASE: return string.Empty;
                case CpuID.ARCH_SHA: return string.Empty;
                case CpuID.ARCH_RTM: return string.Empty;
                case CpuID.ARCH_XSAVE: return string.Empty;
                case CpuID.ARCH_XSAVEC: return string.Empty;
                case CpuID.ARCH_XSS: return string.Empty;
                case CpuID.ARCH_XSAVEOPT: return string.Empty;
                case CpuID.ARCH_PREFETCHWT1: return string.Empty;

                case CpuID.ARCH_RDPID: return "Read Processor ID";
                case CpuID.ARCH_CLWB: return "Cache Line Write Back";

                default:
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: getCpuID_Documentation: unknown CpuID \"" + cpuID + "\".");
                    return string.Empty;
            }
        }

        /// <summary>return true if type2 be cast to type1; false otherwise</summary>
        public static bool IsConversionPossible(ReturnType type1, ReturnType type2)
        {
            if (type2 == ReturnType.UNKNOWN)
            {
                return true;
            }

            switch (type1)
            {
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
                    switch (type2)
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
                            return false;
                        default:
                            return true;
                    }

                    break;
                default:
                    IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: conversionPossible: unknown or unrecognized ReturnType \"" + type1 + "\": returning false");
                    return false;
            }
        }

        public static bool IsCpuID_Enabled(CpuID cpuID_intrisic, CpuID selectedArchitectures)
        {
            if (cpuID_intrisic.HasFlag(CpuID.ARCH_SVML) && !selectedArchitectures.HasFlag(CpuID.ARCH_SVML))
            {
                return false;
            }

            CpuID commonCpuID = (selectedArchitectures & cpuID_intrisic);
            //IntrinsicsDudeToolsStatic.Output_WARNING("IntrinsicTools: isCpuID_Enabled: cpuID_intrisic=" + IntrinsicTools.ToString(cpuID_intrisic) + "; selectedArchitectures="+IntrinsicTools.ToString(selectedArchitectures) +"; commonCpuID " + IntrinsicTools.ToString(commonCpuID));
            return (commonCpuID != CpuID.ARCH_NONE);
        }

        #region Text Wrap

        /// <summary>
        /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
        /// </summary>
        /// <param name="str">The string to wrap.</param>
        /// <param name="maxLength">The maximum number of characters per line.</param>
        public static string Linewrap(this string str, int maxLength)
        {
            return Linewrap(str, maxLength, string.Empty);
        }

        /// <summary>
        /// Forces the string to word wrap so that each line doesn't exceed the maxLineLength.
        /// </summary>
        /// <param name="str">The string to wrap.</param>
        /// <param name="maxLength">The maximum number of characters per line.</param>
        /// <param name="prefix">Adds this string to the beginning of each line.</param>
        private static string Linewrap(string str, int maxLength, string prefix)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (maxLength <= 0)
            {
                return prefix + str;
            }

            IList<string> lines = new List<string>();

            // breaking the string into lines makes it easier to process.
            foreach (string line in str.Split("\n".ToCharArray()))
            {
                string remainingLine = line.Trim();
                do
                {
                    string newLine = GetLine(remainingLine, maxLength - prefix.Length);
                    lines.Add(newLine);
                    remainingLine = remainingLine.Substring(newLine.Length).TrimEnd();
                    // Keep iterating as int as we've got words remaining in the line.
                }
                while (remainingLine.Length > 0);
            }

            return string.Join(Environment.NewLine + prefix, lines.ToArray());
        }

        private static string GetLine(string str, int maxLength)
        {
            // The string is less than the max length so just return it.
            if (str.Length <= maxLength)
            {
                return str;
            }

            // Search backwords in the string for a whitespace char
            // starting with the char one after the maximum length
            // (if the next char is a whitespace, the last word fits).
            for (int i = maxLength; i >= 0; i--)
            {
                if (IsTextSeparatorChar(str[i]))
                {
                    return str.Substring(0, i).TrimEnd();
                }
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
            for (int i = 0; i < 1000; i++)
            {
                TextExtent extent = nav.GetExtentOfWord(currentPos);
                string word = extent.Span.GetText();
                //IntrinsicsDudeToolsStatic.Output_INFO("IntrSignHelpCommandHandler: getIntrinsicAndParamIndex: word=\"" + word+"\".");

                if (word.Contains(";"))
                {
                    break;
                }

                if (word.Equals("="))
                {
                    break;
                }

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
                            bool is_capitals = false;
                            bool warn = false;
                            return new Tuple<Intrinsic, int>(ParseIntrinsic(word2, is_capitals, warn), nParameters);
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

                if (extent.Span.Start == 0)
                {
                    break;
                }

                currentPos = extent.Span.Start - 1;
            }

            return new Tuple<Intrinsic, int>(Intrinsic.NONE, 0);
        }

        public static Intrinsic ParseIntrinsic(string str, bool strIsCapitals, bool warn)
        {
            if (str == null)
            {
                if (warn)
                {
                    IntrinsicsDudeToolsStatic.Output_WARNING(string.Format("{0}:ParseIntrinsic: str is null", "IntrinsicTools"));
                }
                return Intrinsic.NONE;
            }
            else
            {
                if (_intrinsic_cache.TryGetValue(ToCapitals(str, strIsCapitals), out Intrinsic value))
                {
                    //IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:ParseIntrinsic: parsed Intrinsic \"{1}\".", "IntrinsicTools", value));
                    return value;
                }
                else
                {
                    if (warn)
                    {
                        IntrinsicsDudeToolsStatic.Output_WARNING(string.Format("{0}:ParseIntrinsic: unknown Intrinsic \"{1}\".", "IntrinsicTools", str));
                    }
                    return Intrinsic.NONE;
                }
            }
        }
    }
}
