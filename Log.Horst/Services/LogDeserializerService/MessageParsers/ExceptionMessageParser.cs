using System;
using System.Threading.Tasks;
using Log.Horst.Model;

namespace Log.Horst.Services.LogDeserializerService.MessageParsers
{
    public class ExceptionMessageParser : IMessageParser
    {
        public Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog)
        {
            if (message.StartsWith("Exception LogMessage"))
            {
                formattedLog = new ExceptionLog(metaData, new Exception(message), message);
                return Task.FromResult(true);
            }

            formattedLog = null;
            return Task.FromResult(false);
        }
    }
}