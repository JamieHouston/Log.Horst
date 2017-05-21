using System;
using Log.Horst.ViewModel.Pages;
using ReactiveUI;

namespace Log.Horst.View.Pages
{
    public sealed partial class TimelinePage : IViewFor<TimelinePageViewModel>
    {
        public TimelinePage()
        {
            this.InitializeComponent();
            ViewModel = new TimelinePageViewModel();
            DataContext = ViewModel;

            this.WhenActivated(WireUpBindings);
        }

        private void WireUpBindings(Action<IDisposable> d)
        {
            d(this.Bind(ViewModel, vm => vm.FilteredList, v => v.LogsListView.ItemsSource));
            d(this.OneWayBind(ViewModel, vm => vm.Levels, v => v.LevelComboBox.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedLevel, v => v.LevelComboBox.SelectedItem));
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TimelinePageViewModel)value;
        }

        public TimelinePageViewModel ViewModel { get; set; }
    }
}
