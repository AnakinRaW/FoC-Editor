using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using AlomoEngine.Core.Interfaces.FileLayout;

namespace AlomoEngine.Xml
{
    public class XmlToObjectParser<T> where T : class
    {
        public XmlToObjectParser(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));
            if (!typeof(IAlomoXmlFile).IsAssignableFrom(typeof(T)))
                throw new InvalidDataException();
            FilePath = path;
        }

        public XmlToObjectParser(ICollection<string> pathCollection)
        {
            PathCollection = pathCollection;
        }

        private string FilePath { get; set; }

        private ICollection<string> PathCollection { get; }

        public T Parse()
        {
            try
            {
                var instace = (T)Activator.CreateInstance(typeof(T));

                var doc = new XmlDocument();
                doc.Load(FilePath);
                ((IAlomoXmlFile)instace).Open(FilePath);
                ((IAlomoXmlFile)instace).Deserialize(doc);
                return instace;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<T> ParseRange()
        {
            if (PathCollection == null)
                throw new NullReferenceException(nameof(PathCollection));
            if (PathCollection?.Count == 0)
                throw new ArgumentException(nameof(PathCollection));
            foreach (var path in PathCollection)
            {
                FilePath = path;
                yield return Parse();
            }  
        }
    }
}
