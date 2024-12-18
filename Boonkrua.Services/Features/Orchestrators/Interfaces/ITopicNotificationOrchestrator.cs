using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Orchestrators.Interfaces;

public interface ITopicNotificationOrchestrator
{
    Task<Result<Message, AError>> NotifyAsync(string objectId, string type);
}
