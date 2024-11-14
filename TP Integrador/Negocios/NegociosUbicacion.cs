using Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NegociosUbicacion
    {
        DatosUbicacion du = new DatosUbicacion();
        public DataTable ObtenerProvincias()
        {
            return du.ObtenerDatos("provincias");
        }

        // Método para obtener localidades por provincia
        public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            return du.ObtenerDatosPorProvincia(idProvincia);
        }

        public DataTable ObtenerPaises()
        {
            return du.ObtenerDatos("paises");
        }
  public int ObtenerIdProvinciaNombre(int nombreProvinia)
        {
            return du.ObtenerIdProvinciaPorNombre(nombreProvinia);

        }

    }
}
