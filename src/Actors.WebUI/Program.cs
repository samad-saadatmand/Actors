using Actors.Application;
using Actors.Infrastructure;
using Actors.Infrastructure.Persistence;
using Actors.WebUI.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();

await app.Services.SeedDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "IRanger");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCustomErrorHandlerMiddleware();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
