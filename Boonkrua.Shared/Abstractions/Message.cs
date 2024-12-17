namespace Boonkrua.Shared.Abstractions;

public struct Message
{
    public string Content { get; }

    private Message(string message) => Content = message;

    public static Message Create(string message) => new(message);

    public static implicit operator Message(string message) => new(message);

    public override string ToString() => Content;
}
