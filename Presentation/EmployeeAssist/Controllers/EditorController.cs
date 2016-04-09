
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAssist.Models;

namespace EmployeeAssist.Controllers
{
    public class EditorController : Controller
    {

        List<ListItem> defaultListItem = new List<ListItem>() { new ListItem() { id = "", value = "---select---" } };
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
                SubCategoryOptions = repo.GetSubCategory(),
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Index(ReaderViewModel model)
        {
            // Call service and insert records
            var repo = new EditorRepository();
            repo.CreateInfo(model);
            return View(model);

        }
    }
}