FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /app
COPY bin/Release/net6.0/publish .

ENTRYPOINT ["dotnet", "WebAPI.dll"]