using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string first_name { get; set; }

        public string last_name { get; set; }

        public DateTime Dob { get; set; }

        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
