using System.Collections;
using System.Collections.Generic;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Xml.Layout
{
    public class AlomoXmlObject : IAlomoXmlObject
    {
        public AlomoXmlObject(XmlNode node, IAlomoXmlFile file)
        {
            Childs = new List<IAlomoXmlObject>();

            Node = node;
            Name = node.Name;
            File = file;

            if (node.HasAttributes())
                Attributes = node.Attributes;

            AddChildRange(node);
        }

        public string Name { get; set; }

        public IAlomoXmlFile File { get; set; }

        public XmlNode Node { get; set; }

        public XmlAttributeCollection Attributes { get; set; }

        public List<IAlomoXmlObject> Childs { get; set; }

        public void AddChildRange(IEnumerable node)
        {
            foreach (XmlNode xmlNode in Node)
                if (xmlNode.HasChildObjects())
                    Childs.Add(new AlomoXmlObject(xmlNode, File));
        }
    }
}