using System.Threading.Tasks;
using Log.Horst.Model;

namespace Log.Horst.Services.LogDeserializerService.MessageParsers
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