using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrinsicsDude.Tools
{
    public enum Intrinsic
    {
        NONE,

        _mm_add_pd,
        _mm_add_ps
    }

    public static partial class IntrinsicTools
    {
        public static Intrinsic parseIntrinsic(string str) 
        {
            switch (str.ToUpper()) 
            {
                case "_MM_ADD_PD": return Intrinsic._mm_add_pd;
                case "_MM_ADD_PS": return Intrinsic._mm_add_ps;
                default: return Intrinsic.NONE;
            }
        }
    }
}