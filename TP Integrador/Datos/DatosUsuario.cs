using System;
using Seguridad;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;


namespace Datos
{
    public class DatosUsuario
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConexionClinica"].ConnectionString;

        //------------------------------------------------------------METODO PARA VERIFICACION DE USUARIO
        public Usuario ObtenerUsuarioPorCredenciales(string nombreUsuario, string contraseña)
        {
            Usuario usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id_usr, NombreUsuario_usr, Contraseña_usr, Rol_usr FROM Usuarios WHERE NombreUsuario_usr = @NombreUsuario";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string hashedPassword = reader["Contraseña_usr"].ToString();
                    if (Seguridad.HashHelper.VerifyPassword(contraseña, hashedPassword))
                    {
                        usuario = new Usuario
                        {
                            Id = (int)reader["Id_usr"],
                            NombreUsuario = reader["NombreUsuario_usr"].ToString(),
                            Contraseña = hashedPassword,
                            Rol = reader["Rol_usr"].ToString()
                        };
                    }
                }
            }
            return usuario;
        }

        //------------------------------------------------------------METODOS PARA REGISTRO USUARIO
        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            Usuario usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id_usr, NombreUsuario_usr, Rol_usr FROM Usuarios WHERE NombreUsuario_usr = @NombreUsuario";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        Id = (int)reader["Id_usr"],
                        NombreUsuario = reader["NombreUsuario_usr"].ToString(),
                        Rol = reader["Rol_usr"].ToString()
                    };
                }
            }
            return usuario;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                usuario.Contraseña = Seguridad.HashHelper.HashPassword(usuario.Contraseña);  // Hash de la contraseña
                string query = "INSERT INTO Usuarios (NombreUsuario_usr, Contraseña_usr, Rol_usr) VALUES (@NombreUsuario, @Contraseña, @Rol)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                connection.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        //------------------------------------------------------------METODOS PARA MODIFICACION USUARIO
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("ListarUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Id = (int)reader["Id_usr"],
                        NombreUsuario = reader["NombreUsuario_usr"].ToString(),
                        Contraseña = reader["Contraseña_usr"].ToString(),
                        Rol = reader["Rol_usr"].ToString()
                    });
                }
                reader.Close();
            }
            return usuarios;
        }

        public bool ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Paso 1: Obtener la contraseña actual de la base de datos
                string contraseñaActual = string.Empty;
                string queryObtenerContraseña = "SELECT Contraseña_usr FROM Usuarios WHERE Id_usr = @Id_usr";

                using (SqlCommand cmdObtenerContraseña = new SqlCommand(queryObtenerContraseña, connection))
                {
                    cmdObtenerContraseña.Parameters.AddWithValue("@Id_usr", usuario.Id);
                    connection.Open();
                    contraseñaActual = (string)cmdObtenerContraseña.ExecuteScalar();
                    connection.Close();
                }

                // Paso 2: Encriptar la nueva contraseña solo si ha sido modificada
                if (!string.IsNullOrEmpty(usuario.Contraseña) && usuario.Contraseña != contraseñaActual)
                {
                    usuario.Contraseña = Seguridad.HashHelper.HashPassword(usuario.Contraseña);
                }
                else
                {
                    usuario.Contraseña = contraseñaActual; // Mantener la contraseña actual sin cambios
                }

                // Paso 3: Ejecutar la actualización
                using (SqlCommand cmd = new SqlCommand("ModificarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_usr", usuario.Id);
                    cmd.Parameters.AddWithValue("@NombreUsuario_usr", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contraseña_usr", usuario.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol_usr", usuario.Rol);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        public bool VerificarNombreUsuarioExistente(string nombreUsuario, int userId)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario_usr = @NombreUsuario AND Id_usr <> @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                existe = count > 0;
            }
            return existe;
        }
    }
}