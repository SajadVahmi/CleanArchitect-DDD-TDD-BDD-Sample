using Application.Contracts.Customers.Commands;
using Application.Customers;
using Domain.Models.Customers;
using Framework.Application.Commands;
using Framework.Application.Queries;
using Framework.Application.Services;
using Framework.Domain.Clock;
using Framework.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Commands.SqlServer.DbContexts;
using Persistence.Commands.SqlServer.Repositories;
using Persistence.Queries.SqlServer.DbContexts;
using Persistence.Queries.SqlServer.QueryHandlers;
using Presentation.Facade.Customers;
using ICustomerRepository = Domain.Models.Customers.ICustomerRepository;

namespace Presentation.Configuration
{
    public static class AppConfigurations
    {
        public static void ConfigureApp(this IServiceCollection services, AppSettings appsettings)
        {
            services.Scan(s => s.FromAssemblies(typeof(RegisterCustomerCommandHandler).Assembly)
               .AddClasses(c => c.AssignableToAny(typeof(ICommandHandler<>), typeof(ICommandHandler<,>)))
               .AsImplementedInterfaces()
               .WithScopedLifetime());

            services.AddTransient<ICommandBus, CommandBus>();
            services.Decorate<ICommandBus, CommandBusValidationDecorator>();
            services.Decorate<ICommandBus, CommandBusDomainExceptionHandlerDecorator>();

            services.Scan(s => s.FromAssemblies(typeof(CustomerQueryHandler).Assembly)
              .AddClasses(c => c.AssignableToAny(typeof(IQueryHandler<,>)))
              .AsImplementedInterfaces()
              .WithScopedLifetime());

            services.AddDbContext<AppCommandDbContext>(builder =>
                    builder.UseSqlServer(appsettings.CommandsConnectionString));
            services.AddDbContext<AppQueryDbContext>(builder =>
                    builder.UseSqlServer(appsettings.QueriesConnectionString));

            services.Scan(s => s.FromAssemblies(typeof(CustomerRepository).Assembly)
               .AddClasses(c => c.AssignableToAny(typeof(ICustomerRepository)))
               .AsImplementedInterfaces()
               .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(typeof(CustomerFacade).Assembly)
              .AddClasses(c => c.AssignableToAny(typeof(ICustomerFacade)))
              .AsImplementedInterfaces()
              .WithScopedLifetime());



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
