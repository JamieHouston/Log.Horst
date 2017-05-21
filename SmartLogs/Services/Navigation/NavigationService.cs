using System.Threading.Tasks;

namespace SmartLogs.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToTimelineAsync();
        Task NavigateToLogsAsync();
    }
}
