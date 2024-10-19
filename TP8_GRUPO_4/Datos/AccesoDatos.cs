using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class AccesoDatos
    {
        string rutaBDSucursales = "Data Source=localhost\\sqlexpress;Initial Catalog=BDSucursales;Integrated Security=True";

        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDSucursales);
            
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        private SqlDataAdapter ObtenerAdaptador(string consulta, SqlConnection cn)
        {
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);

            try
            {
                return adp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(string tabla, string consulta)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(consulta, conexion);
            adp.Fill(ds, tabla);
            conexion.Close();
            return ds.Tables[tabla];
        }
        public DataTable ObtenerTablaConComando(string tabla, SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            cmd.Connection = conexion;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(ds, tabla);
            conexion.Close();
            return ds.Tables[tabla];
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand cmd, string sp)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand _cmd = new SqlCommand();
            _cmd = cmd;
            _cmd.Connection = Conexion;
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.CommandText = sp;
            FilasCambiadas = _cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public bool ExisteRegistro(string consulta)
        {
            bool estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }
    }
}
