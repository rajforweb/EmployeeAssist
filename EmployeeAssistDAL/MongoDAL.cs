using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization; // BsonClassMap
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;
using MongoDB.Driver.Core;

namespace EmployeeAssistDAL
{
    public class MongoDAL : IMongoDAL
    {
        List<BsonDocument> IMongoDAL.GetInformation(string country, string state, string city, string category, string subcategory)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("eta");
            var col = db.GetCollection<BsonDocument>("employeeassist");
            var builder = Builders<BsonDocument>.Filter;

            var filter = builder.Eq("Country", country) & builder.Eq("State", state)
                & builder.Eq("City", city) & builder.Eq("Category", category) & builder.Eq("SubCategory", subcategory);
            List<BsonDocument> result = col.Find(filter).ToList();
            return result;            
        }

        List<BsonDocument> IMongoDAL.GetCategorySubCategory()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("eta");
            var col = db.GetCollection<BsonDocument>("Category");
           
            List<BsonDocument> result = col.AsQueryable().ToList();
            return result;           
        }

        List<BsonDocument> IMongoDAL.GetSubCategory(string Category)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase("eta");
            var col = db.GetCollection<BsonDocument>("Category");

            var builder = Builders<BsonDocument>.Filter;

            var filter = builder.Eq("Category", Category);

            List<BsonDocument> result = col.Find(filter).ToList();
            return result;
        }


        List<BsonDocument> IMongoDAL.Update(string country, string state, string city, string category, string subcategory, int Likes)
        {

            throw new NotImplementedException();
        }

        void IMongoDAL.Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("eta");
            var col = db.GetCollection<BsonDocument>("employeeassist");

            var doc = new BsonDocument
            {
                { "Country" , country },
                { "State", state},
                { "City", city },
                { "Category", category },
                { "SubCategory" , subcategory },
                { "Description" , Description },
                { "Likes" , Likes }
                //{ "Image", "" },
                //{ "Video", "" }
            };

            col.InsertOne(doc);
        }


        void IMongoDAL.InsertCategorySubCategory(string category, string subcategory)//, int Likes, string Description)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var db = client.GetDatabase("eta");
            var col = db.GetCollection<BsonDocument>("Category");

            var doc = new BsonDocument
            {
                { "Category", category },
                { "SubCategory" , subcategory }
            };

            col.InsertOne(doc);
        }

        public void Update(string Id, string Likes)
        {
        }
    }


}
