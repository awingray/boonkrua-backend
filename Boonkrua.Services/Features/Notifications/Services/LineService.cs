using System.Net.Http.Json;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Messages;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Models;
using Microsoft.Extensions.Options;

namespace Boonkrua.Services.Features.Notifications.Services;

public sealed class LineService(HttpClient client, IOptions<LineSettings> settings)
    : INotificationService
{
    private readonly HttpClient _client = client;
    private readonly LineSettings _settings = settings.Value;

    public NotificationType Type => NotificationType.Line;

    public async Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        var response = await _client.PostAsJsonAsync(
            _settings.PushMessageApi,
            payload.ToLinePayload()
        );

        if (!response.IsSuccessStatusCode)
            return NotificationError.SendFailure;

        return NotificationMessages.Send.Success;
    }
}
