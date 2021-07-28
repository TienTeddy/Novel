using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Category
    {
        public int id_category { set; get; }
        public int sort_order { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? id_parent { set; get; }
        public Status status { set; get; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

    }
}
