using System.IO;
using System.Windows.Forms;
using AlomoEngine.FilesystemWatcher;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FileSystemWatcherTests
{
    [TestClass]
    public class FileSystemWatcherTest
    {
        private readonly EngineFilesystemWatcher _watcher;

        public FileSystemWatcherTest()
        {
            _watcher = new EngineFilesystemWatcher();

            var s1 = new FilesystemWatcherSettings
            {
                Path = @"C:\Test\",
                EventFilers = EventFilers.Created,
                Filter = "*.*",
                IncludeSubdirectories = true,
                NotifyFilters = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            var s2 = new FilesystemWatcherSettings
            {
                Path = @"C:\Test1\",
                EventFilers = EventFilers.Created,
                Filter = "*.*",
                IncludeSubdirectories = true,
                NotifyFilters = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            _watcher.Add(s1);
            _watcher.Add(s2);
        }

        [TestMethod]
        public void Unsubscribe()
        {
            File.Create(@"C:\Test\1.xml");
            File.Create(@"C:\Test1\1.xml");

            var fs = _watcher.GetFileSystemWatcher("C:\\Test1\\");
            _watcher.UnregisterEvent(fs, EventFilers.Created);
            _watcher.UnregisterEvent(fs, EventFilers.Created);
            _watcher.UnregisterEvent(fs, EventFilers.Created);
            _watcher.UnregisterEvent(fs, EventFilers.Created);
        }

        [TestMethod]
        public void Subscribe()
        {
            var fs = _watcher.GetFileSystemWatcher("C:\\Test1\\");
            _watcher.RegisterEvent(fs, EventFilers.Changed);


            File.Create(@"C:\Test\1.xml");
            File.Create(@"C:\Test1\1.xml");
        }

        [TestMethod]
        public void Event()
        {
            var fs = _watcher.GetFileSystemWatcher("C:\\Test1\\");
            var fs1 = _watcher.GetFileSystemWatcher("C:\\Test\\");
            _watcher.RegisterEvent(fs, EventFilers.Changed);
            _watcher.RegisterEvent(fs1, EventFilers.Changed);
            _watcher.Changed += _watcher_Changed;


            File.Create(@"C:\Test\1.xml");
            File.Create(@"C:\Test1\1.xml");
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show(@"Testing");
        }
    }
}
