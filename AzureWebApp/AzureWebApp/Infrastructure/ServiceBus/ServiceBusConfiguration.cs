namespace AzureWebApp.Infrastructure.ServiceBus;

using MassTransit;
using MassTransit.AzureServiceBusTransport.Configuration;

using Microsoft.Azure.ServiceBus.Primitives;

public static class ServiceBusConfiguration
{
    public static void AddServiceBus(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddConsumer<AppConfigChangeConsumer>();

            x.UsingAzureServiceBus((context, cfg) =>
            {
                var conf = context.GetRequiredService<IConfiguration>();

                string endpoint = conf["ServiceBus:Endpoint"];
                string subscriptionName = conf["ServiceBus:SubscriptionName"];
                string topicName = conf["ServiceBus:AppConfigTopicName"];

                cfg.Host(new Uri(endpoint));

                cfg.ConfigureEndpoints(context);

                cfg.SubscriptionEndpoint(subscriptionName, topicName, e =>
                {
                    // parse json messege
                    e.ClearSerialization();
                    e.UseRawJsonSerializer();

                    e.ConfigureConsumer<AppConfigChangeConsumer>(context);
                });
            });
        });
    }
}
