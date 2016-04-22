using System;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;

namespace ForcesOfCorruptionModdingTool.Mods
{
    public static class ModFactory
    {
        /// <summary>
        /// Searches the Game structure for a mod with a given name.
        /// Ought to be used to create mod objects for a game.
        /// </summary>
        /// <param name="game">the game to check</param>
        /// <param name="name">the name of the mod</param>
        /// <returns>returns an instance of the mod</returns>
        public static IMod CreateMod(IGame game, string name)
        {
            if (!Directory.Exists(Path.Combine(game.GameDirectory, "Mods")))
                throw new GameExceptions("The Game does not have any mods");
            if (!Directory.Exists(Path.Combine(game.GameDirectory, "Mods", name)))
                throw new ModNotFoundException($"The Game does not have a mod named: {name} installed.");

            return new Mod(Path.Combine(game.GameDirectory, "Mods", name));
        }

        /// <summary>
        /// Creates an mod instance from a given path
        /// </summary>
        /// <param name="path">root directory of the mod</param>
        /// <returns>returns an instance of the mod</returns>
        public static IMod CreateMod(string path)
        {
            return new Mod(path);
        }

        /// <summary>
        /// Checks whether a mod exists a the given path
        /// </summary>
        /// <param name="path">path to check</param>
        /// <returns></returns>
        public static bool FindMod(string path)
        {
            try
            {
                new Mod(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
