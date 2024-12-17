using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Notifications.Interfaces;

public interface INotificationService
{
    Task<Result<Message, NotificationError>> SendNotificationAsync(NotificationPayload payload);
}
