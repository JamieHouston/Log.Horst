using SmartLogs.Services.LogDeserializerService;

namespace SmartLogs.Model
{
    public class MessageLog : LogBase
    {
        public MessageLog(LogMetaData metaData, string message, LoggingLevel level) : base(metaData, LogType.Message, message)
        {
            LogLevel = level;
        }

        public LoggingLevel LogLevel { get; set; }
        public override string LogMessage => $"[{LogType}] - {Message}";
        public override string LogTitle => Message;
    }

    public enum LoggingLevel
    {
        Verbose,
        Information,
        Warning,
        Error,
        Critical
    }
}
