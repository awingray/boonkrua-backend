using System.Net.Http.Json;
using Boonkrua.Service.Interfaces;
using Boonkrua.Service.Interfaces.Notifications;
using Boonkrua.Service.Models;
using Boonkrua.Service.Models.Error.Notifications;
using Boonkrua.Service.Models.Payload;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Models;
using Microsoft.Extensions.Options;

namespace Boonkrua.Service.Notifications;

public sealed class LineNotificationService(HttpClient client, IOptions<LineSettings> settings)
    : ANotificationService,
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
