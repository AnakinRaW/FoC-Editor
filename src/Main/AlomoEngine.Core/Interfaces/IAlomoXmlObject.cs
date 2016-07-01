using System.Xml;

namespace AlomoEngine.Core.Interfaces
{
    public interface IAlomoXmlObject : IHasXmlFile, IHasChild
    {
        XmlAttributeCollection Attributes { get; set; }
        XmlNode Node { get; set; }
    }
}