using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core.DataTypes;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticModeCamera : EngineObject
    {
        public GalacticModeCamera(IGameXmlFile parent) : base(parent) {}

        public double GMC_InitialPitchAngleDegrees { get; set; }

        public double GMC_ZoomedPitchAngleDegrees { get; set; }

        public double GMC_InitialPullbackDistance { get; set; }

        public double GMC_ZoomedPullbackPlanetRadiusFraction { get; set; }

        public EngineFloatTupel GMC_ZoomedPositionOffsetPlanetRadiusFractions { get; set; }

        public double GMC_ZoomTime { get; set; }

        public double GMC_Battle_Zoom_Time { get; set; }

        public double GMC_Battle_Fade_Time { get; set; }


        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(GMC_InitialPitchAngleDegrees), GMC_InitialPitchAngleDegrees.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPitchAngleDegrees), GMC_ZoomedPitchAngleDegrees.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_InitialPullbackDistance), GMC_InitialPullbackDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPullbackPlanetRadiusFraction), GMC_ZoomedPullbackPlanetRadiusFraction.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPositionOffsetPlanetRadiusFractions), GMC_ZoomedPositionOffsetPlanetRadiusFractions.ToString());
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomTime), GMC_ZoomTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_Battle_Zoom_Time), GMC_Battle_Zoom_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_Battle_Fade_Time), GMC_Battle_Fade_Time.ToString(CultureInfo.InvariantCulture));
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            GMC_InitialPitchAngleDegrees = node.GetValueOfLastTagOfName(nameof(GMC_InitialPitchAngleDegrees)).ToEngineFloat();
            GMC_ZoomedPitchAngleDegrees = node.GetValueOfLastTagOfName(nameof(GMC_ZoomedPitchAngleDegrees)).ToEngineFloat();
            GMC_InitialPullbackDistance = node.GetValueOfLastTagOfName(nameof(GMC_InitialPullbackDistance)).ToEngineFloat();
            GMC_ZoomedPullbackPlanetRadiusFraction = node.GetValueOfLastTagOfName(nameof(GMC_ZoomedPullbackPlanetRadiusFraction)).ToEngineFloat();
            GMC_ZoomedPositionOffsetPlanetRadiusFractions =
                EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(GMC_InitialPitchAngleDegrees)));
            GMC_ZoomTime = node.GetValueOfLastTagOfName(nameof(GMC_ZoomTime)).ToEngineFloat();
            GMC_Battle_Zoom_Time = node.GetValueOfLastTagOfName(nameof(GMC_Battle_Zoom_Time)).ToEngineFloat();
            GMC_Battle_Fade_Time = node.GetValueOfLastTagOfName(nameof(GMC_Battle_Fade_Time)).ToEngineFloat();
        }
    }
}
