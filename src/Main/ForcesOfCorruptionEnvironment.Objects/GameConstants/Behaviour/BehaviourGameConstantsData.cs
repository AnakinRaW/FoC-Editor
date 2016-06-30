using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    public class BehaviourGameConstantsData : EngineObject
    {
        public BehaviourGameConstantsData(IAlomoXmlFile parent) : base(parent) {}

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
            return Parent.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            ShipLoadVulnerabilityData = new ShipLoadVulnerabilityData(Parent);
            ShipLoadVulnerabilityData.Deserialize(node);

            GalacticFleetMovementData = new GalacticFleetMovementData(Parent);
            GalacticFleetMovementData.Deserialize(node);


            GalacticEconomyData = new GalacticEconomyData(Parent);
            GalacticEconomyData.Deserialize(node);

            RandomStoryGenerationData = new RandomStoryGenerationData(Parent);
            RandomStoryGenerationData.Deserialize(node);

            AbilityEffectData = new AbilityEffectData(Parent);
            AbilityEffectData.Deserialize(node);

            GalacticGuiUnitAbilityData = new GalacticGuiUnitAbilityData(Parent);
            GalacticGuiUnitAbilityData.Deserialize(node);

            BountyAwardData = new BountyAwardData(Parent);
            BountyAwardData.Deserialize(node);

            CorruptionData = new CorruptionData(Parent);
            CorruptionData.Deserialize(node);
        }
    }
}
