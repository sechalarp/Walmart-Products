FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 8787

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Walmart.SIEP.Productos.csproj", ""]
RUN dotnet restore "./Walmart.SIEP.Productos.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Walmart.SIEP.Productos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Walmart.SIEP.Productos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Walmart.SIEP.Productos.dll"]