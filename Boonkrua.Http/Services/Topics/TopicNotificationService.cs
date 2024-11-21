using Boonkrua.Common.Enums;
using Boonkrua.Http.Extensions;
using Boonkrua.Http.Factories;
using Boonkrua.Http.Models.Error.Topics;
using Boonkrua.Http.Models.Response;
using Boonkrua.Http.Repositories.Topics.Interfaces;
using Boonkrua.Http.Services.Topics.Interfaces;

namespace Boonkrua.Http.Services.Topics;

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
