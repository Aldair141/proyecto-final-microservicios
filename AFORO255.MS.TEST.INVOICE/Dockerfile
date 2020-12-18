FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app

COPY ./publicado/ /app
ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8081

ENTRYPOINT ["dotnet", "/app/AFORO255.MS.TEST.INVOICE.dll"]