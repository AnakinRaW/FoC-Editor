using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IGameXmlFile: IEngineObject
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);
    }
}
