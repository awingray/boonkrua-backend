using System.Net.Http.Json;
using Boonkrua.Service.Interfaces.Notifications;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Service.Models.Payload;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Notifications;

public sealed class DiscordNotificationService(HttpClient client)
    : ANotificationService,
        INotificationService
{
    private readonly HttpClient _client = client;

    public async Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        var discordPayload = new { content = payload.Message };
        return await HandleOperationAsync(
            () => _client.PostAsJsonAsync(payload.Key, discordPayload)
        );
    }
}
