using System.ComponentModel.Composition;
using ModernApplicationFramework.Utilities;

namespace ForcesOfCorruptionModdingTool.Modules.Defreezer
{
    public static class MenuDefinitions
    {
        [Export]
        public static MenuItemDefinition Output = new MenuItemDefinition<OpenDefreezerCommandDefinition>("Test", 2, ModernApplicationFramework.MVVM.Controls.MenuDefinitions.MenuDefinitions.ViewMenu);
    }
}
