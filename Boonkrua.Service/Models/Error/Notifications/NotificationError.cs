using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Models.Error.Notifications;

public sealed record NotificationError : AError
{
    private NotificationError(string errorMessage)
        : base(errorMessage) { }

    public static NotificationError SendFailure => new(NotificationMessages.SendFailure);
}
