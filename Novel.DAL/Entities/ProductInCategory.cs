using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class ProductInCategory
    {
        public int id_product { get; set; }

        public Product product { get; set; }

        public int id_category { get; set; }

        public Category category { get; set; }
    }
}
