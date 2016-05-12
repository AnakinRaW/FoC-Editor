using System;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects
{
    public abstract class EngineObject : IEngineObject
    {
        protected EngineObject(IGameXmlFile parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            Parent = parent;
        }

        public string Description { get; set; }

        public IGameXmlFile Parent { get; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);
    }
}
