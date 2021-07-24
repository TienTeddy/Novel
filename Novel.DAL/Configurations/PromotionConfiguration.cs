﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using Novel.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");

            builder.HasKey(x => x.id_promotion);
            builder.Property(x => x.id_promotion).UseIdentityColumn(); //sắp xếp theo thứ tự

            builder.Property(x => x.name).IsRequired(true);
            ///throw new NotImplementedException();
        }
    }
}
