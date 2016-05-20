using System;
using System.Text;
using System.Xml;
using AlomoEngine.Core.Interfaces;

namespace AlomoEngine.Xml
{
    public class ObjectToXmlParser
    {
        public ObjectToXmlParser(IGameXmlFile file)
        {
            File = file;
        }

        private IGameXmlFile File { get; }

        public void WriteToXml(string path)
        {
            var oSettings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                OmitXmlDeclaration = false,
                Encoding = Encoding.ASCII,
                NewLineChars = Environment.NewLine,
                NewLineHandling = NewLineHandling.Replace,
                NewLineOnAttributes = true
            };

            var writer = XmlWriter.Create(path, oSettings);
            var xml = File.Serialize();
            xml.WriteTo(writer);
            writer.Close();
            writer.Dispose();

            //TODO: Add proper indention
        }
    }
}
