using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine
{
    public abstract class AlomoXmlFile : IGameXmlFile
    {
        protected AlomoXmlFile(IGameXmlFile parent)
        {
            Parent = parent;
        }
        public string Description { get; set; }
        public IGameXmlFile Parent { get; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);

        public XmlElement RootNode { get; set; }

        public virtual void Deserialize(XmlDocument document)
        {
            RootNode = document.DocumentElement;
        }
    }
}
