using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeAssist.Models;
using System.Net.Http;

namespace EmployeeAssist
{
    public class EditorRepository
    {
        string BaseAddress = "http://localhost:50316";
        public void CreateInfo(ReaderViewModel model)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> output = null;
            client.BaseAddress = new Uri(BaseAddress + "/api/Create");
            using (client)
            {
                var response = client.PostAsJsonAsync<ReaderViewModel>("", model);
                var resilt = response.Result;
            }

        }
    }
}