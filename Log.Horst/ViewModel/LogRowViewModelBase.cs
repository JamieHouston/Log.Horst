using Log.Horst.Model;
using ReactiveUI;

namespace Log.Horst.ViewModel
{
    public abstract class LogRowViewModelBase : ReactiveObject
    {
        protected LogRowViewModelBase(LogBase log)
        {
            Log = log;
        }
        private LogBase _log;
        public LogBase Log
        {
            get { return _log; }
            set { this.RaiseAndSetIfChanged(ref _log, value); }
        }
    }
}
