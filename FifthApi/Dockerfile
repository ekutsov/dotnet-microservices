FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY FifthApi/FifthApi.csproj FifthApi/
RUN dotnet restore FifthApi/FifthApi.csproj
COPY . .
WORKDIR /src/FifthApi
RUN dotnet build FifthApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FifthApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FifthApi.dll"]