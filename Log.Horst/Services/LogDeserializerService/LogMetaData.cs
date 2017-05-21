using System;
using Log.Horst.Model;

namespace Log.Horst.Services.LogDeserializerService
{
    public class LogMetaData
    {
        public LoggingLevel Level { get; set; }
        public DateTime DateTime { get; set; }
        public int ThreadId { get; set; }
        public string FileName { get; set; }
        public string MethodName { get; set; }
        public int LineNumber { get; set; }
        public string Group { get; set; }
    }
}