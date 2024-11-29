using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Notifications;

public abstract class ANotificationService
{
    protected static async Task<Result<Message, NotificationError>> HandleOperationAsync(
        Func<Task<HttpResponseMessage>> func
    )
    {
        var response = await func();
        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return Message.Create(NotificationMessages.SendSuccess);
    }
}
