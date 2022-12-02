using Google.Protobuf.WellKnownTypes;

using Grpc.Core;
using MeterReader.gRPC;
using static MeterReader.gRPC.MeterReaderService;

namespace AzureWebApp.Services;

public class MeterReadingService : MeterReaderServiceBase
{
    private readonly ILogger<MeterReadingService> logger;

    public MeterReadingService(ILogger<MeterReadingService> logger)
    {
        this.logger = logger;
    }


    public override async Task<StatusMessage> AddReading(
        ReadingPacket request,
        ServerCallContext context)
    {
        return new StatusMessage
        {
            Message = "Failed to store readings in database",
            Status = ReadingStatus.Success
        };
    }


    public override async Task<Empty> AddReadingStream(IAsyncStreamReader<ReadingMessage> requestStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext())
        {
            var message = requestStream.Current;

        }

        return new Empty();
    }

    public override async Task AddDuplexStream(
        IAsyncStreamReader<ReadingMessage> requestStream,
        IServerStreamWriter<ErrorMessage> responseStream,
        ServerCallContext context)
    {
        while (await requestStream.MoveNext())
        {
            var message = requestStream.Current;

            if (message.ReadingValue < 500)
            {
                await responseStream.WriteAsync(new ErrorMessage
                {
                    Message = $"Value less than 500. Value: {message.ReadingValue}"
                });
            }

            //var readingValue = new MeterReading
            //{
            //    CustomerId = message.CustomerId,
            //    Value = message.ReadingValue,
            //    ReadingDate = message.ReadingTime.ToDateTime()
            //};

            //this.logger.LogInformation("Adding {ReadingValue} from stream", message.ReadingValue);
            //this.repository.AddEntity(readingValue);
            //await this.repository.SaveAllAsync();
        }

        // return new Empty();
    }
}
