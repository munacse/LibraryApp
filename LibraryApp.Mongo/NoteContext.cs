using LibraryApp.Mongo.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace LibraryApp.Mongo
{
    public class NoteContext
    {
        private readonly IMongoDatabase _database = null;

        public NoteContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Note> Notes
        {
            get
            {
                return _database.GetCollection<Note>("Note");
            }
        }
        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Product");
            }
        }
        public IMongoCollection<Employee> Employees
        {
            get
            {
                return _database.GetCollection<Employee>("Employee");
            }
        }
    }
}
