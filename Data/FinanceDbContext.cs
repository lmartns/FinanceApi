using FinanceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Data
{
    public class FinanceDbContext(DbContextOptions<FinanceDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
