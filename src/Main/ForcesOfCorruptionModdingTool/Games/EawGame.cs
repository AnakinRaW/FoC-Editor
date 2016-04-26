using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.HashProvider;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.Properties;

namespace ForcesOfCorruptionModdingTool.Games
{
    public class EawGame : BasicGame
    {
        public EawGame(string gameDirectory) : base(gameDirectory) {}
        protected override string GameconstantsUpdateHash => "1d44b0797c8becbe240adc0098c2302a";
        protected override string GraphicdetailsUpdateHash => string.Empty;
        protected override string ExeFileName => "sweaw.exe";

        public override string SaveGameDirectrory
        {
            get
            {
                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    @"Petroglyph\Empire At War - Forces of Corruption\Save\");
                return !Directory.Exists(folder) ? "" : folder;
            }
        }

        public override IEnumerable<IMod> Mods { get; protected set; }
        public override string Name => "Empire at War";

        public override GameProcessData GameProcessData => new GameProcessData();

        public override void StartGame(GameLaunchArguments arguments)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(GameDirectory, ExeFileName),
                    Arguments = arguments.ToString(),
                    WorkingDirectory = GameDirectory,
                    UseShellExecute = false
                }
            };
            try
            {
                process.Start();
            }
            catch (Exception)
            {
                throw new GameStartException("Could not start the Game");
            }
        }

        public override void Patch()
        {
            try
            {
                if (Directory.Exists(GameDirectory + @"Data\XML"))
                    Directory.Delete(GameDirectory + @"Data\XML", true);
                Directory.CreateDirectory(GameDirectory + @"Data\XML");
                File.WriteAllText(GameDirectory + @"Data\XML\GAMECONSTANTS.XML", Resources.GAMECONSTANTSeaw);
            }
            catch (Exception)
            {
                throw new GamePatchException($"Could not patch: {Name}");
            }
        }

        public override bool IsPatched()
        {
            if (!File.Exists(GameDirectory + @"Data\XML\GAMECONSTANTS.xml"))
                return false;
            var hashProvider = new HashProvider();
            if (hashProvider.GetFileHash(GameDirectory + @"Data\XML\GAMECONSTANTS.xml") != GameconstantsUpdateHash)
                return false;
            if (Directory.GetFiles(GameDirectory + @"Data\XML").Length != 1)
                return false;
            return true;
        }

        public override IEnumerable<IMod> FindMods(bool instantiate = true)
        {
            throw new NotSupportedException("EaW is not supported");
        }
    }
}
