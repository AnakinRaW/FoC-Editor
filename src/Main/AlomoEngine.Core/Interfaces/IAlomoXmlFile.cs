using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IAlomoXmlFile : IXmlSerializable ,IHasDescription, IHasChild
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);

    }
}
