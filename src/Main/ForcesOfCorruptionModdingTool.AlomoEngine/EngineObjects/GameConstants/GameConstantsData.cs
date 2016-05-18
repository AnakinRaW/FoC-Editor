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
        }
    }
}
