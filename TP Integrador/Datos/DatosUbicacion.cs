using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosUbicacion
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable ObtenerDatos(string tabla)
        {

            string consulta = $"SELECT * FROM {tabla}"; 
            DataTable dt;
            return dt = ad.ObtenerTabla($"{tabla}", consulta);
        }

        public DataTable ObtenerDatosPorProvincia(int idprov)
        {
            // Define la consulta directa con un parámetro
            string consulta = $"SELECT IdLocalidad_loc, Nombre_loc FROM Localidades WHERE IdProvincia_prov = {idprov}";

      
            return ad.ObtenerTabla("Localidades",consulta);
        }

  public int ObtenerIdProvinciaPorNombre(int nombreProvincia)
        {
            int provinciaId = -1;

            string consulta = $"SELECT IdProvincia_prov FROM Provincias WHERE Nombre_prov = '{nombreProvincia}'";

            DataTable dt = ad.ObtenerTabla("Provincias", consulta);  
            if (dt.Rows.Count > 0)
            {

                provinciaId = Convert.ToInt32(dt.Rows[0]["IdProvincia_prov"]);
            }

            return provinciaId;
        }

        
    }
}
