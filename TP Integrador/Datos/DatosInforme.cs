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

    }
}
