﻿using System.ComponentModel.Composition;
using ForcesOfCorruptionModdingTool.Modules.Workspace.Commands;
using ModernApplicationFramework.Utilities;
using static ModernApplicationFramework.MVVM.Controls.MenuDefinitions.MenuDefinitions;

namespace ForcesOfCorruptionModdingTool.Modules.Workspace
{
    public static class MenuDefinition
    {

        [Export]
        public static MenuItemDefinition NewProject = new MenuItemDefinition<NewProjectCommandDefinition>("New Project", 1, SubMenuNew);

        [Export]
        public static MenuItemDefinition CloseActiveDocument = new MenuItemDefinition<CloseProjectCommandDefinition>("Close Document", 3, FileMenu);
        
    }
}
