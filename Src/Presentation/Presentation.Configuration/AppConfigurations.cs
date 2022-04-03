using Application.Commands.Customers;
using Domain.Models.Contracts.DomainServices;
using Domain.Models.Customers;
using Framework.Application.Commands;
using Framework.Application.Services;
using Framework.Domain.Clock;
using Framework.Domain.Commands;
using Framework.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.SqlServer.DbContexts;
using Persistence.Commands.SqlServer.Repositories;
using Persistence.Queries.SqlServer.DbContexts;
using Persistence.Queries.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Configuration
{
    public static class AppConfigurations
    {
        public static void ConfigureApp(this IServiceCollection services, AppSettings appsettings)
        {
            services.Scan(s => s.FromAssemblies(typeof(RegisterCustomerCommand).Assembly)
               .AddClasses(c => c.AssignableToAny(typeof(ICommandHandler<>), typeof(ICommandHandler<,>)))
               .AsImplementedInterfaces()
               .WithScopedLifetime());

            services.AddTransient<ICommandBus, CommandBus>();
            services.Decorate<ICommandBus, CommandBusDomainExceptionHandlerDecorator>();
            services.Decorate<ICommandBus, CommandBusValidationDecorator>();

            services.AddDbContext<AppCommandDbContext>(builder =>
                    builder.UseSqlServer(appsettings.CommandsConnectionString));
            services.AddDbContext<AppQueryDbContext>(builder =>
                    builder.UseSqlServer(appsettings.QueriesConnectionString));

            services.Scan(s => s.FromAssemblies(typeof(CustomerCommandRepository).Assembly)
               .AddClasses(c => c.AssignableToAny(typeof(ICustomerCommandRepository)))
               .AsImplementedInterfaces()
               .WithTransientLifetime());

            services.Scan(s => s.FromAssemblies(typeof(ICustomerQueryRepository).Assembly)
               .AddClasses(c => c.AssignableToAny(typeof(CustomerQueryRepository)))
               .AsImplementedInterfaces()
               .WithTransientLifetime());

            services.AddScoped<ICustomerDomainService, CustomerDomainService>();

            services.AddScoped<IJsonSerializer, NewtonSoftSerializer>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            services.AddSingleton<IClock, UtcClock>();

        }
    }

    public class AppSettings
    {
        public string CommandsConnectionString { get; set; }
        public string QueriesConnectionString { get; set; }
    }
}
