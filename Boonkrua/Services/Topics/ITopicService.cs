using Boonkrua.Models.Dto;
using Boonkrua.Models.Error;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<MessageResponse, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> UpdateAsync(TopicDto topic);
}
