using ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper;

namespace ForcesOfCorruptionModdingTool.Games
{
    public static class SteamHelper
    {
        public static bool IsSteamInstalled
            =>
                RegistryHelper.GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam",
                    "SteamExe") != null;

        public static string SteamInstallPath
            => RegistryHelper.GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam", "SteamExe").ToString();

        public static bool IsSteamAppInstalled(string appId) =>
            RegistryHelper.GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam\\Apps\\" + appId, "Installed")
                .ToString() == "1";
    }
}
