using System;
using System.ComponentModel;

namespace ForcesOfCorruptionModdingTool.EditorCore.Mod
{
    public interface IMod : INotifyPropertyChanged
    {
        //TODO: Add a setter later
        /// <summary>
        /// The name of the Mod
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Checks whether the mod fits the general install pattern
        /// </summary>
        bool CorrectInstalled { get; }

        /// <summary>
        /// The Root directory of the mod
        /// </summary>
        string ModRootDirectory { get; }

        /// <summary>
        /// Specifies whether a mod has XML files in the games data directory
        /// </summary>
        bool UsesAiXml { get; set; }

        /// <summary>
        /// Specifies whether a mod has lua scripts files in the games data directory
        /// </summary>
        bool UsesRootScripts { get; set; }

        /// <summary>
        /// Specifies whether a mod has custom maps in the games data directory
        /// </summary>
        bool UsesCustomMultiplayerMaps { get; set; }

        Uri IconSource { get; }
    }
}