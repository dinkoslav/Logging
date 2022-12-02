namespace AzureWebApp.Infrastructure.ServiceBus;

using AzureWebApp.Infrastructure.ServiceBus.Models;

using MassTransit;

using Microsoft.Extensions.Configuration.AzureAppConfiguration;

public class AppConfigChangeConsumer : IConsumer<AppConfigMessegeType>
{
    private readonly IConfigurationRefresher configurationRefresher;
    private readonly ILogger<AppConfigChangeConsumer> logger;

    public AppConfigChangeConsumer(IConfigurationRefresher configurationRefresher, ILogger<AppConfigChangeConsumer> logger) //, IConfigurationRefresherProvider configurationRefresherProvider)
    {
        this.configurationRefresher = configurationRefresher;
        this.logger = logger;
    }

    public Task Consume(ConsumeContext<AppConfigMessegeType> context)
    {
        #region example
        //{
        //    "id": "6e05a582-74eb-4ce1-ba01-72091ef12404",
        //    "topic": "/subscriptions/ccfd3b52-85d9-4452-b5d3-2914be72cc31/resourceGroups/freetrial_eus2_rg/providers/microsoft.appconfiguration/configurationstores/appconfigeus2",
        //    "subject": "https://appconfigeus2.azconfig.io/kv/AzureWebApp::Testkey?label=%00&api-version=1.0",
        //    "data": {
        //        "key": "AzureWebApp::Testkey",
        //        "label": null,
        //        "etag": "UE_96ey-NZ0tbDYl7l4_tDyHthkQEUG8gJlBkHENZec",
        //        "syncToken": "zAJw6V16=NToxNyMyMzE3MjA1MA==;sn=23172050"
        //    },
        //    "eventType": "Microsoft.AppConfiguration.KeyValueModified",
        //    "dataVersion": "2",
        //    "metadataVersion": "1",
        //    "eventTime": "2022-08-15T13:41:19.6073079Z"
        //}
        #endregion example
        try
        {
            PushNotification pushNotification = new PushNotification()
            {
                EventType = context.Message.EventType,
                SyncToken = context.Message.Data?.SyncToken,
                ResourceUri = new Uri(context.Message.Subject)
            };

            // max delay to refresh in
            // https://docs.microsoft.com/en-us/azure/azure-app-configuration/enable-dynamic-configuration-dotnet-core-push-refresh?tabs=windowscommandprompt
            TimeSpan maxDelay = new TimeSpan(0, 0, 2);
            this.configurationRefresher.ProcessPushNotification(pushNotification, maxDelay);
            logger.LogInformation($"Consumed {nameof(AppConfigChangeConsumer)} messege {context.Message?.Data?.Key} SUCCESS!");

            //if (await configurationRefresher.TryRefreshAsync())
            //{
            //    logger.LogInformation($"Consumed {nameof(AppConfigChangeConsumer)} messege {context.Message?.Data?.Key} SUCCESS!");
            //}
            //else
            //{
            //    logger.LogInformation($"Consumed {nameof(AppConfigChangeConsumer)} messege {context.Message?.Data?.Key} FAILED!");
            //}
        }
        catch (Exception ex)
        {

            logger.LogError(ex, $"Consumed with exception");

        }

        return Task.CompletedTask;
    }
}
