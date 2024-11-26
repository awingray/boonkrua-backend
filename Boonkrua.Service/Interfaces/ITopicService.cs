using Boonkrua.Service.Models.Dto.Topics;
using Boonkrua.Service.Models.Error.Topics;
using Boonkrua.Shared.Abstractions;

namespace Boonkrua.Service.Interfaces;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<Message, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<Message, TopicError>> UpdateAsync(TopicDto topic);
    Task<Result<Message, TopicError>> DeleteAsync(string id);
}
