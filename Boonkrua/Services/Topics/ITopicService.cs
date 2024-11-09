using Boonkrua.Models.Dto;
using Boonkrua.Models.Response;

namespace Boonkrua.Services.Topics;

public interface ITopicService
{
    Task<Result<TopicDto, string>> GetByIdAsync(string topicId);
    Task<Result<IEnumerable<TopicDto>, string>> GetAllAsync();
    Task<Result<string, string>> CreateAsync(TopicDto topic);
}
