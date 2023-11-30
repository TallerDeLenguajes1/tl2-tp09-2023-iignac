using System.Data.SQLite;

namespace tl2_tp09_2023_iignac;

public class UsuarioRepository : IUsuarioRepository
{
    private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared"; //@"Data...

    public void Create(Usuario nuevoUsuario){
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            string query = @"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombreUs);";  //$INSERT...(@nombreUs)"; 
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@nombreUs", nuevoUsuario.NombreUsuario));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public bool Update(Usuario usuarioModificar){
        bool usuarioModificado = false;
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            string query = @"UPDATE Usuario SET nombre_de_usuario = @nombreUs WHERE id = @idUs;"; //$UPDATE...
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idUs", usuarioModificar.Id));
            command.Parameters.Add(new SQLiteParameter("@nombreUs", usuarioModificar.NombreUsuario));
            if(command.ExecuteNonQuery() > 0) usuarioModificado=true;
            connection.Close();
        }
        return usuarioModificado;
    }
    public List<Usuario> GetAll(){
        List<Usuario> listaUsuarios = new List<Usuario>();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            string query = @"SELECT * FROM Usuario;"; //$SELECT...
            SQLiteCommand command = new SQLiteCommand(query, connection);
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                    listaUsuarios.Add(usuario);
                }
            }
            connection.Close();
        }
        return listaUsuarios;
    }

    public Usuario GetByIdUsuario(int idUsuario){
        Usuario usuario = new Usuario();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            string query = @"SELECT * FROM Usuario WHERE id = @idUs;"; 
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idUs", idUsuario));
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();
        }
        return usuario;
    }

    public bool Remove(int idUsuario){
        bool usuarioEliminado = false;
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            string query = @"DELETE FROM Usuario WHERE id = @idUs;"; //$DELETE...
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idUs", idUsuario));
            if (command.ExecuteNonQuery() > 0) usuarioEliminado = true;
            connection.Close();
        }
        return usuarioEliminado;
    } 
}