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

        public ObjectMultiplierData ObjectMultiplierData { get; private set; }

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

        public AbilityEffectData AbilityEffectData { get; set; }

        public GameObjectConstantData GameObjectConstantData { get; set; }

        public DamageArmorMatrixData DamageArmorMatrixData { get; set; }

        public GalacticGuiUnitAbilityData GalacticGuiUnitAbilityData { get; set; }

        public MultiplayerData MultiplayerData { get; set; }

        public BeamAbilityData BeamAbilityData { get; set; }

        public LocalizationData LocalizationData { get; set; }

        public GameCreditsData GameCreditsData { get; set; }

        public PlanetAbilityData PlanetAbilityData { get; set; }

        public CommandBarGuiData CommandBarGuiData { get; set; }

        public BombardmentData BombardmentData { get; set; }

        public BountyAwardData BountyAwardData { get; set; }

        public CorruptionData CorruptionData { get; set; }

        public override void Deserialize(XmlDocument document)
        {
            base.Deserialize(document);
            DebugHotKeyLoadData = new DebugHotKeyLoadData(this);
            DebugHotKeyLoadData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData(this);
            GameConstantsData.Deserialize(RootNode);

            ObjectMultiplierData = new ObjectMultiplierData(this);
            ObjectMultiplierData.Deserialize(RootNode);

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

            AbilityEffectData = new AbilityEffectData(this);
            AbilityEffectData.Deserialize(RootNode);

            GameObjectConstantData = new GameObjectConstantData(this);
            GameObjectConstantData.Deserialize(RootNode);

            DamageArmorMatrixData = new DamageArmorMatrixData(this);
            DamageArmorMatrixData.Deserialize(RootNode);

            GalacticGuiUnitAbilityData = new GalacticGuiUnitAbilityData(this);
            GalacticGuiUnitAbilityData.Deserialize(RootNode);

            MultiplayerData = new MultiplayerData(this);
            MultiplayerData.Deserialize(RootNode);

            BeamAbilityData = new BeamAbilityData(this);
            BeamAbilityData.Deserialize(RootNode);

            LocalizationData = new LocalizationData(this);
            LocalizationData.Deserialize(RootNode);

            GameCreditsData = new GameCreditsData(this);
            GameCreditsData.Deserialize(RootNode);

            PlanetAbilityData = new PlanetAbilityData(this);
            PlanetAbilityData.Deserialize(RootNode);

            CommandBarGuiData = new CommandBarGuiData(this);
            CommandBarGuiData.Deserialize(RootNode);

            BombardmentData = new BombardmentData(this);
            BombardmentData.Deserialize(RootNode);

            BountyAwardData = new BountyAwardData(this);
            BountyAwardData.Deserialize(RootNode);

            CorruptionData = new CorruptionData(this);
            CorruptionData.Deserialize(RootNode);
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override XmlElement Serialize()
        {
            RootNode = DebugHotKeyLoadData.Serialize();
            RootNode = GameConstantsData.Serialize();
            RootNode = ObjectMultiplierData.Serialize();
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
            RootNode = AbilityEffectData.Serialize();
            RootNode = GameObjectConstantData.Serialize();
            RootNode = DamageArmorMatrixData.Serialize();
            RootNode = GalacticGuiUnitAbilityData.Serialize();
            RootNode = MultiplayerData.Serialize();
            RootNode = BeamAbilityData.Serialize();
            RootNode = LocalizationData.Serialize();
            RootNode = GameCreditsData.Serialize();
            RootNode = PlanetAbilityData.Serialize();
            RootNode = CommandBarGuiData.Serialize();
            RootNode = BombardmentData.Serialize();
            RootNode = BountyAwardData.Serialize();
            RootNode = CorruptionData.Serialize();
            return RootNode;
        }
    }
}