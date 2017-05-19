using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartLogs.Services.LogDeserializerService;
using SmartLogs.Utils;

namespace SmartLogs.Model
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
