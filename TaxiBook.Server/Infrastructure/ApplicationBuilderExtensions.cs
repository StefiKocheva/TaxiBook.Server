namespace TaxiBook.Server.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Server.Data;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<TaxiBookDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
