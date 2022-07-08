FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY CustomFeatureManager.sln CustomFeatureManager.sln
COPY CustomFeatureManager.Application/CustomFeatureManager.Application.csproj CustomFeatureManager.Application/CustomFeatureManager.Application.csproj
COPY CustomFeatureManager.Infrastructure/CustomFeatureManager.Infrastructure.csproj CustomFeatureManager.Infrastructure/CustomFeatureManager.Infrastructure.csproj
COPY CustomFeatureManager.WebApi/CustomFeatureManager.WebApi.csproj CustomFeatureManager.WebApi/CustomFeatureManager.WebApi.csproj
COPY CustomFeatureManager.WebApi/appsettings.json CustomFeatureManager.WebApi/appsettings.json
RUN dotnet restore

COPY . .

RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

RUN apt-get update && apt-get install -y curl=7.74.0-1.3+deb11u1 --no-install-recommends && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

RUN groupadd -g 10000 dotnet && useradd -u 10000 -g dotnet -m -d /app dotnet && chown -R dotnet:dotnet /app
USER dotnet:dotnet

ENV ASPNETCORE_URLS http://*:5226
EXPOSE 5226

ENTRYPOINT ["dotnet", "CustomFeatureManager.WebApi.dll"]