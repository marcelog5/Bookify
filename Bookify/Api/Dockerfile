FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Install OpenSSL and generate self-signed certificate
RUN apt-get update && apt-get install -y openssl && \
    mkdir /https && \
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /https/aspnetapp.key -out /https/aspnetapp.crt -subj "/CN=localhost"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "./Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Copy the certificate to the final stage
COPY --from=base /https /https

# Configure Kestrel to use the certificate
ENTRYPOINT ["dotnet", "Api.dll", "--urls", "http://0.0.0.0:8080;https://0.0.0.0:8081"]
