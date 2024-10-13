using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_GRUPO_4.Controladores;

namespace TP7_GRUPO_4.Vistas
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSeleccionar_Command1(object sender, CommandEventArgs e)
        {
            //ItemTemplate
            if (e.CommandName == "eventoSeleccionar")
            {
                GestionSucursales gs = new GestionSucursales();
                gs.VariableSessionSucursalesSeleccionadas(sender, e, lblMostrarSucursalesSeleccionadas, lblCantidadSucursalesSeleccionadas);                
            }
        }

        protected void btnSeleccionar_Command2(object sender, CommandEventArgs e)
        {
            //AlternatinItemTemplate
            if (e.CommandName == "eventoSeleccionar")
            {
                GestionSucursales gs = new GestionSucursales();
                gs.VariableSessionSucursalesSeleccionadas(sender, e, lblMostrarSucursalesSeleccionadas, lblCantidadSucursalesSeleccionadas);
            }
        }
    }
}