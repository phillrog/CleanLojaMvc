using CleanLojaMvc.Application.Insterfaces;
using CleanLojaMvc.Application.Mappings;
using CleanLojaMvc.Application.Services;
using CleanLojaMvc.Domain.Account;
using CleanLojaMvc.Domain.Interfaces;
using CleanLojaMvc.Infra.Data.Context;
using CleanLojaMvc.Infra.Data.Identity;
using CleanLojaMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanLojaMvc.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var handlers = AppDomain.CurrentDomain.Load("CleanLojaMvc.Application");
            services.AddMediatR(handlers);

            var sp = services.BuildServiceProvider();
            var seed = (ISeedUserRoleInitial)sp.GetService(typeof(ISeedUserRoleInitial));
            seed.SeedRoles();
            seed.SeedUsers();

            return services;
        }
    }
}
