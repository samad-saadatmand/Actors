FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM node:latest as node_base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY --from=node_base . .

WORKDIR /src
COPY ["src/Actors.WebUI/Actors.WebUI.csproj", "src/Actors.WebUI/"]
COPY ["src/Actors.Application/Actors.Application.csproj", "src/Actors.Application/"]
COPY ["src/Actors.Domain/Actors.Domain.csproj", "src/Actors.Domain/"]
COPY ["src/Actors.Infrastructure/Actors.Infrastructure.csproj", "src/Actors.Infrastructure/"]
RUN dotnet restore "src/Actors.WebUI/Actors.WebUI.csproj"
COPY . .
WORKDIR "/src/src/Actors.WebUI"
RUN dotnet build "Actors.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Actors.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Actors.WebUI.dll"]