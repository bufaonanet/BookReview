using BookReview.Api.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookReview.Api.Infra.Persistence;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly MongoConfig _config;


    public MongoDbContext(IOptions<MongoConfig> config)
    {
        _config = config.Value;
        var client = new MongoClient(_config.ConnectionString);
        _database = client.GetDatabase(_config.Database);
    }
    
    public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
}