using Boonkrua.Service.Models;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Topics.Models;

public record TopicNotificationError : AError
{
    private TopicNotificationError(string errorMessage)
        : base(errorMessage) { }

    public static TopicNotificationError InvalidType => new(NotificationMessages.Invalid.Provider);

    public static TopicNotificationError NotFoundUser =>
        new(NotificationConfigMessages.NotFound.User);

    public static TopicNotificationError NotFoundConfig =>
        new(NotificationConfigMessages.NotFound.Config);

    public static TopicNotificationError NotFound => new(TopicMessages.NotFound.Topic);

    public static TopicNotificationError SendFailure => new(NotificationMessages.Send.Failure);
}
