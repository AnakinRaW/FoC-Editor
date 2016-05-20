using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using AlomoEngine.SaveGame;
using Caliburn.Micro;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.MVVM.Controls;
using ModernApplicationFramework.MVVM.Core;
using ModernApplicationFramework.MVVM.Modules.OutputTool;

namespace ForcesOfCorruptionModdingTool.Modules.Defreezer.ViewModels
{
    [Export(typeof(IDefreezerTool))]
    public class DefreezerViewModel : Tool, IDefreezerTool
    {
        private IEnumerable<ISaveGameFile> _itemSource;
        private ISaveGameFile _selectedSaveGame;

        public DefreezerViewModel()
        {
            UpdateSaveGameList();
            Workspace.GameChanged += (sender, args) => UpdateSaveGameList();
        }

        private void UpdateSaveGameList()
        {
            ItemSource = SaveGame.GetAllFilesFromDirectory(Workspace.Game.SaveGameDirectrory);
        }

        public override PaneLocation PreferredLocation => PaneLocation.Right;

        public override string DisplayName { get; set; } = "Save Game Defreezer";

        public IModdingToolWorkspace Workspace => IoC.Get<IModdingToolWorkspace>();

        private IOutput _output => IoC.Get<IOutput>();

        public IEnumerable<ISaveGameFile> ItemSource
        {
            get { return _itemSource; }
            set
            {
                if (Equals(value, _itemSource))
                    return;
                _itemSource = value;
                NotifyOfPropertyChange();
            }
        }

        public ISaveGameFile SelectedSaveGame
        {
            get { return _selectedSaveGame; }
            set
            {
                if (Equals(value, _selectedSaveGame))
                    return;
                _selectedSaveGame = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand OpenExplorerCommand => new CommandWrapper(OpenExplorer, CanOpenExplorer);

        private void OpenExplorer()
        {
            var directoryInfo = new FileInfo(SelectedSaveGame.FilePath).Directory;
            if (directoryInfo != null)
                Process.Start(directoryInfo.FullName);
        }

        private bool CanOpenExplorer()
        {
            var directoryInfo = new FileInfo(SelectedSaveGame.FilePath).Directory;
            return directoryInfo != null && Directory.Exists(directoryInfo.FullName);
        }

        public ICommand DefreezeCommand => new CommandWrapper(Defreeze, CanDefreeze);

        private void Defreeze()
        {
            _output.AppendLine($"Defreezing: {SelectedSaveGame.Name}");
            new Defreezer(SelectedSaveGame).DefreezeSaveGame();
            _output.AppendLine($"Defreezing Finished: {SelectedSaveGame.Name}");
        }

        private bool CanDefreeze()
        {
            return SelectedSaveGame != null;
        }
    }
}
