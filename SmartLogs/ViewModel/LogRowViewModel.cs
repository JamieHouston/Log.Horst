using GalaSoft.MvvmLight;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class LogRowViewModel : LogRowViewModelBase
    {
        private LogBase _log;
        public LogBase Log
        {
            get { return _log; }
            set { Set(ref _log, value); }
        }

        public LogRowViewModel(LogBase log)
        {
            Log = log;
        }
    }
}
