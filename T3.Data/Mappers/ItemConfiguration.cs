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
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(i => i.Info)
                .HasMaxLength(150);
            builder.Property(i => i.Amount)
                .IsRequired();
            builder.Property(i => i.Price);
            #endregion
        }
    }
}