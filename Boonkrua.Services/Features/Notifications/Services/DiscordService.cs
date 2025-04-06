using System.Net.Http.Json;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;

namespace Boonkrua.Services.Features.Notifications.Services;

public sealed class DiscordService(HttpClient client) : INotificationService
{
    private readonly HttpClient _client = client;

    public NotificationType Type => NotificationType.Discord;

    public async Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        var response = await _client.PostAsJsonAsync(payload.Key, payload.ToDiscordPayload());

        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return NotificationMessages.Send.Success;
    }
}
