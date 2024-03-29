﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Cart
    {
        public int id_cart { set; get; }
        public int id_product { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }

        public Guid id_user { get; set; }

        public Product Product { get; set; }

        public DateTime date_create { get; set; }

        public AppUser AppUser { get; set; }
    }
}
