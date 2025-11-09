# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["BaDongTourismWebsite.csproj", "./"]
RUN dotnet restore "BaDongTourismWebsite.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "BaDongTourismWebsite.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "BaDongTourismWebsite.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 5000

# Copy published app
COPY --from=publish /app/publish .

# Set entry point
ENTRYPOINT ["dotnet", "BaDongTourismWebsite.dll"]
