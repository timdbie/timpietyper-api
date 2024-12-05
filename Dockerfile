FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev
WORKDIR /app 
COPY *.sln .
COPY TimpieTyper.Api/*.csproj ./TimpieTyper.Api/
COPY TimpieTyper.Core/*.csproj ./TimpieTyper.Core/
COPY TimpieTyper.Persistence/*.csproj ./TimpieTyper.Persistence/ 

RUN dotnet restore 

COPY TimpieTyper.Api/. ./TimpieTyper.Api/
COPY TimpieTyper.Core/. ./TimpieTyper.Core/
COPY TimpieTyper.Persistence/. ./TimpieTyper.Persistence/ 
#
WORKDIR /app/TimpieTyper.Api 
ENV ASPNETCORE_URLS="http://localhost:8080"
#
ENTRYPOINT ["dotnet", "watch", "run"]