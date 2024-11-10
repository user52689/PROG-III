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
    }
}
