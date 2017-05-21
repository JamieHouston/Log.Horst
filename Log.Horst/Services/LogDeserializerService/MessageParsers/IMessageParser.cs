using System.Threading.Tasks;
using Log.Horst.Model;

namespace Log.Horst.Services.LogDeserializerService.MessageParsers
{
    public interface IMessageParser
    {
        Task<bool> TryParseMessage(LogMetaData metaData, string message, out LogBase formattedLog);
    }
}