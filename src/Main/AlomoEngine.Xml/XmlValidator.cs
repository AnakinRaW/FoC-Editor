using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using AlomoEngine.Core.Extensions;

namespace AlomoEngine.Xml
{
    public class XmlValidator
    {
        private int _errors;

        public XmlValidator(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(nameof(file));
            SchemeFileStream = new FileStream(file, FileMode.Open);
        }

        public XmlValidator(Stream schmeStream)
        {
            SchemeFileStream = schmeStream;
        }

        private Stream SchemeFileStream { get; }

        public bool Validate(string xmlFile)
        {
            if (!File.Exists(xmlFile))
                throw new FileNotFoundException(nameof(xmlFile));
            using (var stream = new FileStream(xmlFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                return InternalValidate(stream);
        }

        public bool Validate(Stream xmlStream)
        {
            return InternalValidate(xmlStream);
        }

        private bool InternalValidate(Stream fileStream)
        {
            fileStream.Position = 0;
            SchemeFileStream.Position = 0;
            bool result;
            try
            {
                var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation | XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += Settings_ValidationEventHandler;
                if (SchemeFileStream != null)
                    using (var schemaReader = XmlReader.Create(SchemeFileStream))
                        settings.Schemas.Add(null, schemaReader);
                using (var schemaReader = XmlReader.Create(Properties.Resources.GlobalEngineElements.ToStream()))
                    settings.Schemas.Add(null, schemaReader);
                var reader = XmlReader.Create(fileStream, settings);
                while (reader.Read())
                {
                }
                reader.Close();
                //TODO: Do something with the errors
                if (_errors > 0)
                    throw new Exception();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                SchemeFileStream?.Dispose();
            }
            return result;
        }

        private void Settings_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            _errors++;
        }
    }
}