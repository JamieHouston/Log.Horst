using System.Threading.Tasks;
using SmartLogs.Model;

namespace SmartLogs.Services.LogDeserializerService.MessageParsers
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

    public class AppLifeCycleMessageParser : IMessageParser
    {
        public Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog)
        {
            if (metaData.Group == "AppLifecycle")
            {
                var parts = message.Split('-');

                if (parts.Length == 2)
                {
                    var appLifeCycleEvent = parts[0].Trim();
                    var lifeCycleMessage = parts[1].Trim();

                    ApplicationLifeCycleEvent eventType;
                    switch (appLifeCycleEvent)
                    {
                        case "OnLeavingBackground":
                            eventType = ApplicationLifeCycleEvent.Resumed;
                            break;
                        case "OnEnteredBackground":
                            eventType = ApplicationLifeCycleEvent.Obscured;
                            break;
                        default:
                            eventType = ApplicationLifeCycleEvent.Other;
                            break;

                    }

                    formattedLog = new AppEventLog(metaData, eventType, message);
                    return Task.FromResult(true);
                }
                else
                {
                    // bad formated app lifcycle event
                    //Debugger.Break();
                }
            }

            formattedLog = null;
            return Task.FromResult(false);
        }
    }
}