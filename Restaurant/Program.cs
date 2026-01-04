using Microsoft.OpenApi.Models;
using Restaurant.API.Extensions;
using Restaurant.API.Middlewares;
using Restaurant.Application.Extensions;
using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Extensions;
using Restaurant.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();


 
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();


try
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}
catch (Exception ex)
{
    Log.Error(ex, "Error during database seeding");
}


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API v1");
    options.RoutePrefix = string.Empty; 
});


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();
    
app.MapGroup("api/identity").MapIdentityApi<User>();
 
app.MapControllers();

app.Run();