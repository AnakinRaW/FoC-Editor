using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Commands;
using ModernApplicationFramework.Core.Events;
using ModernApplicationFramework.Interfaces.Controls;
using ModernApplicationFramework.MVVM.Controls;
using ModernApplicationFramework.MVVM.Core;

namespace ForcesOfCorruptionModdingTool.Modules.ModLauncher
{
    [Export(typeof(IModLauncher))]
    public class ModLauncherViewModel : Tool, IModLauncher
    {
        private IEnumerable<IMod> _installedMods;
        private string _language;
        private IMod _selectedMod;

        public ModLauncherViewModel()
        {
            UpdateModList();
            Workspace.GameChanged += (sender, args) => UpdateModList();
            Workspace.Game.ModsChaned += (sender, args) => UpdateModList();
        }

        public IModdingToolWorkspace Workspace => IoC.Get<IModdingToolWorkspace>();
        public override PaneLocation PreferredLocation => PaneLocation.Right;

        public override string DisplayName { get; set; } = "Mod Launcher";

        public override double PreferredWidth => 350;

        public IEnumerable<IMod> InstalledMods
        {
            get { return _installedMods; }
            set
            {
                if (Equals(value, _installedMods))
                    return;
                _installedMods = value;
                NotifyOfPropertyChange();
            }
        }

        public string Language
        {
            get { return _language; }
            set
            {
                if (_language == value)
                    return;
                _language = value;
                NotifyOfPropertyChange();
            }
        }

        public IMod SelectedMod
        {
            get { return _selectedMod; }
            set
            {
                if (value == _selectedMod)
                    return;
                _selectedMod = value;
                NotifyOfPropertyChange();
            }
        }

        public ICommand LaunchCommand => new CommandWrapper(Launch, CanLaunch);
        public bool IsWindowMode { get; set; }

        public override void SaveState(BinaryWriter writer)
        {
            base.SaveState(writer);
            writer.Write(IsWindowMode);
            writer.Write(Language);
        }

        public override void LoadState(BinaryReader reader)
        {
            base.LoadState(reader);
            IsWindowMode = reader.ReadBoolean();
            Language = reader.ReadString();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            var lvc = view as IListViewContainer;
            if (lvc != null)
                lvc.ItemDoubledClicked += Lvc_ItemDoubledClicked;
        }

        private bool CanLaunch()
        {
            return Workspace.Game != null;
        }

        private void Launch()
        {
            var gla = new GameLaunchArguments();
            if (_selectedMod != null)
                gla.Mod = _selectedMod;
            if (IsWindowMode)
                gla.Windowed = true;
            if (!string.IsNullOrEmpty(Language))
                gla.Language = Language;
            Workspace.Game.StartGame(gla);
        }

        private void Lvc_ItemDoubledClicked(object sender, ItemDoubleClickedEventArgs e)
        {
            LaunchCommand.Execute(null);
        }

        private void UpdateModList()
        {
            InstalledMods = new List<IMod> { new EmptyMod() }.Concat(Workspace.Game.Mods).OrderBy(x => x.Name);
        }

        //Used to add a null mod which make the launcher start the vanilla game.
        private sealed class EmptyMod : IMod
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public string Name => null;
            public bool CorrectInstalled => true;
            public string ModRootDirectory => null;
            public bool UsesAiXml { get; set; }
            public bool UsesRootScripts { get; set; }
            public bool UsesCustomMultiplayerMaps { get; set; }

            public Uri IconSource
                => new Uri("/ForcesOfCorruptionModdingTool.Modules;component/Resources/Icons/foc.ico", UriKind.Relative);
        }
    }
}