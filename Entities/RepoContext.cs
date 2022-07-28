using Entities.Configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepoContext : IdentityDbContext<User> // New for JWT
    {
        public RepoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // New for JWT

            //builder.ApplyConfiguration(new CompanyConfig());
            //builder.ApplyConfiguration(new EmployeeConfig());
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Investment>().HasKey(i => new { i.SponsorId, i.ProjectId });
        }
        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Investment> Investments { get; set; }
    }
}

