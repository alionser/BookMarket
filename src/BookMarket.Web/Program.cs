using Autofac.Extensions.DependencyInjection;

namespace BookMarket.Web;


public class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}