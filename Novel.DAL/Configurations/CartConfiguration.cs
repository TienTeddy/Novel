using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.id_cart);

            builder.Property(x => x.id_cart).UseIdentityColumn();

            builder.HasOne(x => x.Product).WithMany(x => x.Carts)
                .HasForeignKey(x => x.id_product);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Carts)
                .HasForeignKey(x => x.id_user);

            //throw new NotImplementedException();
        }
    }
}
