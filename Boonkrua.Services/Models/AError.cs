using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Models;

public abstract record AError
{
    protected AError(Message errMessage)
    {
        ErrorMessage = errMessage;
    }

    public string ErrorMessage { get; init; }
}
