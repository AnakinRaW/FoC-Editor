using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using System.Collections.Generic;
using System.ComponentModel;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public interface IGame : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the directory containing the main executable file
        /// </summary>
        string GameDirectory { get; }

        /// <summary>
        /// Stores the directory containing the save games
        /// </summary>
        string SaveGameDirectrory { get; }

        /// <summary>
        /// Contains a list of game mods
        /// </summary>
        IEnumerable<IMod> Mods { get; }

        /// <summary>
        /// Returns the name of the Game
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Contains Data of the Process
        /// </summary>
        GameProcessData GameProcessData { get; }

        /// <summary>
        /// Checks whether the game is installed
        /// </summary>
        /// <returns>status of game existence</returns>
        bool Exists();

        /// <summary>
        /// Starts the game with specified arguments
        /// </summary>
        /// <param name="arguments">Game arguments</param>
        void StartGame(GameLaunchArguments arguments);

        /// <summary>
        /// Installs the latests hot fixes from PG
        /// </summary>
        void Patch();

        /// <summary>
        /// Checks if the game has the latest patch installed
        /// </summary>
        /// <returns>returns if patched or not</returns>
        bool IsPatched();

        /// <summary>
        /// Deletes a mod
        /// </summary>
        /// <param name="mod">Mod to delete</param>
        void DeleteMod(IMod mod);

        /// <summary>
        /// Adds a mod
        /// </summary>
        /// <param name="mod">Mod to add</param>
        void AddMod(IMod mod);

        /// <summary>
        /// Finds mods for the game
        /// </summary>
        /// <param name="instantiate">Specifies whether the mods should instantiated or not</param>
        /// <returns>Returns a list all mods of the game</returns>
        IEnumerable<IMod> FindMods(bool instantiate = true);

        /// <summary>
        /// Clears the root Data folder to default
        /// </summary>
        void ClearDataFolder();
    }
}