using Microsoft.EntityFrameworkCore;
using System;
using T3.Core.Domain;
using T3.Data.Mappers;

namespace T3.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Properties
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion

        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            // Bill ManyToMany Employee
            modelBuilder.Entity<BillEmployee>()
                .HasKey(b => new { b.BillId, b.EmployeeId });

            modelBuilder.Entity<BillEmployee>()
                .HasOne(be => be.Bill)
                .WithMany(b => b.BillEmployees)
                .HasForeignKey(be => be.BillId);

            modelBuilder.Entity<BillEmployee>()
                .HasOne(be => be.Employee)
                .WithMany(e => e.BillEmployees)
                .HasForeignKey(be => be.EmployeeId);
        }
        #endregion
    }
}