using Boonkrua.Service.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications.Models;

public sealed record NotificationError : AError
{
    private NotificationError(Message errorMessage)
        : base(errorMessage) { }

    public static NotificationError SendFailure => new(NotificationMessages.Send.Failure);
}
