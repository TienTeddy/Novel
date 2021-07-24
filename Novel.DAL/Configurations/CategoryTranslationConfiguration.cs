using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslations");

            builder.HasKey(x => x.id_category_translation);

            builder.Property(x => x.id_category_translation).UseIdentityColumn();


            builder.Property(x => x.name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.seo_alias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.seo_description).HasMaxLength(500);

            builder.Property(x => x.seo_title).HasMaxLength(200);

            builder.Property(x => x.id_language).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.id_language);

            builder.HasOne(x => x.Category).WithMany(x => x.CategoryTranslations).HasForeignKey(x => x.id_category);
        }
    }
}
