using Boonkrua.Service.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Topics.Models;

public record NotificationError : AError
{
    private NotificationError(Message errorMessage)
        : base(errorMessage) { }

    public static NotificationError InvalidType => new(NotificationMessages.Invalid.Provider);

    public static NotificationError NotFoundUser => new(ConfigMessages.NotFound.User);

    public static NotificationError NotFoundConfig => new(ConfigMessages.NotFound.Config);

    public static NotificationError NotFound => new(TopicMessages.NotFound.Topic);

    public static NotificationError SendFailure => new(NotificationMessages.Send.Failure);
}
