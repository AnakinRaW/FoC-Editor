using System.Xml;
using AlomoEngine.Core.Interfaces.XML;

namespace AlomoEngine.Core.Interfaces.FileLayout
{
    public interface IAlomoXmlFile : IXmlSerializable ,IHasDescription, IHasChild
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);

    }
}
