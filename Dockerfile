# Building the project and create release
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
EXPOSE 80 1433
WORKDIR /app

# Install NodeJS 13.x on the image
# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

# Restoring project packages and publishing the project release
COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release -o out

# Define the project Entry Point
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "VehicleStore.dll"]