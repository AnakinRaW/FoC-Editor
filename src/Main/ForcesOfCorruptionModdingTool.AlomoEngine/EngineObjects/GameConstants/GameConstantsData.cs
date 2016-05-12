using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Core;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;
using ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GameConstantsData : IEngineObject
    {
        public GameConstantsData(GameConstants parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            Parent = parent;
        }

        public string Description { get; set; }

        [Description("When a land or space conflict occurs, allow pausing of Strategic/Galactic and not jump right into tactical battle until player(s) are ready")]
        public bool Strategic_Queue_Tactical_Battles { get; set; }

        public IGameXmlFile Parent { get; }

        public XmlElement Serialize()
        {
            var node = Parent.RootNode;
            node.GetElementsByTagName(nameof(Strategic_Queue_Tactical_Battles)).Last().InnerText = Strategic_Queue_Tactical_Battles.ToString();
            return node;
        }

        public void Deserialize(XmlElement node)
        {
            var strategic_Queue_Tactical_Battles = node.GetElementsByTagName(nameof(Strategic_Queue_Tactical_Battles));
            var xmlNode = strategic_Queue_Tactical_Battles.Item(strategic_Queue_Tactical_Battles.Count-1);
            if (xmlNode != null)
                Strategic_Queue_Tactical_Battles =
                    xmlNode
                        .InnerText.ToEngineBoolean();
        }
    }
}
