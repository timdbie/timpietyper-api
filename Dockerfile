FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app

COPY *.sln .
COPY TimpieTyper.Api/*.csproj ./TimpieTyper.Api/
COPY TimpieTyper.Core/*.csproj ./TimpieTyper.Core/
COPY TimpieTyper.Persistence/*.csproj ./TimpieTyper.Persistence/
COPY TimpieTyper.Test/*.csproj ./TimpieTyper.Test/

RUN dotnet restore 

COPY TimpieTyper.Api/. ./TimpieTyper.Api/
COPY TimpieTyper.Core/. ./TimpieTyper.Core/
COPY TimpieTyper.Persistence/. ./TimpieTyper.Persistence/
COPY TimpieTyper.Test/. ./TimpieTyper.Test/

FROM base AS development
WORKDIR /app/TimpieTyper.Api
EXPOSE 5278
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://+:5278"]

FROM base AS testing
WORKDIR /app/TimpieTyper.Test
CMD ["dotnet", "test", "--no-restore", "--verbosity", "normal"]

FROM base AS production
WORKDIR /app/TimpieTyper.Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=production /app/TimpieTyper.Api/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "TimpieTyper.Api.dll"]
