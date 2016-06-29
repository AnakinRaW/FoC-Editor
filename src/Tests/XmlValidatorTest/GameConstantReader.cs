using AlomoEngine.Xml;
using ForcesOfCorruptionEnvironment.Objects.GameConstants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XmlValidatorTest
{
    [TestClass]
    public class GameConstantReader
    {

        private GameConstants Gc { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            var parser = new XmlToObjectParser<GameConstants>(@"C:\Test\Gameconstants.xml");
            Gc = parser.Parse();
        }

        [TestMethod]
        public void CorrectRootNode()
        {
            Assert.AreEqual("GameConstants", Gc.RootNode.Name);
        }

        [TestMethod]
        public void CorrectDataFill()
        {
            Assert.AreEqual(5, Gc.EngineGameConstantsData.DebugHotKeyLoadData.Debug_Hot_Key_Load_Map.Count);
            Assert.AreEqual(1, Gc.EngineGameConstantsData.DebugHotKeyLoadData.Debug_Hot_Key_Load_Campaign.Count);
            Assert.AreEqual(4, Gc.EngineGameConstantsData.DebugHotKeyLoadData.Debug_Hot_Key_Load_Map_Script.Count);
            Assert.IsTrue(Gc.GameConstantsData.Strategic_Queue_Tactical_Battles);
        }
    }
}
