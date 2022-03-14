FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
LABEL author="Kevin"


WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5001

# Copy csproj and restore as distinct layers
COPY LandHubWebService/LandHubWebService/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./LandHubWebService ./
RUN ls -al
RUN dotnet publish PropertyHatchWebService.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN apt-get update && apt-get install -y wget
RUN wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN apt-get install -y apt-transport-https && apt-get update && apt-get install -y dotnet-sdk-5.0
RUN apt-get install -y apt-utils
RUN apt-get install -y libc6-dev
RUN apt-get install -y libgdiplus
RUN ln -s /usr/lib/libgdiplus.so /usr/lib/gdiplus.dll
RUN dotnet dev-certs https --check --verbose
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust


WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 5001 443

ENTRYPOINT ["dotnet", "PropertyHatchWebApi.dll"]
