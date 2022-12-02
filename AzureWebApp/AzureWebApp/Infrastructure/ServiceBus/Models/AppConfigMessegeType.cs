namespace AzureWebApp.Infrastructure.ServiceBus.Models;

using Newtonsoft.Json;

public class AppConfigMessegeType
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; }

    [JsonProperty(PropertyName = "topic")]
    public string? Topic { get; set; }

    [JsonProperty(PropertyName = "subject")]
    public string? Subject { get; set; }

    [JsonProperty(PropertyName = "data")]
    public Data? Data { get; set; } 

    [JsonProperty(PropertyName = "eventType")]
    public string? EventType { get; set; }

    [JsonProperty(PropertyName = "dataVersion")]
    public string? DataVersion { get; set; }

    [JsonProperty(PropertyName = "metadataVersion")] 
    public string? MetadataVersion { get; set; }

    [JsonProperty(PropertyName = "eventTime")]
    public DateTime EventTime { get; set; }
}
