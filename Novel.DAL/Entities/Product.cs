using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Product
    {
        public int id_product { set; get; }
        public decimal price { set; get; }
        public decimal original_price { set; get; }
        public int stock { set; get; }
        public int view_count { set; get; }
        public DateTime date_created { set; get; }

        public bool? IsFeatured { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}