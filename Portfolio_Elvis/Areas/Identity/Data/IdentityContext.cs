using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Portfolio_Elvis.Models
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<IdentityContext>
        {
            IdentityContext IDesignTimeDbContextFactory<IdentityContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
                optionsBuilder.UseSqlServer<IdentityContext>("Server=(localdb)\\mssqllocaldb;Database=Portfolio_Elvis2;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new IdentityContext(optionsBuilder.Options);
            }
        }
    }
}
