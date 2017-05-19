using System;
using System.Threading.Tasks;
using SmartLogs.Model;

namespace SmartLogs.Services.LogDeserializerService
{
    public class InteractionMessageParser : IMessageParser
    {
        public Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog)
        {
            if (metaData.Group == "Interaction")
            {
                var parts = message.Split(':');
                var page = parts[0];
                var action = parts[1];
                
                formattedLog = new UserActionEventLog(metaData, UserActionVerb.Tapped, page, action, message);
                return Task.FromResult(true);
            }

            formattedLog = null;
            return Task.FromResult(false);
        }
    }
}