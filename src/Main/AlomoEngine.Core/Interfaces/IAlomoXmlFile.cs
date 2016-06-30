using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IAlomoXmlFile : IXmlSerializable ,IHasDescription
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);

    }
}
