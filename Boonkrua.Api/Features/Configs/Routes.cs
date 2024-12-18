namespace Boonkrua.Api.Features.Configs;

internal static class Routes
{
    internal static class Config
    {
        private const string Base = "/config";
        private const string UserIdSegment = "/{userId}";

        public const string GetByUserId = Base + UserIdSegment;
        public const string Create = Base;
    }
}
