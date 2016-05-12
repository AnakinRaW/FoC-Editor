using System;
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
        public DebugHotKeyLoadData(GameConstants parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            Parent = parent;
        }

        public List<string> Debug_Hot_Key_Load_Map { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Map_Script { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Campaign { get; set; } = new List<string>();

        public string Description { get; set; }
        public IGameXmlFile Parent { get; }

        public XmlElement Serialize()
        {
            var node = Parent.RootNode;

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Map), Debug_Hot_Key_Load_Map);

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Map_Script), Debug_Hot_Key_Load_Map_Script);

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Campaign), Debug_Hot_Key_Load_Campaign);

            return node;
        }

        public void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsInElementRange(null, nameof(Debug_Hot_Key_Load_Map));

            Debug_Hot_Key_Load_Map = node.GetValuesByTagName(nameof(Debug_Hot_Key_Load_Map));

            Debug_Hot_Key_Load_Map_Script = node.GetValuesByTagName(nameof(Debug_Hot_Key_Load_Map_Script));

            Debug_Hot_Key_Load_Campaign = node.GetValuesByTagName(nameof(Debug_Hot_Key_Load_Campaign));
        }
    }
}
