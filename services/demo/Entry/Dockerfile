#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/demo/Entry/Admin.NET.Demo.Entry.csproj", "services/demo/Entry/"]
COPY ["services/demo/Application/Admin.NET.Demo.Application.csproj", "services/demo/Application/"]
COPY ["shared/Core.Shared/Admin.NET.Core.Shared.csproj", "shared/Core.Shared/"]
RUN dotnet restore "services/demo/Entry/Admin.NET.Demo.Entry.csproj"
COPY . .
WORKDIR "/src/services/demo/Entry"
RUN dotnet build "Admin.NET.Demo.Entry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Admin.NET.Demo.Entry.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.NET.Demo.Entry.dll"]