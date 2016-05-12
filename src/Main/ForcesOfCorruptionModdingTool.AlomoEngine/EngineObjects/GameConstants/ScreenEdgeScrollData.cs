using System.Diagnostics.CodeAnalysis;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class ScreenEdgeScrollData : EngineObject
    {
        public ScreenEdgeScrollData(IGameXmlFile parent) : base(parent) {}

        public int Tactical_Edge_Scroll_Region { get; set; }

        public int Tactical_Max_Scroll_Speed { get; set; }

        public int Tactical_Min_Scroll_Speed { get; set; }

        public int Tactical_Offscreen_Scroll_Region { get; set; }

        public int Strategic_Edge_Scroll_Region { get; set; }

        public int Strategic_Max_Scroll_Speed { get; set; }

        public int Strategic_Min_Scroll_Speed { get; set; }

        public int Strategic_Offscreen_Scroll_Region { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;

            node.SetValueOfLastTagOfName(nameof(Tactical_Edge_Scroll_Region), Tactical_Edge_Scroll_Region.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Max_Scroll_Speed), Tactical_Max_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Min_Scroll_Speed), Tactical_Min_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Tactical_Offscreen_Scroll_Region), Tactical_Offscreen_Scroll_Region.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Edge_Scroll_Region), Strategic_Edge_Scroll_Region.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Max_Scroll_Speed), Strategic_Max_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Min_Scroll_Speed), Strategic_Min_Scroll_Speed.ToString());
            node.SetValueOfLastTagOfName(nameof(Strategic_Offscreen_Scroll_Region), Strategic_Offscreen_Scroll_Region.ToString());

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsOverElements(nameof(Tactical_Edge_Scroll_Region),
                nameof(Strategic_Offscreen_Scroll_Region));

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
        }
    }
}
