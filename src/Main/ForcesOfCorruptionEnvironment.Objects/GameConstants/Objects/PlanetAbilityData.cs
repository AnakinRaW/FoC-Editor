using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using ForcesOfCorruptionEnvironment.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PlanetAbilityData : XmlTagCategory
    {
        public PlanetAbilityData(IAlomoXmlFile file) : base(file) {}

        public EngineStringTupel Planet_Ability_Icon_Names { get; set; }
        public EngineStringTupel Planet_Ability_Text_IDs { get; set; }

        public PlanetAbilityRgbList Planet_Ability_RGBs { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Planet_Ability_Icon_Names), Planet_Ability_Icon_Names.ToString(EngineSparators.Comma, true));
            node.SetValueOfLastTagOfName(nameof(Planet_Ability_Text_IDs), Planet_Ability_Text_IDs.ToString(EngineSparators.Comma, true));
            node.SetValueOfLastTagOfName(nameof(Planet_Ability_RGBs), Planet_Ability_RGBs.ToString(true));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Planet_Ability_Icon_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Planet_Ability_Icon_Names)));
            Planet_Ability_Text_IDs = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Planet_Ability_Text_IDs)));
            Planet_Ability_RGBs =
                PlanetAbilityRgbList.CreateFromString(node.GetValueOfLastTagOfName(nameof(Planet_Ability_RGBs)));
        }
    }
}
