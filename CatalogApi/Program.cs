using CatalogApi.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja usług
builder.Services.AddOpenApi();

var app = builder.Build();

// OpenAPI tylko w Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Rejestracja tras HTTP
RouteRegistration.Apply(app);

app.Run();

// Required for integration tests / WebApplicationFactory
public partial class Program { }