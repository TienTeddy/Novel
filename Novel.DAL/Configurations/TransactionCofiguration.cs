using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class TransactionCofiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.id_transaction);
            builder.HasOne(x => x.AppUser).WithMany(y => y.Transactions)
                .HasForeignKey(y => y.id_user);
            //throw new NotImplementedException();
        }
    }
}
