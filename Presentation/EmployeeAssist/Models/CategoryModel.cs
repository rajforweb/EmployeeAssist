using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAssist.Models
{
    public class CategoryModel
    {
        [Required]
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Required]
        public string Category { get; set; }
        public string SubCategory { get; set; }

    }
}