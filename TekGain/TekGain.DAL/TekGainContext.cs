using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TekGain.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore.Design;

namespace TekGain.DAL
{
    public class TekGainContext : IdentityDbContext<User>
    {
        public TekGainContext(DbContextOptions<TekGainContext> options) : base(options)
        {


        }

        // Implement the DbSet properties here
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TekGainContext>
    {
        public TekGainContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../TekGain.DAL/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TekGainContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new TekGainContext(builder.Options);
        }
    }
}
