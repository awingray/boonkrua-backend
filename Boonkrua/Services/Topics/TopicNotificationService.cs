using Boonkrua.Common.Enums;
using Boonkrua.Extensions;
using Boonkrua.Factories;
using Boonkrua.Models.Error.Topics;
using Boonkrua.Models.Response;
using Boonkrua.Repositories.Topics.Interfaces;
using Boonkrua.Services.Topics.Interfaces;

namespace Boonkrua.Services.Topics;

public sealed class TopicNotificationService(
    ITopicRepository repository,
    NotificationServiceFactory serviceFactory
) : ITopicNotificationService
{
    private readonly ITopicRepository _repository = repository;
    private readonly NotificationServiceFactory _serviceFactory = serviceFactory;

    public async Task<Result<MessageResponse, TopicNotificationError>> NotifyAsync(
        string objectId,
        string type
    )
    {
        if (!type.TryParse(out NotificationType notificationType))
            return TopicNotificationError.InvalidType;

        var topic = await _repository.GetByIdAsync(objectId);
        if (topic is null)
            return TopicNotificationError.NotFound;

        var notificationService = _serviceFactory.GetService(notificationType);
        var result = await notificationService.SendNotificationAsync(topic.Title);
        if (!result.IsSuccessful)
            return TopicNotificationError.SendFailure;

        return result.Content!;
    }
}
