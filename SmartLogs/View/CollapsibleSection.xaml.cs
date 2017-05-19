using System;
using ReactiveUI;
using SmartLogs.ViewModel;

namespace SmartLogs.View
{
    public sealed partial class CollapsibleSection : IViewFor<CollapsibleLogRowViewModel>
    {
        public CollapsibleSection()
        {
            InitializeComponent();
            DataContextChanged += CollapsibleSection_DataContextChanged;

            this.WhenActivated(WireupBindings);
        }

        private void WireupBindings(Action<IDisposable> d)
        {
            d(this.BindCommand(ViewModel, vm => vm.ToggleCollapseCommand, v => v.CollapseGrid));
            d(this.BindCommand(ViewModel, vm => vm.ToggleCollapseCommand, v => v.CollapsedGrid));
        }

        private void CollapsibleSection_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
            ViewModel = (DataContext as CollapsibleLogRowViewModel);
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (CollapsibleLogRowViewModel)value; }
        }

        public CollapsibleLogRowViewModel ViewModel { get; set; }
    }
}
