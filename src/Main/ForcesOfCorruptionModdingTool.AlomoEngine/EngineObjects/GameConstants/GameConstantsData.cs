using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameConstantsData : EngineObject
    {
        public GameConstantsData(IGameXmlFile parent) : base(parent) { }

        [Description("When a land or space conflict occurs, allow pausing of Strategic/Galactic and not jump right into tactical battle until player(s) are ready")]
        public bool Strategic_Queue_Tactical_Battles { get; set; }

        public double Fleet_Maintenance_Update_Delay_Seconds { get; set; }

        public double Space_Auto_Resolve_Delay_Seconds { get; set; }

        public double Land_Auto_Resolve_Delay_Seconds { get; set; }

        public int Political_Control_Change_Time_Seconds { get; set; }

        public double Melee_Cutoff_Range { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Strategic_Queue_Tactical_Battles), Strategic_Queue_Tactical_Battles.ToString());
            node.SetValueOfLastTagOfName(nameof(Fleet_Maintenance_Update_Delay_Seconds), Fleet_Maintenance_Update_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Space_Auto_Resolve_Delay_Seconds), Space_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Auto_Resolve_Delay_Seconds), Land_Auto_Resolve_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Political_Control_Change_Time_Seconds), Political_Control_Change_Time_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Melee_Cutoff_Range), Melee_Cutoff_Range.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Strategic_Queue_Tactical_Battles =
                node.GetValueOfLastTagOfName(nameof(Strategic_Queue_Tactical_Battles)).ToEngineBoolean();

            Fleet_Maintenance_Update_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Fleet_Maintenance_Update_Delay_Seconds)).ToEngineFloat();

            Space_Auto_Resolve_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Space_Auto_Resolve_Delay_Seconds)).ToEngineFloat();

            Land_Auto_Resolve_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Land_Auto_Resolve_Delay_Seconds)).ToEngineFloat();

            Political_Control_Change_Time_Seconds =
                node.GetValueOfLastTagOfName(nameof(Political_Control_Change_Time_Seconds)).ToInteger();

            Melee_Cutoff_Range =
                node.GetValueOfLastTagOfName(nameof(Melee_Cutoff_Range)).ToEngineFloat();
        }
    }
}
