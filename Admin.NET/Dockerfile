#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
COPY "Admin.NET.Web.Entry/publish" .
# 不使用AppConfig.json 而使用appsettings.Docker.json配置
RUN rm -rf AppConfig.json 
ENTRYPOINT ["dotnet", "Admin.NET.Web.Entry.dll"]