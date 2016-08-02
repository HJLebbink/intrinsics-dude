using AsmTools;
using System;
using System.Collections.Generic;
using static Intrinsics.IntrinsicTools;

namespace Intrinsics
{
    public class IntrinsicDataElement
    {
        public Intrinsic intrinsic;
        public ReturnType returnType;
        public IList<Tuple<ParamType, string>> parameters;
        public CpuID cpuID;
        public int id;
        public Mnemonic instruction;
        public bool isSVML;

        public string description;
        public string performance;
        public string operation;
    }
}
