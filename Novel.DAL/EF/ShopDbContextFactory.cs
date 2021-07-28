using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Novel.DAL.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Novel.Data.EF
{
    public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ShopDbContext");

            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShopDbContext(optionsBuilder.Options);
        }
    }
}
