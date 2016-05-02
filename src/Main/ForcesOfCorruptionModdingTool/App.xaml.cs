using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;

namespace ForcesOfCorruptionModdingTool
{
    public partial class App
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            //var ex = e.Exception;
            //var exInner = ex.InnerException;
            //var msg = ex.Message + "\n\n" + ex.StackTrace + "\n\n" + "Inner Exception:\n" + exInner?.Message + "\n\n"
            //             + exInner?.StackTrace;
            //MessageBox.Show(msg, "Application Halted!", MessageBoxButton.OK);
            //e.Handled = true;
            //Current.Shutdown();

            var ex = e.Exception;
            MessageBox.Show(ex.UnwrapCompositionException().Message);

        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Get45Or451FromRegistry();
        }

        private static void Get45Or451FromRegistry()
        {
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey?.GetValue("Release") != null)
                {
                    if (CheckFor46DotVersion((int) ndpKey.GetValue("Release")))
                        return;
                    MessageBox.Show("Required .NetFramework Version 4.6 was not found");
                    Current.Shutdown();
                }
                else
                {
                    MessageBox.Show("Required .NetFramework Version 4.6 was not found");
                    Current.Shutdown();
                }
            }
        }

        private static bool CheckFor46DotVersion(int releaseKey)
        {
            return releaseKey >= 393295;
        }
    }
}
