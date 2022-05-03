using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Digimon> Digimon { get; set; }

    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../MVCDigimon/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("ApplicationDbContext");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }

    }
}
