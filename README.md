# Catalog API

Aplikacja webowa w .NET 9 (ASP.NET Core Minimal API) z endpointem powitalnym, katalogiem produktów i prognozą pogody. Uruchamiana w Dockerze, z testami integracyjnymi i pipeline’em Azure DevOps.

---

## Endpointy

| Metoda | Ścieżka | Opis |
| :----- | :------ | :--- |
| GET | `/` | Tekst powitalny: `Hello DevOps!` |
| GET | `/products` | Lista produktów w JSON (Laptop, Phone) |
| GET | `/weatherforecast` | Prognoza pogody na 5 dni (JSON) |

---

## Wymagania

- **.NET SDK 9.x**
- **Docker Desktop** (przy uruchomieniu w kontenerze)
- PowerShell (Windows) lub terminal (Linux/macOS)

---

## Uruchomienie lokalne (bez Dockera)

```bash
cd CatalogApi
dotnet run
```

Aplikacja nasłuchuje na `http://localhost:80`.

---

## Uruchomienie w Dockerze

W katalogu głównym repozytorium:

```bash
docker build -f CatalogApi/Dockerfile -t catalogapi:latest .
docker run -d -p 5055:80 --name catalogapi-container catalogapi:latest
```

W przeglądarce:

- <http://localhost:5055/>
- <http://localhost:5055/products>
- <http://localhost:5055/weatherforecast>

Zatrzymanie kontenera:

```bash
docker stop catalogapi-container
```

---

## Testy

```bash
dotnet test CatalogApi.Tests/CatalogApi.Tests.csproj --logger "trx;LogFileName=test_results.trx"
```

---

## Struktura projektu

- **CatalogApi** — aplikacja (endpointy w `Core/`)
- **CatalogApi.Tests** — testy integracyjne (xUnit, `WebApplicationFactory`)
- **azure-pipelines.yml** — pipeline: build Dockera, testy, publikacja wyników
