namespace CatalogApi.Core;

/// <summary>
/// Udostępnia listę produktów zwracaną przez endpoint katalogu.
/// </summary>
internal static class ProductCatalogProvider
{
    public static object[] GetItems() => new object[]
    {
        new { id = 1, name = "Laptop" },
        new { id = 2, name = "Phone" }
    };
}
