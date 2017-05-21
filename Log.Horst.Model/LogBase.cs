using System;

namespace Log.Horst.Model
{
    public abstract class LogBase
    {
        protected LogBase(LogMetaData metaData, LogType type, string message)
        {
            // TODO: whats the point of having three different ones?
            LogTitle = LogMessage = Message = message;
            LogType = type;
            LogTimeStamp = metaData.DateTime;
            LogLocation = $"{metaData.FileName} - {metaData.MethodName} - {metaData.LineNumber}";
            LoggingLevel = metaData.Level;
        }

        public DateTime LogTimeStamp { get; set; }

        public string FormattedTimeStamp => LogTimeStamp.ToString("MM/dd/yyyy hh:mm:ss.fff");

        public string Message { get; set; }
        public string LogLocation { get; set; }

        public LogType LogType { get; set; }

        public virtual string LogMessage { get; }

        public virtual string LogTitle { get; }
        public LoggingLevel LoggingLevel { get; set; }
    }
}
