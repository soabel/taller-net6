using System;
namespace FastPay.Payments.WebUI;


public static class ConfigureServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}

