using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;

namespace SmartLogs.ViewModel
{
    public class CollapsibleLogRowViewModel : LogRowViewModelBase
    {
        private ObservableCollection<LogRowViewModel> _subRows;
        public ObservableCollection<LogRowViewModel> SubRows
        {
            get { return _subRows; }
            set { this.RaiseAndSetIfChanged(ref _subRows, value); }
        }

        private bool _isCollapsed;
        public bool IsCollapsed
        {
            get { return _isCollapsed; }
            set { this.RaiseAndSetIfChanged(ref _isCollapsed, value); }
        }

        public CollapsibleLogRowViewModel()
        {
            SubRows = new ObservableCollection<LogRowViewModel>();
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
