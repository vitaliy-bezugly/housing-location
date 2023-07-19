using System.Reflection;
using FluentValidation;
using Housing.Application.Common.Behaviours;
using Housing.Application.Common.Models;
using Housing.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Housing.Application;

public static class ServicesConfigurator
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        services.AddScoped<IQueryBuilder<HousingLocationEntity>, QueryBuilder<HousingLocationEntity>>();

        return services;
    }
}