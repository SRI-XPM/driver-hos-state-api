# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Base image used in final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Stage to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy only the .csproj and restore
COPY src/driver-hos-state-api/driver-hos-state-api.csproj src/driver-hos-state-api/
RUN dotnet restore src/driver-hos-state-api/driver-hos-state-api.csproj

# Copy everything else
COPY . .

# Build the project
WORKDIR /src/src/driver-hos-state-api
RUN dotnet build driver-hos-state-api.csproj -c $BUILD_CONFIGURATION -o /app/build

# Stage to publish the project
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish driver-hos-state-api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "driver-hos-state-api.dll"]
