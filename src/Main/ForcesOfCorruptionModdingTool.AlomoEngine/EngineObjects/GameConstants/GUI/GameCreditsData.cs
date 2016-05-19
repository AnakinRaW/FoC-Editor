using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameCreditsData : EngineObject
    {
        public GameCreditsData(IGameXmlFile parent) : base(parent) {}

        public double Credits_Spacing { get; set; }
        public double Credits_Scroll_Rate { get; set; }
        public string Credits_Font { get; set; }

        public EngineFloatTupel Credits_Header_Top_Color { get; set; }
        public EngineFloatTupel Credits_Header_Bottom_Color { get; set; }
        public EngineFloatTupel Credits_Top_Color { get; set; }
        public EngineFloatTupel Credits_Bottom_Color { get; set; }

        public int Credits_Font_Size { get; set; }
        public double Credits_Margin { get; set; }

        public string Credits_Logo_1_Name { get; set; }
        public double Credits_Logo_1_Width { get; set; }
        public double Credits_Logo_1_Height { get; set; }
        public double Credits_Logo_1_Y_Offset { get; set; }

        public string Credits_Logo_2_Name { get; set; }
        public double Credits_Logo_2_Width { get; set; }
        public double Credits_Logo_2_Height { get; set; }
        public double Credits_Logo_2_Y_Offset { get; set; }

        public string Credits_Logo_3_Name { get; set; }
        public double Credits_Logo_3_Width { get; set; }
        public double Credits_Logo_3_Height { get; set; }
        public double Credits_Logo_3_Y_Offset { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Credits_Spacing), Credits_Spacing.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Scroll_Rate), Credits_Scroll_Rate.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Font), Credits_Font);
            node.SetValueOfLastTagOfName(nameof(Credits_Header_Top_Color), Credits_Header_Top_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Credits_Header_Bottom_Color), Credits_Header_Bottom_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Credits_Top_Color), Credits_Top_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Credits_Bottom_Color), Credits_Bottom_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Credits_Font_Size), Credits_Font_Size.ToString());
            node.SetValueOfLastTagOfName(nameof(Credits_Margin), Credits_Margin.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Credits_Logo_1_Name), Credits_Logo_1_Name);
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_1_Width), Credits_Logo_1_Width.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_1_Height), Credits_Logo_1_Height.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_1_Y_Offset), Credits_Logo_1_Y_Offset.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Credits_Logo_2_Name), Credits_Logo_2_Name);
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_2_Width), Credits_Logo_2_Width.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_2_Height), Credits_Logo_2_Height.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_2_Y_Offset), Credits_Logo_2_Y_Offset.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Credits_Logo_3_Name), Credits_Logo_3_Name);
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_3_Width), Credits_Logo_3_Width.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_3_Height), Credits_Logo_3_Height.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Credits_Logo_3_Y_Offset), Credits_Logo_3_Y_Offset.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Credits_Spacing = node.GetValueOfLastTagOfName(nameof(Credits_Spacing)).ToEngineFloat();
            Credits_Scroll_Rate = node.GetValueOfLastTagOfName(nameof(Credits_Scroll_Rate)).ToEngineFloat();
            Credits_Font = node.GetValueOfLastTagOfName(nameof(Credits_Font));
            Credits_Header_Top_Color = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Credits_Header_Top_Color)));
            Credits_Header_Bottom_Color = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Credits_Header_Bottom_Color)));
            Credits_Top_Color = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Credits_Top_Color)));
            Credits_Bottom_Color = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Credits_Bottom_Color)));
            Credits_Font_Size = node.GetValueOfLastTagOfName(nameof(Credits_Font_Size)).ToInteger();
            Credits_Margin = node.GetValueOfLastTagOfName(nameof(Credits_Margin)).ToEngineFloat();

            Credits_Logo_1_Name = node.GetValueOfLastTagOfName(nameof(Credits_Logo_1_Name));
            Credits_Logo_1_Width = node.GetValueOfLastTagOfName(nameof(Credits_Logo_1_Width)).ToEngineFloat();
            Credits_Logo_1_Height = node.GetValueOfLastTagOfName(nameof(Credits_Logo_1_Height)).ToEngineFloat();
            Credits_Logo_1_Y_Offset = node.GetValueOfLastTagOfName(nameof(Credits_Logo_1_Y_Offset)).ToEngineFloat();

            Credits_Logo_2_Name = node.GetValueOfLastTagOfName(nameof(Credits_Logo_2_Name));
            Credits_Logo_2_Width = node.GetValueOfLastTagOfName(nameof(Credits_Logo_2_Width)).ToEngineFloat();
            Credits_Logo_2_Height = node.GetValueOfLastTagOfName(nameof(Credits_Logo_2_Height)).ToEngineFloat();
            Credits_Logo_2_Y_Offset = node.GetValueOfLastTagOfName(nameof(Credits_Logo_2_Y_Offset)).ToEngineFloat();

            Credits_Logo_3_Name = node.GetValueOfLastTagOfName(nameof(Credits_Logo_3_Name));
            Credits_Logo_3_Width = node.GetValueOfLastTagOfName(nameof(Credits_Logo_3_Width)).ToEngineFloat();
            Credits_Logo_3_Height = node.GetValueOfLastTagOfName(nameof(Credits_Logo_3_Height)).ToEngineFloat();
            Credits_Logo_3_Y_Offset = node.GetValueOfLastTagOfName(nameof(Credits_Logo_3_Y_Offset)).ToEngineFloat();
        }
    }
}
