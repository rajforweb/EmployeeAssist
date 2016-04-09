using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeAssist.Models;
using System.Net.Http;

namespace EmployeeAssist
{
    public class GeoRepository
    {
        string BaseAddress = "http://localhost:50316";
        public List<ListItem> GetCountries()
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Countries");
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }
            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { id = item.Key, value = item.Value } ));

            return response;
        }


        public List<ListItem> GetStates(string id)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/States?countryId=" + id);
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }
            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { id = item.Key, value = item.Value }));

            return response;
        }

        public List<ListItem> GetCities(string id)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Cities?stateId=" + id);
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }
            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { id = item.Key, value = item.Value }));

            return response;
        }

        public List<ListItem> GetCategory()
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Categories");
            using (client)
            {
                var result = client.GetAsync("").Result;
                output = result.Content.ReadAsAsync<Dictionary<string, string>>().Result;
            }
            var response = new List<ListItem>();

            output.ToList().ForEach(item => response.Add(new ListItem() { id = item.Key, value = item.Value }));

            return response;
        }

        public List<ListItem> GetSubCategory()
        {
            HttpClient client = new HttpClient();
           
            client.BaseAddress = new Uri(BaseAddress + "/api/SubCategories");
            using (client)
            {
                var result = client.GetAsync("").Result;
                return result.Content.ReadAsAsync<List<ListItem>>().Result;
            }
          
        }
    }
}