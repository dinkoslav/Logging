namespace AzureWebApp.Controllers;

using AzureWebApp.Infrastructure.Configuration.Models;
using AzureWebApp.WebApiCalle;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IConfiguration configuration;
    private readonly IOptionsMonitor<AzureAppSettings> azureAppSettings;

    public TestController(ILogger<TestController> logger, IConfiguration configuration, IOptionsMonitor<AzureAppSettings> azureAppSettings)
    {
        _logger = logger;
        this.configuration = configuration;
        this.azureAppSettings = azureAppSettings;
    }

    [HttpGet]
    [Route("ok")]
    public async Task<ActionResult> OkTest()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        var response1 = await httpClient.GetAsync("https://www.ipvoid.com/gzip-test/");


        //Client client = new("https://www.ipvoid.com/gzip-test/", new HttpClient());
        //await client.TestConfigPathCreateAsync("dadas");

        //_logger.LogDebug("test by {0}", "Icakis Debug");
        //_logger.LogTrace("test by {0}", "Trace");
        //_logger.LogInformation("test by {0}", "Icakis");
        //_logger.LogWarning("test by {0}", "Bobi");
        //_logger.LogError("test by {0}", "Error");
        //_logger.LogError(new InvalidOperationException("Test ex LogError"), "the message 1");
        //_logger.LogCritical(new NullReferenceException("Test ex LogCritical"), "the message 2");
        _logger.LogCritical("test by {0}", "20Critical-Caller199!");

        string response = string.IsNullOrEmpty(this.configuration["AzureWebApp:Testkey"]) ?
            $"{this.configuration["AzureWebApp:Testkey"]} | {this.azureAppSettings.CurrentValue?.Testkey}" : "My response is 'Whaaatt!'";

        return this.Ok(response);
    }

    [HttpPost]
    [Route("config/path-create")]
    public string PostDataTest([FromBody] string path)
    {
        string response = this.configuration[path] ?? "My response is 'Whaaatt!WTF'";

        return response;
    }

    [HttpGet]
    [Route("config/path")]
    public string GetConfigByPath(string path)
    {
        string response = this.configuration[path] ?? "My response is 'Whaaatt!WTF'";

        return response;
    }

    [HttpGet]
    [Route("config/env")]
    public string GetConfigEnv(string variable = "ASPNETCORE_ENVIRONMENT")
    {
        this._logger.LogError(new NotImplementedException("Tesst"), "dssadas");
        string response = this.configuration[variable] ?? throw new ArgumentException("My response is 'Whaaatt!WTF'");


        return response;
    }
}

