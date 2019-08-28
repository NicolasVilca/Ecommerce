using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace apifinal.Models
{
    public class ABMContext : DbContext
    {
        public ABMContext(DbContextOptions<ABMContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId {get; set;}
        public Category Categories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Product> Products {get; set;} 
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; } 
        public string Email { get; set; }
    }
}