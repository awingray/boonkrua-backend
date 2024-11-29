using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Models;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Notifications;

public sealed class LineNotificationService(HttpClient client) : INotificationService
{
    private readonly HttpClient _client = client;

    public Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        throw new NotImplementedException();
    }
}
