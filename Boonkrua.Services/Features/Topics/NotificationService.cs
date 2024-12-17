using Boonkrua.Data.Features.Configs.Interfaces;
using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Notifications.Factories;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using INotificationService = Boonkrua.Services.Features.Topics.Interfaces.INotificationService;

namespace Boonkrua.Services.Features.Topics;

using NotificationError = Models.NotificationError;

public sealed class NotificationService(
    ITopicService topicService,
    IConfigService configService,
    INotificationDispatcher dispatcher
) : INotificationService
{
    private readonly ITopicService _topicService = topicService;
    private readonly IConfigService _configService = configService;
    private readonly INotificationDispatcher _dispatcher = dispatcher;

    public async Task<Result<Message, NotificationError>> NotifyAsync(string objectId, string type)
    {
        if (!type.TryParse(out NotificationType notificationType))
            return NotificationError.InvalidType;

        var topic = await _topicService.GetByIdAsync(objectId);
        if (!topic.IsSuccessful)
            return NotificationError.NotFound;

        var (userId, title) = (topic.Content!.UserId, topic.Content!.Title);

        var config = await _configService.GetVendorKeyByTypeAsync(userId, notificationType);
        if (!config.IsSuccessful)
            return NotificationError.NotFoundConfig;

        var payload = NotificationPayload.Create(title, config.Content!);
        var result = await _dispatcher.DispatchAsync(notificationType, payload);

        return result.Content!;
    }
}
