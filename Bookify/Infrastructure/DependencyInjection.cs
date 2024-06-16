using Application.Abstracts.Clock;
using Application.Abstracts.Email;
using Domain.Abstracts;
using Domain.Apartments;
using Domain.Bookings;
using Domain.Users;
using Infrastructure.Clock;
using Infrastructure.Email;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            services.AddTransient<IEmailService, EmailService>();

            var connectionString =
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IbookingRepository, BookingRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
