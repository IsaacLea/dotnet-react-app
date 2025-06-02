using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactApp1.Server.Models;
using System;
using System.Collections.Generic;

namespace ReactApp1.Server.EFConfig;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{

    public void Configure(EntityTypeBuilder<Address> entity)
    {

        entity.ToTable("address");

        entity.HasIndex(e => e.UserId, "IX_address_user_id");

        entity.Property(e => e.AddressId).HasColumnName("address_id");
        entity.Property(e => e.CountryCode).HasColumnName("country_code");
        entity.Property(e => e.Province).HasColumnName("province");
        entity.Property(e => e.Street).HasColumnName("street");
        entity.Property(e => e.UserId).HasColumnName("user_id");

        entity.HasOne(d => d.User).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_address_User_user_id");
    }

}
