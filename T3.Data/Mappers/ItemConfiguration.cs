using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using T3.Core.Domain;

namespace T3.Data.Mappers
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            #region Table
            builder.ToTable("Item");
            #endregion

            #region Properties
            builder.HasKey("b => b.Id");
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(b => b.Info)
                .HasMaxLength(150);
            builder.Property(b => b.Amount)
                .IsRequired();
            builder.Property(b => b.Price);
            #endregion
        }
    }
}