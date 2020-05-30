using ManyToMany.System.Core.Application.Common.Interfaces;
using ManyToMany.System.Infrastructure.Persistence;
using ManyToMany.System.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManyToMany.System.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<INotificationService, NotificationService>();

            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryContext")));

            services.AddScoped<ILibraryContext>(provider => provider.GetService<LibraryContext>());

            return services;
        }
    }
}