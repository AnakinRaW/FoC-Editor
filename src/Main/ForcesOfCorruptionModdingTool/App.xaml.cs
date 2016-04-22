using System;
using System.Windows;
using System.Windows.Input;
using ForcesOfCorruptionModdingTool.EditorCore.Game.Exceptions;
using ForcesOfCorruptionModdingTool.EditorCore.Mod.Exceptions;
using ForcesOfCorruptionModdingTool.Modules.DialogProvider;
using ForcesOfCorruptionModdingTool.Properties;

namespace ForcesOfCorruptionModdingTool
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App
    {
        private readonly IDialogProvider _dialogProvider = new DialogProvider();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
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
                    Current.Shutdown(-1);
                }
            }
            catch (Exception ex) when (ex is GameNotFoundException || ex is ModNotFoundException)
            {
                _dialogProvider.Alert(ex.Message + "\r\n\r\nThis error can happen if you have moved the Game/Mod to a different location. "
                                      +"\r\nPlease relocate it in the settings");
            }         
        }
    }
}
