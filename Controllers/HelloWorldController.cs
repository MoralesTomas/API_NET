using Microsoft.AspNetCore.Mvc;
using proyectoEF.Contexto;

namespace API_NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    IHelloWorldService helloWorldService;
    TareasContext dbcontext;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger,TareasContext db)
    {
        _logger = logger;
        helloWorldService = helloWorld;
        dbcontext = db;

    }

    [HttpGet]
    [Route("api/test/[controller]")]
    public IActionResult Get()
    {
        _logger.LogDebug("mandando el hola mundo desde el controlador de HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}