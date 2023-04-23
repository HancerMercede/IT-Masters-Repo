
using FluentMigrator.Runner;
using ITMasters.Api.Migrations;

namespace ITMasters.Api.Extensions;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using(var scope = app.Services.CreateScope())
        {
            var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            try
            {
               databaseService.CreateDatabase("ITMastersdb");
               migrationService.ListMigrations();
               migrationService.MigrateUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something happens during db creation: {ex.Message}" );
                throw;
            }
        }

        return app;
    }
}