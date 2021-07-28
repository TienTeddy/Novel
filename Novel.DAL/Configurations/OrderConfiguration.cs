using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.Property(x => x.order_date);

            builder.Property(x => x.ship_email).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.ship_address).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ship_name).IsRequired().HasMaxLength(200);


            builder.Property(x => x.ship_phoneNumber).IsRequired().HasMaxLength(200);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.id_user);

        }
    }
}
