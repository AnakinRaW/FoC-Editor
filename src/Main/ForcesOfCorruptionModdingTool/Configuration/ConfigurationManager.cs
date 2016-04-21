using ForcesOfCorruptionModdingTool.Configuration.Views;

namespace ForcesOfCorruptionModdingTool.Configuration
{
    public class ConfigurationManager
    {
        public bool DoStartupConfiguration()
        {
            new FirstStartConfigView().ShowDialog();
            return true;
        }
    }
}
