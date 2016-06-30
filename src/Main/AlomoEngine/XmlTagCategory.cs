using System;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine
{
    public abstract class XmlTagCategory : IXmlTagCategory
    {
        protected XmlTagCategory(IAlomoXmlFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            File = file;
        }

        public string Description { get; set; }

        public IAlomoXmlFile File { get; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);
    }
}
