using Boonkrua.Services.Features.Topics.Messages;
using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Topics.Models;

public sealed record TopicError : AError
{
    private TopicError(Message errorMessage)
        : base(errorMessage) { }

    public static TopicError NullId => new(TopicMessages.Null.Id);
    public static TopicError NotFound => new(TopicMessages.NotFound.Topic);
}
