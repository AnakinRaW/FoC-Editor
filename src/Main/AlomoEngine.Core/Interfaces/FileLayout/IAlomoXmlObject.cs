using System.Xml;
using AlomoEngine.Core.Interfaces.XML;

namespace AlomoEngine.Core.Interfaces.FileLayout
{
    public interface IAlomoXmlObject : IHasXmlFile, IHasChild
    {
        XmlAttributeCollection Attributes { get; set; }
        XmlNode Node { get; set; }
    }
}