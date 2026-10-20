using Microsoft.EntityFrameworkCore;
using BankAssignment.Models;

namespace BankAssignment.Data
{
    public class BankDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BankAssignmentDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountNumber)
                .UseIdentityColumn(1000, 1);
        }
    }
}