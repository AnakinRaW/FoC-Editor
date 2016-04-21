using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using System.Collections.Generic;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public interface IGame
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
        /// <returns>Returns a list of game mods</returns>
        IEnumerable<IMod> FindMods();


        /// <summary>
        /// Clears the root Data folder to default
        /// </summary>
        void ClearDataFolder();
    }
}