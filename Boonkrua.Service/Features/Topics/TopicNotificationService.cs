using Boonkrua.Data.Features.Notifications.Interfaces;
using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Service.Features.Notifications;
using Boonkrua.Service.Features.Notifications.Factories;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Service.Features.Topics.Interfaces;
using Boonkrua.Service.Features.Topics.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Service.Features.Topics;

public sealed class TopicNotificationService(
    ITopicRepository topicRepository,
    IConfigRepository configRepository,
    NotificationServiceFactory serviceFactory
) : ITopicNotificationService
{
    private readonly ITopicRepository _topicRepository = topicRepository;
    private readonly IConfigRepository _configRepository = configRepository;
    private readonly NotificationServiceFactory _serviceFactory = serviceFactory;

    public async Task<Result<Message, TopicNotificationError>> NotifyAsync(
        string objectId,
        string type
    )
    {
        if (!type.TryParse(out NotificationType notificationType))
            return TopicNotificationError.InvalidType;

        var topic = await _topicRepository.GetByIdAsync(objectId);
        if (topic is null)
            return TopicNotificationError.NotFound;

        var userConfigs = await _configRepository.GetByUserIdAsync(topic.UserId);
        if (userConfigs is null)
            return TopicNotificationError.NotFoundUser;

        var vendorConfig = userConfigs.GetKeyByType(notificationType);
        if (vendorConfig is null)
            return TopicNotificationError.NotFoundConfig;

        var notificationService = _serviceFactory.GetService(notificationType);
        var payload = NotificationPayload.Create(topic.Title, vendorConfig);

        var result = await notificationService.SendNotificationAsync(payload);
        if (!result.IsSuccessful)
            return TopicNotificationError.SendFailure;

        return result.Content!;
    }
}
