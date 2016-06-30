using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticGuiUnitAbilityData : XmlTagCategory
    {
        public GalacticGuiUnitAbilityData(IAlomoXmlFile file) : base(file) {}

        public EngineStringTupel Activated_Slice_Ability_Names { get; set; }
        public EngineStringTupel Activated_Black_Market_Ability_Names { get; set; }
        public EngineStringTupel Activated_Sabotage_Ability_Names { get; set; }
        public EngineStringTupel Activated_Neutralize_Hero_Ability_Names { get; set; }
        public EngineStringTupel Activated_Siphon_Credits_Ability_Names { get; set; }
        public EngineStringTupel Activated_System_Spy_Ability_Names { get; set; }
        public EngineStringTupel Activated_Destroy_Planet_Ability_Names { get; set; }
        public EngineStringTupel Activated_Corrupt_Planet_Ability_Names { get; set; }
        public EngineStringTupel Activated_Remove_Corruption_Ability_Names { get; set; }
        public EngineStringTupel Activated_Hack_Super_Weapon_Ability_Names { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Activated_Slice_Ability_Names), Activated_Slice_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Black_Market_Ability_Names), Activated_Black_Market_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Sabotage_Ability_Names), Activated_Sabotage_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Neutralize_Hero_Ability_Names), Activated_Neutralize_Hero_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Siphon_Credits_Ability_Names), Activated_Siphon_Credits_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_System_Spy_Ability_Names), Activated_System_Spy_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Destroy_Planet_Ability_Names), Activated_Destroy_Planet_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Corrupt_Planet_Ability_Names), Activated_Corrupt_Planet_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Remove_Corruption_Ability_Names), Activated_Remove_Corruption_Ability_Names.ToString());
            node.SetValueOfLastTagOfName(nameof(Activated_Hack_Super_Weapon_Ability_Names), Activated_Hack_Super_Weapon_Ability_Names.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Description = node.GetCommentOverElement(nameof(Activated_Slice_Ability_Names));
            Activated_Slice_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Slice_Ability_Names)));
            Activated_Black_Market_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Black_Market_Ability_Names)));
            Activated_Sabotage_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Sabotage_Ability_Names)));
            Activated_Neutralize_Hero_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Neutralize_Hero_Ability_Names)));
            Activated_Siphon_Credits_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Slice_Ability_Names)));
            Activated_System_Spy_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_System_Spy_Ability_Names)));
            Activated_Destroy_Planet_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Destroy_Planet_Ability_Names)));
            Activated_Corrupt_Planet_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Corrupt_Planet_Ability_Names)));
            Activated_Remove_Corruption_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Remove_Corruption_Ability_Names)));
            Activated_Hack_Super_Weapon_Ability_Names = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Activated_Hack_Super_Weapon_Ability_Names)));
        }
    }
}
