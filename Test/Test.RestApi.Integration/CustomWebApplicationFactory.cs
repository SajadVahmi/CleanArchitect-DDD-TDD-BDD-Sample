using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Commands.SqlServer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RestApi.Integration.Common.DbConnections;


namespace Test.RestApi.Integration
{
    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup>, IDisposable where TStartup : class
    {
        private ServiceProvider serviceProvider;
        protected override IHostBuilder CreateHostBuilder()
        {

            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<TStartup>().UseTestServer();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {


                });
            return builder;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                serviceProvider = services.BuildServiceProvider();

                var descriptor = services.SingleOrDefault(
                 d => d.ServiceType ==
                     typeof(DbContextOptions<AppCommandDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<AppCommandDbContext>(options =>
                {
                    options.UseSqlServer(DbTestConnections.COMMAND_DBCONTEXT);
                });


                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppCommandDbContext>();

                    db.Database.EnsureCreated();
                    db.Customers.RemoveRange(db.Customers);
                    db.SaveChanges();

                }

            });
        }

       

        public override ValueTask DisposeAsync()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppCommandDbContext>();

                db.Database.EnsureDeleted();
            }

            return base.DisposeAsync();
        }
    }
}
