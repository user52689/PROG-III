using System;
using Datos;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NegociosInforme
    {
        private readonly DatosInforme datosInforme = new DatosInforme();

        public List<Informe> GenerarInformeAsistencias(DateTime fechaInicio, DateTime fechaFin)
        {
            return datosInforme.ObtenerInformeAsistencias(fechaInicio, fechaFin);
        }

        public List<KeyValuePair<string, int>> ObtenerResumenEstadosTurnos(DateTime fechaInicio, DateTime fechaFin)
        {
            return datosInforme.ObtenerResumenEstadosTurnos(fechaInicio, fechaFin);
        }

        public List<KeyValuePair<string, int>> ObtenerEspecialidadesMasAtendidas(DateTime fechaInicio, DateTime fechaFin)
        {
            return datosInforme.ObtenerEspecialidadesMasAtendidas(fechaInicio, fechaFin);
        }
    }
}
