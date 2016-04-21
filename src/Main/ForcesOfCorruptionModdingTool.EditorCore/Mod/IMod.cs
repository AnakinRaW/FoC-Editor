using System.ComponentModel;

namespace ForcesOfCorruptionModdingTool.EditorCore.Mod
{
    public interface IMod : INotifyPropertyChanged
    {
        //TODO: Add a setter later
        string Name { get; }

        bool CorrectInstalled { get; }

        string ModRootDirectory { get; }

        bool UsesAiXml { get; set; }

        bool UsesRootScripts { get; set; }

        bool UsesCustomMultiplayerMaps { get; set; }
    }
}