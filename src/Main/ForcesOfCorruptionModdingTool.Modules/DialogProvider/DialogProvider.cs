using System.ComponentModel.Composition;
using System.Windows;

namespace ForcesOfCorruptionModdingTool.Modules.DialogProvider
{
    [Export(typeof(IDialogProvider))]
    public class DialogProvider :IDialogProvider
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Forces of Corruption Modding Editor", MessageBoxButton.OK,
                MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        public bool Ask(string message, MessageBoxButton button)
        {
            MessageBoxResult result = MessageBox.Show(message, "Forces of Corruption Modding Editor?", button,
                MessageBoxImage.None, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
            return result.HasFlag(MessageBoxResult.OK);
        }

        public void Alert(string message)
        {
            MessageBox.Show(message, "Forces of Corruption Modding Editor", MessageBoxButton.OK,
                MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        public void Inform(string message)
        {
            MessageBox.Show(message, "Forces of Corruption Modding Editor", MessageBoxButton.OK,
                MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }
    }
}
