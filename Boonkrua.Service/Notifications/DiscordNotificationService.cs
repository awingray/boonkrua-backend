using System.Net.Http.Json;
using Boonkrua.Common.Messages;
using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Models;
using Boonkrua.Service.Models.Error.Notifications;

namespace Boonkrua.Service.Notifications;

public sealed class DiscordNotificationService(HttpClient client) : INotificationService
{
    private readonly HttpClient _client = client;

    public async Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        var discordPayload = new { content = payload.Message };
        var response = await _client.PostAsJsonAsync(payload.Key, discordPayload);

        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return MessageResponse.Create(NotificationMessages.SendSuccess);
    }
}
