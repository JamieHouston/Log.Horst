using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<LogRowViewModelBase> _logs;
        public ObservableCollection<LogRowViewModelBase> Logs
        {
            get { return _logs; }
            set { Set(ref _logs, value); }
        }

        public async Task RefreshAsync()
        {
            var logs = await App.DeserializerService.ImportLogsFromFileAsync();
            //var logs = await App.LoggingService.GetAllLogs();


            Logs = new ObservableCollection<LogRowViewModelBase>();

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
