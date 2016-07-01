using System;
using System.Xml;
using AlomoEngine.Xml.Layout;

namespace AlomoEngine.EngineTypes
{
    public class AlomoXmlFile : AbstractAlomoXmlFile
    {
        public override XmlElement Serialize()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(XmlElement node)
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(XmlDocument node)
        {
            base.Deserialize(node);
        }
    }
}
