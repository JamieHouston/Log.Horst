namespace Log.Horst.Model
{
    public class NavigationEventLog : LogBase
    {
        public string DestinatinonPage { get; set; }

        public NavigationEventLog(LogMetaData metaData, string destinationPage, string message) : base(metaData, LogType.Navigation, message)
        {
            DestinatinonPage = destinationPage;
        }

        public override string LogMessage => $"[{LogType}][{DestinatinonPage}]";
        public override string LogTitle => $"A navigation to {DestinatinonPage} occured";
    }
}