// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockAndBuy.Data;
using StockAndBuy.Data.Repositories;
using StockAndBuy.Service.Implementation;
using StockAndBuy.Service.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var bundleService = services.GetRequiredService<IBundleService>();

                Console.WriteLine($"===================================================================");
                Console.WriteLine($"Total number of bicycles buildable = {await bundleService.MaximumNumberOfFinishedBundle(Guid.Parse("6128354f-2e07-4063-901a-b60c02930e6e"))}");
                Console.WriteLine($"===================================================================");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write( ex.ToString() );
            }
        }

        host.Run();
    }


    static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               string connectionString = "Server=localhost;Database=stockandbuy;User=root;Password=123456;";

               services.AddDbContext<StockAndBuyDbContext>(options =>
               {
                   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                   options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
                   options.EnableSensitiveDataLogging();
                   options.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
               });

               services.AddTransient<IBundleRepository, BundleRepository>(); // Add your services
               services.AddTransient<ISparePartRepository, SparePartRepository>(); // Add your services
               services.AddTransient<IBundleService, BundleService>(); // Add your services
           });
}

