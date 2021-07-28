using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Promotion
    {
        public int id_promotion { set; get; }
        public DateTime from_date { set; get; }
        public DateTime to_date { set; get; }
        public bool ApplyForAll { set; get; }
        public int? discount_percent { set; get; }
        public decimal? discount_amount { set; get; }
        public string id_product { set; get; }
        public string id_productCategory { set; get; }
        public Status status { set; get; }
        public string name { set; get; }

    }
}
