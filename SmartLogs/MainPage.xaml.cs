using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SmartLogs.Model;
using SmartLogs.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SmartLogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = new MainPageViewModel();
            DataContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await _viewModel.RefreshAsync();

        }

        private async void Simulate_OnClick(object sender, RoutedEventArgs e)
        {
            await App.LoggingService.LogUserActionEventAsync(UserActionVerb.Tapped, "TapButton");
            await App.LoggingService.LogExceptionAsync(new Exception("something bad happened!"));

            await App.LoggingService.FlushLogsToDiskAsync();

            await _viewModel.RefreshAsync();
        }

        private async void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            await _viewModel.RefreshAsync();
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

            await _viewModel.RefreshAsync();
        }
    }
}
