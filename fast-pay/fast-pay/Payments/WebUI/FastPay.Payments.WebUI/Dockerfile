#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Payments/WebUI/FastPay.Payments.WebUI/FastPay.Payments.WebUI.csproj", "Payments/WebUI/FastPay.Payments.WebUI/"]
COPY ["Payments/Application/FastPay.Payments.Application/FastPay.Payments.Application.csproj", "Payments/Application/FastPay.Payments.Application/"]
COPY ["Payments/Domain/FastPay.Payments.Domain/FastPay.Payments.Domain.csproj", "Payments/Domain/FastPay.Payments.Domain/"]
COPY ["Payments/Infrastructure/FastPay.Payments.Infrastructure/FastPay.Payments.Infrastructure.csproj", "Payments/Infrastructure/FastPay.Payments.Infrastructure/"]
RUN dotnet restore "Payments/WebUI/FastPay.Payments.WebUI/FastPay.Payments.WebUI.csproj"
COPY . .
WORKDIR "/src/Payments/WebUI/FastPay.Payments.WebUI"
RUN dotnet build "FastPay.Payments.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastPay.Payments.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastPay.Payments.WebUI.dll"]
