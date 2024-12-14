using Boonkrua.Service.Features.Topics.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Topics.Interfaces;

public interface INotificationService
{
    Task<Result<Message, NotificationError>> NotifyAsync(string objectId, string type);
}
