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

using IntrinsicsDude.Tools;
using AsmTools;
using System.Collections.Generic;
using System.Text;

namespace IntrinsicsDude.SignatureHelp {

    public enum IntrinsicSignatureEnum : byte {
        NONE,
        UNKNOWN,

        //memory operands
        MEM, M8, M16, M32, M64, M80, M128, M256, M512,

        //register operands
        R8, R16, R32, R64,

        //specific register operands
        REG_AL, REG_AX, REG_EAX, REG_RAX,
        REG_CL, REG_CX, REG_ECX, REG_RCX,
        REG_DX, REG_EDX,
        REG_CS, REG_DS, REG_ES, REG_SS, REG_FS, REG_GS,

        /// <summary>the IMM equal to 0</summary>
        ZERO,
        /// <summary>the IMM equal to 1</summary>
        UNITY,

        IMM,
        IMM8,
        IMM16,
        IMM32,
        IMM64,

        REL8,
        REL16,
        REL32,
        REL64,

        imm_imm,
        imm16_imm,
        imm_imm16,
        imm32_imm,
        imm_imm32,

        NEAR,
        FAR,
        SHORT_ENUM,

        #region FPU
        FPU0,
        FPUREG, 
        M2BYTE,
        M14BYTE,
        M28BYTE,
        M94BYTE,
        M108BYTE,
        M512BYTE,
        #endregion

        #region SIMD
        /// <summary>Opmask register</summary>
        K,
        /// <summary> Zero mask. Nasm use {Z} or nothing</summary>
        Z,
        /// <summary>Suppress All Exceptions. Nasm use {SAE} or nothing</summary>
        SAE,
        /// <summary>
        /// Rounding mode. Nasm: use either:
        /// 1] round nearest even {rn-sae};
        /// 2] round down {rd-sae};
        /// 3] round up {ru-sae};
        /// 4] truncate {rz-sae};
        /// or nothing</summary>
        ER,

        /// <summary>memory destination of type [gpr+xmm*scale+offset] </summary>
        VM32X,
        VM64X,
        /// <summary>memory destination of type [gpr+ymm*scale+offset] with scale=1|4|8</summary>
        VM32Y,
        VM64Y,
        /// <summary>memory destination of type [gpr+zmm*scale+offset] with scale=1|4|8</summary>
        VM32Z,
        VM64Z,

        REG_XMM0, MMXREG, mmxreg, XMMREG, YMMREG, ZMMREG,

        /// <summary>Bound register</summary>
        BNDREG,

        /// <summary>vector broadcasted from a 32-bit memory location</summary>
        M32BCST,
        /// <summary>vector broadcasted from a 64-bit memory location</summary>
        M64BCST,
        #endregion

        MEM_OFFSET,
        REG_SREG,
        REG_DREG,
        CR0, CR1, CR2, CR3, CR4, CR5, CR6, CR7, CR8,
    }

    public static class AsmSignatureTools {

        public static IntrinsicSignatureEnum[] parseOperandTypeEnum(string str) {

            switch (str.ToUpper().Trim()) {

                #region Memory
                case "MEM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M8 };
                case "M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M16 };
                case "M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M32 };
                case "M32{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.K };
                case "M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M64 };
                case "M64{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.K };
                case "M80": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M80 };
                case "M128": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M128 };
                case "M256": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M256 };
                case "M512": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M512 };

                case "M16&16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M16&32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M16&64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M32&32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };

                case "M16:16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M16:32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                case "M16:64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };

                case "PTR16:16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM };
                case "PTR16:32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM };
                case "PTR16:64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM };

                #endregion

                #region Register
                case "R8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R8 };
                case "R16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R16 };
                case "R32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32 };
                case "R64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R64 };

                case "REG": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32 };
                case "AL": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_AL };
                case "AX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_AX };
                case "EAX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_EAX };
                case "RAX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_RAX };

                case "CL": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_CL };
                case "CX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_CX };
                case "ECX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_ECX };
                case "RCX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_RCX };

                case "DX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_DX };
                case "EDX": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_EDX };

                case "CS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_CS };
                case "DS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_DS };
                case "ES": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_ES };
                case "SS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_SS };
                case "FS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_FS };
                case "GS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_GS };

                case "REG_SREG":
                case "SREG": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_SREG };
                case "CR0–CR7": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.CR0, IntrinsicSignatureEnum.CR1, IntrinsicSignatureEnum.CR2, IntrinsicSignatureEnum.CR3, IntrinsicSignatureEnum.CR4, IntrinsicSignatureEnum.CR5, IntrinsicSignatureEnum.CR6, IntrinsicSignatureEnum.CR7 };
                case "CR8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.CR8 };
                case "REG_DREG": 
                case "DR0–DR7": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_DREG };

                #endregion

                #region Register or Memory
                case "R/M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R8, IntrinsicSignatureEnum.M8 };
                case "R/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R16, IntrinsicSignatureEnum.M16 };
                case "R/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M32 };
                case "R/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R64, IntrinsicSignatureEnum.M64 };
                case "R/M32{ER}":  return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.ER };
                case "R/M64{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R64, IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.ER };

                case "REG/M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R8, IntrinsicSignatureEnum.M8 };
                case "REG/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R16, IntrinsicSignatureEnum.M16 };
                case "REG/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M32 };

                case "R16/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R16, IntrinsicSignatureEnum.M16 };
                case "R32/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M16 };
                case "R64/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R64, IntrinsicSignatureEnum.M16 };
                case "R32/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M32 };
                case "R64/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R64, IntrinsicSignatureEnum.M64 };
                case "R32/M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.R32, IntrinsicSignatureEnum.M8 };
                #endregion

                #region Constants Immediates
                case "0": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZERO };
                case "1": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.UNITY };

                case "MOFFS8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM8 };
                case "MOFFS16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM16 };
                case "MOFFS32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM32 };
                case "MOFFS64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM64 };

                case "REL8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM8 };
                case "REL16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM16 };
                case "REL32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM32 };
                case "REL64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM64 };

                case "IMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM };
                case "IMM8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM8 };
                case "IMM16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM16 };
                case "IMM32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM32 };
                case "IMM64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.IMM64 };

                case "IMM:IMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.imm_imm };
                case "IMM16:IMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.imm16_imm };
                case "IMM:IMM16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.imm_imm16 };
                case "IMM32:IMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.imm32_imm };
                case "IMM:IMM32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.imm_imm32 };
                #endregion

                #region FPU
                case "ST(I)": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.FPUREG };
                case "ST(0)": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.FPU0 };
                case "ST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.FPUREG };
                case "M32FP": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.FPUREG };
                case "M64FP": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.FPUREG };
                case "M80FP": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M80, IntrinsicSignatureEnum.FPUREG };
                case "M16INT": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M16 };
                case "M32INT": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M32 };
                case "M64INT": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M64 };

                case "M14/28BYTE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M14BYTE, IntrinsicSignatureEnum.M28BYTE };
                case "M94/108BYTE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M94BYTE, IntrinsicSignatureEnum.M108BYTE };
                case "M2BYTE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M2BYTE };
                case "M512BYTE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M512BYTE };
                case "M80BCD":  return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M80 };
                case "M80DEC": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.M80 };
                #endregion

                #region SIMD
                case "MM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MMXREG };
                case "MM/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MMXREG, IntrinsicSignatureEnum.M32 };
                case "MM/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MMXREG, IntrinsicSignatureEnum.M64 };
                case "MM/MEM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MMXREG, IntrinsicSignatureEnum.M64 };

                case "Z": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.Z };
                case "K": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K };
                case "K{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K };
                case "SAE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.SAE };
                case "ER": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ER };

                case "K/M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.M8 };
                case "K/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.M16 };
                case "K/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.M32 };
                case "K/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.M64 };

                case "VM32X": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32X };
                case "VM64X": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64X };
                case "VM32Y": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32Y };
                case "VM64Y": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64Y };
                case "VM32Z": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32Z };
                case "VM64Z": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64Z };

                case "VM32X{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32X, IntrinsicSignatureEnum.K };
                case "VM64X{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64X, IntrinsicSignatureEnum.K };
                case "VM32Y{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32Y, IntrinsicSignatureEnum.K };
                case "VM64Y{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64Y, IntrinsicSignatureEnum.K };
                case "VM32Z{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM32Z, IntrinsicSignatureEnum.K };
                case "VM64Z{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.VM64Z, IntrinsicSignatureEnum.K };

                case "XMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG };
                case "XMM_ZERO": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.REG_XMM0 };
                case "XMM{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.K };
                case "XMM{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "XMM/M8": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M8 };
                case "XMM/M16": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M16 };
                case "XMM/M16{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M16 };
                case "XMM/M32": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "XMM/M32{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "XMM/M32{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.ER };
                case "XMM/M32{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M32, IntrinsicSignatureEnum.SAE };
                case "XMM/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M64 };
                case "XMM/M64{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "XMM/M64{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.ER };
                case "XMM/M64{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.SAE };
                case "XMM/M64/M32BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M64, IntrinsicSignatureEnum.M32BCST };
                case "XMM/M128":return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M128 };
                case "XMM/M128{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M128, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "XMM/M128/M32BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M128, IntrinsicSignatureEnum.M32BCST };
                case "XMM/M128/M64BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.XMMREG, IntrinsicSignatureEnum.M128, IntrinsicSignatureEnum.M64BCST };

                case "YMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG };
                case "YMM{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.K };
                case "YMM{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "YMM/M256": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256 };
                case "YMM/M256{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.SAE };
                case "YMM/M256{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "YMM/M256/M32BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.M32BCST };
                case "YMM/M256/M32BCST{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.M32BCST, IntrinsicSignatureEnum.ER };
                case "YMM/M256/M32BCST{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.M32BCST, IntrinsicSignatureEnum.SAE };
                case "YMM/M256/M64BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.YMMREG, IntrinsicSignatureEnum.M256, IntrinsicSignatureEnum.M64BCST };

                case "ZMM": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG };
                case "ZMM{K}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.K };
                case "ZMM{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "ZMM{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.SAE };
                case "ZMM/M512": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "ZMM/M512{K}{Z}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.K, IntrinsicSignatureEnum.Z };
                case "ZMM/M512/M32BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M32BCST };
                case "ZMM/M512/M32BCST{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M32BCST, IntrinsicSignatureEnum.ER };
                case "ZMM/M512/M32BCST{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M32BCST, IntrinsicSignatureEnum.SAE };
                case "ZMM/M512/M64BCST": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M64BCST };
                case "ZMM/M512/M64BCST{ER}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M64BCST, IntrinsicSignatureEnum.ER };
                case "ZMM/M512/M64BCST{SAE}": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.ZMMREG, IntrinsicSignatureEnum.M512, IntrinsicSignatureEnum.M64BCST, IntrinsicSignatureEnum.SAE };

                #endregion

                #region Misc
                case "NEAR": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.NEAR };
                case "FAR": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.FAR };
                case "SHORT": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.SHORT_ENUM };
                case "MEM_OFFS": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM_OFFSET };

                case "BND": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.BNDREG };
                case "BND/M64": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.BNDREG, IntrinsicSignatureEnum.M64 };
                case "BND/M128": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.BNDREG, IntrinsicSignatureEnum.M128 };
                case "MIB": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.MEM };
                #endregion

                case "NONE": return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.NONE };

                default:
                    IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsSignatureHelpSource:parseOperandTypeEnum: unknown content " + str);
                    return new IntrinsicSignatureEnum[] { IntrinsicSignatureEnum.UNKNOWN };
            }
        }
        /// <summary>Get brief description of the operand</summary>
        public static string getDoc(IntrinsicSignatureEnum operandType) {
            switch (operandType) {
                case IntrinsicSignatureEnum.MEM: return "memory operand";
                case IntrinsicSignatureEnum.M8: return "8-bits memory operand";
                case IntrinsicSignatureEnum.M16: return "16-bits memory operand";
                case IntrinsicSignatureEnum.M32: return "32-bits memory operand";
                case IntrinsicSignatureEnum.M64: return "64-bits memory operand";
                case IntrinsicSignatureEnum.M80: return "80-bits memory operand";
                case IntrinsicSignatureEnum.M128: return "128-bits memory operand";
                case IntrinsicSignatureEnum.M256: return "256-bits memory operand";
                case IntrinsicSignatureEnum.M512: return "512-bits memory operand";
                case IntrinsicSignatureEnum.R8: return "8-bits register";
                case IntrinsicSignatureEnum.R16: return "16-bits register";
                case IntrinsicSignatureEnum.R32: return "32-bits register";
                case IntrinsicSignatureEnum.R64: return "64-bits register";
                case IntrinsicSignatureEnum.REG_AL: return "AL register";
                case IntrinsicSignatureEnum.REG_AX: return "AX register";
                case IntrinsicSignatureEnum.REG_EAX: return "EAX register";
                case IntrinsicSignatureEnum.REG_RAX: return "RAX register";
                case IntrinsicSignatureEnum.REG_CL: return "CL register";
                case IntrinsicSignatureEnum.REG_CX: return "CX register";
                case IntrinsicSignatureEnum.REG_ECX: return "ECX register";
                case IntrinsicSignatureEnum.REG_RCX: return "RCX register";
                case IntrinsicSignatureEnum.REG_DX: return "DX register";
                case IntrinsicSignatureEnum.REG_EDX: return "EDX register";
                case IntrinsicSignatureEnum.REG_CS: return "CS register";
                case IntrinsicSignatureEnum.REG_DS: return "DS register";
                case IntrinsicSignatureEnum.REG_ES: return "ES register";
                case IntrinsicSignatureEnum.REG_SS: return "SS register";
                case IntrinsicSignatureEnum.REG_FS: return "FS register";
                case IntrinsicSignatureEnum.REG_GS: return "GS register";
                case IntrinsicSignatureEnum.IMM: return "immediate constant";
                case IntrinsicSignatureEnum.IMM8: return "8-bits immediate constant";
                case IntrinsicSignatureEnum.IMM16: return "16-bits immediate constant";
                case IntrinsicSignatureEnum.IMM32: return "32-bits immediate constant";
                case IntrinsicSignatureEnum.IMM64: return "64-bits immediate constant";
                case IntrinsicSignatureEnum.imm_imm: return "immediate constants";
                case IntrinsicSignatureEnum.imm16_imm: return "immediate constants";
                case IntrinsicSignatureEnum.imm_imm16: return "immediate constants";
                case IntrinsicSignatureEnum.imm32_imm: return "immediate constants";
                case IntrinsicSignatureEnum.imm_imm32: return "immediate constants";
                case IntrinsicSignatureEnum.NEAR: return "near ptr";
                case IntrinsicSignatureEnum.FAR: return "far ptr";
                case IntrinsicSignatureEnum.SHORT_ENUM: return "short ptr";
                case IntrinsicSignatureEnum.UNITY: return "immediate value 1";
                case IntrinsicSignatureEnum.ZERO: return "immediate value 0";

                case IntrinsicSignatureEnum.SAE: return "Optional Suppress All Exceptions {SAE}";
                case IntrinsicSignatureEnum.ER: return "Optional Rounding Mode {RN-SAE}/{RU-SAE}/{RD-SAE}/{RZ-SAE}";
                case IntrinsicSignatureEnum.Z: return "Optional Zero Mask {Z}";

                case IntrinsicSignatureEnum.REG_XMM0: return "XMM0 register";
                case IntrinsicSignatureEnum.XMMREG: return "xmm register";
                case IntrinsicSignatureEnum.YMMREG: return "ymm register";
                case IntrinsicSignatureEnum.ZMMREG: return "zmm register";

                case IntrinsicSignatureEnum.K: return "mask register";

                case IntrinsicSignatureEnum.M32BCST: return "vector broadcasted from a 32-bit memory location";
                case IntrinsicSignatureEnum.M64BCST: return "vector broadcasted from a 64-bit memory location";
                case IntrinsicSignatureEnum.MEM_OFFSET: return "memory offset";
                case IntrinsicSignatureEnum.REG_SREG: return "segment register";
                case IntrinsicSignatureEnum.REG_DREG: return "debug register";
                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: SignatureStore:getDoc: add " + operandType);
                    return operandType.ToString();
                    break;
            }
        }

        public static string ToString(IList<IntrinsicSignatureEnum> list, string concat) {
            int nOperands = list.Count;
            if (nOperands == 0) {
                return "";
            } else if (nOperands == 1) {
                return ToString(list[0]);
            } else {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < nOperands; ++i) {
                    sb.Append(ToString(list[i]));
                    if (i < nOperands - 1) sb.Append(concat);
                }
                return sb.ToString();
            }
        }

        public static string ToString(IntrinsicSignatureEnum operandType) {
            switch (operandType) {

                case IntrinsicSignatureEnum.REG_AL: return "AL";
                case IntrinsicSignatureEnum.REG_AX: return "AX";
                case IntrinsicSignatureEnum.REG_EAX: return "EAX";
                case IntrinsicSignatureEnum.REG_RAX: return "RAX";
                case IntrinsicSignatureEnum.REG_CL: return "CL";
                case IntrinsicSignatureEnum.REG_CX: return "CX";
                case IntrinsicSignatureEnum.REG_ECX: return "ECX";
                case IntrinsicSignatureEnum.REG_RCX: return "RCX";
                case IntrinsicSignatureEnum.REG_DX: return "DX";
                case IntrinsicSignatureEnum.REG_EDX: return "EDX";
                case IntrinsicSignatureEnum.REG_CS: return "CS";
                case IntrinsicSignatureEnum.REG_DS: return "DS";
                case IntrinsicSignatureEnum.REG_ES: return "ES";
                case IntrinsicSignatureEnum.REG_SS: return "SS";
                case IntrinsicSignatureEnum.REG_FS: return "FS";
                case IntrinsicSignatureEnum.REG_GS: return "GS";
                case IntrinsicSignatureEnum.IMM: return "IMM";
                case IntrinsicSignatureEnum.IMM8: return "IMM8";
                case IntrinsicSignatureEnum.IMM16: return "IMM16";
                case IntrinsicSignatureEnum.IMM32: return "IMM32";
                case IntrinsicSignatureEnum.IMM64: return "IMM64";
                case IntrinsicSignatureEnum.imm_imm: return "imm:imm";
                case IntrinsicSignatureEnum.imm16_imm: return "imm16:imm";
                case IntrinsicSignatureEnum.imm_imm16: return "imm:imm16";
                case IntrinsicSignatureEnum.imm32_imm: return "imm32:imm";
                case IntrinsicSignatureEnum.imm_imm32: return "imm:imm32";
                case IntrinsicSignatureEnum.NEAR: return "near";
                case IntrinsicSignatureEnum.FAR: return "far";
                case IntrinsicSignatureEnum.SHORT_ENUM: return "short";
                case IntrinsicSignatureEnum.UNITY: return "unity 1";
                case IntrinsicSignatureEnum.Z: return "z";
                case IntrinsicSignatureEnum.ER: return "er";

                case IntrinsicSignatureEnum.REG_XMM0: return "XMM0";
                case IntrinsicSignatureEnum.XMMREG: return "XMM";
                case IntrinsicSignatureEnum.YMMREG: return "YMM";
                case IntrinsicSignatureEnum.ZMMREG: return "ZMM";

                case IntrinsicSignatureEnum.VM32X: return "xmem32";
                case IntrinsicSignatureEnum.VM64X: return "xmem64";
                case IntrinsicSignatureEnum.VM32Y: return "ymem32";
                case IntrinsicSignatureEnum.VM64Y: return "ymem64";
                case IntrinsicSignatureEnum.VM32Z: return "zmem32";
                case IntrinsicSignatureEnum.VM64Z: return "zmem64";

                case IntrinsicSignatureEnum.M32BCST: return "M32bcst";
                case IntrinsicSignatureEnum.M64BCST: return "M64bcst";
                case IntrinsicSignatureEnum.MEM_OFFSET: return "mem_offs";
                case IntrinsicSignatureEnum.REG_SREG: return "segment register";
                case IntrinsicSignatureEnum.REG_DREG: return "debug register";

                case IntrinsicSignatureEnum.MMXREG: return "XMM";
                case IntrinsicSignatureEnum.BNDREG: return "BND";

                case IntrinsicSignatureEnum.FPUREG: return "fpureg";

                case IntrinsicSignatureEnum.K: return "K";
                case IntrinsicSignatureEnum.SAE: return "{SAE}";

                default:
                   // IntrinsicsDudeToolsStatic.Output("WARNING: AsmSignatureTools:ToString: " + operandType);
                    return operandType.ToString();
            }
        }

        public static bool isAllowedOperand(Operand op, IntrinsicSignatureEnum operandType) {
            switch (operandType) {
                case IntrinsicSignatureEnum.UNKNOWN: return true;
                case IntrinsicSignatureEnum.MEM: return op.isMem;
                case IntrinsicSignatureEnum.M8: return (op.isMem && op.nBits == 8);
                case IntrinsicSignatureEnum.M16: return (op.isMem && op.nBits == 16);
                case IntrinsicSignatureEnum.M32: return (op.isMem && op.nBits == 32);
                case IntrinsicSignatureEnum.M64: return (op.isMem && op.nBits == 64);
                case IntrinsicSignatureEnum.M80: return (op.isMem && op.nBits == 80);
                case IntrinsicSignatureEnum.M128: return (op.isMem && op.nBits == 128);
                case IntrinsicSignatureEnum.M256: return (op.isMem && op.nBits == 256);
                case IntrinsicSignatureEnum.M512: return (op.isMem && op.nBits == 512);

                case IntrinsicSignatureEnum.R8: return (op.isReg && op.nBits == 8);
                case IntrinsicSignatureEnum.R16: return (op.isReg && op.nBits == 16);
                case IntrinsicSignatureEnum.R32: return (op.isReg && op.nBits == 32);
                case IntrinsicSignatureEnum.R64: return (op.isReg && op.nBits == 64);
                case IntrinsicSignatureEnum.REG_AL: return (op.isReg && op.rn == Rn.AL);
                case IntrinsicSignatureEnum.REG_AX: return (op.isReg && op.rn == Rn.AX);
                case IntrinsicSignatureEnum.REG_EAX: return (op.isReg && op.rn == Rn.EAX);
                case IntrinsicSignatureEnum.REG_RAX: return (op.isReg && op.rn == Rn.RAX);
                case IntrinsicSignatureEnum.REG_CL: return (op.isReg && op.rn == Rn.CL);
                case IntrinsicSignatureEnum.REG_CX: return (op.isReg && op.rn == Rn.CX);
                case IntrinsicSignatureEnum.REG_ECX: return (op.isReg && op.rn == Rn.ECX);
                case IntrinsicSignatureEnum.REG_RCX: return (op.isReg && op.rn == Rn.RCX);
                case IntrinsicSignatureEnum.REG_DX: return (op.isReg && op.rn == Rn.DX);
                case IntrinsicSignatureEnum.REG_EDX: return (op.isReg && op.rn == Rn.EDX);
                case IntrinsicSignatureEnum.REG_XMM0: return (op.isReg && op.rn == Rn.XMM0);

                case IntrinsicSignatureEnum.REG_CS: return (op.isReg && op.rn == Rn.CS);
                case IntrinsicSignatureEnum.REG_DS: return (op.isReg && op.rn == Rn.DS);
                case IntrinsicSignatureEnum.REG_ES: return (op.isReg && op.rn == Rn.ES);
                case IntrinsicSignatureEnum.REG_SS: return (op.isReg && op.rn == Rn.SS);
                case IntrinsicSignatureEnum.REG_FS: return (op.isReg && op.rn == Rn.FS);
                case IntrinsicSignatureEnum.REG_GS: return (op.isReg && op.rn == Rn.GS);

                case IntrinsicSignatureEnum.IMM: return op.isImm;
                case IntrinsicSignatureEnum.IMM8: return (op.isImm && op.nBits == 8);
                case IntrinsicSignatureEnum.IMM16: return (op.isImm && op.nBits == 16);
                case IntrinsicSignatureEnum.IMM32: return (op.isImm && op.nBits == 32);
                case IntrinsicSignatureEnum.IMM64: return (op.isImm && op.nBits == 64);

                case IntrinsicSignatureEnum.imm_imm: return true;
                case IntrinsicSignatureEnum.imm16_imm: return true;
                case IntrinsicSignatureEnum.imm_imm16: return true;
                case IntrinsicSignatureEnum.imm32_imm: return true;
                case IntrinsicSignatureEnum.imm_imm32: return true;

                case IntrinsicSignatureEnum.NEAR: return (op.isImm);
                case IntrinsicSignatureEnum.FAR: return (op.isImm);
                case IntrinsicSignatureEnum.SHORT_ENUM: return (op.isImm);
                case IntrinsicSignatureEnum.UNITY: return (op.isImm && (op.imm == 1));

                case IntrinsicSignatureEnum.Z: return false;
                case IntrinsicSignatureEnum.ER: return false;
                case IntrinsicSignatureEnum.SAE: return false;

                case IntrinsicSignatureEnum.K: return (op.isReg && (RegisterTools.isOpmaskRegister(op.rn)));
                case IntrinsicSignatureEnum.XMMREG: return (op.isReg && RegisterTools.isSseRegister(op.rn));
                case IntrinsicSignatureEnum.YMMREG: return (op.isReg && RegisterTools.isAvxRegister(op.rn));
                case IntrinsicSignatureEnum.ZMMREG: return (op.isReg && RegisterTools.isAvx512Register(op.rn));

                case IntrinsicSignatureEnum.M32BCST: return (op.isMem && op.nBits == 32);
                case IntrinsicSignatureEnum.M64BCST: return (op.isMem && op.nBits == 64);
                case IntrinsicSignatureEnum.MEM_OFFSET: return (op.isImm);
                case IntrinsicSignatureEnum.REG_SREG: return (op.isReg && (RegisterTools.isSegmentRegister(op.rn)));
                case IntrinsicSignatureEnum.CR0: return (op.isReg && (op.rn == Rn.CR0));
                case IntrinsicSignatureEnum.CR1: return (op.isReg && (op.rn == Rn.CR1));
                case IntrinsicSignatureEnum.CR2: return (op.isReg && (op.rn == Rn.CR2));
                case IntrinsicSignatureEnum.CR3: return (op.isReg && (op.rn == Rn.CR3));
                case IntrinsicSignatureEnum.CR4: return (op.isReg && (op.rn == Rn.CR4));
                case IntrinsicSignatureEnum.CR5: return (op.isReg && (op.rn == Rn.CR5));
                case IntrinsicSignatureEnum.CR6: return (op.isReg && (op.rn == Rn.CR6));
                case IntrinsicSignatureEnum.CR7: return (op.isReg && (op.rn == Rn.CR7));
                case IntrinsicSignatureEnum.CR8: return (op.isReg && (op.rn == Rn.CR8));
                case IntrinsicSignatureEnum.REG_DREG: return (op.isReg && (RegisterTools.isDebugRegister(op.rn)));
                case IntrinsicSignatureEnum.BNDREG: return (op.isReg && (RegisterTools.isBoundRegister(op.rn)));

                default:
                    IntrinsicsDudeToolsStatic.Output("WARNING: AsmSignatureTools:isAllowed: add " + operandType);
                    break;
            }
            return true;
        }

        public static bool isAllowedMisc(string misc, ISet<IntrinsicSignatureEnum> allowedOperands) {
            switch (misc) {
                case "PTR":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.MEM)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M16)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M32)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M64)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M128)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M256)) return true;
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M512)) return true;
                    break;

                case "BYTE":
                case "SBYTE":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M8)) return true;
                    break;
                case "WORD":
                case "SWORD":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M16)) return true;
                    break;
                case "DWORD":
                case "SDWORD":
                case "REAL4":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M32)) return true;
                    break;
                case "QWORD":
                case "MMWORD":
                case "REAL8":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M64)) return true;
                    break;
                case "TWORD":
                case "TBYTE":
                case "REAL10":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M80)) return true;
                    break;
                case "XMMWORD":
                case "OWORD":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M128)) return true;
                    break;
                case "YMMWORD":
                case "YWORD":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M256)) return true;
                    break;
                case "ZWORD":
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.M512)) return true;
                    break;
                default: break;
            }
            return false;
        }

        public static bool isAllowedReg(Rn regName, ISet<IntrinsicSignatureEnum> allowedOperands) {
            RegisterType type = RegisterTools.getRegisterType(regName);
            switch (type) {
                case RegisterType.UNKNOWN:
                    IntrinsicsDudeToolsStatic.Output("INFO: AsmSignatureTools: isAllowedReg: registername " + regName +" could not be classified");
                    break;
                case RegisterType.BIT8:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.R8)) return true;
                    if ((regName == Rn.AL) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_AL)) return true;
                    if ((regName == Rn.CL) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_CL)) return true;
                    break;
                case RegisterType.BIT16:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.R16)) return true;
                    if ((regName == Rn.AX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_AX)) return true;
                    if ((regName == Rn.CX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_CX)) return true;
                    if ((regName == Rn.DX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_DX)) return true;
                    break;
                case RegisterType.BIT32:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.R32)) return true;
                    if ((regName == Rn.EAX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_EAX)) return true;
                    if ((regName == Rn.ECX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_ECX)) return true;
                    if ((regName == Rn.EDX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_EDX)) return true;
                    break;
                case RegisterType.BIT64:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.R64)) return true;
                    if ((regName == Rn.RAX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_RAX)) return true;
                    if ((regName == Rn.RCX) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_RCX)) return true;
                    break;
                case RegisterType.MMX:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.MMXREG)) return true;
                    break;
                case RegisterType.XMM:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.XMMREG)) return true;
                    if ((regName == Rn.XMM0) && allowedOperands.Contains(IntrinsicSignatureEnum.REG_XMM0)) return true;
                    break;
                case RegisterType.YMM:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.YMMREG)) return true;
                    break;
                case RegisterType.ZMM:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.ZMMREG)) return true;
                    break;
                case RegisterType.OPMASK:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.K)) return true;
                    break;
                case RegisterType.SEGMENT:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_SREG)) return true;
                    switch (regName) {
                        case Rn.CS: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_CS)) return true; break;
                        case Rn.DS: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_DS)) return true; break;
                        case Rn.ES: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_ES)) return true; break;
                        case Rn.SS: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_SS)) return true; break;
                        case Rn.FS: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_FS)) return true; break;
                        case Rn.GS: if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_GS)) return true; break;
                    }
                    break;
                case RegisterType.CONTROL:
                    if ((regName == Rn.CR0) && allowedOperands.Contains(IntrinsicSignatureEnum.CR0)) return true;
                    if ((regName == Rn.CR1) && allowedOperands.Contains(IntrinsicSignatureEnum.CR1)) return true;
                    if ((regName == Rn.CR2) && allowedOperands.Contains(IntrinsicSignatureEnum.CR2)) return true;
                    if ((regName == Rn.CR3) && allowedOperands.Contains(IntrinsicSignatureEnum.CR3)) return true;
                    if ((regName == Rn.CR4) && allowedOperands.Contains(IntrinsicSignatureEnum.CR4)) return true;
                    if ((regName == Rn.CR5) && allowedOperands.Contains(IntrinsicSignatureEnum.CR5)) return true;
                    if ((regName == Rn.CR6) && allowedOperands.Contains(IntrinsicSignatureEnum.CR6)) return true;
                    if ((regName == Rn.CR7) && allowedOperands.Contains(IntrinsicSignatureEnum.CR7)) return true;
                    if ((regName == Rn.CR8) && allowedOperands.Contains(IntrinsicSignatureEnum.CR8)) return true;
                    break;
                case RegisterType.DEBUG:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.REG_DREG)) return true;
                    break;
                case RegisterType.BOUND:
                    if (allowedOperands.Contains(IntrinsicSignatureEnum.BNDREG)) return true;
                    break;
                default:
                    break;
            }
            return false;
        }

    }
}
