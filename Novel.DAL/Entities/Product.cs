using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Product
    {
        public int id_product { get; set; }
        public decimal price { get; set; }
        public decimal original_price  { get; set; }
        public int stock { get; set; }
        public int view_count { get; set; }
        public DateTime date_created { get; set; }
        public string seo_alias { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
