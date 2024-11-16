using Boonkrua.Models.Dto.Topics;
using Boonkrua.Models.Error.Topics;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics.Interfaces;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<MessageResponse, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> UpdateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> DeleteAsync(string id);
}
