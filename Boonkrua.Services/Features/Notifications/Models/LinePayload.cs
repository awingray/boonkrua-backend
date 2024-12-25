namespace Boonkrua.Services.Features.Notifications.Models;

public sealed record LinePayload(string To, LineMessage[] Messages);

public sealed record LineMessage(string Type, string Text);
