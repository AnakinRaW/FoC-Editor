using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.EngineObjects
{
    public abstract class GameXmlFile : IGameXmlFile
    {
        protected GameXmlFile(IGameXmlFile parent)
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
