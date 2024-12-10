using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Models.Error.Topics;

public record TopicNotificationError : AError
{
    private TopicNotificationError(string errorMessage)
        : base(errorMessage) { }

    public static TopicNotificationError InvalidType => new(NotificationMessages.Invalid.Provider);

    public static TopicNotificationError NotFoundUser =>
        new(NotificationConfigMessages.NotFoundUser);

    public static TopicNotificationError NotFoundConfig => new(NotificationConfigMessages.NotFound);

    public static TopicNotificationError NotFound => new(TopicMessages.NotFound);

    public static TopicNotificationError SendFailure => new(NotificationMessages.Send.Failure);
}
