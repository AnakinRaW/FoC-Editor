﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class HardPointData : EngineObject
    {
        public HardPointData(IGameXmlFile parent) : base(parent) {}

        public double HardPoint_Target_Reticle_Enemy_Screen_Size { get; set; }

        public double HardPoint_Target_Reticle_Friendly_Screen_Size { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Enemy_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Enemy_Tracked_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Tracked_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Repairing_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Disabled_Texture { get; set; }

        public List<HardPointTextureAssociation> HardPoint_Target_Reticle_Friendly_Disabled_Tracked_Texture { get; set;
        }


        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;

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


        }
    }
}