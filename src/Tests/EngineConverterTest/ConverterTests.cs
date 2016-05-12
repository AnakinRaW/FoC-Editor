using System;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineConverterTest
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void BooleanTest()
        {
            Assert.IsTrue("true".ToEngineBoolean());
            Assert.IsTrue(" true ".ToEngineBoolean());
            Assert.IsTrue("True".ToEngineBoolean());
            Assert.IsTrue("TrUe".ToEngineBoolean());
            Assert.IsTrue("Yes".ToEngineBoolean());

            Assert.IsFalse("False".ToEngineBoolean());
            Assert.IsFalse("   False   ".ToEngineBoolean());
            Assert.IsFalse("FalsE".ToEngineBoolean());
            Assert.IsFalse("no ".ToEngineBoolean());

        }

        [TestMethod]
        public void FloatTest()
        {
            Assert.AreEqual(0.05, ".05".ToEngineFloat());
            Assert.AreEqual(0.05, "0.05".ToEngineFloat());
            Assert.AreEqual(-0.05, "-.05".ToEngineFloat());

            Assert.AreEqual(-1.05f, "  -1.050000f  ".ToEngineFloat());
            Assert.AreEqual(1.05f, "1.05f".ToEngineFloat());
            Assert.AreEqual(0.05f, ".05f".ToEngineFloat());
        }

        [TestMethod]
        public void ColorToStringTest()
        {
            var color = new EngineColor(100, 100, 100, Byte.MaxValue);

            Assert.AreEqual("100, 100, 100, 255", color.ToString());
            Assert.AreEqual("100, 100, 100", color.ToString(false));

            Assert.AreEqual("100 100 100", color.ToString(EngineSparators.Space, false));
            Assert.AreEqual("100 100 100 255", color.ToString(EngineSparators.Space));
        }

        [TestMethod]
        public void StringToColorTest()
        {
            var s = "100, 100, 100, 255";

            var color = EngineColor.CreateColorFromString(s);

            Assert.AreEqual(100, color.Red);
            Assert.AreEqual(100, color.Green);
            Assert.AreEqual(100, color.Blue);
            Assert.AreEqual(byte.MaxValue, color.Alpha);

            var s2 = "111, 111, 111";

            var color2 = EngineColor.CreateColorFromString(s2);

            Assert.AreEqual(111, color2.Red);
            Assert.AreEqual(111, color2.Green);
            Assert.AreEqual(111, color2.Blue);


            Assert.AreEqual("111, 111, 111, 255", color2.ToString());
            Assert.AreEqual("111, 111, 111", color2.ToString(false));

            Assert.AreEqual("111 111 111", color2.ToString(EngineSparators.Space, false));
            Assert.AreEqual("111 111 111 255", color2.ToString(EngineSparators.Space));
        }
    }
}
