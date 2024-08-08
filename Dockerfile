# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the solution and project files
COPY ["Wolf.sln", "./"]
COPY ["WolfAPI/WolfAPI.csproj", "WolfAPI/"]
COPY ["DataLayer/DataAccessLayer.csproj", "DataLayer/"]
COPY ["UserManagamentService/UserManagamentService.csproj", "UserManagamentService/"]
COPY ["DTOS/DTOS.csproj", "DTOS/"]
RUN dotnet restore "WolfAPI/WolfAPI.csproj"

# Copy the rest of the application files
COPY . .

# Build the WebAPI project
WORKDIR "/src/WolfAPI"
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Copy the certificate files
COPY ["certs/cert.pfx", "certs/cert.pfx"]

# Set the entry point to run the WebAPI
ENTRYPOINT ["dotnet", "WolfAPI.dll"]
