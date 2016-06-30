using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine
{
    public abstract class AbstractAlomoXmlFile : IAlomoXmlFile
    {
        public string Description { get; set; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);

        public XmlElement RootNode { get; set; }

        public virtual void Deserialize(XmlDocument document)
        {
            RootNode = document.DocumentElement;
        }
    }
}
