using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kit19Assignment.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public DateTime Manufacture_date { get; set; }
        public string Category { get; set; }
    }
}