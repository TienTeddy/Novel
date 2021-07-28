using Novel.DAL.Entities;
using Novel.DAL.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.id_category);

            builder.Property(x => x.id_category).UseIdentityColumn();


            builder.Property(x => x.status).HasDefaultValue(Status.Active);
        }
    }
}
