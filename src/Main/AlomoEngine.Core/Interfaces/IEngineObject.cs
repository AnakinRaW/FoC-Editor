using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IEngineObject
    {
        string Description { get; set; }

        IAlomoXmlFile Parent { get; }

        XmlElement Serialize();

        void Deserialize(XmlElement node);
    }
}
