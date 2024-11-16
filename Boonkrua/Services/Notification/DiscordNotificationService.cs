using Boonkrua.Constants;
using Boonkrua.Models.Error;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Notification;

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
