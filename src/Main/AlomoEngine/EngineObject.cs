using System;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine
{
    public abstract class EngineObject : IEngineObject
    {
        protected EngineObject(IAlomoXmlFile parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            Parent = parent;
        }

        public string Description { get; set; }

        public IAlomoXmlFile Parent { get; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);
    }
}
