using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.id_productTranslation);
            builder.Property(x => x.id_productTranslation).UseIdentityColumn();

            builder.Property(x => x.name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.seo_alias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.details).HasMaxLength(500);


            builder.Property(x => x.id_language).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.id_language);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductTranslations).HasForeignKey(x => x.id_product);

        }
    }
}
