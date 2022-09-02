using TaxiBook.Server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseSwaggerUI()
    .UseRouting()
    .UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    })
    .ApplyMigrations();

app.Run();
