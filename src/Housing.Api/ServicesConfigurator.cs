using System.Reflection;
using Housing.Api.Constants;
using Housing.Api.Contracts.Models;
using Housing.Api.Factories;
using Housing.Domain.Entities;
using Microsoft.OpenApi.Models;

namespace Housing.Api;

public static class ServicesConfigurator
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Housing location API", Version = "v1" });
        });
        
        services.AddCors(options =>
        {
            options.AddPolicy(ConfigurationConstants.Cors.PolicyName, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.AddScoped<IMappingModelsFactory<HousingLocationEntity, HousingLocationModel>, HousingLocationFactory>();

        return services;
    }
}