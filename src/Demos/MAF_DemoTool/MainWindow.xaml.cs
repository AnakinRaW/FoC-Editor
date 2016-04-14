using System;
using System.Windows.Controls;
using ModernApplicationFramework.ViewModels;
using Menu = ModernApplicationFramework.Controls.Menu;
using MenuItem = ModernApplicationFramework.Controls.MenuItem;
using ToolBar = ModernApplicationFramework.Controls.ToolBar;

namespace ModernApplicationFramework_DemoTool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            MinHeight = 600;
            MinWidth = 1200;
            InitializeComponent();
            SourceInitialized += MainWindow_SourceInitialized;
        }

        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            ((MainWindowViewModel)DataContext).ToolBarHostViewModel.AddToolBar(new ToolBar { IdentifierName = "Test" }, true, Dock.Top);
            ((MainWindowViewModel)DataContext).ToolBarHostViewModel.AddToolBar(new ToolBar { IdentifierName = "Test1" }, true, Dock.Top);

            var m = new Menu();

            var mi2 = new MenuItem { Header = "Test2" };
            mi2.Items.Add(new MenuItem { Header = "Test2" });

            var mi = new MenuItem { Header = "Test" };
            mi.Items.Add(mi2);


            m.Items.Add(mi);
        }
    }
}
