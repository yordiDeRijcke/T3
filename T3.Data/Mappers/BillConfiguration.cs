using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Client)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(b => b.Info)
                .HasMaxLength(150);
            builder.HasMany(b => b.Items)
                .WithOne()
                .HasForeignKey(i => i.BillId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            #endregion
        }
    }
}