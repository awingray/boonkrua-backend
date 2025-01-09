using Boonkrua.Api.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record TopicUpdateRequest(string Id, List<TopicUpdateRequest>? ChildTopics = null)
    : ATopicRequest;
