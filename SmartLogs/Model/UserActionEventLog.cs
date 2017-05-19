using SmartLogs.LoggerService;
using SmartLogs.Services.LogDeserializerService;

namespace SmartLogs.Model
{
    public class UserActionEventLog : LogBase
    {
        public UserActionVerb UserAction { get; set; }
        public string TagetObject { get; set; } 

        public UserActionEventLog(LogMetaData metaData, UserActionVerb userAction, string targetObject, string message) : base(metaData, LogType.UserAction, message)
        {
            UserAction = userAction;
            TagetObject = targetObject;
        }

        public override string LogMessage =>$"[{LogType}][{UserAction}][{TagetObject}] - {Message}";
        public override string LogTitle => $"The user {UserAction} on {TagetObject}";
    }
}
