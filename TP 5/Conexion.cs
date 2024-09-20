using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Web.UI.WebControls;


namespace TP_5
{
    public class Conexion 
    {
        private string ruta = "Data Source=localhost\\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=true";
        private SqlConnection cn = null;
        private SqlCommand cmd = null;

        public int Transaccion(SqlCommand cmd)
        {
            try
            {
                using (this.cn = new SqlConnection(this.ruta))
                {
                    cmd.Connection = cn;

                    cn.Open();
                    
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if(filasAfectadas == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en la conexión SQL: " + ex.Message);
                return 2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió algún error: " + ex.Message);
                return 3;
            }
        }

        public string getRuta()
        {
            return ruta;
        }
    }
}