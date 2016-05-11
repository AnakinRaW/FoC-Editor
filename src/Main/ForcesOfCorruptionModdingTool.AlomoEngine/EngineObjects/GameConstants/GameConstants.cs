// ReSharper disable InconsistentNaming

using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    public class GameConstants : IGameXmlFile
    {
        public XmlElement RootNode { get; set; }
        public DebugHotKeyLoadData DebugHotKeyLoadData { get; protected set; }

        public GameConstantsData GameConstantsData { get; protected set; }


        public string Description { get; set; }

        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public void Deserialize(XmlDocument document)
        {
            RootNode = document.DocumentElement;
            DebugHotKeyLoadData = new DebugHotKeyLoadData();
            DebugHotKeyLoadData.Deserialize(RootNode);

            GameConstantsData = new GameConstantsData();
            GameConstantsData.Deserialize(RootNode);
        }

        public void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        
    }
}