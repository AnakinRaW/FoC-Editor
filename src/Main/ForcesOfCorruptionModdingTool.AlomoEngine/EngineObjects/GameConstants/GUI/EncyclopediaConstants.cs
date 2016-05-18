using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EncyclopediaConstants : EngineObject
    {
        public EncyclopediaConstants(IGameXmlFile parent) : base(parent) {}

        public int Tooltip_Delay { get; set; }

        public int Encyclopedia_Delay { get; set; }

        public int Long_Encyclopedia_Delay { get; set; }

        public int Text_Reveal_Rate { get; set; }

        public double Japanese_Line_Percent { get; set; }

        public double Japanese_ST_Line_Percent { get; set; }

        public int Encyclopedia_Population_Offset { get; set; }

        public int Encyclopedia_Name_Offset { get; set; }

        public int Encyclopedia_Cost_Offset { get; set; }

        public int Encyclopedia_Icon_X_Offset { get; set; }

        public int Encyclopedia_Icon_Y_Offset { get; set; }

        public int Encyclopedia_Class_Y_Offset { get; set; }

        public double Encyclopedia_Fade_Rate { get; set; }

        public double Encyclopedia_Min_Display_Time { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Tooltip_Delay), Tooltip_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Delay), Encyclopedia_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Long_Encyclopedia_Delay), Long_Encyclopedia_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Text_Reveal_Rate), Text_Reveal_Rate.ToString());
            node.SetValueOfLastTagOfName(nameof(Japanese_Line_Percent), Japanese_Line_Percent.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Japanese_ST_Line_Percent), Japanese_ST_Line_Percent.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Population_Offset), Encyclopedia_Population_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Name_Offset), Encyclopedia_Name_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Cost_Offset), Encyclopedia_Cost_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Icon_X_Offset), Encyclopedia_Icon_X_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Icon_Y_Offset), Encyclopedia_Icon_Y_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Class_Y_Offset), Encyclopedia_Class_Y_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Fade_Rate), Encyclopedia_Fade_Rate.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Min_Display_Time), Encyclopedia_Min_Display_Time.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Tooltip_Delay = node.GetValueOfLastTagOfName(nameof(Tooltip_Delay)).ToInteger();
            Encyclopedia_Delay = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Delay)).ToInteger();
            Long_Encyclopedia_Delay = node.GetValueOfLastTagOfName(nameof(Long_Encyclopedia_Delay)).ToInteger();
            Text_Reveal_Rate = node.GetValueOfLastTagOfName(nameof(Text_Reveal_Rate)).ToInteger();
            Japanese_Line_Percent = node.GetValueOfLastTagOfName(nameof(Japanese_Line_Percent)).ToEngineFloat();
            Japanese_ST_Line_Percent = node.GetValueOfLastTagOfName(nameof(Japanese_ST_Line_Percent)).ToEngineFloat();

            Encyclopedia_Population_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Population_Offset)).ToInteger();
            Encyclopedia_Name_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Name_Offset)).ToInteger();
            Encyclopedia_Cost_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Cost_Offset)).ToInteger();
            Encyclopedia_Icon_X_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Icon_X_Offset)).ToInteger();
            Encyclopedia_Icon_Y_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Icon_Y_Offset)).ToInteger();
            Encyclopedia_Class_Y_Offset = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Class_Y_Offset)).ToInteger();
            Encyclopedia_Fade_Rate = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Fade_Rate)).ToEngineFloat();
            Encyclopedia_Min_Display_Time = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Min_Display_Time)).ToEngineFloat();
        }
    }
}
