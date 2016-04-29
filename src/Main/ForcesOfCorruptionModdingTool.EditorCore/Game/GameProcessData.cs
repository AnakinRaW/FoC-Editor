using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ForcesOfCorruptionModdingTool.EditorCore.Annotations;
using ModernApplicationFramework.Caliburn;
using ModernApplicationFramework.MVVM.Interfaces;
using static ForcesOfCorruptionModdingTool.EditorCore.Windows.Processes.ProcessHelper;

namespace ForcesOfCorruptionModdingTool.EditorCore.Game
{
    public class GameProcessData : INotifyPropertyChanged
    {

        private readonly IDockingMainWindowViewModel _mainWindow = IoC.Get<IDockingMainWindowViewModel>();

        public GameProcessData()
        {
            IsProcessRunning = false;
        }

        public bool IsProcessRunning
        {
            get { return _isProcessRunning; }
            private set
            {
                if (value == _isProcessRunning)
                    return;
                _isProcessRunning = value;
                OnPropertyChanged();
                if (_isProcessRunning)
                {
                    Execute.OnUiThread(() =>_mainWindow.StatusBar.ModeText = "Game Running");
                    _mainWindow.StatusBar.Mode = 2;
                }
                else
                {
                    _mainWindow.StatusBar.RestoreMode();
                    Execute.OnUiThread(() => _mainWindow.StatusBar.ModeText = "Ready");
                }
            }
        }


        private Process _process;
        private bool _isProcessRunning;

        public Process Process
        {
            get { return _process; }
            set
            {
                if (Equals(value, _process))
                    return;
                if (_process != null)
                    _process.Exited -= Process_Exited;
                if (value == null)
                    return;
                _process = value;
                _process.EnableRaisingEvents = true;
                OnPropertyChanged();
                IsProcessRunning = IsProcessWithNameAlive(_process);
                _process.Exited += Process_Exited;
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            IsProcessRunning = false;
        }

        public void StartProcess()
        {
            Process?.Start();
            IsProcessRunning = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
