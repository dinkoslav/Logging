namespace AzureWebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using SoapBookService;

[ApiController]
[Route("[controller]")]
public class TestSoapController : ControllerBase
{
    private readonly ILogger<TestSoapController> logger;
    private readonly BookService bookService;

    public TestSoapController(
        ILogger<TestSoapController> logger,
        BookService bookService)
    {
        this.logger = logger;
        this.bookService = bookService;
    }

    [HttpGet]
    [Route("saop")]
    public async Task<ActionResult> OkTest()
    {
        GetAllBooksResponse? response = null;
        try
        {
            GetAllBooksRequest request = new();
            response = await bookService.GetAllBooksAsync(request);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, nameof(this.OkTest));
        }

        return this.Ok(response);
    }
}
