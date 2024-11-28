namespace Boonkrua.Api;

public static class Routes
{
    public static class Topic
    {
        private const string Base = "/topic";
        private const string IdSegment = "/{objectId}";
        private const string NotifySegment = "/notify/{type}";

        public const string GetById = Base + IdSegment;
        public const string GetAll = Base;
        public const string Create = Base;
        public const string Update = Base;
        public const string Delete = Base + IdSegment;
        public const string Notify = Base + IdSegment + NotifySegment;
    }
}
