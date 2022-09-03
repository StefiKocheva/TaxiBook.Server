namespace TaxiBook.Server.Infrastructure.Extensions
{
    public static class ConfigurationSettings
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
