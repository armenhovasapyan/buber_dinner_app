#!/bin/bash
# Stop script on first error
set -e

# if ! command -v sqlite3 &> /dev/null; then
#   echo "📦 SQLite3 not found. Installing..."
#   apt-get update && apt-get install -y sqlite3
# else
#   echo "✅ SQLite3 is already installed. Skipping installation."
# fi

# Only generate if the solution file doesn't exist yet
if [ ! -f "BuberDinner.slnx" ]; then
  echo "🚀 Generating Clean Architecture solution..."

  dotnet new sln -n BuberDinner

  dotnet new webapi -o BuberDinner.Presentation --use-controllers
  dotnet new classlib -o BuberDinner.Contracts
  dotnet new classlib -o BuberDinner.Infrastructure
  dotnet new classlib -o BuberDinner.Application
  dotnet new classlib -o BuberDinner.Domain
  
  dotnet sln BuberDinner.slnx add BuberDinner.Presentation/BuberDinner.Presentation.csproj
  dotnet sln BuberDinner.slnx add BuberDinner.Contracts/BuberDinner.Contracts.csproj
  dotnet sln BuberDinner.slnx add BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj
  dotnet sln BuberDinner.slnx add BuberDinner.Application/BuberDinner.Application.csproj
  dotnet sln BuberDinner.slnx add BuberDinner.Domain/BuberDinner.Domain.csproj


  # Presentation layer references Application AND Contracts
  dotnet add BuberDinner.Presentation/BuberDinner.Presentation.csproj reference BuberDinner.Contracts/BuberDinner.Contracts.csproj
  dotnet add BuberDinner.Presentation/BuberDinner.Presentation.csproj reference BuberDinner.Application/BuberDinner.Application.csproj
  dotnet add BuberDinner.Presentation/BuberDinner.Presentation.csproj reference BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj

  # Infrastructure layer references Application
  dotnet add BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj reference BuberDinner.Application/BuberDinner.Application.csproj

  # Application layer references Domain AND Contracts (to map API requests to internal commands)
  dotnet add BuberDinner.Application/BuberDinner.Application.csproj reference BuberDinner.Domain/BuberDinner.Domain.csproj

  echo "✅ Solution built successfully inside container!"
else
  echo "🔄 Solution already exists. Restoring dependencies..."
  dotnet restore BuberDinner.slnx
fi
