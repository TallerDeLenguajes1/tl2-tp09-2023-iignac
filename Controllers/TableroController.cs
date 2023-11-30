using Microsoft.AspNetCore.Mvc;

namespace tl2_tp09_2023_iignac.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tableroRepo;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepo = new TableroRepository();
    }

    [HttpPost("/api/tablero")]
    public ActionResult<string> AddTablero([FromForm]Tablero nuevoTablero){
        tableroRepo.Create(nuevoTablero);
        return Ok("Usuario creado exitosamente");
    }
    
    [HttpGet("/api/tablero")]
    public ActionResult<IEnumerable<Tablero>> GetTableros(){
        return Ok(tableroRepo.GetAll());
    }
}
