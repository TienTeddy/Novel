﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class OrderDetail
    {

        public int id_order { set; get; }
        public int id_product { set; get; }
        public int quantity { set; get; }
        public decimal price { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
