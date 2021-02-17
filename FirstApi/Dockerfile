FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY FirstApi/FirstApi.csproj FirstApi/
RUN dotnet restore FirstApi/FirstApi.csproj
COPY . .
WORKDIR /src/FirstApi
RUN dotnet build FirstApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FirstApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FirstApi.dll"]