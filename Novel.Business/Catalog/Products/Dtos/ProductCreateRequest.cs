using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.Business.Catalog.Products.Dtos
{
    public class ProductCreateRequest
    {
        public string name { get; set; }
        public decimal price { get; set; }
    }
}
