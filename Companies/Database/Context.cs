using Companies.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Companies.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}

        

        public DbSet<Employee> employees { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Division> divisions { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
