using CatalogApi.Core;

var host = WebApplication.CreateBuilder(args);
host.Services.AddOpenApi();

var webHost = host.Build();

if (webHost.Environment.IsDevelopment())
{
    webHost.MapOpenApi();
}

webHost.UseHttpsRedirection();

// Rejestracja tras HTTP
RouteRegistration.Apply(webHost);

webHost.Urls.Clear();
webHost.Urls.Add("http://0.0.0.0:80");

webHost.Run();

public partial class Program { }
