﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.Business.Catalog.Products.Dtos
{
    public class ProductUpdateRequest
    {
        public int id_product { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string details { set; get; }
        public string seo_description { set; get; }
        public string seo_title { set; get; }

        public string seo_alias { get; set; }
        public string id_language { set; get; }
    }
}
