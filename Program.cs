using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson.Serialization; // BsonClassMap
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;

namespace M101DotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(String[] args)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("test");
            var col = db.GetCollection<BsonDocument>("people");

            var doc = new BsonDocument
            {
                {"Name", "john" },
                {"Age", 30 },
                {"Profession", "job" }
            };

            await col.InsertOneAsync(doc);

        }
    }
}
