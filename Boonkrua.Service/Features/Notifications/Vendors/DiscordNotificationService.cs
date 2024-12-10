using System.Net.Http.Json;
using Boonkrua.Service.Features.Notifications.Interfaces;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Features.Notifications.Vendors;

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
