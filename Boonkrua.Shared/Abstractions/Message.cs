namespace Boonkrua.Shared.Abstractions;

public readonly struct Message
{
    private string Content { get; }

    private Message(string message) => Content = string.Intern(message);

    public static implicit operator Message(string message) => new(message);

    public static implicit operator string(Message message) => message.Content;
}
