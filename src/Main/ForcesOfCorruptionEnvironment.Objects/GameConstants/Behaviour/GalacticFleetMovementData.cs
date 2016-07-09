using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Core.Interfaces.FileLayout;
using AlomoEngine.Xml;
using AlomoEngine.Xml.Layout;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Behaviour
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GalacticFleetMovementData : AbstractXmlTagCategory
    {
        public GalacticFleetMovementData(IAlomoXmlFile file) : base(file) {}

        public string Fleet_Movement_Line_Texture_Name { get; set; }

        public string Fleet_Hyperspace_Band_Texture_Name { get; set; }

        public string WaypointLineTextureName { get; set; }

        public string LoopWaypointLineTextureName { get; set; }

        public string WaypointFlagModelName { get; set; }

        public override XmlElement Serialize()
        {
            var node = File.RootNode;
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
