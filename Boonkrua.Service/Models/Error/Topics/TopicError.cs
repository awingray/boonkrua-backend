using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Models.Error.Topics;

public sealed record TopicError : AError
{
    private TopicError(string errorMessage)
        : base(errorMessage) { }

    public static TopicError NullId => new(TopicMessages.Null.Id);
    public static TopicError NotFound => new(TopicMessages.NotFound.Topic);
}
