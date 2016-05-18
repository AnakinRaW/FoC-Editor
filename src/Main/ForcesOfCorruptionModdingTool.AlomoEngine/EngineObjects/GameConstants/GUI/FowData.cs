using System;
using System.ComponentModel;
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
    public class FowData : EngineObject
    {
        private bool _use_Overrun_Auto_Resolve_Multiple;
        public FowData(IGameXmlFile parent) : base(parent) {}

        public int Minimum_Tactical_Overrun_Time_In_Secs { get; set; }

        [Description("Permanently reveals FOW when X-1 odds reached.")]
        public double Tactical_Overrun_Multiple { get; set; }

        public double Overrun_Auto_Resolve_Multiple { get; set; }

        public EngineColor LandFOWColor { get; set; }

        public EngineColor SpaceFOWColor { get; set; }

        public EngineColor SpaceReinforceFOWColor { get; set; }

        public EngineColor SetupPhaseFOWColor { get; set; }

        public EngineColor SetupPhaseInvalidDragColor { get; set; }

        public double SpaceFOWHeight { get; set; }

        public int SetupPhaseCountdownSeconds { get; set; }

        public double DesiredLandFOWCellSize { get; set; }

        public double DesiredSpaceFOWCellSize { get; set; }

        public double LandFOWRegrowTime { get; set; }

        public double SpaceFOWRegrowTime { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Minimum_Tactical_Overrun_Time_In_Secs), Minimum_Tactical_Overrun_Time_In_Secs.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Overrun_Multiple), Tactical_Overrun_Multiple.ToString(CultureInfo.InvariantCulture));
            if (_use_Overrun_Auto_Resolve_Multiple)
                node.SetValueOfLastTagOfName(nameof(Overrun_Auto_Resolve_Multiple), Overrun_Auto_Resolve_Multiple.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandFOWColor), LandFOWColor.ToString());
            node.SetValueOfLastTagOfName(nameof(SpaceFOWColor), SpaceFOWColor.ToString());
            node.SetValueOfLastTagOfName(nameof(SpaceReinforceFOWColor), SpaceReinforceFOWColor.ToString());
            node.SetValueOfLastTagOfName(nameof(SetupPhaseFOWColor), SetupPhaseFOWColor.ToString());
            node.SetValueOfLastTagOfName(nameof(SetupPhaseInvalidDragColor), SetupPhaseInvalidDragColor.ToString());
            node.SetValueOfLastTagOfName(nameof(SpaceFOWHeight), SpaceFOWHeight.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SetupPhaseCountdownSeconds), SetupPhaseCountdownSeconds.ToString());
            node.SetValueOfLastTagOfName(nameof(DesiredLandFOWCellSize), DesiredLandFOWCellSize.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(DesiredSpaceFOWCellSize), DesiredSpaceFOWCellSize.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(LandFOWRegrowTime), LandFOWRegrowTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(SpaceFOWRegrowTime), SpaceFOWRegrowTime.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
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

            LandFOWColor = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(LandFOWColor)));
            SpaceFOWColor = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(SpaceFOWColor)));
            SpaceReinforceFOWColor = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(SpaceReinforceFOWColor)));
            SetupPhaseFOWColor = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(SetupPhaseFOWColor)));
            SetupPhaseInvalidDragColor = EngineColor.CreateColorFromString(node.GetValueOfLastTagOfName(nameof(SetupPhaseInvalidDragColor)));
            SpaceFOWHeight = node.GetValueOfLastTagOfName(nameof(SpaceFOWHeight)).ToEngineFloat();
            SetupPhaseCountdownSeconds = node.GetValueOfLastTagOfName(nameof(SetupPhaseCountdownSeconds)).ToInteger();
            DesiredLandFOWCellSize = node.GetValueOfLastTagOfName(nameof(DesiredLandFOWCellSize)).ToEngineFloat();
            DesiredSpaceFOWCellSize = node.GetValueOfLastTagOfName(nameof(DesiredSpaceFOWCellSize)).ToEngineFloat();
            LandFOWRegrowTime = node.GetValueOfLastTagOfName(nameof(LandFOWRegrowTime)).ToEngineFloat();
            SpaceFOWRegrowTime = node.GetValueOfLastTagOfName(nameof(SpaceFOWRegrowTime)).ToEngineFloat();
        }
    }
}
