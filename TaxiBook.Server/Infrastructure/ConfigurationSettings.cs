namespace TaxiBook.Server.Infrastructure
{
    public static class ConfigurationSettings
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
