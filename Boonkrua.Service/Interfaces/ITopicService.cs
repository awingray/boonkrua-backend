using Boonkrua.DataContracts.Response;
using Boonkrua.Service.Models.Dto.Topics;
using Boonkrua.Service.Models.Error.Topics;

namespace Boonkrua.Service.Interfaces;

public interface ITopicService
{
    Task<Result<TopicDto, TopicError>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, TopicError>> GetAllAsync();
    Task<Result<MessageResponse, TopicError>> CreateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> UpdateAsync(TopicDto topic);
    Task<Result<MessageResponse, TopicError>> DeleteAsync(string id);
}
