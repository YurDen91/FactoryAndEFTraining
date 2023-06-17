FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FactoryAndEFRaining/FactoryAndEFRaining.csproj", "FactoryAndEFRaining/"]
RUN dotnet restore "FactoryAndEFRaining/FactoryAndEFRaining.csproj"
COPY . .
WORKDIR "/src/FactoryAndEFRaining"
RUN dotnet build "FactoryAndEFRaining.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FactoryAndEFRaining.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FactoryAndEFRaining.dll"]
