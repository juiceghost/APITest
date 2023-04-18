using System;
using Microsoft.EntityFrameworkCore;

namespace APITest
{
    public class RepositoryContext : DbContext
    {
        //public DbSet<Person> Persons { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        //public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // REMOTE:
            // optionsBuilder.UseSqlServer("Server=tcp:dev.kjeldcon.se;Database=dev_testdb1;User ID=SA;Password=Password123!;Trusted_Connection=False;Encrypt=False;");
            // LOCAL:
            optionsBuilder.UseSqlServer("Server=tcp:localhost,57000;Database=dev_testdb1;User ID=SA;Password=Password123!;Trusted_Connection=False;Encrypt=False;");
        }
    }
}

