using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioProvincia
    {
        DatosProvincia dp = new DatosProvincia();
        DataTable dt = new DataTable();
        public DataTable CargarProvincias()
        {
            dt = dp.ObtenerProvincias();
            return dt;
        }
    }
}
