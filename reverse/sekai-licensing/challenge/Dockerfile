FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet build --configuration Release --no-restore
RUN dotnet publish --configuration Release --no-restore -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 80

ENTRYPOINT ["dotnet", "license-server.dll"]