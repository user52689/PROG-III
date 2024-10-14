using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_GRUPO_4.Controladores;

namespace TP7_GRUPO_4.Vistas
{
    public partial class ListadoSucursalesSeleccionadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GestionSucursales gs = new GestionSucursales();
                gs.CargarSucursalesEnGridView(grdSucursales);
            }
        }
    }
}