using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DelMazo.PointRecord.Service.PersistenceDb.Context
{
    public class DataContext
    {
        protected readonly IConfiguration _configuration;
        private MongoClient _client;
        private IMongoDatabase _db;
        // private readonly IMongoCollection<T> _data;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration.GetConnectionString("DefaultConnection"));
            _db = _client.GetDatabase(_configuration.GetConnectionString("DatabaseName"));
        }

        public async Task<bool> Add<T>(T data, string collection)
        {
            var cotacoes = _db.GetCollection<T>(collection);
            cotacoes.InsertOne(data);
            return true;
        }

        public void AddRange<T>(IEnumerable<T> generic, string collection)
        {
            var cotacoes = _db.GetCollection<T>(collection);
            cotacoes.InsertMany(generic);
        }

        public IEnumerable<T> GetAll<T>(string collection)
        {
            var cotacoes = _db.GetCollection<T>(collection);
            return cotacoes.Find<T>(data => true).ToList();
        }

        //public T GetById<T>(T generic, string id, string collection)
        //{
        //    var cotacoes = _db.GetCollection<T>(collection);
        //    return cotacoes.Find<T>(Collection => Collection.Id == id).FirstOrDefault();
        //}

        //public void Update<T>(T generic, string id, string collection)
        //{
        //    var cotacoes = _db.GetCollection<T>(collection);
        //    cotacoes.ReplaceOne(data => data.Id == id, generic);
        //}

        //public void Remove<T>(string id, string collection)
        //{
        //    var cotacoes = _db.GetCollection<T>(collection);
        //    cotacoes.DeleteOne(data => data.Id == id);
        //}
    }
}
