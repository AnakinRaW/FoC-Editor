using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IEngineObject
    {
        string Description { get; set; }

        IGameXmlFile Parent { get; }

        XmlElement Serialize();

        void Deserialize(XmlElement node);
    }
}
