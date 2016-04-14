using System.Collections.Generic;
using System.Linq;
using ForcesOfCorruptionModdingTool.Configuration;

namespace ForcesOfCorruptionModdingTool.Modules.AboutDialog
{
    /// <summary>
    /// Interaktionslogik für AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        public string ProductName => ProductConfiguration.ProductName;

        public string ProductVersion => ProductConfiguration.ProductVersion;

        public string Distributers => ProductConfiguration.Contributers.Aggregate((a, b) => a + ", " + b);

        public string RuntimeName => SystemConfiguration.RuntimeName;

        public string RuntimeVersion => SystemConfiguration.RuntimeVersion;

        public string RuntimeOwner => SystemConfiguration.RuntimeOwner;

        public IEnumerable<UsedSoftwareInformation> UsedSoftware => ProductConfiguration.UsedSoftware;

        public string InfoMessage => "The Tool was developed under the terms of the German EULA of the original games. The creator of this software can not be held liable for contnet created with the tool.";
    }
}
