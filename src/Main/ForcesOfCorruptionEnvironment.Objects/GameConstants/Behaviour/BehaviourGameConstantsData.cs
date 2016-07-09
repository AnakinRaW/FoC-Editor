using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml.Layout;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    public class BehaviourGameConstantsData : AbstractXmlTagCategory
    {
        public BehaviourGameConstantsData(IAlomoXmlFile file) : base(file) {}

        public AbilityEffectData AbilityEffectData { get; set; }

        public BountyAwardData BountyAwardData { get; set; }

        public CorruptionData CorruptionData { get; set; }

        public ShipLoadVulnerabilityData ShipLoadVulnerabilityData { get; set; }

        public GalacticFleetMovementData GalacticFleetMovementData { get; set; }

        public GalacticEconomyData GalacticEconomyData { get; set; }

        public GalacticGuiUnitAbilityData GalacticGuiUnitAbilityData { get; set; }

        public RandomStoryGenerationData RandomStoryGenerationData { get; set; }


        public override XmlElement Serialize()
        {
            GalacticGuiUnitAbilityData.Serialize();
            AbilityEffectData.Serialize();
            RandomStoryGenerationData.Serialize();
            BountyAwardData.Serialize();
            CorruptionData.Serialize();
            ShipLoadVulnerabilityData.Serialize();
            GalacticFleetMovementData.Serialize();
            GalacticEconomyData.Serialize();
            return File.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            ShipLoadVulnerabilityData = new ShipLoadVulnerabilityData(File);
            ShipLoadVulnerabilityData.Deserialize(node);

            GalacticFleetMovementData = new GalacticFleetMovementData(File);
            GalacticFleetMovementData.Deserialize(node);


            GalacticEconomyData = new GalacticEconomyData(File);
            GalacticEconomyData.Deserialize(node);

            RandomStoryGenerationData = new RandomStoryGenerationData(File);
            RandomStoryGenerationData.Deserialize(node);

            AbilityEffectData = new AbilityEffectData(File);
            AbilityEffectData.Deserialize(node);

            GalacticGuiUnitAbilityData = new GalacticGuiUnitAbilityData(File);
            GalacticGuiUnitAbilityData.Deserialize(node);

            BountyAwardData = new BountyAwardData(File);
            BountyAwardData.Deserialize(node);

            CorruptionData = new CorruptionData(File);
            CorruptionData.Deserialize(node);
        }
    }
}
