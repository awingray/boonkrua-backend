using System.Net.Http.Json;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Notifications.Services;

public sealed class DiscordService(HttpClient client) : AService, INotificationService
{
    private readonly HttpClient _client = client;

    public async Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    ) =>
        await HandleOperationAsync(
            () => _client.PostAsJsonAsync(payload.Key, payload.ToDiscordPayload())
        );
}
