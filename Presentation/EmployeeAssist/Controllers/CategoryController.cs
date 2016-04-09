using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAssist.Models;

namespace EmployeeAssist.Controllers
{
    public class CategoryController : Controller
    {
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if (!string.IsNullOrEmpty(model.Category) && !string.IsNullOrEmpty(model.SubCategory))
                new CategoryRepository().AddCategory(model);
            return RedirectToAction("Index", "Editor");
        }

        [HttpPost]
        public ActionResult AddSubCategory(CategoryModel model)
        {
            if (!string.IsNullOrEmpty(model.Category) && !string.IsNullOrEmpty(model.SubCategory))
                new CategoryRepository().AddSubCategory(model);
            return RedirectToAction("Index", "Editor");
        }


        [HttpGet]
        public JsonResult GetSubCategories(string category)
        {
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            CategoryRepository repo = new CategoryRepository();
            result.Data = repo.GetSubCategory(category);

            return result;
            //mock
            //if (category.Equals("Accomodation", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    result.Data = new List<ListItem>()
            //    {
            //        new ListItem {id="",value="" },
            //       new ListItem { id="Share",value="Share"},
            //       new ListItem { id="New",value="New"},
            //    };
            //}
            //if (category.Equals("Allowances", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    result.Data = new List<ListItem>()
            //    {
            //        new ListItem {id="",value="" },
            //       new ListItem { id="ChildEducation",value="ChildEducation"},
            //       new ListItem { id="Internet",value="Internet"},
            //    };
            //}

            return result;
        }
    }
}