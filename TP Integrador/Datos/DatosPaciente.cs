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
        AccesoDatos ad = new AccesoDatos();


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
                                Nacionalidad = reader["Nacionalidad_pac"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento_pac"]),
                                Direccion = reader["Direccion_pac"].ToString(),
                                Localidad = reader["Localidad_pac"].ToString(),
                                Provincia = reader["Provincia_pac"].ToString(),
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