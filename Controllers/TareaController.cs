using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_iignac.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareaRepo;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepo = new TareaRepository();
    }

    [HttpPost("/api/tarea")]
    public ActionResult<string> AddTarea([FromForm]Tarea nuevaTarea){
        tareaRepo.Create(nuevaTarea);
        return Ok("Tarea creada exitosamente");
    }

    /*
    [HttpPut("/api/tarea")]
    public ActionResult<string> UpdateTarea([FromForm]Tarea tareaModificar){
        if(tareaRepo.Update(tareaModificar)) return Ok("Tarea actualizada exitosamente");
        return BadRequest("ERROR. ID de Tarea inexistente");
    }
    */

    [HttpPut("/api/tarea/{id}/nombre/{nombre}")]
    public ActionResult<string> UpdateNombre(int id, string nombre){
        if(tareaRepo.UpdateNombre(id, nombre)) return Ok("Tarea actualizada exitosamente");
        return BadRequest("ERROR. ID de Tarea inexistente");
    }

    [HttpPut("/api/tarea/{id}/estado/{estado}")]
    public ActionResult<string> UpdateEstado(int id, EstadoTarea estado){
        if(tareaRepo.UpdateEstado(id, estado)) return Ok("Tarea actualizada exitosamente");
        return BadRequest("ERROR. ID de Tarea inexistente");
    }

    [HttpDelete("/api/tarea/{id}")] 
    public ActionResult<string> DeleteTarea(int id){
        if(tareaRepo.Remove(id)) return Ok("Tarea eliminada exitosamente");
        return BadRequest("ERROR. ID de tarea inexistente");
    }

    [HttpGet("/api/tarea/{estado}")]
    public ActionResult<string> GetCantTareasSegunEstado(EstadoTarea estado){
        return Ok($"La cantidad de tareas de estado '{estado}' es {tareaRepo.GetCantTareasSegunEstado(estado)}");
    }
    
    [HttpGet("/api/tarea/usuario/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorIdUsuario(int id){
        return Ok(tareaRepo.GetAllByIdUsuario(id));
    }

    [HttpGet("/api/tarea/tablero/{id}")]
    public ActionResult<IEnumerable<Tarea>> GetTareasPorIdTablero(int id){
        return Ok(tareaRepo.GetAllByIdTablero(id));
    }
}
