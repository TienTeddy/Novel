using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.id_language);

            builder.Property(x => x.id_language).IsRequired().IsUnicode(false).HasMaxLength(5);

            builder.Property(x => x.name).IsRequired().HasMaxLength(20);
        }
    }
}
