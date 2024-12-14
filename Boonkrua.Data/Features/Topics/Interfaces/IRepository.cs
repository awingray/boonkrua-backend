using Boonkrua.Data.Features.Topics.Models;

namespace Boonkrua.Data.Features.Topics.Interfaces;

public interface IRepository
{
    public Task<Topic?> GetByIdAsync(string id);
    public Task<IEnumerable<Topic>> GetAllAsync();
    public Task CreateAsync(Topic topic);
    public Task UpdateAsync(Topic topic);
    public Task DeleteAsync(string id);
}
