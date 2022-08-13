using Autofac;
using BookMarket.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookMarket.Web;

public class Startup
{
    public IConfiguration Configuration;


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Transient);
        
        services.AddControllersWithViews();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType(typeof(DataContext))
            .As<DataContext>()
            .InstancePerLifetimeScope();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        
        app.UseEndpoints(routeBuilder =>
        {
            routeBuilder.MapControllers();
        });
        
        var dataContext = app.ApplicationServices.GetRequiredService<DataContext>();
        dataContext.Database.Migrate();
    }
}