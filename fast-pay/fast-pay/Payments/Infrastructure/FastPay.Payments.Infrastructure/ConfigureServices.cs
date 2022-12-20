using System;
using FastPay.Payments.Application.Common.Interfaces;
using FastPay.Payments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace FastPay.Payments.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<PaymentDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    builder => builder.MigrationsAssembly(typeof(PaymentDbContext).Assembly.FullName)));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<PaymentDbContext>());

            //services.AddScoped<IProfileContactRepository, ProfileContactRepository>();

            services.AddHttpClient<IProfileContactRepository, ProfileContactRepository>(client =>
            {
                client.BaseAddress = new Uri(configuration["ProfileApiUrl"]!);
            })
                .AddPolicyHandler(GetRetryPolicy());


            return services;
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}

