FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /src
COPY ["VehicleStore.csproj", "VehicleStore/"]
RUN dotnet restore "VehicleStore.csproj"
COPY . .
WORKDIR "/VehicleStore"
RUN dotnet build "VehicleStore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "VehicleStore.csproj" -c Release -o /app

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh

FROM node as nodebuilder
RUN mkdir /usr/src/app
WORKDIR /usr/src/app
ENV PATH /usr/src/app/node_modules/.bin:$PATH
COPY VehicleStore/ClientApp/package.json /usr/src/app/package.json
RUN npm install
COPY VehicleStore/ClientApp/. /usr/src/app
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN mkdir -p /app/ClientApp/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/
ENTRYPOINT ["dotnet", "VehicleStore.dll"]