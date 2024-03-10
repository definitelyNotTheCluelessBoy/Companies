using Companies.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Companies.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(n => n.Title).IsRequired(false);
        }

        public DbSet<Employee> employees { get; set; }
    }
}
