using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Caliburn.Platform.Xaml;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Views;

namespace ForcesOfCorruptionModdingTool.Modules.MainWindow.ViewModels
{
    [Export(typeof(IDockingMainWindowViewModel))]
    public class DockingMainWindowViewModel : ModernApplicationFramework.MVVM.ViewModels.DockingMainWindowViewModel
    {
        [Import]private IDialogProvider _dialogProvider;

        static DockingMainWindowViewModel()
        {
            ViewLocator.AddNamespaceMapping(typeof(DockingMainWindowViewModel).Namespace,
                typeof(DockingMainWindowView).Namespace);
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            Window.Title = "Forces of Corruption Modding Tool";
            StatusBar.ModeText = "Ready";
            ActiveIcon = new BitmapImage(new Uri("pack://application:,,,/ForcesOfCorruptionModdingTool;component/Resources/Icons/eawActive.png"));
            PassiveIcon = new BitmapImage(new Uri("pack://application:,,,/ForcesOfCorruptionModdingTool;component/Resources/Icons/eawInactive.png"));
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
            //Re-show the first start screen
            if ((Keyboard.Modifiers & ModifierKeys.Shift) > 0)
            {
                Settings.Default.FirstStart = true;
                Settings.Default.Save();
            }

            var configManager = new Configuration.ConfigurationManager();
            try
            {
                if (!configManager.DoStartupConfiguration())
                {
                    Application.Current.Shutdown(-1);
                }
            }
            catch (Exception ex) when (ex is GameNotFoundException || ex is ModNotFoundException)
            {
                _dialogProvider.Alert(ex.Message + "\r\n\r\nThis error can happen if you have moved the Game/Mod to a different location. "
                                      + "\r\nPlease relocate it in the settings");
            }
        }
    }
}
