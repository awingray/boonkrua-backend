using Boonkrua.Models.Error;
using Boonkrua.Models.Error.Notifications;
using Boonkrua.Models.Error.Topics;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics;

public interface ITopicNotificationService
{
    Task<Result<MessageResponse, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
