using Boonkrua.Http.Models.Error.Topics;
using Boonkrua.Http.Models.Response;

namespace Boonkrua.Http.Services.Topics.Interfaces;

public interface ITopicNotificationService
{
    Task<Result<MessageResponse, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
