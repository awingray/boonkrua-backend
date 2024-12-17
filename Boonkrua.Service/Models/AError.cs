using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Models;

public abstract record AError(Message ErrMessage)
{
    public string ErrorMessage => ErrMessage;
}
