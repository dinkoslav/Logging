namespace AzureWebApp.Infrastructure.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication ConfigureSwagger(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{

        app.UseSwagger();
        app.UseSwaggerUI();

        //}

        return app;
    }
}

