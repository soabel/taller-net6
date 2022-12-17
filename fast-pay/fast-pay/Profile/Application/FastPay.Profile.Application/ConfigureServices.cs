using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FastPay.Profile.Application.Contacts.Commands.CreateContact;

namespace FastPay.Profile.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(typeof(CreateContactCommandValidator).Assembly);
        services.AddMediatR(Assembly.GetExecutingAssembly());


        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }

}

