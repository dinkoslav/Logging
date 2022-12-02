namespace AzureWebApp.Infrastructure;

using Apex.Common.Soap;
using AzureWebApp.Infrastructure.Configuration.SoapSettings;
using SoapBookService;
using System.ServiceModel;

public static class SoapClientExtensions
{
    public static IServiceCollection AddSoapClients(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSoapClient<BookService, BookServiceClient, BookServiceSettings>(
            configuration,
            new BasicHttpsBinding(),
            (x, opt) =>
            {
                //x.UserName.Password = opt.Password;
            });

        return services;
    }
}
