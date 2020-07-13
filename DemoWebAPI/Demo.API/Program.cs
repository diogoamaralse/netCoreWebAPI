using Microsoft.AspNetCore.Hosting;
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
                CreateHostBuilder(args).Build().Run();

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
