using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Services.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Topics.Interfaces;

public interface INotificationService
{
    Task<Result<Message, AError>> NotifyAsync(string objectId, string type);
}
