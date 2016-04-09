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
    public interface IMongoDAL
    {
        List<BsonDocument> GetInformation(string country, string state, string city, string category, string subcategory);
        List<BsonDocument> Update(string country, string state, string city, string category, string subcategory, int Likes);
        void Insert(string country, string state, string city, string category, string subcategory, int Likes, string Description);
        void InsertCategorySubCategory(string category, string subcategory);
        List<BsonDocument> GetCategorySubCategory();
        List<BsonDocument> GetSubCategory(string category);
        void Update(string Id, string Likes);
    }    
}
