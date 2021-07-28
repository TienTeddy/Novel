using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Novel.DAL.Entities
{
    public class Transaction
    {
        public int id_transaction { set; get; }
        public DateTime transaction_date { set; get; }
        public string ExternalTransactionId { set; get; }
        public decimal amount { set; get; }
        public decimal fee { set; get; }
        public string result { set; get; }
        public string message { set; get; }
        public TransactionStatus status { set; get; }
        public string provider { set; get; }

        public Guid id_user { get; set; }

        public AppUser AppUser { get; set; }

    }
}
