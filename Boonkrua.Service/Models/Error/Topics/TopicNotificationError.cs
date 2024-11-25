using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Models.Error.Topics;

public record TopicNotificationError : AError
{
    private TopicNotificationError(string errorMessage)
        : base(errorMessage) { }

    public static TopicNotificationError InvalidType => new(NotificationMessages.InvalidProvider);

    public static TopicNotificationError NotFound => new(TopicMessages.NotFound);

    public static TopicNotificationError SendFailure => new(NotificationMessages.SendFailure);
}
