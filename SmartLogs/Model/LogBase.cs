using System;
using SmartLogs.Services.LogDeserializerService;

namespace SmartLogs.Model
{
    public abstract class LogBase
    {
        protected LogBase(LogMetaData metaData, LogType type, string message)
        {
            Message = message;
            LogType = type;
            LogTimeStamp = DateTime.Now;
            LogLocation = $"{metaData.FileName} - {metaData.MethodName} - {metaData.LineNumber}";
        }

        public DateTime LogTimeStamp { get; set; }

        public string FormattedTimeStamp => LogTimeStamp.ToString("MM/dd/yyyy hh:mm:ss.fff");

        public string Message { get; set; }
        public string LogLocation { get; set; }

        public LogType LogType { get; set; }

        public abstract string LogMessage { get; }

        public abstract string LogTitle { get; }
    }
}
