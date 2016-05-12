using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    public class GameConstants : GameXmlFile
    {
        public GameConstants(IGameXmlFile parent) : base(parent) {}

        public GameConstants() : base(null) {}

        public DebugHotKeyLoadData DebugHotKeyLoadData { get; protected set; }

        public GameConstantsData GameConstantsData { get; protected set; }

        public override void Deserialize(XmlDocument document)
        {
            base.Deserialize(document);
            DebugHotKeyLoadData = new DebugHotKeyLoadData(this);
            DebugHotKeyLoadData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData(this);
            GameConstantsData.Deserialize(RootNode);
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Serialize()
        {
            RootNode = DebugHotKeyLoadData.Serialize();
            RootNode = GameConstantsData.Serialize();
            return RootNode;
        }
    }
}