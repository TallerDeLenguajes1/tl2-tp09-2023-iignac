namespace tl2_tp09_2023_iignac;

public interface ITareaRepository
{
    public void Create(Tarea tarea);
    //public bool Update(Tarea tarea);
    public bool UpdateNombre(int id, string nuevoNombre);
    public bool UpdateEstado(int idTarea, EstadoTarea nuevoEstado);
    public bool AsignarUsuario(int idUsuario, int idTarea);
    public bool Remove(int idTarea);
    public Tarea GetByIdTarea(int idTarea);
    public List<Tarea> GetAllByIdUsuario(int idUsuario);
    public List<Tarea> GetAllByIdTablero(int idTablero);
    public int GetCantTareasSegunEstado(EstadoTarea estado);  
}