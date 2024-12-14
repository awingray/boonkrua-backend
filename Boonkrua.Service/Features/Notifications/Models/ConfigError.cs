using Boonkrua.Service.Models;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Features.Notifications.Models;

public sealed record ConfigError : AError
{
    private ConfigError(string errorMessage)
        : base(errorMessage) { }

    public static ConfigError NotFound => new(ConfigMessages.NotFound.Config);

    public static ConfigError Duplicate => new(ConfigMessages.AlreadyExists.Config);
}
