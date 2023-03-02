FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY bin/Release/net6.0/publish .

ENTRYPOINT ["dotnet", "WebAPI.dll"]