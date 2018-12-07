using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using T3.Core.Domain;

namespace T3.Data.Mappers
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Table
            builder.ToTable("Employee");
            #endregion

            #region Properties
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion
        }
    }
}