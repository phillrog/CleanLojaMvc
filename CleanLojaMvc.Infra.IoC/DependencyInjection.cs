using CleanLojaMvc.Application.Insterfaces;
using CleanLojaMvc.Application.Mappings;
using CleanLojaMvc.Application.Services;
using CleanLojaMvc.Domain.Interfaces;
using CleanLojaMvc.Infra.Data.Context;
using CleanLojaMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanLojaMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("CleanLojaMvc.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
