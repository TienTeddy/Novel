using Novel.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novel.DAL.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.id_contact);

            builder.Property(x => x.id_contact).UseIdentityColumn();

            builder.Property(x => x.name).HasMaxLength(200).IsRequired();

            builder.Property(x => x.email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.phone_number).HasMaxLength(200).IsRequired();
            builder.Property(x => x.message).IsRequired();


        }
    }
}
