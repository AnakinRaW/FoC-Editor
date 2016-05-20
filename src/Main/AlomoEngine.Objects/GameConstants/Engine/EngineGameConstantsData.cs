using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Objects.GameConstants.Engine
{
    public class EngineGameConstantsData : EngineObject
    {
        public EngineGameConstantsData(IGameXmlFile parent) : base(parent) {}

        public AiData AiData { get; set; }
        public AutoResolveData AutoResolveData { get; set; }
        public DebugHotKeyLoadData DebugHotKeyLoadData { get; set; }
        public GalacticModeCamera GalacticModeCamera { get; set; }
        public GameScrollData GameScrollData { get; set; }
        public MultiplayerData MultiplayerData { get; set; }
        public PathFindingMovementData PathFindingMovementData { get; set; }

        public override XmlElement Serialize()
        {
            AiData.Serialize();
            AutoResolveData.Serialize();
            DebugHotKeyLoadData.Serialize();
            GalacticModeCamera.Serialize();
            GameScrollData.Serialize();
            MultiplayerData.Serialize();
            PathFindingMovementData.Serialize();
            return Parent.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            AiData = new AiData(Parent);
            AiData.Deserialize(node);

            AutoResolveData = new AutoResolveData(Parent);
            AutoResolveData.Deserialize(node);

            DebugHotKeyLoadData = new DebugHotKeyLoadData(Parent);
            DebugHotKeyLoadData.Deserialize(node);

            GalacticModeCamera = new GalacticModeCamera(Parent);
            GalacticModeCamera.Deserialize(node);

            GameScrollData = new GameScrollData(Parent);
            GameScrollData.Deserialize(node);

            MultiplayerData = new MultiplayerData(Parent);
            MultiplayerData.Deserialize(node);

            PathFindingMovementData = new PathFindingMovementData(Parent);
            PathFindingMovementData.Deserialize(node);
        }
    }
}
