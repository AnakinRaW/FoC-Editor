using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.GUI
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameTypographyData : AbstractXmlTagCategory
    {
        public GameTypographyData(IAlomoXmlFile file) : base(file) {}

        public string Credits_Display_Font_Name { get; set; }

        public int Credits_Display_Font_Size { get; set; }

        public EngineColor Hint_Text_Color { get; set; }

        public EngineColor System_Text_Color { get; set; }

        public EngineColor Task_Text_Color { get; set; }

        public EngineColor Speech_Text_Color { get; set; }

        public double GUI_Tactical_Countdown_Timers_Screen_X { get; set; }

        public double GUI_Tactical_Countdown_Timers_Screen_Y { get; set; }

        public double GUI_Tactical_Countdown_Timers_Screen_Spacing { get; set; }

        public double GUI_Strategic_Countdown_Timers_Screen_X { get; set; }

        public double GUI_Strategic_Countdown_Timers_Screen_Y { get; set; }

        public double GUI_Strategic_Countdown_Timers_Screen_Spacing { get; set; }

        public string Countdowns_Font_Name { get; set; }

        public int Countdowns_Font_Size { get; set; }

        public string In_Game_Message_Default_Font_Name { get; set; }

        public int In_Game_Message_Default_Font_Size { get; set; }

        public string Event_Message_Default_Font_Name { get; set; }

        public int Event_Message_Default_Font_Size { get; set; }

        public string Bink_Player_Caption_Font_Name { get; set; }

        public int Bink_Player_Caption_Font_Size { get; set; }

        public string Tool_Tip_Font_Name { get; set; }

        public int Tool_Tip_Font_Size { get; set; }

        public string Tool_Tip_Small_Font_Name { get; set; }

        public int Tool_Tip_Small_Font_Size { get; set; }

        public string Command_Bar_Default_Font_Name { get; set; }

        public int Command_Bar_Default_Font_Size { get; set; }

        public string Text_Button_Default_Font_Name { get; set; }

        public int Text_Button_Default_Font_Size { get; set; }

        public string Game_Object_Name_Font_Name { get; set; }

        public int Game_Object_Name_Font_Size { get; set; }

        public EngineColor Win_Message_Color { get; set; }

        public EngineColor Lose_Message_Color { get; set; }

        public string Win_Lose_Message_Font { get; set; }

        public int Win_Lose_Message_Font_Size { get; set; }

        public string Battle_Pending_Message_Font { get; set; }

        public int Battle_Pending_Message_Font_Size { get; set; }

        public EngineColor Battle_Pending_Message_Color { get; set; }

        [Description("-1 means center, 0.0+ means use position")]
        public double Battle_Pending_Message_Pos_X { get; set; }

        [Description("-1 means center, 0.0+ means use position")]
        public double Battle_Pending_Message_Pos_Y { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(Credits_Display_Font_Name), Credits_Display_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Credits_Display_Font_Size), Credits_Display_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Hint_Text_Color), Hint_Text_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(System_Text_Color), System_Text_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(Task_Text_Color), Task_Text_Color.ToString(EngineSparators.Space, false));
            node.SetValueOfLastTagOfName(nameof(Speech_Text_Color), Speech_Text_Color.ToString(EngineSparators.Space, false));

            node.SetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_X), GUI_Tactical_Countdown_Timers_Screen_X.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_Y), GUI_Tactical_Countdown_Timers_Screen_Y.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_Spacing), GUI_Tactical_Countdown_Timers_Screen_Spacing.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_X), GUI_Strategic_Countdown_Timers_Screen_X.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_Y), GUI_Strategic_Countdown_Timers_Screen_Y.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_Spacing), GUI_Strategic_Countdown_Timers_Screen_Spacing.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Countdowns_Font_Name), Countdowns_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Countdowns_Font_Size), Countdowns_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(In_Game_Message_Default_Font_Name), In_Game_Message_Default_Font_Name);
            node.SetValueOfLastTagOfName(nameof(In_Game_Message_Default_Font_Size), In_Game_Message_Default_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Event_Message_Default_Font_Name), Event_Message_Default_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Event_Message_Default_Font_Size), Event_Message_Default_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Bink_Player_Caption_Font_Name), Bink_Player_Caption_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Bink_Player_Caption_Font_Size), Bink_Player_Caption_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Tool_Tip_Font_Name), Tool_Tip_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Tool_Tip_Font_Size), Tool_Tip_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Tool_Tip_Small_Font_Name), Tool_Tip_Small_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Tool_Tip_Small_Font_Size), Tool_Tip_Small_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Command_Bar_Default_Font_Name), Command_Bar_Default_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Command_Bar_Default_Font_Size), Command_Bar_Default_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Text_Button_Default_Font_Name), Text_Button_Default_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Text_Button_Default_Font_Size), Text_Button_Default_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Game_Object_Name_Font_Name), Game_Object_Name_Font_Name);
            node.SetValueOfLastTagOfName(nameof(Game_Object_Name_Font_Size), Game_Object_Name_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Win_Lose_Message_Font), Win_Lose_Message_Font);
            node.SetValueOfLastTagOfName(nameof(Win_Lose_Message_Font_Size), Win_Lose_Message_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Message_Font), Battle_Pending_Message_Font);
            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Message_Font_Size), Battle_Pending_Message_Font_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Win_Message_Color), Win_Message_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Lose_Message_Color), Lose_Message_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Message_Color), Battle_Pending_Message_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Message_Pos_X), Battle_Pending_Message_Pos_X.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Message_Pos_Y), Battle_Pending_Message_Pos_Y.ToString(CultureInfo.InvariantCulture));

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Credits_Display_Font_Name = node.GetValueOfLastTagOfName(nameof(Credits_Display_Font_Name));
            Credits_Display_Font_Size = node.GetValueOfLastTagOfName(nameof(Credits_Display_Font_Size)).ToInteger();

            Hint_Text_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Hint_Text_Color)));
            System_Text_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(System_Text_Color)));
            Task_Text_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Task_Text_Color)));
            Speech_Text_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Speech_Text_Color)));

            GUI_Tactical_Countdown_Timers_Screen_X = node.GetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_X)).ToEngineFloat();
            GUI_Tactical_Countdown_Timers_Screen_Y = node.GetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_Y)).ToEngineFloat();
            GUI_Tactical_Countdown_Timers_Screen_Spacing = node.GetValueOfLastTagOfName(nameof(GUI_Tactical_Countdown_Timers_Screen_Spacing)).ToEngineFloat();
            GUI_Strategic_Countdown_Timers_Screen_X = node.GetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_X)).ToEngineFloat();
            GUI_Strategic_Countdown_Timers_Screen_Y = node.GetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_Y)).ToEngineFloat();
            GUI_Strategic_Countdown_Timers_Screen_Spacing = node.GetValueOfLastTagOfName(nameof(GUI_Strategic_Countdown_Timers_Screen_Spacing)).ToEngineFloat();

            Countdowns_Font_Name = node.GetValueOfLastTagOfName(nameof(Countdowns_Font_Name));
            Countdowns_Font_Size = node.GetValueOfLastTagOfName(nameof(Countdowns_Font_Size)).ToInteger();

            In_Game_Message_Default_Font_Name = node.GetValueOfLastTagOfName(nameof(In_Game_Message_Default_Font_Name));
            In_Game_Message_Default_Font_Size = node.GetValueOfLastTagOfName(nameof(In_Game_Message_Default_Font_Size)).ToInteger();

            Event_Message_Default_Font_Name = node.GetValueOfLastTagOfName(nameof(Event_Message_Default_Font_Name));
            Event_Message_Default_Font_Size = node.GetValueOfLastTagOfName(nameof(Event_Message_Default_Font_Size)).ToInteger();

            Bink_Player_Caption_Font_Name = node.GetValueOfLastTagOfName(nameof(Bink_Player_Caption_Font_Name));
            Bink_Player_Caption_Font_Size = node.GetValueOfLastTagOfName(nameof(Bink_Player_Caption_Font_Size)).ToInteger();

            Tool_Tip_Font_Name = node.GetValueOfLastTagOfName(nameof(Tool_Tip_Font_Name));
            Tool_Tip_Font_Size = node.GetValueOfLastTagOfName(nameof(Tool_Tip_Font_Size)).ToInteger();

            Tool_Tip_Small_Font_Name = node.GetValueOfLastTagOfName(nameof(Tool_Tip_Small_Font_Name));
            Tool_Tip_Small_Font_Size = node.GetValueOfLastTagOfName(nameof(Tool_Tip_Small_Font_Size)).ToInteger();

            Command_Bar_Default_Font_Name = node.GetValueOfLastTagOfName(nameof(Command_Bar_Default_Font_Name));
            Command_Bar_Default_Font_Size = node.GetValueOfLastTagOfName(nameof(Command_Bar_Default_Font_Size)).ToInteger();

            Text_Button_Default_Font_Name = node.GetValueOfLastTagOfName(nameof(Text_Button_Default_Font_Name));
            Text_Button_Default_Font_Size = node.GetValueOfLastTagOfName(nameof(Text_Button_Default_Font_Size)).ToInteger();

            Game_Object_Name_Font_Name = node.GetValueOfLastTagOfName(nameof(Game_Object_Name_Font_Name));
            Game_Object_Name_Font_Size = node.GetValueOfLastTagOfName(nameof(Game_Object_Name_Font_Size)).ToInteger();

            Win_Message_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Win_Message_Color)));
            Lose_Message_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Lose_Message_Color)));

            Win_Lose_Message_Font = node.GetValueOfLastTagOfName(nameof(Win_Lose_Message_Font));
            Win_Lose_Message_Font_Size = node.GetValueOfLastTagOfName(nameof(Win_Lose_Message_Font_Size)).ToInteger();

            Battle_Pending_Message_Font = node.GetValueOfLastTagOfName(nameof(Battle_Pending_Message_Font));
            Battle_Pending_Message_Font_Size = node.GetValueOfLastTagOfName(nameof(Battle_Pending_Message_Font_Size)).ToInteger();
            Battle_Pending_Message_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Battle_Pending_Message_Color)));

            Battle_Pending_Message_Pos_X = node.GetValueOfLastTagOfName(nameof(Battle_Pending_Message_Pos_X)).ToEngineFloat();
            Battle_Pending_Message_Pos_Y = node.GetValueOfLastTagOfName(nameof(Battle_Pending_Message_Pos_Y)).ToEngineFloat();
        }
    }
}
