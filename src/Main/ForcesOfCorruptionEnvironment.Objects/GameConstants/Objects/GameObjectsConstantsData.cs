using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    public class GameObjectsConstantsData : XmlTagCategory
    {
        public GameObjectsConstantsData(IAlomoXmlFile file) : base(file) {}

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
            return File.RootNode;
        }

        public override void Deserialize(XmlElement node)
        {
            ObjectMultiplierData = new ObjectMultiplierData(File);
            ObjectMultiplierData.Deserialize(node);

            PlayerFactionData = new PlayerFactionData(File);
            PlayerFactionData.Deserialize(node);

            PlanetaryCorruptionConstants = new PlanetaryCorruptionConstants(File);
            PlanetaryCorruptionConstants.Deserialize(node);

            HardPointData = new HardPointData(File);
            HardPointData.Deserialize(node);

            DamageArmorMatrixData = new DamageArmorMatrixData(File);
            DamageArmorMatrixData.Deserialize(node);

            BeamAbilityData = new BeamAbilityData(File);
            BeamAbilityData.Deserialize(node);

            PlanetAbilityData = new PlanetAbilityData(File);
            PlanetAbilityData.Deserialize(node);

            BombardmentData = new BombardmentData(File);
            BombardmentData.Deserialize(node);
        }
    }
}
