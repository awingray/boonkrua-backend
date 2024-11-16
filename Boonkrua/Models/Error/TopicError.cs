using Boonkrua.Constants;

namespace Boonkrua.Models.Error;

public record TopicError
{
    public string ErrorMessage { get; init; }

    private TopicError(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public static TopicError NullId => new(TopicMessages.NullId);
    public static TopicError NotFound => new(TopicMessages.NotFound);
}
