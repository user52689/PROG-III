using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_5
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        Conexion conexion = null;

        protected void EliminarSucursalID(string idSucursal)
        {
            string consulta = "DELETE FROM Sucursal WHERE Id_Sucursal = @Id_Sucursal";

            using (cmd = new SqlCommand(consulta, cn))
            {
                cmd.Parameters.AddWithValue("@Id_Sucursal", idSucursal);

                conexion = new Conexion();

                int mensaje = conexion.Transaccion(cmd);
                
                if(mensaje == 1)
                {
                    lblMensajeEliminacion.Text = "Se elimino la sucursal " + idSucursal + " de la BD";
                }
                else
                {
                    lblMensajeEliminacion.Text = "No se encuentra Se creo la funcion EliminarSucursalIDla sucursal " + idSucursal + " de la BD";
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string idSucursal = txtIdSucursal.Text.Trim();

            if (!string.IsNullOrEmpty(idSucursal))
            {
                EliminarSucursalID(idSucursal);
                txtIdSucursal.Text = string.Empty;
            }
        }
    }
}