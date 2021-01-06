using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.IO;

namespace LojaVirtual
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataLog = DateTime.Now.ToShortDateString().Replace("/", "-");

            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
           .Enrich.FromLogContext()
           .WriteTo.File(Directory.GetCurrentDirectory() + $"/Logs/{dataLog}-log.txt")
           .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Servidor encerrado inesperadamente");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseSerilog();
    }
}
