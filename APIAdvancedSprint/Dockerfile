FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /App
EXPOSE 8080

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

WORKDIR /App/out

ENTRYPOINT ["dotnet", "APIAdvancedSprint.dll"]