using Boonkrua.Common.Messages;
using Boonkrua.Http.Models.Error.Notifications;
using Boonkrua.Http.Models.Response;
using Boonkrua.Http.Services.Notifications.Interfaces;

namespace Boonkrua.Http.Services.Notifications;

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
