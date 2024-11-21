using Boonkrua.Common.Messages;

namespace Boonkrua.Models.Error.Topics;

public sealed record TopicError : AError
{
    private TopicError(string errorMessage)
        : base(errorMessage) { }

    public static TopicError NullId => new(TopicMessages.NullId);
    public static TopicError NotFound => new(TopicMessages.NotFound);
}
