FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine

WORKDIR /WebAPI
COPY bin/Release/net6.0/publish .

ENTRYPOINT ["dotnet", "webapi.dll"]