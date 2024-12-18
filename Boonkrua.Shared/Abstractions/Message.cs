namespace Boonkrua.Shared.Abstractions;

public readonly struct Message
{
    public string Content { get; }

    private Message(string message) => Content = message;

    public static implicit operator Message(string message) => new(message);

    public static implicit operator string(Message message) => message.Content;
}
