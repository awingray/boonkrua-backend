namespace Boonkrua.Shared.Messages;

public static class NotificationConfigMessages
{
    public static class NotFound
    {
        public const string User = "Can not find the notification config with this user.";
        public const string Config = "Can not find the notification config.";
    }

    public static class Invalid
    {
        public const string NotificationType = "The notification type is invalid.";
    }

    public static class Create
    {
        public const string Success = "The notification configuration was successfully created.";
    }

    public static class AlreadyExists
    {
        public const string Config = "The notification configuration already exists.";
    }
}
