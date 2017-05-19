using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class CollapsibleLogRowViewModel : LogRowViewModelBase
    {
        private ReactiveList<LogRowViewModel> _subRows;
        public ReactiveList<LogRowViewModel> SubRows
        {
            get { return _subRows; }
            set { this.RaiseAndSetIfChanged(ref _subRows, value); }
        }

        private IReactiveDerivedList<LogRowViewModel> _filteredList;

        public IReactiveDerivedList<LogRowViewModel> FilteredList
        {
            get { return _filteredList; }
            set { this.RaiseAndSetIfChanged(ref _filteredList, value); }
        }

        private bool _isCollapsed;
        public bool IsCollapsed
        {
            get { return _isCollapsed; }
            set { this.RaiseAndSetIfChanged(ref _isCollapsed, value); }
        }

        public CollapsibleLogRowViewModel(IObservable<LoggingLevel> level) : base(null)
        {
            SubRows = new ReactiveList<LogRowViewModel>();

            level.Subscribe(logLevel =>
            {
                FilteredList = SubRows.CreateDerivedCollection(x => x, x => x.Log.LoggingLevel >= logLevel);
            });

            IsCollapsed = true;

            // TODO: make more reactivy
            ToggleCollapseCommand = ReactiveCommand.Create(() =>
            {
                IsCollapsed = !IsCollapsed;
            });
        }

        public ReactiveCommand<Unit, Unit> ToggleCollapseCommand { get; set; }


    }
}
