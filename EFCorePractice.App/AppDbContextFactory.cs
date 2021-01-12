using EFCorePractice.App;
using EFCorePractice.Data;
using EFCorePractice.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EFCorePractice.App
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySQL(AppConfig.Configuration["connectionString"], b => b.MigrationsAssembly("EFCorePractice.App"))
                .UseLoggerFactory(CreateLoggerFactory);

            return new AppDbContext(builder.Options);
        }

        public static ILoggerFactory CreateLoggerFactory
            => LoggerFactory.Create(
                builder =>
                {
                    builder
                    .AddFilter("Microsoft", LogLevel.Information)
                    .AddFilter("System", LogLevel.Information)
                    .AddFilter("EFCorePractice", LogLevel.Information)
                    .AddConsole();
                });
    }
}
