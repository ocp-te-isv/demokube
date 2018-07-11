FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY crashy/crashy.csproj crashy/
RUN dotnet restore crashy/crashy.csproj
COPY . .
WORKDIR /src/crashy
RUN dotnet build crashy.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish crashy.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "crashy.dll"]
