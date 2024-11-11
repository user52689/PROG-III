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
        DataSet ds  = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection conexion = new SqlConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public Paciente ObtenerPacientes(int dni)
        {
            string consulta = "SELECT * FROM Pacientes WHERE DNI_pac = @DNI";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", dni);

            using (SqlConnection conexion = ad.ObtenerConexion())
            {
                if (conexion == null)
                {
                    Console.WriteLine("No conectado");
                    return null;
                }

                cmd.Connection = conexion;

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Paciente paciente = new Paciente
                            {
                                DNI = reader["DNI_pac"].ToString(),
                                Nombre = reader["Nombre_pac"].ToString(),
                                Apellido = reader["Apellido_pac"].ToString(),
                                Genero = Convert.ToInt32(reader["Genero_pac"]),
                                Nacionalidad = Convert.ToInt32(reader["Nacionalidad_pac"]),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento_pac"]),
                                Direccion = reader["Direccion_pac"].ToString(),
                                Localidad = Convert.ToInt32(reader["Localidad_pac"]),
                                Provincia = Convert.ToInt32(reader["Provincia_pac"]),
                                CorreoElectronico = reader["CorreoElectronico_pac"].ToString(),
                                Telefono = reader["Telefono_pac"]?.ToString()
                            };
                            return paciente;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el paciente: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                }
            }

            return null;
        }

        public Paciente ObtenerPacientesPorDni(int dni)
        {
            throw new NotImplementedException();
        }




        public List<Paciente> ObtenerTodosLosPacientes()
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            string consulta = "SELECT * FROM Pacientes";

            using (SqlConnection conexion = ad.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Paciente paciente = new Paciente
                            {
                                DNI = reader["DNI_pac"].ToString(),
                                Nombre = reader["Nombre_pac"].ToString(),
                                Apellido = reader["Apellido_pac"].ToString(),
                                Genero = Convert.ToInt32(reader["Genero_pac"]),
                                Nacionalidad = Convert.ToInt32(reader["Nacionalidad_pac"]),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento_pac"]),
                                Direccion = reader["Direccion_pac"].ToString(),
                                Localidad = Convert.ToInt32(reader["Localidad_pac"]),
                                Provincia = Convert.ToInt32(reader["Provincia_pac"]),
                                CorreoElectronico = reader["CorreoElectronico_pac"].ToString(),
                                Telefono = reader["Telefono_pac"]?.ToString()
                            };
                            listaPacientes.Add(paciente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener la lista de pacientes: " + ex.Message);
                }
            }

            return listaPacientes;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------Obtener paciente
        public DataTable GetTablaPacientesDatos() //Muestra todos los pacientes con todos los campos
        {
            string consulta = "SELECT * " +
                              "FROM Pacientes";
            return ad.ObtenerTabla("Pacientes", consulta);
        }
        public DataTable FiltrarPacienteDNIBajaDatos(string DNI) //Muestra un paciente y solo los campos para la Baja
        {
            string consulta = "SELECT DNI_pac, Nombre_pac, Apellido_pac " +
                              "FROM Pacientes " +
                              "WHERE DNI_pac = @DNI";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", DNI);
            return ad.ObtenerTablaConComando("Pacientes", cmd);
        }


        //public DataTable FiltrarPacienteDNIModificacionDatos(string DNI) //Muestra un paciente y todos los campos para la modificacion
        //{
        //    string consulta = "SELECT * " +
        //           "FROM Pacientes " +
        //           "WHERE DNI_pac = @DNI";
        //    SqlCommand cmd = new SqlCommand(consulta);
        //    cmd.Parameters.AddWithValue("@DNI", DNI);
        //    return ad.ObtenerTablaConComando("Pacientes", cmd);
        //}

        public DataTable FiltrarPacienteDNIModificacionDatos(string DNI)
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
                               WHERE p.DNI_pac = @DNI";

            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", DNI);

            return ad.ObtenerTablaConComando("Pacientes", cmd);
        }

        //------------------------------------------------------------------------------------------------Obtener Genero de los pacientes
        public DataTable ObtenerGeneros()
        {
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdGenero_g, Descripcion_g FROM Generos");
            dt = ad.ObtenerTablaConComando("Generos", cmd);
            return dt;
        }

        //------------------------------------------------------------------------------------------------Obtener Nacionalidad de los pacientes
        public DataTable ObtenerNacionalidades()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdPais_p, Nombre_pais FROM Paises");
            dt = ad.ObtenerTablaConComando("Paises", cmd);
            return dt;
        }
        //------------------------------------------------------------------------------------------------Obtener Provincia de los pacientes

        public DataTable ObtenerProvincias()
        {
            cmd = new SqlCommand("SELECT DISTINCT IdProvincia_prov, Nombre_prov FROM Provincias");
            dt = ad.ObtenerTablaConComando("Provincias", cmd);
            return dt;
        }



        //------------------------------------------------------------------------------------------------Obtener Localidad de los pacientes
        public DataTable ObtenerLocalidades()
        {
            cmd = new SqlCommand("SELECT IdLocalidad_loc, Nombre_loc FROM Localidades");
            dt = ad.ObtenerTablaConComando("Localidades", cmd);
            return dt;
        }
        public DataTable ObtenerLocalidadesPorProvincia(int IdProvincia)
        {
            string consulta = "SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_loc = @IdProvincia";
            cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);

            return ad.ObtenerTablaConComando("Localidades", cmd);
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------Agregar Pacientes
        public bool AgregarPaciente(Paciente nuevoPaciente)
        {
            string consulta = @"INSERT INTO PACIENTES (DNI_Pac, Nombre_pac, Apellido_pac, Sexo_pac, Nacionalidad_pac, 
                      FechaNacimiento_pac, Direccion_pac, Localidad_pac, Provincia_pac, CorreoElectronico_pac, Telefono_pac)
                      VALUES (@DNI, @Nombre, @Apellido, @Sexo, @Nacionalidad, @FechaNacimiento, @Direccion, 
                      @Localidad, @Provincia, @CorreoElectronico, @Telefono)";

            using (SqlConnection conexion = ad.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@DNI", nuevoPaciente.DNI);
                cmd.Parameters.AddWithValue("@Nombre", nuevoPaciente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", nuevoPaciente.Apellido);
                cmd.Parameters.AddWithValue("@Sexo", nuevoPaciente.Genero);
                cmd.Parameters.AddWithValue("@Nacionalidad", nuevoPaciente.Nacionalidad);
                cmd.Parameters.AddWithValue("@FechaNacimiento", nuevoPaciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Direccion", nuevoPaciente.Direccion);
                cmd.Parameters.AddWithValue("@Localidad", nuevoPaciente.Localidad);
                cmd.Parameters.AddWithValue("@Provincia", nuevoPaciente.Provincia);
                cmd.Parameters.AddWithValue("@CorreoElectronico", nuevoPaciente.CorreoElectronico);
                cmd.Parameters.AddWithValue("@Telefono", nuevoPaciente.Telefono);

                try
                {
                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar el paciente: " + ex.Message);
                    return false;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------------------------------------Eliminar Paciente

        public int EliminarPacienteDatos(Paciente paciente)
        {
            cmd.CommandText = "SP_EliminarPaciente";  
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI_pac", paciente.DNI);

            return ad.EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarPaciente");
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------Actualizar Paciente
        public DataTable ModificarPaciente(Paciente paciente)
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

            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, "Pacientes");

            int filasCambiadas = ad.EjecutarProcedimientoAlmacenado(cmd, "SP_ModificarPaciente");

            return dt;
        }

    }
}