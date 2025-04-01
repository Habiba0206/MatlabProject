# Use the ASP.NET base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/MatlabProject.Backend 

# Copy project files
COPY ["MatlabProject.Api/MatlabProject.Api.csproj", "MatlabProject.Api/"]
COPY ["MatlabProject.Application/MatlabProject.Application.csproj", "MatlabProject.Application/"]
COPY ["MatlabProject.Domain/MatlabProject.Domain.csproj", "MatlabProject.Domain/"]
COPY ["MatlabProject.Persistence/MatlabProject.Persistence.csproj", "MatlabProject.Persistence/"]
COPY ["MatlabProject.Infrastructure/MatlabProject.Infrastructure.csproj", "MatlabProject.Infrastructure/"]

# Restore the dependencies
RUN dotnet restore "MatlabProject.Api/MatlabProject.Api.csproj"

# Copy the rest of the application files
COPY . .

# Build the application
# Stay in the Backend directory
RUN dotnet build "MatlabProject.Api/MatlabProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "MatlabProject.Api/MatlabProject.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage for runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatlabProject.Api.dll"]
