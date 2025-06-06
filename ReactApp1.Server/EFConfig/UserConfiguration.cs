using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactApp1.Server.Models;
using System;
using System.Collections.Generic;

namespace ReactApp1.Server.EFConfig;

public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {

        //builder.HasKey(e => e.UserId).HasName("PK_=user");

        //builder.ToTable("user");

        //builder.Property(e => e.UserId).HasColumnName("user_id");
        //builder.Property(e => e.CreatedAt).HasColumnName("created_at");
        //builder.Property(e => e.Email).HasColumnName("email");
        //builder.Property(e => e.Name).HasColumnName("name");
    }

}
