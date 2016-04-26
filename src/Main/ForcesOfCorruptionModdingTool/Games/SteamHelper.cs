using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
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

        public static async Task StartSteamGame(IGame game, Process process)
        {
            var str = Directory.GetParent(new DirectoryInfo(game.GameDirectory).FullName).FullName;

            File.Move(str + "\\runme.dat", str + "\\tmp.runme.dat.tmp");
            File.Copy(str + "\\runm2.dat", str + "\\runme.dat");
            process.Start();
            await Task.Run(() => Thread.Sleep(2000));

            File.Delete(str + "\\runme.dat");
            File.Move(str + "\\tmp.runme.dat.tmp", str + "\\runme.dat");
        }
    }
}
