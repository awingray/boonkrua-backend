using Boonkrua.Constants.Enums;
using Boonkrua.Extensions;
using Boonkrua.Factories;
using Boonkrua.Models.Error;
using Boonkrua.Models.Response;
using Boonkrua.Repositories.Topics;

namespace Boonkrua.Services.Topics;

public sealed class TopicNotificationService(
    ITopicRepository repository,
    NotificationServiceFactory serviceFactory
) : ITopicNotificationService
{
    private readonly ITopicRepository _repository = repository;
    private readonly NotificationServiceFactory _serviceFactory = serviceFactory;

    public async Task<Result<MessageResponse, NotificationError>> NotifyAsync(
        string objectId,
        string type
    )
    {
        if (!type.TryParse(out NotificationType notificationType))
            return NotificationError.InvalidType;

        var topic = await _repository.GetByIdAsync(objectId);
        if (topic is null)
            return NotificationError.NoContent;

        var notificationService = _serviceFactory.GetService(notificationType);
        return await notificationService.SendNotificationAsync(topic.Title);
    }
}
