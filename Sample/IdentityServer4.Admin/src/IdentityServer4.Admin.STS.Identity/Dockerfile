FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/IdentityServer4.Admin.STS.Identity/IdentityServer4.Admin.STS.Identity.csproj", "src/IdentityServer4.Admin.STS.Identity/"]
COPY ["src/IdentityServer4.Admin.Admin.EntityFramework.Shared/IdentityServer4.Admin.Admin.EntityFramework.Shared.csproj", "src/IdentityServer4.Admin.Admin.EntityFramework.Shared/"]
COPY ["src/IdentityServer4.Admin.Admin.EntityFramework.SqlServer/IdentityServer4.Admin.Admin.EntityFramework.SqlServer.csproj", "src/IdentityServer4.Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/IdentityServer4.Admin.Admin.EntityFramework.PostgreSQL/IdentityServer4.Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/IdentityServer4.Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/IdentityServer4.Admin.Shared/IdentityServer4.Admin.Shared.csproj", "src/IdentityServer4.Admin.Shared/"]
COPY ["src/IdentityServer4.Admin.Admin.EntityFramework.MySql/IdentityServer4.Admin.Admin.EntityFramework.MySql.csproj", "src/IdentityServer4.Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/IdentityServer4.Admin.STS.Identity/IdentityServer4.Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer4.Admin.STS.Identity"
RUN dotnet build "IdentityServer4.Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer4.Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IdentityServer4.Admin.STS.Identity.dll"]