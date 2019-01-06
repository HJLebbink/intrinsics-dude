using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntrinsicsDude.Tools;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace intrinsics_dude_unit_tests
{
    [TestClass]
    public class UnitTest_IntrinsicTools
    {
        [TestMethod]
        public void TestReturnType()
        {
            foreach (ReturnType x in Enum.GetValues(typeof(ReturnType)))
            {
                string str = IntrinsicTools.ToString(x);
                ReturnType x2 = ParseReturnType(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "ReturnType " + x.ToString() + " does not yield the same enumeration.");
                }
            }
        }

        [TestMethod]
        public void TestParamType()
        {
            foreach (ParamType x in Enum.GetValues(typeof(ParamType)))
            {
                string str = IntrinsicTools.ToString(x);
                ParamType x2 = ParseParamType(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestParamType=" + x.ToString() + "; toString="+str+"; parse="+ x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestParamType_InternalName()
        {
            foreach (ParamType x in Enum.GetValues(typeof(ParamType)))
            {
                string str = x.ToString();
                ParamType x2 = ParseParamType_InternalName(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestParamType_InternalName=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestCpuID()
        {
            foreach (CpuID x in Enum.GetValues(typeof(CpuID)))
            {
                string str = IntrinsicTools.ToString(x);
                CpuID x2 = ParseCpuID(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestCpuID=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestSimdRegisterType()
        {
            foreach (SimdRegisterType x in Enum.GetValues(typeof(SimdRegisterType)))
            {
                string str = x.ToString();
                SimdRegisterType x2 = ParseSimdRegisterType(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestSimdRegisterType=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestIntrinsicEnum()
        {
            foreach (Intrinsic x in Enum.GetValues(typeof(Intrinsic)))
            {
                string str = x.ToString();
                Intrinsic x2 = ParseIntrinsic(str);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestSimdRegisterType=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }
    }
}
