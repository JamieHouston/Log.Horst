namespace Log.Horst.Model
{
    public class UserActionEventLog : LogBase
    {
        public UserActionVerb UserAction { get; set; }

        public UserActionEventLog(LogMetaData metaData, UserActionVerb userAction, string page, string element, string message) : base(metaData, LogType.UserAction, message)
        {
            UserAction = userAction;
            LogTitle = LogMessage = $"User tapped on {element} in {page}";
        }

        public override string LogMessage { get; }
        public override string LogTitle { get; }
    }
}
