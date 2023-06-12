FROM mcr.microsoft.com/dotnet/aspnet:7.0 as build-env
WORKDIR /App
COPY *.csproj
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet"."PlatformService.dll"]
