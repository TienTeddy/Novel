using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class Contact
    {
        public int id_contact { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public string phone_number { set; get; }
        public string message { set; get; }
        public Status status { set; get; }

    }
}
