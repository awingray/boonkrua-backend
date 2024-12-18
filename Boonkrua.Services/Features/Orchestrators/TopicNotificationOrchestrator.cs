using Boonkrua.Services.Features.Configs.Interfaces;
using Boonkrua.Services.Features.Notifications.Interfaces;
using Boonkrua.Services.Features.Notifications.Models;
using Boonkrua.Services.Features.Orchestrators.Interfaces;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Services.Features.Orchestrators;

public sealed class TopicNotificationOrchestrator(
    ITopicService topicService,
    IConfigService configService,
    INotificationDispatcher dispatcher
) : ITopicNotificationOrchestrator
{
    private readonly ITopicService _topicService = topicService;
    private readonly IConfigService _configService = configService;
    private readonly INotificationDispatcher _dispatcher = dispatcher;

    public async Task<Result<Message, AError>> NotifyAsync(string objectId, string type)
    {
        if (!type.TryParse(out NotificationType notificationType))
            return TopicNotificationError.InvalidType;

        var topic = await _topicService.GetByIdAsync(objectId);
        if (!topic.IsSuccessful)
            return topic.Error!;

        var (userId, title) = (topic.Content!.UserId, topic.Content!.Title);

        var config = await _configService.GetVendorKeyByTypeAsync(userId, notificationType);
        if (!config.IsSuccessful)
            return config.Error!;

        var payload = NotificationPayload.Create(title, config.Content!);
        var result = await _dispatcher.DispatchAsync(notificationType, payload);

        return result.Content!;
    }
}
