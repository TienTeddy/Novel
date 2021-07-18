using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Category
    {
        public int id_category { get; set; }
        public int sort_order  { get; set; }
        public bool is_show_on_home { get; set; }
        public int? id_parent { get; set; }
        public Status status { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
