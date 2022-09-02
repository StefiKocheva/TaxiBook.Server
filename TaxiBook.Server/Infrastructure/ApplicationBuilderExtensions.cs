namespace TaxiBook.Server.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using TaxiBook.Server.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My TaxiBook API");
                    options.RoutePrefix = String.Empty;
                });

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<TaxiBookDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
