FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ThirdApi/ThirdApi.csproj ThirdApi/
RUN dotnet restore ThirdApi/ThirdApi.csproj
COPY . .
WORKDIR /src/ThirdApi
RUN dotnet build ThirdApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ThirdApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ThirdApi.dll"]