using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Registration.Persistance;
using System.Reflection;


namespace Registration.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence (this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("data source=localhost\\sqlexpress; initial catalog=RegistrationFormDb; " +
            "integrated security=SSPI; TrustServerCertificate=True;"));

            return services;
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.Load("Registration.Application");

            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
