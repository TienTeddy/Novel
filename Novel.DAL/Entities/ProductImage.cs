﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class ProductImage
    {
        public int id_productImage { get; set; }

        public int id_product { get; set; }

        public string image_path { get; set; }

        public string caption { get; set; }

        public bool IsDefault { get; set; }

        public DateTime date_created { get; set; }

        public int sort_order { get; set; }

        public long file_size { get; set; }

        public Product Product { get; set; }
    }
}
