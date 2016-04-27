using ForcesOfCorruptionModdingTool.EditorCore.Mod;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public class GameLaunchArguments
    {
        /// <summary>
        /// Specific Gametype dependent arguments. Can be empty.
        /// </summary>
        public string GameArguments { get; set; }

        public bool Windowed { get; set; }

        public IMod Mod { get; set; }

        public string Language { get; set; }

        /// <summary>
        /// Converts Properties into a valid argument string
        /// </summary>
        /// <returns>Command line arguments</returns>
        public override string ToString()
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(GameArguments))
                result += $" {GameArguments}";
            if (Windowed)
                result += " WINDOWED";
            if (Mod != null)
                result += $@" MODPATH=Mods\{Mod.Name}";
            if (!string.IsNullOrEmpty(Language))
                result += $" LANGUAGE={Language}";
            return result;
        }
    }
}