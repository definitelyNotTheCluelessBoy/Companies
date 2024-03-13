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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    { 
                        Id = 1,
                        FirstName = "Jano",
                        LastName = "Novák",
                        Email = "janonovak@email.com",
                        Phone = "+421999888777",
                        Title = null
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Peter",
                        LastName = "Malí",
                        Email = "petermali@email.com",
                        Phone = "+421999888666",
                        Title = "Mgr."
                    },
                    new Employee
                    {
                        Id = 3,
                        FirstName = "František",
                        LastName = "Stromokocur",
                        Email = "frantisekstromkoc@email.com",
                        Phone = "+421999888555",
                        Title = "Ing."
                    },
                    new Employee
                    {
                        Id = 4,
                        FirstName = "Jaroslav",
                        LastName = "Pecka",
                        Email = "jaropecka@email.com",
                        Phone = "+421999222777",
                        Title = null
                    },
                    new Employee
                    {
                        Id = 5,
                        FirstName = "Iveta",
                        LastName = "Fialova",
                        Email = "ivkafialka@email.com",
                        Phone = "+421888888777",
                        Title = "Doc."
                    },
                    new Employee
                    {
                        Id = 6,
                        FirstName = "Janko",
                        LastName = "Hrasko",
                        Email = "hrasko.janko@email.com",
                        Phone = "+421999888677",
                        Title = null
                    }, 
                    new Employee
                    {
                        Id = 7,
                        FirstName = "James",
                        LastName = "Bond",
                        Email = "topsecret@misix.com",
                        Phone = "+421000000007",
                        Title = null
                    },
                    new Employee
                    {
                        Id = 8,
                        FirstName = "Jhon",
                        LastName = "Doe",
                        Email = "unknown@mistery.com",
                        Phone = "+421000000000",
                        Title = "Magician"
                    }
                );
            modelBuilder.Entity<Company>().HasData(
                    new Company
                    {
                        IdCode = "001",
                        DirectorOfNodeId = 1,
                        DirectorOfNode = null,
                        Name = "First Company",

                    },
                    new Company
                    {
                        IdCode = "002",
                        DirectorOfNodeId = 2,
                        DirectorOfNode = null,
                        Name = "First Company",

                    }
                );

            modelBuilder.Entity<Division>().HasData(
                    new Division
                    {
                        IdCode = "001",
                        DirectorOfNodeId = 3,
                        DirectorOfNode = null,
                        Name = "First division",
                        MotherCompanyId = "001",
                        MotherCompany = null

                    },
                    new Division
                    {
                        IdCode = "002",
                        DirectorOfNodeId = 4,
                        DirectorOfNode = null,
                        Name = "Second division",
                        MotherCompanyId = "002",
                        MotherCompany = null
                    }
                );
            modelBuilder.Entity<Project>().HasData(
                    new Project
                    {
                        IdCode = "001",
                        DirectorOfNodeId = 5,
                        DirectorOfNode = null,
                        Name = "First project",
                        MotherDivisionId = "001",
                        MotherDivision = null

                    },
                    new Project
                    {
                        IdCode = "002",
                        DirectorOfNodeId = 6,
                        DirectorOfNode = null,
                        Name = "Second project",
                        MotherDivisionId = "002",
                        MotherDivision = null
                    }
                );
            modelBuilder.Entity<Department>().HasData(
                    new Department
                    {
                        IdCode = "001",
                        DirectorOfNodeId = 7,
                        DirectorOfNode = null,
                        Name = "First Department",
                        MotherProjectId = "001",
                        MotherProject = null

                    },
                    new Department
                    {
                        IdCode = "002",
                        DirectorOfNodeId = 8,
                        DirectorOfNode = null,
                        Name = "Second Department",
                        MotherProjectId = "002",
                        MotherProject = null
                    }
                );
        }
    }
}
