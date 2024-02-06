FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/WebUI/*.csproj ./src/WebUI/
COPY src/Domain/*.csproj ./src/Domain/
COPY src/Application/*.csproj ./src/Application/
COPY src/Infrastructure/*.csproj ./src/Infrastructure/ 

COPY tests/Application.UnitTests/*.csproj ./tests/Application.UnitTests/
COPY tests/Application.IntegrationTests/*.csproj ./tests/Application.IntegrationTests/
COPY tests/Domain.UnitTests/*.csproj ./tests/Domain.UnitTests/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY . .
#
WORKDIR /app/src/WebUI

# ENTRYPOINT dotnet watch run  --urls http://0.0.0.0:80
# CMD dotnet watch run --urls http://0.0.0.0:80

# Production Build
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app 
#
COPY --from=build-env /app/src/WebUI/out .
ENTRYPOINT ["dotnet", "elastic_search_api.WebUI.dll"]