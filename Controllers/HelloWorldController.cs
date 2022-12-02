using Microsoft.AspNetCore.Mvc;

namespace API_NET.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController:  ControllerBase
{
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    [Route("api/test/[controller]")]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}