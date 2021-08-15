FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Fatn.Server/Fatn.Server.csproj", "Fatn.Server/"]
RUN dotnet restore "Fatn.Server/Fatn.Server.csproj"
COPY . .
WORKDIR "/src/Fatn.Server"
RUN dotnet build "Fatn.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fatn.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fatn.Server.dll"]
