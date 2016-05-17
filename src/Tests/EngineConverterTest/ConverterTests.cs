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

            Assert.AreEqual(-1.05, "  -1.050000f  ".ToEngineFloat());
            Assert.AreEqual(1.05, "1.05f".ToEngineFloat());
            Assert.AreEqual(0.05, ".05f".ToEngineFloat());
        }

        [TestMethod]
        public void ColorToStringTest()
        {
            var color = new EngineColor(100, 100, 100, byte.MaxValue);

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

        [TestMethod]
        public void FloatTupelTest()
        {
            var t = new EngineFloatTupel(6, -0.1,0.1,3,4,5,6);

            Assert.AreEqual("-0.1,0.1,3,4,5,6", t.ToString());
            Assert.AreEqual("-0.1 0.1 3 4 5 6", t.ToString(EngineSparators.Space));
            Assert.AreEqual("-0.1|0.1|3|4|5|6", t.ToString(EngineSparators.VerticalLine));

            var s = ".1,5,4,3,2,1";
            Assert.AreEqual("0.1,5,4,3,2,1", EngineFloatTupel.CreateFromString(s).ToString());
        }

        [TestMethod]
        public void IntTest()
        {
            Assert.AreEqual(1, "1".ToInteger());
            Assert.AreEqual(-1, "-1".ToInteger());
            Assert.AreEqual(1, "1.0".ToInteger());
        }


        [TestMethod]
        public void StringTupelTest()
        {
            var t = new EngineStringTupel(3, "1", "2", "3");

            Assert.AreEqual("1,2,3", t.ToString());
            Assert.AreEqual("1 2 3", t.ToString(EngineSparators.Space));
            Assert.AreEqual("1|2|3", t.ToString(EngineSparators.VerticalLine));

            var s = "Das Ist ein Test";
            Assert.AreEqual("Das,Ist,ein,Test", EngineStringTupel.CreateFromString(s).ToString());
            Assert.AreEqual("Das Ist ein Test", EngineStringTupel.CreateFromString(s).ToString(EngineSparators.Space));
        }

        [TestMethod]
        public void HardPointImageTest()
        {
            var t = new HardPointTextureAssociation(HardPointType.HARD_POINT_ENGINE, "test");

            Assert.AreEqual("HARD_POINT_ENGINE, test", t.ToString());


            var s = " HARD_POINT_ENGINE  , test  ";
            Assert.AreEqual("HARD_POINT_ENGINE, test", HardPointTextureAssociation.CreateFromString(s).ToString());
        }
    }
}
