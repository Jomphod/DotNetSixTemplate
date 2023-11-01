using Core.Interfaces.Infra.Database;
using Core.Interfaces.Infra.Email;
using Core.Interfaces.Infra.Helpers;
using Core.Interfaces.Infra.ServiceLifetimes;
using Core.Interfaces.Services;
using Infra.Database;
using Infra.Database.Helpers;
using Infra.Database.Repositories;
using Infra.Email;
using Infra.ServiceLifetimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infra;

public static class ServicesExtensions
{
    public static void RegisterLifeTimeServicesExtensions(this IServiceCollection services)
    {
        AddTransientLifeTimeServices(services);
        AddScopedtLifeTimeServices(services);
        AddSingletonLifeTimeServices(services);
    }
    public static void AddTransientLifeTimeServices(this IServiceCollection services)
    {
        services.AddTransient<ITransientService, TransientService>();
        services.AddTransient<ITokenService, TokenService>();
        // builder.Services.AddTransient<IEmailProvider, SendgridEmailProvider>();
        services.AddTransient<IEmailProvider, MailGunEmailProvider>();
    }
    public static void AddScopedtLifeTimeServices(this IServiceCollection services)
    {
        services.AddScoped<IScopedService, ScopedService>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<IProvinceService, ProvinceService>();
        services.AddScoped<IDBHelper, DBHelper>();
    }
    public static void AddSingletonLifeTimeServices(this IServiceCollection services)
    {
        services.AddSingleton<ISingletonService, SingletonService>();
    }
    public static void AddDBHelper(this IServiceCollection services) =>
        services.AddScoped<IDBHelper, DBHelper>();
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
    services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")));
}
