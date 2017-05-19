using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private ReactiveList<LogLevelSelectionViewModel> _levels;

        public ReactiveList<LogLevelSelectionViewModel> Levels
        {
            get { return _levels; }
            set { this.RaiseAndSetIfChanged(ref _levels, value); }
        }

        private LogLevelSelectionViewModel _selectedLevel;
        public LogLevelSelectionViewModel SelectedLevel
        {
            get { return _selectedLevel; }
            set { this.RaiseAndSetIfChanged(ref _selectedLevel, value); }
        }

        private IReactiveDerivedList<LogRowViewModelBase> _filteredList;

        public IReactiveDerivedList<LogRowViewModelBase> FilteredList
        {
            get { return _filteredList; }
            set { this.RaiseAndSetIfChanged(ref _filteredList, value); }
        }

        public async Task RefreshAsync()
        {
            Levels = new ReactiveList<LogLevelSelectionViewModel>()
        {
            new LogLevelSelectionViewModel("Verbose", LoggingLevel.Verbose),
            new LogLevelSelectionViewModel("Information", LoggingLevel.Information),
            new LogLevelSelectionViewModel("Warning", LoggingLevel.Warning),
            new LogLevelSelectionViewModel("Error", LoggingLevel.Error),
            new LogLevelSelectionViewModel("Critical", LoggingLevel.Critical)
        };
            SelectedLevel = Levels.FirstOrDefault();

            var logs = await App.DeserializerService.ImportLogsFromFileAsync();
            //var logs = await App.LoggingService.GetAllLogs();


            Logs = new ReactiveList<LogRowViewModelBase>();
            

            this.WhenAnyValue(x => x.SelectedLevel).Subscribe(level =>
            {
                FilteredList = Logs.CreateDerivedCollection(x => x,
                x => x.Log == null || x.Log?.LoggingLevel >= level.LoggingLevel);
            });

            CollapsibleLogRowViewModel currentCollapsedSection = null;
            foreach (var log in logs)
            {
                if (log is MessageLog)
                {
                    if (currentCollapsedSection == null)
                    {
                        currentCollapsedSection = new CollapsibleLogRowViewModel(this.WhenAnyValue(x => x.SelectedLevel.LoggingLevel));
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

    public class LogLevelSelectionViewModel
    {
        public string Label { get; set; }
        public LoggingLevel LoggingLevel { get; set; }
        public LogLevelSelectionViewModel(string label, LoggingLevel level)
        {
            Label = label;
            LoggingLevel = level;
        }
    }
}
