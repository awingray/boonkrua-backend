using Boonkrua.Models.Error;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics;

public interface ITopicNotificationService
{
    Task<Result<MessageResponse, NotificationError>> NotifyAsync(string objectId, string type);
}
