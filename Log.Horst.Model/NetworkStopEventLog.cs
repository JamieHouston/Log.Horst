namespace Log.Horst.Model
{
    public class NetworkStopEventLog : LogBase
    {
        public string Uid { get; set; }
        public bool Success { get; set; }

        public NetworkStopEventLog(LogMetaData metaData,string message, string uid, bool success) : base(metaData, LogType.NetworkStop, message)
        {
            Uid = uid;
            Success = success;
        }

        public override string LogMessage => $"[{LogType}][{Uid}] - {Message}";
        public override string LogTitle => Success ? $"A network request with id {Uid} succeeded" : $"A network request with id {Uid} failed";
    }
}
