using System.Windows;
using System.Windows.Threading;

namespace ForcesOfCorruptionModdingTool
{
    public partial class App
    {
        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var ex = e.Exception;
            var exInner = ex.InnerException;
            string msg = ex.Message + "\n\n" + ex.StackTrace + "\n\n" + "Inner Exception:\n" + exInner.Message + "\n\n"
                         + exInner.StackTrace;
            MessageBox.Show(msg, "Application Halted!", MessageBoxButton.OK);
            e.Handled = true;
            Current.Shutdown();
        }
    }
}
