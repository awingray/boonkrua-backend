using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications.Vendors;

public abstract class AService
{
    protected static async Task<Result<Message, NotificationError>> HandleOperationAsync(
        Func<Task<HttpResponseMessage>> func
    )
    {
        var response = await func();
        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return Message.Create(NotificationMessages.Send.Success);
    }
}
