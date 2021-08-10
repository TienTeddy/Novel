using Novel.ViewModels.Catalog.ProductImages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int id_product { set; get; }
        public decimal price { set; get; }
        public decimal original_price { set; get; }
        public int stock { set; get; }
        public int view_count { set; get; }
        public DateTime date_created { set; get; }

        public string name { set; get; }
        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }

        public string seo_alias { get; set; }
        public string id_language { set; get; }

        public List<ProductImageViewModel> productImages { get; set; }
    }
}
