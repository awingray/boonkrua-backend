using System.Threading.Tasks;
using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Models.Error.Topics;

namespace Boonkrua.Service.Interfaces;

public interface ITopicNotificationService
{
    Task<Result<MessageResponse, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
