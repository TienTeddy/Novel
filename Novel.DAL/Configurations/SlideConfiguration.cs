using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.id_slide);

            builder.Property(x => x.id_slide).UseIdentityColumn();

            builder.Property(x => x.name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.url).HasMaxLength(200).IsRequired();

            builder.Property(x => x.image).HasMaxLength(200).IsRequired();
        }
    }
}