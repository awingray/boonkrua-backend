using Boonkrua.Enums;
using Boonkrua.Extensions;
using Boonkrua.Factories;
using Boonkrua.Models.Error;
using Boonkrua.Models.Response;
using Boonkrua.Services.Topics;

namespace Boonkrua.Services;

public sealed class NotificationOrchestrator(
    ITopicService topicService,
    NotificationServiceFactory factory
)
{
    private readonly ITopicService _topicService = topicService;
    private readonly NotificationServiceFactory _factory = factory;

    public async Task<Result<MessageResponse, NotificationError>> NotifyAsync(
        string objectId,
        string type
    )
    {
        if (!type.TryParse(out NotificationType notificationType))
            return NotificationError.InvalidType;

        var result = await _topicService.GetByIdAsync(objectId);
        if (!result.IsSuccessful)
            return NotificationError.NoContent;

        var notificationService = _factory.GetService(notificationType);
        return await notificationService.SendNotificationAsync(result.Content!.ToJson());
    }
}
