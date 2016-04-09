using System.Collections.Generic;
using System.Web.Http;
using EmployeeAssist.WebApi.Models;
using EmployeeAssistDAL;
using MongoDB.Bson;
using System;

namespace EmployeeAssist.WebApi.Controllers
{
    public class ReaderController : ApiController
    {
        // GET: Editor
        [Route("api/Read")]
        [HttpGet]
        public List<Information> GetAllRecords([FromUri] EditorViewModel model)
        {
            IMongoDAL dal = new MongoDAL();
            var result = dal.GetInformation(model.Country, model.State, model.City, model.Category, model.SubCategory);

            List<Information> response = new List<Information>();
            foreach (var item in result)
            {
                response.Add(new Information { Id = item["_id"].ToString(), Descrption = item["Description"].ToString(), Likes = Convert.ToInt32(item["Likes"].ToString()) });
            }

            return response;
        }

        // GET: Editor
        [Route("api/UpdateLikes")]
        [HttpPost]
        public void Update([FromBody]Information model)
        {
            IMongoDAL dal = new MongoDAL();
            dal.Update(model.Id, model.Likes);
        }
    }
}