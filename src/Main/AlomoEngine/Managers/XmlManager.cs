using System;
using AlomoEngine.Core.Classes;

namespace AlomoEngine.Managers
{
    public sealed class XmlManager : FileMananger
    {
        public XmlManager(FilesystemWatcherSettings settings) : base(settings)
        {
            if (string.Equals(settings.Filter, "*.xml", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("The settings must be limited to .xml files");
        }

        public override string[] SupportedExtensions => new[] {"*.xml"};

        public override void Initialize()
        {     
            var files = GetAllFilePaths();
        }
    }
}
