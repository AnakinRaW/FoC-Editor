using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.DataTypes;
using AlomoEngine.DataTypes.Enums;
using AlomoEngine.Xml;

namespace AlomoEngine.Objects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CommandBarGuiData : EngineObject
    {
        public CommandBarGuiData(IGameXmlFile parent) : base(parent) {}

        public EngineColor Droid_Date_Color { get; set; }
        public EngineColor Droid_Text_Color { get; set; }
        public EngineColor Droid_Seperator_Color { get; set; }
        public EngineIntegerTupel Droid_Encyclopedia_Offset { get; set; }

        public int Advisor_Hint_Interval { get; set; }
        public double Advisor_Hint_Duration { get; set; }

        public bool Radar_Colorize_Selected_Units { get; set; }
        public EngineColor Radar_Selected_Units_Color { get; set; }

        public bool Radar_Colorize_Multiplayer_Enemy { get; set; }
        public EngineColor Radar_Multiplayer_Enemy_Color { get; set; }

        public bool Animate_During_Galactic_Mode_Pause { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Droid_Date_Color), Droid_Date_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(Droid_Text_Color), Droid_Text_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(Droid_Seperator_Color), Droid_Seperator_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(Droid_Encyclopedia_Offset), Droid_Encyclopedia_Offset.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Advisor_Hint_Interval), Advisor_Hint_Interval.ToString());
            node.SetValueOfLastTagOfName(nameof(Advisor_Hint_Duration), Advisor_Hint_Duration.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Radar_Colorize_Selected_Units), Radar_Colorize_Selected_Units.ToString());
            node.SetValueOfLastTagOfName(nameof(Radar_Selected_Units_Color), Radar_Selected_Units_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Radar_Colorize_Multiplayer_Enemy), Radar_Colorize_Multiplayer_Enemy.ToString());
            node.SetValueOfLastTagOfName(nameof(Radar_Multiplayer_Enemy_Color), Radar_Multiplayer_Enemy_Color.ToString(false));
            node.SetValueOfLastTagOfName(nameof(Animate_During_Galactic_Mode_Pause), Animate_During_Galactic_Mode_Pause.ToString());
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Droid_Date_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Droid_Date_Color)));
            Droid_Text_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Droid_Text_Color)));
            Droid_Seperator_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Droid_Seperator_Color)));
            Droid_Encyclopedia_Offset = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Droid_Encyclopedia_Offset)));
            Advisor_Hint_Interval = node.GetValueOfLastTagOfName(nameof(Advisor_Hint_Interval)).ToInteger();
            Advisor_Hint_Duration = node.GetValueOfLastTagOfName(nameof(Advisor_Hint_Duration)).ToEngineFloat();
            Radar_Colorize_Selected_Units =
                node.GetValueOfLastTagOfName(nameof(Radar_Colorize_Selected_Units)).ToEngineBoolean();
            Radar_Selected_Units_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Radar_Selected_Units_Color)));
            Radar_Colorize_Multiplayer_Enemy =
                node.GetValueOfLastTagOfName(nameof(Radar_Colorize_Multiplayer_Enemy)).ToEngineBoolean();
            Radar_Multiplayer_Enemy_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Radar_Multiplayer_Enemy_Color)));
            Animate_During_Galactic_Mode_Pause =
                node.GetValueOfLastTagOfName(nameof(Animate_During_Galactic_Mode_Pause)).ToEngineBoolean();
        }
    }
}
