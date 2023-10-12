FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SeveranceCalculator.API/SeveranceCalculator.API.csproj", "SeveranceCalculator.API/"]
RUN dotnet restore "SeveranceCalculator.API/SeveranceCalculator.API.csproj"
COPY . .
WORKDIR "/src/SeveranceCalculator.API"
RUN dotnet build "SeveranceCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeveranceCalculator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeveranceCalculator.API.dll"]
