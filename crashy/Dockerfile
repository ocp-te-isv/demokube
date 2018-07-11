FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY crashy.sln /app
COPY crashy/*.csproj /app/crashy/
RUN dotnet restore

COPY crashy /app/crashy
WORKDIR /app/crashy
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/crashy/out ./
ENTRYPOINT ["dotnet", "crashy.dll"]