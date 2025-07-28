# Use the base image for the final container with ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

# Build stage with SDK to restore and build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY src/driver-hos-state-api/driver-hos-state-api.csproj src/driver-hos-state-api/
RUN dotnet restore src/driver-hos-state-api/driver-hos-state-api.csproj

# Copy the rest of the source code
COPY . .

# Build the project
WORKDIR /src/src/driver-hos-state-api
RUN dotnet build driver-hos-state-api.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish the project in the next stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish driver-hos-state-api.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: use the base image and copy the published files
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 
ENTRYPOINT ["dotnet", "driver-hos-state-api.dll"]
