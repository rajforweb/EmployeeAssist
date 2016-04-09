
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAssist.Models;

namespace EmployeeAssist.Controllers
{
    public class ReaderController : Controller
    {

        List<ListItem> defaultListItem = new List<ListItem>() { new ListItem() { id = "", value = "select" } };
        // GET: Search
        public ActionResult Index()
        {

            var repo = new GeoRepository();
    
            var model = new ReaderViewModel()
            {

                CountryOptions = repo.GetCountries(),
                StateOptions = defaultListItem,
                CityOptions = defaultListItem,
                CategoryOptions = repo.GetCategory(),
                SubCategoryOptions = defaultListItem
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {
            var repo = new GeoRepository();
            var repoReader = new ReaderRepository();

            model.CountryOptions = repo.GetCountries();
            model.StateOptions = (!string.IsNullOrWhiteSpace(model.Country)) ? repo.GetStates(model.Country) : defaultListItem;
            model.CityOptions = (!string.IsNullOrWhiteSpace(model.State)) ? repo.GetCities(model.State) : defaultListItem;
            model.CategoryOptions = repo.GetCategory();
            model.SubCategoryOptions = defaultListItem;
            model.information = repoReader.GetRecords(model);
          
            return View(model);
        }

        [HttpGet]
        public JsonResult GetStates(string country)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            
            var repo = new GeoRepository();
            result.Data = repo.GetStates(country);
            return result;
        }

        [HttpGet]
        public JsonResult GetCities(string country, string state)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            var repo = new GeoRepository();
            result.Data = repo.GetCities(state);
            return result;

        }


        [HttpGet]
        public ActionResult Test()
        {
            return View("test");
        }
    }
}