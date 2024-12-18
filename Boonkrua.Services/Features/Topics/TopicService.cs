using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Topics.Interfaces;
using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Extensions;
using static Boonkrua.Services.Features.Topics.Messages.TopicMessages;

namespace Boonkrua.Services.Features.Topics;

public sealed class TopicService(ITopicRepository repository) : ITopicService
{
    private readonly ITopicRepository _repository = repository;

    public async Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId)
    {
        var topic = await _repository.GetByIdAsync(topicId);
        if (topic is null)
            return TopicError.NotFound;

        return TopicDto.FromEntity(topic);
    }

    public async Task<Result<List<TopicDto>, TopicError>> GetAllAsync()
    {
        var topics = await _repository.GetAllAsync();
        return topics.ToMappedList(TopicDto.FromEntity);
    }

    public async Task<Result<Message, TopicError>> CreateAsync(TopicDto topic)
    {
        await _repository.CreateAsync(topic.ToEntity());
        return Create.Success;
    }

    public async Task<Result<Message, TopicError>> UpdateAsync(TopicDto topic)
    {
        if (topic.Id is null)
            return TopicError.NullId;

        var existingTopic = await _repository.GetByIdAsync(topic.Id);
        if (existingTopic is null)
            return TopicError.NotFound;

        await _repository.UpdateAsync(topic.ToEntity());
        return Update.Success;
    }

    public async Task<Result<Message, TopicError>> DeleteAsync(string id)
    {
        await _repository.DeleteAsync(id);
        return Delete.Success;
    }
}
