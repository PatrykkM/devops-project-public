namespace CatalogApi.Core;

/// <summary>
/// Definiuje i rejestruje wszystkie endpointy HTTP aplikacji.
/// </summary>
internal static class RouteRegistration
{
    private static readonly string[] TemperatureLabels =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static void Apply(WebApplication app)
    {
        app.MapGet("/weatherforecast", ObtainForecast).WithName("GetWeatherForecast");
        app.MapGet("/", WelcomeMessage);
        app.MapGet("/products", ProductCatalog);
    }

    /// <summary>
    /// Zwraca listę prognoz pogody na najbliższe dni.
    /// </summary>
    private static ForecastEntry[] ObtainForecast()
    {
        var count = 5;
        var result = new List<ForecastEntry>(count);
        var idx = 0;
        while (idx < count)
        {
            idx++;
            var dayOffset = idx;
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(dayOffset));
            var temp = Random.Shared.Next(-20, 55);
            var labelIndex = Random.Shared.Next(TemperatureLabels.Length);
            result.Add(new ForecastEntry(date, temp, TemperatureLabels[labelIndex]));
        }
        return result.ToArray();
    }

    /// <summary>
    /// Komunikat powitalny zwracany pod ścieżką główną.
    /// </summary>
    private static string WelcomeMessage() => GreetingsProvider.DefaultMessage();

    /// <summary>
    /// Zwraca katalog produktów w formacie JSON.
    /// </summary>
    private static IResult ProductCatalog() =>
        Results.Json(ProductCatalogProvider.GetItems());
}
