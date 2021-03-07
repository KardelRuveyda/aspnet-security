using System;
using System.Collections.Generic;

namespace DataProtection.Web.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Color { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
