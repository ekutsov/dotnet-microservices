FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY SecondApi/SecondApi.csproj SecondApi/
RUN dotnet restore SecondApi/SecondApi.csproj
COPY . .
WORKDIR /src/SecondApi
RUN dotnet build SecondApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SecondApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SecondApi.dll"]