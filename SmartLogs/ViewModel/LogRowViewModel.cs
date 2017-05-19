using ReactiveUI;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class LogRowViewModel : LogRowViewModelBase
    {
        private LogBase _log;
        public LogBase Log
        {
            get { return _log; }
            set { this.RaiseAndSetIfChanged(ref _log, value); }
        }

        public LogRowViewModel(LogBase log)
        {
            Log = log;
        }
    }
}
