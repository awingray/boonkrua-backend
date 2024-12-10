using Boonkrua.Service.Features.Topics.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Topics.Interfaces;

public interface ITopicNotificationService
{
    Task<Result<Message, TopicNotificationError>> NotifyAsync(string objectId, string type);
}
