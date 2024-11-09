using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;


namespace Negocios
{
    public class NegociosPaciente
    {
        private readonly AccesoDatos accesoDatos = new AccesoDatos();

        public List<Paciente> ObtenerListaPacientes()
        {
            string consulta = "SELECT * FROM Pacientes";
            DataTable dt = accesoDatos.ObtenerTabla("Pacientes", consulta);
            List<Paciente> listaPacientes = new List<Paciente>();

            foreach (DataRow row in dt.Rows)
            {
                Paciente paciente = new Paciente
                {
                    DNI = row["DNI_pac"].ToString(),
                    Nombre = row["Nombre_pac"].ToString(),
                    Apellido = row["Apellido_pac"].ToString(),
                    Genero = row["Genero_pac"].ToString(),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_pac"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_pac"]),
                    Direccion = row["Direccion_pac"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_pac"]),
                    Provincia = Convert.ToInt32(row["Provincia_pac"]),
                    CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
                    Telefono = row["Telefono_pac"]?.ToString()
                };
                listaPacientes.Add(paciente);
            }

            return listaPacientes;
        }


        public Paciente ObtenerPacientePorDNI(string dni)
        {
            DataTable dt = accesoDatos.FiltrarDni(dni);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Paciente
                {
                    DNI = row["DNI_pac"].ToString(),
                    Nombre = row["Nombre_pac"].ToString(),
                    Apellido = row["Apellido_pac"].ToString(),
                    Genero = row["Genero_pac"].ToString(),
                    Nacionalidad = Convert.ToInt32(row["Nacionalidad_pac"]),
                    FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento_pac"]),
                    Direccion = row["Direccion_pac"].ToString(),
                    Localidad = Convert.ToInt32(row["Localidad_pac"]),
                    Provincia = Convert.ToInt32(row["Provincia_pac"]),
                    CorreoElectronico = row["CorreoElectronico_pac"].ToString(),
                    Telefono = row["Telefono_pac"].ToString()
                };
            }
            return null;
        }

    }
}
