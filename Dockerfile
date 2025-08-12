FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/
# Try just copying everything first
COPY . .
RUN dotnet restore "LinternBackend/LinternBackend.csproj"
RUN dotnet build "LinternBackend/LinternBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinternBackend/LinternBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinternBackend.dll"]