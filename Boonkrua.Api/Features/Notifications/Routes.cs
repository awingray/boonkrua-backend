namespace Boonkrua.Api.Features.Notifications;

internal static class Routes
{
    internal static class NotificationConfig
    {
        private const string Base = "/config";
        private const string UserIdSegment = "/{userId}";

        public const string GetByUserId = Base + UserIdSegment;
        public const string Create = Base;
    }
}
