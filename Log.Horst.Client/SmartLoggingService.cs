using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Log.Horst.Model;

namespace Log.Horst.Client
{
    public class SmartLoggingService : ISmartLoggingService
    {
        private readonly List<LogBase> _inMemoryLogs;
        private const int InMemoryLimit = 100;

        public SmartLoggingService()
        {
            _inMemoryLogs = new List<LogBase>();
        }
         
        public Task LogAppEventAsync(ApplicationLifeCycleEvent appEvent, string message = "")
        {
            //return LogEventAsync(new AppEventLog(appEvent, message));
            return Task.CompletedTask;
        }

        public Task LogExceptionAsync(Exception exception, string message = "")
        {
            //return LogEventAsync(new ExceptionLog(exception, message));
            return Task.CompletedTask;

        }

        public Task LogMessageAsync(string message, LoggingLevel level)
        {
            //return LogEventAsync(new MessageLog(message, level));
            return Task.CompletedTask;

        }

        public Task<string> LogNetworkStartEventAsync(string message = "")
        {
            //var networkLog = new NetworkStartEventLog(message);
            //await LogEventAsync(networkLog);
            //return networkLog.Uid;

            return Task.FromResult("");

        }

        public Task LogNetworkStopEventAsync(bool success, string startId, string message = "")
        {
            //return LogEventAsync(new NetworkStopEventLog(message, startId, success));

            return Task.CompletedTask;

        }

        public Task LogUserActionEventAsync(UserActionVerb verb, string actionObject, string message = "")
        {
            //return LogEventAsync(new UserActionEventLog(verb, actionObject, message));

            return Task.CompletedTask;

        }

        public Task LogNavigationEventAsync(string destinationPage, string message = "")
        {
            //return LogEventAsync(new NavigationEventLog(destinationPage, message));

            return Task.CompletedTask;

        }

        public Task LogSystemEventAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task LogPushNotificationReceived(string message = "")
        {
            throw new NotImplementedException();
        }

        public Task<List<LogBase>> GetAllLogs()
        {
            // TODO: right now we just return in memory logs
            return Task.FromResult(_inMemoryLogs);
        }

        public Task<IEnumerable<LogBase>> GetLogsAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task FlushLogsToDiskAsync()
        {
            // TODO

        }

        private Task LogEventAsync(LogBase log)
        {
            _inMemoryLogs.Add(log);

            if (_inMemoryLogs.Count >= InMemoryLimit)
            {
                return FlushLogsToDiskAsync();
            }

            return Task.CompletedTask;
        }
    }
}
