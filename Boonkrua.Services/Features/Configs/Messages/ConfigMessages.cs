using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Configs.Messages;

public static class ConfigMessages
{
    public static class NotFound
    {
        public static readonly Message User =
            "Can not find the notification config with this user.";
        public static readonly Message Config = "Can not find the notification config.";
    }

    public static class Invalid
    {
        public static readonly Message NotificationType = "The notification type is invalid.";
    }

    public static class Create
    {
        public static readonly Message Success =
            "The notification configuration was successfully created.";
    }

    public static class AlreadyExists
    {
        public static readonly Message Config = "The notification configuration already exists.";
    }
}
