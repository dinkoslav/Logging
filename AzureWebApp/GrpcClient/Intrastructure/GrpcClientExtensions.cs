using Grpc.Net.ClientFactory;
using GrpcClient.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using static MeterReader.gRPC.MeterReaderService;

namespace GrpcClient.Intrastructure;

public static class GrpcClientExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        string endpoint = configuration["grpcServerEndpoint"];
        services
            .AddGrpcClient<MeterReaderServiceClient>(
                options => options.Address = new Uri(endpoint))
            .AddInterceptor(InterceptorScope.Client, serviceProvider =>
            {
                var logger = serviceProvider.GetRequiredService<ILogger<ClientInterceptor>>();

                return new ClientInterceptor(logger);
            });

        return services;
    }
}
