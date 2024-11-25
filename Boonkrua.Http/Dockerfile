FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["../Boonkrua.sln", "./"]
COPY ["../Boonkrua.Http/Boonkrua.Http.csproj", "Boonkrua.Http/"]
COPY ["../Boonkrua.Common/Boonkrua.Common.csproj", "Boonkrua.Common/"]
COPY ["../Boonkrua.Data/Boonkrua.Data.csproj", "Boonkrua.Data/"]
COPY ["../Boonkrua.DataContracts/Boonkrua.DataContracts.csproj", "Boonkrua.DataContracts/"]
COPY ["../Boonkrua.Service/Boonkrua.Service.csproj", "Boonkrua.Service/"]

RUN dotnet restore

COPY ../ .

WORKDIR "/src/Boonkrua.Http"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Boonkrua.Http.dll"]
