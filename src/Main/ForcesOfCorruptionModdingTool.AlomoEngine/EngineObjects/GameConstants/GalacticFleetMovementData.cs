using System.Diagnostics.CodeAnalysis;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticFleetMovementData : EngineObject
    {
        public GalacticFleetMovementData(IGameXmlFile parent) : base(parent) {}

        public string Fleet_Movement_Line_Texture_Name { get; set; }

        public string Fleet_Hyperspace_Band_Texture_Name { get; set; }

        public string WaypointLineTextureName { get; set; }

        public string LoopWaypointLineTextureName { get; set; }

        public string WaypointFlagModelName { get; set; }

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.SetValueOfLastTagOfName(nameof(Fleet_Movement_Line_Texture_Name), Fleet_Movement_Line_Texture_Name);
            node.SetValueOfLastTagOfName(nameof(Fleet_Hyperspace_Band_Texture_Name), Fleet_Hyperspace_Band_Texture_Name);
            node.SetValueOfLastTagOfName(nameof(WaypointLineTextureName), WaypointLineTextureName);
            node.SetValueOfLastTagOfName(nameof(LoopWaypointLineTextureName), LoopWaypointLineTextureName);
            node.SetValueOfLastTagOfName(nameof(WaypointFlagModelName), WaypointFlagModelName);
            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Fleet_Movement_Line_Texture_Name = node.GetValueOfLastTagOfName(nameof(Fleet_Movement_Line_Texture_Name));
            Fleet_Hyperspace_Band_Texture_Name = node.GetValueOfLastTagOfName(nameof(Fleet_Hyperspace_Band_Texture_Name));
            WaypointLineTextureName = node.GetValueOfLastTagOfName(nameof(WaypointLineTextureName));
            LoopWaypointLineTextureName = node.GetValueOfLastTagOfName(nameof(LoopWaypointLineTextureName));
            WaypointFlagModelName = node.GetValueOfLastTagOfName(nameof(WaypointFlagModelName));
        }
    }
}
