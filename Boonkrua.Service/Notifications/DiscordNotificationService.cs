using System.Net.Http.Json;
using Boonkrua.Common.Messages;
using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Models.Error.Notifications;

namespace Boonkrua.Service.Notifications;

public sealed class DiscordNotificationService(HttpClient client) : INotificationService
{
    private readonly HttpClient _client = client;

    public async Task<Result<MessageResponse, NotificationError>> SendNotificationAsync(
        string message
    )
    {
        var payload = new { content = message };
        var response = await _client.PostAsJsonAsync(string.Empty, payload);

        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return MessageResponse.Create(NotificationMessages.SendSuccess);
    }
}
