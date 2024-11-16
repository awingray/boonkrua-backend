using Boonkrua.Constants.Enums;
using Boonkrua.Constants.Messages;
using Boonkrua.Extensions;
using Boonkrua.Factories;
using Boonkrua.Models.Error;
using Boonkrua.Services.Topics;
using static Microsoft.AspNetCore.Http.Results;

namespace Boonkrua.Services;

public sealed class NotificationOrchestrator(
    ITopicService topicService,
    NotificationServiceFactory factory
)
{
    private readonly ITopicService _topicService = topicService;
    private readonly NotificationServiceFactory _factory = factory;

    public async Task<IResult> NotifyAsync(string objectId, string type)
    {
        if (!type.TryParse(out NotificationType notificationType))
            return BadRequest(NotificationMessages.InvalidProvider);

        var topicResult = await _topicService.GetByIdAsync(objectId);
        if (!topicResult.IsSuccessful)
            return NotFound(topicResult.Error);

        var notificationService = _factory.GetService(notificationType);
        var result = await notificationService.SendNotificationAsync(topicResult.Content!.ToJson());
        return result.Match(Ok, BadRequest);
    }
}
