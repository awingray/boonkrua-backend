using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Models.Error.Topics;

namespace Boonkrua.Service.Interfaces;

public interface ITopicNotificationService
{
    Task<Result<Message, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
