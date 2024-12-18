using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Services.Features.Topics.Models;

public record TopicNotificationError : AError
{
    private TopicNotificationError(Message errorMessage)
        : base(errorMessage) { }

    public static TopicNotificationError InvalidType => new(NotificationMessages.Invalid.Provider);
}
