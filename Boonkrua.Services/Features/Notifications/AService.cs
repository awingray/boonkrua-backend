using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Notifications;

public abstract class AService
{
    protected static async Task<Result<Message, NotificationError>> HandleOperationAsync(
        Func<Task<HttpResponseMessage>> func
    )
    {
        var response = await func();
        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return NotificationMessages.Send.Success;
    }
}
