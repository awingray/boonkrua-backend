using Boonkrua.Services.Features.Topics.Models;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Services.Features.Topics.Interfaces;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<Message, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<Message, TopicError>> UpdateAsync(TopicDto topic);
    Task<Result<Message, TopicError>> DeleteAsync(string id);
}
