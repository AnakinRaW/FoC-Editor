using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using ForcesOfCorruptionModdingTool.Extensions;
using Microsoft.Win32;

namespace ForcesOfCorruptionModdingTool
{
    public partial class App
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var ex = e.Exception;
            MessageBox.Show(ex.UnwrapCompositionException().Message);

            using (var writer = new StreamWriter(Path.Combine(Configuration.ProductConfiguration.AppdataPath, "Excpetions.txt"), true))
            {
                writer.WriteLine(ex.UnwrapCompositionException().Message);
                writer.WriteLine(ex.UnwrapCompositionException().InnerException.Message);
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
            Current.Shutdown();
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            if (!Directory.Exists(Configuration.ProductConfiguration.AppdataPath))
                Directory.CreateDirectory(Configuration.ProductConfiguration.AppdataPath);
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
