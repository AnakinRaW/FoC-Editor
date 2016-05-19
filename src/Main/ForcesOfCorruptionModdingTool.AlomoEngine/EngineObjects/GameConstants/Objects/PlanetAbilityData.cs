using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes.Enums;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PlanetAbilityData : EngineObject
    {
        public PlanetAbilityData(IGameXmlFile parent) : base(parent) {}

        public EngineStringTupel Planet_Ability_Icon_Names { get; set; }
        public EngineStringTupel Planet_Ability_Text_IDs { get; set; }

        public PlanetAbilityRgbList Planet_Ability_RGBs { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
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
