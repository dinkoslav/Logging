namespace AzureWebApp.Infrastructure.Configuration;

using Azure.Core;
using Azure.Identity;

using AzureWebApp.Infrastructure.Configuration.Models;

using Microsoft.Extensions.Configuration.AzureAppConfiguration;

using Steeltoe.Extensions.Configuration.Placeholder;

public static class ConfigureAppConfigurationExtensions
{
    public static ConfigureHostBuilder ConfigureWithManageIdentity(
        this ConfigureHostBuilder hostBuilder,
        HostBuilderContext hostingContext,
        IConfigurationBuilder config)
    {
        var settings = config
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        //string endpoint = settings["AppConfig:Endpoint"];

        //TokenCredential tokenCredential;

        //if (hostingContext.HostingEnvironment.IsDevelopment())
        //{
        //    // MenagedIdentitity does not work on localhost
        //    // https://docs.microsoft.com/en-us/azure/azure-app-configuration/howto-integrate-azure-managed-service-identity?tabs=core5x&pivots=framework-dotnet
        //    //string managedIdentityCreadeantialId = settings.GetValue<string>("AppSecrets:ManagedIdentityClientId");
        //    tokenCredential = new DefaultAzureCredential();
        //}
        //else
        //{
        //    tokenCredential = new ManagedIdentityCredential(clientId: "a1dfbd5f-75a4-4a57-980b-7a15b3d4301d");
        //}

        //TimeSpan refreshTime = new(24, 0, 0);

        //config.AddAzureAppConfiguration(options =>
        //    {
        //        options.Connect(new Uri(endpoint), tokenCredential);
        //        options.ConfigureRefresh(refresh =>
        //        {
        //            refresh.Register("AzureWebApp:Sentinel", refreshAll: true).SetCacheExpiration(refreshTime);
        //        });

        //        options.ConfigureKeyVault(options =>
        //        {
        //            options.SetCredential(tokenCredential);
        //        });

        //        hostBuilder.ConfigureServices(x =>
        //        {
        //            x.AddScoped<IConfigurationRefresher>(x => { return options.GetRefresher(); });
        //        });
        //    });

        //string keyVaultName = settings["KeyVault:Name"];
        //config.AddAzureKeyVault(
        //    new Uri($"https://{keyVaultName}.vault.azure.net/"),
        //    tokenCredential,
        //    new PrefixKeyVaultSecretManager("AzureWebApp-"));

        //config.AddPlaceholderResolver();



        return hostBuilder;
    }

    public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        //var section = configuration.GetSection("AzureWebApp");
        //services.Configure<AzureAppSettings>(section);

        //services.AddOptions<AzureAppSettings>();
    }
}
