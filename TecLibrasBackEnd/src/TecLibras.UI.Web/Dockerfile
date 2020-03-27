FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/TecLibras.UI.Web/TecLibras.UI.Web.csproj", "src/TecLibras.UI.Web/"]
RUN dotnet restore "src/TecLibras.UI.Web/TecLibras.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/TecLibras.UI.Web"
RUN dotnet build "TecLibras.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TecLibras.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TecLibras.UI.Web.dll"]