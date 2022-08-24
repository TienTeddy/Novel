using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Slide
    {
        public int id_slide { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public string url { set; get; }

        public string image { get; set; }
        public int sort_order { get; set; }
        public Status status { set; get; }
    }
}