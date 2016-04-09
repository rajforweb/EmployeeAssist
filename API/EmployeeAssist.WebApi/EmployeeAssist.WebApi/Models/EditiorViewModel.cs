using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EmployeeAssist.WebApi.Models
{
    public class EditorViewModel
    {
        public string Country{ get; set; }

        public string State{ get; set; }

        public string City{ get; set; }

        public string Category{ get; set; }

        public string SubCategory{ get; set; }

        public List<Information> information { get; set; }
    }


    public class Information
    {
        public string Id { get; set; }
        public int Likes { get; set; }
        public string Descrption { get; set; }
        //public string Url { get; set; }
        //public byte[] image { get; set; }
    }
}