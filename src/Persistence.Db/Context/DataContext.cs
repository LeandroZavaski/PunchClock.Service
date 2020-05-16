using DelMazo.PointRecord.Service.Application.Helpers;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Context
{
    public class DataContext
    {
        protected readonly IConfiguration _configuration;
        private MongoClient _client;
        private IMongoDatabase _db;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration.GetConnectionString("DefaultConnection"));
            _db = _client.GetDatabase(_configuration.GetConnectionString("DatabaseName"));
        }

        public async Task<T> Add<T>(T data, string id, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.InsertOneAsync(data);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public void AddRange<T>(IEnumerable<T> generic, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            _collection.InsertMany(generic);
        }

        public async Task<IEnumerable<T>> GetAll<T>(string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            return await _collection.FindAsync<T>(data => true).Result.ToListAsync();
        }

        public async Task<T> GetById<T>(string id, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetAuth<T>(string document, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            var filter = Builders<T>.Filter.Eq("Document", document);

            return await _collection.Find<T>(filter).FirstOrDefaultAsync();
        }

        public async Task<T> Update<T>(T generic, string id, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, generic);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> Remove<T>(string id, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.FindOneAndDeleteAsync(filter);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
