namespace Boonkrua.Shared.Abstractions;

public struct Message
{
    public string Content { get; }

    private Message(string message) => Content = message;

    public static Message Create(string message) => new(message);
}
