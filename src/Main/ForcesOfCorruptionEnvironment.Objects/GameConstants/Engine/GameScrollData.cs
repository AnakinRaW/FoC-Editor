using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;
using AlomoEngine.Xml.DataTypes;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameScrollData : EngineObject
    {
        public GameScrollData(IAlomoXmlFile parent) : base(parent) {}

        public int Tactical_Edge_Scroll_Region { get; set; }

        public int Tactical_Max_Scroll_Speed { get; set; }

        public int Tactical_Min_Scroll_Speed { get; set; }

        public int Tactical_Offscreen_Scroll_Region { get; set; }

        public int Strategic_Edge_Scroll_Region { get; set; }

        public int Strategic_Max_Scroll_Speed { get; set; }

        public int Strategic_Min_Scroll_Speed { get; set; }

        public int Strategic_Offscreen_Scroll_Region { get; set; }

        public double Push_Scroll_Speed_Modifier { get; set; }

        [Description("Acceleration on scrolling. The higher the number, the less acceleration will be evident")]
        public double Scroll_Deceleration_Factor { get; set; }

        [Description("Acceleration on scrolling. The higher the number, the less acceleration will be evident")]
        public double Scroll_Acceleration_Factor { get; set; }

        public double Galactic_Right_Button_Scroll_Speed_Factor { get; set; }

        public double Galactic_Scroll_Plane { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;

            node.SetValueOfLastTagOfName(nameof(Tactical_Edge_Scroll_Region), Tactical_Edge_Scroll_Region.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Max_Scroll_Speed), Tactical_Max_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Min_Scroll_Speed), Tactical_Min_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Offscreen_Scroll_Region),
                Tactical_Offscreen_Scroll_Region.ToString());

            node.SetValueOfLastTagOfName(nameof(Strategic_Edge_Scroll_Region), Strategic_Edge_Scroll_Region.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Max_Scroll_Speed), Strategic_Max_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Min_Scroll_Speed), Strategic_Min_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Offscreen_Scroll_Region),
                Strategic_Offscreen_Scroll_Region.ToString());

            node.SetValueOfLastTagOfName(nameof(Push_Scroll_Speed_Modifier),
                Push_Scroll_Speed_Modifier.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Scroll_Deceleration_Factor),
                Scroll_Deceleration_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Scroll_Acceleration_Factor),
                Scroll_Acceleration_Factor.ToString(CultureInfo.InvariantCulture));

            node.SetValueOfLastTagOfName(nameof(Galactic_Right_Button_Scroll_Speed_Factor),
                Galactic_Right_Button_Scroll_Speed_Factor.ToString(CultureInfo.InvariantCulture));
            node.SetValueOfLastTagOfName(nameof(Galactic_Scroll_Plane),
                Galactic_Scroll_Plane.ToString(CultureInfo.InvariantCulture));

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsOverElements(nameof(Tactical_Edge_Scroll_Region),
                nameof(Scroll_Acceleration_Factor));

            Tactical_Edge_Scroll_Region =
                node.GetValueOfLastTagOfName(nameof(Tactical_Edge_Scroll_Region)).ToInteger();

            Tactical_Max_Scroll_Speed =
                node.GetValueOfLastTagOfName(nameof(Tactical_Max_Scroll_Speed)).ToInteger();

            Tactical_Min_Scroll_Speed =
                node.GetValueOfLastTagOfName(nameof(Tactical_Min_Scroll_Speed)).ToInteger();

            Tactical_Offscreen_Scroll_Region =
                node.GetValueOfLastTagOfName(nameof(Tactical_Offscreen_Scroll_Region)).ToInteger();

            Strategic_Edge_Scroll_Region =
                node.GetValueOfLastTagOfName(nameof(Strategic_Edge_Scroll_Region)).ToInteger();

            Strategic_Max_Scroll_Speed =
                node.GetValueOfLastTagOfName(nameof(Strategic_Max_Scroll_Speed)).ToInteger();

            Strategic_Min_Scroll_Speed =
                node.GetValueOfLastTagOfName(nameof(Strategic_Min_Scroll_Speed)).ToInteger();

            Strategic_Offscreen_Scroll_Region =
                node.GetValueOfLastTagOfName(nameof(Strategic_Offscreen_Scroll_Region)).ToInteger();

            Push_Scroll_Speed_Modifier =
                node.GetValueOfLastTagOfName(nameof(Push_Scroll_Speed_Modifier)).ToEngineFloat();

            Scroll_Deceleration_Factor =
                node.GetValueOfLastTagOfName(nameof(Scroll_Deceleration_Factor)).ToEngineFloat();

            Scroll_Acceleration_Factor =
                node.GetValueOfLastTagOfName(nameof(Scroll_Acceleration_Factor)).ToEngineFloat();

            Galactic_Right_Button_Scroll_Speed_Factor =
                node.GetValueOfLastTagOfName(nameof(Galactic_Right_Button_Scroll_Speed_Factor)).ToEngineFloat();

            Galactic_Scroll_Plane =
                node.GetValueOfLastTagOfName(nameof(Galactic_Scroll_Plane)).ToEngineFloat();
        }
    }
}
