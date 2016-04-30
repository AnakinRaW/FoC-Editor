using ForcesOfCorruptionModdingTool.EditorCore.Game;
using ForcesOfCorruptionModdingTool.EditorCore.RegistryHelper;
using System;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using static ForcesOfCorruptionModdingTool.Configuration.GameConfiguration;
using static ForcesOfCorruptionModdingTool.Games.SteamHelper;

namespace ForcesOfCorruptionModdingTool.Games
{
    public static class GameFactory
    {
        /// <summary>
        /// Trys to find a Game by the given type on the Computer
        /// </summary>
        /// <param name="type">Game-type to check</param>
        /// <returns>Return an instance of the game</returns>
        public static IGame CreateGame(GameType type)
        {
            switch (type)
            {
                case GameType.EmpireAtWar:
                    return CreateEaw();

                case GameType.ForcesOfCorruption:
                    return CreateFoc();

                case GameType.Steam:
                    return CreateSteam();

                case GameType.FocOrSteam:
                    return CreateFocOrSteam();

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static IGame CreateGame(GameType type, string path)
        {
            switch (type)
            {
                case GameType.EmpireAtWar:
                    return CreateEaw(path);

                case GameType.ForcesOfCorruption:
                    return CreateFoc(path);

                case GameType.Steam:
                    return CreateSteam(path);

                case GameType.FocOrSteam:
                    return CreateFocOrSteam(path);

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


        /// <summary>
        /// Gets the type of a game
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static GameType GetGameType(IGame game)
        {
            if (game is EawGame)
                return GameType.EmpireAtWar;
            if (game is FocGame)
                return GameType.ForcesOfCorruption;
            return GameType.Steam;
        }

        // ReSharper disable once UnusedParameter.Local
        private static IGame CreateEaw(string path)
        {
            throw new NotSupportedException("Empire at War is currently not supported.");
        }

        private static IGame CreateEaw()
        {
            throw new NotSupportedException("Empire at War is currently not supported.");
        }

        private static IGame CreateFoc(string path)
        {
            if (!FindGame(GameType.FocOrSteam, path))
                throw new GameNotFoundException();
            return new FocGame(path);
        }

        private static IGame CreateFoc()
        {
            return new FocGame(GetFocInstallPath());
        }

        private static IGame CreateFocOrSteam(string path)
        {
            if (!FindGame(GameType.FocOrSteam, path))
                throw new GameNotFoundException();
            if (new DirectoryInfo(path).Name == FoCSteamFolderName
                && new DirectoryInfo(Directory.GetParent(path).FullName).Name == SteamEawFolderName)
                return CreateSteam(path);
            return CreateFoc(path);

        }

        private static IGame CreateFocOrSteam()
        {
            if (!IsSteamInstalled)
                return CreateFoc();
            return !IsSteamAppInstalled(FocSteamAppId) ? CreateFoc() : CreateSteam();
        }

        private static IGame CreateSteam(string path)
        {
            if (!FindGame(GameType.FocOrSteam, path))
                throw new GameNotFoundException();
            return new SteamGame(path);
        }

        private static IGame CreateSteam()
        {
            var path = Path.Combine(GetFocInstallPath(), "corruption");
            return new SteamGame(path);
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

        private static bool FindFocOrSteam(string directoryPath)
        {
            try
            {
                new FocGame(directoryPath, false);
                new SteamGame(directoryPath, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string GetFocInstallPath()
        {
            return RegistryHelper.GetValueFromKey(RegistryRootTypes.HkLocalMachine, FocRegistryPath, "InstallPath").ToString();
        }
    }
}