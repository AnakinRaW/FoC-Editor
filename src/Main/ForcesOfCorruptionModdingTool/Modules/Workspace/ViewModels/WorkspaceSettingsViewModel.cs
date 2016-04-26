using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Games;
using ForcesOfCorruptionModdingTool.Mods;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Dialoges;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.ViewModels;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace.ViewModels
{
    [Export(typeof(ISettingsPage))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorkspaceSettingsViewModel : ViewModelBase, ISettingsPage
    {
        private readonly IModdingToolWorkspace _workspace;
        private string _gamePath;
        private string _sourcePath;
        private bool _isSteam;
        private readonly IDialogProvider _dialogProvider;

        [ImportingConstructor]
        public WorkspaceSettingsViewModel(IModdingToolWorkspace workspace, IDialogProvider dialogProvider)
        {
            _dialogProvider = dialogProvider;
            _workspace = workspace;
            GamePath = _workspace.Game.GameDirectory;
            SourcePath = _workspace.SourceMod.ModRootDirectory;
            IsSteam = GameFactory.GetGameType(_workspace.Game) == GameType.Steam;
        }

        public string GamePath
        {
            get { return _gamePath; }
            set
            {
                if (_gamePath == value)
                    return;
                _gamePath = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public ICommand BrowseGameCommand => new Command(BrowseGame);

        public ICommand BrowseSourceCommand => new Command(BrowseSource);

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

        public void Apply()
        {
            _workspace.Game = IsSteam
                ? GameFactory.CreateGame(GameType.Steam, GamePath)
                : GameFactory.CreateGame(GameType.ForcesOfCorruption, GamePath);
            _workspace.SourceMod = ModFactory.CreateMod(SourcePath);

            Settings.Default.GamePath = GamePath;
            Settings.Default.SourceModPath = SourcePath;
            Settings.Default.IsGameSteam = IsSteam;
            Settings.Default.Save();
        }

        public bool CanApply()
        {
            string message = $"Error at {Path + "\\" + Name}\r\n\r\n";
            bool result = true;
            if (!GameFactory.FindGame(GameType.FocOrSteam, GamePath))
            {
                message += "The given Game Path does not contain a valid game\r\n";
                result = false;
            }

            if (!ModFactory.FindMod(SourcePath))
            {
                message += ("The given Mod Path does not contain a valid mod\r\n");
                result = false;
            }

            if (!result)
                _dialogProvider.Alert(message);
            return result;
        }

        public int SortOrder => 1;
        public string Name => "General";
        public string Path => "Environment";
    }
}