using SmartLogs.Model;

namespace SmartLogs.ViewModel
{
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