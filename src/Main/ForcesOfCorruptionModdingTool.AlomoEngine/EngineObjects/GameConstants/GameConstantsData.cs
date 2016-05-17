using System;
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
        private bool _use_Overrun_Auto_Resolve_Multiple;

        public GameConstantsData(IGameXmlFile parent) : base(parent) { }

        [Description("When a land or space conflict occurs, allow pausing of Strategic/Galactic and not jump right into tactical battle until player(s) are ready")]
        public bool Strategic_Queue_Tactical_Battles { get; set; }

        public double Fleet_Maintenance_Update_Delay_Seconds { get; set; }

        public int Political_Control_Change_Time_Seconds { get; set; }

        public double Melee_Cutoff_Range { get; set; }

        public int Minimum_Tactical_Overrun_Time_In_Secs { get; set; }

        [Description("Permanently reveals FOW when X-1 odds reached.")]
        public double Tactical_Overrun_Multiple { get; set; }

        public double Overrun_Auto_Resolve_Multiple { get; set; }

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


        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Strategic_Queue_Tactical_Battles), Strategic_Queue_Tactical_Battles.ToString());
            node.SetValueOfLastTagOfName(nameof(Fleet_Maintenance_Update_Delay_Seconds), Fleet_Maintenance_Update_Delay_Seconds.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Political_Control_Change_Time_Seconds), Political_Control_Change_Time_Seconds.ToString());
            node.SetValueOfLastTagOfName(nameof(Melee_Cutoff_Range), Melee_Cutoff_Range.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Minimum_Tactical_Overrun_Time_In_Secs), Minimum_Tactical_Overrun_Time_In_Secs.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Overrun_Multiple), Tactical_Overrun_Multiple.ToString(CultureInfo.InvariantCulture));
            if (_use_Overrun_Auto_Resolve_Multiple)
                node.SetValueOfLastTagOfName(nameof(Overrun_Auto_Resolve_Multiple), Overrun_Auto_Resolve_Multiple.ToString(CultureInfo.InvariantCulture));

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

            Minimum_Tactical_Overrun_Time_In_Secs =
                node.GetValueOfLastTagOfName(nameof(Minimum_Tactical_Overrun_Time_In_Secs)).ToInteger();

            Tactical_Overrun_Multiple =
                node.GetValueOfLastTagOfName(nameof(Tactical_Overrun_Multiple)).ToEngineFloat();

            try
            {
                Overrun_Auto_Resolve_Multiple =
                node.GetValueOfLastTagOfName(nameof(Overrun_Auto_Resolve_Multiple)).ToEngineFloat();
                _use_Overrun_Auto_Resolve_Multiple = true;
            }
            catch (IndexOutOfRangeException)
            {
                _use_Overrun_Auto_Resolve_Multiple = false;
            }

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

        }
    }
}
