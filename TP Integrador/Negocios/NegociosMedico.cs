using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace Negocios
{
    public class NegociosMedico
    {
        private readonly AccesoDatos accesoDatos = new AccesoDatos();
        readonly  Medico medico = new Medico();
        readonly DatosMedico datosM = new DatosMedico();

        public DataTable GetTablaPacietneNegocios()
        {
            return datosM.GetTablaMedicosDatos();
        }


        public Medico ObtenerMedicosPorLegajo(int Legajo)
        {
            DataTable dt = accesoDatos.FiltrarMedicoPorLegajo(Legajo);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Medico
                {
                    Legajo = Convert.ToInt32(row["Legajo_med"]),
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
                    Telefono = row["Telefono_pac"].ToString(),
                    Especialidad = Convert.ToInt32(row["Telefono_pac"])
                };
            }
            return null;
        }

        public DataTable FiltrarMedicoLegajoNegocios(int Legajo)
        {
            return datosM.FiltrarMedicoLegajoDatos(Legajo);
        }


        public int EliminarMedicoNegocio(int Legajo)
        {
            medico.Legajo = Legajo;
            int estado = datosM.EliminarMedicosDatos(medico);
            if (estado >= 1)
            {
                return estado;
            }
            else
            {
                return estado;
            }
        }
    }
}
