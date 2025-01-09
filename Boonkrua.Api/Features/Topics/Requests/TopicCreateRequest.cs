using Boonkrua.Api.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Extensions;

namespace Boonkrua.Api.Features.Topics.Requests;

public sealed record TopicCreateRequest(List<TopicCreateRequest>? ChildTopics = null)
    : ATopicRequest;
