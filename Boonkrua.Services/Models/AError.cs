using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Models;

public abstract record AError(Message ErrMessage)
{
    public string ErrorMessage => ErrMessage;
}
