#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BasketMicroservice/BasketMicroService.csproj", "BasketMicroservice/"]
RUN dotnet restore "BasketMicroservice/BasketMicroService.csproj"
COPY . .
WORKDIR "/src/BasketMicroservice"
RUN dotnet build "BasketMicroService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketMicroService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketMicroService.dll"]