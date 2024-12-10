using Boonkrua.Data.Interfaces;
using Boonkrua.Service.Factories;
using Boonkrua.Service.Interfaces.Topics;
using Boonkrua.Service.Models.Error.Topics;
using Boonkrua.Service.Models.Payload;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Service.Topics;

public sealed class TopicNotificationService(
    ITopicRepository topicRepository,
    INotificationConfigRepository configRepository,
    NotificationServiceFactory serviceFactory
) : ITopicNotificationService
{
    private readonly ITopicRepository _topicRepository = topicRepository;
    private readonly INotificationConfigRepository _configRepository = configRepository;
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

        var vendorConfig = userConfigs.GetVendorByType(notificationType)?.Config;
        if (vendorConfig is null)
            return TopicNotificationError.NotFoundConfig;

        var notificationService = _serviceFactory.GetService(notificationType);
        // TODO: remove thhe place holder
        var payload = NotificationPayload.Create(topic.Title, string.Empty);

        var result = await notificationService.SendNotificationAsync(payload);
        if (!result.IsSuccessful)
            return TopicNotificationError.SendFailure;

        return result.Content!;
    }
}
