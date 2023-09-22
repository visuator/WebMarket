#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Applications/WebMarketDelivery/WebMarketDelivery.csproj", "Applications/WebMarketDelivery/"]
RUN dotnet restore "Applications/WebMarketDelivery/WebMarketDelivery.csproj"
COPY . .
WORKDIR "/src/Applications/WebMarketDelivery"
RUN dotnet build "WebMarketDelivery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMarketDelivery.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMarketDelivery.dll"]