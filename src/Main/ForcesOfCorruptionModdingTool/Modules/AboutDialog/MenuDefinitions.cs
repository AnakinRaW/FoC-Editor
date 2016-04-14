using System.ComponentModel.Composition;
using ForcesOfCorruptionModdingTool.Modules.AboutDialog.Commands;
using ModernApplicationFramework.Utilities;
using static ModernApplicationFramework.MVVM.Controls.MenuDefinitions.MenuDefinitions;

namespace ForcesOfCorruptionModdingTool.Modules.AboutDialog
{
    public static class MenuDefinitions
    {
        [Export]
        public static MenuItemDefinition HelpSeparator = new MenuItemDefinition("Separator", int.MaxValue, HelpMenu, true);

        [Export]
        public static MenuItemDefinition AboutDialog = new MenuItemDefinition<ShowDialogCommandDefinition>("Test", int.MaxValue, HelpMenu);
    }
}
