using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DebugHotKeyLoadData : IEngineObject
    {
        public List<string> Debug_Hot_Key_Load_Map { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Map_Script { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Campaign { get; set; } = new List<string>();

        public string Description { get; set; }

        public void Serialize()
        {
            
        }

        public void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsInElementRange(null, nameof(Debug_Hot_Key_Load_Map));

            var debug_Hot_Key_Load_Map = node.GetElementsByTagName(nameof(Debug_Hot_Key_Load_Map));
            foreach (XmlNode element in debug_Hot_Key_Load_Map)
            {
                Debug_Hot_Key_Load_Map.Add(element.InnerText);
            }

            var debug_Hot_Key_Load_Map_Script = node.GetElementsByTagName(nameof(Debug_Hot_Key_Load_Map_Script));
            foreach (XmlNode element in debug_Hot_Key_Load_Map_Script)
            {
                Debug_Hot_Key_Load_Map_Script.Add(element.InnerText);
            }

            var debug_Hot_Key_Load_Campaign = node.GetElementsByTagName(nameof(Debug_Hot_Key_Load_Campaign));
            foreach (XmlNode element in debug_Hot_Key_Load_Campaign)
            {
                Debug_Hot_Key_Load_Campaign.Add(element.InnerText);
            }
        }
    }
}
