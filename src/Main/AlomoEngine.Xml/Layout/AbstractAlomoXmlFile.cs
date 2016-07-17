using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using AlomoEngine.Core.Interfaces.FileLayout;

namespace AlomoEngine.Xml.Layout
{
    public abstract class AbstractAlomoXmlFile : IAlomoXmlFile
    {
        protected AbstractAlomoXmlFile()
        {
            Childs = new List<IAlomoXmlObject>();
        }

        public string Description { get; set; }

        public abstract XmlElement Serialize();

        public abstract void Deserialize(XmlElement node);

        public List<IAlomoXmlObject> Childs { get; set; }

        public void AddChildRange(IEnumerable node)
        {
            foreach (XmlNode xmlNode in node)
                if (xmlNode.HasChildObjects())
                    Childs.Add(new AlomoXmlObject(xmlNode, this));
        }

        public XmlElement RootNode { get; set; }

        public virtual void Deserialize(XmlDocument document)
        {
            if (document?.DocumentElement == null)
                throw new ArgumentNullException();

            RootNode = document.DocumentElement;
            var content = RootNode.ChildNodes;

            if (content.Count == 0)
                return;

            AddChildRange(content);
        }

        public void Dispose()
        {
            
        }

        public string FilePath { get; protected set; }
        public string Name { get; protected set; }

        public void Open(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));
            FilePath = path;
            Name = Path.GetFileNameWithoutExtension(path);
        }

        public void Save(string path)
        {
            throw new NotImplementedException();
        }
    }
}