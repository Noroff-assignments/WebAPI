FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

WORKDIR /app
COPY bin/Release/net6.0/publish .

ENTRYPOINT ["dotnet", "webapi.dll"]