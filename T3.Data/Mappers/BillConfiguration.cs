using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using T3.Core.Domain;

namespace T3.Data.Mappers
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            #region Table
            builder.ToTable("Bill");
            #endregion

            #region Properties
            builder.HasKey("b => b.Id");
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Client)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Info)
                .HasMaxLength(150);
            builder.HasMany(b => b.Items)
                .WithOne()
                .IsRequired();
            #endregion
        }
    }
}