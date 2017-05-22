using System;
using System.Linq;
using Log.Horst.Model;
using ReactiveUI;
using Splat;

namespace Log.Horst.ViewModel.Pages
{
    public class TimelinePageViewModel : ReactiveObject
    {
        public TimelinePageViewModel()
        {
            Logs = new ReactiveList<LogRowViewModelBase>();
            Levels = new ReactiveList<LogLevelSelectionViewModel>()
            {
                new LogLevelSelectionViewModel("Verbose", LoggingLevel.Verbose),
                new LogLevelSelectionViewModel("Information", LoggingLevel.Information),
                new LogLevelSelectionViewModel("Warning", LoggingLevel.Warning),
                new LogLevelSelectionViewModel("Error", LoggingLevel.Error),
                new LogLevelSelectionViewModel("Critical", LoggingLevel.Critical)
            };
            SelectedLevel = Levels.FirstOrDefault();

            var appVm = Locator.Current.GetService<ShellViewModel>();
            RefreshLogs(appVm);
            appVm.Logs.Changed.Subscribe(_ => { RefreshLogs(appVm); });


            this.WhenAnyValue(x => x.SelectedLevel).Subscribe(level =>
            {
                FilteredList = Logs.CreateDerivedCollection(x => x,
                    x => x.Log == null || x.Log?.LoggingLevel >= level.LoggingLevel);
            });
        }

        private void RefreshLogs(ShellViewModel appVm)
        {
            Logs.Clear();
            var logs = appVm.Logs;
            CollapsibleLogRowViewModel currentCollapsedSection = null;
            foreach (var log in logs)
            {
                if (log is MessageLog)
                {
                    if (currentCollapsedSection == null)
                    {
                        currentCollapsedSection =
                            new CollapsibleLogRowViewModel(this.WhenAnyValue(x => x.SelectedLevel.LoggingLevel));
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

        public ReactiveCommand Refresh { get; set; }

        private ReactiveList<LogLevelSelectionViewModel> _levels;
        public ReactiveList<LogLevelSelectionViewModel> Levels
        {
            get => _levels;
            set => this.RaiseAndSetIfChanged(ref _levels, value);
        }

        private LogLevelSelectionViewModel _selectedLevel;
        public LogLevelSelectionViewModel SelectedLevel
        {
            get => _selectedLevel;
            set => this.RaiseAndSetIfChanged(ref _selectedLevel, value);
        }

        private IReactiveDerivedList<LogRowViewModelBase> _filteredList;
        public IReactiveDerivedList<LogRowViewModelBase> FilteredList
        {
            get => _filteredList;
            set => this.RaiseAndSetIfChanged(ref _filteredList, value);
        }

        private ReactiveList<LogRowViewModelBase> _logs;
        public ReactiveList<LogRowViewModelBase> Logs
        {
            get => _logs;
            set => this.RaiseAndSetIfChanged(ref _logs, value);
        }
    }
}
