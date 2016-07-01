using AlomoEngine.EngineTypes;
using AlomoEngine.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class XmlFileReader
    {

        private AlomoXmlFile File { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var parser = new XmlToObjectParser<AlomoXmlFile>(@"C:\Test\Blackmarketitems.xml");
            File = parser.Parse();
        }

        [TestMethod]
        public void CorrectRootNode()
        {
            Assert.AreEqual("BlackMarketItems", File.RootNode.Name);
        }
    }
}
