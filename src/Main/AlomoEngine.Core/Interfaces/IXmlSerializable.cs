using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IXmlSerializable
    {
        XmlElement Serialize();

        void Deserialize(XmlElement node);
    }
}
