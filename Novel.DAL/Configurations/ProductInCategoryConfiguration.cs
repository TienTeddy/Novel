using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new {t.id_category, t.id_product });

            builder.ToTable("ProductInCategories");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInCategories)
                .HasForeignKey(pc=>pc.id_product);

            builder.HasOne(t => t.Category).WithMany(pc => pc.ProductInCategories)
              .HasForeignKey(pc => pc.id_category);
        }
    }
}
