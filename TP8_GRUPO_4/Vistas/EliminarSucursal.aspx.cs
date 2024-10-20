using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class EliminarSucursal : System.Web.UI.Page
    {
        NegocioSucursal ns = new NegocioSucursal();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminarSucursal_Click(object sender, EventArgs e)
        {
            //Verificar si el ID ingresado es válido
            if (int.TryParse(txtEliminarSucursalID.Text, out int idSucursal))
            {
                // Intentar eliminar la sucursal
                bool eliminado = ns.eliminarSucursal(idSucursal);

                if (eliminado)
                {
                    lblMensaje.Text = "La sucursal se ha eliminado con exito.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    LimpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "No se encontro la sucursal o no se pudo eliminar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    LimpiarCampos();
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un ID valido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos();
            }

        }

        protected void LimpiarCampos()
        {
            txtEliminarSucursalID.Text = string.Empty;

        }
    }
}