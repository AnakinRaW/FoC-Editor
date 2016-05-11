using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces
{
    public interface IGameXmlFile: IEngineObject
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);
    }
}
