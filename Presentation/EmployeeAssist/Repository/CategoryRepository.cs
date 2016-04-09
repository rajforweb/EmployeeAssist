using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeAssist.Models;
using System.Net.Http;

namespace EmployeeAssist
{
    public class CategoryRepository
    {
        string BaseAddress = "http://localhost:50316";
        public void AddCategory(CategoryModel model)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Category");
            using (client)
            {
                var response = client.PostAsJsonAsync<CategoryModel>("", model);
                var resilt = response.Result;
            }

        }


        public void AddSubCategory(CategoryModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/SubCategory");
            using (client)
            {
                client.PostAsJsonAsync<CategoryModel>("", model);

            }
        }


        public List<ListItem> GetSubCategory(string Category)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress + "/api/SubCategories?Category=" + Category);

            List<ListItem> output = new List<ListItem>();
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
            return output;
        }

    }
}