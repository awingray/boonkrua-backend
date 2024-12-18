using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Notifications.Models;

public sealed record NotificationError : AError
{
    private NotificationError(Message errorMessage)
        : base(errorMessage) { }

    public static NotificationError SendFailure => new(NotificationMessages.Send.Failure);
}
