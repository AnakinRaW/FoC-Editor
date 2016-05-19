using System;
using System.IO;
using System.Xml;
using ForcesOfCorruptionModdingTool.AlomoEngine.Interfaces;

namespace ForcesOfCorruptionModdingTool.AlomoEngine.XmlEngine
{
    public class XmlToObjectParser<T> where T : class
    {
        public XmlToObjectParser(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(nameof(path));
            if (!typeof(IGameXmlFile).IsAssignableFrom(typeof(T)))
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
                ((IGameXmlFile)instace).Deserialize(doc);
                return instace;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
