namespace tl2_tp09_2023_iignac;

public interface ITableroRepository
{
    public void Create(Tablero tablero);
    public bool Update(Tablero tablero);
    public bool Remove(int idTablero);
    public List<Tablero> GetAll();
    public Tablero GetByIdTablero(int idTablero);
    public List<Tablero> GetAllByIdUsuario(int idUsuario);
}