using System.Reflection;
using Contracts.Interfaces;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc.Versioning;
using Persistence;
using Services;
using Services.Contracts.Interfaces;

namespace ITMasters.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureFluentMigrator(this IServiceCollection services, IConfiguration configuration) =>
        services.AddLogging(c =>
                c.AddFluentMigratorConsole())
            .AddFluentMigratorCore().ConfigureRunner(c =>
                c.AddSqlServer2016().WithGlobalConnectionString(configuration.GetConnectionString("sqlconnection"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureApiVersion(this IServiceCollection services) =>
        services.AddApiVersioning(v =>
        {
            v.DefaultApiVersion = new ApiVersion(1, 0);
            v.AssumeDefaultVersionWhenUnspecified = true;
            v.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
}