using System.Threading.Tasks;
using SmartLogs.Model;

namespace SmartLogs.Services.LogDeserializerService.MessageParsers
{
    public class AppEventMessageParser : IMessageParser
    {
        public Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog)
        {
            formattedLog = new MessageLog(metaData, message, metaData.Level);
            return Task.FromResult(true);
        }
    }
}