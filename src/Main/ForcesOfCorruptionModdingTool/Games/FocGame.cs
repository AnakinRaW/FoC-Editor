using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.HashProvider;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Windows.ProcessManager;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Properties;

namespace ForcesOfCorruptionModdingTool.Games
{
    public sealed class FocGame : BasicGame
    {
        public FocGame(string gameDirectory, bool fullInstantiate = true) : base(gameDirectory)
        {
            if (!fullInstantiate)
                return;
            Mods = FindMods();
        }
        protected override string GameconstantsUpdateHash => "4306d0c45d103cd11ff6743d1c3d9366";
        protected override string GraphicdetailsUpdateHash => "4d7e140887fc1dd52f47790a6e20b5c5";
        protected override string ExeFileName => "swfoc.exe";

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
        public override string Name => "Forces of Corruption";

        public override void StartGame(GameLaunchArguments arguments)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = GameDirectory + @"\swfoc.exe",
                    Arguments = arguments.ToString(),
                    WorkingDirectory = GameDirectory,
                    UseShellExecute = false
                }
            };
            try
            {
                process.Start();
                IsRunning = true;
                var pm = new ProcessManager(process);
                pm.PropertyChanged += Pm_PropertyChanged;
            }
            catch (Exception e)
            {
                throw new GameStartException($"Could not start the game: {e.Message}");
            }
        }

        private void Pm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(IsRunning))
                return;
            if (((ProcessManager)sender).IsRunning)
                return;
            IsRunning = false;
            ((ProcessManager)sender).Dispose();
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
                throw new GamePatchException($"Could not patch: {Name}");
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

        public override IEnumerable<IMod> FindMods(bool instantiate = true)
        {
            var dirs = Directory.GetDirectories(Path.Combine(GameDirectory, "Mods"));
            var mods = new List<IMod>();
            foreach (var dir in dirs)
            {
                try
                {
                    mods.Add(ModFactory.CreateMod(this, new DirectoryInfo(dir).Name, instantiate));
                }
                catch (ModExceptions) { }
            }
            return mods;
        }
    }
}
