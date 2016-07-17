using System.Xml;
using AlomoEngine.Core.Interfaces.Engine;
using AlomoEngine.Core.Interfaces.XML;

namespace AlomoEngine.Core.Interfaces.FileLayout
{
    public interface IAlomoXmlFile : IEngineFile, IXmlSerializable ,IHasDescription, IHasChild
    {
        XmlElement RootNode { get; set; }

        void Deserialize(XmlDocument document);

    }
}
