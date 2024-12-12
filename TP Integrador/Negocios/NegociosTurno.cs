using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Negocios
{
    public class NegociosTurnos
    {
        public DataTable ObtenerDatosMedico(int legajoMedico)
        {
            DatosTurnos datosTurnos = new DatosTurnos();
            return datosTurnos.ObtenerDatosMedico(legajoMedico);
        }

        public List<Turno> ObtenerTurnosPorMedico(int legajoMedico)
        {
            DatosTurnos datosTurnos = new DatosTurnos();
            return datosTurnos.ObtenerTurnosPorMedico(legajoMedico);
        }

        public void ActualizarTurno(int idTurno, int asistencia, string observacion)
        {
            DatosTurnos datosTurnos = new DatosTurnos();
            datosTurnos.ActualizarTurno(idTurno, asistencia, observacion);
        }

        public DateTime ObtenerFechaTurno(string idPaciente)
        {
            DatosTurnos datosTurnos = new DatosTurnos();
            return datosTurnos.ObtenerFechaTurno(idPaciente);
        }

        public DataTable FiltrarTurnosPorFechas(int legajoMedico, DateTime fechaInicio, DateTime fechaFin)
        {
            DatosTurnos datosTurnos = new DatosTurnos();
            return datosTurnos.ObtenerTurnosPorFechasYMedico(legajoMedico, fechaInicio, fechaFin);
        }

    }
}