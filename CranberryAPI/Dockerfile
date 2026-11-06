# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Restore trước để tận dụng cache layer
COPY *.csproj ./
RUN dotnet restore

# Copy source (bin/obj/.env đã bị loại bởi .dockerignore)
COPY . .
RUN dotnet publish -c Release -o /app/out --no-restore

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Lắng nghe HTTP trên port 8080 trong container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CranberryAPI.dll"]
