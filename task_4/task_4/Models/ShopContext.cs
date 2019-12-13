using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_4.Models.Entities;

namespace task_4.Models
{
    public class ShopContext : DbContext
    {
        public  DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
