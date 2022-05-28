using BE.Infrastructure;
using BE.Infrastructure.Bussiness;
using BE.Infrastructure.Contracts;
using BE.Infrastructure.Data;
using BE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BE.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultDatabase");
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clothing Store API",
                    Description = "Backend API for Clothing Store project",

                });
            });
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IDatabaseFactory<>), typeof(DatabaseFactory<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
