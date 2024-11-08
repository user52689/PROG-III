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


namespace Datos
{
    public class DatosUsuario
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Clinica;Integrated Security=True";

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
    }
}