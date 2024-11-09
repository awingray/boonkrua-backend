using Boonkrua.Constants;
using Boonkrua.Extensions;
using Boonkrua.Models.Dto;
using Boonkrua.Models.Response;
using Boonkrua.Repositories.Topics;

namespace Boonkrua.Services.Topics;

public class TopicService(ITopicRepository repository) : ITopicService
{
    private readonly ITopicRepository _repository = repository;

    public async Task<Result<TopicDto, string>> GetByIdAsync(string topicId)
    {
        var topic = await _repository.GetByIdAsync(topicId);
        if (topic is null)
            return TopicMessages.NotFound;

        return TopicDto.FromEntity(topic);
    }

    public async Task<Result<IEnumerable<TopicDto>, string>> GetAllAsync()
    {
        var topics = await _repository.GetAllAsync();
        return topics.ToMappedList(TopicDto.FromEntity);
    }

    public async Task<Result<string, string>> CreateAsync(TopicDto topic)
    {
        await _repository.CreateAsync(topic.ToEntity());
        return Result<string, string>.Ok(TopicMessages.CreateSuccess);
    }

    public async Task<Result<string, string>> UpdateAsync(TopicDto topic)
    {
        if (topic.Id is null)
            return Result<string, string>.Err(TopicMessages.NullId);

        var existingTopic = await _repository.GetByIdAsync(topic.Id);
        if (existingTopic is null)
            return Result<string, string>.Err(TopicMessages.NotFound);

        await _repository.UpdateAsync(topic.ToEntity());
        return Result<string, string>.Ok(TopicMessages.UpdateSuccess);
    }
}
