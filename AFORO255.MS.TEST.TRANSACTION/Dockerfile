FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app

COPY ./publicado/ /app
ENV ASPNETCORE_URLS=http://+:8083
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8083

ENTRYPOINT ["dotnet", "/app/AFORO255.MS.TEST.TRANSACTION.dll"]