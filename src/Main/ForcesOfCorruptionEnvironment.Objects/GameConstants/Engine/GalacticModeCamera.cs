using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;
using AlomoEngine.Xml.DataTypes.Enums;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticModeCamera : AbstractXmlTagCategory
    {
        public GalacticModeCamera(IAlomoXmlFile file) : base(file) {}

        public double GMC_InitialPitchAngleDegrees { get; set; }

        public double GMC_ZoomedPitchAngleDegrees { get; set; }

        public double GMC_InitialPullbackDistance { get; set; }

        public double GMC_ZoomedPullbackPlanetRadiusFraction { get; set; }

        public EngineFloatTupel GMC_ZoomedPositionOffsetPlanetRadiusFractions { get; set; }

        public double GMC_ZoomTime { get; set; }

        public double GMC_Battle_Zoom_Time { get; set; }

        public double GMC_Battle_Fade_Time { get; set; }

        public int Max_Galactic_Zoom_Distance { get; set; }

        public int Min_Galactic_Zoom_Speed { get; set; }

        public int Max_Galactic_Zoom_Speed { get; set; }

        public int Galactic_Zoom_Acceleration { get; set; }

        public double Galactic_Zoom_Light_Level { get; set; }

        public EngineIntegerTupel Galactic_Zoom_In_Light_Angle { get; set; }

        public EngineIntegerTupel Galactic_Zoom_Out_Light_Angle { get; set; }

        public EngineFloatTupel Galactic_Zoom_In_Station_Offset { get; set; }

        public double Galactic_Zoom_In_Station_Rotation { get; set; }

        public EngineFloatTupel Starting_Galactic_Camera_Position { get; set; }

        public double Camera_Stop_Left { get; set; }

        public double Camera_Stop_Right { get; set; }

        public double Camera_Z_Position { get; set; }


        public override XmlElement Serialize()
        {
            var node = File.RootNode;
            node.SetValueOfLastTagOfName(nameof(GMC_InitialPitchAngleDegrees), GMC_InitialPitchAngleDegrees.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPitchAngleDegrees), GMC_ZoomedPitchAngleDegrees.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_InitialPullbackDistance), GMC_InitialPullbackDistance.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPullbackPlanetRadiusFraction), GMC_ZoomedPullbackPlanetRadiusFraction.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomedPositionOffsetPlanetRadiusFractions), GMC_ZoomedPositionOffsetPlanetRadiusFractions.ToString());
            node.SetValueOfLastTagOfName(nameof(GMC_ZoomTime), GMC_ZoomTime.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_Battle_Zoom_Time), GMC_Battle_Zoom_Time.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(GMC_Battle_Fade_Time), GMC_Battle_Fade_Time.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Max_Galactic_Zoom_Distance), Max_Galactic_Zoom_Distance.ToString());
            node.SetValueOfLastTagOfName(nameof(Min_Galactic_Zoom_Speed), Min_Galactic_Zoom_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Max_Galactic_Zoom_Speed), Max_Galactic_Zoom_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_Acceleration), Galactic_Zoom_Acceleration.ToString());
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_Light_Level), Galactic_Zoom_Light_Level.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Light_Angle), Galactic_Zoom_In_Light_Angle.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_Out_Light_Angle), Galactic_Zoom_Out_Light_Angle.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Station_Offset), Galactic_Zoom_In_Station_Offset.ToString(EngineSparators.Space));
            node.SetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Station_Rotation), Galactic_Zoom_In_Station_Rotation.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Starting_Galactic_Camera_Position), Starting_Galactic_Camera_Position.ToString());
            node.SetValueOfLastTagOfName(nameof(Camera_Stop_Left), Camera_Stop_Left.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Camera_Stop_Right), Camera_Stop_Right.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Camera_Z_Position), Camera_Z_Position.ToString(CultureInfo.InvariantCulture));

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            GMC_InitialPitchAngleDegrees = node.GetValueOfLastTagOfName(nameof(GMC_InitialPitchAngleDegrees)).ToEngineFloat();
            GMC_ZoomedPitchAngleDegrees = node.GetValueOfLastTagOfName(nameof(GMC_ZoomedPitchAngleDegrees)).ToEngineFloat();
            GMC_InitialPullbackDistance = node.GetValueOfLastTagOfName(nameof(GMC_InitialPullbackDistance)).ToEngineFloat();
            GMC_ZoomedPullbackPlanetRadiusFraction = node.GetValueOfLastTagOfName(nameof(GMC_ZoomedPullbackPlanetRadiusFraction)).ToEngineFloat();
            GMC_ZoomedPositionOffsetPlanetRadiusFractions =
                EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(GMC_ZoomedPositionOffsetPlanetRadiusFractions)));
            GMC_ZoomTime = node.GetValueOfLastTagOfName(nameof(GMC_ZoomTime)).ToEngineFloat();
            GMC_Battle_Zoom_Time = node.GetValueOfLastTagOfName(nameof(GMC_Battle_Zoom_Time)).ToEngineFloat();
            GMC_Battle_Fade_Time = node.GetValueOfLastTagOfName(nameof(GMC_Battle_Fade_Time)).ToEngineFloat();

            Max_Galactic_Zoom_Distance = node.GetValueOfLastTagOfName(nameof(Max_Galactic_Zoom_Distance)).ToInteger();
            Min_Galactic_Zoom_Speed = node.GetValueOfLastTagOfName(nameof(Min_Galactic_Zoom_Speed)).ToInteger();
            Max_Galactic_Zoom_Speed = node.GetValueOfLastTagOfName(nameof(Max_Galactic_Zoom_Speed)).ToInteger();
            Galactic_Zoom_Acceleration = node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_Acceleration)).ToInteger();
            Galactic_Zoom_Light_Level = node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_Light_Level)).ToEngineFloat();
            Galactic_Zoom_In_Light_Angle = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Light_Angle)));
            Galactic_Zoom_Out_Light_Angle = EngineIntegerTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_Out_Light_Angle)));
            Galactic_Zoom_In_Station_Offset = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Station_Offset)));
            Galactic_Zoom_In_Station_Rotation = node.GetValueOfLastTagOfName(nameof(Galactic_Zoom_In_Station_Rotation)).ToEngineFloat();
            Starting_Galactic_Camera_Position = EngineFloatTupel.CreateFromString(node.GetValueOfLastTagOfName(nameof(Starting_Galactic_Camera_Position)));
            Camera_Stop_Left = node.GetValueOfLastTagOfName(nameof(Camera_Stop_Left)).ToEngineFloat();
            Camera_Stop_Right = node.GetValueOfLastTagOfName(nameof(Camera_Stop_Right)).ToEngineFloat();
            Camera_Z_Position = node.GetValueOfLastTagOfName(nameof(Camera_Z_Position)).ToEngineFloat();
        }
    }
}
