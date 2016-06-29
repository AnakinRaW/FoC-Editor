using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using AlomoEngine;
using AlomoEngine.Core.Interfaces;
using AlomoEngine.Xml;

namespace ForcesOfCorruptionEnvironment.Objects.GameConstants.Engine
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DebugHotKeyLoadData : EngineObject
    {
        public DebugHotKeyLoadData(IGameXmlFile parent) : base(parent) { }

        public List<string> Debug_Hot_Key_Load_Map { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Map_Script { get; set; } = new List<string>();

        public List<string> Debug_Hot_Key_Load_Campaign { get; set; } = new List<string>();

        public override XmlElement Serialize()
        {
            var node = Parent.RootNode;

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Map), Debug_Hot_Key_Load_Map);

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Map_Script), Debug_Hot_Key_Load_Map_Script);

            node.AddMultipleTagsFromValueList(nameof(Debug_Hot_Key_Load_Campaign), Debug_Hot_Key_Load_Campaign);

            return node;
        }

        public override void Deserialize(XmlElement node)
        {
            Description = node.GetCommentsInElementRange(null, nameof(Debug_Hot_Key_Load_Map));

            Debug_Hot_Key_Load_Map = node.GetValuesByNameFromMultipleTags(nameof(Debug_Hot_Key_Load_Map));

            Debug_Hot_Key_Load_Map_Script = node.GetValuesByNameFromMultipleTags(nameof(Debug_Hot_Key_Load_Map_Script));

            Debug_Hot_Key_Load_Campaign = node.GetValuesByNameFromMultipleTags(nameof(Debug_Hot_Key_Load_Campaign));
        }
    }
}
