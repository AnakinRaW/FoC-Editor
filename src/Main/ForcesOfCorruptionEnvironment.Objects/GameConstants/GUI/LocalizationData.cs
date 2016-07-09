using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml;
using AlomoEngine.Xml.Layout;
using ForcesOfCorruptionEnvironment.DataTypes.AssociationTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class LocalizationData : AbstractXmlTagCategory
    {
        public LocalizationData(IAlomoXmlFile file) : base(file) {}

        public List<LanguageTextureAssociation> Localized_Splash_Screen { get; set; }

        public string Localized_UK_English_Splash_Screen { get; set; }

        public List<LanguageTextureAssociation> Localized_Menu_Overlay { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.AddMultipleTagsFromValueList(nameof(Localized_Splash_Screen),
                            Localized_Splash_Screen.Select(data => data.ToString()).ToList());
            node.SetValueOfLastTagOfName(nameof(Localized_UK_English_Splash_Screen), Localized_UK_English_Splash_Screen);
            node.AddMultipleTagsFromValueList(nameof(Localized_Menu_Overlay),
                            Localized_Menu_Overlay.Select(data => data.ToString()).ToList());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Localized_Splash_Screen =
                node.GetValuesByNameFromMultipleTags(nameof(Localized_Splash_Screen))
                    .Select(LanguageTextureAssociation.CreateFromString)
                    .ToList();
            Localized_UK_English_Splash_Screen = node.GetValueOfLastTagOfName(nameof(Localized_UK_English_Splash_Screen));
            Localized_Menu_Overlay =
                node.GetValuesByNameFromMultipleTags(nameof(Localized_Menu_Overlay))
                    .Select(LanguageTextureAssociation.CreateFromString)
                    .ToList();
        }
    }
}
