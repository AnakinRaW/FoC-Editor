using ForcesOfCorruptionModdingTool.Properties;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.Caliburn.Platform.Xaml;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public class ConfigurationManager
    {
        public bool DoStartupConfiguration()
        {
            if (Settings.Default.FirstStart)
                return DoFirstStartConfiguration();
            return true;
        }

        private bool DoFirstStartConfiguration()
        {
            var fc = IoC.Get<IFirstStartConfigModel>();
            fc.DisplayName = "First Start Configuration";

            var windowManager = IoC.Get<IWindowManager>();
            if (windowManager.ShowDialog(fc) != true)
                return false;

            Settings.Default.FirstStart = false;
            Settings.Default.Save();
            return true;
        }
    }
}
