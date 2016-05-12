using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects.GameConstants
{
    public class ObjectMaximumMultipliers: IEngineObject
    {
        public string Description { get; set; }
        public IGameXmlFile Parent { get; }
        public XmlElement Serialize()
        {
            throw new NotImplementedException();
        }

        public void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }
    }
}
