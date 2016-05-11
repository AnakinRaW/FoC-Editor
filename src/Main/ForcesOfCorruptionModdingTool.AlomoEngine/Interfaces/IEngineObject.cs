using System.Xml;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces
{
    public interface IEngineObject
    {
        string Description { get; set; }

        void Serialize();

        void Deserialize(XmlElement node);
    }
}
