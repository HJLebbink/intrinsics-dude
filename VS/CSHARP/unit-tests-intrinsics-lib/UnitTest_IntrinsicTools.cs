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
            bool is_capitals = false;
            bool warn = true;

            foreach (ReturnType x in Enum.GetValues(typeof(ReturnType)))
            {
                string str = IntrinsicTools.ToString(x);
                ReturnType x2 = ParseReturnType(str, is_capitals, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "ReturnType " + x.ToString() + " does not yield the same enumeration.");
                }
            }
        }

        [TestMethod]
        public void TestParamType()
        {
            bool is_capitals = false;
            bool warn = true;

            foreach (ParamType x in Enum.GetValues(typeof(ParamType)))
            {
                string str = IntrinsicTools.ToString(x);
                ParamType x2 = ParseParamType(str, is_capitals, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestParamType=" + x.ToString() + "; toString="+str+"; parse="+ x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestParamType_InternalName()
        {
            bool warn = true;

            foreach (ParamType x in Enum.GetValues(typeof(ParamType)))
            {
                string str = x.ToString();
                ParamType x2 = ParseParamType_InternalName(str, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestParamType_InternalName=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestCpuID()
        {
            bool is_capitals = true;
            bool warn = true;

            foreach (CpuID x in Enum.GetValues(typeof(CpuID)))
            {
                string str = IntrinsicTools.ToString(x);
                CpuID x2 = ParseCpuID(str, is_capitals, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestCpuID=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestSimdRegisterType()
        {
            bool is_capitals = true;
            bool warn = true;

            foreach (SimdRegisterType x in Enum.GetValues(typeof(SimdRegisterType)))
            {
                string str = x.ToString();
                SimdRegisterType x2 = ParseSimdRegisterType(str, is_capitals, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestSimdRegisterType=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }

        [TestMethod]
        public void TestIntrinsicEnum()
        {
            bool is_capitals = true;
            bool warn = true;

            foreach (Intrinsic x in Enum.GetValues(typeof(Intrinsic)))
            {
                string str = x.ToString();
                Intrinsic x2 = ParseIntrinsic(str, is_capitals, warn);
                if (x != x2)
                {
                    Assert.AreEqual(x, x2, "TestSimdRegisterType=" + x.ToString() + "; toString=" + str + "; parse=" + x2 + ".");
                }
            }
        }
    }
}
