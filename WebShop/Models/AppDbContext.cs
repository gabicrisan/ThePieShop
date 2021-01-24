using System;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Models
{
    public class AppDbContext : DbContext
    {
        // init o instanta de dbcontext options 
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        //setam ce trebuie managed de dbcontext 
        public DbSet<Pie> Pies { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
