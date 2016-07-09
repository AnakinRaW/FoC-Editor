using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    public class EngineGameConstantsData : AbstractXmlTagCategory
    {
        public EngineGameConstantsData(IAlomoXmlFile file) : base(file) {}

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
            return File.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            AiData = new AiData(File);
            AiData.Deserialize(node);

            AutoResolveData = new AutoResolveData(File);
            AutoResolveData.Deserialize(node);

            DebugHotKeyLoadData = new DebugHotKeyLoadData(File);
            DebugHotKeyLoadData.Deserialize(node);

            GalacticModeCamera = new GalacticModeCamera(File);
            GalacticModeCamera.Deserialize(node);

            GameScrollData = new GameScrollData(File);
            GameScrollData.Deserialize(node);

            MultiplayerData = new MultiplayerData(File);
            MultiplayerData.Deserialize(node);

            PathFindingMovementData = new PathFindingMovementData(File);
            PathFindingMovementData.Deserialize(node);
        }
    }
}
