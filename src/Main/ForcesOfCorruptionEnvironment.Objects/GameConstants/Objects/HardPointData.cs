using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Objects
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HardPointData : XmlTagCategory
    {
        public HardPointData(IAlomoXmlFile file) : base(file) {}

        public double HardPoint_Target_Reticle_Enemy_Screen_Size { get; set; }

        public double HardPoint_Target_Reticle_Friendly_Screen_Size { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Enemy_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Enemy_Tracked_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Tracked_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Repairing_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Disabled_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture { get; set; }

        public double Hardpoint_Recharge_Cutoff_For_Opportunity_Fire { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;

            node.SetValueOfLastTagOfName(nameof(HardPoint_Target_Reticle_Enemy_Screen_Size),
                HardPoint_Target_Reticle_Enemy_Screen_Size.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(HardPoint_Target_Reticle_Friendly_Screen_Size),
                HardPoint_Target_Reticle_Friendly_Screen_Size.ToString(CultureInfo.InvariantCulture));

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Enemy_Texture),
                HardPoint_Target_Reticle_Enemy_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Enemy_Tracked_Texture),
                HardPoint_Target_Reticle_Enemy_Tracked_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Friendly_Texture),
                HardPoint_Target_Reticle_Friendly_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Friendly_Tracked_Texture),
                HardPoint_Target_Reticle_Friendly_Tracked_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Friendly_Repairing_Texture),
                HardPoint_Target_Reticle_Friendly_Repairing_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Friendly_Disabled_Texture),
                HardPoint_Target_Reticle_Friendly_Disabled_Texture.Select(data => data.ToString()).ToList());

            node.AddMultipleTagsFromValueList(nameof(HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture),
                HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture.Select(data => data.ToString()).ToList());

            node.SetValueOfLastTagOfName(nameof(Hardpoint_Recharge_Cutoff_For_Opportunity_Fire),
                Hardpoint_Recharge_Cutoff_For_Opportunity_Fire.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            HardPoint_Target_Reticle_Enemy_Screen_Size =
                node.GetValueOfLastTagOfName(nameof(HardPoint_Target_Reticle_Enemy_Screen_Size)).ToEngineFloat();

            HardPoint_Target_Reticle_Friendly_Screen_Size =
                node.GetValueOfLastTagOfName(nameof(HardPoint_Target_Reticle_Friendly_Screen_Size)).ToEngineFloat();

            HardPoint_Target_Reticle_Enemy_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Enemy_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Enemy_Tracked_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Enemy_Tracked_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Friendly_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Friendly_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Friendly_Tracked_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Friendly_Tracked_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Friendly_Repairing_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Friendly_Repairing_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Friendly_Disabled_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Friendly_Disabled_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture =
                node.GetValuesByNameFromMultipleTags(nameof(HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture))
                    .Select(HardPointTextureAssociation.CreateFromString)
                    .ToList();

            Hardpoint_Recharge_Cutoff_For_Opportunity_Fire =
                node.GetValueOfLastTagOfName(nameof(Hardpoint_Recharge_Cutoff_For_Opportunity_Fire)).ToEngineFloat();
        }
    }
}
