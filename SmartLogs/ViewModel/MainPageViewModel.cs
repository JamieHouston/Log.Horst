using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class MainPageViewModel : ReactiveObject
    {
        private ReactiveList<LogRowViewModelBase> _logs;
        public ReactiveList<LogRowViewModelBase> Logs
        {
            get { return _logs; }
            set { this.RaiseAndSetIfChanged(ref _logs, value); }
        }

        private ReactiveList<LoggingLevel> _levels;

        public ReactiveList<LoggingLevel> Levels
        {
            get { return _levels; }
            set { this.RaiseAndSetIfChanged(ref _levels, value); }
        }

        private LoggingLevel _selectedLevel;
        public LoggingLevel SelectedLevel
        {
            get { return _selectedLevel; }
            set { this.RaiseAndSetIfChanged(ref _selectedLevel, value); }
        }

        public IReactiveDerivedList<LogRowViewModel> FilteredList { get; set; }

        public async Task RefreshAsync()
        {
            SelectedLevel = LoggingLevel.Information;

            var logs = await App.DeserializerService.ImportLogsFromFileAsync();
            //var logs = await App.LoggingService.GetAllLogs();


            Logs = new ReactiveList<LogRowViewModelBase>();

            CollapsibleLogRowViewModel currentCollapsedSection = null;
            foreach (var log in logs)
            {
                if (log is MessageLog)
                {
                    if (currentCollapsedSection == null)
                    {
                        currentCollapsedSection = new CollapsibleLogRowViewModel();
                        Logs.Add(currentCollapsedSection);
                    }

                    currentCollapsedSection.SubRows.Add(new LogRowViewModel(log));
                }
                else
                {
                    currentCollapsedSection = null;
                    Logs.Add(new LogRowViewModel(log));
                }
            }
        }
    }
}
