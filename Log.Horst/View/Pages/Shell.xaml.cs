using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Log.Horst.Services.Navigation;
using Log.Horst.ViewModel.Pages;
using ReactiveUI;
using Splat;

namespace Log.Horst.View.Pages
{
    public sealed partial class Shell : IViewFor<ShellViewModel>, INavigationService
    {
        public Shell()
        {
            this.InitializeComponent();
            ViewModel = new ShellViewModel();
            DataContext = ViewModel;

            this.WhenActivated(WireUpBindings);
            Locator.CurrentMutable.Register<INavigationService>(() => this);
        }

        private void WireUpBindings(Action<IDisposable> d)
        {
            d(this.BindCommand(ViewModel, vm => vm.NavigateToTimelineCommand, v => v.TimelineLeftNavButton));
            d(this.BindCommand(ViewModel, vm => vm.NavigateToLogsCommand, v => v.LogsLeftNavButton));
            d(this.BindCommand(ViewModel, vm => vm.LoadLogsCommand, v => v.LoadLogs));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            try
            {
                await NavigateToTimelineAsync();
            }
            catch (Exception)
            {
                // TODO: handle refresh failures
            }

        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShellViewModel)value;
        }

        public ShellViewModel ViewModel { get; set; }

        public Task NavigateToTimelineAsync()
        {
            AppSplitViewFrame.Navigate(typeof(TimelinePage));
            return Task.CompletedTask;
        }

        public Task NavigateToLogsAsync()
        {
            AppSplitViewFrame.Navigate(typeof(LogsPage));
            return Task.CompletedTask;
        }

        private void OnMenuButtonClicked(object sender, RoutedEventArgs e)
        {
            ShellSplitView.IsPaneOpen = !ShellSplitView.IsPaneOpen;
        }
    }
}
