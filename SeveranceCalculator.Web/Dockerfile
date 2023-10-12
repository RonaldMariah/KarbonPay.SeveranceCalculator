FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SeveranceCalculator.Web/SeveranceCalculator.Web.csproj", "SeveranceCalculator.Web/"]
RUN dotnet restore "SeveranceCalculator.Web/SeveranceCalculator.Web.csproj"
COPY . .
WORKDIR "/src/SeveranceCalculator.Web"
RUN dotnet build "SeveranceCalculator.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeveranceCalculator.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeveranceCalculator.Web.dll"]
