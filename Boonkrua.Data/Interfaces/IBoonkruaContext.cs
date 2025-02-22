using Boonkrua.Data.Features.Configs.Models;
using Boonkrua.Data.Features.Topics.Models;
using MongoDB.Driver;

namespace Boonkrua.Data.Interfaces;

public interface IBoonkruaContext
{
    IMongoCollection<Topic> Topics { get; }
    IMongoCollection<Config> Configs { get; }
    void EnsureIndexes();
}
