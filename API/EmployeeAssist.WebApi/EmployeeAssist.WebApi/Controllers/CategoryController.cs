using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using EmployeeAssist.WebApi.Models;
using EmployeeAssist.WebApi.Providers;
using EmployeeAssist.WebApi.Results;
using System.Linq;
using EmployeeAssistDAL;
using MongoDB.Bson;

namespace EmployeeAssist.WebApi.Controllers
{
    
    public class CategoryController : ApiController
    {
        // GET api/Geolocation/Countries
        [Route("api/Categories")]
        [HttpGet]
        public Dictionary<string, string> GetCategories()
        {
            IMongoDAL dal = new MongoDAL();

            var result = dal.GetCategorySubCategory();
            var response = new Dictionary<string, string>();
            response.Add("--select--", "--select--");
            foreach (BsonDocument item in result)
            {
                if (!response.Keys.Contains(item["Category"].ToString()))
                {
                    response.Add(item["Category"].ToString(), item["Category"].ToString());
                }
            }

            return response;
        }

        [Route("api/SubCategories")]
        [HttpGet]
        public List<ListItem> GetSubCategories([FromUri]string  category="")
        {
            IMongoDAL dal = new MongoDAL();

            var result = dal.GetSubCategory(category);
            var response = new List<ListItem>();
            response.Add(new ListItem { id = "--select--", value = "--select--" });
            foreach (BsonDocument item in result)
            {
                response.Add(new ListItem { id = item["SubCategory"].ToString(), value = item["SubCategory"].ToString() });
            }

            return response;
        }



        [Route("api/Category")]
        [HttpPost]
        public string AddCategory([FromBody]AddCategoryModel model)
        {
            IMongoDAL dal = new MongoDAL();
            dal.InsertCategorySubCategory(model.category, model.subcategory);
            return "OK";
        }

        [Route("api/SubCategory")]
        [HttpPost]
        public string AddSubCategory([FromBody]AddCategoryModel model)
        {

            IMongoDAL dal = new MongoDAL();
            dal.InsertCategorySubCategory(model.category, model.subcategory);
            return "OK";
        }

    }
}
