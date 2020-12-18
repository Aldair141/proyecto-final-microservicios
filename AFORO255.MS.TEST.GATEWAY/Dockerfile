FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY ./publicado/ /app
ENV ASPNETCORE_URLS=http://+:8079
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8079

ENTRYPOINT ["dotnet", "/app/AFORO255.MS.TEST.GATEWAY.dll"]