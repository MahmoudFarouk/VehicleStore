FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 13.x
# see https://github.com/nodesource/distributions/blob/master/README.md#deb
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

# copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release -o out

##Run SQL Scripts
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

FROM base
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "VehicleStore.dll"]






#
## Copy csproj and restore as distinct layers
#COPY . .
#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
#RUN dotnet restore
#
## Setup NodeJs
#RUN apt-get update && \
    #apt-get install -y wget && \
    #apt-get install -y gnupg2 && \
    #wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    #apt-get install -y build-essential nodejs
#
## Copy everything else and build
#COPY . .
#FROM build AS publish
#RUN dotnet publish -c Release -o out
#

#
## Build runtime image
#FROM base AS final
#WORKDIR /app
#COPY --from=base /app/out .
#ENTRYPOINT ["dotnet", "VehicleStore.dll"]