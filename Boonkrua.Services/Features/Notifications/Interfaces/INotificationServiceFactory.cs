using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Interfaces;

public interface INotificationServiceFactory
{
    INotificationService GetService(NotificationType type);
}
