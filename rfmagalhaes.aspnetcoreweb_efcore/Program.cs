using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using rfmagalhaes.aspnetcoreweb_efcore.infra.data;
using rfmagalhaes.aspnetcoreweb_efcore.Infra;

namespace rfmagalhaes.aspnetcoreweb_efcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.MigrateDbContext<TesteContext>((context, services) =>
            {
                var env = services.GetService<IHostingEnvironment>();

                new TesteContextSeed()
                .SeedAsync(context, env)
                .Wait();

            }).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }

    public static class WebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                context.Database.Migrate();
                seeder(context, services);
            }

            return webHost;
        }
    }

}
