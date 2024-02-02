#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BubbleTeaCorp.API/BubbleTeaCorp.API.csproj", "BubbleTeaCorp.API/"]
RUN dotnet restore "BubbleTeaCorp.API/BubbleTeaCorp.API.csproj"
COPY . .
WORKDIR "/src/BubbleTeaCorp.API"
RUN dotnet build "BubbleTeaCorp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BubbleTeaCorp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BubbleTeaCorp.API.dll"]
