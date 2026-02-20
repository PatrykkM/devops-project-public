namespace CatalogApi.Core;

/// <summary>
/// Jedna wpis prognozy pogody: data, temperatura w C i krótki opis.
/// </summary>
internal record ForecastEntry(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
