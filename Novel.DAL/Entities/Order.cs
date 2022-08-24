using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
   public class Order
    {
        public int id_order { set; get; }
        public DateTime order_date { set; get; }
        public Guid id_user { set; get; }
        public string ship_name { set; get; }
        public string ship_address { set; get; }
        public string ship_email { set; get; }
        public string ship_phoneNumber { set; get; }
        public OrderStatus status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; }

        public AppUser AppUser { get; set; }


    }
}
