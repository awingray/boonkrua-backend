namespace Boonkrua.Shared.Messages;

public static class NotificationMessages
{
    public static class Send
    {
        public const string Failure = "Something went wrong while sending a notification.";
        public const string Success = "The notification was successfully sent.";
    }

    public static class Invalid
    {
        public const string Provider = "Invalid notification provider.";
    }
}
