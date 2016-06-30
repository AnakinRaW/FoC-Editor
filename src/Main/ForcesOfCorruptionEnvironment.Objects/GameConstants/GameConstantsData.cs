using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameConstantsData : EngineObject
    {
        public GameConstantsData(IAlomoXmlFile parent) : base(parent) { }

        [Description("When a land or space conflict occurs, allow pausing of Strategic/Galactic and not jump right into tactical battle until player(s) are ready")]
        public bool Strategic_Queue_Tactical_Battles { get; set; }

        public double Fleet_Maintenance_Update_Delay_Seconds { get; set; }

        public int Political_Control_Change_Time_Seconds { get; set; }

        public double Melee_Cutoff_Range { get; set; }

        [Description("How long to countdown before a tactical retreat is allowed")]
        public int Space_Retreat_Allowed_Countdown_Seconds { get; set; }

        [Description("How long to countdown before a tactical retreat is allowed")]
        public int Land_Retreat_Allowed_Countdown_Seconds { get; set; }

        [Description("How long to countdown before objects become captureable")]
        public int Space_Capture_Allowed_Countdown_Seconds { get; set; }

        [Description("How long to countdown before objects become captureable")]
        public int Land_Capture_Allowed_Countdown_Seconds { get; set; }

        public double GripperCombatGridSnapDistance { get; set; }

        public bool PlayModeSwitchMovies { get; set; }

        public double MaxInfluenceTransitionAlignmentBonus { get; set; }

        public double MaxInfluenceTransitionAlignmentPenalty { get; set; }

        public double MaxCreditIncomeAlignmentBonus { get; set; }

        public double MaxCreditIncomeAlignmentPenalty { get; set; }

        public double MaxCombatAccuracyAlignmentBonus { get; set; }

        public double MaxCombatDamageAlignmentBonus { get; set; }

        public double MaxCombatSensorRangeAlignmentBonus { get; set; }

        public bool Space_Tactical_Camera_Locked { get; set; }

        public bool Land_Tactical_Camera_Locked { get; set; }

        public int ShieldRechargeIntervalInSecs { get; set; }

        public int EnergyRechargeIntervalInSecs { get; set; }

        public double EnergyToShieldExchangeRate { get; set; }

        public int Terrain_Resurface_Rand { get; set; }

        public double Terrain_Resurface_Tolerance { get; set; }

        public int Max_Ground_Forces_On_Planet { get; set; }

        public double Allow_Reinforcement_Percentage_Normalized { get; set; }

        public int Default_Hero_Respawn_Time { get; set; }

        public bool SpaceReinforceFeedbackOnlyWhileDragging { get; set; }

        public string Game_Scoring_Script_Name { get; set; }

        public int Water_Render_Target_Resolution { get; set; }

        public double Water_Clip_Plane_Offset { get; set; }

        public bool Occlusion_Silhouettes_Enabled { get; set; }

        public double Laser_Beam_Z_Scale_Factor { get; set; }

        public double Laser_Kite_Z_Scale_Factor { get; set; }

        public double Mouse_Over_Highlight_Scale { get; set; }

        public double MinimumDragSelectDistance { get; set; }

        public double MinimumDragDistance { get; set; }

        public int Ships_Per_Stack { get; set; }

        public double Asteroid_Field_Damage { get; set; }

        [Description("Probability the damage is applied in each frame, [0..1]")]
        public double Asteroid_Field_Damage_Rate { get; set; }

        [Description("Control Point Domination Victory Condition (Multiplayer Tactical): How long do you need to hold all control points before you win?")]
        public int Control_Point_Domination_Victory_Time_In_Secs { get; set; }

        [Description("How closely to tie hull vs. hard point healths together in releation to one another")]
        public double Hull_Vs_Hard_Points_Health_Constraint { get; set; }

        public bool Auto_Rotate_For_Space_Targeting { get; set; }

        public bool In_Game_Cinematics { get; set; }

        public bool Display_Bink_Movie_Frames { get; set; }

        [Description("Per unit probability of destruction during a retreat")]
        public double Space_Retreat_Attrition_Factor { get; set; }
        [Description("Per unit probability of destruction during a retreat")]
        public double Land_Retreat_Attrition_Factor { get; set; }
        [Description("Per unit probability of destruction during a retreat")]
        public double Blockade_Run_Attrition_Factor { get; set; }

        public string Demo_Attract_Maps { get; set; }
        public int Demo_Attract_Start_Timeout_Seconds { get; set; }
        public int Demo_Attract_Map_Cycle_Delay_Seconds { get; set; }
        public int Battle_Pending_Timeout_Seconds { get; set; }
        public string Message_Of_The_Day_URL { get; set; }

        public EngineFloatTupel Battle_Load_Planet_Viewport { get; set; }
        public EngineFloatTupel Battle_Load_Planet_Direction { get; set; }
        public EngineFloatTupel Battle_Load_Planet_Ambient { get; set; }
        public double Saliency_Size { get; set; }
        public double Saliency_Power { get; set; }
        public double Saliency_X { get; set; }
        public double Saliency_Y { get; set; }
        public double Saliency_Health { get; set; }
        public double Saliency_Targets { get; set; }
        public double Saliency_Speed { get; set; }

        public int Star_Wars_Crawl_Start_Fadeout_Frame { get; set; }

        public bool Use_Reinforcement_Points { get; set; }

        public bool Main_Menu_Demo_Attract_Mode { get; set; }

        public bool Land_Base_Destruction_Forces_Retreat { get; set; }
        public bool Space_Station_Destruction_Forces_Retreat { get; set; }

        public double Sensor_Jamming_Time { get; set; }

        public double First_Strike_Extra_Damage_Percent { get; set; }
        public string First_Strike_Particle { get; set; }
        public double Garrisoned_Max_Attack_Distance_Multiplier { get; set; }
        public int Max_Remote_Bombs_Per_Player { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Strategic_Queue_Tactical_Battles), Strategic_Queue_Tactical_Battles.ToString());
            node.SetValueOfLastTagOfName(nameof(Fleet_Maintenance_Update_Delay_Seconds), Fleet_Maintenance_Update_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Political_Control_Change_Time_Seconds), Political_Control_Change_Time_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Melee_Cutoff_Range), Melee_Cutoff_Range.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Space_Retreat_Allowed_Countdown_Seconds), Space_Retreat_Allowed_Countdown_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Land_Retreat_Allowed_Countdown_Seconds), Land_Retreat_Allowed_Countdown_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Space_Capture_Allowed_Countdown_Seconds), Space_Capture_Allowed_Countdown_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Land_Capture_Allowed_Countdown_Seconds), Land_Capture_Allowed_Countdown_Seconds.ToString());

            node.SetValueOfLastTagOfName(nameof(GripperCombatGridSnapDistance), GripperCombatGridSnapDistance.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(PlayModeSwitchMovies), PlayModeSwitchMovies.ToString());
            node.SetValueOfLastTagOfName(nameof(MaxInfluenceTransitionAlignmentBonus), MaxInfluenceTransitionAlignmentBonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxInfluenceTransitionAlignmentPenalty), MaxInfluenceTransitionAlignmentPenalty.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxCreditIncomeAlignmentBonus), MaxCreditIncomeAlignmentBonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxCreditIncomeAlignmentPenalty), MaxCreditIncomeAlignmentPenalty.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxCombatAccuracyAlignmentBonus), MaxCombatAccuracyAlignmentBonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxCombatDamageAlignmentBonus), MaxCombatDamageAlignmentBonus.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MaxCombatSensorRangeAlignmentBonus), MaxCombatSensorRangeAlignmentBonus.ToString(CultureInfo.InvariantCulture));


            node.SetValueOfLastTagOfName(nameof(Space_Tactical_Camera_Locked), Space_Tactical_Camera_Locked.ToString());
            node.SetValueOfLastTagOfName(nameof(Land_Tactical_Camera_Locked), Land_Tactical_Camera_Locked.ToString());

            node.SetValueOfLastTagOfName(nameof(ShieldRechargeIntervalInSecs), ShieldRechargeIntervalInSecs.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(EnergyRechargeIntervalInSecs), EnergyRechargeIntervalInSecs.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(EnergyToShieldExchangeRate), EnergyToShieldExchangeRate.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Terrain_Resurface_Rand), Terrain_Resurface_Rand.ToString());
            node.SetValueOfLastTagOfName(nameof(Terrain_Resurface_Tolerance), Terrain_Resurface_Tolerance.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Max_Ground_Forces_On_Planet), Max_Ground_Forces_On_Planet.ToString());
            node.SetValueOfLastTagOfName(nameof(Allow_Reinforcement_Percentage_Normalized), Allow_Reinforcement_Percentage_Normalized.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Default_Hero_Respawn_Time), Default_Hero_Respawn_Time.ToString());

            node.SetValueOfLastTagOfName(nameof(SpaceReinforceFeedbackOnlyWhileDragging), SpaceReinforceFeedbackOnlyWhileDragging.ToString());
            node.SetValueOfLastTagOfName(nameof(Game_Scoring_Script_Name), Game_Scoring_Script_Name);
            node.SetValueOfLastTagOfName(nameof(Water_Render_Target_Resolution), Water_Render_Target_Resolution.ToString());
            node.SetValueOfLastTagOfName(nameof(Water_Clip_Plane_Offset), Water_Clip_Plane_Offset.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Occlusion_Silhouettes_Enabled), Occlusion_Silhouettes_Enabled.ToString());
            node.SetValueOfLastTagOfName(nameof(Laser_Beam_Z_Scale_Factor), Laser_Beam_Z_Scale_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Laser_Kite_Z_Scale_Factor), Laser_Kite_Z_Scale_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Mouse_Over_Highlight_Scale), Mouse_Over_Highlight_Scale.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(MinimumDragSelectDistance), MinimumDragSelectDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(MinimumDragDistance), MinimumDragDistance.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Ships_Per_Stack), Ships_Per_Stack.ToString());

            node.SetValueOfLastTagOfName(nameof(Asteroid_Field_Damage), Asteroid_Field_Damage.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Asteroid_Field_Damage_Rate), Asteroid_Field_Damage_Rate.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Control_Point_Domination_Victory_Time_In_Secs), Control_Point_Domination_Victory_Time_In_Secs.ToString());

            node.SetValueOfLastTagOfName(nameof(Hull_Vs_Hard_Points_Health_Constraint), Hull_Vs_Hard_Points_Health_Constraint.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Auto_Rotate_For_Space_Targeting), Auto_Rotate_For_Space_Targeting.ToString());
            node.SetValueOfLastTagOfName(nameof(In_Game_Cinematics), In_Game_Cinematics.ToString());
            node.SetValueOfLastTagOfName(nameof(Display_Bink_Movie_Frames), Display_Bink_Movie_Frames.ToString());

            node.SetValueOfLastTagOfName(nameof(Space_Retreat_Attrition_Factor), Space_Retreat_Attrition_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Land_Retreat_Attrition_Factor), Land_Retreat_Attrition_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Blockade_Run_Attrition_Factor), Blockade_Run_Attrition_Factor.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Demo_Attract_Maps), Demo_Attract_Maps);
            node.SetValueOfLastTagOfName(nameof(Demo_Attract_Start_Timeout_Seconds), Demo_Attract_Start_Timeout_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Demo_Attract_Map_Cycle_Delay_Seconds), Demo_Attract_Map_Cycle_Delay_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Battle_Pending_Timeout_Seconds), Battle_Pending_Timeout_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Message_Of_The_Day_URL), Message_Of_The_Day_URL);

            node.SetValueOfLastTagOfName(nameof(Battle_Load_Planet_Viewport), Battle_Load_Planet_Viewport.ToString());
            node.SetValueOfLastTagOfName(nameof(Battle_Load_Planet_Direction), Battle_Load_Planet_Direction.ToString());
            node.SetValueOfLastTagOfName(nameof(Battle_Load_Planet_Ambient), Battle_Load_Planet_Ambient.ToString());
            node.SetValueOfLastTagOfName(nameof(Saliency_Size), Saliency_Size.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_Power), Saliency_Power.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_X), Saliency_X.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_Y), Saliency_Y.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_Health), Saliency_Health.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_Targets), Saliency_Targets.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Saliency_Speed), Saliency_Speed.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Star_Wars_Crawl_Start_Fadeout_Frame), Star_Wars_Crawl_Start_Fadeout_Frame.ToString());

            node.SetValueOfLastTagOfName(nameof(Use_Reinforcement_Points), Use_Reinforcement_Points.ToString());
            node.SetValueOfLastTagOfName(nameof(Main_Menu_Demo_Attract_Mode), Main_Menu_Demo_Attract_Mode.ToString());

            node.SetValueOfLastTagOfName(nameof(Land_Base_Destruction_Forces_Retreat), Land_Base_Destruction_Forces_Retreat.ToString());
            node.SetValueOfLastTagOfName(nameof(Space_Station_Destruction_Forces_Retreat), Space_Station_Destruction_Forces_Retreat.ToString());

            node.SetValueOfLastTagOfName(nameof(Sensor_Jamming_Time), Sensor_Jamming_Time.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(First_Strike_Extra_Damage_Percent), First_Strike_Extra_Damage_Percent.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(First_Strike_Particle), First_Strike_Particle);
            node.SetValueOfLastTagOfName(nameof(Garrisoned_Max_Attack_Distance_Multiplier), Garrisoned_Max_Attack_Distance_Multiplier.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Max_Remote_Bombs_Per_Player), Max_Remote_Bombs_Per_Player.ToString());

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Strategic_Queue_Tactical_Battles =
                node.GetValueOfLastTagOfName(nameof(Strategic_Queue_Tactical_Battles)).ToEngineBoolean();

            Fleet_Maintenance_Update_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Fleet_Maintenance_Update_Delay_Seconds)).ToEngineFloat();

           
            Political_Control_Change_Time_Seconds =
                node.GetValueOfLastTagOfName(nameof(Political_Control_Change_Time_Seconds)).ToInteger();

            Melee_Cutoff_Range =
                node.GetValueOfLastTagOfName(nameof(Melee_Cutoff_Range)).ToEngineFloat();

            GripperCombatGridSnapDistance =
                node.GetValueOfLastTagOfName(nameof(GripperCombatGridSnapDistance)).ToEngineFloat();

            PlayModeSwitchMovies =
                node.GetValueOfLastTagOfName(nameof(PlayModeSwitchMovies)).ToEngineBoolean();

            MaxInfluenceTransitionAlignmentBonus =
                node.GetValueOfLastTagOfName(nameof(MaxInfluenceTransitionAlignmentBonus)).ToEngineFloat();

            MaxInfluenceTransitionAlignmentPenalty =
                node.GetValueOfLastTagOfName(nameof(MaxInfluenceTransitionAlignmentPenalty)).ToEngineFloat();

            MaxCreditIncomeAlignmentBonus =
                node.GetValueOfLastTagOfName(nameof(MaxCreditIncomeAlignmentBonus)).ToEngineFloat();

            MaxCreditIncomeAlignmentPenalty =
                node.GetValueOfLastTagOfName(nameof(MaxCreditIncomeAlignmentPenalty)).ToEngineFloat();

            MaxCombatAccuracyAlignmentBonus =
                node.GetValueOfLastTagOfName(nameof(MaxCombatAccuracyAlignmentBonus)).ToEngineFloat();

            MaxCombatDamageAlignmentBonus =
                node.GetValueOfLastTagOfName(nameof(MaxCombatDamageAlignmentBonus)).ToEngineFloat();

            MaxCombatSensorRangeAlignmentBonus =
                node.GetValueOfLastTagOfName(nameof(MaxCombatSensorRangeAlignmentBonus)).ToEngineFloat();

            Space_Tactical_Camera_Locked =
                node.GetValueOfLastTagOfName(nameof(Space_Tactical_Camera_Locked)).ToEngineBoolean();

            Land_Tactical_Camera_Locked =
                node.GetValueOfLastTagOfName(nameof(Land_Tactical_Camera_Locked)).ToEngineBoolean();

            ShieldRechargeIntervalInSecs =
                node.GetValueOfLastTagOfName(nameof(ShieldRechargeIntervalInSecs)).ToInteger();

            EnergyRechargeIntervalInSecs =
                node.GetValueOfLastTagOfName(nameof(EnergyRechargeIntervalInSecs)).ToInteger();

            EnergyToShieldExchangeRate =
                node.GetValueOfLastTagOfName(nameof(EnergyToShieldExchangeRate)).ToEngineFloat();

            Terrain_Resurface_Rand =
                node.GetValueOfLastTagOfName(nameof(Terrain_Resurface_Rand)).ToInteger();

            Terrain_Resurface_Tolerance =
                node.GetValueOfLastTagOfName(nameof(Terrain_Resurface_Tolerance)).ToEngineFloat();

            Max_Ground_Forces_On_Planet =
                node.GetValueOfLastTagOfName(nameof(Max_Ground_Forces_On_Planet)).ToInteger();

            Allow_Reinforcement_Percentage_Normalized =
                node.GetValueOfLastTagOfName(nameof(Allow_Reinforcement_Percentage_Normalized)).ToEngineFloat();

            Default_Hero_Respawn_Time =
                node.GetValueOfLastTagOfName(nameof(Default_Hero_Respawn_Time)).ToInteger();

            SpaceReinforceFeedbackOnlyWhileDragging =
                node.GetValueOfLastTagOfName(nameof(SpaceReinforceFeedbackOnlyWhileDragging)).ToEngineBoolean();

            Game_Scoring_Script_Name = node.GetValueOfLastTagOfName(nameof(Game_Scoring_Script_Name));

            Water_Render_Target_Resolution =
                node.GetValueOfLastTagOfName(nameof(Water_Render_Target_Resolution)).ToInteger();

            Water_Clip_Plane_Offset =
                node.GetValueOfLastTagOfName(nameof(Water_Clip_Plane_Offset)).ToEngineFloat();

            Occlusion_Silhouettes_Enabled =
                node.GetValueOfLastTagOfName(nameof(Occlusion_Silhouettes_Enabled)).ToEngineBoolean();

            Laser_Beam_Z_Scale_Factor =
                node.GetValueOfLastTagOfName(nameof(Laser_Beam_Z_Scale_Factor)).ToEngineFloat();

            Laser_Kite_Z_Scale_Factor =
                node.GetValueOfLastTagOfName(nameof(Laser_Kite_Z_Scale_Factor)).ToEngineFloat();

            Mouse_Over_Highlight_Scale =
                node.GetValueOfLastTagOfName(nameof(Mouse_Over_Highlight_Scale)).ToEngineFloat();

            MinimumDragSelectDistance =
                node.GetValueOfLastTagOfName(nameof(MinimumDragSelectDistance)).ToEngineFloat();

            MinimumDragDistance =
                node.GetValueOfLastTagOfName(nameof(MinimumDragDistance)).ToEngineFloat();

            Ships_Per_Stack =
                node.GetValueOfLastTagOfName(nameof(Ships_Per_Stack)).ToInteger();

            Asteroid_Field_Damage =
                node.GetValueOfLastTagOfName(nameof(Asteroid_Field_Damage)).ToEngineFloat();

            Asteroid_Field_Damage_Rate =
                node.GetValueOfLastTagOfName(nameof(Asteroid_Field_Damage_Rate)).ToEngineFloat();

            Control_Point_Domination_Victory_Time_In_Secs =
                node.GetValueOfLastTagOfName(nameof(Control_Point_Domination_Victory_Time_In_Secs)).ToInteger();

            Hull_Vs_Hard_Points_Health_Constraint =
                node.GetValueOfLastTagOfName(nameof(Hull_Vs_Hard_Points_Health_Constraint)).ToEngineFloat();

            Auto_Rotate_For_Space_Targeting =
                node.GetValueOfLastTagOfName(nameof(Auto_Rotate_For_Space_Targeting)).ToEngineBoolean();

            In_Game_Cinematics =
                node.GetValueOfLastTagOfName(nameof(In_Game_Cinematics)).ToEngineBoolean();

            Display_Bink_Movie_Frames =
                node.GetValueOfLastTagOfName(nameof(Display_Bink_Movie_Frames)).ToEngineBoolean();

            Space_Retreat_Attrition_Factor =
                node.GetValueOfLastTagOfName(nameof(Space_Retreat_Attrition_Factor)).ToEngineFloat();
            Land_Retreat_Attrition_Factor =
                node.GetValueOfLastTagOfName(nameof(Land_Retreat_Attrition_Factor)).ToEngineFloat();
            Blockade_Run_Attrition_Factor =
                node.GetValueOfLastTagOfName(nameof(Blockade_Run_Attrition_Factor)).ToEngineFloat();


            Demo_Attract_Maps =
                node.GetValueOfLastTagOfName(nameof(Demo_Attract_Maps));
            Demo_Attract_Start_Timeout_Seconds =
                node.GetValueOfLastTagOfName(nameof(Demo_Attract_Start_Timeout_Seconds)).ToInteger();
            Demo_Attract_Map_Cycle_Delay_Seconds =
                node.GetValueOfLastTagOfName(nameof(Demo_Attract_Map_Cycle_Delay_Seconds)).ToInteger();
            Battle_Pending_Timeout_Seconds =
                node.GetValueOfLastTagOfName(nameof(Battle_Pending_Timeout_Seconds)).ToInteger();
            Message_Of_The_Day_URL =
                node.GetValueOfLastTagOfName(nameof(Message_Of_The_Day_URL));

            Battle_Load_Planet_Viewport = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Battle_Load_Planet_Viewport)));
            Battle_Load_Planet_Direction = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Battle_Load_Planet_Direction)));
            Battle_Load_Planet_Ambient = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Battle_Load_Planet_Ambient)));
            Saliency_Size = node.GetValueOfLastTagOfName(nameof(Saliency_Size)).ToEngineFloat();
            Saliency_Power = node.GetValueOfLastTagOfName(nameof(Saliency_Power)).ToEngineFloat();
            Saliency_X = node.GetValueOfLastTagOfName(nameof(Saliency_X)).ToEngineFloat();
            Saliency_Y = node.GetValueOfLastTagOfName(nameof(Saliency_Y)).ToEngineFloat();
            Saliency_Health = node.GetValueOfLastTagOfName(nameof(Saliency_Health)).ToEngineFloat();
            Saliency_Targets = node.GetValueOfLastTagOfName(nameof(Saliency_Targets)).ToEngineFloat();
            Saliency_Speed = node.GetValueOfLastTagOfName(nameof(Saliency_Speed)).ToEngineFloat();

            Star_Wars_Crawl_Start_Fadeout_Frame =
                node.GetValueOfLastTagOfName(nameof(Star_Wars_Crawl_Start_Fadeout_Frame)).ToInteger();

            Use_Reinforcement_Points = node.GetValueOfLastTagOfName(nameof(Use_Reinforcement_Points)).ToEngineBoolean();
            Main_Menu_Demo_Attract_Mode = node.GetValueOfLastTagOfName(nameof(Main_Menu_Demo_Attract_Mode)).ToEngineBoolean();

            Land_Base_Destruction_Forces_Retreat = node.GetValueOfLastTagOfName(nameof(Land_Base_Destruction_Forces_Retreat)).ToEngineBoolean();
            Space_Station_Destruction_Forces_Retreat = node.GetValueOfLastTagOfName(nameof(Space_Station_Destruction_Forces_Retreat)).ToEngineBoolean();

            Sensor_Jamming_Time = node.GetValueOfLastTagOfName(nameof(Sensor_Jamming_Time)).ToEngineFloat();

            First_Strike_Extra_Damage_Percent = node.GetValueOfLastTagOfName(nameof(First_Strike_Extra_Damage_Percent)).ToEngineFloat();
            First_Strike_Particle = node.GetValueOfLastTagOfName(nameof(First_Strike_Particle));
            Garrisoned_Max_Attack_Distance_Multiplier = node.GetValueOfLastTagOfName(nameof(Garrisoned_Max_Attack_Distance_Multiplier)).ToEngineFloat();
            Max_Remote_Bombs_Per_Player = node.GetValueOfLastTagOfName(nameof(Max_Remote_Bombs_Per_Player)).ToInteger();

            
        }
    }
}
