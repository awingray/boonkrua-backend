using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Shared.Messages;

public static class TopicMessages
{
    public static class NotFound
    {
        public static readonly Message Topic = "Could not find the topic object.";
    }

    public static class Null
    {
        public static readonly Message Id = "The topic identifier is null.";
    }

    public static class Create
    {
        public static readonly Message Success = "Topic has been created successfully";
    }

    public static class Update
    {
        public static readonly Message Success = "Topic has been updated successfully";
    }

    public static class Delete
    {
        public static readonly Message Success = "Topic has been deleted successfully";
    }
}
