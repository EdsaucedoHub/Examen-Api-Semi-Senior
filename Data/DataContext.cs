using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using WebAPIExamenEP.Models;

namespace WebAPIExamenEP.Data
{
    public class DataContext : DbContext
    { 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    
    }
}
