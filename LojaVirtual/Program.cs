using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            
            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .CreateLogger();

            var dataLog = DateTime.Now.ToShortDateString().Replace("/", "-");

           /*Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
           .Enrich.FromLogContext()
           .WriteTo.File(Directory.GetCurrentDirectory() + $"/Logs/{dataLog}-log.txt")
           .WriteTo.MySQL("Server=127.0.0.1; Port=3306; Database=loja; Username=HCTS; Password=HCTS+102030;")
           .CreateLogger();*/

            try
            {
                Log.Information("Servidor iniciado");
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