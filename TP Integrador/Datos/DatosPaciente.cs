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
                                Genero = reader["Genero_pac"].ToString(),
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
                                Genero = reader["Genero_pac"].ToString(),
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



    }
}