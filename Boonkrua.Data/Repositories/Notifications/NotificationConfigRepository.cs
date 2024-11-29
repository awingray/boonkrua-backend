using Boonkrua.Data.Contexts;
using Boonkrua.Data.Interfaces;
using Boonkrua.Data.Models.Notifications;
using MongoDB.Driver;

namespace Boonkrua.Data.Repositories.Notifications;

public class NotificationConfigRepository(MongoDbContext context) : INotificationConfigRepository
{
    private readonly IMongoCollection<NotificationConfig> _col = context.NotificationConfigs;

    public async Task<NotificationConfig?> GetByUserIdAsync(string userId) =>
        await _col.Find(c => c.UserId == userId).FirstOrDefaultAsync();

    public async Task CreateAsync(NotificationConfig config) => await _col.InsertOneAsync(config);
}
