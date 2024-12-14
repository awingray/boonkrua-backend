using Boonkrua.Data.Features.Notifications.Interfaces;
using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Service.Features.Notifications.Factories;
using Boonkrua.Service.Features.Notifications.Models;
using Boonkrua.Service.Features.Topics.Interfaces;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Enums;
using Boonkrua.Shared.Extensions;
using NotificationError = Boonkrua.Service.Features.Topics.Models.NotificationError;

namespace Boonkrua.Service.Features.Topics;

public sealed class NotificationService(
    IRepository topicRepository,
    IConfigRepository configRepository,
    NotificationServiceFactory serviceFactory
) : INotificationService
{
    private readonly IRepository _topicRepository = topicRepository;
    private readonly IConfigRepository _configRepository = configRepository;
    private readonly NotificationServiceFactory _serviceFactory = serviceFactory;

    public async Task<Result<Message, NotificationError>> NotifyAsync(string objectId, string type)
    {
        if (!type.TryParse(out NotificationType notificationType))
            return NotificationError.InvalidType;

        var topic = await _topicRepository.GetByIdAsync(objectId);
        if (topic is null)
            return NotificationError.NotFound;

        var userConfigs = await _configRepository.GetByUserIdAsync(topic.UserId);
        if (userConfigs is null)
            return NotificationError.NotFoundUser;

        var vendorConfig = userConfigs.GetKeyByType(notificationType);
        if (vendorConfig is null)
            return NotificationError.NotFoundConfig;

        var notificationService = _serviceFactory.GetService(notificationType);
        var payload = NotificationPayload.Create(topic.Title, vendorConfig);

        var result = await notificationService.SendNotificationAsync(payload);
        if (!result.IsSuccessful)
            return NotificationError.SendFailure;

        return result.Content!;
    }
}
