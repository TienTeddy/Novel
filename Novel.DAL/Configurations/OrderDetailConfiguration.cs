using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails)
                .HasForeignKey(x=>x.id_order);

            builder.HasOne(x => x.Product).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.id_product);
            //throw new NotImplementedException();
        }
    }
}
