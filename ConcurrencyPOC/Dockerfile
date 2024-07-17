FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConcurrencyPOC/ConcurrencyPOC.csproj", "ConcurrencyPOC/"]
RUN dotnet restore "ConcurrencyPOC/ConcurrencyPOC.csproj"
COPY . .
WORKDIR "/src/ConcurrencyPOC"
RUN dotnet build "ConcurrencyPOC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConcurrencyPOC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConcurrencyPOC.dll"]
