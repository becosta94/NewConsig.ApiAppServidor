# NewConsig.ApiAppServidor

API .NET 8 em camadas com EF Core SQL Server e seleção dinâmica de banco por requisição (X-Database ou ?db=).

## Build e Run
dotnet restore
dotnet build
dotnet run --project src/NewConsig.ApiAppServidor.Api

## Migrations
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial -p src/NewConsig.ApiAppServidor.Infrastructure -s src/NewConsig.ApiAppServidor.Api
dotnet ef database update -p src/NewConsig.ApiAppServidor.Infrastructure -s src/NewConsig.ApiAppServidor.Api
