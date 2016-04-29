using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Workspace;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Caliburn.Platform.Xaml;
using ModernApplicationFramework.MVVM.Interfaces;
using ModernApplicationFramework.MVVM.Views;
using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ForcesOfCorruptionModdingTool.Modules.MainWindow.ViewModels
{
    [Export(typeof(IDockingMainWindowViewModel))]
    public class DockingMainWindowViewModel : ModernApplicationFramework.MVVM.ViewModels.DockingMainWindowViewModel
    {
#pragma warning disable 649

        [Import]
        private IDialogProvider _dialogProvider;

        [Import]
        private IModdingToolWorkspace _workspace;

#pragma warning restore 649

        static DockingMainWindowViewModel()
        {
            ViewLocator.AddNamespaceMapping(typeof(DockingMainWindowViewModel).Namespace,
                typeof(DockingMainWindowView).Namespace);
        }

        private string _defaultTitle;

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            Window.Title = "Forces of Corruption Modding Tool";
            StatusBar.ModeText = "Ready";
            _defaultTitle = Window.Title;
            ActiveIcon = new BitmapImage(new Uri("pack://application:,,,/ForcesOfCorruptionModdingTool;component/Resources/Icons/eawActive.png"));
            PassiveIcon = new BitmapImage(new Uri("pack://application:,,,/ForcesOfCorruptionModdingTool;component/Resources/Icons/eawInactive.png"));

            _workspace.ProjectClosed += _workspace_ProjectClosed;
            _workspace.ProjectChanged += _workspace_ProjectChanged;
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
                _dialogProvider.Alert(ex.Message
                                      + "\r\n\r\nThis error can happen if you have moved the Game/Mod to a different location. "
                                      + "\r\nPlease relocate it in the settings");
            }
            catch (Exception e)
            {
                _dialogProvider.Alert(e.Message);
            }
        }

        private void _workspace_ProjectChanged(object sender, EditorCore.Workspace.EventArgs.ProjectChangedEventArgs e)
        {
            StatusBar.Mode = 1;
            StatusBar.InformationTextC = e.NewProject?.Name;
            Window.Title += $" - {e.NewProject?.Name}";
        }

        private void _workspace_ProjectClosed(object sender, EditorCore.Workspace.EventArgs.ProjectClosedEventArgs e)
        {
            StatusBar.Mode = 3;
            StatusBar.InformationTextC = string.Empty;
            Window.Title = _defaultTitle;
        }
    }
}