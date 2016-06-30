using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BountyAwardData : EngineObject
    {
        public BountyAwardData(IAlomoXmlFile parent) : base(parent) {}

        public List<BountyCategoryAwardAssociation> Default_Bounty_By_Category_SP { get; set; }
        public List<BountyCategoryAwardAssociation> Default_Bounty_By_Category_MP { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.AddMultipleTagsFromValueList(nameof(Default_Bounty_By_Category_SP),
                Default_Bounty_By_Category_SP.Select(data => data.ToString()).ToList());
            node.AddMultipleTagsFromValueList(nameof(Default_Bounty_By_Category_MP),
                Default_Bounty_By_Category_MP.Select(data => data.ToString()).ToList());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Default_Bounty_By_Category_SP =
               node.GetValuesByNameFromMultipleTags(nameof(Default_Bounty_By_Category_SP))
                   .Select(BountyCategoryAwardAssociation.CreateFromString)
                   .ToList();
            Default_Bounty_By_Category_MP =
               node.GetValuesByNameFromMultipleTags(nameof(Default_Bounty_By_Category_MP))
                   .Select(BountyCategoryAwardAssociation.CreateFromString)
                   .ToList();
        }
    }
}
