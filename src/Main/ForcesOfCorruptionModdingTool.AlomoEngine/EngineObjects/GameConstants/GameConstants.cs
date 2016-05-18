using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Behaviour;
using ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Engine;
using ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.GUI;
using ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Objects;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    public sealed class GameConstants : GameXmlFile
    {
        public GameConstants(IGameXmlFile parent) : base(parent) {}

        public GameConstants() : base(null) {}

        public DebugHotKeyLoadData DebugHotKeyLoadData { get; private set; }

        public GameConstantsData GameConstantsData { get; private set; }

        public ObjectMaximumMultipliers ObjectMaximumMultipliers { get; private set; }

        public PlayerFactionData PlayerFactionData { get; private set; }

        public ShipLoadVulnerabilityData ShipLoadVulnerabilityData { get; private set; }

        public GalacticFleetMovementData GalacticFleetMovementData { get; private set; }

        public GameScrollData GameScrollData { get; private set; }

        public GalacticEconomyData GalacticEconomyData { get; private set; }

        public PlanetaryCorruptionConstants PlanetaryCorruptionConstants { get; private set; }

        public GalacticModeCamera GalacticModeCamera { get; private set; }

        public GuiGameConstantsData GuiGameConstantsData { get; private set; }

        public AutoResolveData AutoResolveData { get; private set; }

        public GameTypographyData GameTypographyData { get; private set; }

        public RandomStoryGenerationData RandomStoryGenerationData { get; private set; }

        public HardPointData HardPointData { get; private set; }

        public FowData FowData { get; private set; }

        public AiData AiData { get; private set; }

        public PathFindingMovementData PathFindingMovementData { get; set; }


        public override void Deserialize(XmlDocument document)
        {
            base.Deserialize(document);
            DebugHotKeyLoadData = new DebugHotKeyLoadData(this);
            DebugHotKeyLoadData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData(this);
            GameConstantsData.Deserialize(RootNode);

            ObjectMaximumMultipliers = new ObjectMaximumMultipliers(this);
            ObjectMaximumMultipliers.Deserialize(RootNode);

            PlayerFactionData = new PlayerFactionData(this);
            PlayerFactionData.Deserialize(RootNode);

            ShipLoadVulnerabilityData = new ShipLoadVulnerabilityData(this);
            ShipLoadVulnerabilityData.Deserialize(RootNode);

            GalacticFleetMovementData = new GalacticFleetMovementData(this);
            GalacticFleetMovementData.Deserialize(RootNode);

            GameScrollData = new GameScrollData(this);
            GameScrollData.Deserialize(RootNode);

            GalacticEconomyData = new GalacticEconomyData(this);
            GalacticEconomyData.Deserialize(RootNode);

            PlanetaryCorruptionConstants = new PlanetaryCorruptionConstants(this);
            PlanetaryCorruptionConstants.Deserialize(RootNode);

            GalacticModeCamera = new GalacticModeCamera(this);
            GalacticModeCamera.Deserialize(RootNode);

            GuiGameConstantsData = new GuiGameConstantsData(this);
            GuiGameConstantsData.Deserialize(RootNode);

            AutoResolveData = new AutoResolveData(this);
            AutoResolveData.Deserialize(RootNode);

            GameTypographyData = new GameTypographyData(this);
            GameTypographyData.Deserialize(RootNode);

            RandomStoryGenerationData = new RandomStoryGenerationData(this);
            RandomStoryGenerationData.Deserialize(RootNode);

            HardPointData = new HardPointData(this);
            HardPointData.Deserialize(RootNode);

            FowData = new FowData(this);
            FowData.Deserialize(RootNode);

            AiData = new AiData(this);
            AiData.Deserialize(RootNode);

            PathFindingMovementData = new PathFindingMovementData(this);
            PathFindingMovementData.Deserialize(RootNode);
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Serialize()
        {
            RootNode = DebugHotKeyLoadData.Serialize();
            RootNode = GameConstantsData.Serialize();
            RootNode = ObjectMaximumMultipliers.Serialize();
            RootNode = PlayerFactionData.Serialize();
            RootNode = ShipLoadVulnerabilityData.Serialize();
            RootNode = GalacticFleetMovementData.Serialize();
            RootNode = GameScrollData.Serialize();
            RootNode = GalacticEconomyData.Serialize();
            RootNode = PlanetaryCorruptionConstants.Serialize();
            RootNode = GalacticModeCamera.Serialize();
            RootNode = GuiGameConstantsData.Serialize();
            RootNode = AutoResolveData.Serialize();
            RootNode = GameTypographyData.Serialize();
            RootNode = RandomStoryGenerationData.Serialize();
            RootNode = HardPointData.Serialize();
            RootNode = FowData.Serialize();
            RootNode = AiData.Serialize();
            RootNode = PathFindingMovementData.Serialize();
            return RootNode;
        }
    }
}