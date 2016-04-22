using System.Windows;

namespace ForcesOfCorruptionModdingTool.Modules.DialogProvider
{
    public interface IDialogProvider
    {
        void ShowMessage(string message);

        bool Ask(string message, MessageBoxButton button);

        void Alert(string message);

        void Inform(string message);

    }
}
