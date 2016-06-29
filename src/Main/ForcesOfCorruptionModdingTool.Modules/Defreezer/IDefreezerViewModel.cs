using System.Collections.Generic;
using System.Windows.Input;
using ForcesOfCorruptionEnvironment.SaveGame;

namespace ForcesOfCorruptionModdingTool.Modules.Defreezer
{
    public interface IDefreezerViewModel
    {
        IEnumerable<ISaveGameFile> ItemSource { get; set; }

        ISaveGameFile SelectedSaveGame { get; set; }

        ICommand OpenExplorerCommand { get; }

        ICommand DefreezeCommand { get; }
    }
}
