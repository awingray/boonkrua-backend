using Boonkrua.Constants.Messages;
using Boonkrua.Models.Error;
using Boonkrua.Models.Error.Notifications;
using Boonkrua.Models.Response;
using Boonkrua.Services.Notifications.Interfaces;

namespace Boonkrua.Services.Notifications;

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
