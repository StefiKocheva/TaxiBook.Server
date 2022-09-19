namespace TaxiBook.Server.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using TaxiBook.Server.Data.Models;
    using TaxiBook.Server.Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;
    using TaxiBook.Server.Features.Identity;
    using TaxiBook.Server.Features.Companies;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using TaxiBook.Server.Infrastructure.Filters;
    using TaxiBook.Server.Infrastructure.Services;

    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var appliCationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(appliCationSettingsConfiguration);
            return appliCationSettingsConfiguration.Get<AppSettings>();
        }
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<TaxiBookDbContext>(options => options
                    .UseSqlServer(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<TaxiBookDbContext>();

            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddTransient<IIdentityService, IdentityService>()
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<ICompanyService, CompanyService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "My TaxiBook API",
                        Version = "v1"
                    });
            });

        public static void AddApiControllers(this IServiceCollection services)
            => services
                .AddControllers(options => options
                    .Filters.Add<ModelOrNotFoundActionFilter>());
    }
}
