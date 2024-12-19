using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Orchestrators.Models;

public record TopicNotificationError : AError
{
    private TopicNotificationError(Message errorMessage)
        : base(errorMessage) { }

    public static TopicNotificationError InvalidType => new(NotificationMessages.Invalid.Provider);
}
