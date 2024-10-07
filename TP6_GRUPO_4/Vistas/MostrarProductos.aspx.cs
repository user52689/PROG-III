using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_GRUPO_4.Vistas
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack == false)
            {
                MostrarProductosSeleccionados();
            }
        }

        protected void MostrarProductosSeleccionados()
        {
            if (Session["ProductosSeleccionados"] != null)
            {
                DataTable dt = (DataTable)Session["ProductosSeleccionados"];

                grdProductosSeleccionados.DataSource = dt;
                grdProductosSeleccionados.DataBind();
            }
            else
            {
                lblMensaje.Text = "No hay productos seleccionados.";
            }
        }
    }
}