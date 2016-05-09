using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class GameConstantsValidationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var validator = new XmlValidator(ForcesOfCorruptionModdingTool.AlomoEngine.Properties.Resources.Gameconstants.ToStream());

            Assert.IsTrue(validator.Validate(@"C:\Test\Gameconstants.xml"));
        }
    }
}
