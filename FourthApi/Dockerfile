FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY FourthApi/FourthApi.csproj FourthApi/
RUN dotnet restore FourthApi/FourthApi.csproj
COPY . .
WORKDIR /src/FourthApi
RUN dotnet build FourthApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FourthApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FourthApi.dll"]