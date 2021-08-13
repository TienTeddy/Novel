using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class QrCodeUserConfiguration : IEntityTypeConfiguration<QrCodeUser>
    {
        public void Configure(EntityTypeBuilder<QrCodeUser> builder)
        {
            builder.ToTable("QrCodeUser");
            builder.HasKey(x => x.id_qrcode);
            builder.Property(x => x.id_qrcode).UseIdentityColumn();
            builder.Property(x => x.create_date);
            builder.Property(x => x.display).IsRequired().HasMaxLength(200);
            builder.Property(x => x.qrcodeUri).IsRequired().IsUnicode(false);

            builder.HasOne(x => x.AppUser).WithOne(x => x.QrCodeUser).HasForeignKey<QrCodeUser>(x =>x.id_user);
        }
    }
}
