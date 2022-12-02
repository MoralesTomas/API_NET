using Microsoft.AspNetCore.Mvc;

namespace API_NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;
        helloWorldService = helloWorld;
    }

    [Route("api/test/[controller]")]
    public IActionResult Get()
    {
        _logger.LogDebug("mandando el hola mundo desde el controlador de HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }
}