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
    public class DatosInforme
    {
        private readonly AccesoDatos accesoDatos = new AccesoDatos();

        public List<Informe> ObtenerInformeAsistencias(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Informe> informes = new List<Informe>();
            SqlCommand cmd = new SqlCommand("sp_InformeAsistencias");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

            DataTable dt = accesoDatos.ObtenerTablaConComando("InformeAsistencias", cmd);

            foreach (DataRow row in dt.Rows)
            {
                informes.Add(new Informe
                {
                    IdTurno = Convert.ToInt32(row["IdTurno_tu"]),
                    NombrePaciente = row["Nombre_pac"].ToString(),
                    ApellidoPaciente = row["Apellido_pac"].ToString(),
                    EstadoTurno = row["EstadoTurno"].ToString(),
                    FechaTurno = Convert.ToDateTime(row["FechaTurno_tu"])
                });
            }

            return informes;
        }

        public List<KeyValuePair<string, int>> ObtenerResumenEstadosTurnos(DateTime fechaInicio, DateTime fechaFin)
        {
            List<KeyValuePair<string, int>> resumen = new List<KeyValuePair<string, int>>();
            SqlCommand cmd = new SqlCommand("sp_ResumenEstadosTurnos");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

            DataTable dt = accesoDatos.ObtenerTablaConComando("ResumenEstadosTurnos", cmd);

            foreach (DataRow row in dt.Rows)
            {
                resumen.Add(new KeyValuePair<string, int>(
                    row["EstadoTurno"].ToString(),
                    Convert.ToInt32(row["Cantidad"])
                ));
            }

            return resumen;
        }

        public List<KeyValuePair<string, int>> ObtenerEspecialidadesMasAtendidas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<KeyValuePair<string, int>> especialidades = new List<KeyValuePair<string, int>>();
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "sp_EspecialidadesMasAtendidas",
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

            DataTable dt = accesoDatos.ObtenerTablaConComando("EspecialidadesMasAtendidas", cmd);

            foreach (DataRow row in dt.Rows)
            {
                especialidades.Add(new KeyValuePair<string, int>(
                    row["Especialidad"].ToString().Trim(),
                    Convert.ToInt32(row["TotalAtenciones"])
                ));
            }
            return especialidades;
        }

    }
}
