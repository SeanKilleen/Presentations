#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlankSlate/BlankSlate.csproj", "BlankSlate/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "BlankSlate/BlankSlate.csproj"
COPY . .
WORKDIR "/src/BlankSlate"
RUN dotnet build "BlankSlate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlankSlate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 9001
ENTRYPOINT ["dotnet", "BlankSlate.dll"]