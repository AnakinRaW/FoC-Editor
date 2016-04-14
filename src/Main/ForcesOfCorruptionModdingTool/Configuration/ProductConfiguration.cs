using System.Collections.Generic;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public static class ProductConfiguration
    {
        public static string ProductName => "Forces of Corruption Modding Tool";

        public static string ProductVersion => typeof(ProductConfiguration).Assembly.GetName().Version.ToString();

        public static List<string> Contributers = new List<string>
        {
            "AnakinSklavenwalker"
        };

        public static List<UsedSoftwareInformation> UsedSoftware = new List<UsedSoftwareInformation>
        {
            new UsedSoftwareInformation("Gemini", "Tim Jones"),
            new UsedSoftwareInformation("Caliburn", "Rob Eisenberg, et al"),
            new UsedSoftwareInformation("AvalonDock", "Xceed"),
            new UsedSoftwareInformation("ModernApplicationFramework", "AnakinSklavenwalker"),
            new UsedSoftwareInformation(".NET Framework", "Microsoft"),
            new UsedSoftwareInformation("Visual Studio Image Library 2015", "Microsoft")
        };
    }
}
