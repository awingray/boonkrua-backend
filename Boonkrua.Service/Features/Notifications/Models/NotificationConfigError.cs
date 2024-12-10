using Boonkrua.Service.Models;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications.Models;

public sealed record NotificationConfigError : AError
{
    private NotificationConfigError(string errorMessage)
        : base(errorMessage) { }

    public static NotificationConfigError NotFound =>
        new(NotificationConfigMessages.NotFound.Config);

    public static NotificationConfigError Duplicate =>
        new(NotificationConfigMessages.AlreadyExists.Config);
}
