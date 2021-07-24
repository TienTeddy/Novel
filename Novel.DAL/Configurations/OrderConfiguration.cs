using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.id_order);

            builder.Property(x => x.id_order).UseIdentityColumn();

            builder.Property(x => x.order_date).HasDefaultValue(DateTime.Now);

            builder.Property(x => x.ship_email).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.ship_address).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ship_name).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ship_phone_number).IsRequired().HasMaxLength(200);
            //throw new NotImplementedException();
        }
    }
}
