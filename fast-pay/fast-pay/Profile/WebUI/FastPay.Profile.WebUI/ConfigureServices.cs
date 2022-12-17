using System;
using FastPay.Profile.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastPay.Profile.WebUI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
