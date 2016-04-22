using ForcesOfCorruptionModdingTool.Configuration;
using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper;
using System;
using System.IO;
using static ForcesOfCorruptionModdingTool.EditorCore.Helpers.SteamHelper;

namespace ForcesOfCorruptionModdingTool.Games
{
    public static class GameFactory
    {
        /// <summary>
        /// Trys to find a Game by the given type on the Computer
        /// </summary>
        /// <param name="type">Game-type to check</param>
        /// <returns>Return an instance of the game</returns>
        public static IGame FindGame(GameType type)
        {
            switch (type)
            {
                case GameType.EmpireAtWar:
                    return FindEaw();

                case GameType.ForcesOfCorruption:
                    return FindFoc();

                case GameType.Steam:
                    return FindSteam();

                case GameType.FocOrSteam:
                    return FindFocOrSteam();

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// Checks whether a game of given type is installed at the specified path
        /// </summary>
        /// <param name="type">Game-type to check</param>
        /// <param name="directoryPath">Path to check</param>
        /// <returns>Returns whether a games was found or not</returns>
        public static bool FindGame(GameType type, string directoryPath)
        {
            switch (type)
            {
                case GameType.EmpireAtWar:
                    return FindEaw(directoryPath);

                case GameType.ForcesOfCorruption:
                case GameType.Steam:
                case GameType.FocOrSteam:
                    return FindFocOrSteam(directoryPath);

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static bool FindFocOrSteam(string directoryPath)
        {
            try
            {
                new FocGame(directoryPath);
                new SteamGame(directoryPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool FindEaw(string directoryPath)
        {
            try
            {
                new EawGame(directoryPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static IGame FindFocOrSteam()
        {
            if (!IsSteamInstalled)
                return FindFoc();
            if (!IsSteamAppInstalled(GameConfiguration.FocSteamAppId))
                return FindFoc();
            var path = Path.Combine(GetFocInstallPath(), "corruption");
            return new SteamGame(path);
        }

        private static string GetFocInstallPath()
        {
            return RegistryHelper.GetValueFromKey(RegistryRootTypes.HkLocalMachine, GameConfiguration.FocRegistryPath, "InstallPath").ToString();
        }

        private static IGame FindSteam()
        {
            throw new NotImplementedException();
        }

        private static IGame FindFoc()
        {
            throw new NotImplementedException();
        }

        private static IGame FindEaw()
        {
            throw new NotSupportedException("Empire at War is currently not supported.");
        }
    }
}