using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;
using ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DamageArmorMatrixData : AbstractXmlTagCategory
    {
        public DamageArmorMatrixData(IAlomoXmlFile file) : base(file) {}

        [Description("these will NOT WORK for special abilities and <Damage_Clone>, <Squash_Damage_Type> and <Internal_Damage_Type> tags.")]
        public EngineStringTupel Damage_Types { get; set; }

        [Description("ARMOR TYPES that have damage types appliced to them for damage modifiers. " +
                     "These are armor categories for baseline units. if a unit is 'like' an existing one as far as armor (rps) is concerned, "
                     + "then you can reuse the category. To make a unit tougher or weaker, change its health or shields. "
                     + "To encourage bringing in a different kind of unit to attack it, then change the armor type and associated damage-vs-armor value.")]
        public EngineStringTupel Armor_Types { get; set; }

        public List<DamageArmorAssociation> Damage_To_Armor_Mod { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Damage_Types), Damage_Types.ToString(EngineSparators.Comma, true));
            node.SetValueOfLastTagOfName(nameof(Armor_Types), Armor_Types.ToString(EngineSparators.Comma, true));

            node.AddMultipleTagsFromValueList(nameof(Damage_To_Armor_Mod),
                Damage_To_Armor_Mod.Select(data => data.ToString()).ToList());


            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Damage_Types = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Damage_Types)));
            Armor_Types = EngineStringTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Armor_Types)));

            Damage_To_Armor_Mod =
                node.GetValuesByNameFromMultipleTags(nameof(Damage_To_Armor_Mod))
                    .Select(DamageArmorAssociation.CreateFromString)
                    .ToList();
        }
    }
}
