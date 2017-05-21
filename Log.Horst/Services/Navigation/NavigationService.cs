using System.Threading.Tasks;

namespace Log.Horst.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToTimelineAsync();
        Task NavigateToLogsAsync();
    }
}
