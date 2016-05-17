using System.Diagnostics.CodeAnalysis;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameTypographyData : EngineObject
    {
        public GameTypographyData(IGameXmlFile parent) : base(parent) {}

        public string Credits_Display_Font_Name { get; set; }

        public int Credits_Display_Font_Size { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Credits_Display_Font_Name), Credits_Display_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Credits_Display_Font_Size), Credits_Display_Font_Size.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Credits_Display_Font_Name = node.GetValueOfLastTagOfName(nameof(Credits_Display_Font_Name));
            Credits_Display_Font_Size = node.GetValueOfLastTagOfName(nameof(Credits_Display_Font_Size)).ToInteger();
        }
    }
}
