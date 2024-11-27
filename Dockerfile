#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

#RUN apt-get update

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CastraBus.Api/CastraBus.Api.csproj", "CastraBus.Api/"]
COPY ["CastraBus.Infra.IoC/CastraBus.Infra.IoC.csproj", "CastraBus.Infra.IoC/"]
COPY ["CastraBus.Application/CastraBus.Application.csproj", "CastraBus.Application/"]
COPY ["CastraBus.Infra.Data/CastraBus.Infra.Data.csproj", "CastraBus.Infra.Data/"]
COPY ["CastraBus.Common/CastraBus.Common.csproj", "CastraBus.Common/"]
RUN dotnet restore "CastraBus.Api/CastraBus.Api.csproj"
COPY . .
WORKDIR "/src/CastraBus.Api"
RUN dotnet build "./CastraBus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CastraBus.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CastraBus.Api.dll"]