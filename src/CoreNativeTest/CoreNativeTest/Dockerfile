#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CoreNativeTest/CoreNativeTest.csproj", "CoreNativeTest/"]
RUN dotnet restore "CoreNativeTest/CoreNativeTest.csproj"
COPY . .
WORKDIR "/src/CoreNativeTest"
RUN dotnet build "CoreNativeTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreNativeTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreNativeTest.dll"]