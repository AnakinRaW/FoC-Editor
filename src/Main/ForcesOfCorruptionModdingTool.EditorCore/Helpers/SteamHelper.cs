using System;
using ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper;
using static ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper.RegistryHelper;

namespace ForcesOfCorruptionModdingTool.EditorCore.Helpers
{
    public static class SteamHelper
    {
        public static bool IsSteamInstalled
            =>
                GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam",
                    "SteamExe") != null;

        public static string SteamInstallPath
            => GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam", "SteamExe").ToString();

        public static bool IsSteamAppInstalled(string appId) =>
            GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam\\Apps\\" + appId, "Installed")
                .ToString() == "1";
    }
}
