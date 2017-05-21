using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using SmartLogs.Model;
using SmartLogs.Services.Navigation;
using Splat;

namespace SmartLogs.ViewModel.Pages
{
    public class ShellViewModel : ReactiveObject
    {
        public ShellViewModel()
        {
            Logs = new ReactiveList<LogBase>();
            LoadLogsCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var logs = await App.DeserializerService.ImportLogsFromFileAsync();
                if (logs != null)
                {
                    Logs.Clear();
                    Logs.AddRange(logs);
                }
                
            });

            NavigateToLogsCommand = ReactiveCommand.CreateFromTask(() => Locator.Current.GetService<INavigationService>().NavigateToLogsAsync());
            NavigateToTimelineCommand = ReactiveCommand.CreateFromTask(() => Locator.Current.GetService<INavigationService>().NavigateToTimelineAsync());
            

            Locator.CurrentMutable.RegisterConstant(this, typeof(ShellViewModel));
        }
        public ReactiveCommand<Unit, Unit> LoadLogsCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NavigateToTimelineCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NavigateToLogsCommand { get; set; }

        private ReactiveList<LogBase> _logs;
        public ReactiveList<LogBase> Logs
        {
            get => _logs;
            set => this.RaiseAndSetIfChanged(ref _logs, value);
        }
    }
}
