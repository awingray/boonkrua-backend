using Boonkrua.Http.Models.Dto.Topics;
using Boonkrua.Http.Models.Error.Topics;
using Boonkrua.Http.Models.Response;

namespace Boonkrua.Http.Services.Topics.Interfaces;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<MessageResponse, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> UpdateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> DeleteAsync(string id);
}
