using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ForcesOfCorruptionModdingTool.EditorCore.Annotations;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;

namespace ForcesOfCorruptionModdingTool.EditorCore.Mod
{
    public class Mod : IMod
    {
        private string _name;
        private bool _usesAiXml;
        private bool _usesRootScripts;
        private bool _usesCustomMultiplayerMaps;

        public Mod(string modDirectory, bool shallFullInstantiate = true)
        {
            ModRootDirectory = modDirectory;
            if (!CorrectInstalled)
                throw new ModExceptions($"The Mod is not installed correctly: {modDirectory}");

            _name = new DirectoryInfo(ModRootDirectory).Name;

            if (!shallFullInstantiate)
                return;

            var icon = Directory.GetFiles(ModRootDirectory, "*.ico", SearchOption.TopDirectoryOnly).FirstOrDefault();
            IconSource = icon == null ? null : new Uri(icon);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return _name; }
            private set
            {
                if (_name == value)
                    return;
                _name = value;

                //TODO: add directory rename stuff here and change ModRootDirectory

                OnPropertyChanged();
            }
        }

        public bool CorrectInstalled
        {
            get
            {
                if (!ModRootDirectory.Contains(@"Mods\"))
                    return false;
                if (!Directory.Exists(ModRootDirectory))
                    return false;
                if (!Directory.Exists(Path.Combine(ModRootDirectory, "Data")))
                    return false;
                return true;
            }
        }

        public string ModRootDirectory { get; }


        public bool UsesAiXml
        {
            get { return _usesAiXml; }
            set
            {
                if (_usesAiXml == value)
                    return;
                _usesAiXml = value;
                OnPropertyChanged();
            }
        }

        public bool UsesRootScripts
        {
            get { return _usesRootScripts; }
            set
            {
                if (value == _usesRootScripts)
                    return;
                _usesRootScripts = value;
                OnPropertyChanged();
            }
        }

        public bool UsesCustomMultiplayerMaps
        {
            get { return _usesCustomMultiplayerMaps; }
            set
            {
                if (value == _usesCustomMultiplayerMaps)
                    return;
                _usesCustomMultiplayerMaps = value;
                OnPropertyChanged();
            }
        }

        public Uri IconSource { get; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}