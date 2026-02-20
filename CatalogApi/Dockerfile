FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY CatalogApi/*.csproj CatalogApi/
RUN dotnet restore CatalogApi/CatalogApi.csproj

COPY CatalogApi/ CatalogApi/
RUN dotnet publish CatalogApi/CatalogApi.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "CatalogApi.dll"]
