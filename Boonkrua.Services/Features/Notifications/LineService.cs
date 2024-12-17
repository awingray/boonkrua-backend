using System.Net.Http.Json;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Models;
using Microsoft.Extensions.Options;

namespace Boonkrua.Services.Features.Notifications;

public sealed class LineService(HttpClient client, IOptions<LineSettings> settings)
    : AService,
        INotificationService
{
    private readonly HttpClient _client = client;
    private readonly LineSettings _settings = settings.Value;

    public async Task<Result<Message, NotificationError>> SendNotificationAsync(
        NotificationPayload payload
    )
    {
        var linePayload = new
        {
            to = payload.Key,
            messages = new[] { new { type = "text", text = payload.Message } },
        };

        return await HandleOperationAsync(
            () => _client.PostAsJsonAsync(_settings.PushMessageApi, linePayload)
        );
    }
}
