using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using ReactiveUI;
using SmartLogs.Model;
using SmartLogs.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartLogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : IViewFor<MainPageViewModel>
    {
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainPageViewModel();
            DataContext = ViewModel;

            this.WhenActivated(WireUpBindings);
        }

        private void WireUpBindings(Action<IDisposable> d)
        {
            d(this.Bind(ViewModel, vm => vm.FilteredList, v => v.LogsListView.ItemsSource));
            d(this.OneWayBind(ViewModel, vm => vm.Levels, v => v.LevelComboBox.ItemsSource));
            d(this.Bind(ViewModel, vm => vm.SelectedLevel, v => v.LevelComboBox.SelectedItem));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await ViewModel.RefreshAsync();

        }

        private async void Simulate_OnClick(object sender, RoutedEventArgs e)
        {
            await App.LoggingService.LogUserActionEventAsync(UserActionVerb.Tapped, "TapButton");
            await App.LoggingService.LogExceptionAsync(new Exception("something bad happened!"));

            await App.LoggingService.FlushLogsToDiskAsync();

            await ViewModel.RefreshAsync();
        }

        private async void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            await ViewModel.RefreshAsync();
        }

        private async void Network_Clicked(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () =>
            {
                var id = await App.LoggingService.LogNetworkStartEventAsync("http://www.google.com");

                var values = Enum.GetValues(typeof(LoggingLevel));
                var random = new Random();


                for (var i = 0; i < random.Next(1, 25); i++)
                {
                    var level = (LoggingLevel)values.GetValue(random.Next(values.Length));
                    await App.LoggingService.LogMessageAsync("Test message " + i, level);
                }

                await App.LoggingService.LogNetworkStopEventAsync(true, id, "http://www.google.com");

            });

            await ViewModel.RefreshAsync();
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainPageViewModel)value; }
        }

        public MainPageViewModel ViewModel { get; set; }
    }
}
