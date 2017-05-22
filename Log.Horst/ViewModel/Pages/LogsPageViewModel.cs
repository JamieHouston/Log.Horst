using System;
using Log.Horst.Model;
using ReactiveUI;
using Splat;

namespace Log.Horst.ViewModel.Pages
{
    public class LogsPageViewModel : ReactiveObject
    {
        public LogsPageViewModel()
        {
            Logs = new ReactiveList<LogBase>();
            var appVm = Locator.Current.GetService<ShellViewModel>();
            RefreshLogs(appVm);
            appVm.Logs.Changed.Subscribe(_ => { RefreshLogs(appVm); });
        }

        private void RefreshLogs(ShellViewModel appVm)
        {
            Logs.Clear();
            var logs = appVm.Logs;
            foreach (var log in logs)
            {
                Logs.Add(log);
            }
        }

        private ReactiveList<LogBase> _logs;
        public ReactiveList<LogBase> Logs
        {
            get => _logs;
            set => this.RaiseAndSetIfChanged(ref _logs, value);
        }
    }
}