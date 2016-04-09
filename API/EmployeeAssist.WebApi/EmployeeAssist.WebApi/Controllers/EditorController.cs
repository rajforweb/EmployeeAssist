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
    public class EditorController : ApiController
    {
        // GET: Editor
        [Route("api/Create")]
        [HttpPost]
        public void Create([FromBody]EditorViewModel model)
        {
            IMongoDAL dal = new MongoDAL();
            dal.Insert(model.Country, model.State, model.City, model.Category, model.SubCategory, model.information[0].Likes, model.information[0].Descrption);
        }

        // GET: Editor
        [Route("api/Update")]
        [HttpPost]
        public void Update([FromBody]EditorViewModel model)
        {
            //IMongoDAL dal = new MongoDAL();
            //dal.Insert(model.Country, model.State, model.City, model.Category, model.SubCategory, model.Likes, model.Descrption);
        }
      
    }
}