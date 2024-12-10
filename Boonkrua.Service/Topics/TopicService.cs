using Boonkrua.Data.Features.Topics.Interfaces;
using Boonkrua.Service.Interfaces.Topics;
using Boonkrua.Service.Models.Dto;
using Boonkrua.Service.Models.Error.Topics;
using Boonkrua.Shared.Abstractions;
using Boonkrua.Shared.Extensions;
using Boonkrua.Shared.Messages;

namespace Boonkrua.Service.Topics;

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

    public async Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync()
    {
        var topics = await _repository.GetAllAsync();
        return topics.ToMappedList(TopicDto.FromEntity);
    }

    public async Task<Result<Message, TopicError>> CreateAsync(TopicDto topic)
    {
        await _repository.CreateAsync(topic.ToEntity());
        return Message.Create(TopicMessages.Create.Success);
    }

    public async Task<Result<Message, TopicError>> UpdateAsync(TopicDto topic)
    {
        if (topic.Id is null)
            return TopicError.NullId;

        var existingTopic = await _repository.GetByIdAsync(topic.Id);
        if (existingTopic is null)
            return TopicError.NotFound;

        await _repository.UpdateAsync(topic.ToEntity());
        return Message.Create(TopicMessages.Update.Success);
    }

    public async Task<Result<Message, TopicError>> DeleteAsync(string id)
    {
        await _repository.DeleteAsync(id);
        return Message.Create(TopicMessages.Delete.Success);
    }
}
