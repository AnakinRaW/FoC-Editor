using AlomoEngine.EngineTypes;
using AlomoEngine.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class XmlChildParser
    {
        private AlomoXmlFile File1 { get; set; }
        private AlomoXmlFile File2 { get; set; }
        private AlomoXmlFile File3 { get; set; }
        private AlomoXmlFile File4 { get; set; }
        private AlomoXmlFile File5 { get; set; }
        private AlomoXmlFile File6 { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Blackmarketitems.xml");
            File1 = parser.Parse();

            parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Gameconstants.xml");
            File2 = parser.Parse();

            parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Aiterraineffectiveness.xml");
            File3 = parser.Parse();

            parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Campaigns_main.xml");
            File4 = parser.Parse();

            parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Weatherscenarios.xml");
            File5 = parser.Parse();

            parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Weathermodifiers.xml");
            File6 = parser.Parse();
        }

        [TestMethod]
        public void CorrectRootNode()
        {
            Assert.AreEqual(10, File1.Childs.Count);
            Assert.AreEqual(0, File2.Childs.Count);
            Assert.AreEqual(7, File3.Childs.Count);
            Assert.AreEqual(2, File4.Childs.Count);
            Assert.AreEqual(13, File5.Childs.Count);
            Assert.AreEqual(5, File6.Childs.Count);
        }
    }
}
