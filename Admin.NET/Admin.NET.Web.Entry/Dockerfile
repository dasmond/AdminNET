#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Admin.NET/Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj", "Admin.NET/Admin.NET.Web.Entry/"]
COPY ["Admin.NET/Admin.NET.Web.Core/Admin.NET.Web.Core.csproj", "Admin.NET/Admin.NET.Web.Core/"]
COPY ["Admin.NET/Admin.NET.Application/Admin.NET.Application.csproj", "Admin.NET/Admin.NET.Application/"]
COPY ["Admin.NET/Admin.NET.Core/Admin.NET.Core.csproj", "Admin.NET/Admin.NET.Core/"]
RUN dotnet restore "Admin.NET/Admin.NET.Web.Entry/Admin.NET.Web.Entry.csproj"
COPY . .
WORKDIR "/src/Admin.NET/Admin.NET.Web.Entry"
RUN dotnet build "Admin.NET.Web.Entry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Admin.NET.Web.Entry.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.NET.Web.Entry.dll"]
