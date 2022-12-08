#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["demo-bug-memoryleak/demo-bug-memoryleak.csproj", "demo-bug-memoryleak/"]
RUN dotnet restore "demo-bug-memoryleak/demo-bug-memoryleak.csproj"
COPY . .
WORKDIR "/src/demo-bug-memoryleak"
RUN dotnet build "demo-bug-memoryleak.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demo-bug-memoryleak.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demo-bug-memoryleak.dll"]