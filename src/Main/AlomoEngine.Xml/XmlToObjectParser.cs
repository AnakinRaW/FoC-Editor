using System;
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


        private string FilePath { get; }

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
    }
}
