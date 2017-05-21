using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Log.Horst.Model;

namespace Log.Horst.Services.LoggerService
{
    public interface ISmartLoggingService
    {
        /// <summary>
        /// Logs an app lifecycle event (i.e. app started, suspended, etc)
        /// </summary>
        /// <param name="appEvent">The application lifecycle event</param>
        /// <param name="message">(optional) message</param>
        /// <returns></returns>
        Task LogAppEventAsync(ApplicationLifeCycleEvent appEvent, string message = "");

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogExceptionAsync(Exception exception, string message = "");

        /// <summary>
        /// Logs a general message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogMessageAsync(string message, LoggingLevel level);

        /// <summary>
        /// Logs a network start event. This method returns a unique id
        /// which must be passed in when the network stopped event
        /// </summary>
        /// <param name="message">(optional) message</param>
        /// <returns></returns>
        Task<string> LogNetworkStartEventAsync(string message = "");

        /// <summary>
        /// Logs a network end event. 
        /// </summary>
        /// <param name="success">Indicates the network call succeeded</param>
        /// <param name="startId">The unique id given when the network event was started</param>
        /// <param name="message">(optional) message to be logged with the event</param>
        /// <returns></returns>
        Task LogNetworkStopEventAsync(bool success, string startId, string message = "");

        /// <summary>
        /// Logs a user action with a verb and action object
        /// 
        /// For example: User "Tapped" "Profile Image" where "Tapped" is the verb and "Profile Image" is the actionObject
        /// </summary>
        /// <param name="verb">The event verb</param>
        /// <param name="actionObject">The objet that the event has taken place on</param>
        /// <param name="message">(optional) message</param>
        /// <returns></returns>
        Task LogUserActionEventAsync(UserActionVerb verb, string actionObject, string message = "");

        /// <summary>
        /// Logs an app navigation event
        /// </summary>
        /// <param name="destinationPage"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogNavigationEventAsync(string destinationPage, string message = "");

        /// <summary>
        /// Logs an event received from the system
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogSystemEventAsync(string message);

        /// <summary>
        /// Logs a push notification was received
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task LogPushNotificationReceived(string message = "");

        /// <summary>
        /// Method returns all stored logs. 
        /// </summary>
        /// <returns></returns>
        Task<List<LogBase>> GetAllLogs();

        /// <summary>
        /// Method returns logs by paging
        /// </summary>
        /// <param name="page">The page requested</param>
        /// <param name="pageSize">The page size</param>
        /// <returns></returns>
        Task<IEnumerable<LogBase>> GetLogsAsync(int page, int pageSize);

        /// <summary>
        /// Flushes in memory logs to disk.
        /// 
        /// IMPORTANT NOTE: Logs get automatically flushed to disk at runtime
        /// when an in-memory limit is reached
        /// 
        /// This only needs to be called on app life cycle events such as suspend
        /// or unhandled exception to flush any remaininig logs
        /// </summary>
        /// <returns></returns>
        Task FlushLogsToDiskAsync();
    }
}
