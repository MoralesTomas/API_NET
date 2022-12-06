using Microsoft.AspNetCore.Mvc;
using proyectoEF.Models;
using API_NET.Services;

namespace API_NET.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareasService tareasService;

    public TareaController(ITareasService service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea Tarea)
    {
        tareasService.Save(Tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea Tarea)
    {
        tareasService.Update(id, Tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareasService.Delete(id);
        return Ok();
    }  
}