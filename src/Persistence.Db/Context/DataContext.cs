using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PunchClock.Service.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PunchClock.Service.PersistenceDb.Context
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

        public async Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> generic, string collection)
        {
            var _collection = _db.GetCollection<T>(collection);

            await _collection.InsertManyAsync(generic);

            return await _collection.FindAsync<T>(data => true).Result.ToListAsync();
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

        public async Task<int> GetSequenceValue(string sequenceName, string collection)
        {
            var _collection = _db.GetCollection<Sequence>(collection);
            UpdateDefinition<Sequence> update;
            var find = await _collection.FindAsync<Sequence>(data => true).Result.ToListAsync();
            var filter = Builders<Sequence>.Filter.Eq(s => s.SequenceName, sequenceName);

            update = find.Count == 0
                ? Builders<Sequence>.Update.Inc(s => s.SequenceValue, 10000)
                : Builders<Sequence>.Update.Inc(s => s.SequenceValue, 1);

            var result = await _collection.FindOneAndUpdateAsync(filter, update, new FindOneAndUpdateOptions<Sequence, Sequence> { IsUpsert = true, ReturnDocument = ReturnDocument.After });

            return result.SequenceValue;
        }
    }
}
