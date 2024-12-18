using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Notifications.Messages;

public static class NotificationMessages
{
    public static class Send
    {
        public static readonly Message Failure =
            "Something went wrong while sending a notification.";
        public static readonly Message Success = "The notification was successfully sent.";
    }

    public static class Invalid
    {
        public static readonly Message Provider = "Invalid notification provider.";
    }
}
