using Boonkrua.Constants.Messages;

namespace Boonkrua.Models.Error;

public sealed record TopicError : AError
{
    private TopicError(string errorMessage)
        : base(errorMessage) { }

    public static TopicError NullId => new(TopicMessages.NullId);
    public static TopicError NotFound => new(TopicMessages.NotFound);
}
