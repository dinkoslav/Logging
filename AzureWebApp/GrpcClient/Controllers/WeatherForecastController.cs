using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using MeterReader.gRPC;

using Microsoft.AspNetCore.Mvc;

using static MeterReader.gRPC.MeterReaderService;

namespace GrpcClient.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MeterReaderServiceClient grpcClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MeterReaderServiceClient grpcClient)
    {
        _logger = logger;
        this.grpcClient = grpcClient;
    }

    [HttpGet("RequestStreaming", Name = "RequestStreaming")]
    public async Task<int> GetStream()
    {
        try
        {
            Metadata headers = new Metadata();
            CancellationToken stoppingToken = new CancellationToken();
            using (var stream = this.grpcClient.AddReadingStream(headers, cancellationToken: stoppingToken))
            {
                for (int i = 0; i < 2; i++)
                {
                    //var reading = await this.generator.GenerateAsync(this.customerId);
                    ReadingMessage reading = new ReadingMessage()
                    {
                        CustomerId = i,
                        Notes = $"Notes_{i}",
                        ReadingTime = Timestamp.FromDateTime(DateTime.UtcNow),
                        ReadingValue = i
                    };

                    await stream.RequestStream.WriteAsync(reading, stoppingToken);
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }
        catch (RpcException ex)
        {
            this._logger.LogError(ex.Message);
        }

        return await Task.FromResult(1);
    }

    [HttpGet("DuplexStreaming", Name = "DuplexStreaming")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        try
        {
            Metadata headers = new Metadata();
            CancellationToken stoppingToken = new CancellationToken();
            var stream = this.grpcClient.AddDuplexStream(headers, cancellationToken: stoppingToken);
            for (int i = 0; i < 5; i++)
            {
                //var reading = await this.generator.GenerateAsync(this.customerId);
                ReadingMessage reading = new ReadingMessage();
                await stream.RequestStream.WriteAsync(reading, stoppingToken);
                await Task.Delay(500, stoppingToken);
            }

            await stream.RequestStream.CompleteAsync();
            while (await stream.ResponseStream.MoveNext(stoppingToken))
            {
                this._logger.LogWarning($"From server: {stream.ResponseStream.Current.Message}");
            }


        }
        catch (RpcException ex)
        {
            this._logger.LogError(ex.Message);
        }

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
