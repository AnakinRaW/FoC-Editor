using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    public class GameObjectsConstantsData : EngineObject
    {
        public GameObjectsConstantsData(IAlomoXmlFile parent) : base(parent) {}

        public ObjectMultiplierData ObjectMultiplierData { get; set; }

        public PlayerFactionData PlayerFactionData { get; set; }

        public PlanetaryCorruptionConstants PlanetaryCorruptionConstants { get; set; }

        public HardPointData HardPointData { get; set; }

        public GeneralObjectData GameObjectConstantData { get; set; }

        public DamageArmorMatrixData DamageArmorMatrixData { get; set; }

        public BeamAbilityData BeamAbilityData { get; set; }

        public PlanetAbilityData PlanetAbilityData { get; set; }

        public BombardmentData BombardmentData { get; set; }

        public override XmlElement Serialize()
        {
            ObjectMultiplierData.Serialize();
            PlayerFactionData.Serialize();
            PlanetaryCorruptionConstants.Serialize();
            HardPointData.Serialize();
            DamageArmorMatrixData.Serialize();
            BeamAbilityData.Serialize();
            PlanetAbilityData.Serialize();
            BombardmentData.Serialize();
            return Parent.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            ObjectMultiplierData = new ObjectMultiplierData(Parent);
            ObjectMultiplierData.Deserialize(node);

            PlayerFactionData = new PlayerFactionData(Parent);
            PlayerFactionData.Deserialize(node);

            PlanetaryCorruptionConstants = new PlanetaryCorruptionConstants(Parent);
            PlanetaryCorruptionConstants.Deserialize(node);

            HardPointData = new HardPointData(Parent);
            HardPointData.Deserialize(node);

            DamageArmorMatrixData = new DamageArmorMatrixData(Parent);
            DamageArmorMatrixData.Deserialize(node);

            BeamAbilityData = new BeamAbilityData(Parent);
            BeamAbilityData.Deserialize(node);

            PlanetAbilityData = new PlanetAbilityData(Parent);
            PlanetAbilityData.Deserialize(node);

            BombardmentData = new BombardmentData(Parent);
            BombardmentData.Deserialize(node);
        }
    }
}
