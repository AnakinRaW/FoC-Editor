using System.Xml;

namespace AlomoEngine.Core.Interfaces.XML
{
    public interface IXmlSerializable
    {
        XmlElement Serialize();

        void Deserialize(XmlElement node);
    }
}
