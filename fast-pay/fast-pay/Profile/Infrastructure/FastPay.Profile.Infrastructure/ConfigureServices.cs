using System;
using FastPay.Profile.Application.Common.Interfaces;
using FastPay.Profile.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastPay.Profile.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {


        services.AddDbContext<ProfileDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default"),
                builder => builder.MigrationsAssembly(typeof(ProfileDbContext).Assembly.FullName)));
        

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ProfileDbContext>());


        return services;
    }

}


