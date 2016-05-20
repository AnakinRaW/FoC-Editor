using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes.Enums;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants.GUI
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

        public double GUI_Flash_Level { get; set; }

        public double GUI_Flash_Duration { get; set; }

        public double GUI_Rapid_Flash_Duration { get; set; }

        public int GUI_Cycle_Speed { get; set; }

        public double GUI_Darken_Level { get; set; }

        public EngineIntegerTupel GUI_Cycle_Color { get; set; }

        public double GUI_Hilite_Level { get; set; }

        public double GUI_Planet_Flash_Level { get; set; }

        public double GUI_Planet_Fade_Duration { get; set; }

        public double CB_Flash_Duration { get; set; }

        public int CB_Flash_Count { get; set; }

        public double Min_Accuracy_For_Icon { get; set; }

        public double Min_Sight_Range_For_Icon { get; set; }

        public EngineColor Left_Queue_Tint { get; set; }

        public EngineColor Right_Queue_Tint { get; set; }

        public int Icons_Per_Column { get; set; }

        public EngineIntegerTupel CB_Movie_Offset { get; set; }

        public EngineColor CB_Movie_Color { get; set; }

        public int BeaconPlaceDelay { get; set; }

        public int Map_Preview_Image_Size { get; set; }

        public double Camera_FX_Manager_Letterbox_Height { get; set; }

        public EncyclopediaConstants EncyclopediaConstants { get; set; }

        public EngineFloatTupel Shield_Flash_Scale { get; set; }
        public double Shield_Flash_Duration { get; set; }

        [Description("Colors to use for the reinforcements terrain overlay (a,r,g,b)")]
        public EngineColor ReinforcementOverlayGoodColor { get; set; }
        [Description("Colors to use for the reinforcements terrain overlay (a,r,g,b)")]
        public EngineColor ReinforcementOverlayBadColor { get; set; }

        public double Health_Bar_Scale { get; set; }
        public double Land_Health_Bar_Scale { get; set; }
        public double Min_Health_Bar_Scale { get; set; }
        public int Team_Healthbar_Offset { get; set; }
        public double Health_Bar_Spacing { get; set; }

        public EngineColor Good_Ground_Color_Tint { get; set; }
        public EngineColor High_Ground_Color_Tint { get; set; }
        public EngineColor Slow_Ground_Color_Tint { get; set; }
        public EngineColor Lava_Ground_Color_Tint { get; set; }
        public EngineColor Infantry_Ground_Color_Tint { get; set; }

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


            node.SetValueOfLastTagOfName(nameof(GUI_Flash_Level), GUI_Flash_Level.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Flash_Duration), GUI_Flash_Duration.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Rapid_Flash_Duration), GUI_Rapid_Flash_Duration.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Cycle_Speed), GUI_Cycle_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(GUI_Darken_Level), GUI_Darken_Level.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Cycle_Color), GUI_Cycle_Color.ToString());
            node.SetValueOfLastTagOfName(nameof(GUI_Hilite_Level), GUI_Hilite_Level.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Planet_Flash_Level), GUI_Planet_Flash_Level.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GUI_Planet_Fade_Duration), GUI_Planet_Fade_Duration.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(CB_Flash_Duration), CB_Flash_Duration.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(CB_Flash_Count), CB_Flash_Count.ToString());

            node.SetValueOfLastTagOfName(nameof(Min_Accuracy_For_Icon), Min_Accuracy_For_Icon.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Min_Sight_Range_For_Icon), Min_Sight_Range_For_Icon.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Left_Queue_Tint), Left_Queue_Tint.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Left_Queue_Tint), Left_Queue_Tint.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Icons_Per_Column), Icons_Per_Column.ToString());
            node.SetValueOfLastTagOfName(nameof(CB_Movie_Offset), CB_Movie_Offset.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(CB_Movie_Color), CB_Movie_Color.ToString(EngineSparators.Space));

            node.SetValueOfLastTagOfName(nameof(BeaconPlaceDelay), BeaconPlaceDelay.ToString());
            node.SetValueOfLastTagOfName(nameof(Map_Preview_Image_Size), Map_Preview_Image_Size.ToString());

            node.SetValueOfLastTagOfName(nameof(Camera_FX_Manager_Letterbox_Height), Camera_FX_Manager_Letterbox_Height.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Shield_Flash_Scale), Shield_Flash_Scale.ToString());
            node.SetValueOfLastTagOfName(nameof(Shield_Flash_Duration), Shield_Flash_Duration.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(ReinforcementOverlayGoodColor), ReinforcementOverlayGoodColor.ToString(true, true));
            node.SetValueOfLastTagOfName(nameof(ReinforcementOverlayBadColor), ReinforcementOverlayBadColor.ToString(true, true));

            node.SetValueOfLastTagOfName(nameof(Health_Bar_Scale), Health_Bar_Scale.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Health_Bar_Scale), Land_Health_Bar_Scale.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Min_Health_Bar_Scale), Min_Health_Bar_Scale.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Team_Healthbar_Offset), Team_Healthbar_Offset.ToString());
            node.SetValueOfLastTagOfName(nameof(Health_Bar_Spacing), Health_Bar_Spacing.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Good_Ground_Color_Tint), Good_Ground_Color_Tint.ToString(false));
            node.SetValueOfLastTagOfName(nameof(High_Ground_Color_Tint), High_Ground_Color_Tint.ToString(false));
            node.SetValueOfLastTagOfName(nameof(Slow_Ground_Color_Tint), Slow_Ground_Color_Tint.ToString(false));
            node.SetValueOfLastTagOfName(nameof(Lava_Ground_Color_Tint), Lava_Ground_Color_Tint.ToString(false));
            node.SetValueOfLastTagOfName(nameof(Infantry_Ground_Color_Tint), Infantry_Ground_Color_Tint.ToString(false));

            node = EncyclopediaConstants.Serialize();

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


            GUI_Flash_Level = node.GetValueOfLastTagOfName(nameof(GUI_Flash_Level)).ToEngineFloat();
            GUI_Flash_Duration = node.GetValueOfLastTagOfName(nameof(GUI_Flash_Duration)).ToEngineFloat();
            GUI_Rapid_Flash_Duration = node.GetValueOfLastTagOfName(nameof(GUI_Rapid_Flash_Duration)).ToEngineFloat();
            GUI_Cycle_Speed = node.GetValueOfLastTagOfName(nameof(GUI_Cycle_Speed)).ToInteger();
            GUI_Darken_Level = node.GetValueOfLastTagOfName(nameof(GUI_Darken_Level)).ToEngineFloat();
            GUI_Cycle_Color = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(GUI_Cycle_Color)));
            GUI_Hilite_Level = node.GetValueOfLastTagOfName(nameof(GUI_Hilite_Level)).ToEngineFloat();
            GUI_Planet_Flash_Level = node.GetValueOfLastTagOfName(nameof(GUI_Planet_Flash_Level)).ToEngineFloat();
            GUI_Planet_Fade_Duration = node.GetValueOfLastTagOfName(nameof(GUI_Planet_Fade_Duration)).ToEngineFloat();
            CB_Flash_Duration = node.GetValueOfLastTagOfName(nameof(CB_Flash_Duration)).ToEngineFloat();
            CB_Flash_Count = node.GetValueOfLastTagOfName(nameof(CB_Flash_Count)).ToInteger();

            Min_Accuracy_For_Icon = node.GetValueOfLastTagOfName(nameof(Min_Accuracy_For_Icon)).ToEngineFloat();
            Min_Sight_Range_For_Icon = node.GetValueOfLastTagOfName(nameof(Min_Sight_Range_For_Icon)).ToEngineFloat();
            Left_Queue_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Left_Queue_Tint)));
            Right_Queue_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Right_Queue_Tint)));
            Icons_Per_Column = node.GetValueOfLastTagOfName(nameof(Icons_Per_Column)).ToInteger();
            CB_Movie_Offset = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(CB_Movie_Offset)));
            CB_Movie_Color = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(CB_Movie_Color)));
            BeaconPlaceDelay = node.GetValueOfLastTagOfName(nameof(BeaconPlaceDelay)).ToInteger();

            Map_Preview_Image_Size = node.GetValueOfLastTagOfName(nameof(Map_Preview_Image_Size)).ToInteger();

            Camera_FX_Manager_Letterbox_Height = node.GetValueOfLastTagOfName(nameof(Camera_FX_Manager_Letterbox_Height)).ToEngineFloat();

            Shield_Flash_Scale = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Shield_Flash_Scale)));
            Shield_Flash_Duration = node.GetValueOfLastTagOfName(nameof(Shield_Flash_Duration)).ToEngineFloat();

            ReinforcementOverlayGoodColor = EngineColor.CreateColorFromStringArgb(node.GetValueOfLastTagOfName(nameof(ReinforcementOverlayGoodColor)));
            ReinforcementOverlayBadColor = EngineColor.CreateColorFromStringArgb(node.GetValueOfLastTagOfName(nameof(ReinforcementOverlayBadColor)));

            Health_Bar_Scale = node.GetValueOfLastTagOfName(nameof(Health_Bar_Scale)).ToEngineFloat();
            Land_Health_Bar_Scale = node.GetValueOfLastTagOfName(nameof(Land_Health_Bar_Scale)).ToEngineFloat();
            Min_Health_Bar_Scale = node.GetValueOfLastTagOfName(nameof(Min_Health_Bar_Scale)).ToEngineFloat();
            Team_Healthbar_Offset = node.GetValueOfLastTagOfName(nameof(Team_Healthbar_Offset)).ToInteger();
            Health_Bar_Spacing = node.GetValueOfLastTagOfName(nameof(Health_Bar_Spacing)).ToEngineFloat();

            Good_Ground_Color_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Good_Ground_Color_Tint)));
            High_Ground_Color_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(High_Ground_Color_Tint)));
            Slow_Ground_Color_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Slow_Ground_Color_Tint)));
            Lava_Ground_Color_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Lava_Ground_Color_Tint)));
            Infantry_Ground_Color_Tint = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(Infantry_Ground_Color_Tint)));

            EncyclopediaConstants = new EncyclopediaConstants(Parent);
            EncyclopediaConstants.Deserialize(node);
        }
    }
}
