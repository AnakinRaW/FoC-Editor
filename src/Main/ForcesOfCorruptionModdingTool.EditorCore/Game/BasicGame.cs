using System.Collections.Generic;
using System.IO;
using ForcesOfCorruptionModdingTool.EditorCore.Extensions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public abstract class BasicGame : IGame
    {
        protected abstract string GameconstantsUpdateHash { get; }

        protected abstract string GraphicdetailsUpdateHash { get; }

        protected abstract string ExeFileName { get; }


        protected BasicGame(string gameDirectory)
        {
            GameDirectory = gameDirectory;
            if (!Exists())
                throw new GameExceptions("The game does not exists at the given location");
        }


        public string GameDirectory { get; }
        public abstract string SaveGameDirectrory { get; }
        public abstract IEnumerable<IMod> Mods { get; protected set; }
        public bool Exists()
        {
            var result = File.Exists(Path.Combine(GameDirectory, ExeFileName));
            if (!File.Exists(Path.Combine(GameDirectory, "PerceptionFunctionG.dll")))
                result = false;
            if (!File.Exists(Path.Combine(GameDirectory, "mss32.dll")))
                result = false;
            if (!File.Exists(Path.Combine(GameDirectory, "binkw32.dll")))
                result = false;
            if (!Directory.Exists(Path.Combine(GameDirectory, "Data")))
                result = false;
            return result;
        }

        public abstract void StartGame(GameLaunchArguments arguments);

        public abstract void Patch();

        public void DeleteMod(IMod mod)
        {
            if (mod.CorrectInstalled)
                return;

            if (mod.UsesAiXml)
                if (Directory.Exists(Path.Combine(GameDirectory, @"Data\XML\AI")))
                    Directory.Delete(Path.Combine(GameDirectory, @"Data\XML\AI"), true);
            if (mod.UsesCustomMultiplayerMaps)
                if (Directory.Exists(Path.Combine(GameDirectory, @"Data\CustomMaps")))
                    Directory.Delete(Path.Combine(GameDirectory, @"Data\CustomMaps"), true);
            if (mod.UsesRootScripts)
                if (Directory.Exists(Path.Combine(GameDirectory, @"Data\Scripts")))
                    Directory.Delete(Path.Combine(GameDirectory, @"Data\Scripts"), true);

            var path = Path.Combine(GameDirectory, Path.GetDirectoryName(mod.ModRootDirectory));
            Directory.Delete(path, true);

            Mods = Mods.Delete(mod);
        }

        public void AddMod(IMod mod)
        {
            Mods = Mods.Add(mod);
        }

        public abstract IEnumerable<IMod> FindMods();

        public void ClearDataFolder()
        {
            if (Directory.Exists(Path.Combine(GameDirectory, @"Data\CustomMaps")))
                Directory.Delete(Path.Combine(GameDirectory, @"Data\CustomMaps"), true);
            if (Directory.Exists(Path.Combine(GameDirectory, @"Data\Scripts")))
                Directory.Delete(Path.Combine(GameDirectory, @"Data\Scripts"), true);
            if (Directory.Exists(Path.Combine(GameDirectory, @"Data\XML")))
                Directory.Delete(Path.Combine(GameDirectory, @"Data\XML"), true);
            Patch();
        }
    }
}
