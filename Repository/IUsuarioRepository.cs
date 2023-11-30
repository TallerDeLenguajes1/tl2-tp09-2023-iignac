namespace tl2_tp09_2023_iignac;

// En la interface solo defino los métodos
public interface IUsuarioRepository
{
    public void Create(Usuario usuario);
    public bool Update(Usuario usuario);
    public bool Remove(int idUsuario);
    public List<Usuario> GetAll();
    public Usuario GetByIdUsuario(int idUsuario);
}