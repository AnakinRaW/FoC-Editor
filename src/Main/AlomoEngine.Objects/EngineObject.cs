using System;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Objects
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
