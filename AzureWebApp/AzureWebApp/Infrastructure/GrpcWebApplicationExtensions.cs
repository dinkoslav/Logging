namespace AzureWebApp.Infrastructure;

using Apex.Logging.Grpc.Interceptors;
using AzureWebApp.Infrastructure.Configuration.SoapSettings;
using AzureWebApp.Services;
using Grpc.AspNetCore.Server;
using SoapBookService;
using System.ServiceModel;

public static class GrpcWebApplicationExtensions
{
    public static WebApplication AddGrpcServices(this WebApplication webApplication)
    {
        webApplication.MapGrpcService<MeterReadingService>();

        return webApplication;
    }
}
