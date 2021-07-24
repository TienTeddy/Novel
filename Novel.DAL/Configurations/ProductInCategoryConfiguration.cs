using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategory");

            builder.HasKey(x => new { x.id_category, x.id_product });

            builder.HasOne(p => p.Product).WithMany(pic => pic.ProductInCategories)
                .HasForeignKey(pic=>pic.id_product);

            builder.HasOne(c => c.Category).WithMany(pic => pic.ProductInCategories)
                .HasForeignKey(pic=>pic.id_category);
            //throw new NotImplementedException();
        }
    }
}
