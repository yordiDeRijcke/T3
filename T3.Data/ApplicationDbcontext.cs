using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using T3.Core.Domain;
using T3.Data.Mappers;

namespace T3.Data
{
    public class ApplicationDbContext : IdentityDbContext
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
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            // Bill ManyToMany Employee
            modelBuilder.Entity<BillEmployee>()
                .HasKey(b => new { b.BillId, b.EmployeeId });

            modelBuilder.Entity<BillEmployee>()
                .HasOne(be => be.Bill)
                .WithMany(b => b.BillEmployees)
                .HasForeignKey(be => be.BillId);

            modelBuilder.Entity<BillEmployee>()
                .HasOne(be => be.Employee)
                .WithMany()
                .HasForeignKey(be => be.EmployeeId);
        }
        #endregion
    }
}