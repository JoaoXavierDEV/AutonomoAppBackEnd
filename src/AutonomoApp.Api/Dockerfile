#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AutonomoApp.Api/AutonomoApp.WebApi.csproj", "src/AutonomoApp.Api/"]
COPY ["src/AutonomoApp.Data/AutonomoApp.Data.csproj", "src/AutonomoApp.Data/"]
COPY ["src/AutonomoApp.Business/AutonomoApp.Business.csproj", "src/AutonomoApp.Business/"]
RUN dotnet restore "src/AutonomoApp.Api/AutonomoApp.WebApi.csproj"
COPY . .
WORKDIR "/src/src/AutonomoApp.Api"
RUN dotnet build "AutonomoApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutonomoApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutonomoApp.WebApi.dll"]