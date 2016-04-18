using System.ComponentModel;

namespace ForcesOfCorruptionModdingTool.EditorCore.Mod
{
    public interface IMod : INotifyPropertyChanged
    {
        string Name { get; set; }

        bool CorrectInstalled { get; }

        string ModRootDirectory { get; }

        bool UsesAiXml { get; set; }

        bool UsesRootScripts { get; set; }

        bool UsesCustomMultiplayerMaps { get; set; }
    }
}