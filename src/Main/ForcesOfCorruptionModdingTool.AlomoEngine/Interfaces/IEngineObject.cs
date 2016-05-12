using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces
{
    public interface IEngineObject
    {
        string Description { get; set; }

        IGameXmlFile Parent { get; }

        XmlElement Serialize();

        void Deserialize(XmlElement node);
    }
}
