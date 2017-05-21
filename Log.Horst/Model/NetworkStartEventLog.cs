using Log.Horst.Services.LogDeserializerService;
using Log.Horst.Utils;

namespace Log.Horst.Model
{
    public class NetworkStartEventLog : LogBase
    {
        public string Uid { get; set; }


        public NetworkStartEventLog(LogMetaData metaData, string message) : base(metaData, LogType.NetworkStart, message)
        {
            Uid = ShortUidGenerator.GenerateUid();
        }

        public override string LogMessage => $"[{LogType}][{Uid}] - {Message}";
        public override string LogTitle => $"A network request with id {Uid} was started";
    }
}
