using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GuiGameConstantsData : EngineObject
    {
        public GuiGameConstantsData(IGameXmlFile parent) : base(parent) {}

        public string GUI_Move_Command_Ack_Effect { get; set; }

        public string GUI_Double_Click_Move_Command_Ack_Effect { get; set; }

        public string GUI_Attack_Move_Command_Ack_Effect { get; set; }

        public string GUI_Guard_Move_Command_Ack_Effect { get; set; }

        public string GUI_Attack_Movement_Click_Radar_Event_Name { get; set; }

        public string GUI_Movement_Click_Radar_Event_Name { get; set; }

        public string GUI_Movement_Double_Click_Radar_Event_Name { get; set; }

        public double GUI_Move_Acknowledge_Scale_Land { get; set; }

        public double GUI_Move_Acknowledge_Scale_Space { get; set; }

        public int Tooltip_Delay { get; set; }
        public int Encyclopedia_Delay { get; set; }
        public int Long_Encyclopedia_Delay { get; set; }
        public int Text_Reveal_Rate { get; set; }
        public double Japanese_Line_Percent { get; set; }
        public double Japanese_ST_Line_Percent { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(GUI_Move_Command_Ack_Effect), GUI_Move_Command_Ack_Effect);
            node.SetValueOfLastTagOfName(nameof(GUI_Double_Click_Move_Command_Ack_Effect), GUI_Double_Click_Move_Command_Ack_Effect);
            node.SetValueOfLastTagOfName(nameof(GUI_Attack_Move_Command_Ack_Effect), GUI_Attack_Move_Command_Ack_Effect);
            node.SetValueOfLastTagOfName(nameof(GUI_Guard_Move_Command_Ack_Effect), GUI_Guard_Move_Command_Ack_Effect);
            node.SetValueOfLastTagOfName(nameof(GUI_Attack_Movement_Click_Radar_Event_Name), GUI_Attack_Movement_Click_Radar_Event_Name);
            node.SetValueOfLastTagOfName(nameof(GUI_Movement_Click_Radar_Event_Name), GUI_Movement_Click_Radar_Event_Name);
            node.SetValueOfLastTagOfName(nameof(GUI_Movement_Double_Click_Radar_Event_Name), GUI_Movement_Double_Click_Radar_Event_Name);
            node.SetValueOfLastTagOfName(nameof(GUI_Move_Acknowledge_Scale_Land), GUI_Move_Acknowledge_Scale_Land.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Move_Acknowledge_Scale_Space), GUI_Move_Acknowledge_Scale_Space.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Tooltip_Delay), Tooltip_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Encyclopedia_Delay), Encyclopedia_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Long_Encyclopedia_Delay), Long_Encyclopedia_Delay.ToString());
            node.SetValueOfLastTagOfName(nameof(Text_Reveal_Rate), Text_Reveal_Rate.ToString());
            node.SetValueOfLastTagOfName(nameof(Japanese_Line_Percent), Japanese_Line_Percent.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Japanese_ST_Line_Percent), Japanese_ST_Line_Percent.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            GUI_Move_Command_Ack_Effect = node.GetValueOfLastTagOfName(nameof(GUI_Move_Command_Ack_Effect));
            GUI_Double_Click_Move_Command_Ack_Effect = node.GetValueOfLastTagOfName(nameof(GUI_Double_Click_Move_Command_Ack_Effect));
            GUI_Attack_Move_Command_Ack_Effect = node.GetValueOfLastTagOfName(nameof(GUI_Attack_Move_Command_Ack_Effect));
            GUI_Guard_Move_Command_Ack_Effect = node.GetValueOfLastTagOfName(nameof(GUI_Guard_Move_Command_Ack_Effect));
            GUI_Attack_Movement_Click_Radar_Event_Name = node.GetValueOfLastTagOfName(nameof(GUI_Attack_Movement_Click_Radar_Event_Name));
            GUI_Movement_Click_Radar_Event_Name = node.GetValueOfLastTagOfName(nameof(GUI_Movement_Click_Radar_Event_Name));
            GUI_Movement_Double_Click_Radar_Event_Name = node.GetValueOfLastTagOfName(nameof(GUI_Movement_Double_Click_Radar_Event_Name));
            GUI_Move_Acknowledge_Scale_Land = node.GetValueOfLastTagOfName(nameof(GUI_Move_Acknowledge_Scale_Land)).ToEngineFloat();
            GUI_Move_Acknowledge_Scale_Space = node.GetValueOfLastTagOfName(nameof(GUI_Move_Acknowledge_Scale_Space)).ToEngineFloat();

            Tooltip_Delay = node.GetValueOfLastTagOfName(nameof(Tooltip_Delay)).ToInteger();
            Encyclopedia_Delay = node.GetValueOfLastTagOfName(nameof(Encyclopedia_Delay)).ToInteger();
            Long_Encyclopedia_Delay = node.GetValueOfLastTagOfName(nameof(Long_Encyclopedia_Delay)).ToInteger();
            Text_Reveal_Rate = node.GetValueOfLastTagOfName(nameof(Text_Reveal_Rate)).ToInteger();
            Japanese_Line_Percent = node.GetValueOfLastTagOfName(nameof(Japanese_Line_Percent)).ToEngineFloat();
            Japanese_ST_Line_Percent = node.GetValueOfLastTagOfName(nameof(Japanese_ST_Line_Percent)).ToEngineFloat();
        }
    }
}
