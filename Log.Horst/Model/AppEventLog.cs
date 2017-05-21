using System;
using Log.Horst.Services.LogDeserializerService;

namespace Log.Horst.Model
{
    public class AppEventLog : LogBase
    {
        public ApplicationLifeCycleEvent AppEvent { get; set; }

        public AppEventLog(LogMetaData metaData, ApplicationLifeCycleEvent appEvent, string message) : base(metaData, LogType.AppEvent, message)
        {
            AppEvent = appEvent;
        }

        public override string LogMessage => $"[{LogType}][{AppEvent}] - {Message}";
        public override string LogTitle
        {
            get
            {
                switch (AppEvent)
                {
                    case ApplicationLifeCycleEvent.Other:
                        return "An application event was received";
                    case ApplicationLifeCycleEvent.Created:
                        return "The application was created";
                    case ApplicationLifeCycleEvent.Started:
                        return "The application started";
                    case ApplicationLifeCycleEvent.Resumed:
                        return "The application resumed";
                    case ApplicationLifeCycleEvent.Suspended:
                        return "The application was suspended";
                    case ApplicationLifeCycleEvent.Closed:
                        return "The application was closed";
                    case ApplicationLifeCycleEvent.Crashed:
                        return "The application crashed!";
                    case ApplicationLifeCycleEvent.LowMemory:
                        return "The application received a low memory event";
                    case ApplicationLifeCycleEvent.Obscured:
                        return "The application was obscured";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
