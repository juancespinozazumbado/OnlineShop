#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/RoleBasedAuth.Api/RoleBasedAuth.Api.csproj", "src/RoleBasedAuth.Api/"]
RUN dotnet restore "./src/RoleBasedAuth.Api/RoleBasedAuth.Api.csproj"
COPY . .
WORKDIR "/src/src/RoleBasedAuth.Api"
RUN dotnet build "./RoleBasedAuth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoleBasedAuth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoleBasedAuth.Api.dll"]