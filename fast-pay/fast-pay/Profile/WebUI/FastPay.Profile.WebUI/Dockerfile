#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Profile/WebUI/FastPay.Profile.WebUI/FastPay.Profile.WebUI.csproj", "Profile/WebUI/FastPay.Profile.WebUI/"]
COPY ["Profile/Application/FastPay.Profile.Application/FastPay.Profile.Application.csproj", "Profile/Application/FastPay.Profile.Application/"]
COPY ["Profile/Domain/FastPay.Profile.Domain/FastPay.Profile.Domain.csproj", "Profile/Domain/FastPay.Profile.Domain/"]
COPY ["Profile/Infrastructure/FastPay.Profile.Infrastructure/FastPay.Profile.Infrastructure.csproj", "Profile/Infrastructure/FastPay.Profile.Infrastructure/"]
RUN dotnet restore "Profile/WebUI/FastPay.Profile.WebUI/FastPay.Profile.WebUI.csproj"
COPY . .
WORKDIR "/src/Profile/WebUI/FastPay.Profile.WebUI"
RUN dotnet build "FastPay.Profile.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastPay.Profile.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastPay.Profile.WebUI.dll"]
