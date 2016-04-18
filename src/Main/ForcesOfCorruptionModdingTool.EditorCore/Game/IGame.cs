using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using System.Collections.Generic;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public interface IGame
    {
        string GameDirectory { get; }

        string SaveGameDirectrory { get; }

        IEnumerable<IMod> Mods { get; }

        bool Exists();

        void StartGame(GameLaunchArguments arguments);

        void Patch();

        void DeleteMod(IMod mod);

        void ClearDataFolder();
    }
}