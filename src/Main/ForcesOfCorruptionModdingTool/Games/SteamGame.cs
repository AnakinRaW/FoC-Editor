using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.HashProvider;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper;
using ForcesOfCorruptionModdingTool.Properties;

namespace ForcesOfCorruptionModdingTool.Games
{
    public class SteamGame : BasicGame
    {
        public SteamGame(string gameDirectory) : base(gameDirectory) {}
        protected override string GameconstantsUpdateHash => "4306d0c45d103cd11ff6743d1c3d9366";
        protected override string GraphicdetailsUpdateHash => "4d7e140887fc1dd52f47790a6e20b5c5";
        protected override string ExeFileName => "swfoc.exe";

        public override string SaveGameDirectrory
        {
            get
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    @"Saved Games\Petroglyph\Empire At War - Forces of Corruption\Save\");
                return !Directory.Exists(folder) ? "" : folder;
            }
        }

        public override IEnumerable<IMod> Mods { get; protected set; }
        public override string Name => "Forces of Corruption (Steam)";

        public override void StartGame(GameLaunchArguments arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = RegistryHelper.GetValueFromKey(RegistryRootTypes.HkCurrentUser, "Software\\Valve\\Steam", "SteamExe").ToString()
            };

            arguments.GameArguments = "-applaunch 32470 swfoc";

            startInfo.Arguments = arguments.ToString();

            string str = Directory.GetParent(new DirectoryInfo(Directory.GetCurrentDirectory()).FullName).FullName;

            if (!Exists())
                throw new GameExceptions("The game is not installed correctly");

            File.Move(str + "\\runme.dat", str + "\\tmp.runme.dat.tmp");
            File.Copy(str + "\\runm2.dat", str + "\\runme.dat");
            Process.Start(startInfo);
            Thread.Sleep(2000);
            File.Delete(str + "\\runme.dat");
            File.Move(str + "\\tmp.runme.dat.tmp", str + "\\runme.dat");
        }

        public override void Patch()
        {
            try
            {
                if (!Directory.Exists(GameDirectory + @"Data\XML"))
                    Directory.CreateDirectory(GameDirectory + @"Data\XML");

                if (File.Exists(GameDirectory + @"Data\XML\GAMECONSTANTS.XML"))
                    File.Delete(GameDirectory + @"Data\XML\GAMECONSTANTS.XML");
                if (File.Exists(GameDirectory + @"Data\XML\GRAPHICDETAILS.XML"))
                    File.Delete(GameDirectory + @"Data\XML\GRAPHICDETAILS.XML");

                File.WriteAllText(GameDirectory + @"Data\XML\GAMECONSTANTS.XML", Resources.GAMECONSTANTS);
                File.WriteAllText(GameDirectory + @"Data\XML\GRAPHICDETAILS.XML", Resources.GRAPHICDETAILS);
            }
            catch (Exception)
            {
                // Ignored
            }
        }

        public override bool IsPatched()
        {
            if (!File.Exists(GameDirectory + @"Data\XML\GAMECONSTANTS.XML") ||
                !File.Exists(GameDirectory + @"Data\XML\GRAPHICDETAILS.XML"))
                return false;
            var hashProvider = new HashProvider();
            if (hashProvider.GetFileHash(GameDirectory + @"Data\XML\GAMECONSTANTS.XML") != GameconstantsUpdateHash)
                return false;
            if (hashProvider.GetFileHash(GameDirectory + @"Data\XML\GRAPHICDETAILS.XML") != GraphicdetailsUpdateHash)
                return false;
            return true;
        }

        public override IEnumerable<IMod> FindMods()
        {
            throw new NotImplementedException();
        }
    }
}
