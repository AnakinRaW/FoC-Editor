using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ModernApplicationFramework.Caliburn;
using System;
using System.IO;

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
        /// Creates relevant File system structure for a mod at the given path
        /// </summary>
        /// <param name="path">Path to build up</param>
        public static void BuildUpMod(string path)
        {
            if (!Directory.Exists(Path.Combine(path, "Data")))
                Directory.CreateDirectory(Path.Combine(path, "Data"));
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
                // ReSharper disable once ObjectCreationAsStatement
                new Mod(path, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the path of a mod is/will be in a given game
        /// </summary>
        /// <param name="path">path to the mod</param>
        /// <param name="game">game to check against</param>
        /// <returns>state whether the mod is part of the game</returns>
        public static bool CheckModPathInGame(string path, IGame game)
        {
            if (game == null)
                throw new GameNotFoundException("The game could not be found");
            return path.Contains(Path.Combine(game.GameDirectory, "Mods"));
        }

        /// <summary>
        /// Checks whether the path of a mod is/will be in the workspace game
        /// </summary>
        /// <param name="path">path to the mod</param>
        /// <returns>state whether the mod is part of the workspace game</returns>
        public static bool CheckModPathInGame(string path)
        {
            var game = IoC.Get<IModdingToolWorkspace>().Game;
            if (game == null)
                throw new GameNotFoundException("The game could not be found");
            return CheckModPathInGame(path, game);
        }
    }
}