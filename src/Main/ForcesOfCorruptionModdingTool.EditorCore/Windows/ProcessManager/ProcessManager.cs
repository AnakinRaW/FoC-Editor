using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using ForcesOfCorruptionModdingTool.EditorCore.Annotations;

namespace ForcesOfCorruptionModdingTool.EditorCore.Windows.ProcessManager
{
    public class ProcessManager : INotifyPropertyChanged, IDisposable
    {
        private bool _isRunning;

        public ProcessManager(Process process)
        {
            var ps = Process.GetProcesses();
            if (ps.Any(x => x == process))
                throw new ProcessNotExistException($"{process?.ProcessName} does not exist.");
            Process = process;
            IsRunning = true;
            Process.EnableRaisingEvents = true;
            Process.Exited += P_Exited;
        }

        public ProcessManager(string name)
        {
            var ps = Process.GetProcessesByName(name);

            var p = ps.FirstOrDefault();
            if (p == null)
                throw new ProcessNotExistException($"{name} does not exist.");
            Process = p;
            IsRunning = true;
            Process.EnableRaisingEvents = true;
            Process.Exited += P_Exited;
        }

        public Process Process { get; private set; }

        public bool IsRunning
        {
            get { return _isRunning; }
            private set
            {
                if (value == _isRunning)
                    return;
                _isRunning = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void P_Exited(object sender, EventArgs e)
        {
            IsRunning = false;
        }

        public void Dispose()
        {
            Process.Exited -= P_Exited;
            Process = null;
        }
    }
}