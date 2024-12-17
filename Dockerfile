FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Boonkrua.sln", "./"]
COPY ["Boonkrua.Api/Boonkrua.Api.csproj", "Boonkrua.Api/"]
COPY ["Boonkrua.Shared/Boonkrua.Shared.csproj", "Boonkrua.Shared/"]
COPY ["Boonkrua.Data/Boonkrua.Data.csproj", "Boonkrua.Data/"]
COPY ["Boonkrua.Services/Boonkrua.Service.csproj", "Boonkrua.Services/"]
COPY ["Boonkrua.IoC.Configuration/Boonkrua.IoC.Configuration.csproj", "Boonkrua.IoC.Configuration/"]


RUN dotnet restore

COPY ../ .

WORKDIR "/src/Boonkrua.Api"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Boonkrua.Api.dll"]
