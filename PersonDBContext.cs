using System;
using Microsoft.EntityFrameworkCore;

namespace APITest
{
    public class PersonDbContext : DbContext
    {
        //public DbSet<Person> Persons { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        //public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:localhost,57000;Database=dev_testdb1;User ID=SA;Password=Password123!;Trusted_Connection=False;Encrypt=False;");
        }
    }
}

