using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeAssist.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace EmployeeAssist
{
    public class ReaderRepository
    {
        string BaseAddress = "http://localhost:50316";
        public List<Information> GetRecords(ReaderViewModel readerViewModel)
        {
            HttpClient client = new HttpClient();

            List<Information> output = new List<Information>();
            client.BaseAddress = new Uri(BaseAddress + "/api/Read?Country=" + readerViewModel.Country + "&State=" + readerViewModel.State + "&City=" + readerViewModel.City + "&Category=" + readerViewModel.Category + "&SubCategory=" + readerViewModel.SubCategory);
            using (client)
            {
                var response = client.GetAsync("").Result;
                output = response.Content.ReadAsAsync<List<Information>>().Result;
                
            }

            return output;
        }
    }
}