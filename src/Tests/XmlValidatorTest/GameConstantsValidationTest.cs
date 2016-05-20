using AlomoEngine.Core;
using AlomoEngine.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class GameConstantsValidationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var validator = new XmlValidator(AlomoEngine.Objects.Properties.Resources.Gameconstants.ToStream());

            Assert.IsTrue(validator.Validate(@"C:\Test\Gameconstants1.xml"));
        }
    }
}