using System;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Xml.Layout
{
    public abstract class AbstractXmlTagCategory : IXmlTagCategory
    {
        protected AbstractXmlTagCategory(IAlomoXmlFile file)
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