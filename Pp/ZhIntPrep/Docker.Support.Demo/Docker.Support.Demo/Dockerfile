FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Docker.Support.Demo/Docker.Support.Demo.csproj Docker.Support.Demo/
RUN dotnet restore Docker.Support.Demo/Docker.Support.Demo.csproj
COPY . .
WORKDIR /src/Docker.Support.Demo
RUN dotnet build Docker.Support.Demo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Docker.Support.Demo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Docker.Support.Demo.dll"]
