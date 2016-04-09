using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace EmployeeAssist.WebApi.Models
{
    public class ResultModel
    {
        public string status { get; set; }
        public int tp { get; set; }
        public string msg { get; set; }
        public Dictionary<string,string> result { get; set; }
    }
}