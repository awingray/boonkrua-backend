using Boonkrua.Data.Contexts;
using Boonkrua.Data.Interfaces;
using Boonkrua.Data.Models.Notifications;
using MongoDB.Driver;

namespace Boonkrua.Data.Repositories.Notifications;

public class UserNotificationRepository(MongoDbContext context) : IUserNotificationRepository
{
    private readonly IMongoCollection<UserNotificationConfig> _col =
        context.UserNotificationConfigs;

    public async Task<UserNotificationConfig?> GetByUserIdAsync(string userId) =>
        await _col.Find(c => c.UserId == userId).FirstOrDefaultAsync();

    public async Task CreateAsync(UserNotificationConfig config) =>
        await _col.InsertOneAsync(config);
}
