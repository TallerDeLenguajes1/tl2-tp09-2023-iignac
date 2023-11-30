using Microsoft.AspNetCore.Mvc;
//using kanban  ->  si kanban es el Namespace de las clases en las carpetas Models y Repository 
namespace tl2_tp09_2023_iignac.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuarioRepository usuarioRepo;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepo = new UsuarioRepository();
    }

    [HttpPost("/api/usuario")]
    public ActionResult<string> AddUsuario([FromForm]Usuario nuevoUsuario){
        usuarioRepo.Create(nuevoUsuario);
        return Ok("Usuario creado exitosamente");
    }

    [HttpPut("/api/usuario/Nombre")]
    public ActionResult<string> UpdateUsuario([FromForm]Usuario usuarioModificar){
        if(usuarioRepo.Update(usuarioModificar)) return Ok("Usuario actualizado exitosamente");
        return BadRequest("ERROR. ID de usuario inexistente");
    }
    
    [HttpGet("/api/usuario")]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios(){
        return Ok(usuarioRepo.GetAll());
    }

    [HttpGet("/api/usuario/{id}")]
    public ActionResult<Usuario> GetUnUsuario(int id){
        return Ok(usuarioRepo.GetByIdUsuario(id));
    }

    /*
    [HttpDelete("/api/usuario/{id}")] 
    public ActionResult<string> DeleteUsuario(int id){
        if(usuarioRepo.Remove(id)) return Ok("Usuario eliminado exitosamente");
        return BadRequest("ERROR. ID de usuario inexistente");
    }
    */
}
