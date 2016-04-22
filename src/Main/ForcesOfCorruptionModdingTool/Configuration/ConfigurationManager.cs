using System;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Games;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Caliburn.Platform.Xaml;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public class ConfigurationManager
    {
        public bool DoStartupConfiguration()
        {
            return Settings.Default.FirstStart ? DoFirstStartConfiguration() : LoadConfiguration();
        }

        private bool LoadConfiguration()
        {
            var workspace = IoC.Get<IModdingToolWorkspace>();
            if (workspace == null)
                throw new NullReferenceException(nameof(workspace));

            if (!GameFactory.FindGame(GameType.FocOrSteam, Settings.Default.GamePath))
                throw new GameNotFoundException("Game could not be loaded.");
            workspace.Game = Settings.Default.IsGameSteam
                ? (IGame)new SteamGame(Settings.Default.GamePath)
                : new FocGame(Settings.Default.GamePath);


            if (!ModFactory.FindMod(Settings.Default.SourceModPath))
                throw new ModNotFoundException("Source Mod could not be loaded.");
            workspace.SourceMod = new Mod(Settings.Default.SourceModPath);
            return true;
        }

        private bool DoFirstStartConfiguration()
        {
            var fc = IoC.Get<IFirstStartConfigModel>();
            fc.DisplayName = "First Start Configuration";

            var windowManager = IoC.Get<IWindowManager>();
            if (windowManager.ShowDialog(fc) != true)
                return false;

            Settings.Default.FirstStart = false;
            Settings.Default.Save();
            return true;
        }
    }
}
