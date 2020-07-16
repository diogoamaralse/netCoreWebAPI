using Demo.API.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System;

namespace Demo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder
            .ConfigureNLog("nlog.config")
            .GetCurrentClassLogger();

            try
            {
                logger.Info("Initializing application...");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<CountryInfoContext>();

                        context.Database.EnsureDeleted();
                        context.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        logger.Error(e, "An error occurred while migration the database");
                    }
                }
                host.Run();

            }
            catch (Exception e)
            {
                logger.Error(e,"Application stopped because of exception error");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseNLog();
                });
    }
}
