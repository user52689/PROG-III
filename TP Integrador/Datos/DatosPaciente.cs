using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosPaciente
    {
        readonly AccesoDatos ad = new AccesoDatos();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conexion = new SqlConnection();




        //----------------------------------------------------------------------------------------------------------------------------------------ALTA
        public bool AgregarPaciente(Paciente paciente)
        {
            try
            {
                using (SqlConnection conexion = ad.ObtenerConexion())
                {
                    if (conexion == null) throw new Exception("No se pudo establecer la conexión con la base de datos.");

                    SqlCommand cmd = new SqlCommand("SP_AgregarPaciente", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);
                    cmd.Parameters.AddWithValue("@Nombre_pac", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido_pac", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@Genero_pac", paciente.Genero);
                    cmd.Parameters.AddWithValue("@Nacionalidad_pac", paciente.Nacionalidad);
                    cmd.Parameters.AddWithValue("@FechaNacimiento_pac", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Direccion_pac", paciente.Direccion);
                    cmd.Parameters.AddWithValue("@Localidad_pac", paciente.Localidad);
                    cmd.Parameters.AddWithValue("@Provincia_pac", paciente.Provincia);
                    cmd.Parameters.AddWithValue("@CorreoElectronico_pac", paciente.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono_pac", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@Estado_pac", paciente.Estado);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el paciente: " + ex.Message);
                return false;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------BAJA

        public int EliminarPacienteDatos(Paciente paciente)
        {
            string consulta = "UPDATE Pacientes SET Estado_pac = 0 WHERE DNI_pac = @DNI_pac";

            conexion = ad.ObtenerConexion();

            cmd = new SqlCommand(consulta, conexion);

            cmd.CommandText = consulta;
            cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);

            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------MODIFICACION
        public int ModificarPacienteDatos(Paciente paciente)
        {
            conexion = ad.ObtenerConexion();

            cmd = new SqlCommand("SP_ModificarPaciente", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);
            cmd.Parameters.AddWithValue("@Nombre_pac", paciente.Nombre);
            cmd.Parameters.AddWithValue("@Apellido_pac", paciente.Apellido);
            cmd.Parameters.AddWithValue("@Genero_pac", paciente.Genero);
            cmd.Parameters.AddWithValue("@Nacionalidad_pac", paciente.Nacionalidad);
            cmd.Parameters.AddWithValue("@FechaNacimiento_pac", paciente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Direccion_pac", paciente.Direccion);
            cmd.Parameters.AddWithValue("@Localidad_pac", paciente.Localidad);
            cmd.Parameters.AddWithValue("@Provincia_pac", paciente.Provincia);
            cmd.Parameters.AddWithValue("@CorreoElectronico_pac", paciente.CorreoElectronico);
            cmd.Parameters.AddWithValue("@Telefono_pac", paciente.Telefono);
            cmd.Parameters.AddWithValue("@Estado_pac", paciente.Estado);

            int filasAfectadas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ModificarPaciente");

            if (filasAfectadas > 0)
            {
                return 1;
            }
            return 0;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------LISTADO
        public DataTable GetTablaPacientesDatos() //Muestra todos los pacientes con todos los campos
        {
            string consulta = @"SELECT p.DNI_pac, 
                                       p.Nombre_pac,
                                       p.Apellido_pac, 
                                       g.Descripcion_g, 
                                       n.Nombre_pais,
                                       p.FechaNacimiento_pac,
                                       p.Direccion_pac, 
                                       pr.Nombre_prov, 
                                       l.Nombre_loc, 
                                       p.CorreoElectronico_pac,
                                       p.Telefono_pac
                                FROM Pacientes AS p
                                INNER JOIN Generos AS g ON p.Genero_pac = g.IdGenero_g
                                INNER JOIN Paises AS n ON p.Nacionalidad_pac = n.IdPais_p
                                INNER JOIN Localidades AS l ON p.Localidad_pac = l.IdLocalidad_loc
                                INNER JOIN Provincias AS pr ON p.Provincia_pac = pr.IdProvincia_prov
                                WHERE p.Estado_Pac = 1";

            return ad.ObtenerTabla("Pacientes", consulta);

        }
        public DataTable FiltrarPacienteDNIBajaDatos(string DNI) //Muestra un paciente y solo los campos para la Baja
        {
            string consulta = "SELECT DNI_pac, Nombre_pac, Apellido_pac " +
                              "FROM Pacientes " +
                              "WHERE DNI_pac = @DNI AND Estado_pac = 1";
            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@DNI", DNI);
            return ad.ObtenerTablaConComando("Pacientes", cmd);
        }


        public DataTable FiltrarPacienteDNIDatos(string DNI) //Muestra un paciente y todos los campos para la modificacion
        {
            string consulta = @"SELECT p.DNI_pac, 
                                       p.Nombre_pac,
                                       p.Apellido_pac, 
                                       g.Descripcion_g , 
                                       n.Nombre_pais,
                                       p.FechaNacimiento_pac,
                                       p.Direccion_pac, 
                                       pr.Nombre_prov, 
                                       l.Nombre_loc, 
                                       p.CorreoElectronico_pac,
                                       p.Telefono_pac
                               FROM Pacientes AS p
                               INNER JOIN Generos AS g ON p.Genero_pac = g.IdGenero_g
                               INNER JOIN Paises AS n ON p.Nacionalidad_pac = n.IdPais_p
                               INNER JOIN Localidades AS l ON p.Localidad_pac = l.IdLocalidad_loc
                               INNER JOIN Provincias AS pr ON p.Provincia_pac = pr.IdProvincia_prov
                               WHERE p.DNI_pac = @DNI AND Estado_pac = 1";
            conexion = ad.ObtenerConexion();
            cmd = new SqlCommand(consulta, conexion);
            cmd.Parameters.AddWithValue("@DNI", DNI);

            if (ad.ExisteRegistroConComando(cmd))
            {
                return ad.ObtenerTablaConComando("Pacientes", cmd);
            }
            return null;

        }
    }
}
