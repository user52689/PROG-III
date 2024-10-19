using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosProvincia
    {
        AccesoDatos ad = new AccesoDatos();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        public DataTable ObtenerProvincias()
        {
            cmd = new SqlCommand("SELECT DISTINCT Id_Provincia, DescripcionProvincia FROM Provincia");
            dt =  ad.ObtenerTablaConComando("Provincia",cmd);
            return dt;
        }
    }
}
