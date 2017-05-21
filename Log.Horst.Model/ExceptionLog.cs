using System;

namespace Log.Horst.Model
{
    public class ExceptionLog : LogBase
    {
        public string ExceptionMessage { set; get; }

        public ExceptionLog(LogMetaData metaData, Exception ex, string message) : base(metaData, LogType.Exception, message)
        {
            ExceptionMessage = ex.Message;
        }

        public override string LogMessage => $"[{LogType}][{ExceptionMessage}] - {Message}";
        public override string LogTitle => $"An exception was raised: {ExceptionMessage}";
    }
}
