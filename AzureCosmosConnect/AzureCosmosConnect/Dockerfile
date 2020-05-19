FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AzureCosmosConnect/AzureCosmosConnect.csproj", "AzureCosmosConnect/"]
RUN dotnet restore "AzureCosmosConnect/AzureCosmosConnect.csproj"
COPY . .
WORKDIR "/src/AzureCosmosConnect"
RUN dotnet build "AzureCosmosConnect.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AzureCosmosConnect.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AzureCosmosConnect.dll"]