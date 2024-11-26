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
    }
}
