namespace AzureWebApp.Infrastructure.ServiceBus.Models;

using Newtonsoft.Json;

public class Data
{
    [JsonProperty(PropertyName = "key")]
    public string? Key { get; set; }

    [JsonProperty(PropertyName = "label")]
    public object? Label { get; set; }

    [JsonProperty(PropertyName = "etag")]
    public string? Etag { get; set; }

    [JsonProperty(PropertyName = "syncToken")]
    public string? SyncToken { get; set; }
}
