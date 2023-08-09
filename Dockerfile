FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source
COPY src/ ./
RUN dotnet publish Clipdrop/Clipdrop.csproj -c release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /out/ ./
RUN rm /app/appsettings.Development.json

EXPOSE 8080

ENTRYPOINT ["/app/Clipdrop", "--urls", "http://0.0.0.0:8080"]
