using System.ComponentModel.Composition;
using ModernApplicationFramework.Utilities;

namespace ForcesOfCorruptionModdingTool.Modules.ModLauncher
{
    public static class MenuDefinitions
    {
        [Export]
        public static MenuItemDefinition Output = new MenuItemDefinition<OpenModLauncherCommandDefinition>("Test", 1, ModernApplicationFramework.MVVM.Controls.MenuDefinitions.MenuDefinitions.ViewMenu);
    }
}
