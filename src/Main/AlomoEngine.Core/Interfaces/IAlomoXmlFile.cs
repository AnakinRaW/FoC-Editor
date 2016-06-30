using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IAlomoXmlFile: IEngineObject
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);
    }
}
