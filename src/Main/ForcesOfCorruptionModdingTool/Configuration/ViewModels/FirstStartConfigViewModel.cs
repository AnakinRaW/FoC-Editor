using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Games;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Core.Themes;
using ModernApplicationFramework.Dialoges;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
namespace ForcesOfCorruptionModdingTool.Configuration.ViewModels
{
    [Export(typeof(IFirstStartConfigModel))]
    public class FirstStartConfigViewModel : Screen, IFirstStartConfigModel
    {
        private const string DefaultModSearchPath = @"Mods\Source";

        private readonly ThemeManager _manager;
        private readonly IModdingToolWorkspace _workspace;
        private string _gamePath;
        private bool _isSteam;
        private Theme _selectedTheme;
        private string _sourcePath;
        private readonly IDialogProvider _dialogProvider;

        [ImportingConstructor]
        public FirstStartConfigViewModel(ThemeManager manager, IModdingToolWorkspace workspace, IDialogProvider dialogProvider)
        {
            _manager = manager;
            _workspace = workspace;
            _dialogProvider = dialogProvider;
        }

        public IEnumerable<Theme> Themes => _manager.Themes;

        public string GamePath
        {
            get { return _gamePath; }
            set
            {
                if (_gamePath == value)
                    return;
                _gamePath = value;
                NotifyOfPropertyChange();
            }
        }

        public string SourcePath
        {
            get { return _sourcePath; }
            set
            {
                if (_sourcePath == value)
                    return;
                _sourcePath = value;
                NotifyOfPropertyChange();
            }
        }

        public bool IsSteam
        {
            get { return _isSteam; }
            set
            {
                if (_isSteam == value)
                    return;
                _isSteam = value;
                NotifyOfPropertyChange();
            }
        }

        public Theme SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                if (value == _selectedTheme)
                    return;
                _selectedTheme = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand BrowseGameCommand => new Command(BrowseGame);

        public ICommand BrowseSourceCommand => new Command(BrowseSource);

        public ICommand StartCommand => new CommandWrapper(Start, CanStart);

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            SetupGame();
            SetupMod();
        }

        private void BrowseGame()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != true)
                return;
            GamePath = dialog.SelectedPath;
            try
            {
                IsSteam = GameFactory.GetGameType(GameFactory.CreateGame(GameType.FocOrSteam, GamePath)) == GameType.Steam;
            }
            catch (Exception)
            {
                //Ignored
            }
        }

        private void BrowseSource()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != true)
                return;
            SourcePath = dialog.SelectedPath;
        }

        private bool CanStart()
        {
            if (SelectedTheme == null)
                return false;

            if (!GameFactory.FindGame(GameType.FocOrSteam, GamePath))
                return false;

            if (!ModFactory.FindMod(SourcePath))
                return false;

            return true;
        }

        private void SetupGame()
        {
            try
            {
                var game = GameFactory.CreateGame(GameType.FocOrSteam);
                GamePath = game.GameDirectory;

                if (game is SteamGame)
                    IsSteam = true;
            }
            catch (GameExceptions)
            {
                _dialogProvider.ShowMessage("Was not able to find any game instance.\r\n" +
                                            "If you have installed the games, please enter the correct path manually.");
            }
            catch (NotSupportedException)
            {
                _dialogProvider.ShowMessage("We are sorry but game which was found is not supported.\r\n" +
                                            "If you have installed a supported game, please enter the correct path manually.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Since the source mod can be anywhere on the computer we should not force to use a mod from the Mods property from the game
        private void SetupMod()
        {
            try
            {
                //Don't throw too many errors right at the start.
                if (GamePath == null)
                    return;
                SourcePath = ModFactory.CreateMod(Path.Combine(GamePath, DefaultModSearchPath)).ModRootDirectory;
            }
            catch (ModExceptions)
            {
                _dialogProvider.ShowMessage("Was not able to find the source mod which comes along with the map editor.\r\n" +
                                "If you have installed the source mod somewhere else, please enter the correct path manually.");
            }
        }

        private void Start()
        {
            _manager.SaveTheme(SelectedTheme.Name);
            _workspace.Game = IsSteam
                ? GameFactory.CreateGame(GameType.Steam, GamePath)
                : GameFactory.CreateGame(GameType.ForcesOfCorruption, GamePath);
            _workspace.SourceMod = ModFactory.CreateMod(SourcePath);

            Settings.Default.GamePath = GamePath;
            Settings.Default.SourceModPath = SourcePath;
            Settings.Default.IsGameSteam = IsSteam;
            Settings.Default.Save();

            TryClose(true);
        }
    }
}