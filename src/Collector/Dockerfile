FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

COPY ./publish .

ENTRYPOINT ["dotnet", "Collector.dll"]