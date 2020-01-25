FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY CodeFirst.Demo/CodeFirst.Demo.csproj CodeFirst.Demo/
RUN dotnet restore CodeFirst.Demo/CodeFirst.Demo.csproj
COPY . .
WORKDIR /src/CodeFirst.Demo
RUN dotnet build CodeFirst.Demo.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CodeFirst.Demo.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CodeFirst.Demo.dll"]
