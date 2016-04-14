using System.Runtime.InteropServices;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public static class SystemConfiguration
    {
        public static string RuntimeName => "Microsoft .NET Framework";

        public static string RuntimeVersion => RuntimeEnvironment.GetSystemVersion();

        public static string RuntimeOwner => "© Microsoft Corporation";
    }
}
