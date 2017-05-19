using System.Threading.Tasks;
using SmartLogs.Model;

namespace SmartLogs.Services.LogDeserializerService
{
    public interface IMessageParser
    {
        Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog);
    }
}