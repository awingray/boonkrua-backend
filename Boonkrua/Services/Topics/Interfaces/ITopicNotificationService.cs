using Boonkrua.Models.Error.Topics;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics.Interfaces;

public interface ITopicNotificationService
{
    Task<Result<MessageResponse, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
