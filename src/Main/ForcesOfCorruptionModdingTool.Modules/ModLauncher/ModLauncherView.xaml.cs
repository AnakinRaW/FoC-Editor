using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ModernApplicationFramework.Core.Events;
using ModernApplicationFramework.Interfaces.Controls;

namespace ForcesOfCorruptionModdingTool.Modules.ModLauncher
{
    /// <summary>
    /// Interaktionslogik für ModLauncherView.xaml
    /// </summary>
    public partial class ModLauncherView : IListViewContainer
    {
        private EventHandler<ItemDoubleClickedEventArgs> _itemDoubleClicked;

        public event EventHandler<ItemDoubleClickedEventArgs> ItemDoubledClicked
        {
            add
            {
                var eventHandler = _itemDoubleClicked;
                EventHandler<ItemDoubleClickedEventArgs> comparand;
                do
                {
                    comparand = eventHandler;
                    eventHandler =
                        Interlocked.CompareExchange(ref _itemDoubleClicked,
                            (EventHandler<ItemDoubleClickedEventArgs>)Delegate.Combine(comparand, value), comparand);
                } while (eventHandler != comparand);
            }
            remove
            {
                var eventHandler = _itemDoubleClicked;
                EventHandler<ItemDoubleClickedEventArgs> comparand;
                do
                {
                    comparand = eventHandler;
                    eventHandler = Interlocked.CompareExchange(ref _itemDoubleClicked,
                        (EventHandler<ItemDoubleClickedEventArgs>)Delegate.Remove(comparand, value), comparand);
                }
                while (eventHandler != comparand);
            }
        }

        public event EventHandler<ItemsChangedEventArgs> OnSelectedItemChanged;

        protected virtual void OnRaiseSelectedItemChanged(ItemsChangedEventArgs e)
        {
            var handler = OnSelectedItemChanged;
            handler?.Invoke(this, e);
        }

        private void ResizeColumn()
        {
            var gridView = ListView.View as GridView;
            if (gridView?.Columns == null)
                return;
            gridView.Columns[0].Width = ListView.ActualWidth - 25.0;
        }

        public ModLauncherView()
        {
            InitializeComponent();
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            ResizeColumn();
        }

        private void FrameworkElement_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeColumn();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left || ListView.SelectedItems.Count == 0 || _itemDoubleClicked == null)
                return;
            _itemDoubleClicked(this, new ItemDoubleClickedEventArgs(ListView.SelectedItem));
        }

        private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnRaiseSelectedItemChanged(null);
        }
    }
}
