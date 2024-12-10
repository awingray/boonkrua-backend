namespace Boonkrua.Shared.Messages;

public static class TopicMessages
{
    public static class NotFound
    {
        public const string Topic = "Could not find the topic object.";
    }

    public static class Null
    {
        public const string Id = "The topic identifier is null.";
    }

    public static class Create
    {
        public const string Success = "Topic has been created successfully";
    }

    public static class Update
    {
        public const string Success = "Topic has been updated successfully";
    }

    public static class Delete
    {
        public const string Success = "Topic has been deleted successfully";
    }
}
