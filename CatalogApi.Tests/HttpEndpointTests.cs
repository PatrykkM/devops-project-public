using Microsoft.AspNetCore.Mvc.Testing;

namespace CatalogApi.Tests;

/// <summary>
/// Testy integracyjne endpointów HTTP (ścieżka główna i katalog produktów).
/// </summary>
public sealed class HttpEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _http;

    public HttpEndpointTests(WebApplicationFactory<Program> factory)
    {
        _http = factory.CreateClient();
    }

    [Fact]
    public async Task StronaGlowna_ZwracaKomunikatPowitalny()
    {
        using var response = await _http.GetAsync("/");
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello DevOps!", body);
    }

    [Fact]
    public async Task KatalogProduktow_ZawieraOczekiwaneProduktyWJson()
    {
        using var response = await _http.GetAsync("/products");
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Laptop", body);
        Assert.Contains("Phone", body);
    }
}
